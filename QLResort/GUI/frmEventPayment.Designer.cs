using System.ComponentModel;
using System.Windows.Forms;

namespace QLResort.GUI
{
    partial class frmEventPayment
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.Label lblTimMaKH;
        private System.Windows.Forms.TextBox txtTimMaKH;
        private System.Windows.Forms.Label lblTimMaSK;
        private System.Windows.Forms.TextBox txtTimMaSK;
        private System.Windows.Forms.Label lblTimTrangThai;
        private System.Windows.Forms.ComboBox cbTimTrangThai;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ListView lvEventDetails;
        private System.Windows.Forms.GroupBox gbThongTin;
        private System.Windows.Forms.Label lblMaCTSK;
        private System.Windows.Forms.TextBox txtMaCTSK;
        private System.Windows.Forms.Label lblTenSK;
        private System.Windows.Forms.TextBox txtTenSK;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblNgayBD;
        private System.Windows.Forms.TextBox txtNgayBD;
        private System.Windows.Forms.Label lblNgayKT;
        private System.Windows.Forms.TextBox txtNgayKT;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label lblDaThanhToan;
        private System.Windows.Forms.TextBox txtDaThanhToan;
        private System.Windows.Forms.Label lblConLai;
        private System.Windows.Forms.TextBox txtConLai;
        private System.Windows.Forms.GroupBox gbThanhToan;
        private System.Windows.Forms.Label lblSoTienThanhToan;
        private System.Windows.Forms.TextBox txtSoTienThanhToan;
        private System.Windows.Forms.Label lblPhuongThucThanhToan;
        private System.Windows.Forms.ComboBox cbPhuongThucThanhToan;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThanhToan;
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
            this.SuspendLayout();

            // InitializeControls
            {
                // Title
                this.lblTitle = new System.Windows.Forms.Label();
                this.lblTitle.Text = "💰 Tra Cứu & Thanh Toán Sự Kiện";
                this.lblTitle.Font = new System.Drawing.Font("Cambria", 18, System.Drawing.FontStyle.Bold);
                this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(255, 215, 0);
                this.lblTitle.AutoSize = true;
                this.lblTitle.Location = new System.Drawing.Point(20, 10);

                // GroupBox Tìm kiếm
                this.gbTimKiem = new System.Windows.Forms.GroupBox();
                this.gbTimKiem.Text = "Tìm kiếm";
                this.gbTimKiem.Location = new System.Drawing.Point(20, 50);
                this.gbTimKiem.Size = new System.Drawing.Size(1200, 80);

                this.lblTimMaKH = new System.Windows.Forms.Label();
                this.lblTimMaKH.Text = "Mã KH:";
                this.lblTimMaKH.Location = new System.Drawing.Point(20, 25);
                this.txtTimMaKH = new System.Windows.Forms.TextBox();
                this.txtTimMaKH.Location = new System.Drawing.Point(100, 22);
                this.txtTimMaKH.Size = new System.Drawing.Size(150, 20);

                this.lblTimMaSK = new System.Windows.Forms.Label();
                this.lblTimMaSK.Text = "Mã SK:";
                this.lblTimMaSK.Location = new System.Drawing.Point(270, 25);
                this.txtTimMaSK = new System.Windows.Forms.TextBox();
                this.txtTimMaSK.Location = new System.Drawing.Point(340, 22);
                this.txtTimMaSK.Size = new System.Drawing.Size(150, 20);

                this.lblTimTrangThai = new System.Windows.Forms.Label();
                this.lblTimTrangThai.Text = "Trạng thái:";
                this.lblTimTrangThai.Location = new System.Drawing.Point(510, 25);
                this.cbTimTrangThai = new System.Windows.Forms.ComboBox();
                this.cbTimTrangThai.Location = new System.Drawing.Point(600, 22);
                this.cbTimTrangThai.Size = new System.Drawing.Size(200, 21);
                this.cbTimTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbTimTrangThai.Items.AddRange(new object[] { "Tất cả", "Lên kế hoạch", "Đang diễn ra", "Đã kết thúc", "Đã thanh toán đủ" });
                this.cbTimTrangThai.SelectedIndex = 0;

                this.btnTimKiem = new System.Windows.Forms.Button();
                this.btnTimKiem.Text = "Tìm kiếm";
                this.btnTimKiem.Location = new System.Drawing.Point(820, 20);
                this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
                this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

                this.gbTimKiem.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTimMaKH, this.txtTimMaKH, this.lblTimMaSK, this.txtTimMaSK,
                this.lblTimTrangThai, this.cbTimTrangThai, this.btnTimKiem
            });

                // ListView
                this.lvEventDetails = new System.Windows.Forms.ListView();
                this.lvEventDetails.Location = new System.Drawing.Point(20, 140);
                this.lvEventDetails.Size = new System.Drawing.Size(800, 300);
                this.lvEventDetails.FullRowSelect = true;
                this.lvEventDetails.GridLines = true;
                this.lvEventDetails.View = System.Windows.Forms.View.Details;
                this.lvEventDetails.Columns.Add("Mã CTSK", 100);
                this.lvEventDetails.Columns.Add("Tên SK", 200);
                this.lvEventDetails.Columns.Add("Tên KH", 150);
                this.lvEventDetails.Columns.Add("Ngày BD", 100);
                this.lvEventDetails.Columns.Add("Ngày KT", 100);
                this.lvEventDetails.Columns.Add("Tổng tiền", 120);
                this.lvEventDetails.Columns.Add("Đã TT", 120);
                this.lvEventDetails.Columns.Add("Còn lại", 120);
                this.lvEventDetails.Columns.Add("Trạng thái", 120);
                this.lvEventDetails.SelectedIndexChanged += new System.EventHandler(this.lvEventDetails_SelectedIndexChanged);

                // GroupBox Thông tin
                this.gbThongTin = new System.Windows.Forms.GroupBox();
                this.gbThongTin.Text = "Thông tin sự kiện";
                this.gbThongTin.Location = new System.Drawing.Point(840, 140);
                this.gbThongTin.Size = new System.Drawing.Size(380, 200);

                this.lblMaCTSK = new System.Windows.Forms.Label();
                this.lblMaCTSK.Text = "Mã CTSK:";
                this.lblMaCTSK.Location = new System.Drawing.Point(20, 25);
                this.txtMaCTSK = new System.Windows.Forms.TextBox();
                this.txtMaCTSK.Enabled = false;
                this.txtMaCTSK.Location = new System.Drawing.Point(120, 22);
                this.txtMaCTSK.Size = new System.Drawing.Size(150, 20);

                this.lblTenSK = new System.Windows.Forms.Label();
                this.lblTenSK.Text = "Tên SK:";
                this.lblTenSK.Location = new System.Drawing.Point(20, 55);
                this.txtTenSK = new System.Windows.Forms.TextBox();
                this.txtTenSK.Enabled = false;
                this.txtTenSK.Location = new System.Drawing.Point(120, 52);
                this.txtTenSK.Size = new System.Drawing.Size(240, 20);

                this.lblTenKH = new System.Windows.Forms.Label();
                this.lblTenKH.Text = "Tên KH:";
                this.lblTenKH.Location = new System.Drawing.Point(20, 85);
                this.txtTenKH = new System.Windows.Forms.TextBox();
                this.txtTenKH.Enabled = false;
                this.txtTenKH.Location = new System.Drawing.Point(120, 82);
                this.txtTenKH.Size = new System.Drawing.Size(240, 20);

                this.lblNgayBD = new System.Windows.Forms.Label();
                this.lblNgayBD.Text = "Ngày BD:";
                this.lblNgayBD.Location = new System.Drawing.Point(20, 115);
                this.txtNgayBD = new System.Windows.Forms.TextBox();
                this.txtNgayBD.Enabled = false;
                this.txtNgayBD.Location = new System.Drawing.Point(120, 112);
                this.txtNgayBD.Size = new System.Drawing.Size(150, 20);

                this.lblNgayKT = new System.Windows.Forms.Label();
                this.lblNgayKT.Text = "Ngày KT:";
                this.lblNgayKT.Location = new System.Drawing.Point(280, 115);
                this.txtNgayKT = new System.Windows.Forms.TextBox();
                this.txtNgayKT.Enabled = false;
                this.txtNgayKT.Location = new System.Drawing.Point(340, 112);
                this.txtNgayKT.Size = new System.Drawing.Size(30, 20);

                this.lblTongTien = new System.Windows.Forms.Label();
                this.lblTongTien.Text = "Tổng tiền:";
                this.lblTongTien.Location = new System.Drawing.Point(20, 145);
                this.txtTongTien = new System.Windows.Forms.TextBox();
                this.txtTongTien.Enabled = false;
                this.txtTongTien.Location = new System.Drawing.Point(120, 142);
                this.txtTongTien.Size = new System.Drawing.Size(150, 20);

                this.lblDaThanhToan = new System.Windows.Forms.Label();
                this.lblDaThanhToan.Text = "Đã TT:";
                this.lblDaThanhToan.Location = new System.Drawing.Point(280, 145);
                this.txtDaThanhToan = new System.Windows.Forms.TextBox();
                this.txtDaThanhToan.Enabled = false;
                this.txtDaThanhToan.Location = new System.Drawing.Point(340, 142);
                this.txtDaThanhToan.Size = new System.Drawing.Size(30, 20);

                this.lblConLai = new System.Windows.Forms.Label();
                this.lblConLai.Text = "Còn lại:";
                this.lblConLai.Location = new System.Drawing.Point(20, 175);
                this.txtConLai = new System.Windows.Forms.TextBox();
                this.txtConLai.Enabled = false;
                this.txtConLai.Location = new System.Drawing.Point(120, 172);
                this.txtConLai.Size = new System.Drawing.Size(150, 20);

                this.gbThongTin.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblMaCTSK, this.txtMaCTSK, this.lblTenSK, this.txtTenSK,
                this.lblTenKH, this.txtTenKH, this.lblNgayBD, this.txtNgayBD,
                this.lblNgayKT, this.txtNgayKT, this.lblTongTien, this.txtTongTien,
                this.lblDaThanhToan, this.txtDaThanhToan, this.lblConLai, this.txtConLai
            });

                // GroupBox Thanh toán
                this.gbThanhToan = new System.Windows.Forms.GroupBox();
                this.gbThanhToan.Text = "Thanh toán";
                this.gbThanhToan.Location = new System.Drawing.Point(840, 350);
                this.gbThanhToan.Size = new System.Drawing.Size(380, 140);

                this.lblSoTienThanhToan = new System.Windows.Forms.Label();
                this.lblSoTienThanhToan.Text = "Số tiền thanh toán:";
                this.lblSoTienThanhToan.Location = new System.Drawing.Point(20, 25);
                this.txtSoTienThanhToan = new System.Windows.Forms.TextBox();
                this.txtSoTienThanhToan.Location = new System.Drawing.Point(150, 22);
                this.txtSoTienThanhToan.Size = new System.Drawing.Size(210, 20);
                this.txtSoTienThanhToan.TextChanged += new System.EventHandler(this.txtSoTienThanhToan_TextChanged);

                this.lblPhuongThucThanhToan = new System.Windows.Forms.Label();
                this.lblPhuongThucThanhToan.Text = "Phương thức:";
                this.lblPhuongThucThanhToan.Location = new System.Drawing.Point(20, 55);
                this.cbPhuongThucThanhToan = new System.Windows.Forms.ComboBox();
                this.cbPhuongThucThanhToan.Location = new System.Drawing.Point(150, 52);
                this.cbPhuongThucThanhToan.Size = new System.Drawing.Size(210, 21);
                this.cbPhuongThucThanhToan.DropDownStyle = ComboBoxStyle.DropDownList;

                this.lblGhiChu = new System.Windows.Forms.Label();
                this.lblGhiChu.Text = "Ghi chú:";
                this.lblGhiChu.Location = new System.Drawing.Point(20, 85);
                this.txtGhiChu = new System.Windows.Forms.TextBox();
                this.txtGhiChu.Location = new System.Drawing.Point(150, 82);
                this.txtGhiChu.Size = new System.Drawing.Size(210, 20);
                this.txtGhiChu.Multiline = true;
                this.txtGhiChu.Height = 50;

                this.gbThanhToan.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblSoTienThanhToan, this.txtSoTienThanhToan,
                this.lblPhuongThucThanhToan, this.cbPhuongThucThanhToan,
                this.lblGhiChu, this.txtGhiChu
            });

                // Buttons
                this.btnThanhToan = new System.Windows.Forms.Button();
                this.btnThanhToan.Text = "Thanh toán";
                this.btnThanhToan.Location = new System.Drawing.Point(840, 500);
                this.btnThanhToan.Size = new System.Drawing.Size(150, 40);
                this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

                this.btnHuy = new System.Windows.Forms.Button();
                this.btnHuy.Text = "Đóng";
                this.btnHuy.Location = new System.Drawing.Point(1010, 500);
                this.btnHuy.Size = new System.Drawing.Size(100, 40);
                this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

                this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);

                // SetupLayout
                this.Text = "Tra Cứu & Thanh Toán Sự Kiện";
                this.Size = new System.Drawing.Size(1250, 570);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Load += new System.EventHandler(this.frmEventPayment_Load);

                this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblTitle,
                this.gbTimKiem,
                this.lvEventDetails,
                this.gbThongTin,
                this.gbThanhToan,
                this.btnThanhToan,
                this.btnHuy
            });

                ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }
    }
}

