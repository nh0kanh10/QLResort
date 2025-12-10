using QLResort.BUS;
using QLResort.GUI.Styles;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace QLResort.GUI
{
    public partial class frmStatistics : Form
    {
        private readonly StatisticsBUS statisticsBUS = new StatisticsBUS();

        public frmStatistics()
        {
            InitializeComponent();
        }

        private void frmStatistics_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadFilters();
            LoadStatistics();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleComboBox(cbFilterResort);
            AppTheme.StyleComboBox(cbFilterMonth);
            AppTheme.StyleComboBox(cbFilterYear);
        }

        private void LoadFilters()
        {
            // Load Resorts
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

            // Load Years
            cbFilterYear.Items.Add("Tất cả");
            for (int year = DateTime.Now.Year; year >= DateTime.Now.Year - 5; year--)
            {
                cbFilterYear.Items.Add(year);
            }
            cbFilterYear.SelectedIndex = 0;

            // Load Months
            cbFilterMonth.Items.Add("Tất cả");
            for (int month = 1; month <= 12; month++)
            {
                cbFilterMonth.Items.Add($"Tháng {month}");
            }
            cbFilterMonth.SelectedIndex = 0;
        }

        private void LoadStatistics()
        {
            // Lấy filter values
            string maCN = null;
            if (cbFilterResort.SelectedIndex > 0 && cbFilterResort.SelectedItem != null)
            {
                try
                {
                    dynamic selected = cbFilterResort.SelectedItem;
                    maCN = selected.MaCN;
                }
                catch { maCN = null; }
            }

            int? year = null;
            if (cbFilterYear.SelectedIndex > 0 && cbFilterYear.SelectedItem != null)
            {
                try { year = Convert.ToInt32(cbFilterYear.SelectedItem); }
                catch { year = null; }
            }

            int? month = null;
            if (cbFilterMonth.SelectedIndex > 0)
            {
                month = cbFilterMonth.SelectedIndex; // 1-12
            }

            try
            {
                // Lấy tất cả thống kê từ BUS
                var data = statisticsBUS.GetAllStatistics(maCN, year, month);

                // ========== Hiển thị PHÒNG ==========
                lblTongPhongValue.Text = $"Tổng: {data.TongPhong:N0}";
                lblPhongTrongValue.Text = $"Trống: {data.PhongTrong:N0}";
                lblPhongDangSuDungValue.Text = $"Đang dùng: {data.PhongDangSuDung:N0}";
                lblPhongBaoTriValue.Text = $"Bảo trì: {data.PhongBaoTri:N0}";
                lblPhongNgungValue.Text = $"Ngưng: {data.PhongNgung:N0}";

                // ========== Hiển thị TÀI CHÍNH ==========
                lblDoanhThuValue.Text = $"Doanh thu: {data.DoanhThu:N0} VNĐ";
                lblChiPhiValue.Text = $"Chi phí: {data.ChiPhi:N0} VNĐ";
                lBUSoiNhuanValue.Text = $"Lợi nhuận: {data.LoiNhuan:N0} VNĐ";
                lBUSoiNhuanValue.ForeColor = data.LoiNhuan >= 0 ? Color.FromArgb(46, 204, 113) : Color.FromArgb(231, 76, 60);
                lblDatCocValue.Text = $"Đặt cọc: {data.DatCoc:N0} VNĐ";
                lblHoanTienValue.Text = $"Hoàn: {data.HoanTien:N0} VNĐ";

                // ========== Hiển thị ĐẶT PHÒNG ==========
                lblTongDatPhongValue.Text = $"Tổng: {data.TongDatPhong:N0} đơn";
                lblDatPhongThanhCongValue.Text = $"Hoàn tất: {data.DatPhongHoanTat:N0}";
                lblDatPhongHuyValue.Text = $"Hủy: {data.DatPhongHuy:N0}";
                lblTiLeThanhCong.Text = $"Tỷ lệ: {data.TiLeThanhCong:F1}%";
                lblTiLeThanhCong.ForeColor = data.TiLeThanhCong >= 80 ? Color.FromArgb(46, 204, 113) :
                                             data.TiLeThanhCong >= 50 ? Color.FromArgb(241, 196, 15) :
                                             Color.FromArgb(231, 76, 60);

                // ========== Hiển thị SỰ KIỆN ==========
                lblTongSuKienValue.Text = $"Tổng: {data.TongSuKien:N0} sự kiện";
                lblDoanhThuSuKienValue.Text = $"Doanh thu: {data.DoanhThuSuKien:N0} VNĐ";

                // ========== Hiển thị KHÁCH HÀNG & NHÂN VIÊN ==========
                lblTongKhachHangValue.Text = $"Tổng KH: {data.TongKhachHang:N0}";
                lblKhachHangMoiValue.Text = $"KH mới: {data.KhachHangMoi:N0}";
                lblTongNhanVienValue.Text = $"Nhân viên: {data.TongNhanVien:N0}";

                // ========== Hiển thị DỊCH VỤ ==========
                lblTongDichVuValue.Text = $"Tổng: {data.TongDichVu:N0} dịch vụ";
                lblDoanhThuDichVuValue.Text = $"Doanh thu: {data.DoanhThuDichVu:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistics();
        }
    }
}
