namespace GUI_QLResort
{
    partial class loaiKH_gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDSLKH = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.ckbActive = new System.Windows.Forms.CheckBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPercent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvTTLKH = new System.Windows.Forms.DataGridView();
            this.txtNhap = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtMaLKH = new System.Windows.Forms.TextBox();
            this.txtTenLoaiKH = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTLKH)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTenLoaiKH);
            this.groupBox1.Controls.Add(this.txtMaLKH);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnDSLKH);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.ckbActive);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDiem);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPercent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 278);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin Loại Khách hàng";
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(666, 160);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 34);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Tag = "";
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(666, 101);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 34);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDSLKH
            // 
            this.btnDSLKH.Location = new System.Drawing.Point(666, 42);
            this.btnDSLKH.Name = "btnDSLKH";
            this.btnDSLKH.Size = new System.Drawing.Size(90, 34);
            this.btnDSLKH.TabIndex = 7;
            this.btnDSLKH.Text = "DS LKH";
            this.btnDSLKH.UseVisualStyleBackColor = true;
            this.btnDSLKH.Click += new System.EventHandler(this.btnDSLKH_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(523, 160);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 34);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(523, 101);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 34);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(523, 42);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 34);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // ckbActive
            // 
            this.ckbActive.AutoSize = true;
            this.ckbActive.Location = new System.Drawing.Point(523, 218);
            this.ckbActive.Name = "ckbActive";
            this.ckbActive.Size = new System.Drawing.Size(87, 23);
            this.ckbActive.TabIndex = 3;
            this.ckbActive.Text = "IsActive";
            this.ckbActive.UseVisualStyleBackColor = true;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(197, 174);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(284, 93);
            this.txtMoTa.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mô tả";
            // 
            // txtDiem
            // 
            this.txtDiem.Location = new System.Drawing.Point(197, 141);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(284, 27);
            this.txtDiem.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Điểm tối thiểu";
            // 
            // txtPercent
            // 
            this.txtPercent.Location = new System.Drawing.Point(197, 108);
            this.txtPercent.Name = "txtPercent";
            this.txtPercent.Size = new System.Drawing.Size(284, 27);
            this.txtPercent.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Giảm giá Percent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên Loại KH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Loại KH";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTim);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtNhap);
            this.groupBox2.Controls.Add(this.dgvTTLKH);
            this.groupBox2.Location = new System.Drawing.Point(13, 298);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(875, 225);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin Danh sách Loại Nhân viên";
            // 
            // dgvTTLKH
            // 
            this.dgvTTLKH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTTLKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTTLKH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTTLKH.Location = new System.Drawing.Point(3, 61);
            this.dgvTTLKH.Name = "dgvTTLKH";
            this.dgvTTLKH.RowHeadersWidth = 51;
            this.dgvTTLKH.RowTemplate.Height = 24;
            this.dgvTTLKH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTTLKH.Size = new System.Drawing.Size(869, 161);
            this.dgvTTLKH.TabIndex = 0;
            this.dgvTTLKH.Click += new System.EventHandler(this.dgvTTLKH_Click);
            // 
            // txtNhap
            // 
            this.txtNhap.Location = new System.Drawing.Point(302, 26);
            this.txtNhap.Name = "txtNhap";
            this.txtNhap.Size = new System.Drawing.Size(284, 27);
            this.txtNhap.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "Nhập TT cần tìm";
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(592, 21);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(90, 34);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "Tìm kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtMaLKH
            // 
            this.txtMaLKH.Location = new System.Drawing.Point(197, 42);
            this.txtMaLKH.Name = "txtMaLKH";
            this.txtMaLKH.Size = new System.Drawing.Size(284, 27);
            this.txtMaLKH.TabIndex = 10;
            // 
            // txtTenLoaiKH
            // 
            this.txtTenLoaiKH.Location = new System.Drawing.Point(197, 75);
            this.txtTenLoaiKH.Name = "txtTenLoaiKH";
            this.txtTenLoaiKH.Size = new System.Drawing.Size(284, 27);
            this.txtTenLoaiKH.TabIndex = 11;
            // 
            // loaiKH_gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(900, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "loaiKH_gui";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "loaiKH_gui";
            this.Load += new System.EventHandler(this.loaiKH_gui_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTTLKH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDSLKH;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.CheckBox ckbActive;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNhap;
        private System.Windows.Forms.DataGridView dgvTTLKH;
        private System.Windows.Forms.TextBox txtMaLKH;
        private System.Windows.Forms.TextBox txtTenLoaiKH;
    }
}
