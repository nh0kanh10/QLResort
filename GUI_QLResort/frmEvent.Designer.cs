using System.ComponentModel;
using System.Windows.Forms;

namespace GUI_QLResort
{
    partial class frmEvent
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaSK;
        private System.Windows.Forms.TextBox txtMaSK;
        private System.Windows.Forms.Label lblTenSK;
        private System.Windows.Forms.TextBox txtTenSK;
        private System.Windows.Forms.Label lBUSoaiSuKien;
        private System.Windows.Forms.ComboBox cbLoaiSuKien;
        private System.Windows.Forms.Label lblMaCN;
        private System.Windows.Forms.ComboBox cbMaCN;
        private System.Windows.Forms.Label lblDiaDiem;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblTongChiPhi;
        private System.Windows.Forms.TextBox txtTongChiPhi;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView lvEvents;
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
            this.lblMaSK = new System.Windows.Forms.Label();
            this.txtMaSK = new System.Windows.Forms.TextBox();
            this.lblTenSK = new System.Windows.Forms.Label();
            this.txtTenSK = new System.Windows.Forms.TextBox();
            this.lBUSoaiSuKien = new System.Windows.Forms.Label();
            this.cbLoaiSuKien = new System.Windows.Forms.ComboBox();
            this.lblMaCN = new System.Windows.Forms.Label();
            this.cbMaCN = new System.Windows.Forms.ComboBox();
            this.lblDiaDiem = new System.Windows.Forms.Label();
            this.txtDiaDiem = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblTongChiPhi = new System.Windows.Forms.Label();
            this.txtTongChiPhi = new System.Windows.Forms.TextBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lvEvents = new System.Windows.Forms.ListView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // lblMaSK
            this.lblMaSK.AutoSize = true;
            this.lblMaSK.Location = new System.Drawing.Point(20, 20);
            this.lblMaSK.Name = "lblMaSK";
            this.lblMaSK.Size = new System.Drawing.Size(70, 13);
            this.lblMaSK.Text = "Mã sự kiện:";
            // txtMaSK
            this.txtMaSK.Enabled = false;
            this.txtMaSK.Location = new System.Drawing.Point(100, 17);
            this.txtMaSK.Name = "txtMaSK";
            this.txtMaSK.Size = new System.Drawing.Size(150, 20);

            // lblTenSK
            this.lblTenSK.AutoSize = true;
            this.lblTenSK.Location = new System.Drawing.Point(20, 50);
            this.lblTenSK.Name = "lblTenSK";
            this.lblTenSK.Size = new System.Drawing.Size(70, 13);
            this.lblTenSK.Text = "Tên sự kiện:";
            // txtTenSK
            this.txtTenSK.Location = new System.Drawing.Point(100, 47);
            this.txtTenSK.Name = "txtTenSK";
            this.txtTenSK.Size = new System.Drawing.Size(300, 20);
            // lBUSoaiSuKien
            this.lBUSoaiSuKien.AutoSize = true;
            this.lBUSoaiSuKien.Location = new System.Drawing.Point(20, 80);
            this.lBUSoaiSuKien.Name = "lBUSoaiSuKien";
            this.lBUSoaiSuKien.Size = new System.Drawing.Size(80, 13);
            this.lBUSoaiSuKien.Text = "Loại sự kiện:";
            // cbLoaiSuKien
            this.cbLoaiSuKien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiSuKien.FormattingEnabled = true;
            this.cbLoaiSuKien.Location = new System.Drawing.Point(100, 77);
            this.cbLoaiSuKien.Name = "cbLoaiSuKien";
            this.cbLoaiSuKien.Size = new System.Drawing.Size(200, 21);
            // lblMaCN
            this.lblMaCN.AutoSize = true;
            this.lblMaCN.Location = new System.Drawing.Point(20, 110);
            this.lblMaCN.Name = "lblMaCN";
            this.lblMaCN.Size = new System.Drawing.Size(60, 13);
            this.lblMaCN.Text = "Chi nhánh:";
            // cbMaCN
            this.cbMaCN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaCN.FormattingEnabled = true;
            this.cbMaCN.Location = new System.Drawing.Point(100, 107);
            this.cbMaCN.Name = "cbMaCN";
            this.cbMaCN.Size = new System.Drawing.Size(200, 21);
            // lblDiaDiem
            this.lblDiaDiem.AutoSize = true;
            this.lblDiaDiem.Location = new System.Drawing.Point(20, 140);
            this.lblDiaDiem.Name = "lblDiaDiem";
            this.lblDiaDiem.Size = new System.Drawing.Size(50, 13);
            this.lblDiaDiem.Text = "Địa điểm:";
            // txtDiaDiem
            this.txtDiaDiem.Location = new System.Drawing.Point(100, 137);
            this.txtDiaDiem.Name = "txtDiaDiem";
            this.txtDiaDiem.Size = new System.Drawing.Size(300, 20);
            // lblGhiChu
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(20, 170);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(50, 13);
            this.lblGhiChu.Text = "Ghi chú:";
            // txtGhiChu
            this.txtGhiChu.Location = new System.Drawing.Point(100, 167);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(300, 60);
            // lblTongChiPhi
            this.lblTongChiPhi.AutoSize = true;
            this.lblTongChiPhi.Location = new System.Drawing.Point(20, 240);
            this.lblTongChiPhi.Name = "lblTongChiPhi";
            this.lblTongChiPhi.Size = new System.Drawing.Size(70, 13);
            this.lblTongChiPhi.Text = "Tổng chi phí:";
            // txtTongChiPhi
            this.txtTongChiPhi.Location = new System.Drawing.Point(100, 237);
            this.txtTongChiPhi.Name = "txtTongChiPhi";
            this.txtTongChiPhi.Size = new System.Drawing.Size(150, 20);
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
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // btnSua
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(110, 310);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // btnReset
            this.btnReset.Location = new System.Drawing.Point(200, 310);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            
            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(290, 310);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.lvEvents.FullRowSelect = true;
            this.lvEvents.GridLines = true;
            this.lvEvents.Location = new System.Drawing.Point(420, 20);
            this.lvEvents.Size = new System.Drawing.Size(700, 400);
            this.lvEvents.View = System.Windows.Forms.View.Details;
            this.lvEvents.Columns.Add("Mã SK", 80);
            this.lvEvents.Columns.Add("Tên SK", 200);
            this.lvEvents.Columns.Add("Loại", 120);
            this.lvEvents.Columns.Add("Địa điểm", 150);
            this.lvEvents.Columns.Add("Tổng chi phí", 120);
            this.lvEvents.Columns.Add("Trạng thái", 80);
            this.lvEvents.SelectedIndexChanged += new System.EventHandler(this.lvEvents_SelectedIndexChanged);

            this.errorProvider1.ContainerControl = this;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 450);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lvEvents, this.btnReset, this.btnSua, this.btnThem,
                this.cbIsActive, this.txtTongChiPhi, this.lblTongChiPhi,
                this.txtGhiChu, this.lblGhiChu, this.txtDiaDiem, this.lblDiaDiem,
                this.cbMaCN, this.lblMaCN, this.cbLoaiSuKien, this.lBUSoaiSuKien,
                this.txtTenSK, this.lblTenSK, this.txtMaSK, this.lblMaSK
            });
            this.Name = "frmEvent";
            this.Text = "Quản lý Sự kiện";
            this.Load += new System.EventHandler(this.frmEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

