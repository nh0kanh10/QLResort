using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_QLResort
{
    partial class frmRoomView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private System.Windows.Forms.ComboBox cbFilterResort;
        private System.Windows.Forms.ComboBox cbFilterRoomType;
        private System.Windows.Forms.ComboBox cbFilterStatus;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlFilter;
        private Button btnToggleView;
        private DataGridView dgvRooms;
        private Label lblRoomCount;
        private Button btnRefresh;
        private SplitContainer splitContainer1;
        private ContextMenuStrip contextMenuRoom;
        private ToolStripMenuItem menuItemDatPhong;
        private ToolStripMenuItem menuItemDonPhong;
        private ToolStripMenuItem menuItemSuaChuaPhong;
        private ToolStripMenuItem menuItemTraPhong;
        private ToolStripMenuItem menuItemCapNhatThongTin;
        private ToolStripMenuItem menuItemHuyDatPhong;
        private ToolStripMenuItem menuItemCheckIn;
        private ToolStripSeparator separator1;
        private ToolStripSeparator separator2;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoomView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuRoom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemDatPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemCheckIn = new System.Windows.Forms.ToolStripMenuItem();
            this.separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemDonPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSuaChuaPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTraPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCapNhatThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHuyDatPhong = new System.Windows.Forms.ToolStripMenuItem(); // Fix: Added instantiation
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.colMaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChiNhanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaTheoNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSucChua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbFilterResort = new System.Windows.Forms.ComboBox();
            this.cbFilterRoomType = new System.Windows.Forms.ComboBox();
            this.cbFilterStatus = new System.Windows.Forms.ComboBox();
            this.btnToggleView = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblRoomCount = new System.Windows.Forms.Label();
            this.contextMenuRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuRoom
            // 
            this.contextMenuRoom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuRoom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDatPhong,
            this.separator1,
            this.menuItemCheckIn,
            this.separator2,
            this.menuItemDonPhong,
            this.menuItemSuaChuaPhong,
            this.menuItemTraPhong,
            this.menuItemCapNhatThongTin,
            this.menuItemHuyDatPhong});
            this.contextMenuRoom.Name = "contextMenuRoom";
            this.contextMenuRoom.Size = new System.Drawing.Size(233, 148);
            // 
            // menuItemDatPhong
            // 
            this.menuItemDatPhong.Name = "menuItemDatPhong";
            this.menuItemDatPhong.Size = new System.Drawing.Size(232, 22);
            this.menuItemDatPhong.Text = "📅 Đặt phòng";
            this.menuItemDatPhong.Click += new System.EventHandler(this.MenuItemDatPhong_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(229, 6);
            // 
            // menuItemCheckIn
            // 
            this.menuItemCheckIn.Name = "menuItemCheckIn";
            this.menuItemCheckIn.Size = new System.Drawing.Size(232, 22);
            this.menuItemCheckIn.Text = "Check In";
            this.menuItemCheckIn.Click += new System.EventHandler(this.MenuItemCheckIn_Click);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(229, 6);
            // 
            // menuItemDonPhong
            // 
            this.menuItemDonPhong.Name = "menuItemDonPhong";
            this.menuItemDonPhong.Size = new System.Drawing.Size(232, 22);
            this.menuItemDonPhong.Text = "Dọn phòng";
            this.menuItemDonPhong.Click += new System.EventHandler(this.MenuItemDonPhong_Click);
            // 
            // menuItemSuaChuaPhong
            // 
            this.menuItemSuaChuaPhong.Name = "menuItemSuaChuaPhong";
            this.menuItemSuaChuaPhong.Size = new System.Drawing.Size(232, 22);
            this.menuItemSuaChuaPhong.Text = "Sửa chữa/Bảo trì";
            this.menuItemSuaChuaPhong.Click += new System.EventHandler(this.MenuItemSuaChuaPhong_Click);
            // 
            // menuItemTraPhong
            // 
            this.menuItemTraPhong.Name = "menuItemTraPhong";
            this.menuItemTraPhong.Size = new System.Drawing.Size(232, 22);
            this.menuItemTraPhong.Text = "Trả phòng";
            this.menuItemTraPhong.Click += new System.EventHandler(this.MenuItemTraPhong_Click);
            // 
            // menuItemHuyDatPhong
            // 
            this.menuItemHuyDatPhong.Name = "menuItemHuyDatPhong";
            this.menuItemHuyDatPhong.Size = new System.Drawing.Size(232, 22);
            this.menuItemHuyDatPhong.Text = "❌ Hủy đặt phòng";
            this.menuItemHuyDatPhong.Click += new System.EventHandler(this.MenuItemHuyDatPhong_Click);
            // 
            // menuItemCapNhatThongTin
            // 
            this.menuItemCapNhatThongTin.Name = "menuItemCapNhatThongTin";
            this.menuItemCapNhatThongTin.Size = new System.Drawing.Size(232, 22);
            this.menuItemCapNhatThongTin.Text = "Cập nhật thông tin đặt phòng";
            this.menuItemCapNhatThongTin.Click += new System.EventHandler(this.MenuItemCapNhatThongTin_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 80);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowPanel);
            this.splitContainer1.Panel1.Controls.Add(this.dgvRooms);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("splitContainer1.Panel2.BackgroundImage")));
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.splitContainer1.Size = new System.Drawing.Size(1073, 521);
            this.splitContainer1.SplitterDistance = 865;
            this.splitContainer1.TabIndex = 1;
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.Location = new System.Drawing.Point(0, 0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(865, 521);
            this.flowPanel.TabIndex = 0;
            // 
            // dgvRooms
            // 
            this.dgvRooms.AllowUserToAddRows = false;
            this.dgvRooms.AllowUserToDeleteRows = false;
            this.dgvRooms.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.dgvRooms.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRooms.BackgroundColor = System.Drawing.Color.White;
            this.dgvRooms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRooms.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRooms.ColumnHeadersHeight = 45;
            this.dgvRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaPhong,
            this.colSoPhong,
            this.colLoaiPhong,
            this.colChiNhanh,
            this.colViTri,
            this.colTrangThai,
            this.colGiaTheoNgay,
            this.colSucChua});
            this.dgvRooms.ContextMenuStrip = this.contextMenuRoom;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRooms.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRooms.EnableHeadersVisualStyles = false;
            this.dgvRooms.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.dgvRooms.Location = new System.Drawing.Point(0, 0);
            this.dgvRooms.MultiSelect = false;
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.ReadOnly = true;
            this.dgvRooms.RowHeadersVisible = false;
            this.dgvRooms.RowHeadersWidth = 51;
            this.dgvRooms.RowTemplate.Height = 35;
            this.dgvRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRooms.Size = new System.Drawing.Size(865, 521);
            this.dgvRooms.TabIndex = 1;
            this.dgvRooms.Visible = false;
            this.dgvRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRooms_CellClick);
            this.dgvRooms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRooms_CellDoubleClick);
            this.dgvRooms.SelectionChanged += new System.EventHandler(this.DgvRooms_SelectionChanged);
            this.dgvRooms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvRooms_MouseDown);
            // 
            // colMaPhong
            // 
            this.colMaPhong.DataPropertyName = "Mã Phòng";
            this.colMaPhong.HeaderText = "Mã Phòng";
            this.colMaPhong.Name = "colMaPhong";
            this.colMaPhong.ReadOnly = true;
            // 
            // colSoPhong
            // 
            this.colSoPhong.DataPropertyName = "Số Phòng";
            this.colSoPhong.HeaderText = "Số Phòng";
            this.colSoPhong.Name = "colSoPhong";
            this.colSoPhong.ReadOnly = true;
            // 
            // colLoaiPhong
            // 
            this.colLoaiPhong.DataPropertyName = "Loại Phòng";
            this.colLoaiPhong.HeaderText = "Loại Phòng";
            this.colLoaiPhong.Name = "colLoaiPhong";
            this.colLoaiPhong.ReadOnly = true;
            // 
            // colChiNhanh
            // 
            this.colChiNhanh.DataPropertyName = "Chi Nhánh";
            this.colChiNhanh.HeaderText = "Chi Nhánh";
            this.colChiNhanh.Name = "colChiNhanh";
            this.colChiNhanh.ReadOnly = true;
            // 
            // colViTri
            // 
            this.colViTri.DataPropertyName = "Vị Trí";
            this.colViTri.HeaderText = "Vị Trí";
            this.colViTri.Name = "colViTri";
            this.colViTri.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "Trạng Thái";
            this.colTrangThai.HeaderText = "Trạng Thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // colGiaTheoNgay
            // 
            this.colGiaTheoNgay.DataPropertyName = "Giá Theo Ngày";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            this.colGiaTheoNgay.DefaultCellStyle = dataGridViewCellStyle3;
            this.colGiaTheoNgay.HeaderText = "Giá Theo Ngày";
            this.colGiaTheoNgay.Name = "colGiaTheoNgay";
            this.colGiaTheoNgay.ReadOnly = true;
            // 
            // colSucChua
            // 
            this.colSucChua.DataPropertyName = "Sức Chứa";
            this.colSucChua.HeaderText = "Sức Chứa";
            this.colSucChua.Name = "colSucChua";
            this.colSucChua.ReadOnly = true;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlFilter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlFilter.BackgroundImage")));
            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Controls.Add(this.cbFilterResort);
            this.pnlFilter.Controls.Add(this.cbFilterRoomType);
            this.pnlFilter.Controls.Add(this.cbFilterStatus);
            this.pnlFilter.Controls.Add(this.btnToggleView);
            this.pnlFilter.Controls.Add(this.btnRefresh);
            this.pnlFilter.Controls.Add(this.lblRoomCount);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1073, 80);
            this.pnlFilter.TabIndex = 2;
            // 
            // lblFilter
            // 
            this.lblFilter.BackColor = System.Drawing.Color.Transparent;
            this.lblFilter.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.Black;
            this.lblFilter.Location = new System.Drawing.Point(20, 20);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(100, 23);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Lọc theo:";
            // 
            // cbFilterResort
            // 
            this.cbFilterResort.Location = new System.Drawing.Point(120, 18);
            this.cbFilterResort.Name = "cbFilterResort";
            this.cbFilterResort.Size = new System.Drawing.Size(200, 21);
            this.cbFilterResort.TabIndex = 1;
            this.cbFilterResort.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cbFilterRoomType
            // 
            this.cbFilterRoomType.Location = new System.Drawing.Point(330, 18);
            this.cbFilterRoomType.Name = "cbFilterRoomType";
            this.cbFilterRoomType.Size = new System.Drawing.Size(200, 21);
            this.cbFilterRoomType.TabIndex = 2;
            this.cbFilterRoomType.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // cbFilterStatus
            // 
            this.cbFilterStatus.Location = new System.Drawing.Point(540, 18);
            this.cbFilterStatus.Name = "cbFilterStatus";
            this.cbFilterStatus.Size = new System.Drawing.Size(150, 21);
            this.cbFilterStatus.TabIndex = 3;
            this.cbFilterStatus.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // btnToggleView
            // 
            this.btnToggleView.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleView.Location = new System.Drawing.Point(700, 18);
            this.btnToggleView.Name = "btnToggleView";
            this.btnToggleView.Size = new System.Drawing.Size(130, 35);
            this.btnToggleView.TabIndex = 4;
            this.btnToggleView.Text = "Dạng danh sách";
            this.btnToggleView.Click += new System.EventHandler(this.btnToggleView_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(840, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblRoomCount
            // 
            this.lblRoomCount.BackColor = System.Drawing.Color.Transparent;
            this.lblRoomCount.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomCount.ForeColor = System.Drawing.Color.Black;
            this.lblRoomCount.Location = new System.Drawing.Point(984, 20);
            this.lblRoomCount.Name = "lblRoomCount";
            this.lblRoomCount.Size = new System.Drawing.Size(127, 33);
            this.lblRoomCount.TabIndex = 6;
            this.lblRoomCount.Text = "0 phòng";
            // 
            // frmRoomView
            // 
            this.ClientSize = new System.Drawing.Size(1073, 601);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "frmRoomView";
            this.Text = "Xem Phòng";
            this.Load += new System.EventHandler(this.frmRoomView_Load);
            this.contextMenuRoom.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colMaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChiNhanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTheoNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSucChua;

    }
}







