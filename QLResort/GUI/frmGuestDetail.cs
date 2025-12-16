using QLResort.BUS;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmGuestDetail : AppBaseForm
    {
        private readonly GuestBUS _guestBUS = new GuestBUS();
        private readonly BookingBUS _bookingBUS = new BookingBUS();
        private readonly BookingDetailBUS _bookingDetailBUS = new BookingDetailBUS();
        private readonly ServiceDetailBUS _serviceDetailBUS = new ServiceDetailBUS();
        private readonly EventDetailBUS _eventDetailBUS = new EventDetailBUS();
        private readonly GuestTypeBUS _guestTypeBUS = new GuestTypeBUS();
        
        private QLResort.Core.Model.Guest _selectedGuest;
        private const string PLACEHOLDER_TEXT = "Nhập mã KH, CCCD, SĐT hoặc Email";

        public frmGuestDetail(string guestId = null)
        {
            InitializeComponent();
            AppTheme.ApplyForm(this);
            AppTheme.StylePrimaryButton(btnSearch);
            AppTheme.StyleDataGridView(dgvBookings);
            AppTheme.StyleDataGridView(dgvServices);
            AppTheme.StyleDataGridView(dgvEvents);
            
            // Initial placeholder setup
            txtSearchGuest.Text = PLACEHOLDER_TEXT;
            txtSearchGuest.ForeColor = Color.Gray;

            if (!string.IsNullOrEmpty(guestId))
            {
                txtSearchGuest.Text = guestId;
                txtSearchGuest.ForeColor = Color.Black;
                SearchGuest();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchGuest();
        }

        private void TxtSearchGuest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchGuest();
            }
        }
        
        private void txtSearchGuest_Enter(object sender, EventArgs e)
        {
            if (txtSearchGuest.Text == PLACEHOLDER_TEXT)
            {
                txtSearchGuest.Text = "";
                txtSearchGuest.ForeColor = Color.Black;
            }
        }

        private void txtSearchGuest_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchGuest.Text))
            {
                txtSearchGuest.Text = PLACEHOLDER_TEXT;
                txtSearchGuest.ForeColor = Color.Gray;
            }
        }

        private void SearchGuest()
        {
            string searchText = txtSearchGuest.Text.Trim();
            if (string.IsNullOrEmpty(searchText) || searchText == PLACEHOLDER_TEXT)
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Tìm theo Mã KH
                var result = _guestBUS.GetGuests(maKH: searchText);
                if (result.Success && result.Data.Count > 0)
                {
                    _selectedGuest = result.Data[0];
                    LoadGuestDetails();
                    return;
                }

                // 2. Tìm theo CCCD/CMND
                result = _guestBUS.GetGuests(id: searchText);
                if (result.Success && result.Data.Count > 0)
                {
                    _selectedGuest = result.Data[0];
                    LoadGuestDetails();
                    return;
                }

                // 3. Tìm theo SĐT
                result = _guestBUS.GetGuests(sdt: searchText);
                if (result.Success && result.Data.Count > 0)
                {
                    _selectedGuest = result.Data[0];
                    LoadGuestDetails();
                    return;
                }

                MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm khách hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGuestDetails()
        {
            if (_selectedGuest == null) return;

            try
            {
                // Hiển thị thông tin cơ bản
                lblGuestInfo.Text = $"Mã KH: {_selectedGuest.MaKH} | " +
                                   $"Họ tên: {_selectedGuest.HoTen} | " +
                                   $"SĐT: {_selectedGuest.SDT} | " +
                                   $"Email: {_selectedGuest.Email ?? "N/A"} | " +
                                   $"CCCD: {_selectedGuest.IDNumber ?? "N/A"}";

                // Load loại khách hàng
                if (!string.IsNullOrEmpty(_selectedGuest.MaLKH))
                {
                    var guestTypeResult = _guestTypeBUS.GetGuestTypes(maLKH: _selectedGuest.MaLKH);
                    if (guestTypeResult.Success && guestTypeResult.Data.Count > 0)
                    {
                        lblGuestType.Text = $"Loại khách hàng: {guestTypeResult.Data[0].TenLKH}";
                    }
                }

                // Load điểm tích lũy (tạm thời)
                lblPoints.Text = "Điểm tích lũy: 0"; 

                // Load lịch sử đặt phòng
                LoadBookingHistory();

                // Load lịch sử dịch vụ
                LoadServiceHistory();

                // Load lịch sử sự kiện
                LoadEventHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookingHistory()
        {
            dgvBookings.Rows.Clear();
            dgvBookings.Columns.Clear();

            dgvBookings.Columns.Add("colMaDP", "Mã đặt phòng");
            dgvBookings.Columns.Add("colNgayDen", "Ngày đến");
            dgvBookings.Columns.Add("colNgayDi", "Ngày đi");
            dgvBookings.Columns.Add("colMaPhong", "Mã phòng");
            dgvBookings.Columns.Add("colTrangThai", "Trạng thái");
            dgvBookings.Columns.Add("colThanhTien", "Thành tiền");

            var bookings = _bookingBUS.GetBookings(maKH: _selectedGuest.MaKH);
            if (bookings.Success)
            {
                foreach (var booking in bookings.Data)
                {
                    var details = _bookingDetailBUS.GetBookingDetails(maDP: booking.MaDP);
                    if (details.Success)
                    {
                        foreach (var detail in details.Data)
                        {
                            dgvBookings.Rows.Add(
                                booking.MaDP,
                                detail.NgayDen?.ToString("dd/MM/yyyy") ?? "",
                                detail.NgayDi?.ToString("dd/MM/yyyy") ?? "",
                                detail.MaPhong,
                                detail.TrangThai,
                                detail.ThanhTien?.ToString("N0") ?? "0"
                            );
                        }
                    }
                }
            }
        }

        private void LoadServiceHistory()
        {
            dgvServices.Rows.Clear();
            dgvServices.Columns.Clear();

            dgvServices.Columns.Add("colMaCTDV", "Mã CTDV");
            dgvServices.Columns.Add("colMaDV", "Mã dịch vụ");
            dgvServices.Columns.Add("colSoLuong", "Số lượng");
            dgvServices.Columns.Add("colGia", "Đơn giá");
            dgvServices.Columns.Add("colThanhTien", "Thành tiền");
            dgvServices.Columns.Add("colNgay", "Ngày sử dụng");

            // Lấy tất cả booking của khách hàng
            var bookings = _bookingBUS.GetBookings(maKH: _selectedGuest.MaKH);
            if (bookings.Success)
            {
                foreach (var booking in bookings.Data)
                {
                    var details = _bookingDetailBUS.GetBookingDetails(maDP: booking.MaDP);
                    if (details.Success)
                    {
                        foreach (var detail in details.Data)
                        {
                            var services = _serviceDetailBUS.GetServiceDetails(maCTDP: detail.MaCTDP);
                            if (services.Success)
                            {
                                foreach (var service in services.Data)
                                {
                                    dgvServices.Rows.Add(
                                        service.MaCTDV,
                                        service.MaDV,
                                        service.SoLuong ?? 1,
                                        service.Gia?.ToString("N0") ?? "0",
                                        service.ThanhTien?.ToString("N0") ?? "0",
                                        service.CreatedAt.ToString("dd/MM/yyyy") ?? ""
                                    );
                                }
                            }
                        }
                    }
                }
            }
        }

        private void LoadEventHistory()
        {
            dgvEvents.Rows.Clear();
            dgvEvents.Columns.Clear();

            dgvEvents.Columns.Add("colMaCTSK", "Mã CTSK");
            dgvEvents.Columns.Add("colMaSK", "Mã sự kiện");
            dgvEvents.Columns.Add("colNgayBD", "Ngày bắt đầu");
            dgvEvents.Columns.Add("colNgayKT", "Ngày kết thúc");
            dgvEvents.Columns.Add("colTongKhach", "Tổng khách");
            dgvEvents.Columns.Add("colThanhTien", "Thành tiền");
            dgvEvents.Columns.Add("colTrangThai", "Trạng thái");

            var events = _eventDetailBUS.GetEventDetails(maKH: _selectedGuest.MaKH);
            if (events.Success)
            {
                foreach (var evt in events.Data)
                {
                    dgvEvents.Rows.Add(
                        evt.MaCTSK,
                        evt.MaSK,
                        evt.NgayBD.ToString("dd/MM/yyyy") ?? "",
                        evt.NgayKT.ToString("dd/MM/yyyy") ?? "",
                        evt.TongKhach ?? 0,
                        evt.ThanhTien.ToString("N0") ?? "0",
                        evt.TrangThai
                    );
                }
            }
        }
    }
}
