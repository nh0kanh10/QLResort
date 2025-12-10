namespace QLResort.GUI
{
    partial class frmPromotion
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaKM, lblTenKM, lblGiaTri, lblCouponCode, lblNgayBD, lblNgayKT, lblDieuKien, lblMaCN, lblMaLP, lblMaPhong, lblMaLKH;
        private System.Windows.Forms.TextBox txtMaKM, txtTenKM, txtGiaTri, txtCouponCode, txtDieuKien;
        private System.Windows.Forms.RadioButton rbPhanTram, rbTienMat;
        private System.Windows.Forms.DateTimePicker dtpNgayBD, dtpNgayKT;
        private System.Windows.Forms.ComboBox cbMaCN, cbMaLP, cbMaPhong, cbMaLKH;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Button btnThem, btnSua, btnXoa, btnReset;
        private System.Windows.Forms.ListView lvPromotions;
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
            this.lblMaKM = new System.Windows.Forms.Label();
            this.txtMaKM = new System.Windows.Forms.TextBox();
            this.lblTenKM = new System.Windows.Forms.Label();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.rbPhanTram = new System.Windows.Forms.RadioButton();
            this.rbTienMat = new System.Windows.Forms.RadioButton();
            this.lblGiaTri = new System.Windows.Forms.Label();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.lblCouponCode = new System.Windows.Forms.Label();
            this.txtCouponCode = new System.Windows.Forms.TextBox();
            this.lblNgayBD = new System.Windows.Forms.Label();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.lblNgayKT = new System.Windows.Forms.Label();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.lblDieuKien = new System.Windows.Forms.Label();
            this.txtDieuKien = new System.Windows.Forms.TextBox();
            this.lblMaCN = new System.Windows.Forms.Label();
            this.cbMaCN = new System.Windows.Forms.ComboBox();
            this.lblMaLP = new System.Windows.Forms.Label();
            this.cbMaLP = new System.Windows.Forms.ComboBox();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.cbMaPhong = new System.Windows.Forms.ComboBox();
            this.lblMaLKH = new System.Windows.Forms.Label();
            this.cbMaLKH = new System.Windows.Forms.ComboBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lvPromotions = new System.Windows.Forms.ListView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // Labels and controls
            this.lblMaKM.AutoSize = true;
            this.lblMaKM.Location = new System.Drawing.Point(20, 20);
            this.lblMaKM.Text = "Mã KM:";
            this.txtMaKM.Enabled = false;
            this.txtMaKM.Location = new System.Drawing.Point(100, 17);
            this.txtMaKM.Size = new System.Drawing.Size(150, 20);

            this.lblTenKM.AutoSize = true;
            this.lblTenKM.Location = new System.Drawing.Point(20, 50);
            this.lblTenKM.Text = "Tên KM:";
            this.txtTenKM.Location = new System.Drawing.Point(100, 47);
            this.txtTenKM.Size = new System.Drawing.Size(300, 20);

            this.rbPhanTram.AutoSize = true;
            this.rbPhanTram.Checked = true;
            this.rbPhanTram.Location = new System.Drawing.Point(20, 80);
            this.rbPhanTram.Text = "Giảm %";
            this.rbTienMat.AutoSize = true;
            this.rbTienMat.Location = new System.Drawing.Point(100, 80);
            this.rbTienMat.Text = "Giảm VNĐ";

            this.lblGiaTri.AutoSize = true;
            this.lblGiaTri.Location = new System.Drawing.Point(20, 110);
            this.lblGiaTri.Text = "Giá trị:";
            this.txtGiaTri.Location = new System.Drawing.Point(100, 107);
            this.txtGiaTri.Size = new System.Drawing.Size(150, 20);

            this.lblCouponCode.AutoSize = true;
            this.lblCouponCode.Location = new System.Drawing.Point(20, 140);
            this.lblCouponCode.Text = "Mã coupon:";
            this.txtCouponCode.Location = new System.Drawing.Point(100, 137);
            this.txtCouponCode.Size = new System.Drawing.Size(200, 20);

            this.lblNgayBD.AutoSize = true;
            this.lblNgayBD.Location = new System.Drawing.Point(20, 170);
            this.lblNgayBD.Text = "Ngày bắt đầu:";
            this.dtpNgayBD.Location = new System.Drawing.Point(100, 167);
            this.dtpNgayBD.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblNgayKT.AutoSize = true;
            this.lblNgayKT.Location = new System.Drawing.Point(20, 200);
            this.lblNgayKT.Text = "Ngày kết thúc:";
            this.dtpNgayKT.Location = new System.Drawing.Point(100, 197);
            this.dtpNgayKT.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblDieuKien.AutoSize = true;
            this.lblDieuKien.Location = new System.Drawing.Point(20, 230);
            this.lblDieuKien.Text = "Điều kiện:";
            this.txtDieuKien.Location = new System.Drawing.Point(100, 227);
            this.txtDieuKien.Multiline = true;
            this.txtDieuKien.Size = new System.Drawing.Size(300, 60);

            this.lblMaCN.AutoSize = true;
            this.lblMaCN.Location = new System.Drawing.Point(20, 300);
            this.lblMaCN.Text = "Chi nhánh:";
            this.cbMaCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaCN.Location = new System.Drawing.Point(100, 297);
            this.cbMaCN.Size = new System.Drawing.Size(200, 21);

            this.lblMaLP.AutoSize = true;
            this.lblMaLP.Location = new System.Drawing.Point(20, 330);
            this.lblMaLP.Text = "Loại phòng:";
            this.cbMaLP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaLP.Location = new System.Drawing.Point(100, 327);
            this.cbMaLP.Size = new System.Drawing.Size(200, 21);

            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Location = new System.Drawing.Point(20, 360);
            this.lblMaPhong.Text = "Phòng:";
            this.cbMaPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaPhong.Location = new System.Drawing.Point(100, 357);
            this.cbMaPhong.Size = new System.Drawing.Size(200, 21);

            this.lblMaLKH.AutoSize = true;
            this.lblMaLKH.Location = new System.Drawing.Point(20, 390);
            this.lblMaLKH.Text = "Loại KH:";
            this.cbMaLKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaLKH.Location = new System.Drawing.Point(100, 387);
            this.cbMaLKH.Size = new System.Drawing.Size(200, 21);

            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.Location = new System.Drawing.Point(20, 420);
            this.cbIsActive.Text = "Hoạt động";

            this.btnThem.Location = new System.Drawing.Point(20, 450);
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.Text = "Thêm";
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(110, 450);
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.Text = "Sửa";
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(200, 450);
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.Text = "Xóa";
            this.btnReset.Location = new System.Drawing.Point(290, 450);
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.Text = "Làm mới";

            this.lvPromotions.FullRowSelect = true;
            this.lvPromotions.GridLines = true;
            this.lvPromotions.Location = new System.Drawing.Point(420, 20);
            this.lvPromotions.Size = new System.Drawing.Size(700, 460);
            this.lvPromotions.View = System.Windows.Forms.View.Details;
            this.lvPromotions.Columns.Add("Mã KM", 80);
            this.lvPromotions.Columns.Add("Tên KM", 150);
            this.lvPromotions.Columns.Add("Loại", 50);
            this.lvPromotions.Columns.Add("Giá trị", 100);
            this.lvPromotions.Columns.Add("Coupon", 100);
            this.lvPromotions.Columns.Add("Ngày BD", 100);
            this.lvPromotions.Columns.Add("Ngày KT", 100);
            this.lvPromotions.Columns.Add("Hoạt động", 80);
            this.lvPromotions.SelectedIndexChanged += new System.EventHandler(this.lvPromotions_SelectedIndexChanged);

            this.errorProvider1.ContainerControl = this;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 500);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lvPromotions, this.btnReset, this.btnXoa, this.btnSua, this.btnThem,
                this.cbIsActive, this.cbMaLKH, this.lblMaLKH, this.cbMaPhong, this.lblMaPhong,
                this.cbMaLP, this.lblMaLP, this.cbMaCN, this.lblMaCN, this.txtDieuKien,
                this.lblDieuKien, this.dtpNgayKT, this.lblNgayKT, this.dtpNgayBD, this.lblNgayBD,
                this.txtCouponCode, this.lblCouponCode, this.txtGiaTri, this.lblGiaTri,
                this.rbTienMat, this.rbPhanTram, this.txtTenKM, this.lblTenKM, this.txtMaKM, this.lblMaKM
            });
            this.Name = "frmPromotion";
            this.Text = "Quản lý Khuyến Mãi";
            this.Load += new System.EventHandler(this.frmPromotion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


