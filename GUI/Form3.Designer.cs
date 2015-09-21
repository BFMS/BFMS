namespace GUI
{
    partial class Form3
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.MarketDGV = new System.Windows.Forms.DataGridView();
            this.RunnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPriceTraded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgOdds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelativeExposure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Indikator1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Indikator2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MarketDGV)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(761, 379);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MarketDGV);
            this.tabPage1.Controls.Add(this.statusStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(753, 353);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MarketDGV
            // 
            this.MarketDGV.AllowUserToAddRows = false;
            this.MarketDGV.AllowUserToDeleteRows = false;
            this.MarketDGV.AllowUserToResizeColumns = false;
            this.MarketDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.MarketDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MarketDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MarketDGV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MarketDGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.MarketDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.MarketDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.MarketDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RunnerName,
            this.Status,
            this.LastPriceTraded,
            this.AvgOdds,
            this.RelativeExposure,
            this.Indikator1,
            this.Indikator2});
            this.MarketDGV.DataMember = "Runners";
            this.MarketDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarketDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.MarketDGV.Location = new System.Drawing.Point(2, 28);
            this.MarketDGV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MarketDGV.MultiSelect = false;
            this.MarketDGV.Name = "MarketDGV";
            this.MarketDGV.ReadOnly = true;
            this.MarketDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.MarketDGV.RowHeadersVisible = false;
            this.MarketDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.MarketDGV.RowTemplate.Height = 24;
            this.MarketDGV.RowTemplate.ReadOnly = true;
            this.MarketDGV.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MarketDGV.ShowCellErrors = false;
            this.MarketDGV.ShowCellToolTips = false;
            this.MarketDGV.ShowEditingIcon = false;
            this.MarketDGV.ShowRowErrors = false;
            this.MarketDGV.Size = new System.Drawing.Size(749, 323);
            this.MarketDGV.TabIndex = 3;
            // 
            // RunnerName
            // 
            this.RunnerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.RunnerName.DataPropertyName = "RunnerName";
            this.RunnerName.HeaderText = "RunnerName";
            this.RunnerName.MinimumWidth = 200;
            this.RunnerName.Name = "RunnerName";
            this.RunnerName.ReadOnly = true;
            this.RunnerName.Width = 203;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 50;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // LastPriceTraded
            // 
            this.LastPriceTraded.DataPropertyName = "LastPriceTraded";
            this.LastPriceTraded.HeaderText = "LastPriceTraded";
            this.LastPriceTraded.MinimumWidth = 50;
            this.LastPriceTraded.Name = "LastPriceTraded";
            this.LastPriceTraded.ReadOnly = true;
            // 
            // AvgOdds
            // 
            this.AvgOdds.DataPropertyName = "AvgOdds";
            this.AvgOdds.HeaderText = "AvgOdds";
            this.AvgOdds.MinimumWidth = 50;
            this.AvgOdds.Name = "AvgOdds";
            this.AvgOdds.ReadOnly = true;
            // 
            // RelativeExposure
            // 
            this.RelativeExposure.DataPropertyName = "RelativeExposure";
            this.RelativeExposure.HeaderText = "RelativeExposure";
            this.RelativeExposure.MinimumWidth = 100;
            this.RelativeExposure.Name = "RelativeExposure";
            this.RelativeExposure.ReadOnly = true;
            // 
            // Indikator1
            // 
            this.Indikator1.DataPropertyName = "Indikator1";
            this.Indikator1.HeaderText = "Indikator1";
            this.Indikator1.MinimumWidth = 100;
            this.Indikator1.Name = "Indikator1";
            this.Indikator1.ReadOnly = true;
            // 
            // Indikator2
            // 
            this.Indikator2.DataPropertyName = "Indikator2";
            this.Indikator2.HeaderText = "Indikator2";
            this.Indikator2.MinimumWidth = 100;
            this.Indikator2.Name = "Indikator2";
            this.Indikator2.ReadOnly = true;
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip2.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripDropDownButton1});
            this.statusStrip2.Location = new System.Drawing.Point(2, 2);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip2.Size = new System.Drawing.Size(749, 26);
            this.statusStrip2.TabIndex = 2;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Top;
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Tahoma", 9.163636F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(162, 21);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(139, 21);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(32, 24);
            this.toolStripDropDownButton1.Text = "Button";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 406);
            this.Controls.Add(this.tabControl1);
            this.Location = new System.Drawing.Point(0, 50);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MarketDGV)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView MarketDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn RunnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPriceTraded;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgOdds;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelativeExposure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Indikator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Indikator2;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
    }
}