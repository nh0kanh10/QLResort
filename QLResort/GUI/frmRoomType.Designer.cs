namespace QLResort.GUI
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numSoPhongTrongNha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSucChuaToiDa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // Controls setup
            this.lblMaLP.AutoSize = true;
            this.lblMaLP.Location = new System.Drawing.Point(20, 20);
            this.lblMaLP.Name = "lblMaLP";
            this.lblMaLP.Size = new System.Drawing.Size(80, 13);
            this.lblMaLP.Text = "Mã loại phòng:";
            
            this.txtMaLP.Enabled = false;
            this.txtMaLP.Location = new System.Drawing.Point(110, 17);
            this.txtMaLP.Name = "txtMaLP";
            this.txtMaLP.Size = new System.Drawing.Size(150, 20);

            this.lblTenLP.AutoSize = true;
            this.lblTenLP.Location = new System.Drawing.Point(20, 50);
            this.lblTenLP.Name = "lblTenLP";
            this.lblTenLP.Size = new System.Drawing.Size(84, 13);
            this.lblTenLP.Text = "Tên loại phòng:";
            
            this.txtTenLP.Location = new System.Drawing.Point(110, 47);
            this.txtTenLP.Name = "txtTenLP";
            this.txtTenLP.Size = new System.Drawing.Size(300, 20);

            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(20, 80);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(38, 13);
            this.lblMoTa.Text = "Mô tả:";
            
            this.txtMoTa.Location = new System.Drawing.Point(110, 77);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(300, 60);

            this.cbIsNhaNguyenCan.AutoSize = true;
            this.cbIsNhaNguyenCan.Location = new System.Drawing.Point(20, 150);
            this.cbIsNhaNguyenCan.Name = "cbIsNhaNguyenCan";
            this.cbIsNhaNguyenCan.Size = new System.Drawing.Size(100, 17);
            this.cbIsNhaNguyenCan.Text = "Nhà nguyên căn";
            this.cbIsNhaNguyenCan.UseVisualStyleBackColor = true;

            this.lblSoPhongTrongNha.AutoSize = true;
            this.lblSoPhongTrongNha.Location = new System.Drawing.Point(20, 180);
            this.lblSoPhongTrongNha.Name = "lblSoPhongTrongNha";
            this.lblSoPhongTrongNha.Size = new System.Drawing.Size(100, 13);
            this.lblSoPhongTrongNha.Text = "Số phòng trong nhà:";
            
            this.numSoPhongTrongNha.Location = new System.Drawing.Point(130, 177);
            this.numSoPhongTrongNha.Minimum = 1;
            this.numSoPhongTrongNha.Name = "numSoPhongTrongNha";
            this.numSoPhongTrongNha.Size = new System.Drawing.Size(100, 20);
            this.numSoPhongTrongNha.Value = 1;

            this.lblGiaTheoGio.AutoSize = true;
            this.lblGiaTheoGio.Location = new System.Drawing.Point(20, 210);
            this.lblGiaTheoGio.Name = "lblGiaTheoGio";
            this.lblGiaTheoGio.Size = new System.Drawing.Size(70, 13);
            this.lblGiaTheoGio.Text = "Giá theo giờ:";
            
            this.txtGiaTheoGio.Location = new System.Drawing.Point(110, 207);
            this.txtGiaTheoGio.Name = "txtGiaTheoGio";
            this.txtGiaTheoGio.Size = new System.Drawing.Size(150, 20);

            this.lblGiaTheoNgay.AutoSize = true;
            this.lblGiaTheoNgay.Location = new System.Drawing.Point(20, 240);
            this.lblGiaTheoNgay.Name = "lblGiaTheoNgay";
            this.lblGiaTheoNgay.Size = new System.Drawing.Size(75, 13);
            this.lblGiaTheoNgay.Text = "Giá theo ngày:";
            
            this.txtGiaTheoNgay.Location = new System.Drawing.Point(110, 237);
            this.txtGiaTheoNgay.Name = "txtGiaTheoNgay";
            this.txtGiaTheoNgay.Size = new System.Drawing.Size(150, 20);

            this.lblGiaTheoThang.AutoSize = true;
            this.lblGiaTheoThang.Location = new System.Drawing.Point(20, 270);
            this.lblGiaTheoThang.Name = "lblGiaTheoThang";
            this.lblGiaTheoThang.Size = new System.Drawing.Size(80, 13);
            this.lblGiaTheoThang.Text = "Giá theo tháng:";
            
            this.txtGiaTheoThang.Location = new System.Drawing.Point(110, 267);
            this.txtGiaTheoThang.Name = "txtGiaTheoThang";
            this.txtGiaTheoThang.Size = new System.Drawing.Size(150, 20);

            this.lblSucChuaToiDa.AutoSize = true;
            this.lblSucChuaToiDa.Location = new System.Drawing.Point(20, 300);
            this.lblSucChuaToiDa.Name = "lblSucChuaToiDa";
            this.lblSucChuaToiDa.Size = new System.Drawing.Size(85, 13);
            this.lblSucChuaToiDa.Text = "Sức chứa tối đa:";
            
            this.numSucChuaToiDa.Location = new System.Drawing.Point(110, 297);
            this.numSucChuaToiDa.Minimum = 1;
            this.numSucChuaToiDa.Name = "numSucChuaToiDa";
            this.numSucChuaToiDa.Size = new System.Drawing.Size(100, 20);
            this.numSucChuaToiDa.Value = 1;

            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.Location = new System.Drawing.Point(20, 330);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(73, 17);
            this.cbIsActive.Text = "Hoạt động";
            this.cbIsActive.UseVisualStyleBackColor = true;

            this.btnThem.Location = new System.Drawing.Point(20, 370);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;

            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(110, 370);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;

            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(200, 370);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;

            this.btnReset.Location = new System.Drawing.Point(290, 370);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;

            this.lvRoomTypes.FullRowSelect = true;
            this.lvRoomTypes.GridLines = true;
            this.lvRoomTypes.HideSelection = false;
            this.lvRoomTypes.Location = new System.Drawing.Point(420, 20);
            this.lvRoomTypes.Name = "lvRoomTypes";
            this.lvRoomTypes.Size = new System.Drawing.Size(700, 400);
            this.lvRoomTypes.TabIndex = 0;
            this.lvRoomTypes.UseCompatibleStateImageBehavior = false;
            this.lvRoomTypes.View = System.Windows.Forms.View.Details;
            this.lvRoomTypes.Columns.Add("Mã LP", 80);
            this.lvRoomTypes.Columns.Add("Tên LP", 150);
            this.lvRoomTypes.Columns.Add("Loại", 100);
            this.lvRoomTypes.Columns.Add("Số phòng", 80);
            this.lvRoomTypes.Columns.Add("Giá/ngày", 100);
            this.lvRoomTypes.Columns.Add("Sức chứa", 80);
            this.lvRoomTypes.Columns.Add("Trạng thái", 80);

            this.errorProvider1.ContainerControl = this;

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







