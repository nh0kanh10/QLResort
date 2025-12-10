using QLResort.BLL;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmCheckout : Form
    {
        private readonly Room _room;
        private readonly Booking _booking;
        private readonly BookingDetail _bookingDetail;

        private readonly InvoiceBLL _invoiceBLL = new InvoiceBLL();
        private readonly PaymentBLL _paymentBLL = new PaymentBLL();
        private readonly PaymentTypeBLL _paymentTypeBLL = new PaymentTypeBLL();
        private readonly ServiceDetailBLL _serviceDetailBLL = new ServiceDetailBLL();
        private readonly ServiceBLL _serviceBLL = new ServiceBLL();
        private readonly RoomBLL _roomBLL = new RoomBLL();
        private readonly BookingDetailBLL _bookingDetailBLL = new BookingDetailBLL();
        private readonly BookingBLL _bookingBLL = new BookingBLL();

        private readonly DataGridView dgvCharges = new DataGridView();
        private readonly Label lblTotal = new Label();
        private readonly ComboBox cbPaymentType = new ComboBox();
        private readonly Button btnCheckout = new Button();
        private readonly Button btnCancel = new Button();

        private decimal _roomTotal;
        private decimal _serviceTotal;
        private decimal _grandTotal;
        private List<ServiceDetail> _serviceDetails = new List<ServiceDetail>();

        public frmCheckout(Room room, Booking booking, BookingDetail bookingDetail)
        {
            _room = room;
            _booking = booking;
            _bookingDetail = bookingDetail;

            BuildLayout();
            LoadPaymentTypes();
            LoadCharges();
        }

        private void BuildLayout()
        {
            AppTheme.ApplyForm(this);
            Text = "Thanh toán & Trả phòng";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(720, 520);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            var header = new Label
            {
                Text = $"🧾 Trả phòng - {_room?.SoPhong}",
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = AppTheme.PrimaryColor
            };
            Controls.Add(header);

            dgvCharges.Dock = DockStyle.Top;
            dgvCharges.Height = 280;
            dgvCharges.ReadOnly = true;
            dgvCharges.AllowUserToAddRows = false;
            dgvCharges.AllowUserToDeleteRows = false;
            dgvCharges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCharges.RowHeadersVisible = false;
            dgvCharges.Columns.Add("colDescription", "Hạng mục");
            dgvCharges.Columns.Add("colQuantity", "Số lượng");
            dgvCharges.Columns.Add("colUnitPrice", "Đơn giá");
            dgvCharges.Columns.Add("colAmount", "Thành tiền");
            AppTheme.StyleDataGridView(dgvCharges);
            Controls.Add(dgvCharges);

            var panelBottom = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            lblTotal.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTotal.ForeColor = AppTheme.PrimaryColor;
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            lblTotal.Dock = DockStyle.Top;
            lblTotal.Height = 40;
            panelBottom.Controls.Add(lblTotal);

            var paymentPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(0, 10, 0, 10)
            };

            var lblPayment = new Label
            {
                Text = "Loại thanh toán:",
                Width = 150,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            cbPaymentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentType.Width = 250;
            paymentPanel.Controls.Add(lblPayment);
            paymentPanel.Controls.Add(cbPaymentType);
            panelBottom.Controls.Add(paymentPanel);

            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                Height = 60
            };

            btnCheckout.Text = "✅ Hoàn tất thanh toán";
            btnCheckout.Width = 200;
            AppTheme.StylePrimaryButton(btnCheckout);
            btnCheckout.Click += BtnCheckout_Click;
            buttonPanel.Controls.Add(btnCheckout);

            btnCancel.Text = "Hủy";
            btnCancel.Width = 100;
            AppTheme.StyleDangerButton(btnCancel);
            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
            buttonPanel.Controls.Add(btnCancel);

            panelBottom.Controls.Add(buttonPanel);
            Controls.Add(panelBottom);
        }

        private void LoadPaymentTypes()
        {
            var result = _paymentTypeBLL.GetPaymentTypes(isActive: true);
            if (result.Success && result.Data.Count > 0)
            {
                cbPaymentType.DataSource = result.Data;
                cbPaymentType.DisplayMember = "TenLTT";
                cbPaymentType.ValueMember = "MaLTT";
            }
        }

        private void LoadCharges()
        {
            dgvCharges.Rows.Clear();
            _roomTotal = CalculateRoomCharge();
            _serviceDetails = LoadServiceDetails();
            _serviceTotal = _serviceDetails.Sum(d => d.ThanhTien ?? ((d.Gia ?? 0) * (d.SoLuong ?? 1)));
            _grandTotal = _roomTotal + _serviceTotal;

            var nights = CalculateNights();
            dgvCharges.Rows.Add("Tiền phòng", $"{nights} đêm", $"{_room?.GiaTheoNgay?.ToString("N0") ?? "0"} đ", $"{_roomTotal:N0} đ");

            foreach (var detail in _serviceDetails)
            {
                string serviceName = detail.MaDV;
                var serviceInfo = _serviceBLL.GetServices(maDV: detail.MaDV);
                if (serviceInfo.Success && serviceInfo.Data.Count > 0)
                    serviceName = serviceInfo.Data[0].TenDV;

                dgvCharges.Rows.Add(
                    $"Dịch vụ: {serviceName}",
                    detail.SoLuong ?? 1,
                    $"{(detail.Gia ?? 0):N0} đ",
                    $"{(detail.ThanhTien ?? (detail.Gia ?? 0) * (detail.SoLuong ?? 1)):N0} đ");
            }

            lblTotal.Text = $"TỔNG THANH TOÁN: {_grandTotal:N0} đ";
        }

        private decimal CalculateRoomCharge()
        {
            var nights = CalculateNights();
            var unitPrice = _room?.GiaTheoNgay ?? _bookingDetail.GiaPhong ?? 0;
            return unitPrice * nights;
        }

        private int CalculateNights()
        {
            var checkIn = _bookingDetail.NgayDen ?? DateTime.Now;
            var checkOut = DateTime.Now;
            if (_bookingDetail.NgayDi.HasValue && _bookingDetail.NgayDi.Value > checkOut)
            {
                checkOut = _bookingDetail.NgayDi.Value;
            }

            var nights = (int)Math.Ceiling((checkOut - checkIn).TotalDays);
            return Math.Max(1, nights);
        }

        private List<ServiceDetail> LoadServiceDetails()
        {
            var result = _serviceDetailBLL.GetServiceDetails(maCTDP: _bookingDetail.MaCTDP, isActive: true);
            if (result.Success)
                return result.Data;

            return new List<ServiceDetail>();
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            // Mở form thanh toán thay vì thanh toán trực tiếp
            try
            {
                // Kiểm tra xem đã có hóa đơn chưa
                var allInvoices = _invoiceBLL.GetInvoices(maDP: _booking.MaDP);
                string maHD = null;
                
                if (allInvoices.Success && allInvoices.Data.Count > 0)
                {
                    // Tìm hóa đơn chưa thanh toán
                    var unpaidInvoice = allInvoices.Data.FirstOrDefault(i => i.TrangThai == "Chưa TT");
                    if (unpaidInvoice != null)
                    {
                        maHD = unpaidInvoice.MaHD;
                    }
                }
                
                // Nếu chưa có hóa đơn chưa thanh toán, tạo mới
                if (string.IsNullOrEmpty(maHD))
                {
                    var invoiceResult = _invoiceBLL.CreateInvoice(
                        _booking.MaDP,
                        _booking.MaKH,
                        Session_Now.CurrentUser,
                        _room?.MaCN,
                        _grandTotal);

                    if (!invoiceResult.Success)
                    {
                        MessageBox.Show($"Không thể tạo hóa đơn: {invoiceResult.ErrorMessage}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var invoice = invoiceResult.Data;
                    maHD = invoice.MaHD;
                    
                    var roomUnitPrice = _room?.GiaTheoNgay ?? _bookingDetail.GiaPhong ?? 0;
                    var nights = CalculateNights();
                    _invoiceBLL.AddInvoiceDetail(invoice.MaHD, $"Tiền phòng {_room?.SoPhong}", nights, roomUnitPrice);

                    foreach (var detail in _serviceDetails)
                    {
                        var serviceName = detail.MaDV;
                        var serviceInfo = _serviceBLL.GetServices(maDV: detail.MaDV);
                        if (serviceInfo.Success && serviceInfo.Data.Count > 0)
                            serviceName = serviceInfo.Data[0].TenDV;

                        _invoiceBLL.AddInvoiceDetail(
                            invoice.MaHD,
                            $"Dịch vụ: {serviceName}",
                            detail.SoLuong ?? 1,
                            detail.Gia ?? 0);
                    }
                }

                // Đóng form checkout và mở form thanh toán
                this.DialogResult = DialogResult.OK;
                this.Close();

                using (var paymentForm = new frmPayment())
                {
                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        // Sau khi thanh toán thành công, cập nhật trạng thái
                        _bookingDetailBLL.UpdateBookingDetail(
                            _bookingDetail.MaCTDP,
                            "Hoàn tất",
                            _bookingDetail.NgayDen,
                            DateTime.Now,
                            _bookingDetail.NguoiLon ?? 2,
                            _bookingDetail.TreEm ?? 0,
                            _bookingDetail.GiaPhong,
                            _grandTotal);

                        _bookingBLL.UpdateBooking(_booking.MaDP, "Hoàn tất", _booking.GhiChu, true);

                        // Cập nhật trạng thái phòng thành "Đang dọn"
                        _roomBLL.UpdateRoom(
                            _room.MaPhong,
                            _room.MaCN,
                            _room.MaLP,
                            _room.SoPhong,
                            _room.ViTri,
                            "Đang dọn",
                            _room.GhiChu,
                            _room.IsActive);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi trả phòng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // frmCheckout
            // 
            this.ClientSize = new System.Drawing.Size(475, 367);
            this.Name = "frmCheckout";
            this.ResumeLayout(false);

        }
    }
}

