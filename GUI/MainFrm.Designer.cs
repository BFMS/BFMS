namespace GUI
{
    partial class MainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.EventDGV = new System.Windows.Forms.DataGridView();
            this.MarketDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isMarketDataDelayedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.competitionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localStartTimeHMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localStartTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventBS = new System.Windows.Forms.BindingSource(this.components);
            this.editorPane1 = new GUI.EditorPane();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.MarketScanCb = new System.Windows.Forms.CheckBox();
            this.DBLoggingCB = new System.Windows.Forms.CheckBox();
            this.EMailCB = new System.Windows.Forms.CheckBox();
            this.SMSCB = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.StatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBS)).BeginInit();
            this.editorPane1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.EventDGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.editorPane1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1576, 815);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // EventDGV
            // 
            this.EventDGV.AllowUserToAddRows = false;
            this.EventDGV.AllowUserToDeleteRows = false;
            this.EventDGV.AllowUserToResizeRows = false;
            this.EventDGV.AutoGenerateColumns = false;
            this.EventDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EventDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EventDGV.ColumnHeadersVisible = false;
            this.EventDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MarketDescr,
            this.StartTime,
            this.marketIdDataGridViewTextBoxColumn,
            this.marketNameDataGridViewTextBoxColumn,
            this.isMarketDataDelayedDataGridViewCheckBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.eventTypeDataGridViewTextBoxColumn,
            this.eventDataGridViewTextBoxColumn,
            this.competitionDataGridViewTextBoxColumn,
            this.localStartTimeHMDataGridViewTextBoxColumn,
            this.localStartTimeDataGridViewTextBoxColumn,
            this.startTimeDataGridViewTextBoxColumn});
            this.EventDGV.DataSource = this.eventBS;
            this.EventDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventDGV.Location = new System.Drawing.Point(7, 39);
            this.EventDGV.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.EventDGV.MultiSelect = false;
            this.EventDGV.Name = "EventDGV";
            this.EventDGV.ReadOnly = true;
            this.EventDGV.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.EventDGV, 2);
            this.EventDGV.RowTemplate.Height = 24;
            this.EventDGV.RowTemplate.ReadOnly = true;
            this.EventDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EventDGV.Size = new System.Drawing.Size(305, 675);
            this.EventDGV.TabIndex = 6;
            this.EventDGV.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EventDGV_MouseDoubleClick);
            // 
            // MarketDescr
            // 
            this.MarketDescr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MarketDescr.DataPropertyName = "MarketDescr";
            this.MarketDescr.FillWeight = 152.2843F;
            this.MarketDescr.HeaderText = "MarketDescr";
            this.MarketDescr.MinimumWidth = 150;
            this.MarketDescr.Name = "MarketDescr";
            this.MarketDescr.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StartTime.DataPropertyName = "LocalStartTimeHM";
            this.StartTime.FillWeight = 47.71574F;
            this.StartTime.HeaderText = "StartTime";
            this.StartTime.MinimumWidth = 80;
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // marketIdDataGridViewTextBoxColumn
            // 
            this.marketIdDataGridViewTextBoxColumn.DataPropertyName = "MarketId";
            this.marketIdDataGridViewTextBoxColumn.HeaderText = "MarketId";
            this.marketIdDataGridViewTextBoxColumn.Name = "marketIdDataGridViewTextBoxColumn";
            this.marketIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.marketIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // marketNameDataGridViewTextBoxColumn
            // 
            this.marketNameDataGridViewTextBoxColumn.DataPropertyName = "MarketName";
            this.marketNameDataGridViewTextBoxColumn.HeaderText = "MarketName";
            this.marketNameDataGridViewTextBoxColumn.Name = "marketNameDataGridViewTextBoxColumn";
            this.marketNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.marketNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // isMarketDataDelayedDataGridViewCheckBoxColumn
            // 
            this.isMarketDataDelayedDataGridViewCheckBoxColumn.DataPropertyName = "IsMarketDataDelayed";
            this.isMarketDataDelayedDataGridViewCheckBoxColumn.HeaderText = "IsMarketDataDelayed";
            this.isMarketDataDelayedDataGridViewCheckBoxColumn.Name = "isMarketDataDelayedDataGridViewCheckBoxColumn";
            this.isMarketDataDelayedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isMarketDataDelayedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventTypeDataGridViewTextBoxColumn
            // 
            this.eventTypeDataGridViewTextBoxColumn.DataPropertyName = "EventType";
            this.eventTypeDataGridViewTextBoxColumn.HeaderText = "EventType";
            this.eventTypeDataGridViewTextBoxColumn.Name = "eventTypeDataGridViewTextBoxColumn";
            this.eventTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventDataGridViewTextBoxColumn
            // 
            this.eventDataGridViewTextBoxColumn.DataPropertyName = "Event";
            this.eventDataGridViewTextBoxColumn.HeaderText = "Event";
            this.eventDataGridViewTextBoxColumn.Name = "eventDataGridViewTextBoxColumn";
            this.eventDataGridViewTextBoxColumn.ReadOnly = true;
            this.eventDataGridViewTextBoxColumn.Visible = false;
            // 
            // competitionDataGridViewTextBoxColumn
            // 
            this.competitionDataGridViewTextBoxColumn.DataPropertyName = "Competition";
            this.competitionDataGridViewTextBoxColumn.HeaderText = "Competition";
            this.competitionDataGridViewTextBoxColumn.Name = "competitionDataGridViewTextBoxColumn";
            this.competitionDataGridViewTextBoxColumn.ReadOnly = true;
            this.competitionDataGridViewTextBoxColumn.Visible = false;
            // 
            // localStartTimeHMDataGridViewTextBoxColumn
            // 
            this.localStartTimeHMDataGridViewTextBoxColumn.DataPropertyName = "LocalStartTimeHM";
            this.localStartTimeHMDataGridViewTextBoxColumn.HeaderText = "LocalStartTimeHM";
            this.localStartTimeHMDataGridViewTextBoxColumn.Name = "localStartTimeHMDataGridViewTextBoxColumn";
            this.localStartTimeHMDataGridViewTextBoxColumn.ReadOnly = true;
            this.localStartTimeHMDataGridViewTextBoxColumn.Visible = false;
            // 
            // localStartTimeDataGridViewTextBoxColumn
            // 
            this.localStartTimeDataGridViewTextBoxColumn.DataPropertyName = "LocalStartTime";
            this.localStartTimeDataGridViewTextBoxColumn.HeaderText = "LocalStartTime";
            this.localStartTimeDataGridViewTextBoxColumn.Name = "localStartTimeDataGridViewTextBoxColumn";
            this.localStartTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.localStartTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // startTimeDataGridViewTextBoxColumn
            // 
            this.startTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.HeaderText = "StartTime";
            this.startTimeDataGridViewTextBoxColumn.Name = "startTimeDataGridViewTextBoxColumn";
            this.startTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.startTimeDataGridViewTextBoxColumn.Visible = false;
            // 
            // eventBS
            // 
            this.eventBS.DataSource = typeof(Shared.BFDO.MarketCatalogue);
            // 
            // editorPane1
            // 
            this.editorPane1.AllowDrop = true;
            this.editorPane1.Controls.Add(this.tabPage1);
            this.editorPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorPane1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.editorPane1.Location = new System.Drawing.Point(323, 6);
            this.editorPane1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.editorPane1.Name = "editorPane1";
            this.editorPane1.Padding = new System.Drawing.Point(16, 0);
            this.tableLayoutPanel1.SetRowSpan(this.editorPane1, 2);
            this.editorPane1.SelectedIndex = 0;
            this.editorPane1.Size = new System.Drawing.Size(1246, 426);
            this.editorPane1.TabIndex = 10;
            this.editorPane1.OnTabClose += new GUI.EditorPane.OnTabClosedDelegate(this.editorPane1_OnTabClose);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(1238, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Market";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.MarketScanCb);
            this.panel1.Controls.Add(this.DBLoggingCB);
            this.panel1.Controls.Add(this.EMailCB);
            this.panel1.Controls.Add(this.SMSCB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(323, 722);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1246, 49);
            this.panel1.TabIndex = 12;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1168, 11);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 20);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "SMS";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MarketScanCb
            // 
            this.MarketScanCb.AutoSize = true;
            this.MarketScanCb.Location = new System.Drawing.Point(23, 11);
            this.MarketScanCb.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MarketScanCb.Name = "MarketScanCb";
            this.MarketScanCb.Size = new System.Drawing.Size(125, 20);
            this.MarketScanCb.TabIndex = 15;
            this.MarketScanCb.Text = "Start  Scanner";
            this.MarketScanCb.UseVisualStyleBackColor = true;
            this.MarketScanCb.CheckedChanged += new System.EventHandler(this.MarketScanCb_CheckedChanged);
            // 
            // DBLoggingCB
            // 
            this.DBLoggingCB.AutoSize = true;
            this.DBLoggingCB.Location = new System.Drawing.Point(739, 11);
            this.DBLoggingCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DBLoggingCB.Name = "DBLoggingCB";
            this.DBLoggingCB.Size = new System.Drawing.Size(44, 20);
            this.DBLoggingCB.TabIndex = 12;
            this.DBLoggingCB.Text = "DB";
            this.DBLoggingCB.UseVisualStyleBackColor = true;
            this.DBLoggingCB.CheckedChanged += new System.EventHandler(this.DBLoggingCB_CheckedChanged);
            // 
            // EMailCB
            // 
            this.EMailCB.AutoSize = true;
            this.EMailCB.Location = new System.Drawing.Point(1050, 10);
            this.EMailCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EMailCB.Name = "EMailCB";
            this.EMailCB.Size = new System.Drawing.Size(60, 20);
            this.EMailCB.TabIndex = 13;
            this.EMailCB.Text = "EMail";
            this.EMailCB.UseVisualStyleBackColor = true;
            // 
            // SMSCB
            // 
            this.SMSCB.AutoSize = true;
            this.SMSCB.Location = new System.Drawing.Point(1340, 14);
            this.SMSCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.SMSCB.Name = "SMSCB";
            this.SMSCB.Size = new System.Drawing.Size(56, 20);
            this.SMSCB.TabIndex = 14;
            this.SMSCB.Text = "SMS";
            this.SMSCB.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            chartArea2.Name = "ChartArea2";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(320, 439);
            this.chart1.Margin = new System.Windows.Forms.Padding(1);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series3.ChartArea = "ChartArea2";
            series3.Legend = "Legend1";
            series3.Name = "Series3";
            series4.ChartArea = "ChartArea2";
            series4.Legend = "Legend1";
            series4.Name = "Series4";
            series5.ChartArea = "ChartArea2";
            series5.Legend = "Legend1";
            series5.Name = "Series5";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(1252, 276);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(7, 722);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 49);
            this.panel2.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mode";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "BFAPI",
            "DB"});
            this.comboBox1.Location = new System.Drawing.Point(110, 14);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 22);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.Text = "DB";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 777);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1570, 35);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dateTimePicker2);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(307, 25);
            this.panel3.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Zeitraum";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(193, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowUpDown = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(97, 22);
            this.dateTimePicker2.TabIndex = 1;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(89, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(98, 22);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "BFMS";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "BFMS";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // StatusLabel1
            // 
            this.StatusLabel1.Name = "StatusLabel1";
            this.StatusLabel1.Size = new System.Drawing.Size(0, 30);
            this.StatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1576, 815);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Verdana", 7.854546F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainFrm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFrm_FormClosed);
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.Resize += new System.EventHandler(this.MainFrm_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventBS)).EndInit();
            this.editorPane1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView EventDGV;
        private EditorPane editorPane1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox DBLoggingCB;
        private System.Windows.Forms.CheckBox EMailCB;
        private System.Windows.Forms.CheckBox SMSCB;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox MarketScanCb;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.BindingSource eventBS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isMarketDataDelayedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn competitionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localStartTimeHMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localStartTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel1;
    }
}