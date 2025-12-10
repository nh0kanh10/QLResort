namespace QLResort.GUI
{
    partial class frmService
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaDV;
        private System.Windows.Forms.TextBox txtMaDV;
        private System.Windows.Forms.Label lblTenDV;
        private System.Windows.Forms.TextBox txtTenDV;
        private System.Windows.Forms.Label lBUSoaiDV;
        private System.Windows.Forms.ComboBox cbLoaiDV;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.CheckBox cbChoPhepDoiDiem;
        private System.Windows.Forms.Label lblGiaTriDoiDiem;
        private System.Windows.Forms.TextBox txtGiaTriDoiDiem;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView lvServices;
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
            this.lblMaDV = new System.Windows.Forms.Label();
            this.txtMaDV = new System.Windows.Forms.TextBox();
            this.lblTenDV = new System.Windows.Forms.Label();
            this.txtTenDV = new System.Windows.Forms.TextBox();
            this.lBUSoaiDV = new System.Windows.Forms.Label();
            this.cbLoaiDV = new System.Windows.Forms.ComboBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.lblGia = new System.Windows.Forms.Label();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.cbChoPhepDoiDiem = new System.Windows.Forms.CheckBox();
            this.lblGiaTriDoiDiem = new System.Windows.Forms.Label();
            this.txtGiaTriDoiDiem = new System.Windows.Forms.TextBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lvServices = new System.Windows.Forms.ListView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // lblMaDV
            this.lblMaDV.AutoSize = true;
            this.lblMaDV.Location = new System.Drawing.Point(20, 20);
            this.lblMaDV.Name = "lblMaDV";
            this.lblMaDV.Size = new System.Drawing.Size(70, 13);
            this.lblMaDV.Text = "Mã dịch vụ:";
            // txtMaDV
            this.txtMaDV.Enabled = false;
            this.txtMaDV.Location = new System.Drawing.Point(100, 17);
            this.txtMaDV.Name = "txtMaDV";
            this.txtMaDV.Size = new System.Drawing.Size(150, 20);
            // lblTenDV
            this.lblTenDV.AutoSize = true;
            this.lblTenDV.Location = new System.Drawing.Point(20, 50);
            this.lblTenDV.Name = "lblTenDV";
            this.lblTenDV.Size = new System.Drawing.Size(74, 13);
            this.lblTenDV.Text = "Tên dịch vụ:";
            // txtTenDV
            this.txtTenDV.Location = new System.Drawing.Point(100, 47);
            this.txtTenDV.Name = "txtTenDV";
            this.txtTenDV.Size = new System.Drawing.Size(300, 20);
            // lBUSoaiDV
            this.lBUSoaiDV.AutoSize = true;
            this.lBUSoaiDV.Location = new System.Drawing.Point(20, 80);
            this.lBUSoaiDV.Name = "lBUSoaiDV";
            this.lBUSoaiDV.Size = new System.Drawing.Size(70, 13);
            this.lBUSoaiDV.Text = "Loại dịch vụ:";
            // cbLoaiDV
            this.cbLoaiDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiDV.FormattingEnabled = true;
            this.cbLoaiDV.Location = new System.Drawing.Point(100, 77);
            this.cbLoaiDV.Name = "cbLoaiDV";
            this.cbLoaiDV.Size = new System.Drawing.Size(200, 21);
            // lblMoTa
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(20, 110);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(38, 13);
            this.lblMoTa.Text = "Mô tả:";
            // txtMoTa
            this.txtMoTa.Location = new System.Drawing.Point(100, 107);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(300, 60);
            // lblGia
            this.lblGia.AutoSize = true;
            this.lblGia.Location = new System.Drawing.Point(20, 180);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(26, 13);
            this.lblGia.Text = "Giá:";
            // txtGia
            this.txtGia.Location = new System.Drawing.Point(100, 177);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(150, 20);
            // cbChoPhepDoiDiem
            this.cbChoPhepDoiDiem.AutoSize = true;
            this.cbChoPhepDoiDiem.Location = new System.Drawing.Point(20, 210);
            this.cbChoPhepDoiDiem.Name = "cbChoPhepDoiDiem";
            this.cbChoPhepDoiDiem.Size = new System.Drawing.Size(120, 17);
            this.cbChoPhepDoiDiem.Text = "Cho phép đổi điểm";
            this.cbChoPhepDoiDiem.UseVisualStyleBackColor = true;
            // lblGiaTriDoiDiem
            this.lblGiaTriDoiDiem.AutoSize = true;
            this.lblGiaTriDoiDiem.Location = new System.Drawing.Point(20, 240);
            this.lblGiaTriDoiDiem.Name = "lblGiaTriDoiDiem";
            this.lblGiaTriDoiDiem.Size = new System.Drawing.Size(85, 13);
            this.lblGiaTriDoiDiem.Text = "Giá trị đổi điểm:";
            // txtGiaTriDoiDiem
            this.txtGiaTriDoiDiem.Enabled = false;
            this.txtGiaTriDoiDiem.Location = new System.Drawing.Point(110, 237);
            this.txtGiaTriDoiDiem.Name = "txtGiaTriDoiDiem";
            this.txtGiaTriDoiDiem.Size = new System.Drawing.Size(100, 20);
            // cbIsActive
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.Location = new System.Drawing.Point(20, 270);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(73, 17);
            this.cbIsActive.Text = "Hoạt động";
            this.cbIsActive.UseVisualStyleBackColor = true;
            // btnThem
            this.btnThem.Location = new System.Drawing.Point(20, 310);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // btnSua
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(110, 310);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // btnXoa
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(200, 310);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // btnReset
            this.btnReset.Location = new System.Drawing.Point(290, 310);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            // lvServices
            this.lvServices.FullRowSelect = true;
            this.lvServices.GridLines = true;
            this.lvServices.HideSelection = false;
            this.lvServices.Location = new System.Drawing.Point(420, 20);
            this.lvServices.Name = "lvServices";
            this.lvServices.Size = new System.Drawing.Size(600, 400);
            this.lvServices.TabIndex = 0;
            this.lvServices.UseCompatibleStateImageBehavior = false;
            this.lvServices.View = System.Windows.Forms.View.Details;
            this.lvServices.Columns.Add("Mã DV", 80);
            this.lvServices.Columns.Add("Tên DV", 150);
            this.lvServices.Columns.Add("Loại", 100);
            this.lvServices.Columns.Add("Giá", 100);
            this.lvServices.Columns.Add("Đổi điểm", 80);
            this.lvServices.Columns.Add("Giá trị điểm", 80);
            this.lvServices.Columns.Add("Trạng thái", 80);
            // errorProvider1
            this.errorProvider1.ContainerControl = this;
            // frmService
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 450);
            this.Controls.Add(this.lvServices);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtGiaTriDoiDiem);
            this.Controls.Add(this.lblGiaTriDoiDiem);
            this.Controls.Add(this.cbChoPhepDoiDiem);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.cbLoaiDV);
            this.Controls.Add(this.lBUSoaiDV);
            this.Controls.Add(this.txtTenDV);
            this.Controls.Add(this.lblTenDV);
            this.Controls.Add(this.txtMaDV);
            this.Controls.Add(this.lblMaDV);
            this.Name = "frmService";
            this.Text = "Quản lý Dịch vụ";
            this.Load += new System.EventHandler(this.frmService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}







