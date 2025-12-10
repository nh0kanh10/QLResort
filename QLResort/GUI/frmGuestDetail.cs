using QLResort.BUS;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmGuestDetail : Form
    {
        private readonly GuestBUS _guestBUS = new GuestBUS();
        private readonly BookingBUS _bookingBUS = new BookingBUS();
        private readonly BookingDetailBUS _bookingDetailBUS = new BookingDetailBUS();
        private readonly ServiceDetailBUS _serviceDetailBUS = new ServiceDetailBUS();
        private readonly EventDetailBUS _eventDetailBUS = new EventDetailBUS();
        private readonly GuestTypeBUS _guestTypeBUS = new GuestTypeBUS();
        private readonly InvoiceBUS _invoiceBUS = new InvoiceBUS();
        private readonly PaymentBUS _paymentBUS = new PaymentBUS();

        private QLResort.Core.Model.Guest _selectedGuest;
        private TabControl tabControl;
        private DataGridView dgvBookings;
        private DataGridView dgvServices;
        private DataGridView dgvEvents;
        private Label lblGuestInfo;
        private Label lblPoints;
        private Label lblGuestType;
        private TextBox txtSearchGuest;

        public frmGuestDetail()
        {
            InitializeComponent();
            AppTheme.ApplyForm(this);
            BuildLayout();
        }

        private void BuildLayout()
        {
            this.Text = "Thông tin khách hàng chi tiết";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Header panel
            var headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.FromArgb(41, 128, 185)
            };

            var lblTitle = new Label
            {
                Text = "👤 THÔNG TIN KHÁCH HÀNG CHI TIẾT",
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Cambria", 16, FontStyle.Bold),
                ForeColor = Color.White
            };
            headerPanel.Controls.Add(lblTitle);

            // Search panel
            var searchPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 50,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(20, 10, 20, 10)
            };

            var lblSearch = new Label
            {
                Text = "Tìm khách hàng:",
                Width = 150,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Cambria", 10, FontStyle.Bold)
            };

            txtSearchGuest = new TextBox
            {
                Width = 200,
                Text = "Nhập mã KH, CCCD, SĐT hoặc Email"
            };
            txtSearchGuest.KeyDown += TxtSearchGuest_KeyDown;

            var btnSearch = new Button
            {
                Text = "🔍 Tìm",
                Width = 100,
                Height = 30
            };
            AppTheme.StylePrimaryButton(btnSearch);
            btnSearch.Click += BtnSearch_Click;

            searchPanel.Controls.Add(lblSearch);
            searchPanel.Controls.Add(txtSearchGuest);
            searchPanel.Controls.Add(btnSearch);
            headerPanel.Controls.Add(searchPanel);

            Controls.Add(headerPanel);

            // Guest info panel
            var infoPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.FromArgb(236, 240, 241)
            };

            lblGuestInfo = new Label
            {
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Cambria", 11),
                Padding = new Padding(20, 10, 20, 10)
            };

            var infoBottomPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(20, 5, 20, 5)
            };

            lblPoints = new Label
            {
                Text = "Điểm tích lũy: 0",
                Width = 200,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Cambria", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 204, 113)
            };

            lblGuestType = new Label
            {
                Text = "Loại khách hàng: --",
                Width = 300,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Cambria", 10, FontStyle.Bold)
            };

            infoBottomPanel.Controls.Add(lblPoints);
            infoBottomPanel.Controls.Add(lblGuestType);

            infoPanel.Controls.Add(infoBottomPanel);
            infoPanel.Controls.Add(lblGuestInfo);
            Controls.Add(infoPanel);

            // Tab control
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Padding = new Point(10, 5)
            };

            // Tab 1: Lịch sử đặt phòng
            var tabBookings = new TabPage("📅 Lịch sử đặt phòng");
            dgvBookings = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            AppTheme.StyleDataGridView(dgvBookings);
            tabBookings.Controls.Add(dgvBookings);
            tabControl.TabPages.Add(tabBookings);

            // Tab 2: Lịch sử dịch vụ
            var tabServices = new TabPage("🛎 Lịch sử dịch vụ");
            dgvServices = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            AppTheme.StyleDataGridView(dgvServices);
            tabServices.Controls.Add(dgvServices);
            tabControl.TabPages.Add(tabServices);

            // Tab 3: Lịch sử sự kiện
            var tabEvents = new TabPage("🎉 Lịch sử sự kiện");
            dgvEvents = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            AppTheme.StyleDataGridView(dgvEvents);
            tabEvents.Controls.Add(dgvEvents);
            tabControl.TabPages.Add(tabEvents);

            Controls.Add(tabControl);
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

        private void SearchGuest()
        {
            string searchText = txtSearchGuest.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tìm khách hàng theo nhiều tiêu chí
                var result = _guestBUS.GetGuests(
                    maKH: searchText,
                    id: searchText,
                    sdt: searchText
                    );

                if (!result.Success || result.Data.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy khách hàng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _selectedGuest = result.Data[0];
                LoadGuestDetails();
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

                // Load điểm tích lũy (từ bảng KhachHangDiem nếu có)
                // TODO: Implement điểm tích lũy
                lblPoints.Text = "Điểm tích lũy: 0"; // Tạm thời

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

