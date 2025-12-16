using System;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace QLResort.GUI
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        public void LoadReport(ReportDocument rpt)
        {
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
