using QLResort.GUI.Styles;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    partial class frmPayment
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaHD, lblMaKH, lblTenKH, lblCouponCode, lblGiamGia, lblTongTruocKM, lblTongTien, lblSoTien, lBUSoaiTT, lblNgayTT;
        private System.Windows.Forms.TextBox txtMaHD, txtMaKH, txtTenKH, txtCouponCode, txtGiamGia, txtTongTruocKM, txtTongTien;
        private System.Windows.Forms.ComboBox cbLoaiTT;
        private System.Windows.Forms.DateTimePicker dtpNgayTT;
        private System.Windows.Forms.Button btnApDungKM, btnThanhToan;
        private System.Windows.Forms.ListView lvInvoices, lvPayments;
        private System.Windows.Forms.Label lblTongTienSummary, lblDaThanhToan, lblConLai;
        private System.Windows.Forms.GroupBox gbThongTinHD, gbThanhToan, gbLichSuTT;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void ApplyPaymentTheme()
        {
            // Áp dụng chung toàn form
            AppTheme.ApplyForm(this);

            // Style GroupBox
            foreach (var gb in this.Controls.OfType<GroupBox>())
                AppTheme.StyleGroupBox(gb);

            // Style Textbox
            foreach (var txt in this.Controls.OfType<TextBox>())
                AppTheme.StyleTextBox(txt);

            // Style ComboBox
            foreach (var cb in this.Controls.OfType<ComboBox>())
                AppTheme.StyleComboBox(cb);

            // Style NumericUpDown
            foreach (var num in this.Controls.OfType<NumericUpDown>())
                AppTheme.StyleNumericUpDown(num);

            // Style DateTimePicker
            foreach (var dtp in this.Controls.OfType<DateTimePicker>())
                AppTheme.StyleDateTimePicker(dtp);

            // Style Label
            foreach (var lbl in this.Controls.OfType<Label>())
                AppTheme.StyleLabel(lbl);

            // Style ListView
            foreach (var lv in this.Controls.OfType<ListView>())
                AppTheme.StyleListView(lv);

            // Style Buttons
            AppTheme.StylePrimaryButton(btnThanhToan);
            AppTheme.StyleSecondaryButton(btnApDungKM);

            // Style Header mạnh hơn
            lblTongTien.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTongTien.ForeColor = AppTheme.PrimaryColor;

            lblConLai.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            lblConLai.ForeColor = Color.Red;
        }
        private void InitializeComponent()
        {
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblCouponCode = new System.Windows.Forms.Label();
            this.txtCouponCode = new System.Windows.Forms.TextBox();
            this.btnApDungKM = new System.Windows.Forms.Button();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.lblTongTruocKM = new System.Windows.Forms.Label();
            this.txtTongTruocKM = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.lBUSoaiTT = new System.Windows.Forms.Label();
            this.cbLoaiTT = new System.Windows.Forms.ComboBox();
            this.lblNgayTT = new System.Windows.Forms.Label();
            this.dtpNgayTT = new System.Windows.Forms.DateTimePicker();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lvInvoices = new System.Windows.Forms.ListView();
            this.lvPayments = new System.Windows.Forms.ListView();
            this.lblTongTienSummary = new System.Windows.Forms.Label();
            this.lblDaThanhToan = new System.Windows.Forms.Label();
            this.lblConLai = new System.Windows.Forms.Label();
            this.gbThongTinHD = new System.Windows.Forms.GroupBox();
            this.gbThanhToan = new System.Windows.Forms.GroupBox();
            this.gbLichSuTT = new System.Windows.Forms.GroupBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.gbThongTinHD.SuspendLayout();
            this.gbThanhToan.SuspendLayout();
            this.gbLichSuTT.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(13, 31);
            this.lblMaHD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(51, 16);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã HĐ:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Enabled = false;
            this.txtMaHD.Location = new System.Drawing.Point(133, 27);
            this.txtMaHD.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(372, 22);
            this.txtMaHD.TabIndex = 1;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(13, 68);
            this.lblMaKH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(50, 16);
            this.lblMaKH.TabIndex = 2;
            this.lblMaKH.Text = "Mã KH:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Enabled = false;
            this.txtMaKH.Location = new System.Drawing.Point(133, 64);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(372, 22);
            this.txtMaKH.TabIndex = 3;
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(13, 105);
            this.lblTenKH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(55, 16);
            this.lblTenKH.TabIndex = 4;
            this.lblTenKH.Text = "Tên KH:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Enabled = false;
            this.txtTenKH.Location = new System.Drawing.Point(133, 101);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(372, 22);
            this.txtTenKH.TabIndex = 5;
            // 
            // lblCouponCode
            // 
            this.lblCouponCode.AutoSize = true;
            this.lblCouponCode.Location = new System.Drawing.Point(13, 142);
            this.lblCouponCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCouponCode.Name = "lblCouponCode";
            this.lblCouponCode.Size = new System.Drawing.Size(77, 16);
            this.lblCouponCode.TabIndex = 6;
            this.lblCouponCode.Text = "Mã coupon:";
            // 
            // txtCouponCode
            // 
            this.txtCouponCode.Location = new System.Drawing.Point(133, 138);
            this.txtCouponCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtCouponCode.Name = "txtCouponCode";
            this.txtCouponCode.Size = new System.Drawing.Size(267, 22);
            this.txtCouponCode.TabIndex = 7;
            // 
            // btnApDungKM
            // 
            this.btnApDungKM.Location = new System.Drawing.Point(417, 136);
            this.btnApDungKM.Margin = new System.Windows.Forms.Padding(4);
            this.btnApDungKM.Name = "btnApDungKM";
            this.btnApDungKM.Size = new System.Drawing.Size(88, 31);
            this.btnApDungKM.TabIndex = 8;
            this.btnApDungKM.Text = "Áp dụng";
            this.btnApDungKM.Click += new System.EventHandler(this.btnApDungKM_Click);
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Location = new System.Drawing.Point(356, 178);
            this.lblGiamGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(64, 16);
            this.lblGiamGia.TabIndex = 9;
            this.lblGiamGia.Text = "Giảm giá:";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Enabled = false;
            this.txtGiamGia.Location = new System.Drawing.Point(440, 175);
            this.txtGiamGia.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(65, 22);
            this.txtGiamGia.TabIndex = 10;
            // 
            // lblTongTruocKM
            // 
            this.lblTongTruocKM.AutoSize = true;
            this.lblTongTruocKM.Location = new System.Drawing.Point(13, 178);
            this.lblTongTruocKM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongTruocKM.Name = "lblTongTruocKM";
            this.lblTongTruocKM.Size = new System.Drawing.Size(96, 16);
            this.lblTongTruocKM.TabIndex = 11;
            this.lblTongTruocKM.Text = "Tổng trước KM:";
            // 
            // txtTongTruocKM
            // 
            this.txtTongTruocKM.Enabled = false;
            this.txtTongTruocKM.Location = new System.Drawing.Point(133, 175);
            this.txtTongTruocKM.Margin = new System.Windows.Forms.Padding(4);
            this.txtTongTruocKM.Name = "txtTongTruocKM";
            this.txtTongTruocKM.Size = new System.Drawing.Size(215, 22);
            this.txtTongTruocKM.TabIndex = 12;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(13, 215);
            this.lblTongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(66, 16);
            this.lblTongTien.TabIndex = 13;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(133, 212);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(4);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(215, 22);
            this.txtTongTien.TabIndex = 14;
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(13, 31);
            this.lblSoTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(51, 16);
            this.lblSoTien.TabIndex = 0;
            this.lblSoTien.Text = "Số tiền:";
            // 
            // lBUSoaiTT
            // 
            this.lBUSoaiTT.AutoSize = true;
            this.lBUSoaiTT.Location = new System.Drawing.Point(13, 68);
            this.lBUSoaiTT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBUSoaiTT.Name = "lBUSoaiTT";
            this.lBUSoaiTT.Size = new System.Drawing.Size(57, 16);
            this.lBUSoaiTT.TabIndex = 2;
            this.lBUSoaiTT.Text = "Loại TT:";
            // 
            // cbLoaiTT
            // 
            this.cbLoaiTT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiTT.Location = new System.Drawing.Point(133, 68);
            this.cbLoaiTT.Margin = new System.Windows.Forms.Padding(4);
            this.cbLoaiTT.Name = "cbLoaiTT";
            this.cbLoaiTT.Size = new System.Drawing.Size(320, 24);
            this.cbLoaiTT.TabIndex = 3;
            this.cbLoaiTT.SelectedIndexChanged += new System.EventHandler(this.cbLoaiTT_SelectedIndexChanged);
            // 
            // lblNgayTT
            // 
            this.lblNgayTT.AutoSize = true;
            this.lblNgayTT.Location = new System.Drawing.Point(13, 105);
            this.lblNgayTT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayTT.Name = "lblNgayTT";
            this.lblNgayTT.Size = new System.Drawing.Size(64, 16);
            this.lblNgayTT.TabIndex = 4;
            this.lblNgayTT.Text = "Ngày TT:";
            // 
            // dtpNgayTT
            // 
            this.dtpNgayTT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTT.Location = new System.Drawing.Point(133, 105);
            this.dtpNgayTT.Margin = new System.Windows.Forms.Padding(4);
            this.dtpNgayTT.Name = "dtpNgayTT";
            this.dtpNgayTT.Size = new System.Drawing.Size(320, 22);
            this.dtpNgayTT.TabIndex = 5;
            this.dtpNgayTT.ValueChanged += new System.EventHandler(this.dtpNgayTT_ValueChanged);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(133, 142);
            this.btnThanhToan.Margin = new System.Windows.Forms.Padding(4);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(133, 37);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lvInvoices
            // 
            this.lvInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvInvoices.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lvInvoices.FullRowSelect = true;
            this.lvInvoices.GridLines = true;
            this.lvInvoices.HideSelection = false;
            this.lvInvoices.Location = new System.Drawing.Point(720, 25);
            this.lvInvoices.Margin = new System.Windows.Forms.Padding(4);
            this.lvInvoices.Name = "lvInvoices";
            this.lvInvoices.Size = new System.Drawing.Size(799, 701);
            this.lvInvoices.TabIndex = 0;
            this.lvInvoices.UseCompatibleStateImageBehavior = false;
            this.lvInvoices.View = System.Windows.Forms.View.Details;
            this.lvInvoices.SelectedIndexChanged += new System.EventHandler(this.lvInvoices_SelectedIndexChanged);
            // 
            // lvPayments
            // 
            this.lvPayments.FullRowSelect = true;
            this.lvPayments.GridLines = true;
            this.lvPayments.HideSelection = false;
            this.lvPayments.Location = new System.Drawing.Point(13, 25);
            this.lvPayments.Margin = new System.Windows.Forms.Padding(4);
            this.lvPayments.Name = "lvPayments";
            this.lvPayments.Size = new System.Drawing.Size(505, 208);
            this.lvPayments.TabIndex = 0;
            this.lvPayments.UseCompatibleStateImageBehavior = false;
            this.lvPayments.View = System.Windows.Forms.View.Details;
            // 
            // lblTongTienSummary
            // 
            this.lblTongTienSummary.AutoSize = true;
            this.lblTongTienSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongTienSummary.Location = new System.Drawing.Point(457, 35);
            this.lblTongTienSummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongTienSummary.Name = "lblTongTienSummary";
            this.lblTongTienSummary.Size = new System.Drawing.Size(136, 18);
            this.lblTongTienSummary.TabIndex = 7;
            this.lblTongTienSummary.Text = "Tổng tiền: 0 VNĐ";
            this.lblTongTienSummary.Click += new System.EventHandler(this.lblTongTienSummary_Click);
            // 
            // lblDaThanhToan
            // 
            this.lblDaThanhToan.AutoSize = true;
            this.lblDaThanhToan.Location = new System.Drawing.Point(461, 71);
            this.lblDaThanhToan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDaThanhToan.Name = "lblDaThanhToan";
            this.lblDaThanhToan.Size = new System.Drawing.Size(132, 16);
            this.lblDaThanhToan.TabIndex = 8;
            this.lblDaThanhToan.Text = "Đã thanh toán: 0 VNĐ";
            this.lblDaThanhToan.Click += new System.EventHandler(this.lblDaThanhToan_Click);
            // 
            // lblConLai
            // 
            this.lblConLai.AutoSize = true;
            this.lblConLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblConLai.ForeColor = System.Drawing.Color.Red;
            this.lblConLai.Location = new System.Drawing.Point(461, 103);
            this.lblConLai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConLai.Name = "lblConLai";
            this.lblConLai.Size = new System.Drawing.Size(119, 18);
            this.lblConLai.TabIndex = 9;
            this.lblConLai.Text = "Còn lại: 0 VNĐ";
            this.lblConLai.Click += new System.EventHandler(this.lblConLai_Click);
            // 
            // gbThongTinHD
            // 
            this.gbThongTinHD.Controls.Add(this.lblMaHD);
            this.gbThongTinHD.Controls.Add(this.txtMaHD);
            this.gbThongTinHD.Controls.Add(this.lblMaKH);
            this.gbThongTinHD.Controls.Add(this.txtMaKH);
            this.gbThongTinHD.Controls.Add(this.lblTenKH);
            this.gbThongTinHD.Controls.Add(this.txtTenKH);
            this.gbThongTinHD.Controls.Add(this.lblCouponCode);
            this.gbThongTinHD.Controls.Add(this.txtCouponCode);
            this.gbThongTinHD.Controls.Add(this.btnApDungKM);
            this.gbThongTinHD.Controls.Add(this.lblGiamGia);
            this.gbThongTinHD.Controls.Add(this.txtGiamGia);
            this.gbThongTinHD.Controls.Add(this.lblTongTruocKM);
            this.gbThongTinHD.Controls.Add(this.txtTongTruocKM);
            this.gbThongTinHD.Controls.Add(this.lblTongTien);
            this.gbThongTinHD.Controls.Add(this.txtTongTien);
            this.gbThongTinHD.Location = new System.Drawing.Point(27, 25);
            this.gbThongTinHD.Margin = new System.Windows.Forms.Padding(4);
            this.gbThongTinHD.Name = "gbThongTinHD";
            this.gbThongTinHD.Padding = new System.Windows.Forms.Padding(4);
            this.gbThongTinHD.Size = new System.Drawing.Size(533, 246);
            this.gbThongTinHD.TabIndex = 3;
            this.gbThongTinHD.TabStop = false;
            this.gbThongTinHD.Text = "Thông tin Hóa đơn";
            // 
            // gbThanhToan
            // 
            this.gbThanhToan.Controls.Add(this.txtSoTien);
            this.gbThanhToan.Controls.Add(this.lblSoTien);
            this.gbThanhToan.Controls.Add(this.lBUSoaiTT);
            this.gbThanhToan.Controls.Add(this.cbLoaiTT);
            this.gbThanhToan.Controls.Add(this.lblNgayTT);
            this.gbThanhToan.Controls.Add(this.dtpNgayTT);
            this.gbThanhToan.Controls.Add(this.btnThanhToan);
            this.gbThanhToan.Controls.Add(this.lblTongTienSummary);
            this.gbThanhToan.Controls.Add(this.lblDaThanhToan);
            this.gbThanhToan.Controls.Add(this.lblConLai);
            this.gbThanhToan.Location = new System.Drawing.Point(27, 283);
            this.gbThanhToan.Margin = new System.Windows.Forms.Padding(4);
            this.gbThanhToan.Name = "gbThanhToan";
            this.gbThanhToan.Padding = new System.Windows.Forms.Padding(4);
            this.gbThanhToan.Size = new System.Drawing.Size(642, 185);
            this.gbThanhToan.TabIndex = 2;
            this.gbThanhToan.TabStop = false;
            this.gbThanhToan.Text = "Thanh toán";
            // 
            // gbLichSuTT
            // 
            this.gbLichSuTT.Controls.Add(this.lvPayments);
            this.gbLichSuTT.Location = new System.Drawing.Point(27, 480);
            this.gbLichSuTT.Margin = new System.Windows.Forms.Padding(4);
            this.gbLichSuTT.Name = "gbLichSuTT";
            this.gbLichSuTT.Padding = new System.Windows.Forms.Padding(4);
            this.gbLichSuTT.Size = new System.Drawing.Size(533, 246);
            this.gbLichSuTT.TabIndex = 1;
            this.gbLichSuTT.TabStop = false;
            this.gbLichSuTT.Text = "Lịch sử thanh toán";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(133, 23);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(320, 22);
            this.txtSoTien.TabIndex = 10;
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 751);
            this.Controls.Add(this.lvInvoices);
            this.Controls.Add(this.gbLichSuTT);
            this.Controls.Add(this.gbThanhToan);
            this.Controls.Add(this.gbThongTinHD);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPayment";
            this.Text = "Thanh Toán";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            this.gbThongTinHD.ResumeLayout(false);
            this.gbThongTinHD.PerformLayout();
            this.gbThanhToan.ResumeLayout(false);
            this.gbThanhToan.PerformLayout();
            this.gbLichSuTT.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private TextBox txtSoTien;
    }
}


