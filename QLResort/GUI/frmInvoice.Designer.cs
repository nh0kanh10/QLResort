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
            this.components = new System.ComponentModel.Container();
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

            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(20, 20);
            this.lblMaHD.Text = "Mã HĐ:";
            this.txtMaHD.Enabled = false;
            this.txtMaHD.Location = new System.Drawing.Point(100, 17);
            this.txtMaHD.Size = new System.Drawing.Size(150, 20);

            this.lblMaDP.AutoSize = true;
            this.lblMaDP.Location = new System.Drawing.Point(20, 50);
            this.lblMaDP.Text = "Mã ĐP:";
            this.txtMaDP.Enabled = false;
            this.txtMaDP.Location = new System.Drawing.Point(100, 47);
            this.txtMaDP.Size = new System.Drawing.Size(150, 20);

            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(20, 80);
            this.lblMaKH.Text = "Mã KH:";
            this.txtMaKH.Enabled = false;
            this.txtMaKH.Location = new System.Drawing.Point(100, 77);
            this.txtMaKH.Size = new System.Drawing.Size(150, 20);

            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Location = new System.Drawing.Point(20, 110);
            this.lblTenKH.Text = "Tên KH:";
            this.txtTenKH.Enabled = false;
            this.txtTenKH.Location = new System.Drawing.Point(100, 107);
            this.txtTenKH.Size = new System.Drawing.Size(250, 20);

            this.lblMaKM.AutoSize = true;
            this.lblMaKM.Location = new System.Drawing.Point(20, 140);
            this.lblMaKM.Text = "Mã KM:";
            this.txtMaKM.Enabled = false;
            this.txtMaKM.Location = new System.Drawing.Point(100, 137);
            this.txtMaKM.Size = new System.Drawing.Size(150, 20);

            this.lblTongTruocKM.AutoSize = true;
            this.lblTongTruocKM.Location = new System.Drawing.Point(20, 170);
            this.lblTongTruocKM.Text = "Tổng trước KM:";
            this.txtTongTruocKM.Enabled = false;
            this.txtTongTruocKM.Location = new System.Drawing.Point(100, 167);
            this.txtTongTruocKM.Size = new System.Drawing.Size(150, 20);

            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Location = new System.Drawing.Point(20, 200);
            this.lblTongTien.Text = "Tổng tiền:";
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(100, 197);
            this.txtTongTien.Size = new System.Drawing.Size(150, 20);

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(20, 230);
            this.lblTrangThai.Text = "Trạng thái:";
            this.cbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrangThai.Location = new System.Drawing.Point(100, 227);
            this.cbTrangThai.Size = new System.Drawing.Size(150, 21);
            this.cbTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbTrangThai_SelectedIndexChanged);

            this.btnSua.Enabled = false;
            this.btnSua.Location = new System.Drawing.Point(20, 270);
            this.btnSua.Size = new System.Drawing.Size(75, 30);
            this.btnSua.Text = "Cập nhật";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnReset.Location = new System.Drawing.Point(110, 270);
            this.btnReset.Size = new System.Drawing.Size(75, 30);
            this.btnReset.Text = "Làm mới";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);

            this.lvInvoices.FullRowSelect = true;
            this.lvInvoices.GridLines = true;
            this.lvInvoices.Location = new System.Drawing.Point(420, 20);
            this.lvInvoices.Size = new System.Drawing.Size(700, 300);
            this.lvInvoices.View = System.Windows.Forms.View.Details;
            this.lvInvoices.Columns.Add("Mã HĐ", 80);
            this.lvInvoices.Columns.Add("Mã ĐP", 80);
            this.lvInvoices.Columns.Add("Mã KH", 80);
            this.lvInvoices.Columns.Add("Ngày lập", 120);
            this.lvInvoices.Columns.Add("Tổng trước KM", 120);
            this.lvInvoices.Columns.Add("Tổng tiền", 120);
            this.lvInvoices.Columns.Add("Trạng thái", 100);
            this.lvInvoices.Columns.Add("Mã KM", 80);
            this.lvInvoices.SelectedIndexChanged += new System.EventHandler(this.lvInvoices_SelectedIndexChanged);

            this.lvDetails.FullRowSelect = true;
            this.lvDetails.GridLines = true;
            this.lvDetails.Location = new System.Drawing.Point(420, 330);
            this.lvDetails.Size = new System.Drawing.Size(700, 240);
            this.lvDetails.View = System.Windows.Forms.View.Details;
            this.lvDetails.Columns.Add("Mã CT", 100);
            this.lvDetails.Columns.Add("Mô tả", 200);
            this.lvDetails.Columns.Add("Số lượng", 80);
            this.lvDetails.Columns.Add("Đơn giá", 100);
            this.lvDetails.Columns.Add("Thành tiền", 120);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 590);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lvDetails, this.lvInvoices, this.btnReset, this.btnSua, this.cbTrangThai, this.lblTrangThai,
                this.txtTongTien, this.lblTongTien, this.txtTongTruocKM, this.lblTongTruocKM,
                this.txtMaKM, this.lblMaKM, this.txtTenKH, this.lblTenKH, this.txtMaKH, this.lblMaKH,
                this.txtMaDP, this.lblMaDP, this.txtMaHD, this.lblMaHD
            });
            this.Name = "frmInvoice";
            this.Text = "Quản lý Hóa đơn";
            this.Load += new System.EventHandler(this.frmInvoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}


