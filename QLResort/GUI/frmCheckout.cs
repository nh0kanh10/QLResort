using QLResort.BUS;
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

        private readonly InvoiceBUS _invoiceBUS = new InvoiceBUS();
        private readonly PaymentBUS _paymentBUS = new PaymentBUS();
        private readonly PaymentTypeBUS _paymentTypeBUS = new PaymentTypeBUS();
        private readonly ServiceDetailBUS _serviceDetailBUS = new ServiceDetailBUS();
        private readonly ServiceBUS _serviceBUS = new ServiceBUS();
        private readonly RoomBUS _roomBUS = new RoomBUS();
        private readonly BookingDetailBUS _bookingDetailBUS = new BookingDetailBUS();
        private readonly BookingBUS _bookingBUS = new BookingBUS();

        private decimal _roomTotal;
        private decimal _serviceTotal;
        private decimal _grandTotal;
        private List<ServiceDetail> _serviceDetails = new List<ServiceDetail>();

        public frmCheckout(Room room, Booking booking, BookingDetail bookingDetail)
        {
            InitializeComponent();

            _room = room;
            _booking = booking;
            _bookingDetail = bookingDetail;

            ApplyStyles();
            LoadPaymentTypes();
            LoadCharges();
        }

        private void ApplyStyles()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleDataGridView(dgvCharges);
            AppTheme.StylePrimaryButton(btnCheckout);
            AppTheme.StyleDangerButton(btnCancel);
            
            lblHeader.Text = $"🧾 Trả phòng - {_room?.SoPhong}";
            lblHeader.ForeColor = AppTheme.PrimaryColor;
            lblTotal.ForeColor = AppTheme.PrimaryColor;
        }

        private void LoadPaymentTypes()
        {
            var result = _paymentTypeBUS.GetPaymentTypes(isActive: true);
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

            var quantity = CalculateUsageQuantity();
            string unitName = _bookingDetail.LoaiThue == "Giờ" ? "giờ" : "đêm";
            
            // Get correct unit price to display
             decimal displayPrice = _bookingDetail.GiaPhong ?? 0;
            if (displayPrice == 0)
            {
                 displayPrice = _bookingDetail.LoaiThue == "Giờ" 
                    ? (_room?.GiaTheoGio ?? 0) 
                    : (_room?.GiaTheoNgay ?? 0);
            }

            dgvCharges.Rows.Add("Tiền phòng", $"{quantity} {unitName}", $"{displayPrice:N0} đ", $"{_roomTotal:N0} đ");

            foreach (var detail in _serviceDetails)
            {
                string serviceName = detail.MaDV;
                var serviceInfo = _serviceBUS.GetServices(maDV: detail.MaDV);
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
            var quantity = CalculateUsageQuantity();
            decimal unitPrice = _bookingDetail.GiaPhong ?? 0;
            
            if (unitPrice == 0)
            {
                if (_bookingDetail.LoaiThue == "Giờ")
                    unitPrice = _room?.GiaTheoGio ?? 0;
                else
                    unitPrice = _room?.GiaTheoNgay ?? 0;
            }

            return unitPrice * quantity;
        }

        private int CalculateUsageQuantity()
        {
            var checkIn = _bookingDetail.NgayDen ?? DateTime.Now;
            var checkOut = DateTime.Now;
            if (_bookingDetail.NgayDi.HasValue && _bookingDetail.NgayDi.Value > checkOut)
            {
                checkOut = _bookingDetail.NgayDi.Value;
            }
            
            TimeSpan duration = checkOut - checkIn;

            if (_bookingDetail.LoaiThue == "Giờ")
            {
                int hours = (int)Math.Ceiling(duration.TotalHours);
                return Math.Max(1, hours);
            }
            else
            {
                int nights = (int)Math.Ceiling(duration.TotalDays);
                return Math.Max(1, nights);
            }
        }

        private List<ServiceDetail> LoadServiceDetails()
        {
            var result = _serviceDetailBUS.GetServiceDetails(maCTDP: _bookingDetail.MaCTDP, isActive: true);
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
                var allInvoices = _invoiceBUS.GetInvoices(maDP: _booking.MaDP);
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
                    var invoiceResult = _invoiceBUS.CreateInvoice(
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
                    
                    var roomUnitPrice = _bookingDetail.GiaPhong ?? 0;
                    if (roomUnitPrice == 0)
                         roomUnitPrice = _bookingDetail.LoaiThue == "Giờ" ? (_room?.GiaTheoGio ?? 0) : (_room?.GiaTheoNgay ?? 0);

                    var quantity = CalculateUsageQuantity();
                    string unitName = _bookingDetail.LoaiThue == "Giờ" ? "giờ" : "đêm";

                    _invoiceBUS.AddInvoiceDetail(invoice.MaHD, $"Tiền phòng {_room?.SoPhong} ({quantity} {unitName})", quantity, roomUnitPrice);

                    foreach (var detail in _serviceDetails)
                    {
                        var serviceName = detail.MaDV;
                        var serviceInfo = _serviceBUS.GetServices(maDV: detail.MaDV);
                        if (serviceInfo.Success && serviceInfo.Data.Count > 0)
                            serviceName = serviceInfo.Data[0].TenDV;

                        _invoiceBUS.AddInvoiceDetail(
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
                        _bookingDetailBUS.UpdateBookingDetail(
                            _bookingDetail.MaCTDP,
                            "Hoàn tất",
                            _bookingDetail.NgayDen,
                            DateTime.Now,
                            _bookingDetail.NguoiLon ?? 2,
                            _bookingDetail.TreEm ?? 0,
                            _bookingDetail.GiaPhong,
                            _grandTotal);

                        _bookingBUS.UpdateBooking(_booking.MaDP, "Hoàn tất", _booking.GhiChu, true);

                        // Cập nhật trạng thái phòng thành "Đang dọn"
                        _roomBUS.UpdateRoom(
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
