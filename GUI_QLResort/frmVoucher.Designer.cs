using System.ComponentModel;
using System.Windows.Forms;

namespace GUI_QLResort
{
    partial class frmVoucher
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaVoucher;
        private System.Windows.Forms.TextBox txtMaVoucher;
        private System.Windows.Forms.Label lblTenVoucher;
        private System.Windows.Forms.TextBox txtTenVoucher;
        private System.Windows.Forms.Label lblCouponCode;
        private System.Windows.Forms.TextBox txtCouponCode;
        private System.Windows.Forms.CheckBox cbIsPhanTram;
        private System.Windows.Forms.Label lblGiaTri;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblMaLKH;
        private System.Windows.Forms.ComboBox cbMaLKH;
        private System.Windows.Forms.Label lblMaCN;
        private System.Windows.Forms.ComboBox cbMaCN;
        private System.Windows.Forms.Label lblNgayBD;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.Label lblNgayKT;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.Label lblDieuKien;
        private System.Windows.Forms.TextBox txtDieuKien;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView lvVouchers;
        private System.Windows.Forms.ColumnHeader colMaVoucher;
        private System.Windows.Forms.ColumnHeader colTenVoucher;
        private System.Windows.Forms.ColumnHeader colCoupon;
        private System.Windows.Forms.ColumnHeader colLoai;
        private System.Windows.Forms.ColumnHeader colGiaTri;
        private System.Windows.Forms.ColumnHeader colSoLuong;
        private System.Windows.Forms.ColumnHeader colDaDung;
        private System.Windows.Forms.ColumnHeader colTrangThai;
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
            this.lblMaVoucher = new System.Windows.Forms.Label();
            this.txtMaVoucher = new System.Windows.Forms.TextBox();
            this.lblTenVoucher = new System.Windows.Forms.Label();
            this.txtTenVoucher = new System.Windows.Forms.TextBox();
            this.lblCouponCode = new System.Windows.Forms.Label();
            this.txtCouponCode = new System.Windows.Forms.TextBox();
            this.cbIsPhanTram = new System.Windows.Forms.CheckBox();
            this.lblGiaTri = new System.Windows.Forms.Label();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.lblMaLKH = new System.Windows.Forms.Label();
            this.cbMaLKH = new System.Windows.Forms.ComboBox();
            this.lblMaCN = new System.Windows.Forms.Label();
            this.cbMaCN = new System.Windows.Forms.ComboBox();
            this.lblNgayBD = new System.Windows.Forms.Label();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKT = new System.Windows.Forms.Label();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.lblDieuKien = new System.Windows.Forms.Label();
            this.txtDieuKien = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lvVouchers = new System.Windows.Forms.ListView();
            this.colMaVoucher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenVoucher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCoupon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGiaTri = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoLuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDaDung = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaVoucher
            // 
            this.lblMaVoucher.AutoSize = true;
            this.lblMaVoucher.Location = new System.Drawing.Point(20, 20);
            this.lblMaVoucher.Name = "lblMaVoucher";
            this.lblMaVoucher.Size = new System.Drawing.Size(67, 13);
            this.lblMaVoucher.TabIndex = 27;
            this.lblMaVoucher.Text = "Mã voucher:";
            // 
            // txtMaVoucher
            // 
            this.txtMaVoucher.Enabled = false;
            this.txtMaVoucher.Location = new System.Drawing.Point(130, 17);
            this.txtMaVoucher.Name = "txtMaVoucher";
            this.txtMaVoucher.Size = new System.Drawing.Size(270, 20);
            this.txtMaVoucher.TabIndex = 26;
            // 
            // lblTenVoucher
            // 
            this.lblTenVoucher.AutoSize = true;
            this.lblTenVoucher.Location = new System.Drawing.Point(20, 50);
            this.lblTenVoucher.Name = "lblTenVoucher";
            this.lblTenVoucher.Size = new System.Drawing.Size(71, 13);
            this.lblTenVoucher.TabIndex = 25;
            this.lblTenVoucher.Text = "Tên voucher:";
            // 
            // txtTenVoucher
            // 
            this.txtTenVoucher.Location = new System.Drawing.Point(130, 47);
            this.txtTenVoucher.Name = "txtTenVoucher";
            this.txtTenVoucher.Size = new System.Drawing.Size(270, 20);
            this.txtTenVoucher.TabIndex = 24;
            // 
            // lblCouponCode
            // 
            this.lblCouponCode.AutoSize = true;
            this.lblCouponCode.Location = new System.Drawing.Point(20, 80);
            this.lblCouponCode.Name = "lblCouponCode";
            this.lblCouponCode.Size = new System.Drawing.Size(64, 13);
            this.lblCouponCode.TabIndex = 23;
            this.lblCouponCode.Text = "Mã coupon:";
            // 
            // txtCouponCode
            // 
            this.txtCouponCode.Location = new System.Drawing.Point(130, 77);
            this.txtCouponCode.Name = "txtCouponCode";
            this.txtCouponCode.Size = new System.Drawing.Size(270, 20);
            this.txtCouponCode.TabIndex = 22;
            // 
            // cbIsPhanTram
            // 
            this.cbIsPhanTram.AutoSize = true;
            this.cbIsPhanTram.Checked = true;
            this.cbIsPhanTram.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsPhanTram.Location = new System.Drawing.Point(20, 110);
            this.cbIsPhanTram.Name = "cbIsPhanTram";
            this.cbIsPhanTram.Size = new System.Drawing.Size(85, 17);
            this.cbIsPhanTram.TabIndex = 21;
            this.cbIsPhanTram.Text = "Giảm theo %";
            // 
            // lblGiaTri
            // 
            this.lblGiaTri.AutoSize = true;
            this.lblGiaTri.Location = new System.Drawing.Point(20, 140);
            this.lblGiaTri.Name = "lblGiaTri";
            this.lblGiaTri.Size = new System.Drawing.Size(37, 13);
            this.lblGiaTri.TabIndex = 20;
            this.lblGiaTri.Text = "Giá trị:";
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(130, 137);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(270, 20);
            this.txtGiaTri.TabIndex = 19;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(20, 170);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(52, 13);
            this.lblSoLuong.TabIndex = 18;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(130, 167);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(270, 20);
            this.txtSoLuong.TabIndex = 17;
            // 
            // lblMaLKH
            // 
            this.lblMaLKH.AutoSize = true;
            this.lblMaLKH.Location = new System.Drawing.Point(20, 200);
            this.lblMaLKH.Name = "lblMaLKH";
            this.lblMaLKH.Size = new System.Drawing.Size(90, 13);
            this.lblMaLKH.TabIndex = 16;
            this.lblMaLKH.Text = "Loại khách hàng:";
            // 
            // cbMaLKH
            // 
            this.cbMaLKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaLKH.FormattingEnabled = true;
            this.cbMaLKH.Location = new System.Drawing.Point(130, 197);
            this.cbMaLKH.Name = "cbMaLKH";
            this.cbMaLKH.Size = new System.Drawing.Size(270, 21);
            this.cbMaLKH.TabIndex = 15;
            // 
            // lblMaCN
            // 
            this.lblMaCN.AutoSize = true;
            this.lblMaCN.Location = new System.Drawing.Point(20, 230);
            this.lblMaCN.Name = "lblMaCN";
            this.lblMaCN.Size = new System.Drawing.Size(58, 13);
            this.lblMaCN.TabIndex = 14;
            this.lblMaCN.Text = "Chi nhánh:";
            // 
            // cbMaCN
            // 
            this.cbMaCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaCN.FormattingEnabled = true;
            this.cbMaCN.Location = new System.Drawing.Point(130, 227);
            this.cbMaCN.Name = "cbMaCN";
            this.cbMaCN.Size = new System.Drawing.Size(270, 21);
            this.cbMaCN.TabIndex = 13;
            // 
            // lblNgayBD
            // 
            this.lblNgayBD.AutoSize = true;
            this.lblNgayBD.Location = new System.Drawing.Point(20, 260);
            this.lblNgayBD.Name = "lblNgayBD";
            this.lblNgayBD.Size = new System.Drawing.Size(75, 13);
            this.lblNgayBD.TabIndex = 12;
            this.lblNgayBD.Text = "Ngày bắt đầu:";
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBD.Location = new System.Drawing.Point(130, 254);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(150, 20);
            this.dtpNgayBD.TabIndex = 11;
            // 
            // lblNgayKT
            // 
            this.lblNgayKT.AutoSize = true;
            this.lblNgayKT.Location = new System.Drawing.Point(20, 290);
            this.lblNgayKT.Name = "lblNgayKT";
            this.lblNgayKT.Size = new System.Drawing.Size(77, 13);
            this.lblNgayKT.TabIndex = 10;
            this.lblNgayKT.Text = "Ngày kết thúc:";
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKT.Location = new System.Drawing.Point(130, 284);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(150, 20);
            this.dtpNgayKT.TabIndex = 9;
            // 
            // lblDieuKien
            // 
            this.lblDieuKien.AutoSize = true;
            this.lblDieuKien.Location = new System.Drawing.Point(20, 320);
            this.lblDieuKien.Name = "lblDieuKien";
            this.lblDieuKien.Size = new System.Drawing.Size(55, 13);
            this.lblDieuKien.TabIndex = 8;
            this.lblDieuKien.Text = "Điều kiện:";
            // 
            // txtDieuKien
            // 
            this.txtDieuKien.Location = new System.Drawing.Point(130, 317);
            this.txtDieuKien.Multiline = true;
            this.txtDieuKien.Name = "txtDieuKien";
            this.txtDieuKien.Size = new System.Drawing.Size(270, 40);
            this.txtDieuKien.TabIndex = 7;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(20, 370);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(58, 13);
            this.lblTrangThai.TabIndex = 6;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(130, 367);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(270, 21);
            this.cbTrangThai.TabIndex = 5;
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.Location = new System.Drawing.Point(20, 400);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(77, 17);
            this.cbIsActive.TabIndex = 4;
            this.cbIsActive.Text = "Hoạt động";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(130, 430);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(244, 430);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(325, 430);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(200, 430);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lvVouchers
            // 
            this.lvVouchers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaVoucher,
            this.colTenVoucher,
            this.colCoupon,
            this.colLoai,
            this.colGiaTri,
            this.colSoLuong,
            this.colDaDung,
            this.colTrangThai});
            this.lvVouchers.FullRowSelect = true;
            this.lvVouchers.GridLines = true;
            this.lvVouchers.HideSelection = false;
            this.lvVouchers.Location = new System.Drawing.Point(420, 20);
            this.lvVouchers.Name = "lvVouchers";
            this.lvVouchers.Size = new System.Drawing.Size(700, 440);
            this.lvVouchers.TabIndex = 0;
            this.lvVouchers.UseCompatibleStateImageBehavior = false;
            this.lvVouchers.View = System.Windows.Forms.View.Details;
            this.lvVouchers.SelectedIndexChanged += new System.EventHandler(this.lvVouchers_SelectedIndexChanged);
            // 
            // colMaVoucher
            // 
            this.colMaVoucher.Text = "Mã Voucher";
            this.colMaVoucher.Width = 80;
            // 
            // colTenVoucher
            // 
            this.colTenVoucher.Text = "Tên Voucher";
            this.colTenVoucher.Width = 120;
            // 
            // colCoupon
            // 
            this.colCoupon.Text = "Code";
            this.colCoupon.Width = 80;
            // 
            // colLoai
            // 
            this.colLoai.Text = "Loại";
            this.colLoai.Width = 50;
            // 
            // colGiaTri
            // 
            this.colGiaTri.Text = "Giá Trị";
            this.colGiaTri.Width = 80;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Text = "SL";
            this.colSoLuong.Width = 50;
             // 
            // colDaDung
            // 
            this.colDaDung.Text = "Đã Dùng";
            this.colDaDung.Width = 60;
             // 
            // colTrangThai
            // 
            this.colTrangThai.Text = "Trạng Thái";
            this.colTrangThai.Width = 80;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 480);
            this.Controls.Add(this.lvVouchers);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.txtDieuKien);
            this.Controls.Add(this.lblDieuKien);
            this.Controls.Add(this.dtpNgayKT);
            this.Controls.Add(this.lblNgayKT);
            this.Controls.Add(this.dtpNgayBD);
            this.Controls.Add(this.lblNgayBD);
            this.Controls.Add(this.cbMaCN);
            this.Controls.Add(this.lblMaCN);
            this.Controls.Add(this.cbMaLKH);
            this.Controls.Add(this.lblMaLKH);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lblSoLuong);
            this.Controls.Add(this.txtGiaTri);
            this.Controls.Add(this.lblGiaTri);
            this.Controls.Add(this.cbIsPhanTram);
            this.Controls.Add(this.txtCouponCode);
            this.Controls.Add(this.lblCouponCode);
            this.Controls.Add(this.txtTenVoucher);
            this.Controls.Add(this.lblTenVoucher);
            this.Controls.Add(this.txtMaVoucher);
            this.Controls.Add(this.lblMaVoucher);
            this.Name = "frmVoucher";
            this.Text = "Quản lý Voucher";
            this.Load += new System.EventHandler(this.frmVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

