using System.ComponentModel;
using System.Windows.Forms;

namespace GUI_QLResort
{
    partial class frmLostFound
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaLF;
        private System.Windows.Forms.TextBox txtMaLF;
        private System.Windows.Forms.Label lblTenDo;
        private System.Windows.Forms.TextBox txtTenDo;
        private System.Windows.Forms.Label lblMaCN;
        private System.Windows.Forms.ComboBox cbMaCN;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.ComboBox cbMaKH;
        private System.Windows.Forms.Label lblNgayTimThay;
        private System.Windows.Forms.DateTimePicker dtpNgayTimThay;
        private System.Windows.Forms.Label lblDiaDiemTim;
        private System.Windows.Forms.TextBox txtDiaDiemTim;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.Label lblNgayTra;
        private System.Windows.Forms.DateTimePicker dtpNgayTra;
        private System.Windows.Forms.Label lblNguoiNhan;
        private System.Windows.Forms.TextBox txtNguoiNhan;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTraDo;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ColumnHeader colMaLF;
        private System.Windows.Forms.ColumnHeader colTenDo;
        private System.Windows.Forms.ColumnHeader colNgayTim;
        private System.Windows.Forms.ColumnHeader colDiaDiem;
        private System.Windows.Forms.ColumnHeader colTrangThai;
        private System.Windows.Forms.ColumnHeader colNgayTra;
        private System.Windows.Forms.ColumnHeader colNguoiNhan;
        private System.Windows.Forms.ListView lvLostFound;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvLostFound = new System.Windows.Forms.ListView();
            this.colMaLF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenDo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgayTim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDiaDiem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTrangThai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgayTra = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNguoiNhan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMaLF = new System.Windows.Forms.Label();
            this.txtMaLF = new System.Windows.Forms.TextBox();
            this.lblTenDo = new System.Windows.Forms.Label();
            this.txtTenDo = new System.Windows.Forms.TextBox();
            this.lblMaCN = new System.Windows.Forms.Label();
            this.cbMaCN = new System.Windows.Forms.ComboBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.cbMaKH = new System.Windows.Forms.ComboBox();
            this.lblNgayTimThay = new System.Windows.Forms.Label();
            this.dtpNgayTimThay = new System.Windows.Forms.DateTimePicker();
            this.lblDiaDiemTim = new System.Windows.Forms.Label();
            this.txtDiaDiemTim = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.lblNgayTra = new System.Windows.Forms.Label();
            this.dtpNgayTra = new System.Windows.Forms.DateTimePicker();
            this.lblNguoiNhan = new System.Windows.Forms.Label();
            this.txtNguoiNhan = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTraDo = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvLostFound
            // 
            this.lvLostFound.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaLF,
            this.colTenDo,
            this.colNgayTim,
            this.colDiaDiem,
            this.colTrangThai,
            this.colNgayTra,
            this.colNguoiNhan});
            this.lvLostFound.FullRowSelect = true;
            this.lvLostFound.GridLines = true;
            this.lvLostFound.HideSelection = false;
            this.lvLostFound.Location = new System.Drawing.Point(420, 20);
            this.lvLostFound.Name = "lvLostFound";
            this.lvLostFound.Size = new System.Drawing.Size(700, 400);
            this.lvLostFound.TabIndex = 0;
            this.lvLostFound.UseCompatibleStateImageBehavior = false;
            this.lvLostFound.View = System.Windows.Forms.View.Details;
            this.lvLostFound.SelectedIndexChanged += new System.EventHandler(this.lvLostFound_SelectedIndexChanged);
            // 
            // colMaLF
            // 
            this.colMaLF.Text = "Mã đồ";
            this.colMaLF.Width = 80;
            // 
            // colTenDo
            // 
            this.colTenDo.Text = "Tên dồ";
            this.colTenDo.Width = 100;
            // 
            // colNgayTim
            // 
            this.colNgayTim.Text = "Ngày tìm";
            this.colNgayTim.Width = 100;
            // 
            // colDiaDiem
            // 
            this.colDiaDiem.Text = "Địa điểm";
            this.colDiaDiem.Width = 130;
            // 
            // colTrangThai
            // 
            this.colTrangThai.Text = "Trạng thái";
            this.colTrangThai.Width = 90;
            // 
            // colNgayTra
            // 
            this.colNgayTra.Text = "Ngày trả";
            this.colNgayTra.Width = 90;
            // 
            // colNguoiNhan
            // 
            this.colNguoiNhan.Text = "Người nhận";
            this.colNguoiNhan.Width = 100;
            // 
            // lblMaLF
            // 
            this.lblMaLF.AutoSize = true;
            this.lblMaLF.Location = new System.Drawing.Point(20, 23);
            this.lblMaLF.Name = "lblMaLF";
            this.lblMaLF.Size = new System.Drawing.Size(41, 13);
            this.lblMaLF.TabIndex = 26;
            this.lblMaLF.Text = "Mã đồ:";
            // 
            // txtMaLF
            // 
            this.txtMaLF.Enabled = false;
            this.txtMaLF.Location = new System.Drawing.Point(120, 20);
            this.txtMaLF.Name = "txtMaLF";
            this.txtMaLF.Size = new System.Drawing.Size(200, 20);
            this.txtMaLF.TabIndex = 25;
            // 
            // lblTenDo
            // 
            this.lblTenDo.AutoSize = true;
            this.lblTenDo.Location = new System.Drawing.Point(20, 53);
            this.lblTenDo.Name = "lblTenDo";
            this.lblTenDo.Size = new System.Drawing.Size(45, 13);
            this.lblTenDo.TabIndex = 24;
            this.lblTenDo.Text = "Tên đồ:";
            // 
            // txtTenDo
            // 
            this.txtTenDo.Location = new System.Drawing.Point(120, 50);
            this.txtTenDo.Name = "txtTenDo";
            this.txtTenDo.Size = new System.Drawing.Size(200, 20);
            this.txtTenDo.TabIndex = 23;
            // 
            // lblMaCN
            // 
            this.lblMaCN.AutoSize = true;
            this.lblMaCN.Location = new System.Drawing.Point(20, 283);
            this.lblMaCN.Name = "lblMaCN";
            this.lblMaCN.Size = new System.Drawing.Size(58, 13);
            this.lblMaCN.TabIndex = 10;
            this.lblMaCN.Text = "Chi nhánh:";
            // 
            // cbMaCN
            // 
            this.cbMaCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaCN.Location = new System.Drawing.Point(120, 280);
            this.cbMaCN.Name = "cbMaCN";
            this.cbMaCN.Size = new System.Drawing.Size(200, 21);
            this.cbMaCN.TabIndex = 9;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(20, 313);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(59, 13);
            this.lblMaNV.TabIndex = 8;
            this.lblMaNV.Text = "Nhân viên:";
            // 
            // cbMaNV
            // 
            this.cbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaNV.Location = new System.Drawing.Point(120, 310);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(200, 21);
            this.cbMaNV.TabIndex = 7;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(20, 343);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(68, 13);
            this.lblMaKH.TabIndex = 6;
            this.lblMaKH.Text = "Khách hàng:";
            // 
            // cbMaKH
            // 
            this.cbMaKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaKH.Location = new System.Drawing.Point(120, 340);
            this.cbMaKH.Name = "cbMaKH";
            this.cbMaKH.Size = new System.Drawing.Size(200, 21);
            this.cbMaKH.TabIndex = 5;
            // 
            // lblNgayTimThay
            // 
            this.lblNgayTimThay.AutoSize = true;
            this.lblNgayTimThay.Location = new System.Drawing.Point(20, 83);
            this.lblNgayTimThay.Name = "lblNgayTimThay";
            this.lblNgayTimThay.Size = new System.Drawing.Size(51, 13);
            this.lblNgayTimThay.TabIndex = 22;
            this.lblNgayTimThay.Text = "Ngày tìm:";
            // 
            // dtpNgayTimThay
            // 
            this.dtpNgayTimThay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTimThay.Location = new System.Drawing.Point(120, 80);
            this.dtpNgayTimThay.Name = "dtpNgayTimThay";
            this.dtpNgayTimThay.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayTimThay.TabIndex = 21;
            // 
            // lblDiaDiemTim
            // 
            this.lblDiaDiemTim.AutoSize = true;
            this.lblDiaDiemTim.Location = new System.Drawing.Point(20, 113);
            this.lblDiaDiemTim.Name = "lblDiaDiemTim";
            this.lblDiaDiemTim.Size = new System.Drawing.Size(52, 13);
            this.lblDiaDiemTim.TabIndex = 20;
            this.lblDiaDiemTim.Text = "Địa điểm:";
            // 
            // txtDiaDiemTim
            // 
            this.txtDiaDiemTim.Location = new System.Drawing.Point(120, 110);
            this.txtDiaDiemTim.Name = "txtDiaDiemTim";
            this.txtDiaDiemTim.Size = new System.Drawing.Size(200, 20);
            this.txtDiaDiemTim.TabIndex = 19;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(20, 143);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(58, 13);
            this.lblTrangThai.TabIndex = 18;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.Items.AddRange(new object[] {
            "Đã tìm thấy",
            "Đã trả lại",
            "Lưu kho"});
            this.cbTrangThai.Location = new System.Drawing.Point(120, 140);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(200, 21);
            this.cbTrangThai.TabIndex = 17;
            // 
            // lblNgayTra
            // 
            this.lblNgayTra.AutoSize = true;
            this.lblNgayTra.Location = new System.Drawing.Point(20, 203);
            this.lblNgayTra.Name = "lblNgayTra";
            this.lblNgayTra.Size = new System.Drawing.Size(50, 13);
            this.lblNgayTra.TabIndex = 14;
            this.lblNgayTra.Text = "Ngày trả:";
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTra.Location = new System.Drawing.Point(120, 200);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayTra.TabIndex = 13;
            // 
            // lblNguoiNhan
            // 
            this.lblNguoiNhan.AutoSize = true;
            this.lblNguoiNhan.Location = new System.Drawing.Point(20, 173);
            this.lblNguoiNhan.Name = "lblNguoiNhan";
            this.lblNguoiNhan.Size = new System.Drawing.Size(65, 13);
            this.lblNguoiNhan.TabIndex = 16;
            this.lblNguoiNhan.Text = "Người nhận:";
            // 
            // txtNguoiNhan
            // 
            this.txtNguoiNhan.Location = new System.Drawing.Point(120, 170);
            this.txtNguoiNhan.Name = "txtNguoiNhan";
            this.txtNguoiNhan.Size = new System.Drawing.Size(200, 20);
            this.txtNguoiNhan.TabIndex = 15;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(20, 233);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(47, 13);
            this.lblGhiChu.TabIndex = 12;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(120, 230);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(200, 40);
            this.txtGhiChu.TabIndex = 11;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(20, 400);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(70, 30);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(100, 400);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(70, 30);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTraDo
            // 
            this.btnTraDo.Location = new System.Drawing.Point(260, 400);
            this.btnTraDo.Name = "btnTraDo";
            this.btnTraDo.Size = new System.Drawing.Size(70, 30);
            this.btnTraDo.TabIndex = 1;
            this.btnTraDo.Text = "Trả đồ";
            this.btnTraDo.Click += new System.EventHandler(this.btnTraDo_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(340, 400);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(70, 30);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(180, 400);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(70, 30);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmLostFound
            // 
            this.ClientSize = new System.Drawing.Size(1132, 453);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnTraDo);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbMaKH);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.cbMaNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.cbMaCN);
            this.Controls.Add(this.lblMaCN);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.dtpNgayTra);
            this.Controls.Add(this.lblNgayTra);
            this.Controls.Add(this.txtNguoiNhan);
            this.Controls.Add(this.lblNguoiNhan);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.txtDiaDiemTim);
            this.Controls.Add(this.lblDiaDiemTim);
            this.Controls.Add(this.dtpNgayTimThay);
            this.Controls.Add(this.lblNgayTimThay);
            this.Controls.Add(this.txtTenDo);
            this.Controls.Add(this.lblTenDo);
            this.Controls.Add(this.txtMaLF);
            this.Controls.Add(this.lblMaLF);
            this.Controls.Add(this.lvLostFound);
            this.Name = "frmLostFound";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

