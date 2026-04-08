namespace GUI_QLResort.Report
{
    partial class frmReportViewer
    {
        private System.ComponentModel.IContainer components = null;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;

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
            this.BaoCaoTongQuat1 = new GUI_QLResort.BaoCaoTongQuat();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = "C:\\Users\\ADMIN\\Desktop\\QLResort-master\\GUI_QLResort\\BaoCaoTongQuat.rpt";
            this.crystalReportViewer1.Size = new System.Drawing.Size(997, 618);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 618);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmReportViewer";
            this.Text = "Xem Báo Cáo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportViewer_Load);
            this.ResumeLayout(false);

        }

        private BaoCaoTongQuat BaoCaoTongQuat1;
    }
}
