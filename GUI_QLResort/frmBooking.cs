using BUS_QLResort;
using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using GUI_QLResort.Styles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Transactions;

/// <summary>
/// Form quản lý đặt phòng trong hệ thống
/// Cho phép tạo mới, cập nhật và xem chi tiết đơn đặt phòng
/// Xử lý các nghiệp vụ đặt phòng, dịch vụ đi kèm và thanh toán
/// </summary>

namespace GUI_QLResort
{
    public partial class frmBooking : AppBaseForm
    {
        // Khai báo các đối tượng BUS để tương tác với cơ sở dữ liệu
        private readonly RoomBUS _roomBUS;
        private readonly ServiceBUS _serviceBUS;
        private readonly BookingBUS _bookingBUS;
        private readonly BookingDetailBUS _bookingDetailBUS;
        private readonly ServiceDetailBUS _serviceDetailBUS;
        private readonly GuestBUS _guestBUS;
        private readonly PromotionBUS _promotionBUS = new PromotionBUS();
        private readonly VoucherBUS _voucherBUS = new VoucherBUS();
        private readonly DepositBUS _depositBUS = new DepositBUS();

        // Biến lưu trữ dữ liệu tạm thời
        private List<ServiceUsage> _selectedServices; // Danh sách dịch vụ đã chọn
        private Room _selectedRoom;                   // Phòng được chọn
        private GuestM _selectedGuest;               // Khách hàng đặt phòng
        private Booking _currentBooking;              // Đơn đặt phòng hiện tại
        private BookingDetail _currentBookingDetail;  // Chi tiết đơn đặt phòng
        private BookingFormMode _formMode;            // Chế độ form (tạo mới/chỉnh sửa)
        private readonly ToolTip _serviceToolTip = new ToolTip(); // Tooltip hiển thị thông tin dịch vụ

        // Biến tính toán
        private decimal _roomTotal = 0;     // Tổng tiền phòng
        private decimal _servicesTotal = 0; // Tổng tiền dịch vụ
        private decimal _discount = 0;      // Giảm giá
        private Voucher _appliedVoucher = null; // Lưu thông tin voucher đang được áp dụng
        private decimal _deposit = 0;       // Tiền đặt cọc
        private int _nightsCount = 0;       // Số đêm ở
        
        /// <summary>
        /// Khởi tạo form đặt phòng
        /// </summary>
        /// <param name="room">Thông tin phòng (nếu chọn từ form khác)</param>
        /// <param name="existingBooking">Thông tin đơn đặt phòng (trường hợp chỉnh sửa)</param>
        /// <param name="existingDetail">Chi tiết đơn đặt phòng (trường hợp chỉnh sửa)</param>
        public frmBooking(Room room = null, Booking existingBooking = null, BookingDetail existingDetail = null)
        {
            InitializeComponent();
            
            // Áp dụng giao diện
            AppTheme.ApplyForm(this);
            AppTheme.StyleDataGridView(dgvSelectedServices);

            // Khởi tạo các đối tượng BUS
            _roomBUS = new RoomBUS();
            _serviceBUS = new ServiceBUS();
            _bookingBUS = new BookingBUS();
            _bookingDetailBUS = new BookingDetailBUS();
            _serviceDetailBUS = new ServiceDetailBUS();
            _guestBUS = new GuestBUS();

            _selectedServices = new List<ServiceUsage>();
            _selectedRoom = room;
            _currentBooking = existingBooking;
            _currentBookingDetail = existingDetail;
            _formMode = existingBooking == null ? BookingFormMode.Create : BookingFormMode.Update;

            InitializeData();
            SetupEventHandlers();
        }


        private void RentType_CheckedChanged(object sender, EventArgs e)
        {
             nudRentHours.Visible = rbRentHour.Checked;
             CalculateTotals();
        }

        private void NudRentHours_ValueChanged(object sender, EventArgs e)
        {
            if (rbRentHour.Checked)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.AddHours((double)nudRentHours.Value);
                // CalculateTotals will be triggered by dtpCheckOut value change or we should call it
                CalculateTotals();
            }
        }

        private void InitializeData()
        {
            lblTitle.Text = _formMode == BookingFormMode.Create
                ? "✨ ĐẶT PHÒNG / CHECK-IN RESORT"
                : "🛠 CẬP NHẬT ĐẶT PHÒNG";

            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);

            cbIDType.SelectedIndex = 0;
            btnConfirmBooking.Text = _formMode == BookingFormMode.Create ? "XÁC NHẬN ĐẶT / CHECK-IN" : "LƯU CẬP NHẬT";
            
            // Thêm RadioButton để chọn giữa đặt trước và check-in trực tiếp
            if (_formMode == BookingFormMode.Create)
            {
                // Nếu phòng đang trống, mặc định là check-in trực tiếp
                if (_selectedRoom != null && _selectedRoom.TrangThai == "Trống")
                {
                    rbCheckInNow.Checked = true;
                    rbBookInAdvance.Checked = false;
                }
                else
                {
                    rbBookInAdvance.Checked = true;
                    rbCheckInNow.Checked = false;
                }
            }

            if (_formMode == BookingFormMode.Update)
            {
                LoadExistingBookingData();
            }
            else if (_selectedRoom != null)
            {
                UpdateRoomInfo();
            }
        }

        private void LoadExistingBookingData()
        {
            if (_currentBooking == null && _currentBookingDetail == null)
                return;

            if (_currentBookingDetail == null && _currentBooking != null)
            {
                var detailResult = _bookingDetailBUS.GetBookingDetails(maDP: _currentBooking.MaDP, isActive: true);
                if (detailResult.Success && detailResult.Data.Count > 0)
                {
                    _currentBookingDetail = detailResult.Data.Find(d => d.TrangThai != null && d.TrangThai != "Hoàn tất")
                        ?? detailResult.Data[0];
                }
            }

            if (_currentBooking == null && _currentBookingDetail != null)
            {
                var bookingResult = _bookingBUS.GetBookings(maDP: _currentBookingDetail.MaDP);
                if (bookingResult.Success && bookingResult.Data.Count > 0)
                {
                    _currentBooking = bookingResult.Data[0];
                }
            }

            if (_currentBooking == null || _currentBookingDetail == null) return;

            if (_selectedRoom == null && !string.IsNullOrEmpty(_currentBookingDetail.MaPhong))
            {
                var roomResult = _roomBUS.GetRooms(maPhong: _currentBookingDetail.MaPhong);
                if (roomResult.Success && roomResult.Data.Count > 0)
                {
                    _selectedRoom = roomResult.Data[0];
                }
            }

            UpdateRoomInfo();

            dtpCheckIn.Value = _currentBookingDetail.NgayDen ?? DateTime.Now;
            dtpCheckOut.Value = _currentBookingDetail.NgayDi ?? dtpCheckIn.Value.AddDays(1);

            if (_currentBooking.TrangThai == "Đang sử dụng" || (_currentBookingDetail != null && _currentBookingDetail.TrangThai == "Đang sử dụng"))
            {
                rbCheckInNow.Checked = true;
                rbBookInAdvance.Checked = false;
            }
            else
            {
                rbCheckInNow.Checked = false;
                rbBookInAdvance.Checked = true;
            }

            if (!string.IsNullOrEmpty(_currentBooking.MaKH))
            {
                var guestResult = _guestBUS.GetGuests(maKH: _currentBooking.MaKH);
                if (guestResult.Success && guestResult.Data.Count > 0)
                {
                    _selectedGuest = guestResult.Data[0];
                    txtCustomerName.Text = _selectedGuest.HoTen;
                    txtCustomerPhone.Text = _selectedGuest.SDT;
                    txtCustomerEmail.Text = _selectedGuest.Email;
                    txtCustomerID.Text = _selectedGuest.IDNumber;
                    if (!string.IsNullOrEmpty(_selectedGuest.IDType))
                    {
                        cbIDType.SelectedItem = _selectedGuest.IDType;
                    }
                }
            }

            var serviceDetailResult = _serviceDetailBUS.GetServiceDetails(maCTDP: _currentBookingDetail.MaCTDP, isActive: true);
            if (serviceDetailResult.Success)
            {
                _selectedServices.Clear();
                foreach (var detail in serviceDetailResult.Data)
                {
                    Service serviceInfo = null;
                    if (!string.IsNullOrEmpty(detail.MaDV))
                    {
                        var serviceLookup = _serviceBUS.GetServices(maDV: detail.MaDV);
                        if (serviceLookup.Success && serviceLookup.Data.Count > 0)
                        {
                            serviceInfo = serviceLookup.Data[0];
                        }
                    }

                    if (serviceInfo != null)
                    {
                        _selectedServices.Add(new ServiceUsage
                        {
                            Service = serviceInfo,
                            Quantity = detail.SoLuong ?? 1,
                            UnitPrice = detail.Gia ?? 0,
                            PaidByPoint = (detail.Gia ?? 0) == 0
                        });
                    }
                }
            }

            RefreshSelectedServicesGrid();
        }

        private void SetupEventHandlers()
        {
            dtpCheckIn.ValueChanged += DatePicker_ValueChanged;
            dtpCheckOut.ValueChanged += DatePicker_ValueChanged;
            btnSearchCustomer.Click += BtnSearchCustomer_Click;
            btnAddService.Click += BtnAddService_Click;
            btnRemoveService.Click += BtnRemoveService_Click;
            btnApplyDiscount.Click += BtnApplyDiscount_Click;
            btnAddDeposit.Click += BtnAddDeposit_Click;
            btnConfirmBooking.Click += BtnConfirmBooking_Click;
            btnCancel.Click += BtnCancel_Click;
            dgvSelectedServices.SelectionChanged += DgvSelectedServices_SelectionChanged;
            dgvSelectedServices.CellClick += DgvSelectedServices_CellClick;
            dgvSelectedServices.CellEndEdit += DgvSelectedServices_CellEndEdit;
        }


        private void RefreshSelectedServicesGrid()
        {


            dgvSelectedServices.Rows.Clear();

            foreach (var usage in _selectedServices)
            {
                dgvSelectedServices.Rows.Add(
                    usage.ServiceCode,
                    usage.ServiceName,
                    usage.Service?.LoaiDV,
                    usage.Quantity,
                    usage.UnitPrice.ToString("N0") + " đ",
                    usage.Total.ToString("N0") + " đ"
                );
            }

            CalculateTotals();
        }

        private void CalculateTotals()
        {
            if (_selectedRoom == null) return;

            decimal unitPrice = 0;
            string durationText = "";
            TimeSpan duration = dtpCheckOut.Value.Date - dtpCheckIn.Value.Date;

            if (rbRentHour != null && rbRentHour.Checked)
            {
                // Tính theo giờ
                TimeSpan exactDuration = dtpCheckOut.Value - dtpCheckIn.Value;
                _nightsCount = (int)Math.Ceiling(exactDuration.TotalHours);
                _nightsCount = Math.Max(1, _nightsCount); // Luôn ít nhất là 1 giờ
                durationText = $"{_nightsCount} giờ";
                unitPrice = _selectedRoom.GiaTheoGio ?? 0;
            }
            else
            {
                // Tính theo ngày (mặc định)
                // Sử dụng .Days của TimeSpan hiệu số Date để lấy số đêm chính xác
                _nightsCount = duration.Days;
                
                // [CHANGED] Removed logic that added +1 day if Time > 12:00. 
                // We rely on simple Night count. Late checkout can be handled by staff manually or hourly rent.
                _nightsCount = Math.Max(1, _nightsCount); // Luôn ít nhất là 1 đêm
                durationText = $"{_nightsCount} đêm";
                unitPrice = _selectedRoom.GiaTheoNgay ?? 0;
            }

            // Cập nhật giao diện
            lblNightsCount.Text = durationText;
            _roomTotal = unitPrice * _nightsCount;
            _servicesTotal = _selectedServices.Sum(s => s.Total);
            
            // Tính tổng tiền cuối cùng
            decimal grandTotal = _roomTotal + _servicesTotal - _discount;

            // Cập nhật giao diện
            txtRoomTotal.Text = _roomTotal.ToString("N0");
            txtServicesTotal.Text = _servicesTotal.ToString("N0");
            txtDiscount.Text = _discount.ToString("N0");
            txtGrandTotal.Text = grandTotal.ToString("N0");
        }

        private void UpdateRoomInfo()
        {
            if (_selectedRoom != null)
            {
                lblRoomNumber.Text = $"🏨 Phòng {_selectedRoom.SoPhong}";
                lblRoomType.Text = _selectedRoom.TenLoaiPhong;
                lblRoomPrice.Text = _selectedRoom.GiaTheoNgay?.ToString("N0") + " đ/đêm";
                lblRoomStatus.Text = _selectedRoom.TrangThai;
                lblRoomCapacity.Text = _selectedRoom.SucChuaToiDa?.ToString() ?? "0";

                // Load room image if available
                // This would require additional implementation for room images
            }
            else
            {
                lblRoomNumber.Text = "🏨 Phòng 000";
                lblRoomType.Text = "Loại phòng";
                lblRoomPrice.Text = "0 đ";
                lblRoomStatus.Text = "Trạng thái";
                lblRoomCapacity.Text = "0";
            }

            CalculateTotals();
        }

        // Event Handlers

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                if (rbRentHour != null && rbRentHour.Checked)
                     dtpCheckOut.Value = dtpCheckIn.Value.AddHours(1);
                else
                     dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }

            if (rbRentHour != null && rbRentHour.Checked && nudRentHours != null)
            {
                // Sync nudRentHours if date changed manually
                TimeSpan duration = dtpCheckOut.Value - dtpCheckIn.Value;
                int hours = (int)Math.Ceiling(duration.TotalHours);
                if (hours >= nudRentHours.Minimum && hours <= nudRentHours.Maximum)
                {
                     // Avoid recursive loop if value is same
                     if (nudRentHours.Value != hours)
                        nudRentHours.Value = hours;
                }
            }

            CalculateTotals();
        }

        private void BtnSearchCustomer_Click(object sender, EventArgs e)
        {
            string idNumber = txtCustomerID.Text.Trim();
            string idType = cbIDType.SelectedItem?.ToString() ?? "CCCD";

            if (string.IsNullOrEmpty(idNumber))
            {
                MessageBox.Show("Vui lòng nhập mã căn cước!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Search guest by ID number and type
                var result = _guestBUS.GetGuests(id: idNumber);
                if (result.Success && result.Data.Count > 0)
                {
                    // Find guest with matching ID type
                    var guest = result.Data.FirstOrDefault(g => 
                        g.IDNumber == idNumber && 
                        (g.IDType == idType || string.IsNullOrEmpty(g.IDType)));

                    if (guest != null)
                    {
                        _selectedGuest = guest;
                        txtCustomerName.Text = guest.HoTen;
                        txtCustomerPhone.Text = guest.SDT ?? "";
                        txtCustomerEmail.Text = guest.Email ?? "";
                        MessageBox.Show("Tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Guest not found, open frmGuest to add
                        if (MessageBox.Show("Không tìm thấy khách hàng với mã này. Bạn có muốn thêm mới không?", 
                            "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var guestForm = new frmGuest();
                            if (guestForm.ShowDialog() == DialogResult.OK)
                            {
                                // Reload and search again
                                BtnSearchCustomer_Click(sender, e);
                            }
                        }
                    }
                }
                else
                {
                    // Guest not found, open frmGuest to add
                    if (MessageBox.Show("Không tìm thấy khách hàng với mã này. Bạn có muốn thêm mới không?", 
                        "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var guestForm = new frmGuest();
                        if (guestForm.ShowDialog() == DialogResult.OK)
                        {
                            // Reload and search again
                            BtnSearchCustomer_Click(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddService_Click(object sender, EventArgs e)
        {
            // Open service selection modal
            string guestMaKH = _selectedGuest?.MaKH;
            var serviceForm = new frmServiceSelection(guestMaKH);
            if (serviceForm.ShowDialog() == DialogResult.OK)
            {
                var selectedServices = serviceForm.SelectedServiceUsages;
                if (selectedServices != null && selectedServices.Count > 0)
                {
                    foreach (var usage in selectedServices)
                    {
                        var existing = _selectedServices.FirstOrDefault(s => s.ServiceCode == usage.ServiceCode && s.UnitPrice == usage.UnitPrice);
                        if (existing != null)
                        {
                            existing.Quantity += usage.Quantity;
                        }
                        else
                        {
                            _selectedServices.Add(usage.Clone());
                        }
                    }
                    RefreshSelectedServicesGrid();
                }
            }
        }

        private void BtnRemoveService_Click(object sender, EventArgs e)
        {
            if (dgvSelectedServices.SelectedRows.Count > 0)
            {
                var selectedRow = dgvSelectedServices.SelectedRows[0];
                string maDV = selectedRow.Cells["colMaDV"].Value?.ToString();

                var service = _selectedServices.FirstOrDefault(s => s.ServiceCode == maDV);
                if (service != null)
                {
                    _selectedServices.Remove(service);
                    RefreshSelectedServicesGrid();
                }
            }
        }

        private void BtnApplyDiscount_Click(object sender, EventArgs e)
        {
            string discountCode = txtDiscountCode.Text.Trim();
            if (string.IsNullOrEmpty(discountCode))
            {
                MessageBox.Show("Vui lòng nhập mã khuyến mãi hoặc voucher!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lấy thông tin khách hàng để kiểm tra loại khách hàng
                string maLKH = null;
                if (_selectedGuest != null)
                {
                    var guestResult = _guestBUS.GetGuests(maKH: _selectedGuest.MaKH);
                    if (guestResult.Success && guestResult.Data.Count > 0)
                    {
                        maLKH = guestResult.Data[0].MaLKH;
                    }
                }

                decimal grandTotal = _roomTotal + _servicesTotal;
                decimal giamGia = 0;

                var promResult = _promotionBUS.GetPromotionByCode(discountCode, _selectedRoom?.MaCN, maLKH);
                if (promResult.Success && promResult.Data != null)
                {
                    var promotion = promResult.Data;
                    giamGia = _promotionBUS.CalculateDiscount(
                        promotion, 
                        grandTotal, 
                        _selectedRoom?.MaCN, 
                        maLKH, 
                        _selectedRoom?.MaLP, 
                        _selectedRoom?.MaPhong);
                }
                
                // Nếu không tìm thấy khuyến mãi hoặc giảm giá = 0, thử tìm voucher
                if (giamGia == 0)
                {
                    // Nếu không tìm thấy khuyến mãi, thử tìm voucher
                    var vouchers = _voucherBUS.GetVouchers(couponCode: discountCode, isActive: true);
                    if (vouchers.Success && vouchers.Data != null && vouchers.Data.Count > 0)
                    {
                        // Lọc voucher phù hợp với điều kiện
                        var validVouchers = vouchers.Data.Where(v => 
                            (v.TrangThai == "Active") &&
                            (!v.NgayBD.HasValue || v.NgayBD.Value <= DateTime.Now) &&
                            (!v.NgayKT.HasValue || v.NgayKT.Value >= DateTime.Now) &&
                            (!v.SoLuong.HasValue || v.SoLuongDaDung < v.SoLuong.Value) &&
                            (v.MaCN == null || v.MaCN == _selectedRoom?.MaCN) &&
                            (v.MaLKH == null || v.MaLKH == maLKH)
                        ).ToList();

                        if (validVouchers.Any())
                        {
                            var voucher = validVouchers.First();
                            
                            // Tính giảm giá từ voucher
                            if (voucher.GiaTri.HasValue)
                            {
                                if (voucher.IsPhanTram)
                                {
                                    // Giảm giá theo phần trăm, tối đa 100%
                                    decimal phanTramGiam = Math.Min(voucher.GiaTri.Value, 100);
                                    giamGia = Math.Round(grandTotal * phanTramGiam / 100, 0);
                                }
                                else
                                {
                                    // Giảm giá cố định, không vượt quá tổng tiền
                                    giamGia = Math.Min(voucher.GiaTri.Value, grandTotal);
                                }
                                
                                // Lưu thông tin voucher đã áp dụng
                                _appliedVoucher = voucher;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Voucher không khả dụng hoặc không thỏa điều kiện sử dụng!", "Thông báo", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy mã giảm giá hoặc voucher hợp lệ!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (giamGia > 0)
                {
                    _discount = giamGia;
                    CalculateTotals();
                    MessageBox.Show($"Áp dụng mã giảm giá thành công!\nGiảm: {giamGia:N0} đ", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã khuyến mãi hoặc voucher hợp lệ!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi áp dụng mã giảm giá: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddDeposit_Click(object sender, EventArgs e)
        {
            if (_selectedRoom == null)
            {
                MessageBox.Show("Vui lòng chọn phòng trước khi đặt cọc!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //  Ensure total amount is positive
            if (_roomTotal <= 0)
            {
                MessageBox.Show("Tổng tiền phòng đang là 0. Vui lòng kiểm tra lại giá phòng và ngày lưu trú!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calculate min deposit (30% of room total) and max deposit (room total)
            decimal minDeposit = _roomTotal * 0.3m;
            decimal maxDeposit = _roomTotal;

            // Open deposit dialog with min/max limits
            var depositForm = new frmDeposit(minDeposit, maxDeposit, _deposit);
            if (depositForm.ShowDialog() == DialogResult.OK)
            {
                _deposit = depositForm.DepositAmount;
                txtDeposit.Text = _deposit.ToString("N0");
                CalculateTotals();
            }
        }

        private void BtnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (!ValidateBooking()) return;

            bool success = false;

            try
            {
                // using (var scope = new TransactionScope()) // Removed as per user request
                {
                    try
                    {
                        // 1. Xử lý Booking (Header)
                        string maDP;
                        if (_formMode == BookingFormMode.Update && _currentBooking != null)
                        {
                            // Update existing booking
                            maDP = _currentBooking.MaDP;
                            var booking = CreateBooking();
                            booking.MaDP = maDP; // Preserve ID
                            // Keep created date/by if needed, or allow update
                            
                            var updateResult = _bookingBUS.UpdateBooking(
                                booking.MaDP, 
                                booking.TrangThai, 
                                booking.GhiChu, 
                                true); // isActive
                            
                            if (!updateResult.Success) throw new Exception("Không thể cập nhật Booking: " + updateResult.ErrorMessage);
                            
                            _currentBooking = booking; // Update localRef
                        }
                        else
                        {
                            // Create new booking
                            var booking = CreateBooking();
                            var bookingResult = _bookingBUS.AddBooking(booking);
                            if (!bookingResult.Success) throw new Exception(bookingResult.ErrorMessage);
                            _currentBooking = bookingResult.Data;
                            maDP = _currentBooking.MaDP;
                        }

                        // 2. Xử lý Booking Detail
                        var bookingDetail = CreateBookingDetail();
                        bookingDetail.MaDP = maDP; // Ensure linked to correct header

                        string maCTDP;
                        if (_formMode == BookingFormMode.Update && _currentBookingDetail != null)
                        {
                            // Update existing detail
                            maCTDP = _currentBookingDetail.MaCTDP;
                            var updateDetailResult = _bookingDetailBUS.UpdateBookingDetail(
                                maCTDP,
                                bookingDetail.TrangThai,
                                bookingDetail.NgayDen,
                                bookingDetail.NgayDi,
                                bookingDetail.NguoiLon,
                                bookingDetail.TreEm,
                                bookingDetail.GiaPhong,
                                bookingDetail.ThanhTien,
                                true
                            );
                            if (!updateDetailResult.Success) throw new Exception("Không thể cập nhật Chi tiết: " + updateDetailResult.ErrorMessage);
                        }
                        else
                        {
                             // Create new detail
                             //  Nếu đang cập nhật (check-in từ booking có sẵn), truyền MaDP để loại trừ khỏi kiểm tra trùng
                            string excludeMaDP = _currentBooking != null ? _currentBooking.MaDP : null;

                            var detailResult = _bookingDetailBUS.AddBookingDetail(
                                bookingDetail.MaDP,
                                bookingDetail.MaPhong,
                                bookingDetail.NgayDen,
                                bookingDetail.NgayDi,
                                bookingDetail.NguoiLon,
                                bookingDetail.TreEm,
                                bookingDetail.GiaPhong,
                                bookingDetail.ThanhTien,
                                bookingDetail.TrangThai,
                                bookingDetail.LoaiThue,
                                excludeMaDP 
                            );
                            if (!detailResult.Success) throw new Exception(detailResult.ErrorMessage);
                            maCTDP = detailResult.Data;
                        }

                        // Cập nhật ref cho CurrentDetail để lưu Service
                        _currentBookingDetail = new BookingDetail
                        {
                            MaCTDP = (_formMode == BookingFormMode.Update && _currentBookingDetail != null) ? _currentBookingDetail.MaCTDP : maCTDP,
                            MaDP = maDP,
                            MaPhong = bookingDetail.MaPhong,
                            NgayDen = bookingDetail.NgayDen,
                            NgayDi = bookingDetail.NgayDi,
                            NguoiLon = bookingDetail.NguoiLon,
                            TreEm = bookingDetail.TreEm,
                            GiaPhong = bookingDetail.GiaPhong,
                            ThanhTien = bookingDetail.ThanhTien,
                            TrangThai = bookingDetail.TrangThai,
                            LoaiThue = bookingDetail.LoaiThue
                        };

                        // 3. Lưu dịch vụ
                        if (!PersistServiceDetails(_currentBookingDetail.MaCTDP, true))
                            throw new Exception("Không thể lưu thông tin dịch vụ");

                        // 4. Lưu đặt cọc nếu có (Chỉ tạo mới nếu có số tiền, check trùng logic riêng nếu cần)
                        if (_deposit > 0)
                        {
                             // logic coc giu nguyen or add check
                            var depositResult = SaveDeposit();
                            if (!depositResult.Success)
                                throw new Exception(depositResult.ErrorMessage);
                        }

                        // 5. Cập nhật trạng thái phòng
                        // Logic xác định trạng thái
                        string roomStatus = rbCheckInNow.Checked ? "Đang sử dụng" : "Đã đặt";
                        
                        var updateRoomResult = _roomBUS.UpdateRoomStatus(
                            _selectedRoom.MaPhong, 
                            roomStatus
                        );

                        if (!updateRoomResult.Success)
                            throw new Exception(updateRoomResult.ErrorMessage);

                        // scope.Complete(); // Removed as per user request
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lưu đặt phòng: {ex.Message}", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xử lý đặt phòng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (success)
            {
                MessageBox.Show("Đặt phòng thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void DgvSelectedServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSelectedServices.SelectedRows.Count > 0)
            {
                var selectedRow = dgvSelectedServices.SelectedRows[0];
                string maDV = selectedRow.Cells["colMaDV"].Value?.ToString();
                
                if (!string.IsNullOrEmpty(maDV))
                {
                    var service = _selectedServices.FirstOrDefault(s => s.ServiceCode == maDV);
                    if (service != null)
                    {
                        btnRemoveService.Enabled = true;
                    }
                }
            }
            else
            {
                btnRemoveService.Enabled = false;
            }
        }

        private void DgvSelectedServices_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var column = dgvSelectedServices.Columns[e.ColumnIndex];
            if (column == null || column.Name != "colSoLuong") return;

            var row = dgvSelectedServices.Rows[e.RowIndex];
            string maDV = row.Cells["colMaDV"].Value?.ToString();
            var usage = _selectedServices.FirstOrDefault(s => s.ServiceCode == maDV);
            if (usage == null) return;

            if (int.TryParse(row.Cells["colSoLuong"].Value?.ToString(), out int quantity) && quantity > 0)
            {
                usage.Quantity = quantity;
                RefreshSelectedServicesGrid();
            }
            else
            {
                MessageBox.Show("Số lượng dịch vụ phải là số nguyên dương.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                row.Cells["colSoLuong"].Value = usage.Quantity;
            }
        }

        private void DgvSelectedServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvSelectedServices.Rows[e.RowIndex];
                string maDV = selectedRow.Cells["colMaDV"].Value?.ToString();
                
                if (!string.IsNullOrEmpty(maDV))
                {
                    var service = _selectedServices.FirstOrDefault(s => s.ServiceCode == maDV);
                    if (service != null)
                    {
                        string serviceInfo = $"Mã DV: {service.ServiceCode}\n" +
                                             $"Tên DV: {service.ServiceName}\n" +
                                             $"Loại: {service.Service?.LoaiDV}\n" +
                                             $"Số lượng: {service.Quantity}\n" +
                                             $"Đơn giá: {service.UnitPrice:N0} đ\n" +
                                             $"Thành tiền: {service.Total:N0} đ";

                        _serviceToolTip.SetToolTip(dgvSelectedServices, serviceInfo);
                        dgvSelectedServices.Rows[e.RowIndex].Selected = true;
                    }
                }
            }
        }

        private bool PersistServiceDetails(string maCTDP, bool replaceExisting)
        {
            try 
            {
                string logPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "debug_booking.txt");
                System.IO.File.AppendAllText(logPath, $"[{DateTime.Now}] PersistServiceDetails Called for MaCTDP: {maCTDP}, Replace: {replaceExisting}\n");
                System.IO.File.AppendAllText(logPath, $"[{DateTime.Now}] Selected Services Count: {_selectedServices.Count}\n");

                if (replaceExisting)
                {
                    var currentDetails = _serviceDetailBUS.GetServiceDetails(maCTDP: maCTDP, isActive: true);
                    if (currentDetails.Success)
                    {
                        foreach (var detail in currentDetails.Data)
                        {
                            _serviceDetailBUS.DeleteServiceDetail(detail.MaCTDV);
                        }
                        System.IO.File.AppendAllText(logPath, $"[{DateTime.Now}] Deleted {currentDetails.Data.Count} existing services.\n");
                    }
                }

                foreach (var usage in _selectedServices)
                {
                    System.IO.File.AppendAllText(logPath, $"[{DateTime.Now}] Processing Service: {usage.ServiceCode}, Qty: {usage.Quantity}\n");
                    
                    if (string.IsNullOrEmpty(usage.ServiceCode))
                    {
                         System.IO.File.AppendAllText(logPath, $"[{DateTime.Now}] SKIP: ServiceCode is empty.\n");
                         continue;
                    }

                    var addResult = _serviceDetailBUS.AddServiceDetail(
                        maCTDP,
                        usage.ServiceCode,
                        usage.Quantity,
                        usage.UnitPrice,
                        usage.Total);

                    System.IO.File.AppendAllText(logPath, $"[{DateTime.Now}] Add Result: {addResult.Success}, Msg: {addResult.ErrorMessage}\n");

                    if (!addResult.Success)
                    {
                        MessageBox.Show($"Lỗi khi lưu dịch vụ {usage.ServiceName}: {addResult.ErrorMessage}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi debug log: " + ex.Message);
                return false;
            }
        }

        private void UpdateRoomStatus(string status)
        {
            if (_selectedRoom == null) return;

            var updateResult = _roomBUS.UpdateRoomStatus(_selectedRoom.MaPhong, status);

            if (updateResult.Success)
            {
                _selectedRoom.TrangThai = status;
                lblRoomStatus.Text = status;
            }
            else
            {
                MessageBox.Show($"Không thể cập nhật trạng thái phòng: {updateResult.ErrorMessage}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidateBooking()
        {
            if (_selectedRoom == null)
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_selectedGuest == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //  Enforce same-day booking (simplification request)
            if (dtpCheckIn.Value.Date != DateTime.Now.Date && _formMode == BookingFormMode.Create)
            {
                 MessageBox.Show("Hệ thống hiện tại chỉ cho phép đặt phòng (Check-in) trong ngày!", 
                     "Quy định đặt phòng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 // Reset date to today to guide user? Or just return false.
                 dtpCheckIn.Value = DateTime.Now;
                 return false;
            }

            // Kiểm tra thời gian đặt phòng
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                MessageBox.Show("Ngày trả phòng phải sau ngày nhận phòng!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra thời gian tối thiểu
            var minStayHours = (rbRentHour != null && rbRentHour.Checked) ? 1 : 24; // 1 giờ nếu thuê giờ, 24h nếu thuê ngày
            // Lưu ý: User prompt muốn 2 giờ, nhưng logic hiện tại của tôi cho 1 giờ tối thiểu trong CalculateTotals. Sửa thành 1 cho nhất quán.
            var minStay = TimeSpan.FromHours(minStayHours);
            var stayDuration = dtpCheckOut.Value - dtpCheckIn.Value;

            // Kiểm tra phòng trống
            // Gọi phương thức CheckRoomAvailability đã thêm vào BookingDetailBUS
            var roomAvailable = _bookingDetailBUS.CheckRoomAvailability(
                _selectedRoom.MaPhong, 
                dtpCheckIn.Value, 
                dtpCheckOut.Value,
                _currentBooking?.MaDP
            );

            if (!roomAvailable.Success)
            {
                MessageBox.Show($"Lỗi khi kiểm tra phòng: {roomAvailable.ErrorMessage}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!roomAvailable.Data)
            {
                MessageBox.Show("Phòng đã được đặt trong khoảng thời gian này!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra số lượng người
            int adults = 0;
            int children = 0;
            int.TryParse(txtAdultsCount.Text, out adults);
            int.TryParse(txtChildrenCount.Text, out children);
            int totalGuests = adults + children;

            if (totalGuests > (_selectedRoom.SucChuaToiDa ?? 10)) // Default 10 nếu null
            {
                MessageBox.Show($"Số lượng khách vượt quá sức chứa của phòng ({_selectedRoom.SucChuaToiDa} người)!", 
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private Booking CreateBooking()
        {
            int adults = 0;
            int children = 0;
            int.TryParse(txtAdultsCount.Text, out adults);
            int.TryParse(txtChildrenCount.Text, out children);

            return new Booking
            {
                MaKH = _selectedGuest.MaKH,
                MaNV = Session_Now.CurrentUser,
                TrangThai = rbCheckInNow.Checked ? "Đang sử dụng" : "Đặt",
                NgayDen = dtpCheckIn.Value,
                NgayDi = dtpCheckOut.Value,
                NguoiLon = adults,
                TreEm = children,
                GhiChu = rbCheckInNow.Checked ? "Check-in trực tiếp" : "Đặt phòng trước"
            };
        }

        private BookingDetail CreateBookingDetail()
        {
            string loaiThue = (rbRentHour != null && rbRentHour.Checked) ? "Giờ" : "Ngày";
            decimal unitPrice = (rbRentHour != null && rbRentHour.Checked) 
                ? (_selectedRoom.GiaTheoGio ?? 0) 
                : (_selectedRoom.GiaTheoNgay ?? 0);

            int adults = 0;
            int children = 0;
            int.TryParse(txtAdultsCount.Text, out adults);
            int.TryParse(txtChildrenCount.Text, out children);

            return new BookingDetail
            {
                MaDP = _currentBooking.MaDP,
                MaPhong = _selectedRoom.MaPhong,
                NgayDen = dtpCheckIn.Value,
                NgayDi = dtpCheckOut.Value,
                NguoiLon = adults,
                TreEm = children,
                GiaPhong = unitPrice,
                ThanhTien = _roomTotal,
                TrangThai = rbCheckInNow.Checked ? "Đang sử dụng" : "Đặt",
                LoaiThue = loaiThue
            };
        }

        private OperationResult<bool> SaveDeposit()
        {
            var deposit = new Deposit
            {
                MaDatCoc = _depositBUS.GenerateDepositCode(),
                MaDP = _currentBooking.MaDP,
                MaKH = _selectedGuest.MaKH,
                SoTien = _deposit,
                HinhThucThanhToan = "Tiền mặt", // Có thể thêm combobox để chọn
                LoaiCoc = "Đặt phòng",
                TrangThai = "ĐÃ NHẬN",
                GhiChu = $"Đặt cọc cho booking {_currentBooking.MaDP}",
                CreatedAt = DateTime.Now,
                CreatedBy = Session_Now.CurrentUser
            };

            return _depositBUS.AddDeposit(deposit);
        }

        private void gbServices_Enter(object sender, EventArgs e)
        {
            
        }

        
    }

    public enum BookingFormMode
    {
        Create,
        Update
    }

}
