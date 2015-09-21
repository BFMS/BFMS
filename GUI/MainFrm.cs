using BLogic;
using Shared;
using Shared.BFDO;
using Shared.GDO;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using DB;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using BFAPI;
using System.Drawing;
using log4net;


namespace GUI
{
    public partial class MainFrm : Form
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(MainFrm));

        private ServiceI service;
        private List<MarketCatalogue> marketCat;
        private Dictionary<string, Market> markets = new Dictionary<string, Market>();

        private MarketUpdate marketUpdate;

        private DBAccess dba = new DBAccess();

        public MainFrm(ServiceI service)
        {
            this.service = service;
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            //this.ShowInTaskbar = false;
        }

        private void GetMarketCat()
        {
            marketCat = service.GetMarkets();
            EventDGV.DataSource = marketCat;
        }


        private void MainFrm_Load(object sender, EventArgs e)
        {
            //BasicConfigurator.Configure();

            MarketScanCb.Appearance = System.Windows.Forms.Appearance.Button;
            marketUpdate = new MarketUpdate(service);
            marketUpdate.StartMarketUpdate(SynchronizationContext.Current, UpdateUI);
            //BFUtil.GetPriceIdx(1.01);
            GetMarketCat();
            if (logger.IsDebugEnabled)
            {
                logger.Debug("IsDebugEnabled");

            }
            //logger.Debug("Here is a debug log.");
            //logger.Info("... and an Info log.");
            //logger.Warn("... and a warning.");
            //logger.Error("... and an error.");
            //logger.Fatal("... and a fatal error.");


        }

        private void EventDGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MarketCatalogue mc = (MarketCatalogue)((DataGridView)sender).SelectedRows[0].DataBoundItem;
            if (!editorPane1.TabPages.ContainsKey(mc.MarketId))
            {
                TabPage newTabPage;
                if (editorPane1.TabCount == 1 && tabPage1.Name == "tabPage1")
                {
                    tabPage1.Name = mc.MarketId;
                    tabPage1.Text = mc.Event.Venue + " " + mc.LocalStartTimeHM;
                    newTabPage = tabPage1;
                }
                else
                {
                    newTabPage = new TabPage(mc.Event.Venue + " " + mc.LocalStartTimeHM);
                    newTabPage.Name = mc.MarketId;
                    editorPane1.TabPages.Add(newTabPage);
                }
                DataGridView dgv = new DataGridView();
                InitMarketDGV(dgv);
                newTabPage.Controls.Add(dgv);
                newTabPage.Controls.Add(InitMarketHeader());

                RichTextBox rtb = new RichTextBox();
                rtb.Size = editorPane1.Size;
                rtb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                editorPane1.TabPages[editorPane1.TabPages.Count - 1].Controls.Add(rtb);
                editorPane1.SelectTab(editorPane1.TabPages.Count - 1);

                //MarketBook mb = service.GetMarketBook(mc.MarketId);
                MarketBook mb = new MarketBook();
                //MarketBook mb = ((List<MarketBook>)Util.DeserializeObj("BFMS.marketBooks" + ((DataGridView)sender).SelectedRows[0].Index + 0)).Find(c => c.MarketId == mc.MarketId);
                mb.marketCatalogue = mc;
                if (Config.ServiceMode == Config.Mode.DB)
                {
                    mc.Runners = dba.GetRunnerDesc(mc.MarketId);
                }
                Market market = new Market(mc);
                markets.Add(market.MarketId, market);

                dgv.DataSource = market;
                dgv.CurrentCell = null;
                marketUpdate.AddMarket(mc);
            }
            else
            {
                editorPane1.SelectTab(mc.MarketId);
            }
        }
        private void MarketScanCb_CheckedChanged(object sender, EventArgs e)
        {
            if (MarketScanCb.Checked)
            {
                SynchronizationContext sc = SynchronizationContext.Current;
                marketUpdate.AddMarkets(marketCat);
                MarketScanCb.Text = "STOP Scanner";
            }
            else
            {
                marketUpdate.RemoveMarkets(marketCat);
                MarketScanCb.Text = "START Scanner";
            }
        }

        private void UpdateUI(object state)
        {
            Util.GUIUpdate gu = (Util.GUIUpdate)state;
            if (gu.updateAction.Equals(Util.GUIUpdate.UpdateAction.Market))
            {
                UpdateMarket(gu.market);
            }
            else if (gu.updateAction.Equals(Util.GUIUpdate.UpdateAction.Message))
            {
                if (String.IsNullOrEmpty(gu.param.ToString()))
                {
                    ShowMsg(gu.msgNr);
                }
                else
                {
                    ShowMsg(gu.msgNr, gu.param);
                }

            }
            else if (gu.updateAction.Equals(Util.GUIUpdate.UpdateAction.Req_Stop))
            {
                //statusStrip1.Items["StatusLabel"].Text = gu.statusLineStr;
                //MarketScanCb.Checked = false;
                //MarketScanCb_CheckedChanged(null, null);
            }
        }

        private void UpdateMarket(object state)
        {
            Market market = (Market)state;
            if (editorPane1.TabPages.ContainsKey(market.MarketId))
            {
                TabPage tp = editorPane1.TabPages[market.MarketId];
                if (editorPane1.SelectedTab == tp && tp.Controls.Count > 0)
                {
                    Market ma = new Market();
                    markets.TryGetValue(market.MarketId, out ma);
                    ma.Copy(market);
                    //((DataGridView)tp.Controls["MarketDGV"]).Update();
                    ((DataGridView)tp.Controls["MarketDGV"]).Refresh();
                    RefreshMarketHeader((StatusStrip)tp.Controls["statusStrip2"], ma);
                }
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MarketScannerTH != null)
            //{
            //    marketScanner.RequestStop();
            //}
            marketUpdate.RequestStop();

        }

        private void editorPane1_OnTabClose(object sender, TabCloseEventArgs e)
        {

            if (editorPane1.TabPages.Count == 1)
            {
                // e.Accept = false;
            }
            //editorPane1.SelectTab(e.TabIndex);
            TabPage tp = (TabPage)sender;
            if (editorPane1.TabPages.ContainsKey(tp.Name) && tp.Controls.Count > 0)
            {
                MarketCatalogue market = marketCat.Find(x => x.MarketId == tp.Name);
                marketUpdate.RemoveMarket(market.MarketId);
                MarketBook mb =new MarketBook();
                marketUpdate.LastBooks.TryRemove(market.MarketId, out mb);
                markets.Remove(tp.Name);
            }

        }



        private void InitMarketDGV(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            DataGridViewTextBoxColumn RunnerName = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn Status = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn TotalMatched = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Matched = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn VolumeBack = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn VolumeLay = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn InsMoneyBack = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn InsMoneyLay = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn LastPriceTraded = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn AvgOdds = new DataGridViewTextBoxColumn();
            //DataGridViewTextBoxColumn RelativeExposure = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Indikator1 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Indikator2 = new DataGridViewTextBoxColumn();


            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
             RunnerName,
             //Status,
             TotalMatched,
             Matched,
             VolumeBack,
             VolumeLay,
             InsMoneyBack,
             InsMoneyLay,
             LastPriceTraded,
             AvgOdds,
             //RelativeExposure,
             Indikator1,
             Indikator2
            });
            BindingSource bs = new BindingSource();

            bs.DataSource = typeof(Shared.GDO.Market);
            dgv.DataMember = "Runners";
            dgv.DataSource = bs;
            dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            //dgv.Location = new System.Drawing.Point(3, 28);
            dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            dgv.MultiSelect = false;
            dgv.Name = "MarketDGV";
            dgv.ReadOnly = true;
            dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgv.RowHeadersVisible = false;
            //dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.RowTemplate.Height = 24;
            dgv.RowTemplate.ReadOnly = true;
            //dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            dgv.ShowCellErrors = false;
            dgv.ShowCellToolTips = false;
            dgv.ShowEditingIcon = false;
            dgv.ShowRowErrors = false;
            //dgv.Size = new System.Drawing.Size(921, 387);
            dgv.TabIndex = 5;
            dgv.TabStop = false;
            dgv.Visible = true;
            dgv.Enabled = true;

            //Alignment rechts für Zahlen
            DataGridViewCellStyle cs = new DataGridViewCellStyle();
            cs.Alignment = DataGridViewContentAlignment.MiddleRight;


            // 
            // RunnerName
            // 
            RunnerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            RunnerName.DataPropertyName = "RunnerName";
            RunnerName.HeaderText = "Teilnehmer";
            RunnerName.MinimumWidth = 200;
            RunnerName.Name = "RunnerName";
            RunnerName.ReadOnly = true;
            RunnerName.Width = 203;
            // 
            // Status
            // 
            //Status.DataPropertyName = "Status";
            //Status.HeaderText = "Status";
            //Status.MinimumWidth = 50;
            //Status.Name = "Status";
            //Status.ReadOnly = true;
            // 
            // TotalMatched
            // 
            TotalMatched.DataPropertyName = "TotalMatched";
            TotalMatched.HeaderText = "Total";
            TotalMatched.Name = "TotalMatched";
            TotalMatched.ReadOnly = true;
            TotalMatched.DefaultCellStyle = cs;
            // 
            // Matched
            // 
            Matched.DataPropertyName = "Matched";
            Matched.HeaderText = "Aktuell";
            Matched.Name = "Matched";
            Matched.ReadOnly = true;
            Matched.DefaultCellStyle = cs;
            // 
            // VolumeBack
            // 
            VolumeBack.DataPropertyName = "VolumeBack";
            VolumeBack.HeaderText = "BackVolume";
            VolumeBack.Name = "BackVolume";
            VolumeBack.ReadOnly = true;
            VolumeBack.DefaultCellStyle = cs;
            // 
            // VolumeLay
            // 
            VolumeLay.DataPropertyName = "VolumeLay";
            VolumeLay.HeaderText = "LayVolume";
            VolumeLay.Name = "LayVolume";
            VolumeLay.ReadOnly = true;
            VolumeLay.DefaultCellStyle = cs;
            // 
            // InsMoneyBack
            // 
            InsMoneyBack.DataPropertyName = "InsMoneyBack";
            InsMoneyBack.HeaderText = "IMB";
            InsMoneyBack.Name = "InsMoneyBack";
            InsMoneyBack.ReadOnly = true;
            InsMoneyBack.DefaultCellStyle = cs;
            // 
            // InsMoneyLay
            // 
            InsMoneyLay.DataPropertyName = "InsMoneyLay";
            InsMoneyLay.HeaderText = "IML";
            InsMoneyLay.Name = "InsMoneyLay";
            InsMoneyLay.ReadOnly = true;
            InsMoneyLay.DefaultCellStyle = cs;

            // 
            // LastPriceTraded
            // 
            LastPriceTraded.DataPropertyName = "LastPriceTraded";
            LastPriceTraded.HeaderText = "LPT";
            LastPriceTraded.MinimumWidth = 50;
            LastPriceTraded.Name = "LastPriceTraded";
            LastPriceTraded.ReadOnly = true;
            LastPriceTraded.DefaultCellStyle = cs;
            // 
            // AvgOdds
            // 
            AvgOdds.DataPropertyName = "AvgOdds";
            AvgOdds.HeaderText = "AvgOdds";
            AvgOdds.MinimumWidth = 50;
            AvgOdds.Name = "AvgOdds";
            AvgOdds.ReadOnly = true;
            AvgOdds.DefaultCellStyle = cs;
            // 
            // RelativeExposure
            // 
            //RelativeExposure.DataPropertyName = "RelativeExposure";
            //RelativeExposure.HeaderText = "RelativeExposure";
            //RelativeExposure.MinimumWidth = 100;
            //RelativeExposure.Name = "RelativeExposure";
            //RelativeExposure.ReadOnly = true;
            //RelativeExposure.DefaultCellStyle = cs;
            // Indikator1
            // 
            Indikator1.DataPropertyName = "Indikator1";
            Indikator1.HeaderText = "Indikator1";
            Indikator1.MinimumWidth = 100;
            Indikator1.Name = "Indikator1";
            Indikator1.ReadOnly = true;
            Indikator1.DefaultCellStyle = cs;
            // Indikator2
            // 
            Indikator2.DataPropertyName = "Indikator2";
            Indikator2.HeaderText = "Indikator2";
            Indikator2.MinimumWidth = 100;
            Indikator2.Name = "Indikator2";
            Indikator2.ReadOnly = true;
            Indikator2.DefaultCellStyle = cs;

            dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MarketDGV_CellDoubleClick);

        }

        private StatusStrip InitMarketHeader()
        {
            ToolStripStatusLabel toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ToolStripStatusLabel toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            StatusStrip statusStrip2 = new StatusStrip();

            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(812, 20);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "Event";
            toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            // 
            // toolStripStatusLabel2
            // 
            //toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            //toolStripStatusLabel2.Size = new System.Drawing.Size(50, 20);
            //toolStripStatusLabel2.Text = "Status";
            //toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            //toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;



            // statusStrip2
            // 
            statusStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            statusStrip2.ImageScalingSize = new System.Drawing.Size(18, 35);
            statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripStatusLabel1,
            toolStripStatusLabel2});
            statusStrip2.Location = new System.Drawing.Point(3, 3);
            statusStrip2.Name = "statusStrip2";
            statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            statusStrip2.Size = new System.Drawing.Size(921, 35);
            statusStrip2.TabIndex = 4;
            statusStrip2.Text = "";
            statusStrip2.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            statusStrip2.BackColor = System.Drawing.SystemColors.Highlight;
            statusStrip2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;

            return statusStrip2;
        }

        private void RefreshMarketHeader(StatusStrip sstrip, Market market)
        {
            int nrNonRunners = market.NumberOfRunners - market.NumberOfActiveRunners;
            string nonRunners = nrNonRunners > 0 ? nrNonRunners + " NS" : "";
            ((ToolStrip)sstrip).Items[0].Text = String.Format("{0,5}", market.RefreshNr) + " | " + market.LocalStartTime.Date.ToString("dd.MM") + " " + market.EventName + " " +
                market.LocalStartTime.ToString("HH:mm") + "   " + market.Name + "   " + market.Type +
                "   Umsatz: " + market.TotalMatched.ToString("C");

            ((ToolStrip)sstrip).Items[1].Text = "     OVR:" + String.Format("{0,5}", market.Ovr) + "   Starter: " + market.NumberOfRunners + " " + nonRunners + "     Status: " + market.Status;
        }

        private void DBLoggingCB_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                marketUpdate.CheckMarkets();
                Config.IsDBLogging = true;
            }
        }


        private void MarketDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            const int MINELEM = 16;

            string marketId = ((Shared.GDO.Market)(((System.Windows.Forms.DataGridView)(sender)).DataSource)).MarketId;
            long selId = ((Shared.GDO.MarketItem)(((System.Windows.Forms.DataGridView)(sender)).CurrentRow.DataBoundItem)).SelectionId;

            List<DataView> dv = dba.GetDataSeries(marketId, selId, Util.DataSeries.PRICE);
            if (dv[0].Count >= MINELEM)
            {
                chart1.ChartAreas["ChartArea1"].BorderDashStyle = ChartDashStyle.Solid;
                chart1.ChartAreas["ChartArea1"].BorderColor = Color.LightGray;
                chart1.ChartAreas["ChartArea1"].BorderWidth = 1;

                chart1.ChartAreas["ChartArea2"].BorderDashStyle = ChartDashStyle.Solid;
                chart1.ChartAreas["ChartArea2"].BorderColor = Color.LightGray;
                chart1.ChartAreas["ChartArea2"].BorderWidth = 1;

                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 1;
                chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 1;

                chart1.ChartAreas["ChartArea2"].AxisX.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas["ChartArea2"].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                chart1.ChartAreas["ChartArea2"].AxisX.MajorGrid.LineWidth = 1;
                chart1.ChartAreas["ChartArea2"].AxisY.MajorGrid.LineColor = Color.LightGray;
                chart1.ChartAreas["ChartArea2"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
                chart1.ChartAreas["ChartArea2"].AxisY.MajorGrid.LineWidth = 1;

                chart1.ChartAreas["ChartArea1"].InnerPlotPosition.Auto = true;
                chart1.ChartAreas["ChartArea2"].InnerPlotPosition.Auto = true;

                // Set the alignment properties so the "Volume" chart area will allign to "Default"
                chart1.ChartAreas["ChartArea2"].AlignmentOrientation = AreaAlignmentOrientations.Vertical;
                chart1.ChartAreas["ChartArea2"].AlignmentStyle = AreaAlignmentStyles.All;
                chart1.ChartAreas["ChartArea2"].AlignWithChartArea = "ChartArea1";



                chart1.Series["Series1"].Points.DataBindY(dv[0], "VolPrice");
                chart1.Series["Series1"].ChartType = SeriesChartType.Spline;
                chart1.Series["Series1"].Enabled = false;

                chart1.Series["Series2"].Points.DataBindY(dv[0], "LastPriceTraded");
                chart1.Series["Series2"].ChartType = SeriesChartType.Spline;
                chart1.Series["Series2"].Enabled = false;

                chart1.Series["Series3"].Points.DataBindY(dv[0], "Matched");
                chart1.Series["Series3"].ChartType = SeriesChartType.Column;
                chart1.Series["Series3"].Enabled = true;

                chart1.Series["Series4"].Points.DataBindY(dv[0], "ToBackTotal");
                chart1.Series["Series4"].ChartType = SeriesChartType.Spline;
                chart1.Series["Series4"].Enabled = true;

                chart1.Series["Series5"].Points.DataBindY(dv[0], "ToLayTotal");
                chart1.Series["Series5"].ChartType = SeriesChartType.Spline;
                chart1.Series["Series5"].Enabled = true;

                double max = Math.Max(((DataPoint)chart1.Series["Series1"].Points.FindMaxByValue()).YValues[0], ((DataPoint)chart1.Series["Series2"].Points.FindMaxByValue()).YValues[0]);
                double min = Math.Min(((DataPoint)chart1.Series["Series1"].Points.FindMinByValue()).YValues[0], ((DataPoint)chart1.Series["Series2"].Points.FindMinByValue()).YValues[0]);
                chart1.ChartAreas["ChartArea1"].AxisY.Maximum = BFUtil.RoundUpToNearestBetfairPrice(max + BFUtil.GetPriceInc(max));
                chart1.ChartAreas["ChartArea1"].AxisY.Minimum = BFUtil.RoundDownToNearestBetfairPrice(min - BFUtil.GetPriceInc(min));
                double nrOfTicks = (max - min) / BFUtil.GetPriceInc(min);
                chart1.ChartAreas["ChartArea1"].AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;
                chart1.ChartAreas["ChartArea1"].AxisY.Interval = Math.Ceiling(nrOfTicks / 6) * BFUtil.GetPriceInc(min);

                //chart1.ChartAreas["ChartArea1"].AxisY.IntervalType = DateTimeIntervalType.Number;
                //chart1.ChartAreas["ChartArea1"].AxisY.MajorTickMark.IntervalOffset = BFUtil.GetPriceInc(min);

                chart1.DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, MINELEM.ToString(), "Series2", "LPT");
                chart1.Series["LPT"].ChartType = SeriesChartType.Spline;

                chart1.DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, "1", "Series1", "VolPrice");
                chart1.Series["VolPrice"].ChartType = SeriesChartType.Spline;
                chart1.Series["VolPrice"].Color = Color.Green;

                chart1.DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, "8", "Series4", "Series4");
                chart1.Series["Series4"].ChartType = SeriesChartType.Spline;
                chart1.Series["Series4"].Color = Color.Green;

                chart1.DataManipulator.FinancialFormula(FinancialFormula.WeightedMovingAverage, "8", "Series5", "Series5");
                chart1.Series["Series5"].ChartType = SeriesChartType.Spline;
                chart1.Series["Series5"].Color = Color.Blue;

                chart1.ChartAreas["ChartArea1"].CursorX.AxisType = AxisType.Primary;
                chart1.ChartAreas["ChartArea1"].CursorY.AxisType = AxisType.Secondary;
                chart1.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = true;
                chart1.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;
                chart1.ChartAreas["ChartArea1"].CursorX.LineColor = Color.DeepPink;
                chart1.ChartAreas["ChartArea1"].CursorX.SelectionColor = Color.PaleGoldenrod;
                chart1.ChartAreas["ChartArea1"].AxisX.ScrollBar.Enabled = false;
                chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = false;

                chart1.ChartAreas["ChartArea2"].CursorX.AxisType = AxisType.Primary;
                chart1.ChartAreas["ChartArea2"].CursorY.AxisType = AxisType.Secondary;
                chart1.ChartAreas["ChartArea2"].CursorX.IsUserEnabled = true;
                chart1.ChartAreas["ChartArea2"].CursorX.IsUserSelectionEnabled = true;
                chart1.ChartAreas["ChartArea2"].CursorX.LineColor = Color.DeepPink;
                chart1.ChartAreas["ChartArea2"].CursorX.SelectionColor = Color.PaleGoldenrod;

                //Util.getLinearRegAngle(null, 4);
                // Util.getLinearRegAngle(chart1.Series["LPT"].Points.Cast<[]double>
            }
            else
            {
                ShowMsg("Msg100", new String[] { MINELEM.ToString() });

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (cb.SelectedIndex == 0)
            {
                service = new JsonAPI();
                Config.ServiceMode = Config.Mode.API;
            }
            else if (cb.SelectedIndex == 1)
            {
                service = new DBAPI();
                Config.ServiceMode = Config.Mode.DB;
            }
            service.login();
            MainFrm_Load(null, null);
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            BFUtil.HorsRaceFilter_MarketStartTime.From = ((DateTime)((DateTimePicker)sender).Value).AddMinutes(-10);
            GetMarketCat();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime selDT = (DateTime)((DateTimePicker)sender).Value;
            BFUtil.HorsRaceFilter_MarketStartTime.To = new DateTime(selDT.Year, selDT.Month, selDT.Day, 23, 59, 59);
            GetMarketCat();
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(500);
                //this.ShowInTaskbar = false;
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }

        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        public void ShowMsg(string msgNr, String[] msgParams)
        {
            string msg = Shared.Properties.Message.ResourceManager.GetString(msgNr);
            int cnt = 1;
            foreach (String param in msgParams)
            {
                msg = msg.Replace("{" + cnt + "}", param);
                cnt++;
            }
            StatusLabel1.Text = msg;
            statusStrip1.Invalidate();
            statusStrip1.Refresh();
        }

        public void ShowMsg(string msgNr)
        {
            string msg = Shared.Properties.Message.ResourceManager.GetString(msgNr);

            StatusLabel1.Text = msg;
            statusStrip1.Invalidate();
            statusStrip1.Refresh();

        }

    }
}
