namespace GUI
{
    partial class Form1
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
            this.MarketDGV = new System.Windows.Forms.DataGridView();
            this.RunnerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPriceTraded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgOdds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelativeExposure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Indikator1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Indikator2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MarketDGV)).BeginInit();
            this.SuspendLayout();
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
            this.MarketDGV.Location = new System.Drawing.Point(0, 0);
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
            this.MarketDGV.Size = new System.Drawing.Size(670, 327);
            this.MarketDGV.TabIndex = 2;
            this.MarketDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MarketDGV_CellDoubleClick);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 327);
            this.Controls.Add(this.MarketDGV);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MarketDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MarketDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn RunnerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPriceTraded;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgOdds;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelativeExposure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Indikator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Indikator2;
    }
}