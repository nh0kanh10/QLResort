using QLResort.BLL;
using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.GUI.Guest;
using QLResort.GUI.Styles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmBooking : Form
    {
        private readonly RoomBLL _roomBLL;
        private readonly ServiceBLL _serviceBLL;
        private readonly BookingBLL _bookingBLL;
        private readonly BookingDetailBLL _bookingDetailBLL;
        private readonly ServiceDetailBLL _serviceDetailBLL;
        private readonly GuestBLL _guestBLL;
        private readonly PromotionBLL _promotionBLL = new PromotionBLL();
        private readonly VoucherBLL _voucherBLL = new VoucherBLL();
        private readonly DepositBLL _depositBLL = new DepositBLL();

        private List<ServiceUsage> _selectedServices;
        private Room _selectedRoom;
        private QLResort.Core.Model.Guest _selectedGuest;
        private Booking _currentBooking;
        private BookingDetail _currentBookingDetail;
        private BookingFormMode _formMode;
        private readonly ToolTip _serviceToolTip = new ToolTip();

        private decimal _roomTotal = 0;
        private decimal _servicesTotal = 0;
        private decimal _discount = 0;
        private decimal _deposit = 0;
        private int _nightsCount = 0;
        
        // RadioButtons cho chọn loại đặt phòng
        

        public frmBooking(Room room = null, Booking existingBooking = null, BookingDetail existingDetail = null)
        {
            InitializeComponent();
            AppTheme.ApplyForm(this);
            AppTheme.StyleDataGridView(dgvSelectedServices);

            _roomBLL = new RoomBLL();
            _serviceBLL = new ServiceBLL();
            _bookingBLL = new BookingBLL();
            _bookingDetailBLL = new BookingDetailBLL();
            _serviceDetailBLL = new ServiceDetailBLL();
            _guestBLL = new GuestBLL();

            _selectedServices = new List<ServiceUsage>();
            _selectedRoom = room;
            _currentBooking = existingBooking;
            _currentBookingDetail = existingDetail;
            _formMode = existingBooking == null ? BookingFormMode.Create : BookingFormMode.Update;

            InitializeData();
            SetupEventHandlers();
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
                var detailResult = _bookingDetailBLL.GetBookingDetails(maDP: _currentBooking.MaDP, isActive: true);
                if (detailResult.Success && detailResult.Data.Count > 0)
                {
                    _currentBookingDetail = detailResult.Data.Find(d => d.TrangThai != null && d.TrangThai != "Hoàn tất")
                        ?? detailResult.Data[0];
                }
            }

            if (_currentBooking == null && _currentBookingDetail != null)
            {
                var bookingResult = _bookingBLL.GetBookings(maDP: _currentBookingDetail.MaDP);
                if (bookingResult.Success && bookingResult.Data.Count > 0)
                {
                    _currentBooking = bookingResult.Data[0];
                }
            }

            if (_currentBooking == null || _currentBookingDetail == null) return;

            if (_selectedRoom == null && !string.IsNullOrEmpty(_currentBookingDetail.MaPhong))
            {
                var roomResult = _roomBLL.GetRooms(maPhong: _currentBookingDetail.MaPhong);
                if (roomResult.Success && roomResult.Data.Count > 0)
                {
                    _selectedRoom = roomResult.Data[0];
                }
            }

            UpdateRoomInfo();

            dtpCheckIn.Value = _currentBookingDetail.NgayDen ?? DateTime.Now;
            dtpCheckOut.Value = _currentBookingDetail.NgayDi ?? dtpCheckIn.Value.AddDays(1);

            if (!string.IsNullOrEmpty(_currentBooking.MaKH))
            {
                var guestResult = _guestBLL.GetGuests(maKH: _currentBooking.MaKH);
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

            // Load services đã gắn
            var serviceDetailResult = _serviceDetailBLL.GetServiceDetails(maCTDP: _currentBookingDetail.MaCTDP, isActive: true);
            if (serviceDetailResult.Success)
            {
                _selectedServices.Clear();
                foreach (var detail in serviceDetailResult.Data)
                {
                    Service serviceInfo = null;
                    if (!string.IsNullOrEmpty(detail.MaDV))
                    {
                        var serviceLookup = _serviceBLL.GetServices(maDV: detail.MaDV);
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
            if (dgvSelectedServices.Columns.Count == 0)
            {
                dgvSelectedServices.Columns.Add("colMaDV", "Mã DV");
                dgvSelectedServices.Columns.Add("colTenDV", "Tên dịch vụ");
                dgvSelectedServices.Columns.Add("colLoaiDV", "Loại");
                dgvSelectedServices.Columns.Add("colSoLuong", "SL");
                dgvSelectedServices.Columns.Add("colGia", "Đơn giá");
                dgvSelectedServices.Columns.Add("colThanhTien", "Thành tiền");

                dgvSelectedServices.Columns["colMaDV"].Width = 80;
                dgvSelectedServices.Columns["colTenDV"].Width = 200;
                dgvSelectedServices.Columns["colLoaiDV"].Width = 120;
                dgvSelectedServices.Columns["colSoLuong"].Width = 60;
                dgvSelectedServices.Columns["colGia"].Width = 120;
                dgvSelectedServices.Columns["colThanhTien"].Width = 150;
            }

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
            // Calculate nights
            _nightsCount = (int)(dtpCheckOut.Value - dtpCheckIn.Value).TotalDays;
            _nightsCount = Math.Max(1, _nightsCount);
            lblNightsCount.Text = $"{_nightsCount} đêm";

            // Calculate room total - nếu đang update, dùng giá từ booking detail hoặc phòng
            _roomTotal = 0;
            if (_formMode == BookingFormMode.Update && _currentBookingDetail != null)
            {
                // Khi update, tính lại dựa trên giá phòng hiện tại hoặc giá đã lưu
                decimal unitPrice = _selectedRoom?.GiaTheoNgay ?? _currentBookingDetail.GiaPhong ?? 0;
                _roomTotal = unitPrice * _nightsCount;
            }
            else if (_selectedRoom?.GiaTheoNgay != null)
            {
                _roomTotal = _selectedRoom.GiaTheoNgay.Value * _nightsCount;
            }

            // Calculate services total
            _servicesTotal = _selectedServices.Sum(s => s.Total);

            // Calculate grand total
            decimal grandTotal = _roomTotal + _servicesTotal - _discount;

            // Update UI
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

        #region Event Handlers

        private void DatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value <= dtpCheckIn.Value)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
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
                var result = _guestBLL.GetGuests(id: idNumber);
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
                    var guestResult = _guestBLL.GetGuests(maKH: _selectedGuest.MaKH);
                    if (guestResult.Success && guestResult.Data.Count > 0)
                    {
                        maLKH = guestResult.Data[0].MaLKH;
                    }
                }

                decimal grandTotal = _roomTotal + _servicesTotal;
                decimal giamGia = 0;

                // Thử tìm khuyến mãi trước
                var promResult = _promotionBLL.GetPromotionByCode(discountCode, _selectedRoom?.MaCN, maLKH);
                if (promResult.Success)
                {
                    var promotion = promResult.Data;
                    giamGia = _promotionBLL.CalculateDiscount(
                        promotion, 
                        grandTotal, 
                        _selectedRoom?.MaCN, 
                        maLKH, 
                        _selectedRoom?.MaLP, 
                        _selectedRoom?.MaPhong);
                }
                else
                {
                    // Nếu không tìm thấy khuyến mãi, thử tìm voucher
                    var vouchers = _voucherBLL.GetVouchers(couponCode: discountCode, maLKH: maLKH, maCN: _selectedRoom?.MaCN, trangThai: "Active", isActive: true);
                    if (vouchers.Success && vouchers.Data.Count > 0)
                    {
                        var voucher = vouchers.Data.FirstOrDefault();
                        if (voucher != null)
                        {
                            // Kiểm tra thời gian hiệu lực
                            if (voucher.NgayBD.HasValue && voucher.NgayBD.Value > DateTime.Now)
                            {
                                MessageBox.Show("Voucher chưa có hiệu lực!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (voucher.NgayKT.HasValue && voucher.NgayKT.Value < DateTime.Now)
                            {
                                MessageBox.Show("Voucher đã hết hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Kiểm tra số lượng còn lại
                            if (voucher.SoLuong.HasValue && voucher.SoLuongDaDung >= voucher.SoLuong.Value)
                            {
                                MessageBox.Show("Voucher đã hết số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Tính giảm giá từ voucher
                            if (voucher.IsPhanTram && voucher.GiaTri.HasValue)
                            {
                                giamGia = grandTotal * voucher.GiaTri.Value / 100;
                            }
                            else if (!voucher.IsPhanTram && voucher.GiaTri.HasValue)
                            {
                                giamGia = voucher.GiaTri.Value > grandTotal ? grandTotal : voucher.GiaTri.Value;
                            }
                        }
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
            if (!ValidateBooking())
                return;

            try
            {
                if (_formMode == BookingFormMode.Create)
                {
                    // Kiểm tra null trước khi tạo booking
                    if (_selectedGuest == null)
                    {
                        MessageBox.Show("Vui lòng chọn khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (_selectedRoom == null)
                    {
                        MessageBox.Show("Vui lòng chọn phòng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(Session_Now.CurrentUser))
                    {
                        MessageBox.Show("Không tìm thấy thông tin người dùng! Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Xác định trạng thái dựa trên loại đặt phòng
                    string trangThai = rbCheckInNow.Checked ? "Đang sử dụng" : "Đặt";
                    string ghiChu = rbCheckInNow.Checked ? "Check-in trực tiếp" : "Đặt phòng trước";
                    
                    var booking = new Booking
                    {
                        MaKH = _selectedGuest.MaKH,
                        MaNV = Session_Now.CurrentUser,
                        TrangThai = trangThai,
                        NgayDen = dtpCheckIn.Value,
                        NgayDi = dtpCheckOut.Value,
                        NguoiLon = 2,
                        TreEm = 0,
                        GhiChu = ghiChu
                    };

                    var bookingResult = _bookingBLL.AddBooking(booking);
                    if (!bookingResult.Success)
                    {
                        MessageBox.Show($"Lỗi khi tạo booking: {bookingResult.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy booking từ kết quả trả về
                    _currentBooking = bookingResult.Data;
                    if (_currentBooking == null || string.IsNullOrWhiteSpace(_currentBooking.MaDP))
                    {
                        MessageBox.Show("Không thể lấy mã đặt phòng sau khi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Xác định trạng thái cho booking detail
                    string detailTrangThai = rbCheckInNow.Checked ? "Đang sử dụng" : "Đặt";
                    
                    var bookingDetailResult = _bookingDetailBLL.AddBookingDetail(
                        _currentBooking.MaDP,
                        _selectedRoom.MaPhong,
                        dtpCheckIn.Value,
                        dtpCheckOut.Value,
                        2,
                        0,
                        _selectedRoom.GiaTheoNgay ?? 0,
                        _roomTotal,
                        detailTrangThai
                    );

                    if (!bookingDetailResult.Success)
                    {
                        MessageBox.Show($"Lỗi khi tạo chi tiết booking: {bookingDetailResult.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(bookingDetailResult.Data))
                    {
                        MessageBox.Show("Không thể lấy mã chi tiết đặt phòng sau khi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _currentBookingDetail = new BookingDetail
                    {
                        MaCTDP = bookingDetailResult.Data,
                        MaDP = _currentBooking.MaDP,
                        MaPhong = _selectedRoom.MaPhong,
                        NgayDen = dtpCheckIn.Value,
                        NgayDi = dtpCheckOut.Value,
                        GiaPhong = _selectedRoom.GiaTheoNgay ?? 0,
                        ThanhTien = _roomTotal,
                        TrangThai = detailTrangThai
                    };

                    if (!PersistServiceDetails(_currentBookingDetail.MaCTDP, true))
                        return;

                    // Lưu deposit nếu có
                    if (_deposit > 0)
                    {
                        var deposit = new Deposit
                        {
                            MaDatCoc = _depositBLL.GenerateDepositCode(),
                            MaDP = _currentBooking.MaDP,
                            MaKH = _selectedGuest.MaKH,
                            SoTien = _deposit,
                            HinhThucThanhToan = "Tiền mặt", // Default, có thể thêm form chọn
                            LoaiCoc = "Đặt phòng",
                            TrangThai = "ĐÃ NHẬN",
                            GhiChu = $"Đặt cọc cho booking {_currentBooking.MaDP}",
                            CreatedBy = Session_Now.CurrentUser
                        };

                        var depositResult = _depositBLL.AddDeposit(deposit);
                        if (!depositResult.Success)
                        {
                            MessageBox.Show($"Cảnh báo: Lưu thông tin cọc thất bại: {depositResult.Message}\nBooking đã được tạo nhưng cần nhập lại tiền cọc.", 
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // Cập nhật trạng thái phòng
                    string roomStatus = rbCheckInNow.Checked ? "Đang sử dụng" : "Đã đặt";
                    UpdateRoomStatus(roomStatus);
                    
                    // Booking detail đã được tạo với trạng thái đúng, không cần update lại

                    string message = rbCheckInNow.Checked 
                        ? "Check-in thành công! Khách đã vào phòng." 
                        : "Đặt phòng thành công!";
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Đảm bảo DialogResult được set để form đóng đúng cách
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (_currentBooking == null || _currentBookingDetail == null)
                    {
                        MessageBox.Show("Không tìm thấy thông tin đặt phòng để cập nhật.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Tính lại tổng tiền dựa trên thời gian mới và dịch vụ
                    int nights = (int)(dtpCheckOut.Value - dtpCheckIn.Value).TotalDays;
                    nights = Math.Max(1, nights);
                    decimal roomTotal = (_selectedRoom?.GiaTheoNgay ?? _currentBookingDetail.GiaPhong ?? 0) * nights;
                    decimal servicesTotal = _selectedServices.Sum(s => s.Total);
                    decimal newTotal = roomTotal + servicesTotal - _discount;

                    _currentBookingDetail.NgayDen = dtpCheckIn.Value;
                    _currentBookingDetail.NgayDi = dtpCheckOut.Value;
                    _currentBookingDetail.GiaPhong = _selectedRoom?.GiaTheoNgay ?? _currentBookingDetail.GiaPhong;
                    _currentBookingDetail.ThanhTien = newTotal;

                    var updateDetailResult = _bookingDetailBLL.UpdateBookingDetail(
                        _currentBookingDetail.MaCTDP,
                        _currentBookingDetail.TrangThai, // Giữ nguyên trạng thái hiện tại
                        _currentBookingDetail.NgayDen,
                        _currentBookingDetail.NgayDi,
                        _currentBookingDetail.NguoiLon ?? 2,
                        _currentBookingDetail.TreEm ?? 0,
                        _currentBookingDetail.GiaPhong,
                        _currentBookingDetail.ThanhTien
                    );

                    if (!updateDetailResult.Success)
                    {
                        MessageBox.Show($"Lỗi khi cập nhật chi tiết đặt phòng: {updateDetailResult.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!PersistServiceDetails(_currentBookingDetail.MaCTDP, true))
                        return;

                    MessageBox.Show("Cập nhật đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        #endregion

        private bool PersistServiceDetails(string maCTDP, bool replaceExisting)
        {
            if (replaceExisting)
            {
                var currentDetails = _serviceDetailBLL.GetServiceDetails(maCTDP: maCTDP, isActive: true);
                if (currentDetails.Success)
                {
                    foreach (var detail in currentDetails.Data)
                    {
                        _serviceDetailBLL.DeleteServiceDetail(detail.MaCTDV);
                    }
                }
            }

            foreach (var usage in _selectedServices)
            {
                if (string.IsNullOrEmpty(usage.ServiceCode))
                    continue;

                var addResult = _serviceDetailBLL.AddServiceDetail(
                    maCTDP,
                    usage.ServiceCode,
                    usage.Quantity,
                    usage.UnitPrice,
                    usage.Total);

                if (!addResult.Success)
                {
                    MessageBox.Show($"Lỗi khi lưu dịch vụ {usage.ServiceName}: {addResult.ErrorMessage}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void UpdateRoomStatus(string status)
        {
            if (_selectedRoom == null)
                return;

            var updateResult = _roomBLL.UpdateRoom(
                _selectedRoom.MaPhong,
                _selectedRoom.MaCN,
                _selectedRoom.MaLP,
                _selectedRoom.SoPhong,
                _selectedRoom.ViTri,
                status,
                _selectedRoom.GhiChu,
                _selectedRoom.IsActive);

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
                MessageBox.Show("Vui lòng chọn phòng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_selectedGuest == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpCheckIn.Value >= dtpCheckOut.Value)
            {
                MessageBox.Show("Ngày trả phải sau ngày nhận!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ComboBoxItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
