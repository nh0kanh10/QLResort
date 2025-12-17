// File: QLResort-master/QLResort/GUI/frmServiceSelection.Designer.cs

namespace GUI_QLResort
{
    partial class frmServiceSelection
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblRoomInfo;
        private System.Windows.Forms.DataGridView dgvAvailableServices;
        private System.Windows.Forms.DataGridView dgvSelectedServices;
        private System.Windows.Forms.Label lblAvailableServices;
        private System.Windows.Forms.Label lblSelectedServices;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtSearchService;
        private System.Windows.Forms.Label lblSearchService;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDVAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDVAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChoPhepDoiDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTriDoiDiem;
        private System.Windows.Forms.DataGridViewButtonColumn colAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDVSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDVSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTienSelected;
        private System.Windows.Forms.DataGridViewButtonColumn colRemove;


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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchService = new System.Windows.Forms.TextBox();
            this.lblSearchService = new System.Windows.Forms.Label();
            this.lblRoomInfo = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvAvailableServices = new System.Windows.Forms.DataGridView();
            this.colMaDVAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDVAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChoPhepDoiDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaTriDoiDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAdd = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblAvailableServices = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.dgvSelectedServices = new System.Windows.Forms.DataGridView();
            this.colMaDVSelected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDVSelected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongSelected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaSelected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTienSelected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblSelectedServices = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableServices)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedServices)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Controls.Add(this.txtSearchService);
            this.panelTop.Controls.Add(this.lblSearchService);
            this.panelTop.Controls.Add(this.lblRoomInfo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1174, 65);
            this.panelTop.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btnSearch.Location = new System.Drawing.Point(352, 37);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchService
            // 
            this.txtSearchService.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.txtSearchService.Location = new System.Drawing.Point(112, 38);
            this.txtSearchService.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchService.Name = "txtSearchService";
            this.txtSearchService.Size = new System.Drawing.Size(226, 22);
            this.txtSearchService.TabIndex = 2;
            // 
            // lblSearchService
            // 
            this.lblSearchService.AutoSize = true;
            this.lblSearchService.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearchService.ForeColor = System.Drawing.Color.White;
            this.lblSearchService.Location = new System.Drawing.Point(15, 41);
            this.lblSearchService.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearchService.Name = "lblSearchService";
            this.lblSearchService.Size = new System.Drawing.Size(92, 14);
            this.lblSearchService.TabIndex = 1;
            this.lblSearchService.Text = "🔍 Tìm dịch vụ:";
            // 
            // lblRoomInfo
            // 
            this.lblRoomInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRoomInfo.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblRoomInfo.Location = new System.Drawing.Point(0, 0);
            this.lblRoomInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomInfo.Name = "lblRoomInfo";
            this.lblRoomInfo.Size = new System.Drawing.Size(1174, 32);
            this.lblRoomInfo.TabIndex = 0;
            this.lblRoomInfo.Text = "💎 CHỌN DỊCH VỤ";
            this.lblRoomInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.dgvAvailableServices);
            this.panelLeft.Controls.Add(this.lblAvailableServices);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 65);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(648, 651);
            this.panelLeft.TabIndex = 1;
            // 
            // dgvAvailableServices
            // 
            this.dgvAvailableServices.AllowUserToAddRows = false;
            this.dgvAvailableServices.AllowUserToDeleteRows = false;
            this.dgvAvailableServices.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAvailableServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAvailableServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaDVAvailable,
            this.colTenDVAvailable,
            this.colGiaAvailable,
            this.colChoPhepDoiDiem,
            this.colGiaTriDoiDiem,
            this.colAdd});
            this.dgvAvailableServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAvailableServices.EnableHeadersVisualStyles = false;
            this.dgvAvailableServices.Location = new System.Drawing.Point(0, 20);
            this.dgvAvailableServices.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvAvailableServices.Name = "dgvAvailableServices";
            this.dgvAvailableServices.ReadOnly = true;
            this.dgvAvailableServices.RowHeadersWidth = 51;
            this.dgvAvailableServices.RowTemplate.Height = 24;
            this.dgvAvailableServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAvailableServices.Size = new System.Drawing.Size(648, 631);
            this.dgvAvailableServices.TabIndex = 1;
            // 
            // colMaDVAvailable
            // 
            this.colMaDVAvailable.DataPropertyName = "MaDV";
            this.colMaDVAvailable.HeaderText = "Mã DV";
            this.colMaDVAvailable.MinimumWidth = 6;
            this.colMaDVAvailable.Name = "colMaDVAvailable";
            this.colMaDVAvailable.ReadOnly = true;
            this.colMaDVAvailable.Width = 70;
            // 
            // colTenDVAvailable
            // 
            this.colTenDVAvailable.DataPropertyName = "TenDV";
            this.colTenDVAvailable.HeaderText = "Tên Dịch Vụ";
            this.colTenDVAvailable.MinimumWidth = 6;
            this.colTenDVAvailable.Name = "colTenDVAvailable";
            this.colTenDVAvailable.ReadOnly = true;
            this.colTenDVAvailable.Width = 150;
            // 
            // colGiaAvailable
            // 
            this.colGiaAvailable.DataPropertyName = "Gia";
            this.colGiaAvailable.HeaderText = "Giá";
            this.colGiaAvailable.MinimumWidth = 6;
            this.colGiaAvailable.Name = "colGiaAvailable";
            this.colGiaAvailable.ReadOnly = true;
            // 
            // colChoPhepDoiDiem
            // 
            this.colChoPhepDoiDiem.HeaderText = "Đổi điểm";
            this.colChoPhepDoiDiem.MinimumWidth = 6;
            this.colChoPhepDoiDiem.Name = "colChoPhepDoiDiem";
            this.colChoPhepDoiDiem.ReadOnly = true;
            this.colChoPhepDoiDiem.Width = 80;
            // 
            // colGiaTriDoiDiem
            // 
            this.colGiaTriDoiDiem.HeaderText = "Giá trị điểm";
            this.colGiaTriDoiDiem.MinimumWidth = 6;
            this.colGiaTriDoiDiem.Name = "colGiaTriDoiDiem";
            this.colGiaTriDoiDiem.ReadOnly = true;
            this.colGiaTriDoiDiem.Width = 80;
            // 
            // colAdd
            // 
            this.colAdd.HeaderText = "Thêm";
            this.colAdd.MinimumWidth = 6;
            this.colAdd.Name = "colAdd";
            this.colAdd.ReadOnly = true;
            this.colAdd.Text = "+";
            this.colAdd.UseColumnTextForButtonValue = true;
            this.colAdd.Width = 50;
            // 
            // lblAvailableServices
            // 
            this.lblAvailableServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAvailableServices.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableServices.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblAvailableServices.Location = new System.Drawing.Point(0, 0);
            this.lblAvailableServices.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAvailableServices.Name = "lblAvailableServices";
            this.lblAvailableServices.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.lblAvailableServices.Size = new System.Drawing.Size(648, 20);
            this.lblAvailableServices.TabIndex = 0;
            this.lblAvailableServices.Text = "DANH SÁCH DỊCH VỤ CÓ SẴN";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.btnClose);
            this.panelRight.Controls.Add(this.btnSave);
            this.panelRight.Controls.Add(this.txtTotalAmount);
            this.panelRight.Controls.Add(this.lblTotalAmount);
            this.panelRight.Controls.Add(this.dgvSelectedServices);
            this.panelRight.Controls.Add(this.lblSelectedServices);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(648, 65);
            this.panelRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(526, 651);
            this.panelRight.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.IndianRed;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(406, 608);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng (Hủy)";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(291, 608);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "LƯU DỊCH VỤ";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.BackColor = System.Drawing.Color.White;
            this.txtTotalAmount.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(382, 557);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(114, 23);
            this.txtTotalAmount.TabIndex = 3;
            this.txtTotalAmount.Text = "0";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotalAmount.Location = new System.Drawing.Point(308, 560);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(73, 16);
            this.lblTotalAmount.TabIndex = 2;
            this.lblTotalAmount.Text = "Tổng Tiền:";
            // 
            // dgvSelectedServices
            // 
            this.dgvSelectedServices.AllowUserToAddRows = false;
            this.dgvSelectedServices.AllowUserToDeleteRows = false;
            this.dgvSelectedServices.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectedServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSelectedServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaDVSelected,
            this.colTenDVSelected,
            this.colSoLuongSelected,
            this.colGiaSelected,
            this.colThanhTienSelected,
            this.colRemove});
            this.dgvSelectedServices.Location = new System.Drawing.Point(4, 22);
            this.dgvSelectedServices.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvSelectedServices.Name = "dgvSelectedServices";
            this.dgvSelectedServices.RowHeadersWidth = 51;
            this.dgvSelectedServices.RowTemplate.Height = 24;
            this.dgvSelectedServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedServices.Size = new System.Drawing.Size(492, 523);
            this.dgvSelectedServices.TabIndex = 1;
            // 
            // colMaDVSelected
            // 
            this.colMaDVSelected.DataPropertyName = "MaDV";
            this.colMaDVSelected.HeaderText = "Mã DV";
            this.colMaDVSelected.MinimumWidth = 6;
            this.colMaDVSelected.Name = "colMaDVSelected";
            this.colMaDVSelected.ReadOnly = true;
            this.colMaDVSelected.Width = 60;
            // 
            // colTenDVSelected
            // 
            this.colTenDVSelected.DataPropertyName = "TenDV";
            this.colTenDVSelected.HeaderText = "Tên Dịch Vụ";
            this.colTenDVSelected.MinimumWidth = 6;
            this.colTenDVSelected.Name = "colTenDVSelected";
            this.colTenDVSelected.ReadOnly = true;
            this.colTenDVSelected.Width = 110;
            // 
            // colSoLuongSelected
            // 
            this.colSoLuongSelected.DataPropertyName = "SoLuong";
            this.colSoLuongSelected.HeaderText = "SL";
            this.colSoLuongSelected.MinimumWidth = 6;
            this.colSoLuongSelected.Name = "colSoLuongSelected";
            this.colSoLuongSelected.Width = 50;
            // 
            // colGiaSelected
            // 
            this.colGiaSelected.DataPropertyName = "Gia";
            this.colGiaSelected.HeaderText = "Giá";
            this.colGiaSelected.MinimumWidth = 6;
            this.colGiaSelected.Name = "colGiaSelected";
            this.colGiaSelected.ReadOnly = true;
            this.colGiaSelected.Width = 80;
            // 
            // colThanhTienSelected
            // 
            this.colThanhTienSelected.DataPropertyName = "ThanhTien";
            this.colThanhTienSelected.HeaderText = "Thành Tiền";
            this.colThanhTienSelected.MinimumWidth = 6;
            this.colThanhTienSelected.Name = "colThanhTienSelected";
            this.colThanhTienSelected.ReadOnly = true;
            this.colThanhTienSelected.Width = 90;
            // 
            // colRemove
            // 
            this.colRemove.HeaderText = "Xóa";
            this.colRemove.MinimumWidth = 6;
            this.colRemove.Name = "colRemove";
            this.colRemove.Text = "-";
            this.colRemove.UseColumnTextForButtonValue = true;
            this.colRemove.Width = 50;
            // 
            // lblSelectedServices
            // 
            this.lblSelectedServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelectedServices.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedServices.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSelectedServices.Location = new System.Drawing.Point(0, 0);
            this.lblSelectedServices.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedServices.Name = "lblSelectedServices";
            this.lblSelectedServices.Padding = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.lblSelectedServices.Size = new System.Drawing.Size(526, 20);
            this.lblSelectedServices.TabIndex = 0;
            this.lblSelectedServices.Text = "DỊCH VỤ ĐÃ CHỌN CHO PHÒNG";
            // 
            // frmServiceSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 716);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmServiceSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "💎 Chọn Dịch Vụ - Hệ Thống Quản Lý Resort";
            this.Load += new System.EventHandler(this.frmServiceSelection_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableServices)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedServices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
