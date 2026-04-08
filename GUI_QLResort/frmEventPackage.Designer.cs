using System.ComponentModel;
using System.Windows.Forms;

namespace GUI_QLResort
{
    partial class frmEventPackage
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaGoiSK;
        private System.Windows.Forms.TextBox txtMaGoiSK;
        private System.Windows.Forms.Label lblTenGoiSK;
        private System.Windows.Forms.TextBox txtTenGoiSK;
        private System.Windows.Forms.Label lBUSoaiSuKien;
        private System.Windows.Forms.ComboBox cbLoaiSuKien;
        private System.Windows.Forms.Label lblMaCN;
        private System.Windows.Forms.ComboBox cbMaCN;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblGiaCoBan;
        private System.Windows.Forms.NumericUpDown nudGiaCoBan;
        private System.Windows.Forms.Label lblSoKhachToiThieu;
        private System.Windows.Forms.NumericUpDown nudSoKhachToiThieu;
        private System.Windows.Forms.Label lblSoKhachToiDa;
        private System.Windows.Forms.NumericUpDown nudSoKhachToiDa;
        private System.Windows.Forms.Label lblThoiGianToiThieu;
        private System.Windows.Forms.NumericUpDown nudThoiGianToiThieu;
        private System.Windows.Forms.Label lblThoiGianToiDa;
        private System.Windows.Forms.NumericUpDown nudThoiGianToiDa;
        private System.Windows.Forms.Label lblDichVuKemTheo;
        private System.Windows.Forms.TextBox txtDichVuKemTheo;
        private System.Windows.Forms.CheckBox cbIsGoiMacDinh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView lvPackages;
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
            this.lblMaGoiSK = new System.Windows.Forms.Label();
            this.txtMaGoiSK = new System.Windows.Forms.TextBox();
            this.lblTenGoiSK = new System.Windows.Forms.Label();
            this.txtTenGoiSK = new System.Windows.Forms.TextBox();
            this.lBUSoaiSuKien = new System.Windows.Forms.Label();
            this.cbLoaiSuKien = new System.Windows.Forms.ComboBox();
            this.lblMaCN = new System.Windows.Forms.Label();
            this.cbMaCN = new System.Windows.Forms.ComboBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblGiaCoBan = new System.Windows.Forms.Label();
            this.nudGiaCoBan = new System.Windows.Forms.NumericUpDown();
            this.lblSoKhachToiThieu = new System.Windows.Forms.Label();
            this.nudSoKhachToiThieu = new System.Windows.Forms.NumericUpDown();
            this.lblSoKhachToiDa = new System.Windows.Forms.Label();
            this.nudSoKhachToiDa = new System.Windows.Forms.NumericUpDown();
            this.lblThoiGianToiThieu = new System.Windows.Forms.Label();
            this.nudThoiGianToiThieu = new System.Windows.Forms.NumericUpDown();
            this.lblThoiGianToiDa = new System.Windows.Forms.Label();
            this.nudThoiGianToiDa = new System.Windows.Forms.NumericUpDown();
            this.lblDichVuKemTheo = new System.Windows.Forms.Label();
            this.txtDichVuKemTheo = new System.Windows.Forms.TextBox();
            this.cbIsGoiMacDinh = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lvPackages = new System.Windows.Forms.ListView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaCoBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoKhachToiThieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoKhachToiDa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGianToiThieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGianToiDa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaGoiSK
            // 
            this.lblMaGoiSK.AutoSize = true;
            this.lblMaGoiSK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaGoiSK.Location = new System.Drawing.Point(55, 53);
            this.lblMaGoiSK.Name = "lblMaGoiSK";
            this.lblMaGoiSK.Size = new System.Drawing.Size(51, 16);
            this.lblMaGoiSK.TabIndex = 0;
            this.lblMaGoiSK.Text = "Mã gói:";
            // 
            // txtMaGoiSK
            // 
            this.txtMaGoiSK.Enabled = false;
            this.txtMaGoiSK.Location = new System.Drawing.Point(162, 50);
            this.txtMaGoiSK.Name = "txtMaGoiSK";
            this.txtMaGoiSK.Size = new System.Drawing.Size(473, 22);
            this.txtMaGoiSK.TabIndex = 1;
            // 
            // lblTenGoiSK
            // 
            this.lblTenGoiSK.AutoSize = true;
            this.lblTenGoiSK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenGoiSK.Location = new System.Drawing.Point(55, 83);
            this.lblTenGoiSK.Name = "lblTenGoiSK";
            this.lblTenGoiSK.Size = new System.Drawing.Size(56, 16);
            this.lblTenGoiSK.TabIndex = 2;
            this.lblTenGoiSK.Text = "Tên gói:";
            // 
            // txtTenGoiSK
            // 
            this.txtTenGoiSK.Location = new System.Drawing.Point(162, 80);
            this.txtTenGoiSK.Name = "txtTenGoiSK";
            this.txtTenGoiSK.Size = new System.Drawing.Size(473, 22);
            this.txtTenGoiSK.TabIndex = 3;
            // 
            // lBUSoaiSuKien
            // 
            this.lBUSoaiSuKien.AutoSize = true;
            this.lBUSoaiSuKien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBUSoaiSuKien.Location = new System.Drawing.Point(55, 113);
            this.lBUSoaiSuKien.Name = "lBUSoaiSuKien";
            this.lBUSoaiSuKien.Size = new System.Drawing.Size(81, 16);
            this.lBUSoaiSuKien.TabIndex = 4;
            this.lBUSoaiSuKien.Text = "Loại sự kiện:";
            // 
            // cbLoaiSuKien
            // 
            this.cbLoaiSuKien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiSuKien.Location = new System.Drawing.Point(162, 110);
            this.cbLoaiSuKien.Name = "cbLoaiSuKien";
            this.cbLoaiSuKien.Size = new System.Drawing.Size(173, 24);
            this.cbLoaiSuKien.TabIndex = 5;
            // 
            // lblMaCN
            // 
            this.lblMaCN.AutoSize = true;
            this.lblMaCN.Location = new System.Drawing.Point(355, 113);
            this.lblMaCN.Name = "lblMaCN";
            this.lblMaCN.Size = new System.Drawing.Size(68, 16);
            this.lblMaCN.TabIndex = 6;
            this.lblMaCN.Text = "Chi nhánh:";
            // 
            // cbMaCN
            // 
            this.cbMaCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaCN.Location = new System.Drawing.Point(435, 110);
            this.cbMaCN.Name = "cbMaCN";
            this.cbMaCN.Size = new System.Drawing.Size(200, 24);
            this.cbMaCN.TabIndex = 7;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(55, 143);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(43, 16);
            this.lblMoTa.TabIndex = 8;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(162, 140);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(473, 50);
            this.txtMoTa.TabIndex = 9;
            // 
            // lblGiaCoBan
            // 
            this.lblGiaCoBan.AutoSize = true;
            this.lblGiaCoBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaCoBan.Location = new System.Drawing.Point(61, 217);
            this.lblGiaCoBan.Name = "lblGiaCoBan";
            this.lblGiaCoBan.Size = new System.Drawing.Size(75, 16);
            this.lblGiaCoBan.TabIndex = 10;
            this.lblGiaCoBan.Text = "Giá cơ bản:";
            // 
            // nudGiaCoBan
            // 
            this.nudGiaCoBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudGiaCoBan.Location = new System.Drawing.Point(162, 215);
            this.nudGiaCoBan.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudGiaCoBan.Name = "nudGiaCoBan";
            this.nudGiaCoBan.Size = new System.Drawing.Size(200, 22);
            this.nudGiaCoBan.TabIndex = 11;
            // 
            // lblSoKhachToiThieu
            // 
            this.lblSoKhachToiThieu.AutoSize = true;
            this.lblSoKhachToiThieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoKhachToiThieu.Location = new System.Drawing.Point(422, 252);
            this.lblSoKhachToiThieu.Name = "lblSoKhachToiThieu";
            this.lblSoKhachToiThieu.Size = new System.Drawing.Size(114, 16);
            this.lblSoKhachToiThieu.TabIndex = 12;
            this.lblSoKhachToiThieu.Text = "Số khách tối thiểu:";
            // 
            // nudSoKhachToiThieu
            // 
            this.nudSoKhachToiThieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoKhachToiThieu.Location = new System.Drawing.Point(425, 285);
            this.nudSoKhachToiThieu.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSoKhachToiThieu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoKhachToiThieu.Name = "nudSoKhachToiThieu";
            this.nudSoKhachToiThieu.Size = new System.Drawing.Size(210, 22);
            this.nudSoKhachToiThieu.TabIndex = 13;
            this.nudSoKhachToiThieu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSoKhachToiDa
            // 
            this.lblSoKhachToiDa.AutoSize = true;
            this.lblSoKhachToiDa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoKhachToiDa.Location = new System.Drawing.Point(160, 252);
            this.lblSoKhachToiDa.Name = "lblSoKhachToiDa";
            this.lblSoKhachToiDa.Size = new System.Drawing.Size(102, 16);
            this.lblSoKhachToiDa.TabIndex = 14;
            this.lblSoKhachToiDa.Text = "Số khách tối đa:";
            // 
            // nudSoKhachToiDa
            // 
            this.nudSoKhachToiDa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoKhachToiDa.Location = new System.Drawing.Point(162, 285);
            this.nudSoKhachToiDa.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSoKhachToiDa.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoKhachToiDa.Name = "nudSoKhachToiDa";
            this.nudSoKhachToiDa.Size = new System.Drawing.Size(200, 22);
            this.nudSoKhachToiDa.TabIndex = 15;
            this.nudSoKhachToiDa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblThoiGianToiThieu
            // 
            this.lblThoiGianToiThieu.AutoSize = true;
            this.lblThoiGianToiThieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianToiThieu.Location = new System.Drawing.Point(422, 328);
            this.lblThoiGianToiThieu.Name = "lblThoiGianToiThieu";
            this.lblThoiGianToiThieu.Size = new System.Drawing.Size(144, 16);
            this.lblThoiGianToiThieu.TabIndex = 16;
            this.lblThoiGianToiThieu.Text = "Thời gian tối thiểu (giờ):";
            // 
            // nudThoiGianToiThieu
            // 
            this.nudThoiGianToiThieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudThoiGianToiThieu.Location = new System.Drawing.Point(425, 362);
            this.nudThoiGianToiThieu.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudThoiGianToiThieu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThoiGianToiThieu.Name = "nudThoiGianToiThieu";
            this.nudThoiGianToiThieu.Size = new System.Drawing.Size(210, 22);
            this.nudThoiGianToiThieu.TabIndex = 17;
            this.nudThoiGianToiThieu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblThoiGianToiDa
            // 
            this.lblThoiGianToiDa.AutoSize = true;
            this.lblThoiGianToiDa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianToiDa.Location = new System.Drawing.Point(159, 328);
            this.lblThoiGianToiDa.Name = "lblThoiGianToiDa";
            this.lblThoiGianToiDa.Size = new System.Drawing.Size(132, 16);
            this.lblThoiGianToiDa.TabIndex = 18;
            this.lblThoiGianToiDa.Text = "Thời gian tối đa (giờ):";
            // 
            // nudThoiGianToiDa
            // 
            this.nudThoiGianToiDa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudThoiGianToiDa.Location = new System.Drawing.Point(162, 362);
            this.nudThoiGianToiDa.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudThoiGianToiDa.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThoiGianToiDa.Name = "nudThoiGianToiDa";
            this.nudThoiGianToiDa.Size = new System.Drawing.Size(200, 22);
            this.nudThoiGianToiDa.TabIndex = 19;
            this.nudThoiGianToiDa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDichVuKemTheo
            // 
            this.lblDichVuKemTheo.AutoSize = true;
            this.lblDichVuKemTheo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDichVuKemTheo.Location = new System.Drawing.Point(159, 409);
            this.lblDichVuKemTheo.Name = "lblDichVuKemTheo";
            this.lblDichVuKemTheo.Size = new System.Drawing.Size(112, 16);
            this.lblDichVuKemTheo.TabIndex = 20;
            this.lblDichVuKemTheo.Text = "Dịch vụ kèm theo:";
            // 
            // txtDichVuKemTheo
            // 
            this.txtDichVuKemTheo.Location = new System.Drawing.Point(162, 442);
            this.txtDichVuKemTheo.Multiline = true;
            this.txtDichVuKemTheo.Name = "txtDichVuKemTheo";
            this.txtDichVuKemTheo.Size = new System.Drawing.Size(473, 103);
            this.txtDichVuKemTheo.TabIndex = 21;
            // 
            // cbIsGoiMacDinh
            // 
            this.cbIsGoiMacDinh.AutoSize = true;
            this.cbIsGoiMacDinh.Enabled = false;
            this.cbIsGoiMacDinh.Location = new System.Drawing.Point(546, 408);
            this.cbIsGoiMacDinh.Name = "cbIsGoiMacDinh";
            this.cbIsGoiMacDinh.Size = new System.Drawing.Size(104, 20);
            this.cbIsGoiMacDinh.TabIndex = 22;
            this.cbIsGoiMacDinh.Text = "Gói mặc định";
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(162, 565);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.TabIndex = 23;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(291, 565);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 24;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(413, 565);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.TabIndex = 25;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(535, 565);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 35);
            this.btnReset.TabIndex = 26;
            this.btnReset.Text = "Làm mới";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lvPackages
            // 
            this.lvPackages.FullRowSelect = true;
            this.lvPackages.GridLines = true;
            this.lvPackages.HideSelection = false;
            this.lvPackages.Location = new System.Drawing.Point(707, 47);
            this.lvPackages.Name = "lvPackages";
            this.lvPackages.Size = new System.Drawing.Size(811, 553);
            this.lvPackages.TabIndex = 27;
            this.lvPackages.UseCompatibleStateImageBehavior = false;
            this.lvPackages.View = System.Windows.Forms.View.Details;
            this.lvPackages.SelectedIndexChanged += new System.EventHandler(this.lvPackages_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmEventPackage
            // 
            this.ClientSize = new System.Drawing.Size(1534, 640);
            this.Controls.Add(this.lblMaGoiSK);
            this.Controls.Add(this.txtMaGoiSK);
            this.Controls.Add(this.lblTenGoiSK);
            this.Controls.Add(this.txtTenGoiSK);
            this.Controls.Add(this.lBUSoaiSuKien);
            this.Controls.Add(this.cbLoaiSuKien);
            this.Controls.Add(this.lblMaCN);
            this.Controls.Add(this.cbMaCN);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.lblGiaCoBan);
            this.Controls.Add(this.nudGiaCoBan);
            this.Controls.Add(this.lblSoKhachToiThieu);
            this.Controls.Add(this.nudSoKhachToiThieu);
            this.Controls.Add(this.lblSoKhachToiDa);
            this.Controls.Add(this.nudSoKhachToiDa);
            this.Controls.Add(this.lblThoiGianToiThieu);
            this.Controls.Add(this.nudThoiGianToiThieu);
            this.Controls.Add(this.lblThoiGianToiDa);
            this.Controls.Add(this.nudThoiGianToiDa);
            this.Controls.Add(this.lblDichVuKemTheo);
            this.Controls.Add(this.txtDichVuKemTheo);
            this.Controls.Add(this.cbIsGoiMacDinh);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lvPackages);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmEventPackage";
            this.Text = "Quản lý Gói Sự Kiện";
            this.Load += new System.EventHandler(this.frmEventPackage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudGiaCoBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoKhachToiThieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoKhachToiDa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGianToiThieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThoiGianToiDa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

