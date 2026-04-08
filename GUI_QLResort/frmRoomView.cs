using BUS_QLResort;
using ET_QLResort;
using DAL_QLResort.Resort_F;
using DAL_QLResort.RoomTypeDAL;
using GUI_QLResort.Styles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI_QLResort
{
    public partial class frmRoomView : AppBaseForm
    {
        private readonly RoomBUS roomBUS = new RoomBUS();
        private readonly RoomTypeBUS roomTypeBUS = new RoomTypeBUS();
        private readonly BookingBUS bookingBUS = new BookingBUS();
        private readonly BookingDetailBUS bookingDetailBUS = new BookingDetailBUS();
        private readonly ResortDAL resortDAL = new ResortDAL();

        private ViewMode currentViewMode = ViewMode.Card;
        private Dictionary<string, RoomType> roomTypeDict = new Dictionary<string, RoomType>();

        public frmRoomView()
        {
            InitializeComponent();
            AppTheme.ApplyForm(this);
            InitializeViewMode();
            dgvRooms.AutoGenerateColumns = false;
            AppTheme.StyleDataGridView(dgvRooms);
        }

        private void frmRoomView_Load(object sender, EventArgs e)
        {
            LoadFilters();
            LoadRooms();
        }

        private void InitializeViewMode()
        {
            if (currentViewMode == ViewMode.Card)
            {
                btnToggleView.Text = "Grid View";
                dgvRooms.Visible = false;
                flowPanel.Visible = true;
            }
            else
            {
                btnToggleView.Text = "Card View";
                dgvRooms.Visible = true;
                flowPanel.Visible = false;
            }
        }


        private void LoadFilters()
        {
            // Load Resorts
            cbFilterResort.Items.Clear();

            if (Session_Now.IsQuanLy || Session_Now.IsAdmin)
            {
                // Admin/Quản lý: Xem được tất cả hoặc chọn chi nhánh khác
                cbFilterResort.Items.Add("Tất cả chi nhánh");
                var resorts = resortDAL.GetResort(isActive: true);
                if (resorts.Success)
                {
                    foreach (DataRow row in resorts.Data.Rows)
                    {
                        cbFilterResort.Items.Add(new { MaCN = row["MaCN"].ToString(), TenCN = row["TenCN"].ToString() });
                    }
                }
                cbFilterResort.DisplayMember = "TenCN";
                cbFilterResort.ValueMember = "MaCN";
                cbFilterResort.SelectedIndex = 0; // Mặc định "Tất cả"
                cbFilterResort.Enabled = true;
            }
            else
            {
                // Nhân viên: Chỉ xem chi nhánh hiện tại, không được chọn khác
                var resorts = resortDAL.GetResort(isActive: true);
                string currentCNName = "Chi nhánh hiện tại";
                if (resorts.Success)
                {
                   foreach(DataRow row in resorts.Data.Rows)
                   {
                       if(row["MaCN"].ToString() == Session_Now.CurrentResort)
                       {
                           currentCNName = row["TenCN"].ToString();
                           break;
                       }
                   }
                }

                cbFilterResort.Items.Add(new { MaCN = Session_Now.CurrentResort, TenCN = currentCNName });
                cbFilterResort.DisplayMember = "TenCN";
                cbFilterResort.ValueMember = "MaCN";
                cbFilterResort.SelectedIndex = 0;
                cbFilterResort.Enabled = false; // Khóa combobox
            }

            // Load Room Types
            var roomTypes = roomTypeBUS.GetRoomTypes(isActive: true);
            if (roomTypes.Success)
            {
                roomTypeDict.Clear();
                cbFilterRoomType.Items.Add("Tất cả loại phòng");
                cbFilterRoomType.Items.Add("Nguyên căn"); 
                foreach (var rt in roomTypes.Data)
                {
                    roomTypeDict[rt.MaLP] = rt;
                    cbFilterRoomType.Items.Add(new { MaLP = rt.MaLP, TenLP = rt.TenLP });
                }
                cbFilterRoomType.DisplayMember = "TenLP";
                cbFilterRoomType.ValueMember = "MaLP";
                cbFilterRoomType.SelectedIndex = 0;
            }

            // Load Status
            cbFilterStatus.Items.Add("Tất cả trạng thái");
            cbFilterStatus.Items.Add("Trống");
            cbFilterStatus.Items.Add("Đã đặt");
            cbFilterStatus.Items.Add("Đang sử dụng");
            cbFilterStatus.Items.Add("Bảo trì");
            cbFilterStatus.Items.Add("Đang dọn");
            cbFilterStatus.Items.Add("Ngưng hoạt động");
            cbFilterStatus.SelectedIndex = 0;
        }

        private void LoadRooms()
        {
            string maCN = GetSelectedMaCN();
            string maLP = GetSelectedMaLP();
            string trangThai = GetSelectedStatus();
            bool? isNguyenCan = GetSelectedIsNguyenCan();

            var result = roomBUS.GetRooms(maCN: maCN, maLP: maLP, trangThai: trangThai, isActive: true);
            if (!result.Success)
            {
                MessageBox.Show($"Lỗi khi load phòng: {result.ErrorMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lọc nguyên căn nếu được chọn
            var filteredRooms = result.Data;
            if (isNguyenCan.HasValue)
            {
                filteredRooms = result.Data.Where(r =>
                {
                    if (roomTypeDict.ContainsKey(r.MaLP))
                    {
                        var roomType = roomTypeDict[r.MaLP];
                        return roomType.IsNhaNguyenCan == isNguyenCan.Value;
                    }
                    return false;
                }).ToList();
            }

            if (currentViewMode == ViewMode.Card)
                ShowCardView(filteredRooms);
            else
                ShowGridView(filteredRooms);

            UpdateRoomCount(filteredRooms.Count);
        }


        private void ShowCardView(List<Room> rooms)
        {
            flowPanel.Controls.Clear();
            dgvRooms.Visible = false;
            flowPanel.Visible = true;

            foreach (var room in rooms)
            {
                RoomCardControl card = new RoomCardControl();
                RoomType roomType = roomTypeDict.ContainsKey(room.MaLP) ? roomTypeDict[room.MaLP] : null;
                card.SetData(room);
                card.RoomClicked += Card_RoomClicked;
                card.RoomRightClicked += Card_RoomRightClicked;
                card.Margin = new Padding(10);
                flowPanel.Controls.Add(card);
            }
        }

        private void ShowGridView(List<Room> rooms)
        {
            flowPanel.Visible = false;
            dgvRooms.Visible = true;
            dgvRooms.AutoGenerateColumns = false;

            var dataTable = new DataTable();
            dataTable.Columns.Add("Mã Phòng");
            dataTable.Columns.Add("Số Phòng");
            dataTable.Columns.Add("Loại Phòng");
            dataTable.Columns.Add("Chi Nhánh");
            dataTable.Columns.Add("Vị Trí");
            dataTable.Columns.Add("Trạng Thái");
            dataTable.Columns.Add("Giá Theo Ngày", typeof(decimal));
            dataTable.Columns.Add("Sức Chứa", typeof(int));

            foreach (var room in rooms)
            {
                var roomType = roomTypeDict.ContainsKey(room.MaLP) ? roomTypeDict[room.MaLP] : null;
                dataTable.Rows.Add(
                    room.MaPhong,
                    room.SoPhong,
                    roomType?.TenLP ?? "N/A",
                    room.MaCN,
                    room.ViTri,
                    room.TrangThai,
                    roomType?.GiaTheoNgay ?? 0,
                    roomType?.SucChuaToiDa ?? 0
                );
            }

            dgvRooms.DataSource = dataTable;
        }

        private Room _selectedRoomForContextMenu;

        private void Card_RoomClicked(object sender, Room room)
        {
            _selectedRoomForContextMenu = room;
            if (room.TrangThai == "Trống" || string.IsNullOrEmpty(room.TrangThai))
                OpenBookingForm(room);
        }

        private void Card_RoomRightClicked(object sender, Room room)
        {
            if (room == null) return;

            _selectedRoomForContextMenu = room;
            if (sender is Control control)
            {
                var relativePoint = control.PointToClient(Control.MousePosition);
                contextMenuRoom.Show(control, relativePoint);
            }
            else
            {
                contextMenuRoom.Show(Cursor.Position);
            }
        }

        private void DgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count > 0)
            {
                var selectedRow = dgvRooms.SelectedRows[0];
                string maPhong = selectedRow.Cells["Mã Phòng"].Value?.ToString();

                if (!string.IsNullOrEmpty(maPhong))
                {
                    var result = roomBUS.GetRooms(maPhong: maPhong);
                    if (result.Success && result.Data.Count > 0)
                    {
                        _selectedRoomForContextMenu = result.Data[0];                    
                    }
                }
            }
        }

        private void DgvRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvRooms.Rows[e.RowIndex];
                string maPhong = selectedRow.Cells["Mã Phòng"].Value?.ToString();

                if (!string.IsNullOrEmpty(maPhong))
                {
                    var result = roomBUS.GetRooms(maPhong: maPhong);
                    if (result.Success && result.Data.Count > 0)
                    {
                        _selectedRoomForContextMenu = result.Data[0];
                        // Ensure row is selected
                        dgvRooms.Rows[e.RowIndex].Selected = true;
                    }
                }
            }
        }

        private void dgvRooms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvRooms.Rows[e.RowIndex];
                string maPhong = row.Cells["Mã Phòng"].Value.ToString();

                var result = roomBUS.GetRooms(maPhong: maPhong);
                if (result.Success && result.Data.Count > 0)
                {
                    _selectedRoomForContextMenu = result.Data[0];
                    OpenBookingForm(result.Data[0]);
                }
            }
        }

        private void dgvRooms_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dgvRooms.HitTest(e.X, e.Y);
                if (hit.RowIndex >= 0)
                {
                    dgvRooms.ClearSelection();
                    dgvRooms.Rows[hit.RowIndex].Selected = true;
                    var row = dgvRooms.Rows[hit.RowIndex];
                    string maPhong = row.Cells["Mã Phòng"].Value.ToString();

                    var result = roomBUS.GetRooms(maPhong: maPhong);
                    if (result.Success && result.Data.Count > 0)
                    {
                        _selectedRoomForContextMenu = result.Data[0];
                    }
                }
            }
        }

        private void flowPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Clicking on empty area should hide context menu
                contextMenuRoom.Hide();
            }
        }

        private void OpenBookingForm(Room room, Booking booking = null, BookingDetail detail = null)
        {
            // Mở trực tiếp trong Panel main (User xác nhận form không chạy độc lập)
            if (this.ParentForm is frmMain mainForm)
            {
                var bookingForm = new frmBooking(room, booking, detail);
                bookingForm.FormClosed += (s, args) => 
                {
                    if (bookingForm.DialogResult == DialogResult.OK)
                    {
                        LoadRooms();
                    }
                };
                mainForm.OpenFormInPanel(bookingForm);
            }
        }

        private void btnToggleView_Click(object sender, EventArgs e)
        {
            currentViewMode = currentViewMode == ViewMode.Card ? ViewMode.Grid : ViewMode.Card;
            InitializeViewMode();
            LoadRooms();
        }


        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private string GetSelectedMaCN()
        {
            if (cbFilterResort.SelectedItem != null)
            {
                // Nếu là "Tất cả chi nhánh" (thường là string), return null
                if (cbFilterResort.SelectedItem is string) return null;

                try
                {
                    dynamic selected = cbFilterResort.SelectedItem;
                    return selected.MaCN;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        private string GetSelectedMaLP()
        {
            if (cbFilterRoomType.SelectedIndex > 0 && cbFilterRoomType.SelectedItem != null)
            {
                try
                {
                    // Nếu chọn "Nguyên căn", trả về null để lọc sau
                    if (cbFilterRoomType.SelectedItem.ToString() == "Nguyên căn")
                        return null;
                    
                    dynamic selected = cbFilterRoomType.SelectedItem;
                    return selected.MaLP;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        private bool? GetSelectedIsNguyenCan()
        {
            if (cbFilterRoomType.SelectedIndex > 0 && cbFilterRoomType.SelectedItem != null)
            {
                try
                {
                    // Nếu chọn "Nguyên căn", trả về true
                    if (cbFilterRoomType.SelectedItem.ToString() == "Nguyên căn")
                        return true;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        private string GetSelectedStatus()
        {
            return cbFilterStatus.SelectedIndex > 0 ? cbFilterStatus.SelectedItem.ToString() : null;
        }

        private void UpdateRoomCount(int count)
        {
            lblRoomCount.Text = $"Tìm thấy {count} phòng";
            lblRoomCount.ForeColor = Color.DarkGoldenrod;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }

        // Context Menu Handlers

        private void MenuItemCheckIn_Click(object sender, EventArgs e)
        {
            if (_selectedRoomForContextMenu != null)
            {
                if (!TryGetActiveBooking(out var booking, out var detail, out string debugInfo))
                {
                    // Nếu phòng đang Trống mà bấm Check-in -> Coi như là khách vãng lai -> Mở form đặt phòng mới
                    string status = _selectedRoomForContextMenu.TrangThai;
                    if (string.IsNullOrEmpty(status) || status == "Trống" || status == "Đã dọn")
                    {
                        OpenBookingForm(_selectedRoomForContextMenu);
                        return;
                    }

                    MessageBox.Show($"Không tìm thấy thông tin đặt phòng hợp lệ để check in.\n\nDebug Info:\n{debugInfo}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (detail.TrangThai == "Đặt" && detail.NgayDen.HasValue && detail.NgayDen.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show($"Đơn đặt phòng {booking.MaDP} (Ngày đến: {detail.NgayDen:dd/MM/yyyy}) đã quá hạn.\nHệ thống sẽ tự động hủy và đặt lại trạng thái Trống.", 
                        "Đơn quá hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    bookingDetailBUS.UpdateBookingDetail(
                        detail.MaCTDP,
                        "Hủy",
                        detail.NgayDen,
                        DateTime.Now,
                        detail.NguoiLon,
                        detail.TreEm,
                        detail.GiaPhong,
                        detail.ThanhTien,
                        false 
                    );

                    roomBUS.UpdateRoom(
                        _selectedRoomForContextMenu.MaPhong,
                        _selectedRoomForContextMenu.MaCN,
                        _selectedRoomForContextMenu.MaLP,
                        _selectedRoomForContextMenu.SoPhong,
                        _selectedRoomForContextMenu.ViTri,
                        "Trống",
                        _selectedRoomForContextMenu.GhiChu,
                        _selectedRoomForContextMenu.IsActive
                    );

                    LoadRooms();
                    
                    OpenBookingForm(_selectedRoomForContextMenu);
                    return;
                }

                OpenBookingForm(_selectedRoomForContextMenu, booking, detail); 
            }
        }

        private void MenuItemDatPhong_Click(object sender, EventArgs e)
        {
            if (_selectedRoomForContextMenu != null)
            {
                OpenBookingForm(_selectedRoomForContextMenu);
            }
        }

        private void MenuItemDonPhong_Click(object sender, EventArgs e)
        {
            if (_selectedRoomForContextMenu != null)
            {
                // Update room status to "Trống"
                var result = roomBUS.UpdateRoom(
                    _selectedRoomForContextMenu.MaPhong,
                    _selectedRoomForContextMenu.MaCN,
                    _selectedRoomForContextMenu.MaLP,
                    _selectedRoomForContextMenu.SoPhong,
                    _selectedRoomForContextMenu.ViTri,
                    "Trống",
                    _selectedRoomForContextMenu.GhiChu,
                    _selectedRoomForContextMenu.IsActive
                );

                if (result.Success)
                {
                    MessageBox.Show("Đã cập nhật trạng thái phòng thành 'Trống'!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
                }
                else
                {
                    MessageBox.Show($"Lỗi: {result.ErrorMessage}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuItemSuaChuaPhong_Click(object sender, EventArgs e)
        {
            if (_selectedRoomForContextMenu != null)
            {
                // Update room status to "Bảo trì"
                var result = roomBUS.UpdateRoom(
                    _selectedRoomForContextMenu.MaPhong,
                    _selectedRoomForContextMenu.MaCN,
                    _selectedRoomForContextMenu.MaLP,
                    _selectedRoomForContextMenu.SoPhong,
                    _selectedRoomForContextMenu.ViTri,
                    "Bảo trì",
                    _selectedRoomForContextMenu.GhiChu,
                    _selectedRoomForContextMenu.IsActive
                );

                if (result.Success)
                {
                    MessageBox.Show("Đã cập nhật trạng thái phòng thành 'Bảo trì'!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
                }
                else
                {
                    MessageBox.Show($"Lỗi: {result.ErrorMessage}", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuItemHuyDatPhong_Click(object sender, EventArgs e)
        {
            if (_selectedRoomForContextMenu == null) return;

             // 1. Check active booking
            Booking booking;
            BookingDetail detail;
            string debugInfo;

            if (!TryGetActiveBooking(out booking, out detail, out debugInfo))
            {
                MessageBox.Show("Không tìm thấy đơn đặt phòng đang hoạt động (Đặt/Đang sử dụng) cho phòng này.", 
                    "Không thể hủy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Confirm Cancellation
            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn HỦY đơn đặt phòng {booking.MaDP} của khách {booking.TenKH}?\n" +
                $"Ngày đặt: {detail.NgayDen:dd/MM} - {detail.NgayDi:dd/MM}",
                "Xác nhận hủy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try 
                {
                      // 3. Update Booking Detail Status -> "Hủy"
                      var updateDetailResult = bookingDetailBUS.UpdateBookingDetail(
                            detail.MaCTDP, 
                            "Hủy", 
                            detail.NgayDen, 
                            detail.NgayDi, 
                            detail.NguoiLon, 
                            detail.TreEm, 
                            detail.GiaPhong, 
                            detail.ThanhTien, 
                            true
                      );

                      if (!updateDetailResult.Success) 
                         throw new Exception("Lỗi hủy chi tiết: " + updateDetailResult.ErrorMessage);

                      // 4. Update Room Status -> "Trống"
                       var updateRoomResult = roomBUS.UpdateRoomStatus(_selectedRoomForContextMenu.MaPhong, "Trống");
                       if (!updateRoomResult.Success)
                          throw new Exception("Lỗi cập nhật phòng: " + updateRoomResult.ErrorMessage);

                       // 5. Success
                       MessageBox.Show("Đã hủy đặt phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                       //  Update header status if all details are cancelled
                       var allDetails = bookingDetailBUS.GetBookingDetails(maDP: booking.MaDP);
                       if (allDetails.Success && allDetails.Data.All(d => d.TrangThai == "Hủy"))
                       {
                           bookingBUS.UpdateBooking(booking.MaDP, "Hủy", booking.GhiChu, null);
                       }

                       LoadRooms();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Lỗi trong quá trình hủy: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MenuItemTraPhong_Click(object sender, EventArgs e)
        {
            if (_selectedRoomForContextMenu != null)
            {
                if (!TryGetActiveBooking(out var booking, out var detail, out string debugInfo))
                {
                    MessageBox.Show($"Không tìm thấy thông tin đặt phòng để trả.\n\nDebug Info:\n{debugInfo}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try {
                    string logPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "debug_invoice.txt");
                    System.IO.File.AppendAllText(logPath, $"[{DateTime.Now}] Invoice Generation Started\n");
                    System.IO.File.AppendAllText(logPath, $"[{DateTime.Now}] Selected Booking: {booking.MaDP}, Detail: {detail.MaCTDP}\n");
                } catch {}

                // Tạo hoặc lấy hóa đơn cho booking này
                var invoiceBUS = new InvoiceBUS();
                var allInvoices = invoiceBUS.GetInvoices(maDP: booking.MaDP);
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

                // Nếu chưa có hóa đơn, tạo mới
                if (string.IsNullOrEmpty(maHD))
                {
                    // Tính tổng tiền
                    var roomBUS = new RoomBUS();
                    var roomResult = roomBUS.GetRooms(maPhong: detail.MaPhong);
                    decimal roomPrice = roomResult.Success && roomResult.Data.Count > 0 
                        ? (roomResult.Data[0].GiaTheoNgay ?? detail.GiaPhong ?? 0) 
                        : (detail.GiaPhong ?? 0);
                    
                    int nights = (int)((detail.NgayDi ?? DateTime.Now) - (detail.NgayDen ?? DateTime.Now)).TotalDays;
                    nights = Math.Max(1, nights);
                    decimal roomTotal = roomPrice * nights;

                    // Lấy dịch vụ
                    var serviceDetailBUS = new ServiceDetailBUS();
                    var services = serviceDetailBUS.GetServiceDetails(maCTDP: detail.MaCTDP, isActive: true);
                    decimal serviceTotal = services.Success ? services.Data.Sum(s => s.ThanhTien ?? 0) : 0;
                    
                    decimal grandTotal = roomTotal + serviceTotal;

                    // Tạo hóa đơn
                    var invoiceResult = invoiceBUS.CreateInvoice(
                        booking.MaDP,
                        booking.MaKH,
                        Session_Now.CurrentUser,
                        _selectedRoomForContextMenu.MaCN,
                        grandTotal);

                    if (!invoiceResult.Success)
                    {
                        MessageBox.Show($"Không thể tạo hóa đơn: {invoiceResult.ErrorMessage}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    maHD = invoiceResult.Data.MaHD;

                    // Thêm chi tiết hóa đơn
                    invoiceBUS.AddInvoiceDetail(maHD, $"Tiền phòng {_selectedRoomForContextMenu.SoPhong}", nights, roomPrice);
                    
                    if (services.Success)
                    {
                        var serviceBUS = new ServiceBUS(); //  Init ServiceBUS to fetch names
                        foreach (var service in services.Data)
                        {
                            string serviceName = $"Dịch vụ: {service.MaDV}";
                            var serviceInfo = serviceBUS.GetServices(maDV: service.MaDV).Data.FirstOrDefault();
                            if (serviceInfo != null)
                            {
                                serviceName = serviceInfo.TenDV;
                            }

                            invoiceBUS.AddInvoiceDetail(
                                maHD,
                                serviceName,
                                service.SoLuong ?? 1,
                                service.Gia ?? 0);
                        }
                    }
                }

                // Mở form thanh toán với hóa đơn đã chọn
                var paymentForm = new frmPayment(maHD);
                
                paymentForm.FormClosed += (s, args) => 
                {
                    if (paymentForm.DialogResult == DialogResult.OK)
                    {
                        // Sau khi thanh toán thành công, cập nhật trạng thái
                        var bookingDetailBUS = new BookingDetailBUS();
                        bookingDetailBUS.UpdateBookingDetail(
                            detail.MaCTDP,
                            "Hoàn tất",
                            detail.NgayDen,
                            DateTime.Now,
                            detail.NguoiLon ?? 2,
                            detail.TreEm ?? 0,
                            detail.GiaPhong,
                            detail.ThanhTien);

                        var bookingBUS = new BookingBUS();
                        bookingBUS.UpdateBooking(booking.MaDP, "Hoàn tất", booking.GhiChu, true);

                        // Cập nhật trạng thái phòng thành "Đang dọn"
                        var roomBUS2 = new RoomBUS();
                        roomBUS2.UpdateRoom(
                            _selectedRoomForContextMenu.MaPhong,
                            _selectedRoomForContextMenu.MaCN,
                            _selectedRoomForContextMenu.MaLP,
                            _selectedRoomForContextMenu.SoPhong,
                            _selectedRoomForContextMenu.ViTri,
                            "Đang dọn",
                            _selectedRoomForContextMenu.GhiChu,
                            _selectedRoomForContextMenu.IsActive);

                        LoadRooms();
                    }
                };

                if (this.ParentForm is frmMain mainForm)
                {
                     mainForm.OpenFormInPanel(paymentForm);
                }
            }
        }

        private void MenuItemCapNhatThongTin_Click(object sender, EventArgs e)
        {
            if (_selectedRoomForContextMenu != null)
            {
                if (!TryGetActiveBooking(out var booking, out var detail, out string debugInfo))
                {
                    MessageBox.Show($"Phòng hiện chưa có đặt phòng đang xử lý để cập nhật.\n\nDebug Info:\n{debugInfo}", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var bookingForm = new frmBooking(_selectedRoomForContextMenu, booking, detail);
                bookingForm.FormClosed += (s, args) => 
                {
                    if (bookingForm.DialogResult == DialogResult.OK)
                    {
                        LoadRooms();
                    }
                };

                if (this.ParentForm is frmMain mainForm)
                {
                    mainForm.OpenFormInPanel(bookingForm);
                }
            }
        }

        private bool TryGetActiveBooking(out Booking booking, out BookingDetail detail, out string debugInfo)
        {
            booking = null;
            detail = null;
            debugInfo = "";
            var sb = new System.Text.StringBuilder();

            if (_selectedRoomForContextMenu == null || string.IsNullOrWhiteSpace(_selectedRoomForContextMenu.MaPhong))
            {
                debugInfo = "Selected room is null or Invalid.";
                return false;
            }

            try
            {
                // Tìm trong CTDatPhong theo MaPhong
                var detailResult = bookingDetailBUS.GetBookingDetails(
                    maPhong: _selectedRoomForContextMenu.MaPhong);
                
                if (!detailResult.Success || detailResult.Data == null || detailResult.Data.Count == 0)
                {
                    debugInfo = $"No Booking Details found for Room {_selectedRoomForContextMenu.MaPhong}.";
                    return false;
                }

                sb.AppendLine($"Found {detailResult.Data.Count} details.");

                // Tìm booking detail đang hoạt động - kiểm tra nhiều trạng thái
                var activeStatuses = new[] { "Đặt", "Đang sử dụng", "Đang Sử Dụng", "ĐANG SỬ DỤNG", "Đã đặt", "Đã Đặt" };
                var today = DateTime.Now.Date;

                detail = detailResult.Data
                    .Where(d => 
                    {
                        if (d.TrangThai == null) {
                            sb.AppendLine("Detail Has Null Status.");
                            return false;
                        }

                        string normalizedStatus = d.TrangThai.Trim();
                        
                        bool isActiveStatus = activeStatuses.Any(s => 
                            normalizedStatus.Equals(s, StringComparison.OrdinalIgnoreCase));                                       
                        bool isActive = d.IsActive == true || normalizedStatus.Equals("Đang sử dụng", StringComparison.OrdinalIgnoreCase);

                        if (!isActiveStatus || !isActive) {
                             sb.AppendLine($"Skipped {d.MaCTDP}: Status={normalizedStatus}, Active={isActive}");
                        }

                        return isActiveStatus && isActive;
                    })
                    .OrderByDescending(d => 
                    {
                        string status = d.TrangThai?.Trim() ?? "";
                        if (status.Equals("Đang sử dụng", StringComparison.OrdinalIgnoreCase)) return 3;
                        if (status.Equals("Đặt", StringComparison.OrdinalIgnoreCase)) return 2;
                        return 1;
                    })
                    .ThenByDescending(d => d.NgayDen ?? DateTime.MinValue)
                    .FirstOrDefault();

                if (detail == null || string.IsNullOrWhiteSpace(detail.MaDP))
                {
                    debugInfo = sb.ToString() + "không tìm thấy.";
                    return false;
                }

                // Bước 2: Lấy booking từ MaDP
                var bookingResult = bookingBUS.GetBookings(maDP: detail.MaDP);
                if (!bookingResult.Success || bookingResult.Data == null || bookingResult.Data.Count == 0)
                {
                    debugInfo = $"Chi tiết đạt phòng thấy {detail.MaCTDP}) nhưng không tìm thấy Booking ({detail.MaDP}) .";
                    return false;
                }
                
                booking = bookingResult.Data[0];
                
                
                if (booking.TrangThai == "Hủy" || booking.TrangThai == "Hoàn tất")
                {
                    debugInfo = $"đặt phòng tìm thấy  ({booking.MaDP}) nhưng trạng thái '{booking.TrangThai}' không đúng.";
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                 debugInfo = $"Exception: {ex.Message}";
                 return false;
            }
        }

        
    }

    public enum ViewMode
    {
        Card,
        Grid
    }
}
