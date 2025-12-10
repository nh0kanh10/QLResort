using System.ComponentModel;
using System.Windows.Forms;

namespace QLResort.GUI
{
    partial class frmAccount
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.Label lblTimMaNV;
        private System.Windows.Forms.TextBox txtTimMaNV;
        private System.Windows.Forms.Label lblTimTenDangNhap;
        private System.Windows.Forms.TextBox txtTimTenDangNhap;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ListView lvAccounts;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblMaTK;
        private System.Windows.Forms.TextBox txtMaTK;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblMatKhauMoi;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ErrorProvider errorProvider1;

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
            // Title
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTitle.Text = "🔐 Quản Lý Tài Khoản Nhân Viên";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 215, 0);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 10);

            // GroupBox Tìm kiếm
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.gbTimKiem.Text = "Tìm kiếm";
            this.gbTimKiem.Location = new System.Drawing.Point(20, 50);
            this.gbTimKiem.Size = new System.Drawing.Size(1200, 80);

            this.lblTimMaNV = new System.Windows.Forms.Label();
            this.lblTimMaNV.Text = "Mã NV:";
            this.lblTimMaNV.Location = new System.Drawing.Point(20, 25);
            this.txtTimMaNV = new System.Windows.Forms.TextBox();
            this.txtTimMaNV.Location = new System.Drawing.Point(100, 22);
            this.txtTimMaNV.Size = new System.Drawing.Size(150, 20);

            this.lblTimTenDangNhap = new System.Windows.Forms.Label();
            this.lblTimTenDangNhap.Text = "Tên đăng nhập:";
            this.lblTimTenDangNhap.Location = new System.Drawing.Point(270, 25);
            this.txtTimTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtTimTenDangNhap.Location = new System.Drawing.Point(380, 22);
            this.txtTimTenDangNhap.Size = new System.Drawing.Size(200, 20);

            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Location = new System.Drawing.Point(600, 20);
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            this.gbTimKiem.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTimMaNV, this.txtTimMaNV, this.lblTimTenDangNhap, this.txtTimTenDangNhap, this.btnTimKiem
            });

            // ListView
            this.lvAccounts = new System.Windows.Forms.ListView();
            this.lvAccounts.Location = new System.Drawing.Point(20, 140);
            this.lvAccounts.Size = new System.Drawing.Size(800, 400);
            this.lvAccounts.FullRowSelect = true;
            this.lvAccounts.GridLines = true;
            this.lvAccounts.View = System.Windows.Forms.View.Details;
            this.lvAccounts.Columns.Add("Mã TK", 100);
            this.lvAccounts.Columns.Add("Mã NV", 100);
            this.lvAccounts.Columns.Add("Tên NV", 200);
            this.lvAccounts.Columns.Add("Tên đăng nhập", 200);
            this.lvAccounts.Columns.Add("Mật khẩu", 100);
            this.lvAccounts.Columns.Add("Trạng thái", 100);
            this.lvAccounts.SelectedIndexChanged += new System.EventHandler(this.lvAccounts_SelectedIndexChanged);

            // GroupBox Thông tin
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.gbThongTin.Text = "Thông tin tài khoản";
            this.gbThongTin.Location = new System.Drawing.Point(840, 140);
            this.gbThongTin.Size = new System.Drawing.Size(380, 400);

            this.lblMaTK = new System.Windows.Forms.Label();
            this.lblMaTK.Text = "Mã TK:";
            this.lblMaTK.Location = new System.Drawing.Point(20, 25);
            this.txtMaTK = new System.Windows.Forms.TextBox();
            this.txtMaTK.Enabled = false;
            this.txtMaTK.Location = new System.Drawing.Point(120, 22);
            this.txtMaTK.Size = new System.Drawing.Size(150, 20);

            this.lblMaNV = new System.Windows.Forms.Label();
            this.lblMaNV.Text = "Nhân viên:";
            this.lblMaNV.Location = new System.Drawing.Point(20, 55);
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.cbMaNV.Location = new System.Drawing.Point(120, 52);
            this.cbMaNV.Size = new System.Drawing.Size(240, 21);
            this.cbMaNV.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.lblTenDangNhap.Text = "Tên đăng nhập:";
            this.lblTenDangNhap.Location = new System.Drawing.Point(20, 85);
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtTenDangNhap.Location = new System.Drawing.Point(120, 82);
            this.txtTenDangNhap.Size = new System.Drawing.Size(240, 20);

            this.lblMatKhau = new System.Windows.Forms.Label();
            this.lblMatKhau.Text = "Mật khẩu:";
            this.lblMatKhau.Location = new System.Drawing.Point(20, 115);
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtMatKhau.Location = new System.Drawing.Point(120, 112);
            this.txtMatKhau.Size = new System.Drawing.Size(240, 20);
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Enabled = false;

            this.lblMatKhauMoi = new System.Windows.Forms.Label();
            this.lblMatKhauMoi.Text = "Mật khẩu mới:";
            this.lblMatKhauMoi.Location = new System.Drawing.Point(20, 145);
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.txtMatKhauMoi.Location = new System.Drawing.Point(120, 142);
            this.txtMatKhauMoi.Size = new System.Drawing.Size(240, 20);
            this.txtMatKhauMoi.PasswordChar = '*';

            this.lblRole = new System.Windows.Forms.Label();
            this.lblRole.Text = "Vai trò:";
            this.lblRole.Location = new System.Drawing.Point(20, 175);
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.cbRole.Location = new System.Drawing.Point(120, 172);
            this.cbRole.Size = new System.Drawing.Size(240, 21);
            this.cbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbRole.Items.AddRange(new object[] { "NhanVien", "QuanLy", "Admin" });

            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.cbIsActive.Text = "Hoạt động";
            this.cbIsActive.Location = new System.Drawing.Point(20, 205);
            this.cbIsActive.Checked = true;

            this.gbThongTin.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaTK, this.txtMaTK, this.lblMaNV, this.cbMaNV,
                this.lblTenDangNhap, this.txtTenDangNhap, this.lblMatKhau, this.txtMatKhau,
                this.lblMatKhauMoi, this.txtMatKhauMoi, this.lblRole, this.cbRole, this.cbIsActive
            });

            // Buttons
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThem.Text = "Thêm";
            this.btnThem.Location = new System.Drawing.Point(840, 550);
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua = new System.Windows.Forms.Button();
            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new System.Drawing.Point(950, 550);
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new System.Drawing.Point(1060, 550);
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnReset = new System.Windows.Forms.Button();
            this.btnReset.Text = "Làm mới";
            this.btnReset.Location = new System.Drawing.Point(1170, 550);
            this.btnReset.Size = new System.Drawing.Size(100, 35);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Text = "Quản Lý Tài Khoản";
            this.Size = new System.Drawing.Size(1300, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAccount_Load);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle,
                this.gbTimKiem,
                this.lvAccounts,
                this.gbThongTin,
                this.btnThem, this.btnSua, this.btnXoa, this.btnReset
            });

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        

        
    }
}

