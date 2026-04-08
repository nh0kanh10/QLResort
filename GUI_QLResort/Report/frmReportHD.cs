using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using BUS_QLResort;
using ET_QLResort;

namespace GUI_QLResort
{
    public partial class frmReportHD : Form
    {
        private ResortBUS cn = new ResortBUS();

        public frmReportHD()
        {
            InitializeComponent();
        }

        private void frmReportHD_Load(object sender, EventArgs e)
        {
            LoadChiNhanh();
            LoadReport();
        }

        private void LoadChiNhanh()
        {
            var check = cn.GetResorts();
            if (!check.Success)
            {
                MessageBox.Show("Lỗi khi tải chi nhánh: " + check.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var branches = check.Data;
            cbbChiNhanh.Items.Clear();
            cbbChiNhanh.Items.Add("-- Tất cả chi nhánh --");
            foreach (var branch in branches)
            {
                cbbChiNhanh.Items.Add(branch);
            }
            cbbChiNhanh.SelectedIndex = 0;
            cbbChiNhanh.DisplayMember = "TenCN";
            cbbChiNhanh.ValueMember = "MaCN";
        }

        private void LoadReport()
        {
            try
            {
                string reportPath = @"C:\Users\ADMIN\Desktop\QLResort-master\GUI_QLResort\BaoCao.rpt";
                ReportDocument rpt = new ReportDocument();
                rpt.Load(reportPath);

                string server = System.Configuration.ConfigurationManager.ConnectionStrings["QLResortConnection"]?.ConnectionString ?? "";
                rpt.SetDatabaseLogon("", "", "localhost", "QLResort");

                string selectedMaCN = GetSelectedMaCN();
                if (!string.IsNullOrEmpty(selectedMaCN))
                {
                    ParameterValues para = new ParameterValues();
                    ParameterDiscreteValue pValue = new ParameterDiscreteValue();
                    pValue.Value = selectedMaCN;
                    para.Add(pValue);
                    rpt.DataDefinition.ParameterFields["@MaCN"].ApplyCurrentValues(para);
                }

                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSelectedMaCN()
        {
            if (cbbChiNhanh.SelectedIndex <= 0)
                return null;
            
            var selected = cbbChiNhanh.SelectedItem;
            if (selected is ET_QLResort.Resort branch)
                return branch.MaCN;
            
            return null;
        }

        private void cbbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
