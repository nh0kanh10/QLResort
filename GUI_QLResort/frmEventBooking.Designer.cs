using System.ComponentModel;
using System.Windows.Forms;

namespace GUI_QLResort
{
    partial class frmEventBooking
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbKhachHang;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnChonKhachHang;
        private System.Windows.Forms.GroupBox gbThongTinSuKien;
        private System.Windows.Forms.Label lBUSoaiSuKien;
        private System.Windows.Forms.ComboBox cbLoaiSuKien;
        private System.Windows.Forms.Label lblMaCN;
        private System.Windows.Forms.ComboBox cbMaCN;
        private System.Windows.Forms.Label lblNgayBD;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.Label lblNgayKT;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.Label lblTongKhach;
        private System.Windows.Forms.NumericUpDown txtTongKhach;
        private System.Windows.Forms.GroupBox gbGoiSuKien;
        private System.Windows.Forms.ListView lvGoiSuKien;
        private System.Windows.Forms.Label lblMaGoiSK;
        private System.Windows.Forms.TextBox txtMaGoiSK;
        private System.Windows.Forms.Label lblTenGoiSK;
        private System.Windows.Forms.TextBox txtTenGoiSK;
        private System.Windows.Forms.Label lblGiaCoBan;
        private System.Windows.Forms.TextBox txtGiaCoBan;
        private System.Windows.Forms.Label lblDichVuKemTheo;
        private System.Windows.Forms.TextBox txtDichVuKemTheo;
        private System.Windows.Forms.Button btnTaoGoiCustom;
        private System.Windows.Forms.GroupBox gbThanhToan;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblDatCoc;
        private System.Windows.Forms.TextBox txtDatCoc;
        private System.Windows.Forms.Label lblConLai;
        private System.Windows.Forms.TextBox txtConLai;
        private System.Windows.Forms.Label lblPhuongThucThanhToan;
        private System.Windows.Forms.ComboBox cbPhuongThucThanhToan;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
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
            this.gbKhachHang = new System.Windows.Forms.GroupBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnChonKhachHang = new System.Windows.Forms.Button();
            this.gbThongTinSuKien = new System.Windows.Forms.GroupBox();
            this.lBUSoaiSuKien = new System.Windows.Forms.Label();
            this.cbLoaiSuKien = new System.Windows.Forms.ComboBox();
            this.lblMaCN = new System.Windows.Forms.Label();
            this.cbMaCN = new System.Windows.Forms.ComboBox();
            this.lblNgayBD = new System.Windows.Forms.Label();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKT = new System.Windows.Forms.Label();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.lblTongKhach = new System.Windows.Forms.Label();
            this.txtTongKhach = new System.Windows.Forms.NumericUpDown();
            this.gbGoiSuKien = new System.Windows.Forms.GroupBox();
            this.lvGoiSuKien = new System.Windows.Forms.ListView();
            this.lblMaGoiSK = new System.Windows.Forms.Label();
            this.txtMaGoiSK = new System.Windows.Forms.TextBox();
            this.lblTenGoiSK = new System.Windows.Forms.Label();
            this.txtTenGoiSK = new System.Windows.Forms.TextBox();
            this.lblGiaCoBan = new System.Windows.Forms.Label();
            this.txtGiaCoBan = new System.Windows.Forms.TextBox();
            this.lblDichVuKemTheo = new System.Windows.Forms.Label();
            this.txtDichVuKemTheo = new System.Windows.Forms.TextBox();
            this.btnTaoGoiCustom = new System.Windows.Forms.Button();
            this.gbThanhToan = new System.Windows.Forms.GroupBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblDatCoc = new System.Windows.Forms.Label();
            this.txtDatCoc = new System.Windows.Forms.TextBox();
            this.lblConLai = new System.Windows.Forms.Label();
            this.txtConLai = new System.Windows.Forms.TextBox();
            this.lblPhuongThucThanhToan = new System.Windows.Forms.Label();
            this.cbPhuongThucThanhToan = new System.Windows.Forms.ComboBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);

            this.gbKhachHang.SuspendLayout();
            this.gbThongTinSuKien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTongKhach)).BeginInit();
            this.gbGoiSuKien.SuspendLayout();
            this.gbThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(188, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "✨ ĐẶT SỰ KIỆN";

            // 
            // gbKhachHang
            // 
            this.gbKhachHang.Controls.Add(this.btnChonKhachHang);
            this.gbKhachHang.Controls.Add(this.txtEmail);
            this.gbKhachHang.Controls.Add(this.lblEmail);
            this.gbKhachHang.Controls.Add(this.txtSDT);
            this.gbKhachHang.Controls.Add(this.lblSDT);
            this.gbKhachHang.Controls.Add(this.txtTenKH);
            this.gbKhachHang.Controls.Add(this.lblTenKH);
            this.gbKhachHang.Controls.Add(this.txtMaKH);
            this.gbKhachHang.Controls.Add(this.lblMaKH);
            this.gbKhachHang.Location = new System.Drawing.Point(20, 50);
            this.gbKhachHang.Name = "gbKhachHang";
            this.gbKhachHang.Size = new System.Drawing.Size(600, 120);
            this.gbKhachHang.TabIndex = 1;
            this.gbKhachHang.TabStop = false;
            this.gbKhachHang.Text = "Thông tin khách hàng";

            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(20, 25);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(43, 13);
            this.lblMaKH.TabIndex = 0;
            this.lblMaKH.Text = "Mã KH:";

            // 
            // txtMaKH
            // 
            this.txtMaKH.Enabled = false;
            this.txtMaKH.Location = new System.Drawing.Point(100, 22);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(150, 20);
            this.txtMaKH.TabIndex = 1;

            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(270, 25);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(47, 13);
            this.lblTenKH.TabIndex = 2;
            this.lblTenKH.Text = "Tên KH:";

            // 
            // txtTenKH
            // 
            this.txtTenKH.Enabled = false;
            this.txtTenKH.Location = new System.Drawing.Point(340, 22);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(200, 20);
            this.txtTenKH.TabIndex = 3;

            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(20, 55);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(32, 13);
            this.lblSDT.TabIndex = 4;
            this.lblSDT.Text = "SĐT:";

            // 
            // txtSDT
            // 
            this.txtSDT.Enabled = false;
            this.txtSDT.Location = new System.Drawing.Point(100, 52);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(150, 20);
            this.txtSDT.TabIndex = 5;

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(270, 55);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";

            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(340, 52);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.txtEmail.TabIndex = 7;

            // 
            // btnChonKhachHang
            // 
            this.btnChonKhachHang.Location = new System.Drawing.Point(100, 80);
            this.btnChonKhachHang.Name = "btnChonKhachHang";
            this.btnChonKhachHang.Size = new System.Drawing.Size(150, 30);
            this.btnChonKhachHang.TabIndex = 8;
            this.btnChonKhachHang.Text = "Chọn khách hàng";
            this.btnChonKhachHang.UseVisualStyleBackColor = true;
            this.btnChonKhachHang.Click += new System.EventHandler(this.btnChonKhachHang_Click);

            // 
            // gbThongTinSuKien
            // 
            this.gbThongTinSuKien.Controls.Add(this.txtTongKhach);
            this.gbThongTinSuKien.Controls.Add(this.lblTongKhach);
            this.gbThongTinSuKien.Controls.Add(this.dtpNgayKT);
            this.gbThongTinSuKien.Controls.Add(this.lblNgayKT);
            this.gbThongTinSuKien.Controls.Add(this.dtpNgayBD);
            this.gbThongTinSuKien.Controls.Add(this.lblNgayBD);
            this.gbThongTinSuKien.Controls.Add(this.cbMaCN);
            this.gbThongTinSuKien.Controls.Add(this.lblMaCN);
            this.gbThongTinSuKien.Controls.Add(this.cbLoaiSuKien);
            this.gbThongTinSuKien.Controls.Add(this.lBUSoaiSuKien);
            this.gbThongTinSuKien.Location = new System.Drawing.Point(20, 180);
            this.gbThongTinSuKien.Name = "gbThongTinSuKien";
            this.gbThongTinSuKien.Size = new System.Drawing.Size(600, 120);
            this.gbThongTinSuKien.TabIndex = 2;
            this.gbThongTinSuKien.TabStop = false;
            this.gbThongTinSuKien.Text = "Thông tin sự kiện";

            // 
            // lBUSoaiSuKien
            // 
            this.lBUSoaiSuKien.AutoSize = true;
            this.lBUSoaiSuKien.Location = new System.Drawing.Point(20, 25);
            this.lBUSoaiSuKien.Name = "lBUSoaiSuKien";
            this.lBUSoaiSuKien.Size = new System.Drawing.Size(67, 13);
            this.lBUSoaiSuKien.TabIndex = 0;
            this.lBUSoaiSuKien.Text = "Loại sự kiện:";

            // 
            // cbLoaiSuKien
            // 
            this.cbLoaiSuKien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiSuKien.FormattingEnabled = true;
            this.cbLoaiSuKien.Location = new System.Drawing.Point(120, 22);
            this.cbLoaiSuKien.Name = "cbLoaiSuKien";
            this.cbLoaiSuKien.Size = new System.Drawing.Size(200, 21);
            this.cbLoaiSuKien.TabIndex = 1;
            this.cbLoaiSuKien.SelectedIndexChanged += new System.EventHandler(this.cbLoaiSuKien_SelectedIndexChanged);

            // 
            // lblMaCN
            // 
            this.lblMaCN.AutoSize = true;
            this.lblMaCN.Location = new System.Drawing.Point(340, 25);
            this.lblMaCN.Name = "lblMaCN";
            this.lblMaCN.Size = new System.Drawing.Size(58, 13);
            this.lblMaCN.TabIndex = 2;
            this.lblMaCN.Text = "Chi nhánh:";

            // 
            // cbMaCN
            // 
            this.cbMaCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaCN.FormattingEnabled = true;
            this.cbMaCN.Location = new System.Drawing.Point(420, 22);
            this.cbMaCN.Name = "cbMaCN";
            this.cbMaCN.Size = new System.Drawing.Size(150, 21);
            this.cbMaCN.TabIndex = 3;

            // 
            // lblNgayBD
            // 
            this.lblNgayBD.AutoSize = true;
            this.lblNgayBD.Location = new System.Drawing.Point(20, 55);
            this.lblNgayBD.Name = "lblNgayBD";
            this.lblNgayBD.Size = new System.Drawing.Size(75, 13);
            this.lblNgayBD.TabIndex = 4;
            this.lblNgayBD.Text = "Ngày bắt đầu:";

            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Location = new System.Drawing.Point(120, 52);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayBD.TabIndex = 5;
            this.dtpNgayBD.ValueChanged += new System.EventHandler(this.dtpNgayBD_ValueChanged);
            
            // 
            // lblNgayKT
            // 
            this.lblNgayKT.AutoSize = true;
            this.lblNgayKT.Location = new System.Drawing.Point(340, 55);
            this.lblNgayKT.Name = "lblNgayKT";
            this.lblNgayKT.Size = new System.Drawing.Size(77, 13);
            this.lblNgayKT.TabIndex = 6;
            this.lblNgayKT.Text = "Ngày kết thúc:";

            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.Location = new System.Drawing.Point(420, 52);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayKT.TabIndex = 7;
            this.dtpNgayKT.ValueChanged += new System.EventHandler(this.dtpNgayKT_ValueChanged);

            // 
            // lblTongKhach
            // 
            this.lblTongKhach.AutoSize = true;
            this.lblTongKhach.Location = new System.Drawing.Point(20, 85);
            this.lblTongKhach.Name = "lblTongKhach";
            this.lblTongKhach.Size = new System.Drawing.Size(81, 13);
            this.lblTongKhach.TabIndex = 8;
            this.lblTongKhach.Text = "Tổng số khách:";

            // 
            // txtTongKhach
            // 
            this.txtTongKhach.Location = new System.Drawing.Point(120, 82);
            this.txtTongKhach.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtTongKhach.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTongKhach.Name = "txtTongKhach";
            this.txtTongKhach.Size = new System.Drawing.Size(100, 20);
            this.txtTongKhach.TabIndex = 9;
            this.txtTongKhach.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTongKhach.ValueChanged += new System.EventHandler(this.txtTongKhach_ValueChanged);

            // 
            // gbGoiSuKien
            // 
            this.gbGoiSuKien.Controls.Add(this.btnTaoGoiCustom);
            this.gbGoiSuKien.Controls.Add(this.txtDichVuKemTheo);
            this.gbGoiSuKien.Controls.Add(this.lblDichVuKemTheo);
            this.gbGoiSuKien.Controls.Add(this.txtGiaCoBan);
            this.gbGoiSuKien.Controls.Add(this.lblGiaCoBan);
            this.gbGoiSuKien.Controls.Add(this.txtTenGoiSK);
            this.gbGoiSuKien.Controls.Add(this.lblTenGoiSK);
            this.gbGoiSuKien.Controls.Add(this.txtMaGoiSK);
            this.gbGoiSuKien.Controls.Add(this.lblMaGoiSK);
            this.gbGoiSuKien.Controls.Add(this.lvGoiSuKien);
            this.gbGoiSuKien.Location = new System.Drawing.Point(640, 50);
            this.gbGoiSuKien.Name = "gbGoiSuKien";
            this.gbGoiSuKien.Size = new System.Drawing.Size(600, 400);
            this.gbGoiSuKien.TabIndex = 3;
            this.gbGoiSuKien.TabStop = false;
            this.gbGoiSuKien.Text = "Chọn gói sự kiện";

            // 
            // lvGoiSuKien
            // 
            this.lvGoiSuKien.FullRowSelect = true;
            this.lvGoiSuKien.GridLines = true;
            this.lvGoiSuKien.HideSelection = false;
            this.lvGoiSuKien.Location = new System.Drawing.Point(20, 25);
            this.lvGoiSuKien.Name = "lvGoiSuKien";
            this.lvGoiSuKien.Size = new System.Drawing.Size(560, 150);
            this.lvGoiSuKien.TabIndex = 0;
            this.lvGoiSuKien.UseCompatibleStateImageBehavior = false;
            this.lvGoiSuKien.View = System.Windows.Forms.View.Details;
            this.lvGoiSuKien.Columns.Add("Mã gói", 80);
            this.lvGoiSuKien.Columns.Add("Tên gói", 200);
            this.lvGoiSuKien.Columns.Add("Giá", 120);
            this.lvGoiSuKien.Columns.Add("Khách min", 80);
            this.lvGoiSuKien.Columns.Add("Khách max", 100);
            this.lvGoiSuKien.Columns.Add("Loại", 80);
            this.lvGoiSuKien.SelectedIndexChanged += new System.EventHandler(this.lvGoiSuKien_SelectedIndexChanged);

            // 
            // lblMaGoiSK
            // 
            this.lblMaGoiSK.AutoSize = true;
            this.lblMaGoiSK.Location = new System.Drawing.Point(20, 185);
            this.lblMaGoiSK.Name = "lblMaGoiSK";
            this.lblMaGoiSK.Size = new System.Drawing.Size(42, 13);
            this.lblMaGoiSK.TabIndex = 1;
            this.lblMaGoiSK.Text = "Mã gói:";

            // 
            // txtMaGoiSK
            // 
            this.txtMaGoiSK.Enabled = false;
            this.txtMaGoiSK.Location = new System.Drawing.Point(100, 182);
            this.txtMaGoiSK.Name = "txtMaGoiSK";
            this.txtMaGoiSK.Size = new System.Drawing.Size(150, 20);
            this.txtMaGoiSK.TabIndex = 2;

            // 
            // lblTenGoiSK
            // 
            this.lblTenGoiSK.AutoSize = true;
            this.lblTenGoiSK.Location = new System.Drawing.Point(270, 185);
            this.lblTenGoiSK.Name = "lblTenGoiSK";
            this.lblTenGoiSK.Size = new System.Drawing.Size(46, 13);
            this.lblTenGoiSK.TabIndex = 3;
            this.lblTenGoiSK.Text = "Tên gói:";

            // 
            // txtTenGoiSK
            // 
            this.txtTenGoiSK.Enabled = false;
            this.txtTenGoiSK.Location = new System.Drawing.Point(340, 182);
            this.txtTenGoiSK.Name = "txtTenGoiSK";
            this.txtTenGoiSK.Size = new System.Drawing.Size(240, 20);
            this.txtTenGoiSK.TabIndex = 4;

            // 
            // lblGiaCoBan
            // 
            this.lblGiaCoBan.AutoSize = true;
            this.lblGiaCoBan.Location = new System.Drawing.Point(20, 215);
            this.lblGiaCoBan.Name = "lblGiaCoBan";
            this.lblGiaCoBan.Size = new System.Drawing.Size(60, 13);
            this.lblGiaCoBan.TabIndex = 5;
            this.lblGiaCoBan.Text = "Giá cơ bản:";

            // 
            // txtGiaCoBan
            // 
            this.txtGiaCoBan.Enabled = false;
            this.txtGiaCoBan.Location = new System.Drawing.Point(100, 212);
            this.txtGiaCoBan.Name = "txtGiaCoBan";
            this.txtGiaCoBan.Size = new System.Drawing.Size(200, 20);
            this.txtGiaCoBan.TabIndex = 6;

            // 
            // lblDichVuKemTheo
            // 
            this.lblDichVuKemTheo.AutoSize = true;
            this.lblDichVuKemTheo.Location = new System.Drawing.Point(20, 245);
            this.lblDichVuKemTheo.Name = "lblDichVuKemTheo";
            this.lblDichVuKemTheo.Size = new System.Drawing.Size(92, 13);
            this.lblDichVuKemTheo.TabIndex = 7;
            this.lblDichVuKemTheo.Text = "Dịch vụ kèm theo:";

            // 
            // txtDichVuKemTheo
            // 
            this.txtDichVuKemTheo.Enabled = false;
            this.txtDichVuKemTheo.Location = new System.Drawing.Point(120, 242);
            this.txtDichVuKemTheo.Multiline = true;
            this.txtDichVuKemTheo.Name = "txtDichVuKemTheo";
            this.txtDichVuKemTheo.Size = new System.Drawing.Size(460, 60);
            this.txtDichVuKemTheo.TabIndex = 8;

            // 
            // btnTaoGoiCustom
            // 
            this.btnTaoGoiCustom.Location = new System.Drawing.Point(420, 310);
            this.btnTaoGoiCustom.Name = "btnTaoGoiCustom";
            this.btnTaoGoiCustom.Size = new System.Drawing.Size(160, 35);
            this.btnTaoGoiCustom.TabIndex = 9;
            this.btnTaoGoiCustom.Text = "Tạo gói custom";
            this.btnTaoGoiCustom.UseVisualStyleBackColor = true;
            this.btnTaoGoiCustom.Click += new System.EventHandler(this.btnTaoGoiCustom_Click);

            // 
            // gbThanhToan
            // 
            this.gbThanhToan.Controls.Add(this.txtGhiChu);
            this.gbThanhToan.Controls.Add(this.lblGhiChu);
            this.gbThanhToan.Controls.Add(this.cbPhuongThucThanhToan);
            this.gbThanhToan.Controls.Add(this.lblPhuongThucThanhToan);
            this.gbThanhToan.Controls.Add(this.txtConLai);
            this.gbThanhToan.Controls.Add(this.lblConLai);
            this.gbThanhToan.Controls.Add(this.txtDatCoc);
            this.gbThanhToan.Controls.Add(this.lblDatCoc);
            this.gbThanhToan.Controls.Add(this.txtTongTien);
            this.gbThanhToan.Controls.Add(this.lblTongTien);
            this.gbThanhToan.Location = new System.Drawing.Point(20, 310);
            this.gbThanhToan.Name = "gbThanhToan";
            this.gbThanhToan.Size = new System.Drawing.Size(600, 140);
            this.gbThanhToan.TabIndex = 4;
            this.gbThanhToan.TabStop = false;
            this.gbThanhToan.Text = "Thanh toán";

            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(20, 25);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(55, 13);
            this.lblTongTien.TabIndex = 0;
            this.lblTongTien.Text = "Tổng tiền:";

            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(120, 22);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(200, 20);
            this.txtTongTien.TabIndex = 1;

            // 
            // lblDatCoc
            // 
            this.lblDatCoc.AutoSize = true;
            this.lblDatCoc.Location = new System.Drawing.Point(340, 25);
            this.lblDatCoc.Name = "lblDatCoc";
            this.lblDatCoc.Size = new System.Drawing.Size(74, 13);
            this.lblDatCoc.TabIndex = 2;
            this.lblDatCoc.Text = "Đặt cọc (30%):";

            // 
            // txtDatCoc
            // 
            this.txtDatCoc.Enabled = false;
            this.txtDatCoc.Location = new System.Drawing.Point(450, 22);
            this.txtDatCoc.Name = "txtDatCoc";
            this.txtDatCoc.Size = new System.Drawing.Size(140, 20);
            this.txtDatCoc.TabIndex = 3;

            // 
            // lblConLai
            // 
            this.lblConLai.AutoSize = true;
            this.lblConLai.Location = new System.Drawing.Point(20, 55);
            this.lblConLai.Name = "lblConLai";
            this.lblConLai.Size = new System.Drawing.Size(42, 13);
            this.lblConLai.TabIndex = 4;
            this.lblConLai.Text = "Còn lại:";

            // 
            // txtConLai
            // 
            this.txtConLai.Enabled = false;
            this.txtConLai.Location = new System.Drawing.Point(120, 52);
            this.txtConLai.Name = "txtConLai";
            this.txtConLai.Size = new System.Drawing.Size(200, 20);
            this.txtConLai.TabIndex = 5;

            // 
            // lblPhuongThucThanhToan
            // 
            this.lblPhuongThucThanhToan.AutoSize = true;
            this.lblPhuongThucThanhToan.Location = new System.Drawing.Point(340, 55);
            this.lblPhuongThucThanhToan.Name = "lblPhuongThucThanhToan";
            this.lblPhuongThucThanhToan.Size = new System.Drawing.Size(70, 13);
            this.lblPhuongThucThanhToan.TabIndex = 6;
            this.lblPhuongThucThanhToan.Text = "Phương thức:";

            // 
            // cbPhuongThucThanhToan
            // 
            this.cbPhuongThucThanhToan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhuongThucThanhToan.FormattingEnabled = true;
            this.cbPhuongThucThanhToan.Location = new System.Drawing.Point(450, 52);
            this.cbPhuongThucThanhToan.Name = "cbPhuongThucThanhToan";
            this.cbPhuongThucThanhToan.Size = new System.Drawing.Size(140, 21);
            this.cbPhuongThucThanhToan.TabIndex = 7;

            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(20, 85);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(47, 13);
            this.lblGhiChu.TabIndex = 8;
            this.lblGhiChu.Text = "Ghi chú:";

            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(120, 82);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(470, 50);
            this.txtGhiChu.TabIndex = 9;

            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(900, 470);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(160, 40);
            this.btnXacNhan.TabIndex = 5;
            this.btnXacNhan.Text = "Xác nhận đặt sự kiện";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(1080, 470);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;

            // 
            // frmEventBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 550);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.gbThanhToan);
            this.Controls.Add(this.gbGoiSuKien);
            this.Controls.Add(this.gbThongTinSuKien);
            this.Controls.Add(this.gbKhachHang);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmEventBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt Sự Kiện";
            this.Load += new System.EventHandler(this.frmEventBooking_Load);
            this.gbKhachHang.ResumeLayout(false);
            this.gbKhachHang.PerformLayout();
            this.gbThongTinSuKien.ResumeLayout(false);
            this.gbThongTinSuKien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTongKhach)).EndInit();
            this.gbGoiSuKien.ResumeLayout(false);
            this.gbGoiSuKien.PerformLayout();
            this.gbThanhToan.ResumeLayout(false);
            this.gbThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
