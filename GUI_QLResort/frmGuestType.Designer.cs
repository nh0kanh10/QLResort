
using System.ComponentModel;
using System.Windows.Forms;

namespace GUI_QLResort
{
    partial class frmGuestType
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.ListView lvGuestTypes;
        private System.Windows.Forms.ColumnHeader colMaLKH;
        private System.Windows.Forms.ColumnHeader colTenLKH;
        private System.Windows.Forms.ColumnHeader colGiamGia;
        private System.Windows.Forms.ColumnHeader colDiemToiThieu;
        private System.Windows.Forms.ColumnHeader colStatus;
        
        private System.Windows.Forms.Label lblMaLKH;
        private System.Windows.Forms.TextBox txtMaLKH;
        private System.Windows.Forms.Label lblTenLKH;
        private System.Windows.Forms.TextBox txtTenLKH;
        private System.Windows.Forms.Label lblGiamGia;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.Label lblDiemToiThieu;
        private System.Windows.Forms.TextBox txtDiemToiThieu;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.CheckBox cbIsActive;
        
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReset;
        
        private System.Windows.Forms.ErrorProvider errorProvider;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtDiemToiThieu = new System.Windows.Forms.TextBox();
            this.lblDiemToiThieu = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.lblGiamGia = new System.Windows.Forms.Label();
            this.txtTenLKH = new System.Windows.Forms.TextBox();
            this.lblTenLKH = new System.Windows.Forms.Label();
            this.txtMaLKH = new System.Windows.Forms.TextBox();
            this.lblMaLKH = new System.Windows.Forms.Label();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.lvGuestTypes = new System.Windows.Forms.ListView();
            this.colMaLKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenLKH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGiamGia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDiemToiThieu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpThongTin.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(280, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ LOẠI KHÁCH HÀNG";
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.cbIsActive);
            this.grpThongTin.Controls.Add(this.btnReset);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnSua);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.txtMoTa);
            this.grpThongTin.Controls.Add(this.lblMoTa);
            this.grpThongTin.Controls.Add(this.txtDiemToiThieu);
            this.grpThongTin.Controls.Add(this.lblDiemToiThieu);
            this.grpThongTin.Controls.Add(this.txtGiamGia);
            this.grpThongTin.Controls.Add(this.lblGiamGia);
            this.grpThongTin.Controls.Add(this.txtTenLKH);
            this.grpThongTin.Controls.Add(this.lblTenLKH);
            this.grpThongTin.Controls.Add(this.txtMaLKH);
            this.grpThongTin.Controls.Add(this.lblMaLKH);
            this.grpThongTin.Location = new System.Drawing.Point(20, 70);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(900, 200);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin loại khách hàng";
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.Location = new System.Drawing.Point(500, 80);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(117, 21);
            this.cbIsActive.TabIndex = 14;
            this.cbIsActive.Text = "Đang hoạt động";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(540, 140);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 40);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(400, 140);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 40);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(260, 140);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 40);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(120, 140);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 40);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(500, 30);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(350, 40);
            this.txtMoTa.TabIndex = 9;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(420, 33);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(46, 17);
            this.lblMoTa.TabIndex = 8;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // txtDiemToiThieu
            // 
            this.txtDiemToiThieu.Location = new System.Drawing.Point(120, 110);
            this.txtDiemToiThieu.Name = "txtDiemToiThieu";
            this.txtDiemToiThieu.Size = new System.Drawing.Size(250, 23);
            this.txtDiemToiThieu.TabIndex = 7;
            this.txtDiemToiThieu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblDiemToiThieu
            // 
            this.lblDiemToiThieu.AutoSize = true;
            this.lblDiemToiThieu.Location = new System.Drawing.Point(20, 113);
            this.lblDiemToiThieu.Name = "lblDiemToiThieu";
            this.lblDiemToiThieu.Size = new System.Drawing.Size(98, 17);
            this.lblDiemToiThieu.TabIndex = 6;
            this.lblDiemToiThieu.Text = "Điểm tối thiểu:";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Location = new System.Drawing.Point(120, 80);
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(250, 23);
            this.txtGiamGia.TabIndex = 5;
            this.txtGiamGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblGiamGia
            // 
            this.lblGiamGia.AutoSize = true;
            this.lblGiamGia.Location = new System.Drawing.Point(20, 83);
            this.lblGiamGia.Name = "lblGiamGia";
            this.lblGiamGia.Size = new System.Drawing.Size(89, 17);
            this.lblGiamGia.TabIndex = 4;
            this.lblGiamGia.Text = "Giảm giá (%):";
            // 
            // txtTenLKH
            // 
            this.txtTenLKH.Location = new System.Drawing.Point(120, 50);
            this.txtTenLKH.Name = "txtTenLKH";
            this.txtTenLKH.Size = new System.Drawing.Size(250, 23);
            this.txtTenLKH.TabIndex = 3;
            // 
            // lblTenLKH
            // 
            this.lblTenLKH.AutoSize = true;
            this.lblTenLKH.Location = new System.Drawing.Point(20, 53);
            this.lblTenLKH.Name = "lblTenLKH";
            this.lblTenLKH.Size = new System.Drawing.Size(65, 17);
            this.lblTenLKH.TabIndex = 2;
            this.lblTenLKH.Text = "Tên loại:";
            // 
            // txtMaLKH
            // 
            this.txtMaLKH.Location = new System.Drawing.Point(120, 20);
            this.txtMaLKH.Name = "txtMaLKH";
            this.txtMaLKH.Size = new System.Drawing.Size(250, 23);
            this.txtMaLKH.TabIndex = 1;
            // 
            // lblMaLKH
            // 
            this.lblMaLKH.AutoSize = true;
            this.lblMaLKH.Location = new System.Drawing.Point(20, 23);
            this.lblMaLKH.Name = "lblMaLKH";
            this.lblMaLKH.Size = new System.Drawing.Size(59, 17);
            this.lblMaLKH.TabIndex = 0;
            this.lblMaLKH.Text = "Mã loại:";
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.lvGuestTypes);
            this.grpDanhSach.Location = new System.Drawing.Point(20, 280);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(900, 300);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Danh sách loại khách hàng";
            // 
            // lvGuestTypes
            // 
            this.lvGuestTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaLKH,
            this.colTenLKH,
            this.colGiamGia,
            this.colDiemToiThieu,
            this.colStatus});
            this.lvGuestTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvGuestTypes.FullRowSelect = true;
            this.lvGuestTypes.GridLines = true;
            this.lvGuestTypes.Location = new System.Drawing.Point(3, 19);
            this.lvGuestTypes.MultiSelect = false;
            this.lvGuestTypes.Name = "lvGuestTypes";
            this.lvGuestTypes.Size = new System.Drawing.Size(894, 278);
            this.lvGuestTypes.TabIndex = 0;
            this.lvGuestTypes.UseCompatibleStateImageBehavior = false;
            this.lvGuestTypes.View = System.Windows.Forms.View.Details;
            this.lvGuestTypes.SelectedIndexChanged += new System.EventHandler(this.lvGuestTypes_SelectedIndexChanged);
            // 
            // colMaLKH
            // 
            this.colMaLKH.Text = "Mã loại";
            this.colMaLKH.Width = 100;
            // 
            // colTenLKH
            // 
            this.colTenLKH.Text = "Tên loại";
            this.colTenLKH.Width = 200;
            // 
            // colGiamGia
            // 
            this.colGiamGia.Text = "Giảm giá (%)";
            this.colGiamGia.Width = 120;
            this.colGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colDiemToiThieu
            // 
            this.colDiemToiThieu.Text = "Điểm tối thiểu";
            this.colDiemToiThieu.Width = 120;
            this.colDiemToiThieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Trạng thái";
            this.colStatus.Width = 100;
            this.colStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmGuestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGuestType";
            this.Text = "Quản lý Loại Khách hàng";
            this.Load += new System.EventHandler(this.frmGuestType_Load);
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
