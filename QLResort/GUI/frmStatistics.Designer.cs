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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbFilterResort = new System.Windows.Forms.ComboBox();
            this.cbFilterMonth = new System.Windows.Forms.ComboBox();
            this.cbFilterYear = new System.Windows.Forms.ComboBox();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.grpPhong = new System.Windows.Forms.GroupBox();
            this.lblTongPhongValue = new System.Windows.Forms.Label();
            this.lblPhongTrongValue = new System.Windows.Forms.Label();
            this.lblPhongDangSuDungValue = new System.Windows.Forms.Label();
            this.lblPhongBaoTriValue = new System.Windows.Forms.Label();
            this.lblPhongNgungValue = new System.Windows.Forms.Label();
            this.grpTaiChinh = new System.Windows.Forms.GroupBox();
            this.lblDoanhThuValue = new System.Windows.Forms.Label();
            this.lblChiPhiValue = new System.Windows.Forms.Label();
            this.lBUSoiNhuanValue = new System.Windows.Forms.Label();
            this.lblDatCocValue = new System.Windows.Forms.Label();
            this.lblHoanTienValue = new System.Windows.Forms.Label();
            this.grpDatPhong = new System.Windows.Forms.GroupBox();
            this.lblTongDatPhongValue = new System.Windows.Forms.Label();
            this.lblDatPhongThanhCongValue = new System.Windows.Forms.Label();
            this.lblDatPhongHuyValue = new System.Windows.Forms.Label();
            this.lblTiLeThanhCong = new System.Windows.Forms.Label();
            this.grpSuKien = new System.Windows.Forms.GroupBox();
            this.lblTongSuKienValue = new System.Windows.Forms.Label();
            this.lblDoanhThuSuKienValue = new System.Windows.Forms.Label();
            this.grpKhachHang = new System.Windows.Forms.GroupBox();
            this.lblTongKhachHangValue = new System.Windows.Forms.Label();
            this.lblKhachHangMoiValue = new System.Windows.Forms.Label();
            this.lblTongNhanVienValue = new System.Windows.Forms.Label();
            this.grpDichVu = new System.Windows.Forms.GroupBox();
            this.lblTongDichVuValue = new System.Windows.Forms.Label();
            this.lblDoanhThuDichVuValue = new System.Windows.Forms.Label();
            this.pnlFilter.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.grpPhong.SuspendLayout();
            this.grpTaiChinh.SuspendLayout();
            this.grpDatPhong.SuspendLayout();
            this.grpSuKien.SuspendLayout();
            this.grpKhachHang.SuspendLayout();
            this.grpDichVu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Controls.Add(this.cbFilterResort);
            this.pnlFilter.Controls.Add(this.cbFilterMonth);
            this.pnlFilter.Controls.Add(this.cbFilterYear);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1284, 50);
            this.pnlFilter.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilter.Location = new System.Drawing.Point(10, 15);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(70, 19);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Lọc theo:";
            // 
            // cbFilterResort
            // 
            this.cbFilterResort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterResort.Location = new System.Drawing.Point(90, 12);
            this.cbFilterResort.Name = "cbFilterResort";
            this.cbFilterResort.Size = new System.Drawing.Size(200, 21);
            this.cbFilterResort.TabIndex = 1;
            this.cbFilterResort.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cbFilterMonth
            // 
            this.cbFilterMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterMonth.Location = new System.Drawing.Point(300, 12);
            this.cbFilterMonth.Name = "cbFilterMonth";
            this.cbFilterMonth.Size = new System.Drawing.Size(150, 21);
            this.cbFilterMonth.TabIndex = 2;
            this.cbFilterMonth.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cbFilterYear
            // 
            this.cbFilterYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterYear.Location = new System.Drawing.Point(460, 12);
            this.cbFilterYear.Name = "cbFilterYear";
            this.cbFilterYear.Size = new System.Drawing.Size(100, 21);
            this.cbFilterYear.TabIndex = 3;
            this.cbFilterYear.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // pnlStats
            // 
            this.pnlStats.AutoScroll = true;
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlStats.Controls.Add(this.grpPhong);
            this.pnlStats.Controls.Add(this.grpTaiChinh);
            this.pnlStats.Controls.Add(this.grpDatPhong);
            this.pnlStats.Controls.Add(this.grpSuKien);
            this.pnlStats.Controls.Add(this.grpKhachHang);
            this.pnlStats.Controls.Add(this.grpDichVu);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStats.Location = new System.Drawing.Point(0, 50);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(10);
            this.pnlStats.Size = new System.Drawing.Size(1284, 382);
            this.pnlStats.TabIndex = 0;
            // 
            // grpPhong
            // 
            this.grpPhong.Controls.Add(this.lblTongPhongValue);
            this.grpPhong.Controls.Add(this.lblPhongTrongValue);
            this.grpPhong.Controls.Add(this.lblPhongDangSuDungValue);
            this.grpPhong.Controls.Add(this.lblPhongBaoTriValue);
            this.grpPhong.Controls.Add(this.lblPhongNgungValue);
            this.grpPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpPhong.Location = new System.Drawing.Point(10, 10);
            this.grpPhong.Name = "grpPhong";
            this.grpPhong.Size = new System.Drawing.Size(620, 100);
            this.grpPhong.TabIndex = 0;
            this.grpPhong.TabStop = false;
            this.grpPhong.Text = "🏨 PHÒNG";
            // 
            // lblTongPhongValue
            // 
            this.lblTongPhongValue.AutoSize = true;
            this.lblTongPhongValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTongPhongValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTongPhongValue.Location = new System.Drawing.Point(15, 30);
            this.lblTongPhongValue.Name = "lblTongPhongValue";
            this.lblTongPhongValue.Size = new System.Drawing.Size(58, 20);
            this.lblTongPhongValue.TabIndex = 0;
            this.lblTongPhongValue.Text = "Tổng: 0";
            // 
            // lblPhongTrongValue
            // 
            this.lblPhongTrongValue.AutoSize = true;
            this.lblPhongTrongValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPhongTrongValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblPhongTrongValue.Location = new System.Drawing.Point(15, 60);
            this.lblPhongTrongValue.Name = "lblPhongTrongValue";
            this.lblPhongTrongValue.Size = new System.Drawing.Size(62, 20);
            this.lblPhongTrongValue.TabIndex = 1;
            this.lblPhongTrongValue.Text = "Trống: 0";
            // 
            // lblPhongDangSuDungValue
            // 
            this.lblPhongDangSuDungValue.AutoSize = true;
            this.lblPhongDangSuDungValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPhongDangSuDungValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblPhongDangSuDungValue.Location = new System.Drawing.Point(150, 30);
            this.lblPhongDangSuDungValue.Name = "lblPhongDangSuDungValue";
            this.lblPhongDangSuDungValue.Size = new System.Drawing.Size(98, 20);
            this.lblPhongDangSuDungValue.TabIndex = 2;
            this.lblPhongDangSuDungValue.Text = "Đang dùng: 0";
            // 
            // lblPhongBaoTriValue
            // 
            this.lblPhongBaoTriValue.AutoSize = true;
            this.lblPhongBaoTriValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPhongBaoTriValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.lblPhongBaoTriValue.Location = new System.Drawing.Point(150, 60);
            this.lblPhongBaoTriValue.Name = "lblPhongBaoTriValue";
            this.lblPhongBaoTriValue.Size = new System.Drawing.Size(68, 20);
            this.lblPhongBaoTriValue.TabIndex = 3;
            this.lblPhongBaoTriValue.Text = "Bảo trì: 0";
            // 
            // lblPhongNgungValue
            // 
            this.lblPhongNgungValue.AutoSize = true;
            this.lblPhongNgungValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPhongNgungValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblPhongNgungValue.Location = new System.Drawing.Point(320, 30);
            this.lblPhongNgungValue.Name = "lblPhongNgungValue";
            this.lblPhongNgungValue.Size = new System.Drawing.Size(70, 20);
            this.lblPhongNgungValue.TabIndex = 4;
            this.lblPhongNgungValue.Text = "Ngưng: 0";
            // 
            // grpTaiChinh
            // 
            this.grpTaiChinh.Controls.Add(this.lblDoanhThuValue);
            this.grpTaiChinh.Controls.Add(this.lblChiPhiValue);
            this.grpTaiChinh.Controls.Add(this.lBUSoiNhuanValue);
            this.grpTaiChinh.Controls.Add(this.lblDatCocValue);
            this.grpTaiChinh.Controls.Add(this.lblHoanTienValue);
            this.grpTaiChinh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpTaiChinh.Location = new System.Drawing.Point(640, 10);
            this.grpTaiChinh.Name = "grpTaiChinh";
            this.grpTaiChinh.Size = new System.Drawing.Size(620, 100);
            this.grpTaiChinh.TabIndex = 1;
            this.grpTaiChinh.TabStop = false;
            this.grpTaiChinh.Text = "💰 TÀI CHÍNH";
            // 
            // lblDoanhThuValue
            // 
            this.lblDoanhThuValue.AutoSize = true;
            this.lblDoanhThuValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDoanhThuValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblDoanhThuValue.Location = new System.Drawing.Point(15, 30);
            this.lblDoanhThuValue.Name = "lblDoanhThuValue";
            this.lblDoanhThuValue.Size = new System.Drawing.Size(128, 20);
            this.lblDoanhThuValue.TabIndex = 0;
            this.lblDoanhThuValue.Text = "Doanh thu: 0 VNĐ";
            // 
            // lblChiPhiValue
            // 
            this.lblChiPhiValue.AutoSize = true;
            this.lblChiPhiValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblChiPhiValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblChiPhiValue.Location = new System.Drawing.Point(15, 60);
            this.lblChiPhiValue.Name = "lblChiPhiValue";
            this.lblChiPhiValue.Size = new System.Drawing.Size(105, 20);
            this.lblChiPhiValue.TabIndex = 1;
            this.lblChiPhiValue.Text = "Chi phí: 0 VNĐ";
            // 
            // lBUSoiNhuanValue
            // 
            this.lBUSoiNhuanValue.AutoSize = true;
            this.lBUSoiNhuanValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lBUSoiNhuanValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lBUSoiNhuanValue.Location = new System.Drawing.Point(250, 30);
            this.lBUSoiNhuanValue.Name = "lBUSoiNhuanValue";
            this.lBUSoiNhuanValue.Size = new System.Drawing.Size(132, 20);
            this.lBUSoiNhuanValue.TabIndex = 2;
            this.lBUSoiNhuanValue.Text = "Lợi nhuận: 0 VNĐ";
            // 
            // lblDatCocValue
            // 
            this.lblDatCocValue.AutoSize = true;
            this.lblDatCocValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDatCocValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblDatCocValue.Location = new System.Drawing.Point(250, 60);
            this.lblDatCocValue.Name = "lblDatCocValue";
            this.lblDatCocValue.Size = new System.Drawing.Size(110, 20);
            this.lblDatCocValue.TabIndex = 3;
            this.lblDatCocValue.Text = "Đặt cọc: 0 VNĐ";
            // 
            // lblHoanTienValue
            // 
            this.lblHoanTienValue.AutoSize = true;
            this.lblHoanTienValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblHoanTienValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.lblHoanTienValue.Location = new System.Drawing.Point(480, 30);
            this.lblHoanTienValue.Name = "lblHoanTienValue";
            this.lblHoanTienValue.Size = new System.Drawing.Size(95, 20);
            this.lblHoanTienValue.TabIndex = 4;
            this.lblHoanTienValue.Text = "Hoàn: 0 VNĐ";
            // 
            // grpDatPhong
            // 
            this.grpDatPhong.Controls.Add(this.lblTongDatPhongValue);
            this.grpDatPhong.Controls.Add(this.lblDatPhongThanhCongValue);
            this.grpDatPhong.Controls.Add(this.lblDatPhongHuyValue);
            this.grpDatPhong.Controls.Add(this.lblTiLeThanhCong);
            this.grpDatPhong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDatPhong.Location = new System.Drawing.Point(10, 120);
            this.grpDatPhong.Name = "grpDatPhong";
            this.grpDatPhong.Size = new System.Drawing.Size(620, 100);
            this.grpDatPhong.TabIndex = 2;
            this.grpDatPhong.TabStop = false;
            this.grpDatPhong.Text = "📋 ĐẶT PHÒNG";
            // 
            // lblTongDatPhongValue
            // 
            this.lblTongDatPhongValue.AutoSize = true;
            this.lblTongDatPhongValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTongDatPhongValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTongDatPhongValue.Location = new System.Drawing.Point(15, 30);
            this.lblTongDatPhongValue.Name = "lblTongDatPhongValue";
            this.lblTongDatPhongValue.Size = new System.Drawing.Size(88, 20);
            this.lblTongDatPhongValue.TabIndex = 0;
            this.lblTongDatPhongValue.Text = "Tổng: 0 đơn";
            // 
            // lblDatPhongThanhCongValue
            // 
            this.lblDatPhongThanhCongValue.AutoSize = true;
            this.lblDatPhongThanhCongValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDatPhongThanhCongValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblDatPhongThanhCongValue.Location = new System.Drawing.Point(15, 60);
            this.lblDatPhongThanhCongValue.Name = "lblDatPhongThanhCongValue";
            this.lblDatPhongThanhCongValue.Size = new System.Drawing.Size(82, 20);
            this.lblDatPhongThanhCongValue.TabIndex = 1;
            this.lblDatPhongThanhCongValue.Text = "Hoàn tất: 0";
            // 
            // lblDatPhongHuyValue
            // 
            this.lblDatPhongHuyValue.AutoSize = true;
            this.lblDatPhongHuyValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDatPhongHuyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblDatPhongHuyValue.Location = new System.Drawing.Point(180, 30);
            this.lblDatPhongHuyValue.Name = "lblDatPhongHuyValue";
            this.lblDatPhongHuyValue.Size = new System.Drawing.Size(50, 20);
            this.lblDatPhongHuyValue.TabIndex = 2;
            this.lblDatPhongHuyValue.Text = "Hủy: 0";
            // 
            // lblTiLeThanhCong
            // 
            this.lblTiLeThanhCong.AutoSize = true;
            this.lblTiLeThanhCong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTiLeThanhCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTiLeThanhCong.Location = new System.Drawing.Point(180, 60);
            this.lblTiLeThanhCong.Name = "lblTiLeThanhCong";
            this.lblTiLeThanhCong.Size = new System.Drawing.Size(77, 21);
            this.lblTiLeThanhCong.TabIndex = 3;
            this.lblTiLeThanhCong.Text = "Tỷ lệ: 0%";
            // 
            // grpSuKien
            // 
            this.grpSuKien.Controls.Add(this.lblTongSuKienValue);
            this.grpSuKien.Controls.Add(this.lblDoanhThuSuKienValue);
            this.grpSuKien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpSuKien.Location = new System.Drawing.Point(640, 120);
            this.grpSuKien.Name = "grpSuKien";
            this.grpSuKien.Size = new System.Drawing.Size(620, 100);
            this.grpSuKien.TabIndex = 3;
            this.grpSuKien.TabStop = false;
            this.grpSuKien.Text = "🎉 SỰ KIỆN";
            // 
            // lblTongSuKienValue
            // 
            this.lblTongSuKienValue.AutoSize = true;
            this.lblTongSuKienValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTongSuKienValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTongSuKienValue.Location = new System.Drawing.Point(15, 40);
            this.lblTongSuKienValue.Name = "lblTongSuKienValue";
            this.lblTongSuKienValue.Size = new System.Drawing.Size(108, 20);
            this.lblTongSuKienValue.TabIndex = 0;
            this.lblTongSuKienValue.Text = "Tổng: 0 sự kiện";
            // 
            // lblDoanhThuSuKienValue
            // 
            this.lblDoanhThuSuKienValue.AutoSize = true;
            this.lblDoanhThuSuKienValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDoanhThuSuKienValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblDoanhThuSuKienValue.Location = new System.Drawing.Point(200, 40);
            this.lblDoanhThuSuKienValue.Name = "lblDoanhThuSuKienValue";
            this.lblDoanhThuSuKienValue.Size = new System.Drawing.Size(128, 20);
            this.lblDoanhThuSuKienValue.TabIndex = 1;
            this.lblDoanhThuSuKienValue.Text = "Doanh thu: 0 VNĐ";
            // 
            // grpKhachHang
            // 
            this.grpKhachHang.Controls.Add(this.lblTongKhachHangValue);
            this.grpKhachHang.Controls.Add(this.lblKhachHangMoiValue);
            this.grpKhachHang.Controls.Add(this.lblTongNhanVienValue);
            this.grpKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpKhachHang.Location = new System.Drawing.Point(10, 230);
            this.grpKhachHang.Name = "grpKhachHang";
            this.grpKhachHang.Size = new System.Drawing.Size(620, 100);
            this.grpKhachHang.TabIndex = 4;
            this.grpKhachHang.TabStop = false;
            this.grpKhachHang.Text = "👥 KHÁCH HÀNG & NHÂN VIÊN";
            // 
            // lblTongKhachHangValue
            // 
            this.lblTongKhachHangValue.AutoSize = true;
            this.lblTongKhachHangValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTongKhachHangValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTongKhachHangValue.Location = new System.Drawing.Point(15, 40);
            this.lblTongKhachHangValue.Name = "lblTongKhachHangValue";
            this.lblTongKhachHangValue.Size = new System.Drawing.Size(82, 20);
            this.lblTongKhachHangValue.TabIndex = 0;
            this.lblTongKhachHangValue.Text = "Tổng KH: 0";
            // 
            // lblKhachHangMoiValue
            // 
            this.lblKhachHangMoiValue.AutoSize = true;
            this.lblKhachHangMoiValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblKhachHangMoiValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblKhachHangMoiValue.Location = new System.Drawing.Point(150, 40);
            this.lblKhachHangMoiValue.Name = "lblKhachHangMoiValue";
            this.lblKhachHangMoiValue.Size = new System.Drawing.Size(74, 20);
            this.lblKhachHangMoiValue.TabIndex = 1;
            this.lblKhachHangMoiValue.Text = "KH mới: 0";
            // 
            // lblTongNhanVienValue
            // 
            this.lblTongNhanVienValue.AutoSize = true;
            this.lblTongNhanVienValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTongNhanVienValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTongNhanVienValue.Location = new System.Drawing.Point(300, 40);
            this.lblTongNhanVienValue.Name = "lblTongNhanVienValue";
            this.lblTongNhanVienValue.Size = new System.Drawing.Size(90, 20);
            this.lblTongNhanVienValue.TabIndex = 2;
            this.lblTongNhanVienValue.Text = "Nhân viên: 0";
            // 
            // grpDichVu
            // 
            this.grpDichVu.Controls.Add(this.lblTongDichVuValue);
            this.grpDichVu.Controls.Add(this.lblDoanhThuDichVuValue);
            this.grpDichVu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpDichVu.Location = new System.Drawing.Point(640, 230);
            this.grpDichVu.Name = "grpDichVu";
            this.grpDichVu.Size = new System.Drawing.Size(620, 100);
            this.grpDichVu.TabIndex = 5;
            this.grpDichVu.TabStop = false;
            this.grpDichVu.Text = "🛎️ DỊCH VỤ";
            // 
            // lblTongDichVuValue
            // 
            this.lblTongDichVuValue.AutoSize = true;
            this.lblTongDichVuValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTongDichVuValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTongDichVuValue.Location = new System.Drawing.Point(15, 40);
            this.lblTongDichVuValue.Name = "lblTongDichVuValue";
            this.lblTongDichVuValue.Size = new System.Drawing.Size(109, 20);
            this.lblTongDichVuValue.TabIndex = 0;
            this.lblTongDichVuValue.Text = "Tổng: 0 dịch vụ";
            // 
            // lblDoanhThuDichVuValue
            // 
            this.lblDoanhThuDichVuValue.AutoSize = true;
            this.lblDoanhThuDichVuValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDoanhThuDichVuValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblDoanhThuDichVuValue.Location = new System.Drawing.Point(200, 40);
            this.lblDoanhThuDichVuValue.Name = "lblDoanhThuDichVuValue";
            this.lblDoanhThuDichVuValue.Size = new System.Drawing.Size(128, 20);
            this.lblDoanhThuDichVuValue.TabIndex = 1;
            this.lblDoanhThuDichVuValue.Text = "Doanh thu: 0 VNĐ";
            // 
            // frmStatistics
            // 
            this.ClientSize = new System.Drawing.Size(1284, 432);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlFilter);
            this.Name = "frmStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống Kê Resort";
            this.Load += new System.EventHandler(this.frmStatistics_Load);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.grpPhong.ResumeLayout(false);
            this.grpPhong.PerformLayout();
            this.grpTaiChinh.ResumeLayout(false);
            this.grpTaiChinh.PerformLayout();
            this.grpDatPhong.ResumeLayout(false);
            this.grpDatPhong.PerformLayout();
            this.grpSuKien.ResumeLayout(false);
            this.grpSuKien.PerformLayout();
            this.grpKhachHang.ResumeLayout(false);
            this.grpKhachHang.PerformLayout();
            this.grpDichVu.ResumeLayout(false);
            this.grpDichVu.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
