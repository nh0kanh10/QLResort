
namespace GUI_QLResort
{
    partial class frmBooking
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlBookingDetails;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.Panel pnlRoomInfo;

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
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBookingDetails = new System.Windows.Forms.Panel();
            this.btnConfirmBooking = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlPayment = new System.Windows.Forms.Panel();
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
            this.gbBookingDates = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbRentType = new System.Windows.Forms.GroupBox();
            this.nudRentHours = new System.Windows.Forms.NumericUpDown();
            this.rbRentHour = new System.Windows.Forms.RadioButton();
            this.rbRentDay = new System.Windows.Forms.RadioButton();
            this.btnRemoveService = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.lblNightsCount = new System.Windows.Forms.Label();
            this.dgvSelectedServices = new System.Windows.Forms.DataGridView();
            this.colMaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbBookingType = new System.Windows.Forms.GroupBox();
            this.rbBookInAdvance = new System.Windows.Forms.RadioButton();
            this.rbCheckInNow = new System.Windows.Forms.RadioButton();
            this.txtChildrenCount = new System.Windows.Forms.TextBox();
            this.txtAdultsCount = new System.Windows.Forms.TextBox();
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlBookingDetails.SuspendLayout();
            this.pnlPayment.SuspendLayout();
            this.gbPaymentSummary.SuspendLayout();
            this.gbBookingDates.SuspendLayout();
            this.gbRentType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRentHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedServices)).BeginInit();
            this.gbCustomer.SuspendLayout();
            this.gbBookingType.SuspendLayout();
            this.pnlRoomInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlMain.Controls.Add(this.pnlBookingDetails);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 73);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1509, 784);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlBookingDetails
            // 
            this.pnlBookingDetails.AutoScroll = true;
            this.pnlBookingDetails.BackColor = System.Drawing.Color.OldLace;
            this.pnlBookingDetails.Controls.Add(this.btnConfirmBooking);
            this.pnlBookingDetails.Controls.Add(this.btnCancel);
            this.pnlBookingDetails.Controls.Add(this.pnlPayment);
            this.pnlBookingDetails.Controls.Add(this.gbBookingDates);
            this.pnlBookingDetails.Controls.Add(this.gbCustomer);
            this.pnlBookingDetails.Controls.Add(this.pnlRoomInfo);
            this.pnlBookingDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBookingDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlBookingDetails.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBookingDetails.Name = "pnlBookingDetails";
            this.pnlBookingDetails.Padding = new System.Windows.Forms.Padding(38, 20, 38, 20);
            this.pnlBookingDetails.Size = new System.Drawing.Size(1509, 784);
            this.pnlBookingDetails.TabIndex = 0;
            // 
            // btnConfirmBooking
            // 
            this.btnConfirmBooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btnConfirmBooking.FlatAppearance.BorderSize = 0;
            this.btnConfirmBooking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnConfirmBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmBooking.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirmBooking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.btnConfirmBooking.Location = new System.Drawing.Point(40, 697);
            this.btnConfirmBooking.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmBooking.Name = "btnConfirmBooking";
            this.btnConfirmBooking.Size = new System.Drawing.Size(150, 45);
            this.btnConfirmBooking.TabIndex = 0;
            this.btnConfirmBooking.Text = "✅ XÁC NHẬN ĐẶT PHÒNG";
            this.btnConfirmBooking.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(90)))), ((int)(((byte)(75)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Palatino Linotype", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(207, 697);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "❌ HỦY";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // pnlPayment
            // 
            this.pnlPayment.Controls.Add(this.gbPaymentSummary);
            this.pnlPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPayment.Location = new System.Drawing.Point(38, 475);
            this.pnlPayment.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPayment.Name = "pnlPayment";
            this.pnlPayment.Size = new System.Drawing.Size(1433, 179);
            this.pnlPayment.TabIndex = 4;
            // 
            // gbPaymentSummary
            // 
            this.gbPaymentSummary.BackColor = System.Drawing.Color.OldLace;
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
            this.gbPaymentSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPaymentSummary.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gbPaymentSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.gbPaymentSummary.Location = new System.Drawing.Point(0, 0);
            this.gbPaymentSummary.Margin = new System.Windows.Forms.Padding(2);
            this.gbPaymentSummary.Name = "gbPaymentSummary";
            this.gbPaymentSummary.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.gbPaymentSummary.Size = new System.Drawing.Size(1433, 179);
            this.gbPaymentSummary.TabIndex = 0;
            this.gbPaymentSummary.TabStop = false;
            this.gbPaymentSummary.Text = "THANH TOÁN";
            // 
            // btnAddDeposit
            // 
            this.btnAddDeposit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btnAddDeposit.FlatAppearance.BorderSize = 0;
            this.btnAddDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDeposit.Font = new System.Drawing.Font("Palatino Linotype", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddDeposit.ForeColor = System.Drawing.Color.Gold;
            this.btnAddDeposit.Location = new System.Drawing.Point(950, 64);
            this.btnAddDeposit.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddDeposit.Name = "btnAddDeposit";
            this.btnAddDeposit.Size = new System.Drawing.Size(98, 24);
            this.btnAddDeposit.TabIndex = 12;
            this.btnAddDeposit.Text = "THÊM CỌC";
            this.btnAddDeposit.UseVisualStyleBackColor = false;
            // 
            // btnApplyDiscount
            // 
            this.btnApplyDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btnApplyDiscount.FlatAppearance.BorderSize = 0;
            this.btnApplyDiscount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(105)))), ((int)(((byte)(195)))));
            this.btnApplyDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyDiscount.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnApplyDiscount.ForeColor = System.Drawing.Color.Gold;
            this.btnApplyDiscount.Location = new System.Drawing.Point(950, 26);
            this.btnApplyDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.btnApplyDiscount.Name = "btnApplyDiscount";
            this.btnApplyDiscount.Size = new System.Drawing.Size(98, 25);
            this.btnApplyDiscount.TabIndex = 11;
            this.btnApplyDiscount.Text = " ÁP DỤNG";
            this.btnApplyDiscount.UseVisualStyleBackColor = false;
            // 
            // txtDiscountCode
            // 
            this.txtDiscountCode.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.txtDiscountCode.Location = new System.Drawing.Point(855, 26);
            this.txtDiscountCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiscountCode.Name = "txtDiscountCode";
            this.txtDiscountCode.Size = new System.Drawing.Size(91, 24);
            this.txtDiscountCode.TabIndex = 10;
            this.txtDiscountCode.Text = "Mã giảm giá";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.txtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrandTotal.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold);
            this.txtGrandTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.txtGrandTotal.Location = new System.Drawing.Point(453, 123);
            this.txtGrandTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(380, 33);
            this.txtGrandTotal.TabIndex = 9;
            this.txtGrandTotal.Text = "0";
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDeposit
            // 
            this.txtDeposit.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.txtDeposit.Location = new System.Drawing.Point(691, 66);
            this.txtDeposit.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.ReadOnly = true;
            this.txtDeposit.Size = new System.Drawing.Size(142, 24);
            this.txtDeposit.TabIndex = 8;
            this.txtDeposit.Text = "0";
            this.txtDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.txtDiscount.Location = new System.Drawing.Point(691, 28);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(142, 24);
            this.txtDiscount.TabIndex = 7;
            this.txtDiscount.Text = "0";
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtServicesTotal
            // 
            this.txtServicesTotal.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.txtServicesTotal.Location = new System.Drawing.Point(412, 71);
            this.txtServicesTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtServicesTotal.Name = "txtServicesTotal";
            this.txtServicesTotal.ReadOnly = true;
            this.txtServicesTotal.Size = new System.Drawing.Size(176, 24);
            this.txtServicesTotal.TabIndex = 6;
            this.txtServicesTotal.Text = "0";
            this.txtServicesTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRoomTotal
            // 
            this.txtRoomTotal.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.txtRoomTotal.Location = new System.Drawing.Point(412, 26);
            this.txtRoomTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txtRoomTotal.Name = "txtRoomTotal";
            this.txtRoomTotal.ReadOnly = true;
            this.txtRoomTotal.Size = new System.Drawing.Size(176, 24);
            this.txtRoomTotal.TabIndex = 5;
            this.txtRoomTotal.Text = "0";
            this.txtRoomTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.lblGrandTotal.Location = new System.Drawing.Point(340, 136);
            this.lblGrandTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(108, 19);
            this.lblGrandTotal.TabIndex = 4;
            this.lblGrandTotal.Text = "TỔNG CỘNG:";
            // 
            // lblDeposit
            // 
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblDeposit.Location = new System.Drawing.Point(628, 71);
            this.lblDeposit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(57, 17);
            this.lblDeposit.TabIndex = 3;
            this.lblDeposit.Text = "Tiền cọc:";
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblDiscount.Location = new System.Drawing.Point(628, 31);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(61, 17);
            this.lblDiscount.TabIndex = 2;
            this.lblDiscount.Text = "Giảm giá:";
            // 
            // lblServicesTotal
            // 
            this.lblServicesTotal.AutoSize = true;
            this.lblServicesTotal.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblServicesTotal.Location = new System.Drawing.Point(340, 74);
            this.lblServicesTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServicesTotal.Name = "lblServicesTotal";
            this.lblServicesTotal.Size = new System.Drawing.Size(53, 17);
            this.lblServicesTotal.TabIndex = 1;
            this.lblServicesTotal.Text = "Dịch vụ:";
            // 
            // lblRoomTotal
            // 
            this.lblRoomTotal.AutoSize = true;
            this.lblRoomTotal.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblRoomTotal.Location = new System.Drawing.Point(340, 29);
            this.lblRoomTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomTotal.Name = "lblRoomTotal";
            this.lblRoomTotal.Size = new System.Drawing.Size(73, 17);
            this.lblRoomTotal.TabIndex = 0;
            this.lblRoomTotal.Text = "Tiền phòng:";
            // 
            // gbBookingDates
            // 
            this.gbBookingDates.BackColor = System.Drawing.Color.OldLace;
            this.gbBookingDates.Controls.Add(this.textBox1);
            this.gbBookingDates.Controls.Add(this.gbRentType);
            this.gbBookingDates.Controls.Add(this.btnRemoveService);
            this.gbBookingDates.Controls.Add(this.btnAddService);
            this.gbBookingDates.Controls.Add(this.lblNightsCount);
            this.gbBookingDates.Controls.Add(this.dgvSelectedServices);
            this.gbBookingDates.Controls.Add(this.lblCheckOut);
            this.gbBookingDates.Controls.Add(this.lblCheckIn);
            this.gbBookingDates.Controls.Add(this.dtpCheckIn);
            this.gbBookingDates.Controls.Add(this.dtpCheckOut);
            this.gbBookingDates.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBookingDates.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gbBookingDates.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.gbBookingDates.Location = new System.Drawing.Point(38, 268);
            this.gbBookingDates.Margin = new System.Windows.Forms.Padding(2);
            this.gbBookingDates.Name = "gbBookingDates";
            this.gbBookingDates.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.gbBookingDates.Size = new System.Drawing.Size(1433, 207);
            this.gbBookingDates.TabIndex = 2;
            this.gbBookingDates.TabStop = false;
            this.gbBookingDates.Text = "THỜI GIAN ĐẶT PHÒNG - DỊCH VỤ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(412, 155);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(76, 25);
            this.textBox1.TabIndex = 1;
            // 
            // gbRentType
            // 
            this.gbRentType.BackColor = System.Drawing.Color.OldLace;
            this.gbRentType.Controls.Add(this.nudRentHours);
            this.gbRentType.Controls.Add(this.rbRentHour);
            this.gbRentType.Controls.Add(this.rbRentDay);
            this.gbRentType.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gbRentType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.gbRentType.Location = new System.Drawing.Point(12, 118);
            this.gbRentType.Name = "gbRentType";
            this.gbRentType.Size = new System.Drawing.Size(280, 60);
            this.gbRentType.TabIndex = 1;
            this.gbRentType.TabStop = false;
            this.gbRentType.Text = "Loại hình thuê";
            // 
            // nudRentHours
            // 
            this.nudRentHours.Location = new System.Drawing.Point(195, 25);
            this.nudRentHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudRentHours.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRentHours.Name = "nudRentHours";
            this.nudRentHours.Size = new System.Drawing.Size(50, 25);
            this.nudRentHours.TabIndex = 2;
            this.nudRentHours.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRentHours.Visible = false;
            this.nudRentHours.ValueChanged += new System.EventHandler(this.NudRentHours_ValueChanged);
            // 
            // rbRentHour
            // 
            this.rbRentHour.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.rbRentHour.Location = new System.Drawing.Point(110, 25);
            this.rbRentHour.Name = "rbRentHour";
            this.rbRentHour.Size = new System.Drawing.Size(80, 24);
            this.rbRentHour.TabIndex = 1;
            this.rbRentHour.Text = "Theo Giờ";
            this.rbRentHour.CheckedChanged += new System.EventHandler(this.RentType_CheckedChanged);
            // 
            // rbRentDay
            // 
            this.rbRentDay.Checked = true;
            this.rbRentDay.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.rbRentDay.Location = new System.Drawing.Point(15, 25);
            this.rbRentDay.Name = "rbRentDay";
            this.rbRentDay.Size = new System.Drawing.Size(90, 24);
            this.rbRentDay.TabIndex = 0;
            this.rbRentDay.TabStop = true;
            this.rbRentDay.Text = "Theo Ngày";
            // 
            // btnRemoveService
            // 
            this.btnRemoveService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemoveService.FlatAppearance.BorderSize = 0;
            this.btnRemoveService.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(90)))), ((int)(((byte)(75)))));
            this.btnRemoveService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveService.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveService.ForeColor = System.Drawing.Color.White;
            this.btnRemoveService.Location = new System.Drawing.Point(1318, 92);
            this.btnRemoveService.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveService.Name = "btnRemoveService";
            this.btnRemoveService.Size = new System.Drawing.Size(98, 28);
            this.btnRemoveService.TabIndex = 2;
            this.btnRemoveService.Text = "❌ XÓA";
            this.btnRemoveService.UseVisualStyleBackColor = false;
            // 
            // btnAddService
            // 
            this.btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btnAddService.FlatAppearance.BorderSize = 0;
            this.btnAddService.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnAddService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddService.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddService.ForeColor = System.Drawing.Color.White;
            this.btnAddService.Location = new System.Drawing.Point(1318, 23);
            this.btnAddService.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(98, 28);
            this.btnAddService.TabIndex = 1;
            this.btnAddService.Text = "➕ THÊM";
            this.btnAddService.UseVisualStyleBackColor = false;
            // 
            // lblNightsCount
            // 
            this.lblNightsCount.AutoSize = true;
            this.lblNightsCount.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblNightsCount.Location = new System.Drawing.Point(273, 49);
            this.lblNightsCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNightsCount.Name = "lblNightsCount";
            this.lblNightsCount.Size = new System.Drawing.Size(42, 17);
            this.lblNightsCount.TabIndex = 4;
            this.lblNightsCount.Text = "0 đêm";
            // 
            // dgvSelectedServices
            // 
            this.dgvSelectedServices.AllowUserToAddRows = false;
            this.dgvSelectedServices.AllowUserToDeleteRows = false;
            this.dgvSelectedServices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSelectedServices.BackgroundColor = System.Drawing.Color.OldLace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectedServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelectedServices.ColumnHeadersHeight = 40;
            this.dgvSelectedServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaDV,
            this.colTenDV,
            this.colLoaiDV,
            this.colSoLuong,
            this.colGia,
            this.colThanhTien});
            this.dgvSelectedServices.Location = new System.Drawing.Point(633, 24);
            this.dgvSelectedServices.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSelectedServices.Name = "dgvSelectedServices";
            this.dgvSelectedServices.ReadOnly = true;
            this.dgvSelectedServices.RowHeadersWidth = 51;
            this.dgvSelectedServices.RowTemplate.Height = 35;
            this.dgvSelectedServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedServices.Size = new System.Drawing.Size(665, 169);
            this.dgvSelectedServices.TabIndex = 0;
            // 
            // colMaDV
            // 
            this.colMaDV.HeaderText = "Mã DV";
            this.colMaDV.Name = "colMaDV";
            this.colMaDV.ReadOnly = true;
            this.colMaDV.Width = 80;
            // 
            // colTenDV
            // 
            this.colTenDV.HeaderText = "Tên dịch vụ";
            this.colTenDV.Name = "colTenDV";
            this.colTenDV.ReadOnly = true;
            this.colTenDV.Width = 200;
            // 
            // colLoaiDV
            // 
            this.colLoaiDV.HeaderText = "Loại";
            this.colLoaiDV.Name = "colLoaiDV";
            this.colLoaiDV.ReadOnly = true;
            this.colLoaiDV.Width = 120;
            // 
            // colSoLuong
            // 
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            this.colSoLuong.Width = 60;
            // 
            // colGia
            // 
            this.colGia.HeaderText = "Đơn giá";
            this.colGia.Name = "colGia";
            this.colGia.ReadOnly = true;
            this.colGia.Width = 120;
            // 
            // colThanhTien
            // 
            this.colThanhTien.HeaderText = "Thành tiền";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            this.colThanhTien.Width = 150;
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblCheckOut.Location = new System.Drawing.Point(9, 72);
            this.lblCheckOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(60, 17);
            this.lblCheckOut.TabIndex = 3;
            this.lblCheckOut.Text = "Ngày trả:";
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblCheckIn.Location = new System.Drawing.Point(9, 30);
            this.lblCheckIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(72, 17);
            this.lblCheckIn.TabIndex = 2;
            this.lblCheckIn.Text = "Ngày nhận:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckIn.Location = new System.Drawing.Point(87, 24);
            this.dtpCheckIn.Margin = new System.Windows.Forms.Padding(2);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(151, 24);
            this.dtpCheckIn.TabIndex = 0;
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckOut.Location = new System.Drawing.Point(87, 64);
            this.dtpCheckOut.Margin = new System.Windows.Forms.Padding(2);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(151, 24);
            this.dtpCheckOut.TabIndex = 1;
            // 
            // gbCustomer
            // 
            this.gbCustomer.BackColor = System.Drawing.Color.OldLace;
            this.gbCustomer.Controls.Add(this.label2);
            this.gbCustomer.Controls.Add(this.label1);
            this.gbCustomer.Controls.Add(this.gbBookingType);
            this.gbCustomer.Controls.Add(this.txtChildrenCount);
            this.gbCustomer.Controls.Add(this.txtAdultsCount);
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
            this.gbCustomer.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.gbCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.gbCustomer.Location = new System.Drawing.Point(38, 118);
            this.gbCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.gbCustomer.Size = new System.Drawing.Size(1433, 150);
            this.gbCustomer.TabIndex = 1;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "THÔNG TIN KHÁCH HÀNG - THỜI GIAN ĐẶT PHÒNG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.label2.Location = new System.Drawing.Point(1145, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Số trẻ em";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.label1.Location = new System.Drawing.Point(1145, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số người lớn";
            // 
            // gbBookingType
            // 
            this.gbBookingType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBookingType.BackColor = System.Drawing.Color.OldLace;
            this.gbBookingType.Controls.Add(this.rbBookInAdvance);
            this.gbBookingType.Controls.Add(this.rbCheckInNow);
            this.gbBookingType.Location = new System.Drawing.Point(859, 30);
            this.gbBookingType.Margin = new System.Windows.Forms.Padding(2);
            this.gbBookingType.Name = "gbBookingType";
            this.gbBookingType.Padding = new System.Windows.Forms.Padding(2);
            this.gbBookingType.Size = new System.Drawing.Size(245, 60);
            this.gbBookingType.TabIndex = 12;
            this.gbBookingType.TabStop = false;
            this.gbBookingType.Text = "Loại đặt phòng";
            // 
            // rbBookInAdvance
            // 
            this.rbBookInAdvance.Checked = true;
            this.rbBookInAdvance.Location = new System.Drawing.Point(15, 20);
            this.rbBookInAdvance.Margin = new System.Windows.Forms.Padding(2);
            this.rbBookInAdvance.Name = "rbBookInAdvance";
            this.rbBookInAdvance.Size = new System.Drawing.Size(93, 30);
            this.rbBookInAdvance.TabIndex = 0;
            this.rbBookInAdvance.TabStop = true;
            this.rbBookInAdvance.Text = "Đặt trước";
            // 
            // rbCheckInNow
            // 
            this.rbCheckInNow.Location = new System.Drawing.Point(112, 15);
            this.rbCheckInNow.Margin = new System.Windows.Forms.Padding(2);
            this.rbCheckInNow.Name = "rbCheckInNow";
            this.rbCheckInNow.Size = new System.Drawing.Size(111, 40);
            this.rbCheckInNow.TabIndex = 1;
            this.rbCheckInNow.Text = "Check-in";
            // 
            // txtChildrenCount
            // 
            this.txtChildrenCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChildrenCount.Location = new System.Drawing.Point(1241, 67);
            this.txtChildrenCount.Margin = new System.Windows.Forms.Padding(2);
            this.txtChildrenCount.Name = "txtChildrenCount";
            this.txtChildrenCount.Size = new System.Drawing.Size(105, 25);
            this.txtChildrenCount.TabIndex = 6;
            // 
            // txtAdultsCount
            // 
            this.txtAdultsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdultsCount.Location = new System.Drawing.Point(1241, 30);
            this.txtAdultsCount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAdultsCount.Name = "txtAdultsCount";
            this.txtAdultsCount.Size = new System.Drawing.Size(105, 25);
            this.txtAdultsCount.TabIndex = 5;
            // 
            // lblCustomerEmail
            // 
            this.lblCustomerEmail.AutoSize = true;
            this.lblCustomerEmail.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblCustomerEmail.Location = new System.Drawing.Point(472, 86);
            this.lblCustomerEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerEmail.Name = "lblCustomerEmail";
            this.lblCustomerEmail.Size = new System.Drawing.Size(42, 17);
            this.lblCustomerEmail.TabIndex = 6;
            this.lblCustomerEmail.Text = "Email:";
            // 
            // lblCustomerPhone
            // 
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblCustomerPhone.Location = new System.Drawing.Point(272, 85);
            this.lblCustomerPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerPhone.Name = "lblCustomerPhone";
            this.lblCustomerPhone.Size = new System.Drawing.Size(34, 17);
            this.lblCustomerPhone.TabIndex = 5;
            this.lblCustomerPhone.Text = "SĐT:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblCustomerName.Location = new System.Drawing.Point(18, 84);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(48, 17);
            this.lblCustomerName.TabIndex = 4;
            this.lblCustomerName.Text = "Họ tên:";
            // 
            // lblIDType
            // 
            this.lblIDType.AutoSize = true;
            this.lblIDType.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblIDType.Location = new System.Drawing.Point(272, 28);
            this.lblIDType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIDType.Name = "lblIDType";
            this.lblIDType.Size = new System.Drawing.Size(76, 17);
            this.lblIDType.TabIndex = 8;
            this.lblIDType.Text = "Loại giấy tờ:";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblCustomerID.Location = new System.Drawing.Point(18, 25);
            this.lblCustomerID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(82, 17);
            this.lblCustomerID.TabIndex = 7;
            this.lblCustomerID.Text = "Mã căn cước:";
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.btnSearchCustomer.FlatAppearance.BorderSize = 0;
            this.btnSearchCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCustomer.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.Gold;
            this.btnSearchCustomer.Location = new System.Drawing.Point(490, 50);
            this.btnSearchCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(98, 28);
            this.btnSearchCustomer.TabIndex = 11;
            this.btnSearchCustomer.Text = "TÌM KIẾM";
            this.btnSearchCustomer.UseVisualStyleBackColor = false;
            // 
            // cbIDType
            // 
            this.cbIDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIDType.Font = new System.Drawing.Font("Palatino Linotype", 9.5F);
            this.cbIDType.FormattingEnabled = true;
            this.cbIDType.Items.AddRange(new object[] {
            "CCCD",
            "CMND",
            "Passport"});
            this.cbIDType.Location = new System.Drawing.Point(270, 53);
            this.cbIDType.Margin = new System.Windows.Forms.Padding(2);
            this.cbIDType.Name = "cbIDType";
            this.cbIDType.Size = new System.Drawing.Size(188, 26);
            this.cbIDType.TabIndex = 10;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Font = new System.Drawing.Font("Palatino Linotype", 9.5F);
            this.txtCustomerID.Location = new System.Drawing.Point(17, 54);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(230, 25);
            this.txtCustomerID.TabIndex = 9;
            // 
            // txtCustomerEmail
            // 
            this.txtCustomerEmail.Font = new System.Drawing.Font("Palatino Linotype", 9.5F);
            this.txtCustomerEmail.Location = new System.Drawing.Point(475, 111);
            this.txtCustomerEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerEmail.Name = "txtCustomerEmail";
            this.txtCustomerEmail.ReadOnly = true;
            this.txtCustomerEmail.Size = new System.Drawing.Size(188, 25);
            this.txtCustomerEmail.TabIndex = 2;
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Font = new System.Drawing.Font("Palatino Linotype", 9.5F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(270, 111);
            this.txtCustomerPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.ReadOnly = true;
            this.txtCustomerPhone.Size = new System.Drawing.Size(188, 25);
            this.txtCustomerPhone.TabIndex = 1;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Palatino Linotype", 9.5F);
            this.txtCustomerName.Location = new System.Drawing.Point(12, 111);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(230, 25);
            this.txtCustomerName.TabIndex = 0;
            // 
            // pnlRoomInfo
            // 
            this.pnlRoomInfo.BackColor = System.Drawing.Color.OldLace;
            this.pnlRoomInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRoomInfo.Controls.Add(this.lblRoomCapacity);
            this.pnlRoomInfo.Controls.Add(this.lblCapacity);
            this.pnlRoomInfo.Controls.Add(this.picRoom);
            this.pnlRoomInfo.Controls.Add(this.lblRoomStatus);
            this.pnlRoomInfo.Controls.Add(this.lblRoomPrice);
            this.pnlRoomInfo.Controls.Add(this.lblRoomType);
            this.pnlRoomInfo.Controls.Add(this.lblRoomNumber);
            this.pnlRoomInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRoomInfo.Location = new System.Drawing.Point(38, 20);
            this.pnlRoomInfo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRoomInfo.Name = "pnlRoomInfo";
            this.pnlRoomInfo.Padding = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.pnlRoomInfo.Size = new System.Drawing.Size(1433, 98);
            this.pnlRoomInfo.TabIndex = 0;
            // 
            // lblRoomCapacity
            // 
            this.lblRoomCapacity.AutoSize = true;
            this.lblRoomCapacity.Font = new System.Drawing.Font("Palatino Linotype", 10F);
            this.lblRoomCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.lblRoomCapacity.Location = new System.Drawing.Point(364, 57);
            this.lblRoomCapacity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomCapacity.Name = "lblRoomCapacity";
            this.lblRoomCapacity.Size = new System.Drawing.Size(16, 19);
            this.lblRoomCapacity.TabIndex = 6;
            this.lblRoomCapacity.Text = "0";
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold);
            this.lblCapacity.Location = new System.Drawing.Point(364, 37);
            this.lblCapacity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(62, 17);
            this.lblCapacity.TabIndex = 5;
            this.lblCapacity.Text = "Sức chứa:";
            // 
            // picRoom
            // 
            this.picRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRoom.Location = new System.Drawing.Point(11, 12);
            this.picRoom.Margin = new System.Windows.Forms.Padding(2);
            this.picRoom.Name = "picRoom";
            this.picRoom.Size = new System.Drawing.Size(68, 74);
            this.picRoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRoom.TabIndex = 4;
            this.picRoom.TabStop = false;
            // 
            // lblRoomStatus
            // 
            this.lblRoomStatus.AutoSize = true;
            this.lblRoomStatus.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblRoomStatus.Location = new System.Drawing.Point(251, 61);
            this.lblRoomStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomStatus.Name = "lblRoomStatus";
            this.lblRoomStatus.Size = new System.Drawing.Size(65, 17);
            this.lblRoomStatus.TabIndex = 3;
            this.lblRoomStatus.Text = "Trạng thái";
            // 
            // lblRoomPrice
            // 
            this.lblRoomPrice.AutoSize = true;
            this.lblRoomPrice.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblRoomPrice.Location = new System.Drawing.Point(251, 37);
            this.lblRoomPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomPrice.Name = "lblRoomPrice";
            this.lblRoomPrice.Size = new System.Drawing.Size(24, 17);
            this.lblRoomPrice.TabIndex = 2;
            this.lblRoomPrice.Text = "0 đ";
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lblRoomType.Location = new System.Drawing.Point(102, 61);
            this.lblRoomType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(70, 17);
            this.lblRoomType.TabIndex = 1;
            this.lblRoomType.Text = "Loại phòng";
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Palatino Linotype", 14F, System.Drawing.FontStyle.Bold);
            this.lblRoomNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.lblRoomNumber.Location = new System.Drawing.Point(101, 28);
            this.lblRoomNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(105, 26);
            this.lblRoomNumber.TabIndex = 0;
            this.lblRoomNumber.Text = "Phòng 000";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(47)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1509, 73);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Palatino Linotype", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(343, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐẶT PHÒNG RESORT";
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1509, 857);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "✨ Đặt Phòng Resort - Hệ Thống Quản Lý";
            this.pnlMain.ResumeLayout(false);
            this.pnlBookingDetails.ResumeLayout(false);
            this.pnlPayment.ResumeLayout(false);
            this.gbPaymentSummary.ResumeLayout(false);
            this.gbPaymentSummary.PerformLayout();
            this.gbBookingDates.ResumeLayout(false);
            this.gbBookingDates.PerformLayout();
            this.gbRentType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudRentHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedServices)).EndInit();
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.gbBookingType.ResumeLayout(false);
            this.pnlRoomInfo.ResumeLayout(false);
            this.pnlRoomInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRoom)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
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
        private System.Windows.Forms.Label lblNightsCount;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.TextBox txtChildrenCount;
        private System.Windows.Forms.TextBox txtAdultsCount;
        private System.Windows.Forms.GroupBox gbBookingType;
        private System.Windows.Forms.RadioButton rbBookInAdvance;
        private System.Windows.Forms.RadioButton rbCheckInNow;
        private System.Windows.Forms.GroupBox gbRentType;
        private System.Windows.Forms.RadioButton rbRentDay;
        private System.Windows.Forms.RadioButton rbRentHour;
        private System.Windows.Forms.NumericUpDown nudRentHours;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
