using System.ComponentModel;
using System.Windows.Forms;

namespace QLResort.GUI
{
    partial class frmComplaint
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaKN;
        private System.Windows.Forms.TextBox txtMaKN;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.ComboBox cbMaKH;
        private System.Windows.Forms.Label lblMaCN;
        private System.Windows.Forms.ComboBox cbMaCN;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.Label lblNgayGhi;
        private System.Windows.Forms.DateTimePicker dtpNgayGhi;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label lblMucDo;
        private System.Windows.Forms.ComboBox cbMucDo;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Label lblSoTienBoiThuong;
        private System.Windows.Forms.TextBox txtSoTienBoiThuong;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView lvComplaints;
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
            this.lblMaKN = new System.Windows.Forms.Label();
            this.txtMaKN = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.cbMaKH = new System.Windows.Forms.ComboBox();
            this.lblMaCN = new System.Windows.Forms.Label();
            this.cbMaCN = new System.Windows.Forms.ComboBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.lblNgayGhi = new System.Windows.Forms.Label();
            this.dtpNgayGhi = new System.Windows.Forms.DateTimePicker();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.lblMucDo = new System.Windows.Forms.Label();
            this.cbMucDo = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.lblSoTienBoiThuong = new System.Windows.Forms.Label();
            this.txtSoTienBoiThuong = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lvComplaints = new System.Windows.Forms.ListView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // lblMaKN
            this.lblMaKN.AutoSize = true;
            this.lblMaKN.Location = new System.Drawing.Point(20, 20);
            this.lblMaKN.Name = "lblMaKN";
            this.lblMaKN.Size = new System.Drawing.Size(70, 13);
            this.lblMaKN.Text = "Mã khiếu nại:";
            // txtMaKN
            this.txtMaKN.Enabled = false;
            this.txtMaKN.Location = new System.Drawing.Point(100, 17);
            this.txtMaKN.Name = "txtMaKN";
            this.txtMaKN.Size = new System.Drawing.Size(150, 20);
            // lblMaKH
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(20, 50);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(70, 13);
            this.lblMaKH.Text = "Khách hàng:";
            // cbMaKH
            this.cbMaKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaKH.FormattingEnabled = true;
            this.cbMaKH.Location = new System.Drawing.Point(100, 47);
            this.cbMaKH.Name = "cbMaKH";
            this.cbMaKH.Size = new System.Drawing.Size(200, 21);
            // lblMaCN
            this.lblMaCN.AutoSize = true;
            this.lblMaCN.Location = new System.Drawing.Point(20, 80);
            this.lblMaCN.Name = "lblMaCN";
            this.lblMaCN.Size = new System.Drawing.Size(60, 13);
            this.lblMaCN.Text = "Chi nhánh:";
            // cbMaCN
            this.cbMaCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaCN.FormattingEnabled = true;
            this.cbMaCN.Location = new System.Drawing.Point(100, 77);
            this.cbMaCN.Name = "cbMaCN";
            this.cbMaCN.Size = new System.Drawing.Size(200, 21);
            // lblMaNV
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(20, 110);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(60, 13);
            this.lblMaNV.Text = "Nhân viên:";
            // cbMaNV
            this.cbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(100, 107);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(200, 21);
            // lblNgayGhi
            this.lblNgayGhi.AutoSize = true;
            this.lblNgayGhi.Location = new System.Drawing.Point(20, 140);
            this.lblNgayGhi.Name = "lblNgayGhi";
            this.lblNgayGhi.Size = new System.Drawing.Size(50, 13);
            this.lblNgayGhi.Text = "Ngày ghi:";
            // dtpNgayGhi
            this.dtpNgayGhi.Enabled = false;
            this.dtpNgayGhi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayGhi.Location = new System.Drawing.Point(100, 137);
            this.dtpNgayGhi.Name = "dtpNgayGhi";
            this.dtpNgayGhi.Size = new System.Drawing.Size(150, 20);
            // lblNoiDung
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(20, 170);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(60, 13);
            this.lblNoiDung.Text = "Nội dung:";
            // txtNoiDung
            this.txtNoiDung.Location = new System.Drawing.Point(100, 167);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(300, 60);
            // lblMucDo
            this.lblMucDo.AutoSize = true;
            this.lblMucDo.Location = new System.Drawing.Point(20, 240);
            this.lblMucDo.Name = "lblMucDo";
            this.lblMucDo.Size = new System.Drawing.Size(50, 13);
            this.lblMucDo.Text = "Mức độ:";
            // cbMucDo
            this.cbMucDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMucDo.FormattingEnabled = true;
            this.cbMucDo.Location = new System.Drawing.Point(100, 237);
            this.cbMucDo.Name = "cbMucDo";
            this.cbMucDo.Size = new System.Drawing.Size(150, 21);
            // lblTrangThai
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(20, 270);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(60, 13);
            this.lblTrangThai.Text = "Trạng thái:";
            // cbTrangThai
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(100, 267);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(150, 21);
            // lblKetQua
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(20, 300);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(50, 13);
            this.lblKetQua.Text = "Kết quả:";
            // txtKetQua
            this.txtKetQua.Location = new System.Drawing.Point(100, 297);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(300, 40);
            // lblSoTienBoiThuong
            this.lblSoTienBoiThuong.AutoSize = true;
            this.lblSoTienBoiThuong.Location = new System.Drawing.Point(20, 350);
            this.lblSoTienBoiThuong.Name = "lblSoTienBoiThuong";
            this.lblSoTienBoiThuong.Size = new System.Drawing.Size(90, 13);
            this.lblSoTienBoiThuong.Text = "Số tiền bồi thường:";
            // txtSoTienBoiThuong
            this.txtSoTienBoiThuong.Location = new System.Drawing.Point(110, 347);
            this.txtSoTienBoiThuong.Name = "txtSoTienBoiThuong";
            this.txtSoTienBoiThuong.Size = new System.Drawing.Size(150, 20);
            // lblGhiChu
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(20, 380);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(50, 13);
            this.lblGhiChu.Text = "Ghi chú:";
            // txtGhiChu
            this.txtGhiChu.Location = new System.Drawing.Point(100, 377);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(300, 40);
            // btnThem
            this.btnThem.Location = new System.Drawing.Point(20, 430);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // btnSua
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(110, 430);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(200, 430);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // btnReset
            this.btnReset.Location = new System.Drawing.Point(290, 430);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // lvComplaints
            this.lvComplaints.FullRowSelect = true;
            this.lvComplaints.GridLines = true;
            this.lvComplaints.HideSelection = false;
            this.lvComplaints.Location = new System.Drawing.Point(420, 20);
            this.lvComplaints.Name = "lvComplaints";
            this.lvComplaints.Size = new System.Drawing.Size(700, 440);
            this.lvComplaints.TabIndex = 0;
            this.lvComplaints.UseCompatibleStateImageBehavior = false;
            this.lvComplaints.View = System.Windows.Forms.View.Details;
            this.lvComplaints.Columns.Add("Mã KN", 80);
            this.lvComplaints.Columns.Add("Ngày ghi", 100);
            this.lvComplaints.Columns.Add("Mức độ", 100);
            this.lvComplaints.Columns.Add("Trạng thái", 100);
            this.lvComplaints.Columns.Add("Bồi thường", 120);
            this.lvComplaints.SelectedIndexChanged += new System.EventHandler(this.lvComplaints_SelectedIndexChanged);
            // errorProvider1
            this.errorProvider1.ContainerControl = this;
            // frmComplaint
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 480);
            this.Controls.Add(this.lvComplaints);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtSoTienBoiThuong);
            this.Controls.Add(this.lblSoTienBoiThuong);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cbMucDo);
            this.Controls.Add(this.lblMucDo);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.lblNoiDung);
            this.Controls.Add(this.dtpNgayGhi);
            this.Controls.Add(this.lblNgayGhi);
            this.Controls.Add(this.cbMaNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.cbMaCN);
            this.Controls.Add(this.lblMaCN);
            this.Controls.Add(this.cbMaKH);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.txtMaKN);
            this.Controls.Add(this.lblMaKN);
            this.Name = "frmComplaint";
            this.Text = "Quản lý Khiếu nại";
            this.Load += new System.EventHandler(this.frmComplaint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

