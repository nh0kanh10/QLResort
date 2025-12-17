namespace GUI_QLResort
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
        private System.Windows.Forms.ToolStripMenuItem menuTraCuuKhachHang;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuQuanLyTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblResort = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoaiPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoaiKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTraCuuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoaiNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChiNhanh = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyKhuyenMai = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyLoaiThanhToan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyDoThatLac = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyGoiSuKien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyKhieuNai = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuanLyVoucher = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatSuKien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThanhToan = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThanhToanSuKien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.menuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuQuanLyTaiKhoan
            // 
            this.menuQuanLyTaiKhoan.Name = "menuQuanLyTaiKhoan";
            this.menuQuanLyTaiKhoan.Size = new System.Drawing.Size(223, 26);
            this.menuQuanLyTaiKhoan.Text = "Quản lý Tài khoản";
            this.menuQuanLyTaiKhoan.Click += new System.EventHandler(this.menuQuanLyTaiKhoan_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 85);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1383, 628);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlHeader.BackgroundImage")));
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 25);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1383, 60);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(28)))), ((int)(((byte)(48)))));
            this.lblTitle.Location = new System.Drawing.Point(502, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(348, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "| HỆ THỐNG QUẢN LÝ RESORT |";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser,
            this.lblResort});
            this.statusStrip1.Location = new System.Drawing.Point(0, 713);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1383, 22);
            this.statusStrip1.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(56, 17);
            this.lblUser.Text = "User: ...";
            // 
            // lblResort
            // 
            this.lblResort.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblResort.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblResort.Name = "lblResort";
            this.lblResort.Size = new System.Drawing.Size(70, 17);
            this.lblResort.Text = "Resort: ...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Goldenrod;
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1383, 25);
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
            this.menuTraCuuKhachHang,
            this.menuNhanVien,
            this.menuLoaiNhanVien,
            this.menuChiNhanh,
            this.menuQuanLyKhuyenMai,
            this.menuQuanLyLoaiThanhToan,
            this.menuQuanLyDoThatLac,
            this.menuQuanLyGoiSuKien,
            this.menuQuanLyKhieuNai,
            this.menuQuanLyVoucher});
            this.menuQuanLy.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuQuanLy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(36)))), ((int)(((byte)(70)))));
            this.menuQuanLy.Name = "menuQuanLy";
            this.menuQuanLy.Size = new System.Drawing.Size(72, 21);
            this.menuQuanLy.Text = "Quản lý";
            // 
            // menuPhong
            // 
            this.menuPhong.Name = "menuPhong";
            this.menuPhong.Size = new System.Drawing.Size(218, 22);
            this.menuPhong.Text = "Quản lý Phòng";
            this.menuPhong.Click += new System.EventHandler(this.menuQuanLyPhong_Click);
            // 
            // menuLoaiPhong
            // 
            this.menuLoaiPhong.Name = "menuLoaiPhong";
            this.menuLoaiPhong.Size = new System.Drawing.Size(218, 22);
            this.menuLoaiPhong.Text = "Quản lý Loại Phòng";
            this.menuLoaiPhong.Click += new System.EventHandler(this.menuQuanLyLoaiPhong_Click);
            // 
            // menuDichVu
            // 
            this.menuDichVu.Name = "menuDichVu";
            this.menuDichVu.Size = new System.Drawing.Size(218, 22);
            this.menuDichVu.Text = "Quản lý Dịch vụ";
            this.menuDichVu.Click += new System.EventHandler(this.menuQuanLyDichVu_Click);
            // 
            // menuKhachHang
            // 
            this.menuKhachHang.Name = "menuKhachHang";
            this.menuKhachHang.Size = new System.Drawing.Size(218, 22);
            this.menuKhachHang.Text = "Quản lý Khách hàng";
            this.menuKhachHang.Click += new System.EventHandler(this.menuQuanLyKhachHang_Click);
            // 
            // menuLoaiKhachHang
            // 
            this.menuLoaiKhachHang.Name = "menuLoaiKhachHang";
            this.menuLoaiKhachHang.Size = new System.Drawing.Size(218, 22);
            this.menuLoaiKhachHang.Text = "Quản lý Loại KH";
            this.menuLoaiKhachHang.Click += new System.EventHandler(this.menuQuanLyLoaiKhachHang_Click);
            // 
            // menuTraCuuKhachHang
            // 
            this.menuTraCuuKhachHang.Name = "menuTraCuuKhachHang";
            this.menuTraCuuKhachHang.Size = new System.Drawing.Size(218, 22);
            this.menuTraCuuKhachHang.Text = "Tra cứu Khách Hàng";
            this.menuTraCuuKhachHang.Click += new System.EventHandler(this.menuTraCuuKhachHang_Click);
            // 
            // menuNhanVien
            // 
            this.menuNhanVien.Name = "menuNhanVien";
            this.menuNhanVien.Size = new System.Drawing.Size(218, 22);
            this.menuNhanVien.Text = "Quản lý Nhân viên";
            this.menuNhanVien.Click += new System.EventHandler(this.menuQuanLyNhanVien_Click);
            // 
            // menuLoaiNhanVien
            // 
            this.menuLoaiNhanVien.Name = "menuLoaiNhanVien";
            this.menuLoaiNhanVien.Size = new System.Drawing.Size(218, 22);
            this.menuLoaiNhanVien.Text = "Quản lý Loại NV";
            this.menuLoaiNhanVien.Click += new System.EventHandler(this.menuQuanLyLoaiNhanVien_Click);
            // 
            // menuChiNhanh
            // 
            this.menuChiNhanh.Name = "menuChiNhanh";
            this.menuChiNhanh.Size = new System.Drawing.Size(218, 22);
            this.menuChiNhanh.Text = "Quản lý Chi nhánh";
            this.menuChiNhanh.Click += new System.EventHandler(this.menuQuanLyChiNhanh_Click);
            // 
            // menuQuanLyKhuyenMai
            // 
            this.menuQuanLyKhuyenMai.Name = "menuQuanLyKhuyenMai";
            this.menuQuanLyKhuyenMai.Size = new System.Drawing.Size(218, 22);
            this.menuQuanLyKhuyenMai.Text = "Quản lý Khuyến mãi";
            this.menuQuanLyKhuyenMai.Click += new System.EventHandler(this.menuQuanLyKhuyenMai_Click);
            // 
            // menuQuanLyLoaiThanhToan
            // 
            this.menuQuanLyLoaiThanhToan.Name = "menuQuanLyLoaiThanhToan";
            this.menuQuanLyLoaiThanhToan.Size = new System.Drawing.Size(218, 22);
            this.menuQuanLyLoaiThanhToan.Text = "Quản lý Loại TT";
            this.menuQuanLyLoaiThanhToan.Click += new System.EventHandler(this.menuQuanLyLoaiThanhToan_Click);
            // 
            // menuQuanLyDoThatLac
            // 
            this.menuQuanLyDoThatLac.Name = "menuQuanLyDoThatLac";
            this.menuQuanLyDoThatLac.Size = new System.Drawing.Size(218, 22);
            this.menuQuanLyDoThatLac.Text = "Quản lý Đồ Thất Lạc";
            this.menuQuanLyDoThatLac.Click += new System.EventHandler(this.menuQuanLyDoThatLac_Click);
            // 
            // menuQuanLyGoiSuKien
            // 
            this.menuQuanLyGoiSuKien.Name = "menuQuanLyGoiSuKien";
            this.menuQuanLyGoiSuKien.Size = new System.Drawing.Size(218, 22);
            this.menuQuanLyGoiSuKien.Text = "Quản lý Gói Sự Kiện";
            this.menuQuanLyGoiSuKien.Click += new System.EventHandler(this.menuQuanLyGoiSuKien_Click);
            // 
            // menuQuanLyKhieuNai
            // 
            this.menuQuanLyKhieuNai.Name = "menuQuanLyKhieuNai";
            this.menuQuanLyKhieuNai.Size = new System.Drawing.Size(218, 22);
            this.menuQuanLyKhieuNai.Text = "Quản lý Khiếu nại";
            this.menuQuanLyKhieuNai.Click += new System.EventHandler(this.menuQuanLyKhieuNai_Click);
            // 
            // menuQuanLyVoucher
            // 
            this.menuQuanLyVoucher.Name = "menuQuanLyVoucher";
            this.menuQuanLyVoucher.Size = new System.Drawing.Size(218, 22);
            this.menuQuanLyVoucher.Text = "Quản lý Voucher";
            this.menuQuanLyVoucher.Click += new System.EventHandler(this.menuQuanLyVoucher_Click);
            // 
            // menuDatPhong
            // 
            this.menuDatPhong.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDatPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(36)))), ((int)(((byte)(70)))));
            this.menuDatPhong.Name = "menuDatPhong";
            this.menuDatPhong.Size = new System.Drawing.Size(91, 21);
            this.menuDatPhong.Text = "Đặt phòng";
            this.menuDatPhong.Click += new System.EventHandler(this.menuDatPhong_Click);
            // 
            // menuDatSuKien
            // 
            this.menuDatSuKien.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDatSuKien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(36)))), ((int)(((byte)(70)))));
            this.menuDatSuKien.Name = "menuDatSuKien";
            this.menuDatSuKien.Size = new System.Drawing.Size(99, 21);
            this.menuDatSuKien.Text = "Đặt sự kiện";
            this.menuDatSuKien.Click += new System.EventHandler(this.menuDatSuKien_Click);
            // 
            // menuHoaDon
            // 
            this.menuHoaDon.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(36)))), ((int)(((byte)(70)))));
            this.menuHoaDon.Name = "menuHoaDon";
            this.menuHoaDon.Size = new System.Drawing.Size(79, 21);
            this.menuHoaDon.Text = "Hóa đơn";
            this.menuHoaDon.Click += new System.EventHandler(this.menuHoaDon_Click);
            // 
            // menuThanhToan
            // 
            this.menuThanhToan.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(36)))), ((int)(((byte)(70)))));
            this.menuThanhToan.Name = "menuThanhToan";
            this.menuThanhToan.Size = new System.Drawing.Size(99, 21);
            this.menuThanhToan.Text = "Thanh toán";
            this.menuThanhToan.Click += new System.EventHandler(this.menuThanhToan_Click);
            // 
            // menuThanhToanSuKien
            // 
            this.menuThanhToanSuKien.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuThanhToanSuKien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(36)))), ((int)(((byte)(70)))));
            this.menuThanhToanSuKien.Name = "menuThanhToanSuKien";
            this.menuThanhToanSuKien.Size = new System.Drawing.Size(154, 21);
            this.menuThanhToanSuKien.Text = "Thanh toán sự kiện";
            this.menuThanhToanSuKien.Click += new System.EventHandler(this.menuThanhToanSuKien_Click);
            // 
            // menuThongKe
            // 
            this.menuThongKe.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(36)))), ((int)(((byte)(70)))));
            this.menuThongKe.Name = "menuThongKe";
            this.menuThongKe.Size = new System.Drawing.Size(85, 21);
            this.menuThongKe.Text = "Thống kê";
            this.menuThongKe.Click += new System.EventHandler(this.menuThongKe_Click);
            // 
            // menuHeThong
            // 
            this.menuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDangXuat,
            this.menuThoat});
            this.menuHeThong.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuHeThong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(36)))), ((int)(((byte)(70)))));
            this.menuHeThong.Name = "menuHeThong";
            this.menuHeThong.Size = new System.Drawing.Size(82, 21);
            this.menuHeThong.Text = "Hệ thống";
            // 
            // menuDangXuat
            // 
            this.menuDangXuat.Name = "menuDangXuat";
            this.menuDangXuat.Size = new System.Drawing.Size(148, 22);
            this.menuDangXuat.Text = "Đăng xuất";
            this.menuDangXuat.Click += new System.EventHandler(this.menuDangXuat_Click);
            // 
            // menuThoat
            // 
            this.menuThoat.Name = "menuThoat";
            this.menuThoat.Size = new System.Drawing.Size(148, 22);
            this.menuThoat.Text = "Thoát";
            this.menuThoat.Click += new System.EventHandler(this.menuThoat_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 735);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Resort";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

