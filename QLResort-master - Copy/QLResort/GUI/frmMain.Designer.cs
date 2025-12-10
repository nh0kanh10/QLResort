namespace QLResort.GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLy;
        private System.Windows.Forms.ToolStripMenuItem menuPhong;
        private System.Windows.Forms.ToolStripMenuItem menuLoaiPhong;
        private System.Windows.Forms.ToolStripMenuItem menuDichVu;
        private System.Windows.Forms.ToolStripMenuItem menuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem menuLoaiKhachHang;
        private System.Windows.Forms.ToolStripMenuItem menuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem menuLoaiNhanVien;
        private System.Windows.Forms.ToolStripMenuItem menuChiNhanh;
        private System.Windows.Forms.ToolStripMenuItem menuDatPhong;
        private System.Windows.Forms.ToolStripMenuItem menuHoaDon;
        private System.Windows.Forms.ToolStripMenuItem menuThanhToan;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyKhuyenMai;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyLoaiThanhToan;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyDoThatLac;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyKhieuNai;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyVoucher;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyGoiSuKien;
        private System.Windows.Forms.ToolStripMenuItem menuQuanLyTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem menuDatSuKien;
        private System.Windows.Forms.ToolStripMenuItem menuThanhToanSuKien;
        private System.Windows.Forms.ToolStripMenuItem menuThongKe;
        private System.Windows.Forms.ToolStripMenuItem menuHeThong;
        private System.Windows.Forms.ToolStripMenuItem menuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem menuThoat;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblResort;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoaiPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoaiKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoaiNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChiNhanh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyKhuyenMai = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyLoaiThanhToan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyDoThatLac = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyKhieuNai = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyGoiSuKien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatSuKien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThanhToanSuKien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThanhToan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblResort = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuQuanLy,
            this.menuDatPhong,
            this.menuDatSuKien,
            this.menuHoaDon,
            this.menuThanhToan,
            this.menuThanhToanSuKien,
            this.menuThongKe,
            this.menuHeThong});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1600, 30);
            this.menuStrip1.TabIndex = 0;
            // 
            // menuQuanLy
            // 
            this.menuQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPhong,
            this.menuLoaiPhong,
            this.menuDichVu,
            this.menuKhachHang,
            this.menuLoaiKhachHang,
            this.menuNhanVien,
            this.menuLoaiNhanVien,
            this.menuChiNhanh,
            this.menuQuanLyKhuyenMai,
            this.menuQuanLyLoaiThanhToan,
            this.menuQuanLyDoThatLac,
            this.menuQuanLyGoiSuKien,
            this.menuQuanLyKhieuNai,
            this.menuQuanLyVoucher});
            this.menuQuanLy.Name = "menuQuanLy";
            this.menuQuanLy.Size = new System.Drawing.Size(73, 26);
            this.menuQuanLy.Text = "Quản lý";
            // 
            // menuPhong
            // 
            this.menuPhong.Name = "menuPhong";
            this.menuPhong.Size = new System.Drawing.Size(223, 26);
            this.menuPhong.Text = "Quản lý Phòng";
            this.menuPhong.Click += new System.EventHandler(this.menuQuanLyPhong_Click);
            // 
            // menuLoaiPhong
            // 
            this.menuLoaiPhong.Name = "menuLoaiPhong";
            this.menuLoaiPhong.Size = new System.Drawing.Size(223, 26);
            this.menuLoaiPhong.Text = "Quản lý Loại Phòng";
            this.menuLoaiPhong.Click += new System.EventHandler(this.menuQuanLyLoaiPhong_Click);
            // 
            // menuDichVu
            // 
            this.menuDichVu.Name = "menuDichVu";
            this.menuDichVu.Size = new System.Drawing.Size(223, 26);
            this.menuDichVu.Text = "Quản lý Dịch vụ";
            this.menuDichVu.Click += new System.EventHandler(this.menuQuanLyDichVu_Click);
            // 
            // menuKhachHang
            // 
            this.menuKhachHang.Name = "menuKhachHang";
            this.menuKhachHang.Size = new System.Drawing.Size(223, 26);
            this.menuKhachHang.Text = "Quản lý Khách hàng";
            this.menuKhachHang.Click += new System.EventHandler(this.menuQuanLyKhachHang_Click);
            // 
            // menuLoaiKhachHang
            // 
            this.menuLoaiKhachHang.Name = "menuLoaiKhachHang";
            this.menuLoaiKhachHang.Size = new System.Drawing.Size(223, 26);
            this.menuLoaiKhachHang.Text = "Quản lý Loại KH";
            this.menuLoaiKhachHang.Click += new System.EventHandler(this.menuQuanLyLoaiKhachHang_Click);
            // 
            // menuNhanVien
            // 
            this.menuNhanVien.Name = "menuNhanVien";
            this.menuNhanVien.Size = new System.Drawing.Size(223, 26);
            this.menuNhanVien.Text = "Quản lý Nhân viên";
            this.menuNhanVien.Click += new System.EventHandler(this.menuQuanLyNhanVien_Click);
            // 
            // menuLoaiNhanVien
            // 
            this.menuLoaiNhanVien.Name = "menuLoaiNhanVien";
            this.menuLoaiNhanVien.Size = new System.Drawing.Size(223, 26);
            this.menuLoaiNhanVien.Text = "Quản lý Loại NV";
            this.menuLoaiNhanVien.Click += new System.EventHandler(this.menuQuanLyLoaiNhanVien_Click);
            // 
            // menuChiNhanh
            // 
            this.menuChiNhanh.Name = "menuChiNhanh";
            this.menuChiNhanh.Size = new System.Drawing.Size(223, 26);
            this.menuChiNhanh.Text = "Quản lý Chi nhánh";
            this.menuChiNhanh.Click += new System.EventHandler(this.menuQuanLyChiNhanh_Click);
            // 
            // menuQuanLyKhuyenMai
            // 
            this.menuQuanLyKhuyenMai.Name = "menuQuanLyKhuyenMai";
            this.menuQuanLyKhuyenMai.Size = new System.Drawing.Size(223, 26);
            this.menuQuanLyKhuyenMai.Text = "Quản lý Khuyến mãi";
            this.menuQuanLyKhuyenMai.Click += new System.EventHandler(this.menuQuanLyKhuyenMai_Click);
            // 
            // menuQuanLyLoaiThanhToan
            // 
            this.menuQuanLyLoaiThanhToan.Name = "menuQuanLyLoaiThanhToan";
            this.menuQuanLyLoaiThanhToan.Size = new System.Drawing.Size(223, 26);
            this.menuQuanLyLoaiThanhToan.Text = "Quản lý Loại TT";
            this.menuQuanLyLoaiThanhToan.Click += new System.EventHandler(this.menuQuanLyLoaiThanhToan_Click);
            // 
            // menuQuanLyDoThatLac
            // 
            this.menuQuanLyDoThatLac.Name = "menuQuanLyDoThatLac";
            this.menuQuanLyDoThatLac.Size = new System.Drawing.Size(223, 26);
            this.menuQuanLyDoThatLac.Text = "Quản lý Đồ Thất Lạc";
            this.menuQuanLyDoThatLac.Click += new System.EventHandler(this.menuQuanLyDoThatLac_Click);
            // 
            // menuQuanLyKhieuNai
            // 
            this.menuQuanLyKhieuNai.Name = "menuQuanLyKhieuNai";
            this.menuQuanLyKhieuNai.Size = new System.Drawing.Size(223, 26);
            this.menuQuanLyKhieuNai.Text = "Quản lý Khiếu nại";
            this.menuQuanLyKhieuNai.Click += new System.EventHandler(this.menuQuanLyKhieuNai_Click);
            // 
            // menuQuanLyVoucher
            // 
            this.menuQuanLyVoucher.Name = "menuQuanLyVoucher";
            this.menuQuanLyVoucher.Size = new System.Drawing.Size(223, 26);
            this.menuQuanLyVoucher.Text = "Quản lý Voucher";
            this.menuQuanLyVoucher.Click += new System.EventHandler(this.menuQuanLyVoucher_Click);
            // 
            // menuQuanLyTaiKhoan
            // 
            this.menuQuanLyTaiKhoan.Name = "menuQuanLyTaiKhoan";
            this.menuQuanLyTaiKhoan.Size = new System.Drawing.Size(223, 26);
            this.menuQuanLyTaiKhoan.Text = "Quản lý Tài khoản";
            this.menuQuanLyTaiKhoan.Click += new System.EventHandler(this.menuQuanLyTaiKhoan_Click);
            // 
            // menuQuanLyGoiSuKien
            // 
            this.menuQuanLyGoiSuKien.Name = "menuQuanLyGoiSuKien";
            this.menuQuanLyGoiSuKien.Size = new System.Drawing.Size(223, 26);
            this.menuQuanLyGoiSuKien.Text = "Quản lý Gói Sự Kiện";
            this.menuQuanLyGoiSuKien.Click += new System.EventHandler(this.menuQuanLyGoiSuKien_Click);
            // 
            // menuDatPhong
            // 
            this.menuDatPhong.Name = "menuDatPhong";
            this.menuDatPhong.Size = new System.Drawing.Size(94, 26);
            this.menuDatPhong.Text = "Đặt phòng";
            this.menuDatPhong.Click += new System.EventHandler(this.menuDatPhong_Click);
            // 
            // menuHoaDon
            // 
            this.menuHoaDon.Name = "menuHoaDon";
            this.menuHoaDon.Size = new System.Drawing.Size(81, 26);
            this.menuHoaDon.Text = "Hóa đơn";
            this.menuHoaDon.Click += new System.EventHandler(this.menuHoaDon_Click);
            // 
            // menuThanhToan
            // 
            this.menuThanhToan.Name = "menuThanhToan";
            this.menuThanhToan.Size = new System.Drawing.Size(97, 26);
            this.menuThanhToan.Text = "Thanh toán";
            this.menuThanhToan.Click += new System.EventHandler(this.menuThanhToan_Click);
            // 
            // menuDatSuKien
            // 
            this.menuDatSuKien.Name = "menuDatSuKien";
            this.menuDatSuKien.Size = new System.Drawing.Size(94, 26);
            this.menuDatSuKien.Text = "Đặt sự kiện";
            this.menuDatSuKien.Click += new System.EventHandler(this.menuDatSuKien_Click);
            // 
            // menuThanhToanSuKien
            // 
            this.menuThanhToanSuKien.Name = "menuThanhToanSuKien";
            this.menuThanhToanSuKien.Size = new System.Drawing.Size(130, 26);
            this.menuThanhToanSuKien.Text = "Thanh toán sự kiện";
            this.menuThanhToanSuKien.Click += new System.EventHandler(this.menuThanhToanSuKien_Click);
            // 
            // menuThongKe
            // 
            this.menuThongKe.Name = "menuThongKe";
            this.menuThongKe.Size = new System.Drawing.Size(84, 26);
            this.menuThongKe.Text = "Thống kê";
            this.menuThongKe.Click += new System.EventHandler(this.menuThongKe_Click);
            // 
            // menuHeThong
            // 
            this.menuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDangXuat,
            this.menuThoat});
            this.menuHeThong.Name = "menuHeThong";
            this.menuHeThong.Size = new System.Drawing.Size(85, 26);
            this.menuHeThong.Text = "Hệ thống";
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(160, 26);
            this.menuDangXuat.Text = "Đăng xuất";
            this.menuDangXuat.Click += new System.EventHandler(this.menuDangXuat_Click);
            // 
            // menuThoat
            // 
            this.menuThoat.Name = "menuThoat";
            this.menuThoat.Size = new System.Drawing.Size(160, 26);
            this.menuThoat.Text = "Thoát";
            this.menuThoat.Click += new System.EventHandler(this.menuThoat_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 104);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1600, 759);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 30);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1600, 74);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(27, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(465, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ RESORT";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser,
            this.lblResort});
            this.statusStrip1.Location = new System.Drawing.Point(0, 863);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1600, 26);
            this.statusStrip1.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(54, 20);
            this.lblUser.Text = "User: ...";
            // 
            // lblResort
            // 
            this.lblResort.Name = "lblResort";
            this.lblResort.Size = new System.Drawing.Size(67, 20);
            this.lblResort.Text = "Resort: ...";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 889);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Resort";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

