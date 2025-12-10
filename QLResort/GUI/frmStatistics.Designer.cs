using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace QLResort.GUI
{
    partial class frmStatistics
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cbFilterResort;
        private System.Windows.Forms.ComboBox cbFilterMonth;
        private System.Windows.Forms.ComboBox cbFilterYear;
        private System.Windows.Forms.Panel pnlStats;
        
        // GroupBoxes
        private System.Windows.Forms.GroupBox grpPhong;
        private System.Windows.Forms.GroupBox grpTaiChinh;
        private System.Windows.Forms.GroupBox grpDatPhong;
        private System.Windows.Forms.GroupBox grpSuKien;
        private System.Windows.Forms.GroupBox grpKhachHang;
        private System.Windows.Forms.GroupBox grpDichVu;
        
        // Labels cho giá trị thống kê
        private System.Windows.Forms.Label lblTongPhongValue;
        private System.Windows.Forms.Label lblPhongTrongValue;
        private System.Windows.Forms.Label lblPhongDangSuDungValue;
        private System.Windows.Forms.Label lblPhongBaoTriValue;
        private System.Windows.Forms.Label lblPhongNgungValue;
        private System.Windows.Forms.Label lblDoanhThuValue;
        private System.Windows.Forms.Label lblChiPhiValue;
        private System.Windows.Forms.Label lBUSoiNhuanValue;
        private System.Windows.Forms.Label lblDatCocValue;
        private System.Windows.Forms.Label lblHoanTienValue;
        private System.Windows.Forms.Label lblTongDatPhongValue;
        private System.Windows.Forms.Label lblDatPhongThanhCongValue;
        private System.Windows.Forms.Label lblDatPhongHuyValue;
        private System.Windows.Forms.Label lblTiLeThanhCong;
        private System.Windows.Forms.Label lblTongSuKienValue;
        private System.Windows.Forms.Label lblDoanhThuSuKienValue;
        private System.Windows.Forms.Label lblTongKhachHangValue;
        private System.Windows.Forms.Label lblTongNhanVienValue;
        private System.Windows.Forms.Label lblKhachHangMoiValue;
        private System.Windows.Forms.Label lblTongDichVuValue;
        private System.Windows.Forms.Label lblDoanhThuDichVuValue;

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
            this.components = new System.ComponentModel.Container();
            
            // Filter controls
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbFilterResort = new System.Windows.Forms.ComboBox();
            this.cbFilterMonth = new System.Windows.Forms.ComboBox();
            this.cbFilterYear = new System.Windows.Forms.ComboBox();
            this.pnlStats = new System.Windows.Forms.Panel();
            
            // GroupBoxes
            this.grpPhong = new System.Windows.Forms.GroupBox();
            this.grpTaiChinh = new System.Windows.Forms.GroupBox();
            this.grpDatPhong = new System.Windows.Forms.GroupBox();
            this.grpSuKien = new System.Windows.Forms.GroupBox();
            this.grpKhachHang = new System.Windows.Forms.GroupBox();
            this.grpDichVu = new System.Windows.Forms.GroupBox();
            
            // Value labels
            this.lblTongPhongValue = new System.Windows.Forms.Label();
            this.lblPhongTrongValue = new System.Windows.Forms.Label();
            this.lblPhongDangSuDungValue = new System.Windows.Forms.Label();
            this.lblPhongBaoTriValue = new System.Windows.Forms.Label();
            this.lblPhongNgungValue = new System.Windows.Forms.Label();
            this.lblDoanhThuValue = new System.Windows.Forms.Label();
            this.lblChiPhiValue = new System.Windows.Forms.Label();
            this.lBUSoiNhuanValue = new System.Windows.Forms.Label();
            this.lblDatCocValue = new System.Windows.Forms.Label();
            this.lblHoanTienValue = new System.Windows.Forms.Label();
            this.lblTongDatPhongValue = new System.Windows.Forms.Label();
            this.lblDatPhongThanhCongValue = new System.Windows.Forms.Label();
            this.lblDatPhongHuyValue = new System.Windows.Forms.Label();
            this.lblTiLeThanhCong = new System.Windows.Forms.Label();
            this.lblTongSuKienValue = new System.Windows.Forms.Label();
            this.lblDoanhThuSuKienValue = new System.Windows.Forms.Label();
            this.lblTongKhachHangValue = new System.Windows.Forms.Label();
            this.lblKhachHangMoiValue = new System.Windows.Forms.Label();
            this.lblTongNhanVienValue = new System.Windows.Forms.Label();
            this.lblTongDichVuValue = new System.Windows.Forms.Label();
            this.lblDoanhThuDichVuValue = new System.Windows.Forms.Label();
            
            this.SuspendLayout();

            // ========== pnlFilter ==========
            this.pnlFilter.BackColor = Color.FromArgb(236, 240, 241);
            this.pnlFilter.Dock = DockStyle.Top;
            this.pnlFilter.Height = 50;
            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Controls.Add(this.cbFilterResort);
            this.pnlFilter.Controls.Add(this.cbFilterMonth);
            this.pnlFilter.Controls.Add(this.cbFilterYear);

            this.lblFilter.Text = "Lọc theo:";
            this.lblFilter.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.lblFilter.Location = new Point(10, 15);
            this.lblFilter.AutoSize = true;

            this.cbFilterResort.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbFilterResort.Location = new Point(90, 12);
            this.cbFilterResort.Size = new Size(200, 25);
            this.cbFilterResort.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);

            this.cbFilterMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbFilterMonth.Location = new Point(300, 12);
            this.cbFilterMonth.Size = new Size(150, 25);
            this.cbFilterMonth.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);

            this.cbFilterYear.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbFilterYear.Location = new Point(460, 12);
            this.cbFilterYear.Size = new Size(100, 25);
            this.cbFilterYear.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);

            // ========== pnlStats ==========
            this.pnlStats.AutoScroll = true;
            this.pnlStats.Dock = DockStyle.Fill;
            this.pnlStats.BackColor = Color.FromArgb(245, 247, 250);
            this.pnlStats.Padding = new Padding(10);
            this.pnlStats.Controls.Add(this.grpPhong);
            this.pnlStats.Controls.Add(this.grpTaiChinh);
            this.pnlStats.Controls.Add(this.grpDatPhong);
            this.pnlStats.Controls.Add(this.grpSuKien);
            this.pnlStats.Controls.Add(this.grpKhachHang);
            this.pnlStats.Controls.Add(this.grpDichVu);

            // ========== grpPhong ==========
            this.grpPhong.Text = "🏨 PHÒNG";
            this.grpPhong.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.grpPhong.Location = new Point(10, 10);
            this.grpPhong.Size = new Size(620, 100);
            this.grpPhong.Controls.Add(this.lblTongPhongValue);
            this.grpPhong.Controls.Add(this.lblPhongTrongValue);
            this.grpPhong.Controls.Add(this.lblPhongDangSuDungValue);
            this.grpPhong.Controls.Add(this.lblPhongBaoTriValue);
            this.grpPhong.Controls.Add(this.lblPhongNgungValue);

            this.lblTongPhongValue.Text = "Tổng: 0";
            this.lblTongPhongValue.Font = new Font("Segoe UI", 11);
            this.lblTongPhongValue.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblTongPhongValue.Location = new Point(15, 30);
            this.lblTongPhongValue.AutoSize = true;

            this.lblPhongTrongValue.Text = "Trống: 0";
            this.lblPhongTrongValue.Font = new Font("Segoe UI", 11);
            this.lblPhongTrongValue.ForeColor = Color.FromArgb(46, 204, 113);
            this.lblPhongTrongValue.Location = new Point(15, 60);
            this.lblPhongTrongValue.AutoSize = true;

            this.lblPhongDangSuDungValue.Text = "Đang dùng: 0";
            this.lblPhongDangSuDungValue.Font = new Font("Segoe UI", 11);
            this.lblPhongDangSuDungValue.ForeColor = Color.FromArgb(231, 76, 60);
            this.lblPhongDangSuDungValue.Location = new Point(150, 30);
            this.lblPhongDangSuDungValue.AutoSize = true;

            this.lblPhongBaoTriValue.Text = "Bảo trì: 0";
            this.lblPhongBaoTriValue.Font = new Font("Segoe UI", 11);
            this.lblPhongBaoTriValue.ForeColor = Color.FromArgb(241, 196, 15);
            this.lblPhongBaoTriValue.Location = new Point(150, 60);
            this.lblPhongBaoTriValue.AutoSize = true;

            this.lblPhongNgungValue.Text = "Ngưng: 0";
            this.lblPhongNgungValue.Font = new Font("Segoe UI", 11);
            this.lblPhongNgungValue.ForeColor = Color.FromArgb(149, 165, 166);
            this.lblPhongNgungValue.Location = new Point(320, 30);
            this.lblPhongNgungValue.AutoSize = true;

            // ========== grpTaiChinh ==========
            this.grpTaiChinh.Text = "💰 TÀI CHÍNH";
            this.grpTaiChinh.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.grpTaiChinh.Location = new Point(640, 10);
            this.grpTaiChinh.Size = new Size(620, 100);
            this.grpTaiChinh.Controls.Add(this.lblDoanhThuValue);
            this.grpTaiChinh.Controls.Add(this.lblChiPhiValue);
            this.grpTaiChinh.Controls.Add(this.lBUSoiNhuanValue);
            this.grpTaiChinh.Controls.Add(this.lblDatCocValue);
            this.grpTaiChinh.Controls.Add(this.lblHoanTienValue);

            this.lblDoanhThuValue.Text = "Doanh thu: 0 VNĐ";
            this.lblDoanhThuValue.Font = new Font("Segoe UI", 11);
            this.lblDoanhThuValue.ForeColor = Color.FromArgb(155, 89, 182);
            this.lblDoanhThuValue.Location = new Point(15, 30);
            this.lblDoanhThuValue.AutoSize = true;

            this.lblChiPhiValue.Text = "Chi phí: 0 VNĐ";
            this.lblChiPhiValue.Font = new Font("Segoe UI", 11);
            this.lblChiPhiValue.ForeColor = Color.FromArgb(231, 76, 60);
            this.lblChiPhiValue.Location = new Point(15, 60);
            this.lblChiPhiValue.AutoSize = true;

            this.lBUSoiNhuanValue.Text = "Lợi nhuận: 0 VNĐ";
            this.lBUSoiNhuanValue.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.lBUSoiNhuanValue.ForeColor = Color.FromArgb(46, 204, 113);
            this.lBUSoiNhuanValue.Location = new Point(250, 30);
            this.lBUSoiNhuanValue.AutoSize = true;

            this.lblDatCocValue.Text = "Đặt cọc: 0 VNĐ";
            this.lblDatCocValue.Font = new Font("Segoe UI", 11);
            this.lblDatCocValue.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblDatCocValue.Location = new Point(250, 60);
            this.lblDatCocValue.AutoSize = true;

            this.lblHoanTienValue.Text = "Hoàn: 0 VNĐ";
            this.lblHoanTienValue.Font = new Font("Segoe UI", 11);
            this.lblHoanTienValue.ForeColor = Color.FromArgb(241, 196, 15);
            this.lblHoanTienValue.Location = new Point(480, 30);
            this.lblHoanTienValue.AutoSize = true;

            // ========== grpDatPhong ==========
            this.grpDatPhong.Text = "📋 ĐẶT PHÒNG";
            this.grpDatPhong.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.grpDatPhong.Location = new Point(10, 120);
            this.grpDatPhong.Size = new Size(620, 100);
            this.grpDatPhong.Controls.Add(this.lblTongDatPhongValue);
            this.grpDatPhong.Controls.Add(this.lblDatPhongThanhCongValue);
            this.grpDatPhong.Controls.Add(this.lblDatPhongHuyValue);
            this.grpDatPhong.Controls.Add(this.lblTiLeThanhCong);

            this.lblTongDatPhongValue.Text = "Tổng: 0 đơn";
            this.lblTongDatPhongValue.Font = new Font("Segoe UI", 11);
            this.lblTongDatPhongValue.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTongDatPhongValue.Location = new Point(15, 30);
            this.lblTongDatPhongValue.AutoSize = true;

            this.lblDatPhongThanhCongValue.Text = "Hoàn tất: 0";
            this.lblDatPhongThanhCongValue.Font = new Font("Segoe UI", 11);
            this.lblDatPhongThanhCongValue.ForeColor = Color.FromArgb(46, 204, 113);
            this.lblDatPhongThanhCongValue.Location = new Point(15, 60);
            this.lblDatPhongThanhCongValue.AutoSize = true;

            this.lblDatPhongHuyValue.Text = "Hủy: 0";
            this.lblDatPhongHuyValue.Font = new Font("Segoe UI", 11);
            this.lblDatPhongHuyValue.ForeColor = Color.FromArgb(231, 76, 60);
            this.lblDatPhongHuyValue.Location = new Point(180, 30);
            this.lblDatPhongHuyValue.AutoSize = true;

            this.lblTiLeThanhCong.Text = "Tỷ lệ: 0%";
            this.lblTiLeThanhCong.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblTiLeThanhCong.ForeColor = Color.FromArgb(155, 89, 182);
            this.lblTiLeThanhCong.Location = new Point(180, 60);
            this.lblTiLeThanhCong.AutoSize = true;

            // ========== grpSuKien ==========
            this.grpSuKien.Text = "🎉 SỰ KIỆN";
            this.grpSuKien.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.grpSuKien.Location = new Point(640, 120);
            this.grpSuKien.Size = new Size(620, 100);
            this.grpSuKien.Controls.Add(this.lblTongSuKienValue);
            this.grpSuKien.Controls.Add(this.lblDoanhThuSuKienValue);

            this.lblTongSuKienValue.Text = "Tổng: 0 sự kiện";
            this.lblTongSuKienValue.Font = new Font("Segoe UI", 11);
            this.lblTongSuKienValue.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblTongSuKienValue.Location = new Point(15, 40);
            this.lblTongSuKienValue.AutoSize = true;

            this.lblDoanhThuSuKienValue.Text = "Doanh thu: 0 VNĐ";
            this.lblDoanhThuSuKienValue.Font = new Font("Segoe UI", 11);
            this.lblDoanhThuSuKienValue.ForeColor = Color.FromArgb(155, 89, 182);
            this.lblDoanhThuSuKienValue.Location = new Point(200, 40);
            this.lblDoanhThuSuKienValue.AutoSize = true;

            // ========== grpKhachHang ==========
            this.grpKhachHang.Text = "👥 KHÁCH HÀNG & NHÂN VIÊN";
            this.grpKhachHang.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.grpKhachHang.Location = new Point(10, 230);
            this.grpKhachHang.Size = new Size(620, 100);
            this.grpKhachHang.Controls.Add(this.lblTongKhachHangValue);
            this.grpKhachHang.Controls.Add(this.lblKhachHangMoiValue);
            this.grpKhachHang.Controls.Add(this.lblTongNhanVienValue);

            this.lblTongKhachHangValue.Text = "Tổng KH: 0";
            this.lblTongKhachHangValue.Font = new Font("Segoe UI", 11);
            this.lblTongKhachHangValue.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTongKhachHangValue.Location = new Point(15, 40);
            this.lblTongKhachHangValue.AutoSize = true;

            this.lblKhachHangMoiValue.Text = "KH mới: 0";
            this.lblKhachHangMoiValue.Font = new Font("Segoe UI", 11);
            this.lblKhachHangMoiValue.ForeColor = Color.FromArgb(46, 204, 113);
            this.lblKhachHangMoiValue.Location = new Point(150, 40);
            this.lblKhachHangMoiValue.AutoSize = true;

            this.lblTongNhanVienValue.Text = "Nhân viên: 0";
            this.lblTongNhanVienValue.Font = new Font("Segoe UI", 11);
            this.lblTongNhanVienValue.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblTongNhanVienValue.Location = new Point(300, 40);
            this.lblTongNhanVienValue.AutoSize = true;

            // ========== grpDichVu ==========
            this.grpDichVu.Text = "🛎️ DỊCH VỤ";
            this.grpDichVu.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.grpDichVu.Location = new Point(640, 230);
            this.grpDichVu.Size = new Size(620, 100);
            this.grpDichVu.Controls.Add(this.lblTongDichVuValue);
            this.grpDichVu.Controls.Add(this.lblDoanhThuDichVuValue);

            this.lblTongDichVuValue.Text = "Tổng: 0 dịch vụ";
            this.lblTongDichVuValue.Font = new Font("Segoe UI", 11);
            this.lblTongDichVuValue.ForeColor = Color.FromArgb(52, 73, 94);
            this.lblTongDichVuValue.Location = new Point(15, 40);
            this.lblTongDichVuValue.AutoSize = true;

            this.lblDoanhThuDichVuValue.Text = "Doanh thu: 0 VNĐ";
            this.lblDoanhThuDichVuValue.Font = new Font("Segoe UI", 11);
            this.lblDoanhThuDichVuValue.ForeColor = Color.FromArgb(155, 89, 182);
            this.lblDoanhThuDichVuValue.Location = new Point(200, 40);
            this.lblDoanhThuDichVuValue.AutoSize = true;

            // ========== Form ==========
            this.Text = "Thống Kê Resort";
            this.Size = new Size(1300, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmStatistics_Load);

            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlFilter);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
