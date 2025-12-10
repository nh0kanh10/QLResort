// File: QLResort-master/QLResort/GUI/frmBooking.Designer.cs (Đã Sửa Lỗi Khởi Tạo Biến)

namespace QLResort.GUI
{
    partial class frmBooking
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlBookingDetails;
        private System.Windows.Forms.GroupBox gbServices;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.Panel pnlRoomInfo;
        private System.Windows.Forms.Panel pnlActions;

        // TẤT CẢ CÁC CONTROLS KHÁC (Đã được khai báo)
        private System.Windows.Forms.Label lblRoomNumber;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.Label lblRoomPrice;
        private System.Windows.Forms.Label lblRoomStatus;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerEmail;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.ComboBox cbIDType;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label lblIDType;
        private System.Windows.Forms.DataGridView dgvSelectedServices;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnRemoveService;
        private System.Windows.Forms.Button btnConfirmBooking;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblCustomerEmail;
        private System.Windows.Forms.PictureBox picRoom;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblRoomCapacity;


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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBookingDetails = new System.Windows.Forms.Panel();
            this.pnlPayment = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbPaymentSummary = new System.Windows.Forms.GroupBox();
            this.btnAddDeposit = new System.Windows.Forms.Button();
            this.btnApplyDiscount = new System.Windows.Forms.Button();
            this.txtDiscountCode = new System.Windows.Forms.TextBox();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtServicesTotal = new System.Windows.Forms.TextBox();
            this.txtRoomTotal = new System.Windows.Forms.TextBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblServicesTotal = new System.Windows.Forms.Label();
            this.lblRoomTotal = new System.Windows.Forms.Label();
            this.gbServices = new System.Windows.Forms.GroupBox();
            this.btnRemoveService = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.dgvSelectedServices = new System.Windows.Forms.DataGridView();
            this.gbBookingDates = new System.Windows.Forms.GroupBox();
            this.txtChildrenCount = new System.Windows.Forms.TextBox();
            this.txtAdultsCount = new System.Windows.Forms.TextBox();
            this.gbBookingType = new System.Windows.Forms.GroupBox();
            this.rbBookInAdvance = new System.Windows.Forms.RadioButton();
            this.rbCheckInNow = new System.Windows.Forms.RadioButton();
            this.lblNightsCount = new System.Windows.Forms.Label();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.lblCustomerEmail = new System.Windows.Forms.Label();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblIDType = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.cbIDType = new System.Windows.Forms.ComboBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtCustomerEmail = new System.Windows.Forms.TextBox();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.pnlRoomInfo = new System.Windows.Forms.Panel();
            this.lblRoomCapacity = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.picRoom = new System.Windows.Forms.PictureBox();
            this.lblRoomStatus = new System.Windows.Forms.Label();
            this.lblRoomPrice = new System.Windows.Forms.Label();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirmBooking = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlBookingDetails.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            this.gbPaymentSummary.SuspendLayout();
            this.gbServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedServices)).BeginInit();
            this.gbBookingDates.SuspendLayout();
            this.gbBookingType.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            this.pnlRoomInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1346, 90);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(40, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(451, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "✨ ĐẶT PHÒNG RESORT";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlBookingDetails);
            this.pnlMain.Controls.Add(this.pnlActions);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 90);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1346, 965);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlBookingDetails
            // 
            this.pnlBookingDetails.AutoScroll = true;
            this.pnlBookingDetails.BackColor = System.Drawing.Color.White;
            this.pnlBookingDetails.Controls.Add(this.pnlPayment);
            this.pnlBookingDetails.Controls.Add(this.gbServices);
            this.pnlBookingDetails.Controls.Add(this.gbBookingDates);
            this.pnlBookingDetails.Controls.Add(this.gbCustomer);
            this.pnlBookingDetails.Controls.Add(this.pnlRoomInfo);
            this.pnlBookingDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBookingDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlBookingDetails.Name = "pnlBookingDetails";
            this.pnlBookingDetails.Padding = new System.Windows.Forms.Padding(50, 25, 50, 25);
            this.pnlBookingDetails.Size = new System.Drawing.Size(1346, 910);
            this.pnlBookingDetails.TabIndex = 0;
            // 
            // pnlPayment
            // 
            this.pnlPayment.Controls.Add(this.textBox1);
            this.pnlPayment.Controls.Add(this.gbPaymentSummary);
            this.pnlPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPayment.Location = new System.Drawing.Point(50, 684);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(1246, 220);
            this.pnlPayment.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(844, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // gbPaymentSummary
            // 
            this.gbPaymentSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.gbPaymentSummary.Controls.Add(this.btnAddDeposit);
            this.gbPaymentSummary.Controls.Add(this.btnApplyDiscount);
            this.gbPaymentSummary.Controls.Add(this.txtDiscountCode);
            this.gbPaymentSummary.Controls.Add(this.txtGrandTotal);
            this.gbPaymentSummary.Controls.Add(this.txtDeposit);
            this.gbPaymentSummary.Controls.Add(this.txtDiscount);
            this.gbPaymentSummary.Controls.Add(this.txtServicesTotal);
            this.gbPaymentSummary.Controls.Add(this.txtRoomTotal);
            this.gbPaymentSummary.Controls.Add(this.lblGrandTotal);
            this.gbPaymentSummary.Controls.Add(this.lblDeposit);
            this.gbPaymentSummary.Controls.Add(this.lblDiscount);
            this.gbPaymentSummary.Controls.Add(this.lblServicesTotal);
            this.gbPaymentSummary.Controls.Add(this.lblRoomTotal);
            this.gbPaymentSummary.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbPaymentSummary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbPaymentSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.gbPaymentSummary.Location = new System.Drawing.Point(0, 0);
            this.gbPaymentSummary.Name = "gbPaymentSummary";
            this.gbPaymentSummary.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.gbPaymentSummary.Size = new System.Drawing.Size(640, 220);
            this.gbPaymentSummary.TabIndex = 0;
            this.gbPaymentSummary.TabStop = false;
            this.gbPaymentSummary.Text = "💰 THANH TOÁN";
            // 
            // btnAddDeposit
            // 
            this.btnAddDeposit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddDeposit.FlatAppearance.BorderSize = 0;
            this.btnAddDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDeposit.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddDeposit.ForeColor = System.Drawing.Color.White;
            this.btnAddDeposit.Location = new System.Drawing.Point(470, 100);
            this.btnAddDeposit.Name = "btnAddDeposit";
            this.btnAddDeposit.Size = new System.Drawing.Size(120, 30);
            this.btnAddDeposit.TabIndex = 12;
            this.btnAddDeposit.Text = "THÊM CỌC";
            this.btnAddDeposit.UseVisualStyleBackColor = false;
            // 
            // btnApplyDiscount
            // 
            this.btnApplyDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnApplyDiscount.FlatAppearance.BorderSize = 0;
            this.btnApplyDiscount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(105)))), ((int)(((byte)(195)))));
            this.btnApplyDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyDiscount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyDiscount.ForeColor = System.Drawing.Color.White;
            this.btnApplyDiscount.Location = new System.Drawing.Point(470, 56);
            this.btnApplyDiscount.Name = "btnApplyDiscount";
            this.btnApplyDiscount.Size = new System.Drawing.Size(130, 31);
            this.btnApplyDiscount.TabIndex = 11;
            this.btnApplyDiscount.Text = " ÁP DỤNG";
            this.btnApplyDiscount.UseVisualStyleBackColor = false;
            // 
            // txtDiscountCode
            // 
            this.txtDiscountCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiscountCode.Location = new System.Drawing.Point(340, 60);
            this.txtDiscountCode.Name = "txtDiscountCode";
            this.txtDiscountCode.Size = new System.Drawing.Size(120, 27);
            this.txtDiscountCode.TabIndex = 10;
            this.txtDiscountCode.Text = "Mã giảm giá";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.txtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrandTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.txtGrandTotal.Location = new System.Drawing.Point(320, 155);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(260, 39);
            this.txtGrandTotal.TabIndex = 9;
            this.txtGrandTotal.Text = "0";
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDeposit
            // 
            this.txtDeposit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDeposit.Location = new System.Drawing.Point(340, 100);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.ReadOnly = true;
            this.txtDeposit.Size = new System.Drawing.Size(120, 27);
            this.txtDeposit.TabIndex = 8;
            this.txtDeposit.Text = "0";
            this.txtDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiscount.Location = new System.Drawing.Point(340, 30);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(120, 27);
            this.txtDiscount.TabIndex = 7;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtServicesTotal
            // 
            this.txtServicesTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtServicesTotal.Location = new System.Drawing.Point(120, 100);
            this.txtServicesTotal.Name = "txtServicesTotal";
            this.txtServicesTotal.ReadOnly = true;
            this.txtServicesTotal.Size = new System.Drawing.Size(150, 27);
            this.txtServicesTotal.TabIndex = 6;
            this.txtServicesTotal.Text = "0";
            this.txtServicesTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRoomTotal
            // 
            this.txtRoomTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRoomTotal.Location = new System.Drawing.Point(120, 30);
            this.txtRoomTotal.Name = "txtRoomTotal";
            this.txtRoomTotal.ReadOnly = true;
            this.txtRoomTotal.Size = new System.Drawing.Size(150, 27);
            this.txtRoomTotal.TabIndex = 5;
            this.txtRoomTotal.Text = "0";
            this.txtRoomTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.Location = new System.Drawing.Point(199, 159);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(117, 23);
            this.lblGrandTotal.TabIndex = 4;
            this.lblGrandTotal.Text = "TỔNG CỘNG:";
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDeposit.Location = new System.Drawing.Point(37, 117);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(67, 20);
            this.lblDeposit.TabIndex = 3;
            this.lblDeposit.Text = "Tiền cọc:";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiscount.Location = new System.Drawing.Point(37, 77);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(72, 20);
            this.lblDiscount.TabIndex = 2;
            this.lblDiscount.Text = "Giảm giá:";
            // 
            // lblServicesTotal
            // 
            this.lblServicesTotal.AutoSize = true;
            this.lblServicesTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblServicesTotal.Location = new System.Drawing.Point(37, 117);
            this.lblServicesTotal.Name = "lblServicesTotal";
            this.lblServicesTotal.Size = new System.Drawing.Size(61, 20);
            this.lblServicesTotal.TabIndex = 1;
            this.lblServicesTotal.Text = "Dịch vụ:";
            // 
            // lblRoomTotal
            // 
            this.lblRoomTotal.AutoSize = true;
            this.lblRoomTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoomTotal.Location = new System.Drawing.Point(37, 47);
            this.lblRoomTotal.Name = "lblRoomTotal";
            this.lblRoomTotal.Size = new System.Drawing.Size(87, 20);
            this.lblRoomTotal.TabIndex = 0;
            this.lblRoomTotal.Text = "Tiền phòng:";
            // 
            // gbServices
            // 
            this.gbServices.BackColor = System.Drawing.Color.White;
            this.gbServices.Controls.Add(this.btnRemoveService);
            this.gbServices.Controls.Add(this.btnAddService);
            this.gbServices.Controls.Add(this.dgvSelectedServices);
            this.gbServices.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbServices.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.gbServices.Location = new System.Drawing.Point(50, 485);
            this.gbServices.Name = "gbServices";
            this.gbServices.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.gbServices.Size = new System.Drawing.Size(1246, 199);
            this.gbServices.TabIndex = 3;
            this.gbServices.TabStop = false;
            this.gbServices.Text = "✅ DỊCH VỤ ĐÃ CHỌN";
            this.gbServices.Enter += new System.EventHandler(this.gbServices_Enter);
            // 
            // btnRemoveService
            // 
            this.btnRemoveService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemoveService.FlatAppearance.BorderSize = 0;
            this.btnRemoveService.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(90)))), ((int)(((byte)(75)))));
            this.btnRemoveService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveService.ForeColor = System.Drawing.Color.White;
            this.btnRemoveService.Location = new System.Drawing.Point(450, 80);
            this.btnRemoveService.Name = "btnRemoveService";
            this.btnRemoveService.Size = new System.Drawing.Size(130, 35);
            this.btnRemoveService.TabIndex = 2;
            this.btnRemoveService.Text = "❌ XÓA";
            this.btnRemoveService.UseVisualStyleBackColor = false;
            // 
            // btnAddService
            // 
            this.btnAddService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btnAddService.FlatAppearance.BorderSize = 0;
            this.btnAddService.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddService.ForeColor = System.Drawing.Color.White;
            this.btnAddService.Location = new System.Drawing.Point(450, 35);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(130, 35);
            this.btnAddService.TabIndex = 1;
            this.btnAddService.Text = "➕ THÊM";
            this.btnAddService.UseVisualStyleBackColor = false;
            // 
            // dgvSelectedServices
            // 
            this.dgvSelectedServices.AllowUserToAddRows = false;
            this.dgvSelectedServices.AllowUserToDeleteRows = false;
            this.dgvSelectedServices.BackgroundColor = System.Drawing.Color.White;
            this.dgvSelectedServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectedServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelectedServices.ColumnHeadersHeight = 40;
            this.dgvSelectedServices.Location = new System.Drawing.Point(20, 30);
            this.dgvSelectedServices.Name = "dgvSelectedServices";
            this.dgvSelectedServices.ReadOnly = true;
            this.dgvSelectedServices.RowHeadersWidth = 51;
            this.dgvSelectedServices.RowTemplate.Height = 35;
            this.dgvSelectedServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedServices.Size = new System.Drawing.Size(440, 100);
            this.dgvSelectedServices.TabIndex = 0;
            // 
            // gbBookingDates
            // 
            this.gbBookingDates.BackColor = System.Drawing.Color.White;
            this.gbBookingDates.Controls.Add(this.txtChildrenCount);
            this.gbBookingDates.Controls.Add(this.txtAdultsCount);
            this.gbBookingDates.Controls.Add(this.gbBookingType);
            this.gbBookingDates.Controls.Add(this.lblNightsCount);
            this.gbBookingDates.Controls.Add(this.lblCheckOut);
            this.gbBookingDates.Controls.Add(this.lblCheckIn);
            this.gbBookingDates.Controls.Add(this.dtpCheckOut);
            this.gbBookingDates.Controls.Add(this.dtpCheckIn);
            this.gbBookingDates.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBookingDates.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbBookingDates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.gbBookingDates.Location = new System.Drawing.Point(50, 305);
            this.gbBookingDates.Name = "gbBookingDates";
            this.gbBookingDates.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.gbBookingDates.Size = new System.Drawing.Size(1246, 180);
            this.gbBookingDates.TabIndex = 2;
            this.gbBookingDates.TabStop = false;
            this.gbBookingDates.Text = "📅 THỜI GIAN ĐẶT PHÒNG";
            // 
            // txtChildrenCount
            // 
            this.txtChildrenCount.Location = new System.Drawing.Point(858, 109);
            this.txtChildrenCount.Name = "txtChildrenCount";
            this.txtChildrenCount.Size = new System.Drawing.Size(100, 30);
            this.txtChildrenCount.TabIndex = 6;
            // 
            // txtAdultsCount
            // 
            this.txtAdultsCount.Location = new System.Drawing.Point(733, 109);
            this.txtAdultsCount.Name = "txtAdultsCount";
            this.txtAdultsCount.Size = new System.Drawing.Size(100, 30);
            this.txtAdultsCount.TabIndex = 5;
            // 
            // gbBookingType
            // 
            this.gbBookingType.BackColor = System.Drawing.Color.White;
            this.gbBookingType.Controls.Add(this.rbBookInAdvance);
            this.gbBookingType.Controls.Add(this.rbCheckInNow);
            this.gbBookingType.Location = new System.Drawing.Point(20, 20);
            this.gbBookingType.Name = "gbBookingType";
            this.gbBookingType.Size = new System.Drawing.Size(300, 60);
            this.gbBookingType.TabIndex = 0;
            this.gbBookingType.TabStop = false;
            this.gbBookingType.Text = "Loại đặt phòng";
            // 
            // rbBookInAdvance
            // 
            this.rbBookInAdvance.Checked = true;
            this.rbBookInAdvance.Location = new System.Drawing.Point(20, 25);
            this.rbBookInAdvance.Name = "rbBookInAdvance";
            this.rbBookInAdvance.Size = new System.Drawing.Size(100, 20);
            this.rbBookInAdvance.TabIndex = 0;
            this.rbBookInAdvance.TabStop = true;
            this.rbBookInAdvance.Text = "Đặt trước";
            // 
            // rbCheckInNow
            // 
            this.rbCheckInNow.Location = new System.Drawing.Point(140, 25);
            this.rbCheckInNow.Name = "rbCheckInNow";
            this.rbCheckInNow.Size = new System.Drawing.Size(150, 20);
            this.rbCheckInNow.TabIndex = 1;
            this.rbCheckInNow.Text = "Check-in trực tiếp";
            // 
            // lblNightsCount
            // 
            this.lblNightsCount.AutoSize = true;
            this.lblNightsCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNightsCount.Location = new System.Drawing.Point(487, 117);
            this.lblNightsCount.Name = "lblNightsCount";
            this.lblNightsCount.Size = new System.Drawing.Size(51, 20);
            this.lblNightsCount.TabIndex = 4;
            this.lblNightsCount.Text = "0 đêm";
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckOut.Location = new System.Drawing.Point(257, 97);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(69, 20);
            this.lblCheckOut.TabIndex = 3;
            this.lblCheckOut.Text = "Ngày trả:";
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCheckIn.Location = new System.Drawing.Point(37, 97);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(83, 20);
            this.lblCheckIn.TabIndex = 2;
            this.lblCheckIn.Text = "Ngày nhận:";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCheckOut.Location = new System.Drawing.Point(240, 105);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(200, 27);
            this.dtpCheckOut.TabIndex = 1;
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCheckIn.Location = new System.Drawing.Point(20, 105);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(200, 27);
            this.dtpCheckIn.TabIndex = 0;
            // 
            // gbCustomer
            // 
            this.gbCustomer.BackColor = System.Drawing.Color.White;
            this.gbCustomer.Controls.Add(this.lblCustomerEmail);
            this.gbCustomer.Controls.Add(this.lblCustomerPhone);
            this.gbCustomer.Controls.Add(this.lblCustomerName);
            this.gbCustomer.Controls.Add(this.lblIDType);
            this.gbCustomer.Controls.Add(this.lblCustomerID);
            this.gbCustomer.Controls.Add(this.btnSearchCustomer);
            this.gbCustomer.Controls.Add(this.cbIDType);
            this.gbCustomer.Controls.Add(this.txtCustomerID);
            this.gbCustomer.Controls.Add(this.txtCustomerEmail);
            this.gbCustomer.Controls.Add(this.txtCustomerPhone);
            this.gbCustomer.Controls.Add(this.txtCustomerName);
            this.gbCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCustomer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.gbCustomer.Location = new System.Drawing.Point(50, 145);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Padding = new System.Windows.Forms.Padding(20, 15, 20, 15);
            this.gbCustomer.Size = new System.Drawing.Size(1246, 160);
            this.gbCustomer.TabIndex = 1;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "👤 THÔNG TIN KHÁCH HÀNG";
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.AutoSize = true;
            this.lblCustomerEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerEmail.Location = new System.Drawing.Point(597, 112);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(49, 20);
            this.lblCustomerEmail.TabIndex = 6;
            this.lblCustomerEmail.Text = "Email:";
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerPhone.Location = new System.Drawing.Point(317, 112);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(39, 20);
            this.lblCustomerPhone.TabIndex = 5;
            this.lblCustomerPhone.Text = "SĐT:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerName.Location = new System.Drawing.Point(37, 112);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(57, 20);
            this.lblCustomerName.TabIndex = 4;
            this.lblCustomerName.Text = "Họ tên:";
            // 
            // lblIDType
            // 
            this.lblIDType.AutoSize = true;
            this.lblIDType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIDType.Location = new System.Drawing.Point(297, 42);
            this.lblIDType.Name = "lblIDType";
            this.lblIDType.Size = new System.Drawing.Size(90, 20);
            this.lblIDType.TabIndex = 8;
            this.lblIDType.Text = "Loại giấy tờ:";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerID.Location = new System.Drawing.Point(37, 42);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(96, 20);
            this.lblCustomerID.TabIndex = 7;
            this.lblCustomerID.Text = "Mã căn cước:";
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btnSearchCustomer.FlatAppearance.BorderSize = 0;
            this.btnSearchCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.White;
            this.btnSearchCustomer.Location = new System.Drawing.Point(450, 50);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(130, 35);
            this.btnSearchCustomer.TabIndex = 11;
            this.btnSearchCustomer.Text = "🔍 TÌM KIẾM";
            this.btnSearchCustomer.UseVisualStyleBackColor = false;
            // 
            // cbIDType
            // 
            this.cbIDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIDType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cbIDType.FormattingEnabled = true;
            this.cbIDType.Items.AddRange(new object[] {
            "CCCD",
            "CMND",
            "Passport"});
            this.cbIDType.Location = new System.Drawing.Point(280, 55);
            this.cbIDType.Name = "cbIDType";
            this.cbIDType.Size = new System.Drawing.Size(150, 29);
            this.cbIDType.TabIndex = 10;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCustomerID.Location = new System.Drawing.Point(20, 55);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(250, 29);
            this.txtCustomerID.TabIndex = 9;
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCustomerEmail.Location = new System.Drawing.Point(580, 125);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.ReadOnly = true;
            this.txtCustomerEmail.Size = new System.Drawing.Size(250, 29);
            this.txtCustomerEmail.TabIndex = 2;
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(300, 125);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.ReadOnly = true;
            this.txtCustomerPhone.Size = new System.Drawing.Size(250, 29);
            this.txtCustomerPhone.TabIndex = 1;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCustomerName.Location = new System.Drawing.Point(20, 125);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(250, 29);
            this.txtCustomerName.TabIndex = 0;
            // 
            // pnlRoomInfo
            // 
            this.pnlRoomInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlRoomInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRoomInfo.Controls.Add(this.lblRoomCapacity);
            this.pnlRoomInfo.Controls.Add(this.lblCapacity);
            this.pnlRoomInfo.Controls.Add(this.picRoom);
            this.pnlRoomInfo.Controls.Add(this.lblRoomStatus);
            this.pnlRoomInfo.Controls.Add(this.lblRoomPrice);
            this.pnlRoomInfo.Controls.Add(this.lblRoomType);
            this.pnlRoomInfo.Controls.Add(this.lblRoomNumber);
            this.pnlRoomInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoomInfo.Location = new System.Drawing.Point(50, 25);
            this.pnlRoomInfo.Name = "pnlRoomInfo";
            this.pnlRoomInfo.Padding = new System.Windows.Forms.Padding(15);
            this.pnlRoomInfo.Size = new System.Drawing.Size(1246, 120);
            this.pnlRoomInfo.TabIndex = 0;
            // 
            // lblRoomCapacity
            // 
            this.lblRoomCapacity.AutoSize = true;
            this.lblRoomCapacity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRoomCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.lblRoomCapacity.Location = new System.Drawing.Point(485, 70);
            this.lblRoomCapacity.Name = "lblRoomCapacity";
            this.lblRoomCapacity.Size = new System.Drawing.Size(19, 23);
            this.lblRoomCapacity.TabIndex = 6;
            this.lblRoomCapacity.Text = "0";
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCapacity.Location = new System.Drawing.Point(485, 45);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(76, 20);
            this.lblCapacity.TabIndex = 5;
            this.lblCapacity.Text = "Sức chứa:";
            // 
            // picRoom
            // 
            this.picRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRoom.Location = new System.Drawing.Point(15, 15);
            this.picRoom.Name = "picRoom";
            this.picRoom.Size = new System.Drawing.Size(90, 90);
            this.picRoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRoom.TabIndex = 4;
            this.picRoom.TabStop = false;
            // 
            // lblRoomStatus
            // 
            this.lblRoomStatus.AutoSize = true;
            this.lblRoomStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoomStatus.Location = new System.Drawing.Point(335, 75);
            this.lblRoomStatus.Name = "lblRoomStatus";
            this.lblRoomStatus.Size = new System.Drawing.Size(75, 20);
            this.lblRoomStatus.TabIndex = 3;
            this.lblRoomStatus.Text = "Trạng thái";
            // 
            // lblRoomPrice
            // 
            this.lblRoomPrice.AutoSize = true;
            this.lblRoomPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoomPrice.Location = new System.Drawing.Point(335, 45);
            this.lblRoomPrice.Name = "lblRoomPrice";
            this.lblRoomPrice.Size = new System.Drawing.Size(30, 20);
            this.lblRoomPrice.TabIndex = 2;
            this.lblRoomPrice.Text = "0 đ";
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoomType.Location = new System.Drawing.Point(135, 75);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(84, 20);
            this.lblRoomType.TabIndex = 1;
            this.lblRoomType.Text = "Loại phòng";
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRoomNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblRoomNumber.Location = new System.Drawing.Point(135, 35);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(178, 32);
            this.lblRoomNumber.TabIndex = 0;
            this.lblRoomNumber.Text = "🏨 Phòng 000";
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.Controls.Add(this.btnCancel);
            this.pnlActions.Controls.Add(this.btnConfirmBooking);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 910);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(50, 20, 50, 20);
            this.pnlActions.Size = new System.Drawing.Size(1346, 55);
            this.pnlActions.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(90)))), ((int)(((byte)(75)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(663, 33);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 55);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "❌ HỦY";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnConfirmBooking
            // 
            this.btnConfirmBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btnConfirmBooking.FlatAppearance.BorderSize = 0;
            this.btnConfirmBooking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnConfirmBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmBooking.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirmBooking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.btnConfirmBooking.Location = new System.Drawing.Point(150, 20);
            this.btnConfirmBooking.Name = "btnConfirmBooking";
            this.btnConfirmBooking.Size = new System.Drawing.Size(200, 55);
            this.btnConfirmBooking.TabIndex = 0;
            this.btnConfirmBooking.Text = "✅ XÁC NHẬN ĐẶT PHÒNG";
            this.btnConfirmBooking.UseVisualStyleBackColor = false;
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1346, 1055);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "✨ Đặt Phòng Resort - Hệ Thống Quản Lý";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlBookingDetails.ResumeLayout(false);
            this.pnlPayment.ResumeLayout(false);
            this.pnlPayment.PerformLayout();
            this.gbPaymentSummary.ResumeLayout(false);
            this.gbPaymentSummary.PerformLayout();
            this.gbServices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedServices)).EndInit();
            this.gbBookingDates.ResumeLayout(false);
            this.gbBookingDates.PerformLayout();
            this.gbBookingType.ResumeLayout(false);
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.pnlRoomInfo.ResumeLayout(false);
            this.pnlRoomInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPayment;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox gbPaymentSummary;
        private System.Windows.Forms.Button btnAddDeposit;
        private System.Windows.Forms.Button btnApplyDiscount;
        private System.Windows.Forms.TextBox txtDiscountCode;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtServicesTotal;
        private System.Windows.Forms.TextBox txtRoomTotal;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblServicesTotal;
        private System.Windows.Forms.Label lblRoomTotal;
        private System.Windows.Forms.GroupBox gbBookingDates;
        private System.Windows.Forms.GroupBox gbBookingType;
        private System.Windows.Forms.RadioButton rbBookInAdvance;
        private System.Windows.Forms.RadioButton rbCheckInNow;
        private System.Windows.Forms.Label lblNightsCount;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.TextBox txtChildrenCount;
        private System.Windows.Forms.TextBox txtAdultsCount;
    }
}
