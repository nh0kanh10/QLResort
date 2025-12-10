using QLResort.BLL;
using QLResort.DAL.DatabaseToolF;
using QLResort.DAL.Constants;
using QLResort.Core.Helpers;
using QLResort.GUI.Styles;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace QLResort.GUI
{
    public partial class frmStatistics : Form
    {
        private readonly FastQuery fastQuery = new FastQuery();

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
            string maCN = null;
            if (cbFilterResort.SelectedIndex > 0 && cbFilterResort.SelectedItem != null)
            {
                try
                {
                    dynamic selected = cbFilterResort.SelectedItem;
                    maCN = selected.MaCN;
                }
                catch
                {
                    maCN = null;
                }
            }

            int? year = null;
            if (cbFilterYear.SelectedIndex > 0 && cbFilterYear.SelectedItem != null)
            {
                try
                {
                    year = Convert.ToInt32(cbFilterYear.SelectedItem);
                }
                catch
                {
                    year = null;
                }
            }

            int? month = null;
            if (cbFilterMonth.SelectedIndex > 0)
            {
                month = cbFilterMonth.SelectedIndex; // 1-12
            }

            try
            {
                // ========== THỐNG KÊ PHÒNG ==========
                var tongPhong = GetTongPhong(maCN);
                lblTongPhongValue.Text = $"{tongPhong:N0}";
                lblTongPhongValue.Text += tongPhong > 0 ? " phòng" : "";

                var phongTrong = GetPhongTheoTrangThai(maCN, "Trống");
                lblPhongTrongValue.Text = $"{phongTrong:N0}";
                lblPhongTrongValue.Text += phongTrong > 0 ? " phòng" : "";

                var phongDangSuDung = GetPhongTheoTrangThai(maCN, "Đã đặt") + 
                                     GetPhongTheoTrangThai(maCN, "Đang sử dụng") +
                                     GetPhongTheoTrangThai(maCN, "Đang Sử Dụng");
                lblPhongDangSuDungValue.Text = $"{phongDangSuDung:N0}";
                lblPhongDangSuDungValue.Text += phongDangSuDung > 0 ? " phòng" : "";

                var phongBaoTri = GetPhongTheoTrangThai(maCN, "Bảo trì") + 
                                 GetPhongTheoTrangThai(maCN, "Đang dọn");
                lblPhongBaoTriValue.Text = $"{phongBaoTri:N0}";
                lblPhongBaoTriValue.Text += phongBaoTri > 0 ? " phòng" : "";

                var phongNgung = GetPhongTheoTrangThai(maCN, "Ngưng hoạt động");
                lblPhongNgungValue.Text = $"{phongNgung:N0}";
                lblPhongNgungValue.Text += phongNgung > 0 ? " phòng" : "";

                // ========== THỐNG KÊ TÀI CHÍNH ==========
                var doanhThu = GetDoanhThu(maCN, year, month);
                lblDoanhThuValue.Text = $"{doanhThu:N0}";
                lblDoanhThuValue.Text += doanhThu > 0 ? " VNĐ" : "";

                var chiPhi = GetChiPhi(maCN, year, month);
                lblChiPhiValue.Text = $"{chiPhi:N0}";
                lblChiPhiValue.Text += chiPhi > 0 ? " VNĐ" : "";

                var loiNhuan = doanhThu - chiPhi;
                lblLoiNhuanValue.Text = $"{loiNhuan:N0}";
                lblLoiNhuanValue.Text += loiNhuan != 0 ? " VNĐ" : "";
                lblLoiNhuanValue.ForeColor = loiNhuan >= 0 ? Color.FromArgb(46, 204, 113) : Color.FromArgb(231, 76, 60);

                var datCoc = GetDatCoc(maCN, year, month);
                lblDatCocValue.Text = $"{datCoc:N0}";
                lblDatCocValue.Text += datCoc > 0 ? " VNĐ" : "";

                var hoanTien = GetHoanTien(maCN, year, month);
                lblHoanTienValue.Text = $"{hoanTien:N0}";
                lblHoanTienValue.Text += hoanTien > 0 ? " VNĐ" : "";

                // ========== THỐNG KÊ ĐẶT PHÒNG ==========
                var tongDatPhong = GetTongDatPhong(maCN, year, month);
                lblTongDatPhongValue.Text = $"{tongDatPhong:N0}";
                lblTongDatPhongValue.Text += tongDatPhong > 0 ? " đơn" : "";

                var datPhongThanhCong = GetDatPhongTheoTrangThai(maCN, "Đã TT", year, month);
                lblDatPhongThanhCongValue.Text = $"{datPhongThanhCong:N0}";
                lblDatPhongThanhCongValue.Text += datPhongThanhCong > 0 ? " đơn" : "";

                var datPhongHuy = GetDatPhongTheoTrangThai(maCN, "Đã hủy", year, month);
                lblDatPhongHuyValue.Text = $"{datPhongHuy:N0}";
                lblDatPhongHuyValue.Text += datPhongHuy > 0 ? " đơn" : "";

                var tiLeThanhCong = tongDatPhong > 0 ? (datPhongThanhCong * 100.0m / tongDatPhong) : 0;
                lblTiLeThanhCong.Text = $"📊 {tiLeThanhCong:F1}%";
                lblTiLeThanhCong.ForeColor = tiLeThanhCong >= 80 ? Color.FromArgb(46, 204, 113) : 
                                             tiLeThanhCong >= 50 ? Color.FromArgb(241, 196, 15) : 
                                             Color.FromArgb(231, 76, 60);

                // ========== THỐNG KÊ SỰ KIỆN ==========
                var tongSuKien = GetTongSuKien(maCN, year, month);
                lblTongSuKienValue.Text = $"{tongSuKien:N0}";
                lblTongSuKienValue.Text += tongSuKien > 0 ? " sự kiện" : "";

                var doanhThuSuKien = GetDoanhThuSuKien(maCN, year, month);
                lblDoanhThuSuKienValue.Text = $"{doanhThuSuKien:N0}";
                lblDoanhThuSuKienValue.Text += doanhThuSuKien > 0 ? " VNĐ" : "";

                // ========== THỐNG KÊ KHÁCH HÀNG & NHÂN VIÊN ==========
                var tongKH = GetTongKhachHang();
                lblTongKhachHangValue.Text = $"{tongKH:N0}";
                lblTongKhachHangValue.Text += tongKH > 0 ? " khách hàng" : "";

                var tongNV = GetTongNhanVien(maCN);
                lblTongNhanVienValue.Text = $"{tongNV:N0}";
                lblTongNhanVienValue.Text += tongNV > 0 ? " nhân viên" : "";

                var khachHangMoi = GetKhachHangMoi(maCN, year, month);
                lblKhachHangMoiValue.Text = $"{khachHangMoi:N0}";
                lblKhachHangMoiValue.Text += khachHangMoi > 0 ? " khách hàng mới" : "";

                // ========== THỐNG KÊ DỊCH VỤ ==========
                var tongDichVu = GetTongDichVu(maCN);
                lblTongDichVuValue.Text = $"{tongDichVu:N0}";
                lblTongDichVuValue.Text += tongDichVu > 0 ? " dịch vụ" : "";

                var doanhThuDichVu = GetDoanhThuDichVu(maCN, year, month);
                lblDoanhThuDichVuValue.Text = $"{doanhThuDichVu:N0}";
                lblDoanhThuDichVuValue.Text += doanhThuDichVu > 0 ? " VNĐ" : "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thống kê: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Database Queries

        private int GetTongPhong(string maCN)
        {
            try
            {
            SqlParameter[] parameters = new SqlParameter[]
            {
                SqlParameterHelper.Create("@MaCN", maCN),
                SqlParameterHelper.Create("@IsActive", true)
            };

            DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Room.GetPhong, parameters);
                return dt != null && dt.Rows != null ? dt.Rows.Count : 0;
            }
            catch { return 0; }
        }

        private int GetPhongTheoTrangThai(string maCN, string trangThai)
        {
            try
            {
            SqlParameter[] parameters = new SqlParameter[]
            {
                SqlParameterHelper.Create("@MaCN", maCN),
                SqlParameterHelper.Create("@TrangThai", trangThai),
                SqlParameterHelper.Create("@IsActive", true)
            };

            DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Room.GetPhong, parameters);
                return dt != null && dt.Rows != null ? dt.Rows.Count : 0;
            }
            catch { return 0; }
        }

        private decimal GetDoanhThu(string maCN, int? year, int? month)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetDoanhThu, parameters);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0 && dt.Rows[0]["DoanhThu"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["DoanhThu"]);
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetDoanhThu error: {ex.Message}");
                return 0;
            }
        }

        private decimal GetChiPhi(string maCN, int? year, int? month)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetChiPhi, parameters);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0 && dt.Rows[0]["ChiPhi"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["ChiPhi"]);
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetChiPhi error: {ex.Message}");
                return 0;
            }
        }

        private decimal GetDatCoc(string maCN, int? year, int? month)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetDatCoc, parameters);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0 && dt.Rows[0]["DatCoc"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["DatCoc"]);
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetDatCoc error: {ex.Message}");
                return 0;
            }
        }

        private decimal GetHoanTien(string maCN, int? year, int? month)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetHoanTien, parameters);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0 && dt.Rows[0]["HoanTien"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["HoanTien"]);
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetHoanTien error: {ex.Message}");
                return 0;
            }
        }

        private int GetTongDatPhong(string maCN, int? year, int? month)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetTongDatPhong, parameters);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetTongDatPhong error: {ex.Message}");
                return 0;
            }
        }

        private int GetDatPhongTheoTrangThai(string maCN, string trangThai, int? year, int? month)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@TrangThai", trangThai),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetDatPhongTheoTrangThai, parameters);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetDatPhongTheoTrangThai error: {ex.Message}");
                return 0;
            }
        }

        private int GetTongSuKien(string maCN, int? year, int? month)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetTongSuKien, parameters);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetTongSuKien error: {ex.Message}");
                return 0;
            }
        }

        private decimal GetDoanhThuSuKien(string maCN, int? year, int? month)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetDoanhThuSuKien, parameters);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0 && dt.Rows[0]["DoanhThu"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["DoanhThu"]);
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetDoanhThuSuKien error: {ex.Message}");
                return 0;
            }
        }

        private int GetTongKhachHang()
        {
            try
            {
                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetTongKhachHang, null);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetTongKhachHang error: {ex.Message}");
                return 0;
            }
        }

        private int GetKhachHangMoi(string maCN, int? year, int? month)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetKhachHangMoi, parameters);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetKhachHangMoi error: {ex.Message}");
                return 0;
            }
        }

        private int GetTongNhanVien(string maCN)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@IsActive", true)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Employee.GetNhanVien, parameters);
                if (dt != null && dt.Rows != null)
                    return dt.Rows.Count;
                return 0;
            }
            catch { return 0; }
        }

        private int GetTongDichVu(string maCN)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@IsActive", true)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Service.GetDichVu, parameters);
                if (dt != null && dt.Rows != null)
                    return dt.Rows.Count;
                return 0;
            }
            catch { return 0; }
        }

        private decimal GetDoanhThuDichVu(string maCN, int? year, int? month)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaCN", maCN),
                    SqlParameterHelper.Create("@Year", year),
                    SqlParameterHelper.Create("@Month", month)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Statistics.GetDoanhThuDichVu, parameters);
                if (dt != null && dt.Rows != null && dt.Rows.Count > 0 && dt.Rows[0]["DoanhThu"] != DBNull.Value)
                    return Convert.ToDecimal(dt.Rows[0]["DoanhThu"]);
                return 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetDoanhThuDichVu error: {ex.Message}");
                return 0;
            }
        }

        #endregion

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistics();
        }
    }
}

