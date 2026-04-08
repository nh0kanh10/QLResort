using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace GUI_QLResort.Report
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        private void frmReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                string reportPath = @"C:\Users\ADMIN\Desktop\QLResort-master\GUI_QLResort\BaoCaoTongQuat.rpt";
                ReportDocument rpt = new ReportDocument();
                rpt.Load(reportPath);

                string server = System.Configuration.ConfigurationManager.ConnectionStrings["QLResortConnection"]?.ConnectionString ?? "";
                rpt.SetDatabaseLogon("", "", "localhost", "QLResort");
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
