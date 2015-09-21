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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.EventDGV = new System.Windows.Forms.DataGridView();
            this.MarketDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventDGV)).BeginInit();
            this.editorPane1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1182, 757);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // EventDGV
            // 
            this.EventDGV.AllowUserToAddRows = false;
            this.EventDGV.AllowUserToDeleteRows = false;
            this.EventDGV.AllowUserToResizeRows = false;
            this.EventDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EventDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EventDGV.ColumnHeadersVisible = false;
            this.EventDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MarketDescr,
            this.StartTime});
            this.EventDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventDGV.Location = new System.Drawing.Point(6, 44);
            this.EventDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EventDGV.MultiSelect = false;
            this.EventDGV.Name = "EventDGV";
            this.EventDGV.ReadOnly = true;
            this.EventDGV.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.EventDGV, 2);
            this.EventDGV.RowTemplate.Height = 24;
            this.EventDGV.RowTemplate.ReadOnly = true;
            this.EventDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EventDGV.Size = new System.Drawing.Size(228, 626);
            this.EventDGV.TabIndex = 6;
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
            // editorPane1
            // 
            this.editorPane1.AllowDrop = true;
            this.editorPane1.Controls.Add(this.tabPage1);
            this.editorPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorPane1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.editorPane1.Location = new System.Drawing.Point(243, 6);
            this.editorPane1.Name = "editorPane1";
            this.editorPane1.Padding = new System.Drawing.Point(16, 0);
            this.tableLayoutPanel1.SetRowSpan(this.editorPane1, 2);
            this.editorPane1.SelectedIndex = 0;
            this.editorPane1.Size = new System.Drawing.Size(933, 402);
            this.editorPane1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 20);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(925, 378);
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
            this.panel1.Location = new System.Drawing.Point(243, 678);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 30);
            this.panel1.TabIndex = 12;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(850, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 17);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "SMS";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MarketScanCb
            // 
            this.MarketScanCb.AutoSize = true;
            this.MarketScanCb.Location = new System.Drawing.Point(19, 10);
            this.MarketScanCb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MarketScanCb.Name = "MarketScanCb";
            this.MarketScanCb.Size = new System.Drawing.Size(94, 17);
            this.MarketScanCb.TabIndex = 15;
            this.MarketScanCb.Text = "Start  Scanner";
            this.MarketScanCb.UseVisualStyleBackColor = true;
            // 
            // DBLoggingCB
            // 
            this.DBLoggingCB.AutoSize = true;
            this.DBLoggingCB.Location = new System.Drawing.Point(575, 13);
            this.DBLoggingCB.Name = "DBLoggingCB";
            this.DBLoggingCB.Size = new System.Drawing.Size(41, 17);
            this.DBLoggingCB.TabIndex = 12;
            this.DBLoggingCB.Text = "DB";
            this.DBLoggingCB.UseVisualStyleBackColor = true;
            // 
            // EMailCB
            // 
            this.EMailCB.AutoSize = true;
            this.EMailCB.Location = new System.Drawing.Point(758, 16);
            this.EMailCB.Name = "EMailCB";
            this.EMailCB.Size = new System.Drawing.Size(52, 17);
            this.EMailCB.TabIndex = 13;
            this.EMailCB.Text = "EMail";
            this.EMailCB.UseVisualStyleBackColor = true;
            // 
            // SMSCB
            // 
            this.SMSCB.AutoSize = true;
            this.SMSCB.Location = new System.Drawing.Point(1005, 13);
            this.SMSCB.Name = "SMSCB";
            this.SMSCB.Size = new System.Drawing.Size(49, 17);
            this.SMSCB.TabIndex = 14;
            this.SMSCB.Text = "SMS";
            this.SMSCB.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(243, 417);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(933, 252);
            this.chart1.TabIndex = 13;
            this.chart1.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(6, 678);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 30);
            this.panel2.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mode";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "BFAPI",
            "DB"});
            this.comboBox1.Location = new System.Drawing.Point(83, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.Text = "DB";
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip1.Location = new System.Drawing.Point(3, 714);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1176, 40);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 757);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EventDGV)).EndInit();
            this.editorPane1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView EventDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MarketDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
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
    }
}