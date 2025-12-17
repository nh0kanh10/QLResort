namespace GUI_QLResort
{
    partial class frmRoomType
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaLP;
        private System.Windows.Forms.TextBox txtMaLP;
        private System.Windows.Forms.Label lblTenLP;
        private System.Windows.Forms.TextBox txtTenLP;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.CheckBox cbIsNhaNguyenCan;
        private System.Windows.Forms.Label lblSoPhongTrongNha;
        private System.Windows.Forms.NumericUpDown numSoPhongTrongNha;
        private System.Windows.Forms.Label lblGiaTheoGio;
        private System.Windows.Forms.TextBox txtGiaTheoGio;
        private System.Windows.Forms.Label lblGiaTheoNgay;
        private System.Windows.Forms.TextBox txtGiaTheoNgay;
        private System.Windows.Forms.Label lblGiaTheoThang;
        private System.Windows.Forms.TextBox txtGiaTheoThang;
        private System.Windows.Forms.Label lblSucChuaToiDa;
        private System.Windows.Forms.NumericUpDown numSucChuaToiDa;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView lvRoomTypes;
        private System.Windows.Forms.ColumnHeader colMaLP;
        private System.Windows.Forms.ColumnHeader colTenLP;
        private System.Windows.Forms.ColumnHeader colLoai;
        private System.Windows.Forms.ColumnHeader colSoPhong;
        private System.Windows.Forms.ColumnHeader colGia;
        private System.Windows.Forms.ColumnHeader colSucChua;
        private System.Windows.Forms.ColumnHeader colIsActive;
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
            this.lblMaLP = new System.Windows.Forms.Label();
            this.txtMaLP = new System.Windows.Forms.TextBox();
            this.lblTenLP = new System.Windows.Forms.Label();
            this.txtTenLP = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.cbIsNhaNguyenCan = new System.Windows.Forms.CheckBox();
            this.lblSoPhongTrongNha = new System.Windows.Forms.Label();
            this.numSoPhongTrongNha = new System.Windows.Forms.NumericUpDown();
            this.lblGiaTheoGio = new System.Windows.Forms.Label();
            this.txtGiaTheoGio = new System.Windows.Forms.TextBox();
            this.lblGiaTheoNgay = new System.Windows.Forms.Label();
            this.txtGiaTheoNgay = new System.Windows.Forms.TextBox();
            this.lblGiaTheoThang = new System.Windows.Forms.Label();
            this.txtGiaTheoThang = new System.Windows.Forms.TextBox();
            this.lblSucChuaToiDa = new System.Windows.Forms.Label();
            this.numSucChuaToiDa = new System.Windows.Forms.NumericUpDown();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lvRoomTypes = new System.Windows.Forms.ListView();
            this.colMaLP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenLP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoPhong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSucChua = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numSoPhongTrongNha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSucChuaToiDa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaLP
            // 
            this.lblMaLP.AutoSize = true;
            this.lblMaLP.Location = new System.Drawing.Point(20, 20);
            this.lblMaLP.Name = "lblMaLP";
            this.lblMaLP.Size = new System.Drawing.Size(77, 13);
            this.lblMaLP.TabIndex = 22;
            this.lblMaLP.Text = "Mã loại phòng:";
            // 
            // txtMaLP
            // 
            this.txtMaLP.Enabled = false;
            this.txtMaLP.Location = new System.Drawing.Point(110, 17);
            this.txtMaLP.Name = "txtMaLP";
            this.txtMaLP.Size = new System.Drawing.Size(150, 20);
            this.txtMaLP.TabIndex = 21;
            // 
            // lblTenLP
            // 
            this.lblTenLP.AutoSize = true;
            this.lblTenLP.Location = new System.Drawing.Point(20, 50);
            this.lblTenLP.Name = "lblTenLP";
            this.lblTenLP.Size = new System.Drawing.Size(81, 13);
            this.lblTenLP.TabIndex = 20;
            this.lblTenLP.Text = "Tên loại phòng:";
            // 
            // txtTenLP
            // 
            this.txtTenLP.Location = new System.Drawing.Point(110, 47);
            this.txtTenLP.Name = "txtTenLP";
            this.txtTenLP.Size = new System.Drawing.Size(300, 20);
            this.txtTenLP.TabIndex = 19;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(20, 80);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(37, 13);
            this.lblMoTa.TabIndex = 18;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(110, 77);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(300, 60);
            this.txtMoTa.TabIndex = 17;
            // 
            // cbIsNhaNguyenCan
            // 
            this.cbIsNhaNguyenCan.AutoSize = true;
            this.cbIsNhaNguyenCan.Location = new System.Drawing.Point(20, 150);
            this.cbIsNhaNguyenCan.Name = "cbIsNhaNguyenCan";
            this.cbIsNhaNguyenCan.Size = new System.Drawing.Size(105, 17);
            this.cbIsNhaNguyenCan.TabIndex = 16;
            this.cbIsNhaNguyenCan.Text = "Nhà nguyên căn";
            this.cbIsNhaNguyenCan.UseVisualStyleBackColor = true;
            this.cbIsNhaNguyenCan.Click += new System.EventHandler(this.cbIsNhaNguyenCan_CheckedChanged);
            // 
            // lblSoPhongTrongNha
            // 
            this.lblSoPhongTrongNha.AutoSize = true;
            this.lblSoPhongTrongNha.Location = new System.Drawing.Point(20, 180);
            this.lblSoPhongTrongNha.Name = "lblSoPhongTrongNha";
            this.lblSoPhongTrongNha.Size = new System.Drawing.Size(104, 13);
            this.lblSoPhongTrongNha.TabIndex = 15;
            this.lblSoPhongTrongNha.Text = "Số phòng trong nhà:";
            // 
            // numSoPhongTrongNha
            // 
            this.numSoPhongTrongNha.Location = new System.Drawing.Point(130, 177);
            this.numSoPhongTrongNha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoPhongTrongNha.Name = "numSoPhongTrongNha";
            this.numSoPhongTrongNha.Size = new System.Drawing.Size(100, 20);
            this.numSoPhongTrongNha.TabIndex = 14;
            this.numSoPhongTrongNha.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblGiaTheoGio
            // 
            this.lblGiaTheoGio.AutoSize = true;
            this.lblGiaTheoGio.Location = new System.Drawing.Point(20, 210);
            this.lblGiaTheoGio.Name = "lblGiaTheoGio";
            this.lblGiaTheoGio.Size = new System.Drawing.Size(67, 13);
            this.lblGiaTheoGio.TabIndex = 13;
            this.lblGiaTheoGio.Text = "Giá theo giờ:";
            // 
            // txtGiaTheoGio
            // 
            this.txtGiaTheoGio.Location = new System.Drawing.Point(110, 207);
            this.txtGiaTheoGio.Name = "txtGiaTheoGio";
            this.txtGiaTheoGio.Size = new System.Drawing.Size(150, 20);
            this.txtGiaTheoGio.TabIndex = 12;
            // 
            // lblGiaTheoNgay
            // 
            this.lblGiaTheoNgay.AutoSize = true;
            this.lblGiaTheoNgay.Location = new System.Drawing.Point(20, 240);
            this.lblGiaTheoNgay.Name = "lblGiaTheoNgay";
            this.lblGiaTheoNgay.Size = new System.Drawing.Size(76, 13);
            this.lblGiaTheoNgay.TabIndex = 11;
            this.lblGiaTheoNgay.Text = "Giá theo ngày:";
            // 
            // txtGiaTheoNgay
            // 
            this.txtGiaTheoNgay.Location = new System.Drawing.Point(110, 237);
            this.txtGiaTheoNgay.Name = "txtGiaTheoNgay";
            this.txtGiaTheoNgay.Size = new System.Drawing.Size(150, 20);
            this.txtGiaTheoNgay.TabIndex = 10;
            // 
            // lblGiaTheoThang
            // 
            this.lblGiaTheoThang.AutoSize = true;
            this.lblGiaTheoThang.Location = new System.Drawing.Point(20, 270);
            this.lblGiaTheoThang.Name = "lblGiaTheoThang";
            this.lblGiaTheoThang.Size = new System.Drawing.Size(80, 13);
            this.lblGiaTheoThang.TabIndex = 9;
            this.lblGiaTheoThang.Text = "Giá theo tháng:";
            // 
            // txtGiaTheoThang
            // 
            this.txtGiaTheoThang.Location = new System.Drawing.Point(110, 267);
            this.txtGiaTheoThang.Name = "txtGiaTheoThang";
            this.txtGiaTheoThang.Size = new System.Drawing.Size(150, 20);
            this.txtGiaTheoThang.TabIndex = 8;
            // 
            // lblSucChuaToiDa
            // 
            this.lblSucChuaToiDa.AutoSize = true;
            this.lblSucChuaToiDa.Location = new System.Drawing.Point(20, 300);
            this.lblSucChuaToiDa.Name = "lblSucChuaToiDa";
            this.lblSucChuaToiDa.Size = new System.Drawing.Size(86, 13);
            this.lblSucChuaToiDa.TabIndex = 7;
            this.lblSucChuaToiDa.Text = "Sức chứa tối đa:";
            // 
            // numSucChuaToiDa
            // 
            this.numSucChuaToiDa.Location = new System.Drawing.Point(110, 297);
            this.numSucChuaToiDa.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSucChuaToiDa.Name = "numSucChuaToiDa";
            this.numSucChuaToiDa.Size = new System.Drawing.Size(100, 20);
            this.numSucChuaToiDa.TabIndex = 6;
            this.numSucChuaToiDa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.Location = new System.Drawing.Point(20, 330);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(77, 17);
            this.cbIsActive.TabIndex = 5;
            this.cbIsActive.Text = "Hoạt động";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(20, 370);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(110, 370);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(200, 370);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(290, 370);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lvRoomTypes
            // 
            this.lvRoomTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaLP,
            this.colTenLP,
            this.colLoai,
            this.colSoPhong,
            this.colGia,
            this.colSucChua,
            this.colIsActive});
            this.lvRoomTypes.FullRowSelect = true;
            this.lvRoomTypes.GridLines = true;
            this.lvRoomTypes.HideSelection = false;
            this.lvRoomTypes.Location = new System.Drawing.Point(420, 20);
            this.lvRoomTypes.Name = "lvRoomTypes";
            this.lvRoomTypes.Size = new System.Drawing.Size(700, 400);
            this.lvRoomTypes.TabIndex = 0;
            this.lvRoomTypes.UseCompatibleStateImageBehavior = false;
            this.lvRoomTypes.View = System.Windows.Forms.View.Details;
            this.lvRoomTypes.SelectedIndexChanged += new System.EventHandler(this.lvRoomTypes_SelectedIndexChanged);
            // 
            // colMaLP
            // 
            this.colMaLP.Text = "Mã Loại";
            this.colMaLP.Width = 80;
            // 
            // colTenLP
            // 
            this.colTenLP.Text = "Tên Loại";
            this.colTenLP.Width = 150;
            // 
            // colLoai
            // 
            this.colLoai.Text = "Loại Nhà";
            this.colLoai.Width = 100;
            // 
            // colSoPhong
            // 
            this.colSoPhong.Text = "Số Phòng";
            this.colSoPhong.Width = 80;
            // 
            // colGia
            // 
            this.colGia.Text = "Giá Ngày";
            this.colGia.Width = 100;
            // 
            // colSucChua
            // 
            this.colSucChua.Text = "Sức Chứa";
            this.colSucChua.Width = 80;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "Active";
            this.colIsActive.Width = 50;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmRoomType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 430);
            this.Controls.Add(this.lvRoomTypes);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.numSucChuaToiDa);
            this.Controls.Add(this.lblSucChuaToiDa);
            this.Controls.Add(this.txtGiaTheoThang);
            this.Controls.Add(this.lblGiaTheoThang);
            this.Controls.Add(this.txtGiaTheoNgay);
            this.Controls.Add(this.lblGiaTheoNgay);
            this.Controls.Add(this.txtGiaTheoGio);
            this.Controls.Add(this.lblGiaTheoGio);
            this.Controls.Add(this.numSoPhongTrongNha);
            this.Controls.Add(this.lblSoPhongTrongNha);
            this.Controls.Add(this.cbIsNhaNguyenCan);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.txtTenLP);
            this.Controls.Add(this.lblTenLP);
            this.Controls.Add(this.txtMaLP);
            this.Controls.Add(this.lblMaLP);
            this.Name = "frmRoomType";
            this.Text = "Quản lý Loại Phòng";
            this.Load += new System.EventHandler(this.frmRoomType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSoPhongTrongNha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSucChuaToiDa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}







