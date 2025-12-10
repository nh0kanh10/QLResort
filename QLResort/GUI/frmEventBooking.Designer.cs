using System.ComponentModel;
using System.Windows.Forms;

namespace QLResort.GUI
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
            this.gbThongTinSuKien = new System.Windows.Forms.GroupBox();
            this.gbGoiSuKien = new System.Windows.Forms.GroupBox();
            this.gbThanhToan = new System.Windows.Forms.GroupBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.SuspendLayout();

            // Initialize all controls
            {
                // Title
                this.lblTitle = new System.Windows.Forms.Label();
                this.lblTitle.Text = "✨ ĐẶT SỰ KIỆN";
                this.lblTitle.Font = new System.Drawing.Font("Cambria", 18, System.Drawing.FontStyle.Bold);
                this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 215, 0);
                this.lblTitle.AutoSize = true;
                this.lblTitle.Location = new System.Drawing.Point(20, 10);

                // GroupBox Khách hàng
                this.gbKhachHang = new System.Windows.Forms.GroupBox();
                this.gbKhachHang.Text = "Thông tin khách hàng";
                this.gbKhachHang.Location = new System.Drawing.Point(20, 50);
                this.gbKhachHang.Size = new System.Drawing.Size(600, 120);

                this.lblMaKH = new System.Windows.Forms.Label();
                this.lblMaKH.Text = "Mã KH:";
                this.lblMaKH.Location = new System.Drawing.Point(20, 25);
                this.txtMaKH = new System.Windows.Forms.TextBox();
                this.txtMaKH.Enabled = false;
                this.txtMaKH.Location = new System.Drawing.Point(100, 22);
                this.txtMaKH.Size = new System.Drawing.Size(150, 20);

                this.lblTenKH = new System.Windows.Forms.Label();
                this.lblTenKH.Text = "Tên KH:";
                this.lblTenKH.Location = new System.Drawing.Point(270, 25);
                this.txtTenKH = new System.Windows.Forms.TextBox();
                this.txtTenKH.Enabled = false;
                this.txtTenKH.Location = new System.Drawing.Point(340, 22);
                this.txtTenKH.Size = new System.Drawing.Size(200, 20);

                this.lblSDT = new System.Windows.Forms.Label();
                this.lblSDT.Text = "SĐT:";
                this.lblSDT.Location = new System.Drawing.Point(20, 55);
                this.txtSDT = new System.Windows.Forms.TextBox();
                this.txtSDT.Enabled = false;
                this.txtSDT.Location = new System.Drawing.Point(100, 52);
                this.txtSDT.Size = new System.Drawing.Size(150, 20);

                this.lblEmail = new System.Windows.Forms.Label();
                this.lblEmail.Text = "Email:";
                this.lblEmail.Location = new System.Drawing.Point(270, 55);
                this.txtEmail = new System.Windows.Forms.TextBox();
                this.txtEmail.Enabled = false;
                this.txtEmail.Location = new System.Drawing.Point(340, 52);
                this.txtEmail.Size = new System.Drawing.Size(200, 20);

                this.btnChonKhachHang = new System.Windows.Forms.Button();
                this.btnChonKhachHang.Text = "Chọn khách hàng";
                this.btnChonKhachHang.Location = new System.Drawing.Point(100, 80);
                this.btnChonKhachHang.Size = new System.Drawing.Size(150, 30);
                this.btnChonKhachHang.Click += new System.EventHandler(this.btnChonKhachHang_Click);

                this.gbKhachHang.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaKH, this.txtMaKH, this.lblTenKH, this.txtTenKH,
                this.lblSDT, this.txtSDT, this.lblEmail, this.txtEmail,
                this.btnChonKhachHang
            });

                // GroupBox Thông tin sự kiện
                this.gbThongTinSuKien = new System.Windows.Forms.GroupBox();
                this.gbThongTinSuKien.Text = "Thông tin sự kiện";
                this.gbThongTinSuKien.Location = new System.Drawing.Point(20, 180);
                this.gbThongTinSuKien.Size = new System.Drawing.Size(600, 120);

                this.lBUSoaiSuKien = new System.Windows.Forms.Label();
                this.lBUSoaiSuKien.Text = "Loại sự kiện:";
                this.lBUSoaiSuKien.Location = new System.Drawing.Point(20, 25);
                this.cbLoaiSuKien = new System.Windows.Forms.ComboBox();
                this.cbLoaiSuKien.Location = new System.Drawing.Point(120, 22);
                this.cbLoaiSuKien.Size = new System.Drawing.Size(200, 21);
                this.cbLoaiSuKien.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbLoaiSuKien.SelectedIndexChanged += new System.EventHandler(this.cbLoaiSuKien_SelectedIndexChanged);

                this.lblMaCN = new System.Windows.Forms.Label();
                this.lblMaCN.Text = "Chi nhánh:";
                this.lblMaCN.Location = new System.Drawing.Point(340, 25);
                this.cbMaCN = new System.Windows.Forms.ComboBox();
                this.cbMaCN.Location = new System.Drawing.Point(420, 22);
                this.cbMaCN.Size = new System.Drawing.Size(150, 21);
                this.cbMaCN.DropDownStyle = ComboBoxStyle.DropDownList;

                this.lblNgayBD = new System.Windows.Forms.Label();
                this.lblNgayBD.Text = "Ngày bắt đầu:";
                this.lblNgayBD.Location = new System.Drawing.Point(20, 55);
                this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
                this.dtpNgayBD.Location = new System.Drawing.Point(120, 52);
                this.dtpNgayBD.Size = new System.Drawing.Size(200, 20);
                this.dtpNgayBD.ValueChanged += new System.EventHandler(this.dtpNgayBD_ValueChanged);

                this.lblNgayKT = new System.Windows.Forms.Label();
                this.lblNgayKT.Text = "Ngày kết thúc:";
                this.lblNgayKT.Location = new System.Drawing.Point(340, 55);
                this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
                this.dtpNgayKT.Location = new System.Drawing.Point(420, 52);
                this.dtpNgayKT.Size = new System.Drawing.Size(200, 20);
                this.dtpNgayKT.ValueChanged += new System.EventHandler(this.dtpNgayKT_ValueChanged);

                this.lblTongKhach = new System.Windows.Forms.Label();
                this.lblTongKhach.Text = "Tổng số khách:";
                this.lblTongKhach.Location = new System.Drawing.Point(20, 85);
                this.txtTongKhach = new System.Windows.Forms.NumericUpDown();
                this.txtTongKhach.Location = new System.Drawing.Point(120, 82);
                this.txtTongKhach.Size = new System.Drawing.Size(100, 20);
                this.txtTongKhach.Minimum = 1;
                this.txtTongKhach.Maximum = 10000;
                this.txtTongKhach.ValueChanged += new System.EventHandler(this.txtTongKhach_ValueChanged);

                this.gbThongTinSuKien.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lBUSoaiSuKien, this.cbLoaiSuKien, this.lblMaCN, this.cbMaCN,
                this.lblNgayBD, this.dtpNgayBD, this.lblNgayKT, this.dtpNgayKT,
                this.lblTongKhach, this.txtTongKhach
            });

                // GroupBox Gói sự kiện
                this.gbGoiSuKien = new System.Windows.Forms.GroupBox();
                this.gbGoiSuKien.Text = "Chọn gói sự kiện";
                this.gbGoiSuKien.Location = new System.Drawing.Point(640, 50);
                this.gbGoiSuKien.Size = new System.Drawing.Size(600, 400);

                this.lvGoiSuKien = new System.Windows.Forms.ListView();
                this.lvGoiSuKien.Location = new System.Drawing.Point(20, 25);
                this.lvGoiSuKien.Size = new System.Drawing.Size(560, 150);
                this.lvGoiSuKien.FullRowSelect = true;
                this.lvGoiSuKien.GridLines = true;
                this.lvGoiSuKien.View = System.Windows.Forms.View.Details;
                this.lvGoiSuKien.Columns.Add("Mã gói", 80);
                this.lvGoiSuKien.Columns.Add("Tên gói", 200);
                this.lvGoiSuKien.Columns.Add("Giá", 120);
                this.lvGoiSuKien.Columns.Add("Khách min", 80);
                this.lvGoiSuKien.Columns.Add("Khách max", 100);
                this.lvGoiSuKien.Columns.Add("Loại", 80);
                this.lvGoiSuKien.SelectedIndexChanged += new System.EventHandler(this.lvGoiSuKien_SelectedIndexChanged);

                this.lblMaGoiSK = new System.Windows.Forms.Label();
                this.lblMaGoiSK.Text = "Mã gói:";
                this.lblMaGoiSK.Location = new System.Drawing.Point(20, 185);
                this.txtMaGoiSK = new System.Windows.Forms.TextBox();
                this.txtMaGoiSK.Enabled = false;
                this.txtMaGoiSK.Location = new System.Drawing.Point(100, 182);
                this.txtMaGoiSK.Size = new System.Drawing.Size(150, 20);

                this.lblTenGoiSK = new System.Windows.Forms.Label();
                this.lblTenGoiSK.Text = "Tên gói:";
                this.lblTenGoiSK.Location = new System.Drawing.Point(270, 185);
                this.txtTenGoiSK = new System.Windows.Forms.TextBox();
                this.txtTenGoiSK.Enabled = false;
                this.txtTenGoiSK.Location = new System.Drawing.Point(340, 182);
                this.txtTenGoiSK.Size = new System.Drawing.Size(240, 20);

                this.lblGiaCoBan = new System.Windows.Forms.Label();
                this.lblGiaCoBan.Text = "Giá cơ bản:";
                this.lblGiaCoBan.Location = new System.Drawing.Point(20, 215);
                this.txtGiaCoBan = new System.Windows.Forms.TextBox();
                this.txtGiaCoBan.Enabled = false;
                this.txtGiaCoBan.Location = new System.Drawing.Point(100, 212);
                this.txtGiaCoBan.Size = new System.Drawing.Size(200, 20);

                this.lblDichVuKemTheo = new System.Windows.Forms.Label();
                this.lblDichVuKemTheo.Text = "Dịch vụ kèm theo:";
                this.lblDichVuKemTheo.Location = new System.Drawing.Point(20, 245);
                this.txtDichVuKemTheo = new System.Windows.Forms.TextBox();
                this.txtDichVuKemTheo.Enabled = false;
                this.txtDichVuKemTheo.Location = new System.Drawing.Point(120, 242);
                this.txtDichVuKemTheo.Size = new System.Drawing.Size(460, 20);
                this.txtDichVuKemTheo.Multiline = true;
                this.txtDichVuKemTheo.Height = 60;

                this.btnTaoGoiCustom = new System.Windows.Forms.Button();
                this.btnTaoGoiCustom.Text = "Tạo gói custom";
                this.btnTaoGoiCustom.Location = new System.Drawing.Point(420, 310);
                this.btnTaoGoiCustom.Size = new System.Drawing.Size(160, 35);
                this.btnTaoGoiCustom.Click += new System.EventHandler(this.btnTaoGoiCustom_Click);

                this.gbGoiSuKien.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lvGoiSuKien, this.lblMaGoiSK, this.txtMaGoiSK,
                this.lblTenGoiSK, this.txtTenGoiSK, this.lblGiaCoBan, this.txtGiaCoBan,
                this.lblDichVuKemTheo, this.txtDichVuKemTheo, this.btnTaoGoiCustom
            });

                // GroupBox Thanh toán
                this.gbThanhToan = new System.Windows.Forms.GroupBox();
                this.gbThanhToan.Text = "Thanh toán";
                this.gbThanhToan.Location = new System.Drawing.Point(20, 310);
                this.gbThanhToan.Size = new System.Drawing.Size(600, 140);

                this.lblTongTien = new System.Windows.Forms.Label();
                this.lblTongTien.Text = "Tổng tiền:";
                this.lblTongTien.Location = new System.Drawing.Point(20, 25);
                this.txtTongTien = new System.Windows.Forms.TextBox();
                this.txtTongTien.Enabled = false;
                this.txtTongTien.Location = new System.Drawing.Point(120, 22);
                this.txtTongTien.Size = new System.Drawing.Size(200, 20);

                this.lblDatCoc = new System.Windows.Forms.Label();
                this.lblDatCoc.Text = "Đặt cọc (30%):";
                this.lblDatCoc.Location = new System.Drawing.Point(340, 25);
                this.txtDatCoc = new System.Windows.Forms.TextBox();
                this.txtDatCoc.Enabled = false;
                this.txtDatCoc.Location = new System.Drawing.Point(450, 22);
                this.txtDatCoc.Size = new System.Drawing.Size(140, 20);

                this.lblConLai = new System.Windows.Forms.Label();
                this.lblConLai.Text = "Còn lại:";
                this.lblConLai.Location = new System.Drawing.Point(20, 55);
                this.txtConLai = new System.Windows.Forms.TextBox();
                this.txtConLai.Enabled = false;
                this.txtConLai.Location = new System.Drawing.Point(120, 52);
                this.txtConLai.Size = new System.Drawing.Size(200, 20);

                this.lblPhuongThucThanhToan = new System.Windows.Forms.Label();
                this.lblPhuongThucThanhToan.Text = "Phương thức:";
                this.lblPhuongThucThanhToan.Location = new System.Drawing.Point(340, 55);
                this.cbPhuongThucThanhToan = new System.Windows.Forms.ComboBox();
                this.cbPhuongThucThanhToan.Location = new System.Drawing.Point(450, 52);
                this.cbPhuongThucThanhToan.Size = new System.Drawing.Size(140, 21);
                this.cbPhuongThucThanhToan.DropDownStyle = ComboBoxStyle.DropDownList;

                this.lblGhiChu = new System.Windows.Forms.Label();
                this.lblGhiChu.Text = "Ghi chú:";
                this.lblGhiChu.Location = new System.Drawing.Point(20, 85);
                this.txtGhiChu = new System.Windows.Forms.TextBox();
                this.txtGhiChu.Location = new System.Drawing.Point(120, 82);
                this.txtGhiChu.Size = new System.Drawing.Size(470, 20);
                this.txtGhiChu.Multiline = true;
                this.txtGhiChu.Height = 50;

                this.gbThanhToan.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTongTien, this.txtTongTien, this.lblDatCoc, this.txtDatCoc,
                this.lblConLai, this.txtConLai, this.lblPhuongThucThanhToan, this.cbPhuongThucThanhToan,
                this.lblGhiChu, this.txtGhiChu
            });

                // Buttons
                this.btnXacNhan = new System.Windows.Forms.Button();
                this.btnXacNhan.Text = "Xác nhận đặt sự kiện";
                this.btnXacNhan.Location = new System.Drawing.Point(900, 470);
                this.btnXacNhan.Size = new System.Drawing.Size(160, 40);
                this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);

                this.btnHuy = new System.Windows.Forms.Button();
                this.btnHuy.Text = "Hủy";
                this.btnHuy.Location = new System.Drawing.Point(1080, 470);
                this.btnHuy.Size = new System.Drawing.Size(100, 40);
                this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

                // Setup layout
                this.Text = "Đặt Sự Kiện";
                this.Size = new System.Drawing.Size(1280, 550);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Load += new System.EventHandler(this.frmEventBooking_Load);

                this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle,
                this.gbKhachHang,
                this.gbThongTinSuKien,
                this.gbGoiSuKien,
                this.gbThanhToan,
                this.btnXacNhan,
                this.btnHuy
            });

                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }
    }
}

