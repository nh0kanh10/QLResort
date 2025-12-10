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
        private System.Windows.Forms.Button btnThoat;
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTimMaNV = new System.Windows.Forms.Label();
            this.txtTimMaNV = new System.Windows.Forms.TextBox();
            this.lblTimTenDangNhap = new System.Windows.Forms.Label();
            this.txtTimTenDangNhap = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lvAccounts = new System.Windows.Forms.ListView();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaTK = new System.Windows.Forms.Label();
            this.txtMaTK = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lblMatKhauMoi = new System.Windows.Forms.Label();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbTimKiem.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(333, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản Lý Tài Khoản Nhân Viên";
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.btnRefresh);
            this.gbTimKiem.Controls.Add(this.lblTimMaNV);
            this.gbTimKiem.Controls.Add(this.txtTimMaNV);
            this.gbTimKiem.Controls.Add(this.lblTimTenDangNhap);
            this.gbTimKiem.Controls.Add(this.txtTimTenDangNhap);
            this.gbTimKiem.Controls.Add(this.btnTimKiem);
            this.gbTimKiem.Location = new System.Drawing.Point(20, 50);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(1200, 67);
            this.gbTimKiem.TabIndex = 1;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm";
            // 
            // lblTimMaNV
            // 
            this.lblTimMaNV.Location = new System.Drawing.Point(20, 22);
            this.lblTimMaNV.Name = "lblTimMaNV";
            this.lblTimMaNV.Size = new System.Drawing.Size(74, 23);
            this.lblTimMaNV.TabIndex = 0;
            this.lblTimMaNV.Text = "Mã NV:";
            // 
            // txtTimMaNV
            // 
            this.txtTimMaNV.Location = new System.Drawing.Point(100, 22);
            this.txtTimMaNV.Name = "txtTimMaNV";
            this.txtTimMaNV.Size = new System.Drawing.Size(150, 20);
            this.txtTimMaNV.TabIndex = 1;
            // 
            // lblTimTenDangNhap
            // 
            this.lblTimTenDangNhap.Location = new System.Drawing.Point(270, 25);
            this.lblTimTenDangNhap.Name = "lblTimTenDangNhap";
            this.lblTimTenDangNhap.Size = new System.Drawing.Size(100, 23);
            this.lblTimTenDangNhap.TabIndex = 2;
            this.lblTimTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // txtTimTenDangNhap
            // 
            this.txtTimTenDangNhap.Location = new System.Drawing.Point(380, 22);
            this.txtTimTenDangNhap.Name = "txtTimTenDangNhap";
            this.txtTimTenDangNhap.Size = new System.Drawing.Size(200, 20);
            this.txtTimTenDangNhap.TabIndex = 3;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(600, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(72, 22);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lvAccounts
            // 
            this.lvAccounts.FullRowSelect = true;
            this.lvAccounts.GridLines = true;
            this.lvAccounts.HideSelection = false;
            this.lvAccounts.Location = new System.Drawing.Point(20, 140);
            this.lvAccounts.Name = "lvAccounts";
            this.lvAccounts.Size = new System.Drawing.Size(800, 345);
            this.lvAccounts.TabIndex = 2;
            this.lvAccounts.UseCompatibleStateImageBehavior = false;
            this.lvAccounts.View = System.Windows.Forms.View.Details;
            this.lvAccounts.SelectedIndexChanged += new System.EventHandler(this.lvAccounts_SelectedIndexChanged);
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.lblMaTK);
            this.gbThongTin.Controls.Add(this.txtMaTK);
            this.gbThongTin.Controls.Add(this.lblMaNV);
            this.gbThongTin.Controls.Add(this.cbMaNV);
            this.gbThongTin.Controls.Add(this.lblTenDangNhap);
            this.gbThongTin.Controls.Add(this.txtTenDangNhap);
            this.gbThongTin.Controls.Add(this.lblMatKhau);
            this.gbThongTin.Controls.Add(this.txtMatKhau);
            this.gbThongTin.Controls.Add(this.lblMatKhauMoi);
            this.gbThongTin.Controls.Add(this.txtMatKhauMoi);
            this.gbThongTin.Controls.Add(this.lblRole);
            this.gbThongTin.Controls.Add(this.cbRole);
            this.gbThongTin.Controls.Add(this.cbIsActive);
            this.gbThongTin.Location = new System.Drawing.Point(840, 140);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(380, 245);
            this.gbThongTin.TabIndex = 3;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin tài khoản";
            // 
            // lblMaTK
            // 
            this.lblMaTK.Location = new System.Drawing.Point(20, 25);
            this.lblMaTK.Name = "lblMaTK";
            this.lblMaTK.Size = new System.Drawing.Size(100, 23);
            this.lblMaTK.TabIndex = 0;
            this.lblMaTK.Text = "Mã TK:";
            // 
            // txtMaTK
            // 
            this.txtMaTK.Enabled = false;
            this.txtMaTK.Location = new System.Drawing.Point(120, 22);
            this.txtMaTK.Name = "txtMaTK";
            this.txtMaTK.Size = new System.Drawing.Size(240, 20);
            this.txtMaTK.TabIndex = 1;
            // 
            // lblMaNV
            // 
            this.lblMaNV.Location = new System.Drawing.Point(20, 55);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(100, 23);
            this.lblMaNV.TabIndex = 2;
            this.lblMaNV.Text = "Nhân viên:";
            // 
            // cbMaNV
            // 
            this.cbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaNV.Location = new System.Drawing.Point(120, 52);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(240, 21);
            this.cbMaNV.TabIndex = 3;
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.Location = new System.Drawing.Point(20, 85);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(100, 23);
            this.lblTenDangNhap.TabIndex = 4;
            this.lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(120, 82);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(240, 20);
            this.txtTenDangNhap.TabIndex = 5;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Location = new System.Drawing.Point(20, 115);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(100, 23);
            this.lblMatKhau.TabIndex = 6;
            this.lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Enabled = false;
            this.txtMatKhau.Location = new System.Drawing.Point(120, 112);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(240, 20);
            this.txtMatKhau.TabIndex = 7;
            // 
            // lblMatKhauMoi
            // 
            this.lblMatKhauMoi.Location = new System.Drawing.Point(20, 145);
            this.lblMatKhauMoi.Name = "lblMatKhauMoi";
            this.lblMatKhauMoi.Size = new System.Drawing.Size(100, 23);
            this.lblMatKhauMoi.TabIndex = 8;
            this.lblMatKhauMoi.Text = "Mật khẩu mới:";
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Location = new System.Drawing.Point(120, 142);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.PasswordChar = '*';
            this.txtMatKhauMoi.Size = new System.Drawing.Size(240, 20);
            this.txtMatKhauMoi.TabIndex = 9;
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(20, 175);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(100, 23);
            this.lblRole.TabIndex = 10;
            this.lblRole.Text = "Vai trò:";
            // 
            // cbRole
            // 
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.Items.AddRange(new object[] {
            "NhanVien",
            "QuanLy",
            "Admin"});
            this.cbRole.Location = new System.Drawing.Point(120, 172);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(240, 21);
            this.cbRole.TabIndex = 11;
            // 
            // cbIsActive
            // 
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.Location = new System.Drawing.Point(20, 205);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(104, 24);
            this.cbIsActive.TabIndex = 12;
            this.cbIsActive.Text = "Hoạt động";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(840, 391);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(980, 391);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(1120, 391);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(840, 450);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 35);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(687, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(72, 22);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmAccount
            // 
            this.ClientSize = new System.Drawing.Size(1242, 518);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbTimKiem);
            this.Controls.Add(this.lvAccounts);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Name = "frmAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Tài Khoản";
            this.Load += new System.EventHandler(this.frmAccount_Load);
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btnRefresh;
    }
}

