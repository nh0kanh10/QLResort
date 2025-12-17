namespace GUI_QLResort
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
        private System.Windows.Forms.ColumnHeader colMaLTT;
        private System.Windows.Forms.ColumnHeader colTenLTT;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.ListView lvPaymentTypes;
        private System.Windows.Forms.ErrorProvider errorProvider1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvPaymentTypes = new System.Windows.Forms.ListView();
            this.colMaLTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTenLTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblMaLTT = new System.Windows.Forms.Label();
            this.txtMaLTT = new System.Windows.Forms.TextBox();
            this.lblTenLTT = new System.Windows.Forms.Label();
            this.txtTenLTT = new System.Windows.Forms.TextBox();
            this.cbIsActive = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvPaymentTypes
            // 
            this.lvPaymentTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaLTT,
            this.colTenLTT,
            this.colIsActive});
            this.lvPaymentTypes.FullRowSelect = true;
            this.lvPaymentTypes.GridLines = true;
            this.lvPaymentTypes.HideSelection = false;
            this.lvPaymentTypes.Location = new System.Drawing.Point(560, 25);
            this.lvPaymentTypes.Margin = new System.Windows.Forms.Padding(4);
            this.lvPaymentTypes.Name = "lvPaymentTypes";
            this.lvPaymentTypes.Size = new System.Drawing.Size(665, 491);
            this.lvPaymentTypes.TabIndex = 0;
            this.lvPaymentTypes.UseCompatibleStateImageBehavior = false;
            this.lvPaymentTypes.View = System.Windows.Forms.View.Details;
            this.lvPaymentTypes.SelectedIndexChanged += new System.EventHandler(this.lvPaymentTypes_SelectedIndexChanged);
            // 
            // colMaLTT
            // 
            this.colMaLTT.Text = "Mã LTT";
            this.colMaLTT.Width = 100;
            // 
            // colTenLTT
            // 
            this.colTenLTT.Text = "Tên Loại Thanh Toán";
            this.colTenLTT.Width = 200;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "Trạng Thái";
            this.colIsActive.Width = 100;
            // 
            // lblMaLTT
            // 
            this.lblMaLTT.AutoSize = true;
            this.lblMaLTT.Location = new System.Drawing.Point(20, 23);
            this.lblMaLTT.Name = "lblMaLTT";
            this.lblMaLTT.Size = new System.Drawing.Size(48, 13);
            this.lblMaLTT.TabIndex = 8;
            this.lblMaLTT.Text = "Mã LTT:";
            // 
            // txtMaLTT
            // 
            this.txtMaLTT.Enabled = false;
            this.txtMaLTT.Location = new System.Drawing.Point(120, 20);
            this.txtMaLTT.Name = "txtMaLTT";
            this.txtMaLTT.Size = new System.Drawing.Size(200, 20);
            this.txtMaLTT.TabIndex = 7;
            // 
            // lblTenLTT
            // 
            this.lblTenLTT.AutoSize = true;
            this.lblTenLTT.Location = new System.Drawing.Point(20, 53);
            this.lblTenLTT.Name = "lblTenLTT";
            this.lblTenLTT.Size = new System.Drawing.Size(52, 13);
            this.lblTenLTT.TabIndex = 6;
            this.lblTenLTT.Text = "Tên LTT:";
            // 
            // txtTenLTT
            // 
            this.txtTenLTT.Location = new System.Drawing.Point(120, 50);
            this.txtTenLTT.Name = "txtTenLTT";
            this.txtTenLTT.Size = new System.Drawing.Size(200, 20);
            this.txtTenLTT.TabIndex = 5;
            // 
            // cbIsActive
            // 
            this.cbIsActive.AutoSize = true;
            this.cbIsActive.Checked = true;
            this.cbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsActive.Location = new System.Drawing.Point(120, 80);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(104, 24);
            this.cbIsActive.TabIndex = 4;
            this.cbIsActive.Text = "Hoạt động";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(20, 120);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 30);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(110, 120);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(200, 120);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 30);
            this.btnXoa.TabIndex = 1;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(290, 120);
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
            // frmPaymentType
            // 
            this.ClientSize = new System.Drawing.Size(1297, 536);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.txtTenLTT);
            this.Controls.Add(this.lblTenLTT);
            this.Controls.Add(this.txtMaLTT);
            this.Controls.Add(this.lblMaLTT);
            this.Controls.Add(this.lvPaymentTypes);
            this.Name = "frmPaymentType";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}


