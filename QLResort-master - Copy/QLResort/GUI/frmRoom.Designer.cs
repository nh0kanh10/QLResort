namespace QLResort.GUI
{
    partial class frmRoom
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.Label lblSoPhong;
        private System.Windows.Forms.TextBox txtSoPhong;
        private System.Windows.Forms.Label lblMaCN;
        private System.Windows.Forms.ComboBox cbMaCN;
        private System.Windows.Forms.Label lblMaLoaiPhong;
        private System.Windows.Forms.ComboBox cbMaLoaiPhong;
        private System.Windows.Forms.Label lblViTri;
        private System.Windows.Forms.TextBox txtViTri;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView lvRooms;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pbRoomImage;
        private System.Windows.Forms.Label lblAnhPhong;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.Button btnDeleteImage;

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
            this.pbRoomImage = new System.Windows.Forms.PictureBox();
            this.lblAnhPhong = new System.Windows.Forms.Label();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.btnDeleteImage = new System.Windows.Forms.Button();

            this.lblMaPhong = new System.Windows.Forms.Label();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.lblSoPhong = new System.Windows.Forms.Label();
            this.txtSoPhong = new System.Windows.Forms.TextBox();
            this.lblMaCN = new System.Windows.Forms.Label();
            this.cbMaCN = new System.Windows.Forms.ComboBox();
            this.lblMaLoaiPhong = new System.Windows.Forms.Label();
            this.cbMaLoaiPhong = new System.Windows.Forms.ComboBox();
            this.lblViTri = new System.Windows.Forms.Label();
            this.txtViTri = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lvRooms = new System.Windows.Forms.ListView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoomImage)).BeginInit();
            this.SuspendLayout();

            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Location = new System.Drawing.Point(20, 20);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(60, 13);
            this.lblMaPhong.Text = "Mã phòng:";
            
            this.txtMaPhong.Enabled = false;
            this.txtMaPhong.Location = new System.Drawing.Point(90, 17);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(150, 20);

            this.lblSoPhong.AutoSize = true;
            this.lblSoPhong.Location = new System.Drawing.Point(20, 50);
            this.lblSoPhong.Name = "lblSoPhong";
            this.lblSoPhong.Size = new System.Drawing.Size(60, 13);
            this.lblSoPhong.Text = "Số phòng:";
            
            this.txtSoPhong.Location = new System.Drawing.Point(90, 47);
            this.txtSoPhong.Name = "txtSoPhong";
            this.txtSoPhong.Size = new System.Drawing.Size(200, 20);

            this.lblMaCN.AutoSize = true;
            this.lblMaCN.Location = new System.Drawing.Point(20, 80);
            this.lblMaCN.Name = "lblMaCN";
            this.lblMaCN.Size = new System.Drawing.Size(70, 13);
            this.lblMaCN.Text = "Chi nhánh:";
            
            this.cbMaCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaCN.FormattingEnabled = true;
            this.cbMaCN.Location = new System.Drawing.Point(90, 77);
            this.cbMaCN.Name = "cbMaCN";
            this.cbMaCN.Size = new System.Drawing.Size(250, 21);

            this.lblMaLoaiPhong.AutoSize = true;
            this.lblMaLoaiPhong.Location = new System.Drawing.Point(20, 110);
            this.lblMaLoaiPhong.Name = "lblMaLoaiPhong";
            this.lblMaLoaiPhong.Size = new System.Drawing.Size(70, 13);
            this.lblMaLoaiPhong.Text = "Loại phòng:";
            
            this.cbMaLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaLoaiPhong.FormattingEnabled = true;
            this.cbMaLoaiPhong.Location = new System.Drawing.Point(90, 107);
            this.cbMaLoaiPhong.Name = "cbMaLoaiPhong";
            this.cbMaLoaiPhong.Size = new System.Drawing.Size(250, 21);

            this.lblViTri.AutoSize = true;
            this.lblViTri.Location = new System.Drawing.Point(20, 140);
            this.lblViTri.Name = "lblViTri";
            this.lblViTri.Size = new System.Drawing.Size(38, 13);
            this.lblViTri.Text = "Vị trí:";
            
            this.txtViTri.Location = new System.Drawing.Point(90, 137);
            this.txtViTri.Name = "txtViTri";
            this.txtViTri.Size = new System.Drawing.Size(250, 20);

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(20, 170);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(60, 13);
            this.lblTrangThai.Text = "Trạng thái:";
            
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.FormattingEnabled = true;
            this.cbTrangThai.Location = new System.Drawing.Point(90, 167);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(200, 21);

            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(20, 200);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(48, 13);
            this.lblGhiChu.Text = "Ghi chú:";
            
            this.txtGhiChu.Location = new System.Drawing.Point(90, 197);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(300, 60);

            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.Location = new System.Drawing.Point(20, 270);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(73, 17);
            this.cbIsActive.Text = "Hoạt động";
            this.cbIsActive.UseVisualStyleBackColor = true;

            // PictureBox for room image
            this.pbRoomImage.Location = new System.Drawing.Point(20, 300);
            this.pbRoomImage.Name = "pbRoomImage";
            this.pbRoomImage.Size = new System.Drawing.Size(200, 150);
            this.pbRoomImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRoomImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRoomImage.BackColor = System.Drawing.Color.White;

            // Label for image
            
            this.lblAnhPhong.AutoSize = true;
            this.lblAnhPhong.Location = new System.Drawing.Point(20, 280);
            this.lblAnhPhong.Name = "lblAnhPhong";
            this.lblAnhPhong.Size = new System.Drawing.Size(60, 13);
            this.lblAnhPhong.Text = "Ảnh phòng:";

            // Button upload image
            
            this.btnUploadImage.Location = new System.Drawing.Point(230, 300);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(80, 30);
            this.btnUploadImage.Text = "Chọn ảnh";
            this.btnUploadImage.UseVisualStyleBackColor = true;

            // Button delete image
            
            this.btnDeleteImage.Location = new System.Drawing.Point(230, 340);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(80, 30);
            this.btnDeleteImage.Text = "Xóa ảnh";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Enabled = false;

            this.btnThem.Location = new System.Drawing.Point(20, 470);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;

            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(110, 470);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;

            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(200, 470);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;

            this.btnReset.Location = new System.Drawing.Point(290, 470);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;

            this.lvRooms.FullRowSelect = true;
            this.lvRooms.GridLines = true;
            this.lvRooms.HideSelection = false;
            this.lvRooms.Location = new System.Drawing.Point(420, 20);
            this.lvRooms.Name = "lvRooms";
            this.lvRooms.Size = new System.Drawing.Size(700, 480);
            this.lvRooms.TabIndex = 0;
            this.lvRooms.UseCompatibleStateImageBehavior = false;
            this.lvRooms.View = System.Windows.Forms.View.Details;
            this.lvRooms.Columns.Add("Mã phòng", 80);
            this.lvRooms.Columns.Add("Số phòng", 100);
            this.lvRooms.Columns.Add("Chi nhánh", 80);
            this.lvRooms.Columns.Add("Loại phòng", 100);
            this.lvRooms.Columns.Add("Vị trí", 150);
            this.lvRooms.Columns.Add("Trạng thái", 100);
            this.lvRooms.Columns.Add("Hoạt động", 80);

            this.errorProvider1.ContainerControl = this;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 530);
            this.Controls.Add(this.btnDeleteImage);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.lblAnhPhong);
            this.Controls.Add(this.pbRoomImage);
            this.Controls.Add(this.lvRooms);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.txtViTri);
            this.Controls.Add(this.lblViTri);
            this.Controls.Add(this.cbMaLoaiPhong);
            this.Controls.Add(this.lblMaLoaiPhong);
            this.Controls.Add(this.cbMaCN);
            this.Controls.Add(this.lblMaCN);
            this.Controls.Add(this.txtSoPhong);
            this.Controls.Add(this.lblSoPhong);
            this.Controls.Add(this.txtMaPhong);
            this.Controls.Add(this.lblMaPhong);
            this.Name = "frmRoom";
            this.Text = "Quản lý Phòng";
            this.Load += new System.EventHandler(this.frmRoom_Load);
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRoomImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

