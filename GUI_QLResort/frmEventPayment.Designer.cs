using System.ComponentModel;
using System.Windows.Forms;

namespace GUI_QLResort
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTimMaKH = new System.Windows.Forms.Label();
            this.txtTimMaKH = new System.Windows.Forms.TextBox();
            this.lblTimMaSK = new System.Windows.Forms.Label();
            this.txtTimMaSK = new System.Windows.Forms.TextBox();
            this.lblTimTrangThai = new System.Windows.Forms.Label();
            this.cbTimTrangThai = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lvEventDetails = new System.Windows.Forms.ListView();
            this.gbThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaCTSK = new System.Windows.Forms.Label();
            this.txtMaCTSK = new System.Windows.Forms.TextBox();
            this.lblTenSK = new System.Windows.Forms.Label();
            this.txtTenSK = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblNgayBD = new System.Windows.Forms.Label();
            this.txtNgayBD = new System.Windows.Forms.TextBox();
            this.lblNgayKT = new System.Windows.Forms.Label();
            this.txtNgayKT = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblDaThanhToan = new System.Windows.Forms.Label();
            this.txtDaThanhToan = new System.Windows.Forms.TextBox();
            this.lblConLai = new System.Windows.Forms.Label();
            this.txtConLai = new System.Windows.Forms.TextBox();
            this.gbThanhToan = new System.Windows.Forms.GroupBox();
            this.lblSoTienThanhToan = new System.Windows.Forms.Label();
            this.txtSoTienThanhToan = new System.Windows.Forms.TextBox();
            this.lblPhuongThucThanhToan = new System.Windows.Forms.Label();
            this.cbPhuongThucThanhToan = new System.Windows.Forms.ComboBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbTimKiem.SuspendLayout();
            this.gbThongTin.SuspendLayout();
            this.gbThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(243, 116);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(382, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "💰 Tra Cứu & Thanh Toán Sự Kiện";
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.lblTimMaKH);
            this.gbTimKiem.Controls.Add(this.txtTimMaKH);
            this.gbTimKiem.Controls.Add(this.lblTimMaSK);
            this.gbTimKiem.Controls.Add(this.txtTimMaSK);
            this.gbTimKiem.Controls.Add(this.lblTimTrangThai);
            this.gbTimKiem.Controls.Add(this.cbTimTrangThai);
            this.gbTimKiem.Controls.Add(this.btnTimKiem);
            this.gbTimKiem.Location = new System.Drawing.Point(243, 156);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(1419, 80);
            this.gbTimKiem.TabIndex = 1;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm";
            // 
            // lblTimMaKH
            // 
            this.lblTimMaKH.BackColor = System.Drawing.Color.Transparent;
            this.lblTimMaKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimMaKH.Location = new System.Drawing.Point(115, 28);
            this.lblTimMaKH.Name = "lblTimMaKH";
            this.lblTimMaKH.Size = new System.Drawing.Size(66, 23);
            this.lblTimMaKH.TabIndex = 0;
            this.lblTimMaKH.Text = "Mã KH:";
            // 
            // txtTimMaKH
            // 
            this.txtTimMaKH.Location = new System.Drawing.Point(236, 28);
            this.txtTimMaKH.Name = "txtTimMaKH";
            this.txtTimMaKH.Size = new System.Drawing.Size(243, 20);
            this.txtTimMaKH.TabIndex = 1;
            // 
            // lblTimMaSK
            // 
            this.lblTimMaSK.BackColor = System.Drawing.Color.Transparent;
            this.lblTimMaSK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTimMaSK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimMaSK.Location = new System.Drawing.Point(485, 28);
            this.lblTimMaSK.Name = "lblTimMaSK";
            this.lblTimMaSK.Size = new System.Drawing.Size(100, 23);
            this.lblTimMaSK.TabIndex = 2;
            this.lblTimMaSK.Text = "Mã SK:";
            // 
            // txtTimMaSK
            // 
            this.txtTimMaSK.Location = new System.Drawing.Point(591, 28);
            this.txtTimMaSK.Name = "txtTimMaSK";
            this.txtTimMaSK.Size = new System.Drawing.Size(150, 20);
            this.txtTimMaSK.TabIndex = 3;
            // 
            // lblTimTrangThai
            // 
            this.lblTimTrangThai.BackColor = System.Drawing.Color.Transparent;
            this.lblTimTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimTrangThai.Location = new System.Drawing.Point(756, 28);
            this.lblTimTrangThai.Name = "lblTimTrangThai";
            this.lblTimTrangThai.Size = new System.Drawing.Size(80, 23);
            this.lblTimTrangThai.TabIndex = 4;
            this.lblTimTrangThai.Text = "Trạng thái:";
            // 
            // cbTimTrangThai
            // 
            this.cbTimTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimTrangThai.Items.AddRange(new object[] {
            "Tất cả",
            "Lên kế hoạch",
            "Đang diễn ra",
            "Đã kết thúc",
            "Đã thanh toán đủ"});
            this.cbTimTrangThai.Location = new System.Drawing.Point(865, 28);
            this.cbTimTrangThai.Name = "cbTimTrangThai";
            this.cbTimTrangThai.Size = new System.Drawing.Size(200, 21);
            this.cbTimTrangThai.TabIndex = 5;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(1080, 22);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lvEventDetails
            // 
            this.lvEventDetails.FullRowSelect = true;
            this.lvEventDetails.GridLines = true;
            this.lvEventDetails.HideSelection = false;
            this.lvEventDetails.Location = new System.Drawing.Point(243, 246);
            this.lvEventDetails.Name = "lvEventDetails";
            this.lvEventDetails.Size = new System.Drawing.Size(876, 350);
            this.lvEventDetails.TabIndex = 2;
            this.lvEventDetails.UseCompatibleStateImageBehavior = false;
            this.lvEventDetails.View = System.Windows.Forms.View.Details;
            this.lvEventDetails.SelectedIndexChanged += new System.EventHandler(this.lvEventDetails_SelectedIndexChanged);
            // 
            // gbThongTin
            // 
            this.gbThongTin.Controls.Add(this.lblMaCTSK);
            this.gbThongTin.Controls.Add(this.txtMaCTSK);
            this.gbThongTin.Controls.Add(this.lblTenSK);
            this.gbThongTin.Controls.Add(this.txtTenSK);
            this.gbThongTin.Controls.Add(this.lblTenKH);
            this.gbThongTin.Controls.Add(this.txtTenKH);
            this.gbThongTin.Controls.Add(this.lblNgayBD);
            this.gbThongTin.Controls.Add(this.txtNgayBD);
            this.gbThongTin.Controls.Add(this.lblNgayKT);
            this.gbThongTin.Controls.Add(this.txtNgayKT);
            this.gbThongTin.Controls.Add(this.lblTongTien);
            this.gbThongTin.Controls.Add(this.txtTongTien);
            this.gbThongTin.Controls.Add(this.lblDaThanhToan);
            this.gbThongTin.Controls.Add(this.txtDaThanhToan);
            this.gbThongTin.Controls.Add(this.lblConLai);
            this.gbThongTin.Controls.Add(this.txtConLai);
            this.gbThongTin.Location = new System.Drawing.Point(1140, 246);
            this.gbThongTin.Name = "gbThongTin";
            this.gbThongTin.Size = new System.Drawing.Size(522, 200);
            this.gbThongTin.TabIndex = 3;
            this.gbThongTin.TabStop = false;
            this.gbThongTin.Text = "Thông tin sự kiện";
            // 
            // lblMaCTSK
            // 
            this.lblMaCTSK.Location = new System.Drawing.Point(20, 25);
            this.lblMaCTSK.Name = "lblMaCTSK";
            this.lblMaCTSK.Size = new System.Drawing.Size(100, 23);
            this.lblMaCTSK.TabIndex = 0;
            this.lblMaCTSK.Text = "Mã CTSK:";
            // 
            // txtMaCTSK
            // 
            this.txtMaCTSK.Enabled = false;
            this.txtMaCTSK.Location = new System.Drawing.Point(120, 22);
            this.txtMaCTSK.Name = "txtMaCTSK";
            this.txtMaCTSK.Size = new System.Drawing.Size(346, 20);
            this.txtMaCTSK.TabIndex = 1;
            // 
            // lblTenSK
            // 
            this.lblTenSK.Location = new System.Drawing.Point(20, 55);
            this.lblTenSK.Name = "lblTenSK";
            this.lblTenSK.Size = new System.Drawing.Size(100, 23);
            this.lblTenSK.TabIndex = 2;
            this.lblTenSK.Text = "Tên SK:";
            // 
            // txtTenSK
            // 
            this.txtTenSK.Enabled = false;
            this.txtTenSK.Location = new System.Drawing.Point(120, 52);
            this.txtTenSK.Name = "txtTenSK";
            this.txtTenSK.Size = new System.Drawing.Size(346, 20);
            this.txtTenSK.TabIndex = 3;
            // 
            // lblTenKH
            // 
            this.lblTenKH.Location = new System.Drawing.Point(20, 85);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(100, 23);
            this.lblTenKH.TabIndex = 4;
            this.lblTenKH.Text = "Tên KH:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Enabled = false;
            this.txtTenKH.Location = new System.Drawing.Point(120, 82);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(346, 20);
            this.txtTenKH.TabIndex = 5;
            // 
            // lblNgayBD
            // 
            this.lblNgayBD.Location = new System.Drawing.Point(20, 115);
            this.lblNgayBD.Name = "lblNgayBD";
            this.lblNgayBD.Size = new System.Drawing.Size(100, 23);
            this.lblNgayBD.TabIndex = 6;
            this.lblNgayBD.Text = "Ngày BD:";
            // 
            // txtNgayBD
            // 
            this.txtNgayBD.Enabled = false;
            this.txtNgayBD.Location = new System.Drawing.Point(120, 112);
            this.txtNgayBD.Name = "txtNgayBD";
            this.txtNgayBD.Size = new System.Drawing.Size(150, 20);
            this.txtNgayBD.TabIndex = 7;
            // 
            // lblNgayKT
            // 
            this.lblNgayKT.Location = new System.Drawing.Point(291, 115);
            this.lblNgayKT.Name = "lblNgayKT";
            this.lblNgayKT.Size = new System.Drawing.Size(54, 23);
            this.lblNgayKT.TabIndex = 8;
            this.lblNgayKT.Text = "Ngày KT:";
            // 
            // txtNgayKT
            // 
            this.txtNgayKT.Enabled = false;
            this.txtNgayKT.Location = new System.Drawing.Point(351, 112);
            this.txtNgayKT.Name = "txtNgayKT";
            this.txtNgayKT.Size = new System.Drawing.Size(115, 20);
            this.txtNgayKT.TabIndex = 9;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Location = new System.Drawing.Point(20, 145);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(100, 23);
            this.lblTongTien.TabIndex = 10;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(120, 142);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(150, 20);
            this.txtTongTien.TabIndex = 11;
            // 
            // lblDaThanhToan
            // 
            this.lblDaThanhToan.Location = new System.Drawing.Point(291, 145);
            this.lblDaThanhToan.Name = "lblDaThanhToan";
            this.lblDaThanhToan.Size = new System.Drawing.Size(54, 23);
            this.lblDaThanhToan.TabIndex = 12;
            this.lblDaThanhToan.Text = "Đã TT:";
            // 
            // txtDaThanhToan
            // 
            this.txtDaThanhToan.Enabled = false;
            this.txtDaThanhToan.Location = new System.Drawing.Point(351, 142);
            this.txtDaThanhToan.Name = "txtDaThanhToan";
            this.txtDaThanhToan.Size = new System.Drawing.Size(115, 20);
            this.txtDaThanhToan.TabIndex = 13;
            // 
            // lblConLai
            // 
            this.lblConLai.Location = new System.Drawing.Point(20, 175);
            this.lblConLai.Name = "lblConLai";
            this.lblConLai.Size = new System.Drawing.Size(100, 23);
            this.lblConLai.TabIndex = 14;
            this.lblConLai.Text = "Còn lại:";
            // 
            // txtConLai
            // 
            this.txtConLai.Enabled = false;
            this.txtConLai.Location = new System.Drawing.Point(120, 172);
            this.txtConLai.Name = "txtConLai";
            this.txtConLai.Size = new System.Drawing.Size(150, 20);
            this.txtConLai.TabIndex = 15;
            // 
            // gbThanhToan
            // 
            this.gbThanhToan.Controls.Add(this.lblSoTienThanhToan);
            this.gbThanhToan.Controls.Add(this.txtSoTienThanhToan);
            this.gbThanhToan.Controls.Add(this.lblPhuongThucThanhToan);
            this.gbThanhToan.Controls.Add(this.cbPhuongThucThanhToan);
            this.gbThanhToan.Controls.Add(this.lblGhiChu);
            this.gbThanhToan.Controls.Add(this.txtGhiChu);
            this.gbThanhToan.Location = new System.Drawing.Point(1140, 456);
            this.gbThanhToan.Name = "gbThanhToan";
            this.gbThanhToan.Size = new System.Drawing.Size(522, 140);
            this.gbThanhToan.TabIndex = 4;
            this.gbThanhToan.TabStop = false;
            this.gbThanhToan.Text = "Thanh toán";
            // 
            // lblSoTienThanhToan
            // 
            this.lblSoTienThanhToan.Location = new System.Drawing.Point(20, 25);
            this.lblSoTienThanhToan.Name = "lblSoTienThanhToan";
            this.lblSoTienThanhToan.Size = new System.Drawing.Size(100, 23);
            this.lblSoTienThanhToan.TabIndex = 0;
            this.lblSoTienThanhToan.Text = "Số tiền thanh toán:";
            // 
            // txtSoTienThanhToan
            // 
            this.txtSoTienThanhToan.Location = new System.Drawing.Point(150, 22);
            this.txtSoTienThanhToan.Name = "txtSoTienThanhToan";
            this.txtSoTienThanhToan.Size = new System.Drawing.Size(316, 20);
            this.txtSoTienThanhToan.TabIndex = 1;
            this.txtSoTienThanhToan.TextChanged += new System.EventHandler(this.txtSoTienThanhToan_TextChanged);
            // 
            // lblPhuongThucThanhToan
            // 
            this.lblPhuongThucThanhToan.Location = new System.Drawing.Point(20, 55);
            this.lblPhuongThucThanhToan.Name = "lblPhuongThucThanhToan";
            this.lblPhuongThucThanhToan.Size = new System.Drawing.Size(100, 23);
            this.lblPhuongThucThanhToan.TabIndex = 2;
            this.lblPhuongThucThanhToan.Text = "Phương thức:";
            // 
            // cbPhuongThucThanhToan
            // 
            this.cbPhuongThucThanhToan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhuongThucThanhToan.Location = new System.Drawing.Point(150, 52);
            this.cbPhuongThucThanhToan.Name = "cbPhuongThucThanhToan";
            this.cbPhuongThucThanhToan.Size = new System.Drawing.Size(316, 21);
            this.cbPhuongThucThanhToan.TabIndex = 3;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(20, 85);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(100, 23);
            this.lblGhiChu.TabIndex = 4;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(150, 82);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(316, 50);
            this.txtGhiChu.TabIndex = 5;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(1512, 606);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(150, 40);
            this.btnThanhToan.TabIndex = 5;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(1400, 606);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Đóng";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmEventPayment
            // 
            this.ClientSize = new System.Drawing.Size(1676, 652);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbTimKiem);
            this.Controls.Add(this.lvEventDetails);
            this.Controls.Add(this.gbThongTin);
            this.Controls.Add(this.gbThanhToan);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnHuy);
            this.Name = "frmEventPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra Cứu & Thanh Toán Sự Kiện";
            this.Load += new System.EventHandler(this.frmEventPayment_Load);
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            this.gbThongTin.ResumeLayout(false);
            this.gbThongTin.PerformLayout();
            this.gbThanhToan.ResumeLayout(false);
            this.gbThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

