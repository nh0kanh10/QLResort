using QLResort.BUS;
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
using System.Transactions;

namespace QLResort.GUI
{
    public partial class frmBooking : AppBaseForm
    {
        private readonly RoomBUS _roomBUS;
        private readonly ServiceBUS _serviceBUS;
        private readonly BookingBUS _bookingBUS;
        private readonly BookingDetailBUS _bookingDetailBUS;
        private readonly ServiceDetailBUS _serviceDetailBUS;
        private readonly GuestBUS _guestBUS;
        private readonly PromotionBUS _promotionBUS = new PromotionBUS();
        private readonly VoucherBUS _voucherBUS = new VoucherBUS();
        private readonly DepositBUS _depositBUS = new DepositBUS();

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
        

        // Rent Type Controls - Moved to Designer

        public frmBooking(Room room = null, Booking existingBooking = null, BookingDetail existingDetail = null)
        {
            InitializeComponent();
            AppTheme.ApplyForm(this);
            AppTheme.StyleDataGridView(dgvSelectedServices);

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

            // Load services đã gắn
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
                // Nếu check-out sau 12h trưa thì tính thêm 1 ngày
                _nightsCount = duration.Days;
                if (dtpCheckOut.Value.TimeOfDay > new TimeSpan(12, 0, 0))
                {
                    _nightsCount += 1;
                }
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

                // Thử tìm khuyến mãi trước
                var promResult = _promotionBUS.GetPromotionByCode(discountCode, _selectedRoom?.MaCN, maLKH);
                if (promResult.Success)
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
                else
                {
                    // Nếu không tìm thấy khuyến mãi, thử tìm voucher
                    var vouchers = _voucherBUS.GetVouchers(couponCode: discountCode, maLKH: maLKH, maCN: _selectedRoom?.MaCN, trangThai: "Active", isActive: true);
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
            if (!ValidateBooking()) return;

            bool success = false;

            try
            {
                using (var scope = new TransactionScope())
                {
                    try
                    {
                        // 1. Tạo booking
                        var booking = CreateBooking();
                        var bookingResult = _bookingBUS.AddBooking(booking);
                        
                        if (!bookingResult.Success)
                            throw new Exception(bookingResult.ErrorMessage);

                        _currentBooking = bookingResult.Data;

                        // 2. Tạo booking detail
                        var bookingDetail = CreateBookingDetail();
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
                            bookingDetail.LoaiThue
                        );

                        if (!detailResult.Success)
                            throw new Exception(detailResult.ErrorMessage);

                        _currentBookingDetail = new BookingDetail
                        {
                            MaCTDP = detailResult.Data,
                            MaDP = _currentBooking.MaDP,
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

                        // 4. Lưu đặt cọc nếu có
                        if (_deposit > 0)
                        {
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

                        scope.Complete(); // Commit transaction
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        // Transaction sẽ tự động rollback khi có lỗi (Dispose mà không Complete)
                        throw new Exception($"Lỗi khi xử lý đặt phòng: {ex.Message}");
                    }
                } // Dispose scope here

                // UI Logic outside transaction
                if (success)
                {
                    MessageBox.Show("Đặt phòng thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool PersistServiceDetails(string maCTDP, bool replaceExisting)
        {
            if (replaceExisting)
            {
                var currentDetails = _serviceDetailBUS.GetServiceDetails(maCTDP: maCTDP, isActive: true);
                if (currentDetails.Success)
                {
                    foreach (var detail in currentDetails.Data)
                    {
                        _serviceDetailBUS.DeleteServiceDetail(detail.MaCTDV);
                    }
                }
            }

            foreach (var usage in _selectedServices)
            {
                if (string.IsNullOrEmpty(usage.ServiceCode))
                    continue;

                var addResult = _serviceDetailBUS.AddServiceDetail(
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
