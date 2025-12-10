using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLResort.GUI
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
        private ToolStripMenuItem menuItemCheckIn;
        private ToolStripMenuItem menuItemCheckOut;
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
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cbFilterResort = new System.Windows.Forms.ComboBox();
            this.cbFilterRoomType = new System.Windows.Forms.ComboBox();
            this.cbFilterStatus = new System.Windows.Forms.ComboBox();
            this.btnToggleView = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblRoomCount = new System.Windows.Forms.Label();
            this.dgvRooms = new System.Windows.Forms.DataGridView();
            this.contextMenuRoom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemDatPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemCheckIn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCheckOut = new System.Windows.Forms.ToolStripMenuItem();
            this.separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemDonPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSuaChuaPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTraPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCapNhatThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).BeginInit();
            this.contextMenuRoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanel.Location = new System.Drawing.Point(0, 0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(812, 521);
            this.flowPanel.TabIndex = 0;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
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
            this.pnlFilter.Size = new System.Drawing.Size(1007, 80);
            this.pnlFilter.TabIndex = 2;
            // 
            // lblFilter
            // 
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.Gold;
            this.lblFilter.Location = new System.Drawing.Point(20, 20);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(100, 23);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "🔍 Lọc theo:";
            // 
            // cbFilterResort
            // 
            this.cbFilterResort.Location = new System.Drawing.Point(120, 18);
            this.cbFilterResort.Name = "cbFilterResort";
            this.cbFilterResort.Size = new System.Drawing.Size(200, 24);
            this.cbFilterResort.TabIndex = 1;
            // 
            // cbFilterRoomType
            // 
            this.cbFilterRoomType.Location = new System.Drawing.Point(330, 18);
            this.cbFilterRoomType.Name = "cbFilterRoomType";
            this.cbFilterRoomType.Size = new System.Drawing.Size(200, 24);
            this.cbFilterRoomType.TabIndex = 2;
            // 
            // cbFilterStatus
            // 
            this.cbFilterStatus.Location = new System.Drawing.Point(540, 18);
            this.cbFilterStatus.Name = "cbFilterStatus";
            this.cbFilterStatus.Size = new System.Drawing.Size(150, 24);
            this.cbFilterStatus.TabIndex = 3;
            // 
            // btnToggleView
            // 
            this.btnToggleView.Location = new System.Drawing.Point(700, 18);
            this.btnToggleView.Name = "btnToggleView";
            this.btnToggleView.Size = new System.Drawing.Size(130, 35);
            this.btnToggleView.TabIndex = 4;
            this.btnToggleView.Text = "📋 Dạng danh sách";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(840, 18);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "⟳ Refresh";
            // 
            // lblRoomCount
            // 
            this.lblRoomCount.ForeColor = System.Drawing.Color.White;
            this.lblRoomCount.Location = new System.Drawing.Point(20, 55);
            this.lblRoomCount.Name = "lblRoomCount";
            this.lblRoomCount.Size = new System.Drawing.Size(100, 23);
            this.lblRoomCount.TabIndex = 6;
            this.lblRoomCount.Text = "0 phòng";
            // 
            // dgvRooms
            // 
            this.dgvRooms.ColumnHeadersHeight = 29;
            this.dgvRooms.ContextMenuStrip = this.contextMenuRoom;
            this.dgvRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRooms.Location = new System.Drawing.Point(0, 0);
            this.dgvRooms.Name = "dgvRooms";
            this.dgvRooms.RowHeadersWidth = 51;
            this.dgvRooms.Size = new System.Drawing.Size(812, 521);
            this.dgvRooms.TabIndex = 1;
            this.dgvRooms.Visible = false;
            // 
            // contextMenuRoom
            // 
            this.contextMenuRoom.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuRoom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDatPhong,
            this.separator1,
            this.menuItemCheckIn,
            this.menuItemCheckOut,
            this.separator2,
            this.menuItemDonPhong,
            this.menuItemSuaChuaPhong,
            this.menuItemTraPhong,
            this.menuItemCapNhatThongTin});
            this.contextMenuRoom.Name = "contextMenuRoom";
            this.contextMenuRoom.Size = new System.Drawing.Size(300, 184);
            // 
            // menuItemDatPhong
            // 
            this.menuItemDatPhong.Name = "menuItemDatPhong";
            this.menuItemDatPhong.Size = new System.Drawing.Size(299, 24);
            this.menuItemDatPhong.Text = "📅 Đặt phòng";
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(296, 6);
            // 
            // menuItemCheckIn
            // 
            this.menuItemCheckIn.Name = "menuItemCheckIn";
            this.menuItemCheckIn.Size = new System.Drawing.Size(299, 24);
            this.menuItemCheckIn.Text = "✅ Check In";
            // 
            // menuItemCheckOut
            // 
            this.menuItemCheckOut.Name = "menuItemCheckOut";
            this.menuItemCheckOut.Size = new System.Drawing.Size(299, 24);
            this.menuItemCheckOut.Text = "🚪 Check Out";
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(296, 6);
            // 
            // menuItemDonPhong
            // 
            this.menuItemDonPhong.Name = "menuItemDonPhong";
            this.menuItemDonPhong.Size = new System.Drawing.Size(299, 24);
            this.menuItemDonPhong.Text = "🧹 Dọn phòng";
            // 
            // menuItemSuaChuaPhong
            // 
            this.menuItemSuaChuaPhong.Name = "menuItemSuaChuaPhong";
            this.menuItemSuaChuaPhong.Size = new System.Drawing.Size(299, 24);
            this.menuItemSuaChuaPhong.Text = "🔧 Sửa chữa/Bảo trì";
            // 
            // menuItemTraPhong
            // 
            this.menuItemTraPhong.Name = "menuItemTraPhong";
            this.menuItemTraPhong.Size = new System.Drawing.Size(299, 24);
            this.menuItemTraPhong.Text = "💳 Trả phòng";
            // 
            // menuItemCapNhatThongTin
            // 
            this.menuItemCapNhatThongTin.Name = "menuItemCapNhatThongTin";
            this.menuItemCapNhatThongTin.Size = new System.Drawing.Size(299, 24);
            this.menuItemCapNhatThongTin.Text = "✏️ Cập nhật thông tin đặt phòng";
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
            this.splitContainer1.Size = new System.Drawing.Size(1007, 521);
            this.splitContainer1.SplitterDistance = 812;
            this.splitContainer1.TabIndex = 1;
            // 
            // frmRoomView
            // 
            this.ClientSize = new System.Drawing.Size(1007, 601);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlFilter);
            this.Name = "frmRoomView";
            this.Text = "✨ Xem Phòng";
            this.pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRooms)).EndInit();
            this.contextMenuRoom.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

    }
}







