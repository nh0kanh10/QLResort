
namespace GUI_QLResort
{
    partial class frmGuestDetail
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel searchPanel;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchGuest;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label lblGuestInfo;
        private System.Windows.Forms.FlowLayoutPanel infoBottomPanel;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblGuestType;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabBookings;
        private System.Windows.Forms.DataGridView dgvBookings;
        private System.Windows.Forms.TabPage tabServices;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.DataGridView dgvEvents;

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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.searchPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearchGuest = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.infoBottomPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblGuestType = new System.Windows.Forms.Label();
            this.lblGuestInfo = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabBookings = new System.Windows.Forms.TabPage();
            this.dgvBookings = new System.Windows.Forms.DataGridView();
            this.tabServices = new System.Windows.Forms.TabPage();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.headerPanel.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.infoBottomPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).BeginInit();
            this.tabServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.tabEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.headerPanel.Controls.Add(this.searchPanel);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1000, 100);
            this.headerPanel.TabIndex = 0;
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.lblSearch);
            this.searchPanel.Controls.Add(this.txtSearchGuest);
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchPanel.Location = new System.Drawing.Point(0, 50);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.searchPanel.Size = new System.Drawing.Size(1000, 50);
            this.searchPanel.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(23, 10);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(150, 30);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm khách hàng:";
            this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearchGuest
            // 
            this.txtSearchGuest.Location = new System.Drawing.Point(179, 13);
            this.txtSearchGuest.Name = "txtSearchGuest";
            this.txtSearchGuest.Size = new System.Drawing.Size(200, 20);
            this.txtSearchGuest.TabIndex = 1;
            this.txtSearchGuest.Text = "Nhập mã KH, CCCD, SĐT hoặc Email";
            this.txtSearchGuest.Enter += new System.EventHandler(this.txtSearchGuest_Enter);
            this.txtSearchGuest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearchGuest_KeyDown);
            this.txtSearchGuest.Leave += new System.EventHandler(this.txtSearchGuest_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(385, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "🔍 Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1000, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN KHÁCH HÀNG CHI TIẾT";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.infoPanel.Controls.Add(this.infoBottomPanel);
            this.infoPanel.Controls.Add(this.lblGuestInfo);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.Location = new System.Drawing.Point(0, 100);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(1000, 120);
            this.infoPanel.TabIndex = 1;
            // 
            // infoBottomPanel
            // 
            this.infoBottomPanel.Controls.Add(this.lblPoints);
            this.infoBottomPanel.Controls.Add(this.lblGuestType);
            this.infoBottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infoBottomPanel.Location = new System.Drawing.Point(0, 60);
            this.infoBottomPanel.Name = "infoBottomPanel";
            this.infoBottomPanel.Padding = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.infoBottomPanel.Size = new System.Drawing.Size(1000, 60);
            this.infoBottomPanel.TabIndex = 1;
            // 
            // lblPoints
            // 
            this.lblPoints.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.lblPoints.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblPoints.Location = new System.Drawing.Point(23, 5);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(200, 30);
            this.lblPoints.TabIndex = 0;
            this.lblPoints.Text = "Điểm tích lũy: 0";
            this.lblPoints.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGuestType
            // 
            this.lblGuestType.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.lblGuestType.Location = new System.Drawing.Point(229, 5);
            this.lblGuestType.Name = "lblGuestType";
            this.lblGuestType.Size = new System.Drawing.Size(300, 30);
            this.lblGuestType.TabIndex = 1;
            this.lblGuestType.Text = "Loại khách hàng: --";
            this.lblGuestType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGuestInfo
            // 
            this.lblGuestInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGuestInfo.Font = new System.Drawing.Font("Palatino Linotype", 11F);
            this.lblGuestInfo.Location = new System.Drawing.Point(0, 0);
            this.lblGuestInfo.Name = "lblGuestInfo";
            this.lblGuestInfo.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.lblGuestInfo.Size = new System.Drawing.Size(1000, 60);
            this.lblGuestInfo.TabIndex = 0;
            this.lblGuestInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabBookings);
            this.tabControl.Controls.Add(this.tabServices);
            this.tabControl.Controls.Add(this.tabEvents);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 220);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(10, 5);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 480);
            this.tabControl.TabIndex = 2;
            // 
            // tabBookings
            // 
            this.tabBookings.Controls.Add(this.dgvBookings);
            this.tabBookings.Location = new System.Drawing.Point(4, 26);
            this.tabBookings.Name = "tabBookings";
            this.tabBookings.Padding = new System.Windows.Forms.Padding(3);
            this.tabBookings.Size = new System.Drawing.Size(992, 450);
            this.tabBookings.TabIndex = 0;
            this.tabBookings.Text = "📅 Lịch sử đặt phòng";
            this.tabBookings.UseVisualStyleBackColor = true;
            // 
            // dgvBookings
            // 
            this.dgvBookings.AllowUserToAddRows = false;
            this.dgvBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBookings.Location = new System.Drawing.Point(3, 3);
            this.dgvBookings.Name = "dgvBookings";
            this.dgvBookings.ReadOnly = true;
            this.dgvBookings.Size = new System.Drawing.Size(986, 444);
            this.dgvBookings.TabIndex = 0;
            // 
            // tabServices
            // 
            this.tabServices.Controls.Add(this.dgvServices);
            this.tabServices.Location = new System.Drawing.Point(4, 26);
            this.tabServices.Name = "tabServices";
            this.tabServices.Padding = new System.Windows.Forms.Padding(3);
            this.tabServices.Size = new System.Drawing.Size(992, 450);
            this.tabServices.TabIndex = 1;
            this.tabServices.Text = "🛎 Lịch sử dịch vụ";
            this.tabServices.UseVisualStyleBackColor = true;
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvServices.Location = new System.Drawing.Point(3, 3);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.Size = new System.Drawing.Size(986, 444);
            this.dgvServices.TabIndex = 0;
            // 
            // tabEvents
            // 
            this.tabEvents.Controls.Add(this.dgvEvents);
            this.tabEvents.Location = new System.Drawing.Point(4, 26);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tabEvents.Size = new System.Drawing.Size(992, 450);
            this.tabEvents.TabIndex = 2;
            this.tabEvents.Text = "🎉 Lịch sử sự kiện";
            this.tabEvents.UseVisualStyleBackColor = true;
            // 
            // dgvEvents
            // 
            this.dgvEvents.AllowUserToAddRows = false;
            this.dgvEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEvents.Location = new System.Drawing.Point(3, 3);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.Size = new System.Drawing.Size(986, 444);
            this.dgvEvents.TabIndex = 0;
            // 
            // frmGuestDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "frmGuestDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin khách hàng chi tiết";
            this.headerPanel.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.infoBottomPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookings)).EndInit();
            this.tabServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.tabEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
