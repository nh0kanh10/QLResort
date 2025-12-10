using System.ComponentModel;
using System.Windows.Forms;

namespace QLResort.GUI
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

            // Labels và Controls
            this.lblMaGoiSK.AutoSize = true;
            this.lblMaGoiSK.Location = new System.Drawing.Point(20, 20);
            this.lblMaGoiSK.Text = "Mã gói:";
            this.txtMaGoiSK.Enabled = false;
            this.txtMaGoiSK.Location = new System.Drawing.Point(100, 17);
            this.txtMaGoiSK.Size = new System.Drawing.Size(150, 20);

            this.lblTenGoiSK.AutoSize = true;
            this.lblTenGoiSK.Location = new System.Drawing.Point(20, 50);
            this.lblTenGoiSK.Text = "Tên gói:";
            this.txtTenGoiSK.Location = new System.Drawing.Point(100, 47);
            this.txtTenGoiSK.Size = new System.Drawing.Size(300, 20);

            this.lBUSoaiSuKien.AutoSize = true;
            this.lBUSoaiSuKien.Location = new System.Drawing.Point(20, 80);
            this.lBUSoaiSuKien.Text = "Loại sự kiện:";
            this.cbLoaiSuKien.Location = new System.Drawing.Point(100, 77);
            this.cbLoaiSuKien.Size = new System.Drawing.Size(200, 21);
            this.cbLoaiSuKien.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbLoaiSuKien.SelectedIndexChanged += new System.EventHandler(this.cbLoaiSuKien_SelectedIndexChanged);

            this.lblMaCN.AutoSize = true;
            this.lblMaCN.Location = new System.Drawing.Point(320, 80);
            this.lblMaCN.Text = "Chi nhánh:";
            this.cbMaCN.Location = new System.Drawing.Point(400, 77);
            this.cbMaCN.Size = new System.Drawing.Size(200, 21);
            this.cbMaCN.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(20, 110);
            this.lblMoTa.Text = "Mô tả:";
            this.txtMoTa.Location = new System.Drawing.Point(100, 107);
            this.txtMoTa.Size = new System.Drawing.Size(500, 20);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Height = 50;

            this.lblGiaCoBan.AutoSize = true;
            this.lblGiaCoBan.Location = new System.Drawing.Point(20, 170);
            this.lblGiaCoBan.Text = "Giá cơ bản:";
            this.nudGiaCoBan.Location = new System.Drawing.Point(100, 167);
            this.nudGiaCoBan.Size = new System.Drawing.Size(200, 20);
            this.nudGiaCoBan.Minimum = 0;
            this.nudGiaCoBan.Maximum = 1000000000;
            this.nudGiaCoBan.DecimalPlaces = 0;

            this.lblSoKhachToiThieu.AutoSize = true;
            this.lblSoKhachToiThieu.Location = new System.Drawing.Point(320, 170);
            this.lblSoKhachToiThieu.Text = "Số khách tối thiểu:";
            this.nudSoKhachToiThieu.Location = new System.Drawing.Point(450, 167);
            this.nudSoKhachToiThieu.Size = new System.Drawing.Size(100, 20);
            this.nudSoKhachToiThieu.Minimum = 1;
            this.nudSoKhachToiThieu.Maximum = 10000;

            this.lblSoKhachToiDa.AutoSize = true;
            this.lblSoKhachToiDa.Location = new System.Drawing.Point(20, 200);
            this.lblSoKhachToiDa.Text = "Số khách tối đa:";
            this.nudSoKhachToiDa.Location = new System.Drawing.Point(100, 197);
            this.nudSoKhachToiDa.Size = new System.Drawing.Size(200, 20);
            this.nudSoKhachToiDa.Minimum = 1;
            this.nudSoKhachToiDa.Maximum = 10000;

            this.lblThoiGianToiThieu.AutoSize = true;
            this.lblThoiGianToiThieu.Location = new System.Drawing.Point(320, 200);
            this.lblThoiGianToiThieu.Text = "Thời gian tối thiểu (giờ):";
            this.nudThoiGianToiThieu.Location = new System.Drawing.Point(450, 197);
            this.nudThoiGianToiThieu.Size = new System.Drawing.Size(100, 20);
            this.nudThoiGianToiThieu.Minimum = 1;
            this.nudThoiGianToiThieu.Maximum = 24;

            this.lblThoiGianToiDa.AutoSize = true;
            this.lblThoiGianToiDa.Location = new System.Drawing.Point(20, 230);
            this.lblThoiGianToiDa.Text = "Thời gian tối đa (giờ):";
            this.nudThoiGianToiDa.Location = new System.Drawing.Point(100, 227);
            this.nudThoiGianToiDa.Size = new System.Drawing.Size(200, 20);
            this.nudThoiGianToiDa.Minimum = 1;
            this.nudThoiGianToiDa.Maximum = 24;

            this.lblDichVuKemTheo.AutoSize = true;
            this.lblDichVuKemTheo.Location = new System.Drawing.Point(20, 260);
            this.lblDichVuKemTheo.Text = "Dịch vụ kèm theo:";
            this.txtDichVuKemTheo.Location = new System.Drawing.Point(100, 257);
            this.txtDichVuKemTheo.Size = new System.Drawing.Size(500, 20);
            this.txtDichVuKemTheo.Multiline = true;
            this.txtDichVuKemTheo.Height = 50;

            this.cbIsGoiMacDinh.AutoSize = true;
            this.cbIsGoiMacDinh.Location = new System.Drawing.Point(320, 230);
            this.cbIsGoiMacDinh.Text = "Gói mặc định";
            this.cbIsGoiMacDinh.Enabled = false; // Chỉ set khi tạo mới

            // Buttons
            this.btnThem.Location = new System.Drawing.Point(100, 320);
            this.btnThem.Size = new System.Drawing.Size(100, 35);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(210, 320);
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(320, 320);
            this.btnXoa.Size = new System.Drawing.Size(100, 35);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnReset.Location = new System.Drawing.Point(430, 320);
            this.btnReset.Size = new System.Drawing.Size(100, 35);
            this.btnReset.Text = "Làm mới";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            // ListView
            this.lvPackages.Location = new System.Drawing.Point(620, 20);
            this.lvPackages.Size = new System.Drawing.Size(600, 400);
            this.lvPackages.FullRowSelect = true;
            this.lvPackages.GridLines = true;
            this.lvPackages.View = System.Windows.Forms.View.Details;
            this.lvPackages.Columns.Add("Mã gói", 80);
            this.lvPackages.Columns.Add("Tên gói", 200);
            this.lvPackages.Columns.Add("Loại", 100);
            this.lvPackages.Columns.Add("Giá", 120);
            this.lvPackages.Columns.Add("Khách min", 80);
            this.lvPackages.Columns.Add("Khách max", 80);
            this.lvPackages.Columns.Add("Loại gói", 100);
            this.lvPackages.SelectedIndexChanged += new System.EventHandler(this.lvPackages_SelectedIndexChanged);

            // Form
            this.Text = "Quản lý Gói Sự Kiện";
            this.Size = new System.Drawing.Size(1250, 500);
            this.Load += new System.EventHandler(this.frmEventPackage_Load);

            // Add controls
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaGoiSK, this.txtMaGoiSK,
                this.lblTenGoiSK, this.txtTenGoiSK,
                this.lBUSoaiSuKien, this.cbLoaiSuKien,
                this.lblMaCN, this.cbMaCN,
                this.lblMoTa, this.txtMoTa,
                this.lblGiaCoBan, this.nudGiaCoBan,
                this.lblSoKhachToiThieu, this.nudSoKhachToiThieu,
                this.lblSoKhachToiDa, this.nudSoKhachToiDa,
                this.lblThoiGianToiThieu, this.nudThoiGianToiThieu,
                this.lblThoiGianToiDa, this.nudThoiGianToiDa,
                this.lblDichVuKemTheo, this.txtDichVuKemTheo,
                this.cbIsGoiMacDinh,
                this.btnThem, this.btnSua, this.btnXoa, this.btnReset,
                this.lvPackages
            });

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

