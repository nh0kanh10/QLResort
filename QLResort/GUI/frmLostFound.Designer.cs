using System.ComponentModel;
using System.Windows.Forms;

namespace QLResort.GUI
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
        private System.Windows.Forms.ListView lvLostFound;
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
            this.lvLostFound = new System.Windows.Forms.ListView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaLF
            // 
            this.lblMaLF.AutoSize = true;
            this.lblMaLF.Location = new System.Drawing.Point(20, 20);
            this.lblMaLF.Name = "lblMaLF";
            this.lblMaLF.Size = new System.Drawing.Size(41, 13);
            this.lblMaLF.TabIndex = 27;
            this.lblMaLF.Text = "Mã đồ:";
            // 
            // txtMaLF
            // 
            this.txtMaLF.Enabled = false;
            this.txtMaLF.Location = new System.Drawing.Point(100, 17);
            this.txtMaLF.Name = "txtMaLF";
            this.txtMaLF.Size = new System.Drawing.Size(150, 20);
            this.txtMaLF.TabIndex = 26;
            // 
            // lblTenDo
            // 
            this.lblTenDo.AutoSize = true;
            this.lblTenDo.Location = new System.Drawing.Point(20, 50);
            this.lblTenDo.Name = "lblTenDo";
            this.lblTenDo.Size = new System.Drawing.Size(45, 13);
            this.lblTenDo.TabIndex = 25;
            this.lblTenDo.Text = "Tên đồ:";
            // 
            // txtTenDo
            // 
            this.txtTenDo.Location = new System.Drawing.Point(100, 47);
            this.txtTenDo.Name = "txtTenDo";
            this.txtTenDo.Size = new System.Drawing.Size(300, 20);
            this.txtTenDo.TabIndex = 24;
            // 
            // lblMaCN
            // 
            this.lblMaCN.AutoSize = true;
            this.lblMaCN.Location = new System.Drawing.Point(20, 80);
            this.lblMaCN.Name = "lblMaCN";
            this.lblMaCN.Size = new System.Drawing.Size(58, 13);
            this.lblMaCN.TabIndex = 23;
            this.lblMaCN.Text = "Chi nhánh:";
            // 
            // cbMaCN
            // 
            this.cbMaCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaCN.FormattingEnabled = true;
            this.cbMaCN.Location = new System.Drawing.Point(100, 77);
            this.cbMaCN.Name = "cbMaCN";
            this.cbMaCN.Size = new System.Drawing.Size(300, 21);
            this.cbMaCN.TabIndex = 22;
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(20, 110);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(59, 13);
            this.lblMaNV.TabIndex = 21;
            this.lblMaNV.Text = "Nhân viên:";
            // 
            // cbMaNV
            // 
            this.cbMaNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(100, 107);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(200, 21);
            this.cbMaNV.TabIndex = 20;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(20, 140);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(68, 13);
            this.lblMaKH.TabIndex = 19;
            this.lblMaKH.Text = "Khách hàng:";
            // 
            // cbMaKH
            // 
            this.cbMaKH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaKH.FormattingEnabled = true;
            this.cbMaKH.Location = new System.Drawing.Point(100, 137);
            this.cbMaKH.Name = "cbMaKH";
            this.cbMaKH.Size = new System.Drawing.Size(200, 21);
            this.cbMaKH.TabIndex = 18;
            // 
            // lblNgayTimThay
            // 
            this.lblNgayTimThay.AutoSize = true;
            this.lblNgayTimThay.Location = new System.Drawing.Point(20, 170);
            this.lblNgayTimThay.Name = "lblNgayTimThay";
            this.lblNgayTimThay.Size = new System.Drawing.Size(74, 13);
            this.lblNgayTimThay.TabIndex = 17;
            this.lblNgayTimThay.Text = "Ngày tìm thấy:";
            // 
            // dtpNgayTimThay
            // 
            this.dtpNgayTimThay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTimThay.Location = new System.Drawing.Point(100, 167);
            this.dtpNgayTimThay.Name = "dtpNgayTimThay";
            this.dtpNgayTimThay.Size = new System.Drawing.Size(150, 20);
            this.dtpNgayTimThay.TabIndex = 16;
            // 
            // lblDiaDiemTim
            // 
            this.lblDiaDiemTim.AutoSize = true;
            this.lblDiaDiemTim.Location = new System.Drawing.Point(20, 200);
            this.lblDiaDiemTim.Name = "lblDiaDiemTim";
            this.lblDiaDiemTim.Size = new System.Drawing.Size(68, 13);
            this.lblDiaDiemTim.TabIndex = 15;
            this.lblDiaDiemTim.Text = "Địa điểm tìm:";
            // 
            // txtDiaDiemTim
            // 
            this.txtDiaDiemTim.Location = new System.Drawing.Point(100, 197);
            this.txtDiaDiemTim.Name = "txtDiaDiemTim";
            this.txtDiaDiemTim.Size = new System.Drawing.Size(300, 20);
            this.txtDiaDiemTim.TabIndex = 14;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(20, 230);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(58, 13);
            this.lblTrangThai.TabIndex = 13;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(100, 227);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(150, 21);
            this.cbTrangThai.TabIndex = 12;
            this.cbTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbTrangThai_SelectedIndexChanged);
            // 
            // lblNgayTra
            // 
            this.lblNgayTra.AutoSize = true;
            this.lblNgayTra.Location = new System.Drawing.Point(20, 260);
            this.lblNgayTra.Name = "lblNgayTra";
            this.lblNgayTra.Size = new System.Drawing.Size(50, 13);
            this.lblNgayTra.TabIndex = 11;
            this.lblNgayTra.Text = "Ngày trả:";
            // 
            // dtpNgayTra
            // 
            this.dtpNgayTra.Enabled = false;
            this.dtpNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayTra.Location = new System.Drawing.Point(100, 257);
            this.dtpNgayTra.Name = "dtpNgayTra";
            this.dtpNgayTra.Size = new System.Drawing.Size(150, 20);
            this.dtpNgayTra.TabIndex = 10;
            // 
            // lblNguoiNhan
            // 
            this.lblNguoiNhan.AutoSize = true;
            this.lblNguoiNhan.Location = new System.Drawing.Point(20, 290);
            this.lblNguoiNhan.Name = "lblNguoiNhan";
            this.lblNguoiNhan.Size = new System.Drawing.Size(65, 13);
            this.lblNguoiNhan.TabIndex = 9;
            this.lblNguoiNhan.Text = "Người nhận:";
            // 
            // txtNguoiNhan
            // 
            this.txtNguoiNhan.Enabled = false;
            this.txtNguoiNhan.Location = new System.Drawing.Point(100, 287);
            this.txtNguoiNhan.Name = "txtNguoiNhan";
            this.txtNguoiNhan.Size = new System.Drawing.Size(200, 20);
            this.txtNguoiNhan.TabIndex = 8;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(20, 320);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(47, 13);
            this.lblGhiChu.TabIndex = 7;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(100, 317);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(300, 60);
            this.txtGhiChu.TabIndex = 6;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(20, 390);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(110, 390);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTraDo
            // 
            this.btnTraDo.Enabled = false;
            this.btnTraDo.Location = new System.Drawing.Point(200, 390);
            this.btnTraDo.Name = "btnTraDo";
            this.btnTraDo.Size = new System.Drawing.Size(75, 30);
            this.btnTraDo.TabIndex = 3;
            this.btnTraDo.Text = "Trả đồ";
            this.btnTraDo.UseVisualStyleBackColor = true;
            this.btnTraDo.Click += new System.EventHandler(this.btnTraDo_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(290, 390);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(380, 390);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lvLostFound
            // 
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmLostFound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 450);
            this.Controls.Add(this.lvLostFound);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnTraDo);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.txtNguoiNhan);
            this.Controls.Add(this.lblNguoiNhan);
            this.Controls.Add(this.dtpNgayTra);
            this.Controls.Add(this.lblNgayTra);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.txtDiaDiemTim);
            this.Controls.Add(this.lblDiaDiemTim);
            this.Controls.Add(this.dtpNgayTimThay);
            this.Controls.Add(this.lblNgayTimThay);
            this.Controls.Add(this.cbMaKH);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.cbMaNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.cbMaCN);
            this.Controls.Add(this.lblMaCN);
            this.Controls.Add(this.txtTenDo);
            this.Controls.Add(this.lblTenDo);
            this.Controls.Add(this.txtMaLF);
            this.Controls.Add(this.lblMaLF);
            this.Name = "frmLostFound";
            this.Text = "Quản lý Đồ Thất Lạc";
            this.Load += new System.EventHandler(this.frmLostFound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

