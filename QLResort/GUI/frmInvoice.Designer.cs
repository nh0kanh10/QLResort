namespace QLResort.GUI
{
    partial class frmInvoice
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblMaHD, lblMaDP, lblMaKH, lblTenKH, lblMaKM, lblTongTruocKM, lblTongTien, lblTrangThai;
        private System.Windows.Forms.TextBox txtMaHD, txtMaDP, txtMaKH, txtTenKH, txtMaKM, txtTongTruocKM, txtTongTien;
        private System.Windows.Forms.ComboBox cbTrangThai;
        private System.Windows.Forms.Button btnSua, btnReset;
        private System.Windows.Forms.ListView lvInvoices, lvDetails;

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
            this.lblMaHD = new System.Windows.Forms.Label();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblMaDP = new System.Windows.Forms.Label();
            this.txtMaDP = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblMaKM = new System.Windows.Forms.Label();
            this.txtMaKM = new System.Windows.Forms.TextBox();
            this.lblTongTruocKM = new System.Windows.Forms.Label();
            this.txtTongTruocKM = new System.Windows.Forms.TextBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cbTrangThai = new System.Windows.Forms.ComboBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lvInvoices = new System.Windows.Forms.ListView();
            this.lvDetails = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(20, 20);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(44, 13);
            this.lblMaHD.TabIndex = 19;
            this.lblMaHD.Text = "Mã HĐ:";
            // 
            // txtMaHD
            // 
            this.txtMaHD.Enabled = false;
            this.txtMaHD.Location = new System.Drawing.Point(100, 17);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(250, 20);
            this.txtMaHD.TabIndex = 18;
            // 
            // lblMaDP
            // 
            this.lblMaDP.AutoSize = true;
            this.lblMaDP.Location = new System.Drawing.Point(20, 50);
            this.lblMaDP.Name = "lblMaDP";
            this.lblMaDP.Size = new System.Drawing.Size(43, 13);
            this.lblMaDP.TabIndex = 17;
            this.lblMaDP.Text = "Mã ĐP:";
            // 
            // txtMaDP
            // 
            this.txtMaDP.Enabled = false;
            this.txtMaDP.Location = new System.Drawing.Point(100, 47);
            this.txtMaDP.Name = "txtMaDP";
            this.txtMaDP.Size = new System.Drawing.Size(250, 20);
            this.txtMaDP.TabIndex = 16;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(20, 80);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(43, 13);
            this.lblMaKH.TabIndex = 15;
            this.lblMaKH.Text = "Mã KH:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Enabled = false;
            this.txtMaKH.Location = new System.Drawing.Point(100, 77);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(250, 20);
            this.txtMaKH.TabIndex = 14;
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(20, 110);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(47, 13);
            this.lblTenKH.TabIndex = 13;
            this.lblTenKH.Text = "Tên KH:";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Enabled = false;
            this.txtTenKH.Location = new System.Drawing.Point(100, 107);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(250, 20);
            this.txtTenKH.TabIndex = 12;
            // 
            // lblMaKM
            // 
            this.lblMaKM.AutoSize = true;
            this.lblMaKM.Location = new System.Drawing.Point(20, 140);
            this.lblMaKM.Name = "lblMaKM";
            this.lblMaKM.Size = new System.Drawing.Size(44, 13);
            this.lblMaKM.TabIndex = 11;
            this.lblMaKM.Text = "Mã KM:";
            // 
            // txtMaKM
            // 
            this.txtMaKM.Enabled = false;
            this.txtMaKM.Location = new System.Drawing.Point(100, 137);
            this.txtMaKM.Name = "txtMaKM";
            this.txtMaKM.Size = new System.Drawing.Size(250, 20);
            this.txtMaKM.TabIndex = 10;
            // 
            // lblTongTruocKM
            // 
            this.lblTongTruocKM.AutoSize = true;
            this.lblTongTruocKM.Location = new System.Drawing.Point(20, 170);
            this.lblTongTruocKM.Name = "lblTongTruocKM";
            this.lblTongTruocKM.Size = new System.Drawing.Size(81, 13);
            this.lblTongTruocKM.TabIndex = 9;
            this.lblTongTruocKM.Text = "Tổng trước KM:";
            // 
            // txtTongTruocKM
            // 
            this.txtTongTruocKM.Enabled = false;
            this.txtTongTruocKM.Location = new System.Drawing.Point(100, 167);
            this.txtTongTruocKM.Name = "txtTongTruocKM";
            this.txtTongTruocKM.Size = new System.Drawing.Size(250, 20);
            this.txtTongTruocKM.TabIndex = 8;
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(20, 200);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(55, 13);
            this.lblTongTien.TabIndex = 7;
            this.lblTongTien.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(100, 197);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(250, 20);
            this.txtTongTien.TabIndex = 6;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(20, 230);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(58, 13);
            this.lblTrangThai.TabIndex = 5;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cbTrangThai
            // 
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.Location = new System.Drawing.Point(100, 227);
            this.cbTrangThai.Name = "cbTrangThai";
            this.cbTrangThai.Size = new System.Drawing.Size(250, 21);
            this.cbTrangThai.TabIndex = 4;
            this.cbTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbTrangThai_SelectedIndexChanged);
            // 
            // btnSua
            // 
            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(20, 270);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.TabIndex = 3;
            this.btnSua.Text = "Cập nhật";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(110, 270);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Làm mới";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lvInvoices
            // 
            this.lvInvoices.FullRowSelect = true;
            this.lvInvoices.GridLines = true;
            this.lvInvoices.HideSelection = false;
            this.lvInvoices.Location = new System.Drawing.Point(420, 20);
            this.lvInvoices.Name = "lvInvoices";
            this.lvInvoices.Size = new System.Drawing.Size(700, 300);
            this.lvInvoices.TabIndex = 1;
            this.lvInvoices.UseCompatibleStateImageBehavior = false;
            this.lvInvoices.View = System.Windows.Forms.View.Details;
            this.lvInvoices.SelectedIndexChanged += new System.EventHandler(this.lvInvoices_SelectedIndexChanged);
            // 
            // lvDetails
            // 
            this.lvDetails.FullRowSelect = true;
            this.lvDetails.GridLines = true;
            this.lvDetails.HideSelection = false;
            this.lvDetails.Location = new System.Drawing.Point(420, 330);
            this.lvDetails.Name = "lvDetails";
            this.lvDetails.Size = new System.Drawing.Size(700, 240);
            this.lvDetails.TabIndex = 0;
            this.lvDetails.UseCompatibleStateImageBehavior = false;
            this.lvDetails.View = System.Windows.Forms.View.Details;
            // 
            // frmInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 590);
            this.Controls.Add(this.lvDetails);
            this.Controls.Add(this.lvInvoices);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.cbTrangThai);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.txtTongTruocKM);
            this.Controls.Add(this.lblTongTruocKM);
            this.Controls.Add(this.txtMaKM);
            this.Controls.Add(this.lblMaKM);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.lblTenKH);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.txtMaDP);
            this.Controls.Add(this.lblMaDP);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.lblMaHD);
            this.Name = "frmInvoice";
            this.Text = "Quản lý Hóa đơn";
            this.Load += new System.EventHandler(this.frmInvoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}


