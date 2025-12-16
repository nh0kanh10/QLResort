/*
 * =================================================================
 * frmStatistics.cs - Form Thống kê tổng hợp
 * =================================================================
 * Chức năng:
 *   - Hiển thị thống kê tổng quan của resort
 *   - Lọc theo chi nhánh, năm, tháng
 *   - Dữ liệu từ StatisticsBUS (3-layer architecture)
 * 
 * Các nhóm thống kê:
 *   1. PHÒNG: Tổng, Trống, Đang dùng, Bảo trì, Ngưng
 *   2. TÀI CHÍNH: Doanh thu, Chi phí, Lợi nhuận, Đặt cọc, Hoàn tiền
 *   3. ĐẶT PHÒNG: Tổng đơn, Hoàn tất, Hủy, Tỷ lệ thành công
 *   4. SỰ KIỆN: Tổng sự kiện, Doanh thu sự kiện
 *   5. KHÁCH & NV: Tổng KH, KH mới, Tổng NV
 *   6. DỊCH VỤ: Tổng DV, Doanh thu DV
 * =================================================================
 */

using QLResort.BUS;
using QLResort.GUI.Styles;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace QLResort.GUI
{
    public partial class frmStatistics : AppBaseForm
    {
        // Fields
        private readonly StatisticsBUS statisticsBUS = new StatisticsBUS();
        
        // Constructor
        public frmStatistics()
        {
            InitializeComponent();
        }
        
        // Form Events
        /// <summary>
        /// Load form: áp dụng theme, tải bộ lọc và dữ liệu
        /// </summary>
        private void frmStatistics_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadFilters();
            LoadStatistics();
        }
        
        // UI Setup
        /// <summary>
        /// Áp dụng theme cho form và các controls
        /// </summary>
        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleComboBox(cbFilterResort);
            AppTheme.StyleComboBox(cbFilterMonth);
            AppTheme.StyleComboBox(cbFilterYear);
        }

        /// <summary>
        /// Tải dữ liệu cho các bộ lọc: Chi nhánh, Năm, Tháng
        /// </summary>
        private void LoadFilters()
        {
            // Load danh sách chi nhánh
            var resorts = new QLResort.DAL.Resort_F.ResortDAL().GetResort(isActive: true);
            if (resorts.Success)
            {
                cbFilterResort.Items.Add("Tất cả");
                foreach (DataRow row in resorts.Data.Rows)
                {
                    cbFilterResort.Items.Add(new { MaCN = row["MaCN"].ToString(), TenCN = row["TenCN"].ToString() });
                }
                cbFilterResort.DisplayMember = "TenCN";
                cbFilterResort.ValueMember = "MaCN";
                cbFilterResort.SelectedIndex = 0;
            }

            // Load năm (5 năm gần nhất)
            cbFilterYear.Items.Add("Tất cả");
            for (int year = DateTime.Now.Year; year >= DateTime.Now.Year - 5; year--)
            {
                cbFilterYear.Items.Add(year);
            }
            cbFilterYear.SelectedIndex = 0;

            // Load tháng 1-12
            cbFilterMonth.Items.Add("Tất cả");
            for (int month = 1; month <= 12; month++)
            {
                cbFilterMonth.Items.Add($"Tháng {month}");
            }
            cbFilterMonth.SelectedIndex = 0;
        }
        
        // Data Loading
        /// <summary>
        /// Tải và hiển thị dữ liệu thống kê từ StatisticsBUS
        /// </summary>
        private void LoadStatistics()
        {
            // Lấy giá trị filter
            string maCN = GetSelectedMaCN();
            int? year = GetSelectedYear();
            int? month = GetSelectedMonth();

            try
            {
                // Lấy tất cả thống kê từ BUS layer
                var data = statisticsBUS.GetAllStatistics(maCN, year, month);

                // ========== PHÒNG ==========
                lblTongPhongValue.Text = $"Tổng: {data.TongPhong:N0}";
                lblPhongTrongValue.Text = $"Trống: {data.PhongTrong:N0}";
                lblPhongDangSuDungValue.Text = $"Đang dùng: {data.PhongDangSuDung:N0}";
                lblPhongBaoTriValue.Text = $"Bảo trì: {data.PhongBaoTri:N0}";
                lblPhongNgungValue.Text = $"Ngưng: {data.PhongNgung:N0}";

                // ========== TÀI CHÍNH ==========
                lblDoanhThuValue.Text = $"Doanh thu: {data.DoanhThu:N0} VNĐ";
                lblChiPhiValue.Text = $"Chi phí: {data.ChiPhi:N0} VNĐ";
                lBUSoiNhuanValue.Text = $"Lợi nhuận: {data.LoiNhuan:N0} VNĐ";
                // Màu xanh nếu lãi, đỏ nếu lỗ
                lBUSoiNhuanValue.ForeColor = data.LoiNhuan >= 0 
                    ? Color.FromArgb(46, 204, 113)   // Xanh lá
                    : Color.FromArgb(231, 76, 60);    // Đỏ
                lblDatCocValue.Text = $"Đặt cọc: {data.DatCoc:N0} VNĐ";
                lblHoanTienValue.Text = $"Hoàn: {data.HoanTien:N0} VNĐ";

                // ========== ĐẶT PHÒNG ==========
                lblTongDatPhongValue.Text = $"Tổng: {data.TongDatPhong:N0} đơn";
                lblDatPhongThanhCongValue.Text = $"Hoàn tất: {data.DatPhongHoanTat:N0}";
                lblDatPhongHuyValue.Text = $"Hủy: {data.DatPhongHuy:N0}";
                lblTiLeThanhCong.Text = $"Tỷ lệ: {data.TiLeThanhCong:F1}%";
                // Màu theo tỷ lệ: Xanh >= 80%, Vàng >= 50%, Đỏ < 50%
                lblTiLeThanhCong.ForeColor = data.TiLeThanhCong >= 80 ? Color.FromArgb(46, 204, 113) :
                                             data.TiLeThanhCong >= 50 ? Color.FromArgb(241, 196, 15) :
                                             Color.FromArgb(231, 76, 60);

                // ========== SỰ KIỆN ==========
                lblTongSuKienValue.Text = $"Tổng: {data.TongSuKien:N0} sự kiện";
                lblDoanhThuSuKienValue.Text = $"Doanh thu: {data.DoanhThuSuKien:N0} VNĐ";

                // ========== KHÁCH HÀNG & NHÂN VIÊN ==========
                lblTongKhachHangValue.Text = $"Tổng KH: {data.TongKhachHang:N0}";
                lblKhachHangMoiValue.Text = $"KH mới: {data.KhachHangMoi:N0}";
                lblTongNhanVienValue.Text = $"Nhân viên: {data.TongNhanVien:N0}";

                // ========== DỊCH VỤ ==========
                lblTongDichVuValue.Text = $"Tổng: {data.TongDichVu:N0} dịch vụ";
                lblDoanhThuDichVuValue.Text = $"Doanh thu: {data.DoanhThuDichVu:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // Event Handlers
        /// <summary>
        /// Xử lý khi thay đổi bộ lọc - tải lại dữ liệu
        /// </summary>
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistics();
        }
        
        // Helper Methods
        /// <summary>Lấy mã chi nhánh đã chọn</summary>
        private string GetSelectedMaCN()
        {
            if (cbFilterResort.SelectedIndex > 0 && cbFilterResort.SelectedItem != null)
            {
                try
                {
                    dynamic selected = cbFilterResort.SelectedItem;
                    return selected.MaCN;
                }
                catch { }
            }
            return null;
        }

        /// <summary>Lấy năm đã chọn</summary>
        private int? GetSelectedYear()
        {
            if (cbFilterYear.SelectedIndex > 0 && cbFilterYear.SelectedItem != null)
            {
                try { return Convert.ToInt32(cbFilterYear.SelectedItem); }
                catch { }
            }
            return null;
        }

        /// <summary>Lấy tháng đã chọn (1-12)</summary>
        private int? GetSelectedMonth()
        {
            if (cbFilterMonth.SelectedIndex > 0)
                return cbFilterMonth.SelectedIndex;
            return null;
        }

        /// <summary>
        /// Xử lý sự kiện click nút In báo cáo
        /// </summary>
        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // check file rpt existence
                string reportPath = System.IO.Path.Combine(Application.StartupPath, "Reports", "StatisticsReport.rpt");
                if (!System.IO.File.Exists(reportPath))
                {
                    MessageBox.Show("Không tìm thấy file mẫu báo cáo (StatisticsReport.rpt)!\nVui lòng tạo file này trong thư mục Reports.", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1. Get Data
                string maCN = GetSelectedMaCN();
                int? year = GetSelectedYear();
                int? month = GetSelectedMonth();
                var statsData = statisticsBUS.GetAllStatistics(maCN, year, month);

                // 2. Map to DataSet
                // Do DataSet StatisticsDS đã được định nghĩa trong Reports/StatisticsDS.xsd
                // Ta cần load schema đó vào DataSet
                DataSet ds = new DataSet();
                string xsdPath = System.IO.Path.Combine(Application.StartupPath, "Reports", "StatisticsDS.xsd");
                 if (System.IO.File.Exists(xsdPath))
                {
                     ds.ReadXmlSchema(xsdPath);
                }
                else
                {
                     MessageBox.Show("Không tìm thấy file định nghĩa dữ liệu (StatisticsDS.xsd)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                }
                
                // Add row to DataTable "Statistics"
                DataTable dt = ds.Tables["Statistics"];
                DataRow row = dt.NewRow();
                
                // Filter Info
                string cnName = cbFilterResort.Text;
                string timeInfo = year.HasValue ? $"Năm {year}" : "Tất cả các năm";
                if (month.HasValue) timeInfo = $"Tháng {month.Value}/{year}";
                
                row["MaCN"] = maCN ?? "Toàn hệ thống";
                row["ThoiGian"] = timeInfo;

                row["TongPhong"] = statsData.TongPhong;
                row["PhongTrong"] = statsData.PhongTrong;
                row["PhongDangSuDung"] = statsData.PhongDangSuDung;
                row["PhongBaoTri"] = statsData.PhongBaoTri;
                row["PhongNgung"] = statsData.PhongNgung;

                row["DoanhThu"] = statsData.DoanhThu;
                row["ChiPhi"] = statsData.ChiPhi;
                row["LoiNhuan"] = statsData.LoiNhuan;
                row["DatCoc"] = statsData.DatCoc;
                row["HoanTien"] = statsData.HoanTien;

                row["TongDatPhong"] = statsData.TongDatPhong;
                row["DatPhongHoanTat"] = statsData.DatPhongHoanTat;
                row["DatPhongHuy"] = statsData.DatPhongHuy;
                row["TiLeThanhCong"] = statsData.TiLeThanhCong;

                row["TongSuKien"] = statsData.TongSuKien;
                row["DoanhThuSuKien"] = statsData.DoanhThuSuKien;

                row["TongKhachHang"] = statsData.TongKhachHang;
                row["KhachHangMoi"] = statsData.KhachHangMoi;
                row["TongNhanVien"] = statsData.TongNhanVien;

                row["TongDichVu"] = statsData.TongDichVu;
                row["DoanhThuDichVu"] = statsData.DoanhThuDichVu;

                dt.Rows.Add(row);

                // 3. Load Report
                CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                rpt.Load(reportPath);
                rpt.SetDataSource(ds);

                // 4. Show Viewer
                frmReportViewer frm = new frmReportViewer();
                frm.LoadReport(rpt);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
