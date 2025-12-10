namespace QLResort.GUI
{
    partial class frmPaymentType
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaLTT;
        private System.Windows.Forms.TextBox txtMaLTT;
        private System.Windows.Forms.Label lblTenLTT;
        private System.Windows.Forms.TextBox txtTenLTT;
        private System.Windows.Forms.CheckBox cbIsActive;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ListView lvPaymentTypes;
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
            this.lblMaLTT = new System.Windows.Forms.Label();
            this.txtMaLTT = new System.Windows.Forms.TextBox();
            this.lblTenLTT = new System.Windows.Forms.Label();
            this.txtTenLTT = new System.Windows.Forms.TextBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lvPaymentTypes = new System.Windows.Forms.ListView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaLTT
            // 
            this.lblMaLTT.AutoSize = true;
            this.lblMaLTT.Location = new System.Drawing.Point(27, 25);
            this.lblMaLTT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaLTT.Name = "lblMaLTT";
            this.lblMaLTT.Size = new System.Drawing.Size(75, 16);
            this.lblMaLTT.TabIndex = 9;
            this.lblMaLTT.Text = "Mã loại TT:";
            // 
            // txtMaLTT
            // 
            this.txtMaLTT.Enabled = false;
            this.txtMaLTT.Location = new System.Drawing.Point(147, 21);
            this.txtMaLTT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaLTT.Name = "txtMaLTT";
            this.txtMaLTT.Size = new System.Drawing.Size(199, 22);
            this.txtMaLTT.TabIndex = 8;
            // 
            // lblTenLTT
            // 
            this.lblTenLTT.AutoSize = true;
            this.lblTenLTT.Location = new System.Drawing.Point(27, 62);
            this.lblTenLTT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenLTT.Name = "lblTenLTT";
            this.lblTenLTT.Size = new System.Drawing.Size(80, 16);
            this.lblTenLTT.TabIndex = 7;
            this.lblTenLTT.Text = "Tên loại TT:";
            // 
            // txtTenLTT
            // 
            this.txtTenLTT.Location = new System.Drawing.Point(147, 58);
            this.txtTenLTT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenLTT.Name = "txtTenLTT";
            this.txtTenLTT.Size = new System.Drawing.Size(332, 22);
            this.txtTenLTT.TabIndex = 6;
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.Location = new System.Drawing.Point(27, 98);
            this.cbIsActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(92, 20);
            this.cbIsActive.TabIndex = 5;
            this.cbIsActive.Text = "Hoạt động";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(27, 135);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 37);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(147, 135);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 37);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(267, 135);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 37);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(387, 135);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 37);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Làm mới";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // lvPaymentTypes
            // 
            this.lvPaymentTypes.FullRowSelect = true;
            this.lvPaymentTypes.GridLines = true;
            this.lvPaymentTypes.HideSelection = false;
            this.lvPaymentTypes.Location = new System.Drawing.Point(560, 25);
            this.lvPaymentTypes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvPaymentTypes.Name = "lvPaymentTypes";
            this.lvPaymentTypes.Size = new System.Drawing.Size(665, 491);
            this.lvPaymentTypes.TabIndex = 0;
            this.lvPaymentTypes.UseCompatibleStateImageBehavior = false;
            this.lvPaymentTypes.View = System.Windows.Forms.View.Details;
            this.lvPaymentTypes.SelectedIndexChanged += new System.EventHandler(this.lvPaymentTypes_SelectedIndexChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmPaymentType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 554);
            this.Controls.Add(this.lvPaymentTypes);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtTenLTT);
            this.Controls.Add(this.lblTenLTT);
            this.Controls.Add(this.txtMaLTT);
            this.Controls.Add(this.lblMaLTT);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmPaymentType";
            this.Text = "Quản lý Loại Thanh Toán";
            this.Load += new System.EventHandler(this.frmPaymentType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}


