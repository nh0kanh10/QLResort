using System.ComponentModel;
using System.Windows.Forms;

namespace GUI_QLResort
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
        private System.Windows.Forms.ColumnHeader colMaKN;
        private System.Windows.Forms.ColumnHeader colNgayGhi;
        private System.Windows.Forms.ColumnHeader colMucDo;
        private System.Windows.Forms.ColumnHeader colTrangThai;
        private System.Windows.Forms.ColumnHeader colSoTienBoiThuong;
        private System.Windows.Forms.ListView lvComplaints;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvComplaints = new System.Windows.Forms.ListView();
            this.colMaKN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgayGhi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMucDo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoTienBoiThuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMaKN = new System.Windows.Forms.Label();
            this.txtMaKN = new System.Windows.Forms.TextBox();
            this.lblNgayGhi = new System.Windows.Forms.Label();
            this.dtpNgayGhi = new System.Windows.Forms.DateTimePicker();
            this.lblMucDo = new System.Windows.Forms.Label();
            this.cbMucDo = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.lblSoTienBoiThuong = new System.Windows.Forms.Label();
            this.txtSoTienBoiThuong = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.cbMaKH = new System.Windows.Forms.ComboBox();
            this.lblMaCN = new System.Windows.Forms.Label();
            this.cbMaCN = new System.Windows.Forms.ComboBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvComplaints
            // 
            this.lvComplaints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaKN,
            this.colNgayGhi,
            this.colMucDo,
            this.colTrangThai,
            this.colSoTienBoiThuong});
            this.lvComplaints.FullRowSelect = true;
            this.lvComplaints.GridLines = true;
            this.lvComplaints.HideSelection = false;
            this.lvComplaints.Location = new System.Drawing.Point(420, 20);
            this.lvComplaints.Name = "lvComplaints";
            this.lvComplaints.Size = new System.Drawing.Size(700, 440);
            this.lvComplaints.TabIndex = 0;
            this.lvComplaints.UseCompatibleStateImageBehavior = false;
            this.lvComplaints.View = System.Windows.Forms.View.Details;
            this.lvComplaints.SelectedIndexChanged += new System.EventHandler(this.lvComplaints_SelectedIndexChanged);
            // 
            // colMaKN
            // 
            this.colMaKN.Text = "Mã KN";
            this.colMaKN.Width = 80;
            // 
            // colNgayGhi
            // 
            this.colNgayGhi.Text = "Ngày Ghi";
            this.colNgayGhi.Width = 100;
            // 
            // colMucDo
            // 
            this.colMucDo.Text = "Mức Độ";
            this.colMucDo.Width = 100;
            // 
            // colTrangThai
            // 
            this.colTrangThai.Text = "Trạng Thái";
            this.colTrangThai.Width = 100;
            // 
            // colSoTienBoiThuong
            // 
            this.colSoTienBoiThuong.Text = "Bồi Thường";
            this.colSoTienBoiThuong.Width = 100;
            // 
            // lblMaKN
            // 
            this.lblMaKN.AutoSize = true;
            this.lblMaKN.Location = new System.Drawing.Point(20, 23);
            this.lblMaKN.Name = "lblMaKN";
            this.lblMaKN.Size = new System.Drawing.Size(43, 13);
            this.lblMaKN.TabIndex = 25;
            this.lblMaKN.Text = "Mã KN:";
            // 
            // txtMaKN
            // 
            this.txtMaKN.Enabled = false;
            this.txtMaKN.Location = new System.Drawing.Point(120, 20);
            this.txtMaKN.Name = "txtMaKN";
            this.txtMaKN.Size = new System.Drawing.Size(200, 20);
            this.txtMaKN.TabIndex = 24;
            // 
            // lblNgayGhi
            // 
            this.lblNgayGhi.AutoSize = true;
            this.lblNgayGhi.Location = new System.Drawing.Point(20, 53);
            this.lblNgayGhi.Name = "lblNgayGhi";
            this.lblNgayGhi.Size = new System.Drawing.Size(54, 13);
            this.lblNgayGhi.TabIndex = 23;
            this.lblNgayGhi.Text = "Ngày Ghi:";
            // 
            // dtpNgayGhi
            // 
            this.dtpNgayGhi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayGhi.Location = new System.Drawing.Point(120, 50);
            this.dtpNgayGhi.Name = "dtpNgayGhi";
            this.dtpNgayGhi.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayGhi.TabIndex = 22;
            // 
            // lblMucDo
            // 
            this.lblMucDo.AutoSize = true;
            this.lblMucDo.Location = new System.Drawing.Point(20, 83);
            this.lblMucDo.Name = "lblMucDo";
            this.lblMucDo.Size = new System.Drawing.Size(47, 13);
            this.lblMucDo.TabIndex = 21;
            this.lblMucDo.Text = "Mức độ:";
            // 
            // cbMucDo
            // 
            this.cbMucDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMucDo.Items.AddRange(new object[] {
            "Thấp",
            "Trung bình",
            "Cao"});
            this.cbMucDo.Location = new System.Drawing.Point(120, 80);
            this.cbMucDo.Name = "cbMucDo";
            this.cbMucDo.Size = new System.Drawing.Size(200, 21);
            this.cbMucDo.TabIndex = 20;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(20, 113);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(58, 13);
            this.lblTrangThai.TabIndex = 19;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.Items.AddRange(new object[] {
            "Đang xử lý",
            "Hoàn thành",
            "Hủy"});
            this.cbTrangThai.Location = new System.Drawing.Point(120, 110);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(200, 21);
            this.cbTrangThai.TabIndex = 18;
            // 
            // lblSoTienBoiThuong
            // 
            this.lblSoTienBoiThuong.AutoSize = true;
            this.lblSoTienBoiThuong.Location = new System.Drawing.Point(20, 143);
            this.lblSoTienBoiThuong.Name = "lblSoTienBoiThuong";
            this.lblSoTienBoiThuong.Size = new System.Drawing.Size(61, 13);
            this.lblSoTienBoiThuong.TabIndex = 17;
            this.lblSoTienBoiThuong.Text = "Bồi thường:";
            // 
            // txtSoTienBoiThuong
            // 
            this.txtSoTienBoiThuong.Location = new System.Drawing.Point(120, 140);
            this.txtSoTienBoiThuong.Name = "txtSoTienBoiThuong";
            this.txtSoTienBoiThuong.Size = new System.Drawing.Size(200, 20);
            this.txtSoTienBoiThuong.TabIndex = 16;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(20, 283);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(47, 13);
            this.lblGhiChu.TabIndex = 11;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(120, 280);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(280, 40);
            this.txtGhiChu.TabIndex = 10;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(20, 333);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(68, 13);
            this.lblMaKH.TabIndex = 9;
            this.lblMaKH.Text = "Khách hàng:";
            // 
            // cbMaKH
            // 
            this.cbMaKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaKH.Location = new System.Drawing.Point(120, 330);
            this.cbMaKH.Name = "cbMaKH";
            this.cbMaKH.Size = new System.Drawing.Size(200, 21);
            this.cbMaKH.TabIndex = 8;
            // 
            // lblMaCN
            // 
            this.lblMaCN.AutoSize = true;
            this.lblMaCN.Location = new System.Drawing.Point(20, 363);
            this.lblMaCN.Name = "lblMaCN";
            this.lblMaCN.Size = new System.Drawing.Size(58, 13);
            this.lblMaCN.TabIndex = 7;
            this.lblMaCN.Text = "Chi nhánh:";
            // 
            // cbMaCN
            // 
            this.cbMaCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaCN.Location = new System.Drawing.Point(120, 360);
            this.cbMaCN.Name = "cbMaCN";
            this.cbMaCN.Size = new System.Drawing.Size(200, 21);
            this.cbMaCN.TabIndex = 6;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(20, 393);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(59, 13);
            this.lblMaNV.TabIndex = 5;
            this.lblMaNV.Text = "Nhân viên:";
            // 
            // cbMaNV
            // 
            this.cbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaNV.Location = new System.Drawing.Point(120, 390);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(200, 21);
            this.cbMaNV.TabIndex = 4;
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(20, 173);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(53, 13);
            this.lblNoiDung.TabIndex = 15;
            this.lblNoiDung.Text = "Nội dung:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(120, 170);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(280, 50);
            this.txtNoiDung.TabIndex = 14;
            // 
            // lblKetQua
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(20, 233);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(47, 13);
            this.lblKetQua.TabIndex = 13;
            this.lblKetQua.Text = "Kết quả:";
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(120, 230);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(280, 40);
            this.txtKetQua.TabIndex = 12;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(20, 430);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(110, 430);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(200, 430);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(290, 430);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmComplaint
            // 
            this.ClientSize = new System.Drawing.Size(1179, 487);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbMaNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.cbMaCN);
            this.Controls.Add(this.lblMaCN);
            this.Controls.Add(this.cbMaKH);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.lblNoiDung);
            this.Controls.Add(this.txtSoTienBoiThuong);
            this.Controls.Add(this.lblSoTienBoiThuong);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.cbMucDo);
            this.Controls.Add(this.lblMucDo);
            this.Controls.Add(this.dtpNgayGhi);
            this.Controls.Add(this.lblNgayGhi);
            this.Controls.Add(this.txtMaKN);
            this.Controls.Add(this.lblMaKN);
            this.Controls.Add(this.lvComplaints);
            this.Name = "frmComplaint";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

