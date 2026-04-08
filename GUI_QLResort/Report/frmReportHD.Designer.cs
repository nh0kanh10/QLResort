namespace GUI_QLResort
{
    partial class frmReportHD
    {
        private System.ComponentModel.IContainer components = null;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ComboBox cbbChiNhanh;
        private System.Windows.Forms.Label lblChiNhanh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cbbChiNhanh = new System.Windows.Forms.ComboBox();
            this.lblChiNhanh = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblChiNhanh
            // 
            this.lblChiNhanh.AutoSize = true;
            this.lblChiNhanh.Location = new System.Drawing.Point(12, 15);
            this.lblChiNhanh.Name = "lblChiNhanh";
            this.lblChiNhanh.Size = new System.Drawing.Size(56, 13);
            this.lblChiNhanh.TabIndex = 0;
            this.lblChiNhanh.Text = "Chi nhánh:";
            // 
            // cbbChiNhanh
            // 
            this.cbbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChiNhanh.FormattingEnabled = true;
            this.cbbChiNhanh.Location = new System.Drawing.Point(74, 12);
            this.cbbChiNhanh.Name = "cbbChiNhanh";
            this.cbbChiNhanh.Size = new System.Drawing.Size(250, 21);
            this.cbbChiNhanh.TabIndex = 1;
            this.cbbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cbbChiNhanh_SelectedIndexChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 45);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(997, 573);
            this.crystalReportViewer1.TabIndex = 2;
            // 
            // frmReportHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 618);
            this.Controls.Add(this.lblChiNhanh);
            this.Controls.Add(this.cbbChiNhanh);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmReportHD";
            this.Text = "Báo Cáo Hóa Đơn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportHD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
