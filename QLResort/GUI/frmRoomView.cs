using QLResort.BLL;
using QLResort.Core.Model;
using QLResort.DAL.Resort_F;
using QLResort.DAL.RoomTypeDAL;
using QLResort.GUI.Styles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmRoomView : Form
    {
        private readonly RoomBLL roomBLL = new RoomBLL();
        private readonly RoomTypeBLL roomTypeBLL = new RoomTypeBLL();
        private readonly BookingBLL bookingBLL = new BookingBLL();
        private readonly BookingDetailBLL bookingDetailBLL = new BookingDetailBLL();
        private readonly ResortDAL resortDAL = new ResortDAL();

        private ViewMode currentViewMode = ViewMode.Card;
        private Dictionary<string, RoomType> roomTypeDict = new Dictionary<string, RoomType>();

        public frmRoomView()
        {
            InitializeComponent();
            AppTheme.ApplyForm(this);
            InitializeViewMode();
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
                btnToggleView.Text = "📋 Grid View";
                dgvRooms.Visible = false;
                flowPanel.Visible = true;
            }
            else
            {
                btnToggleView.Text = "🃏 Card View";
                dgvRooms.Visible = true;
                flowPanel.Visible = false;
            }
        }


        private void LoadFilters()
        {
            // Load Resorts
            var resorts = resortDAL.GetResort(isActive: true);
            if (resorts.Success)
            {
                cbFilterResort.Items.Add("Tất cả chi nhánh");
                foreach (DataRow row in resorts.Data.Rows)
                {
                    cbFilterResort.Items.Add(new { MaCN = row["MaCN"].ToString(), TenCN = row["TenCN"].ToString() });
                }
                cbFilterResort.DisplayMember = "TenCN";
                cbFilterResort.ValueMember = "MaCN";
                cbFilterResort.SelectedIndex = 0;
            }

            // Load Room Types
            var roomTypes = roomTypeBLL.GetRoomTypes(isActive: true);
            if (roomTypes.Success)
            {
                roomTypeDict.Clear();
                cbFilterRoomType.Items.Add("Tất cả loại phòng");
                cbFilterRoomType.Items.Add("🏠 Nguyên căn"); // Thêm filter nguyên căn
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

            var result = roomBLL.GetRooms(maCN: maCN, maLP: maLP, trangThai: trangThai, isActive: true);
            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage);
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

            InitializeViewMode(); // <-- Đảm bảo UI chỉ hiển thị dạng cần thiết
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
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.ReadOnly = true;

            // Định dạng cột giá
            if (dgvRooms.Columns["Giá Theo Ngày"] != null)
            {
                dgvRooms.Columns["Giá Theo Ngày"].DefaultCellStyle.Format = "N0";
                dgvRooms.Columns["Giá Theo Ngày"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Định dạng màu sắc - Modern resort style
            dgvRooms.EnableHeadersVisualStyles = false;
            dgvRooms.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 32, 47);
            dgvRooms.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRooms.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvRooms.ColumnHeadersHeight = 45;

            dgvRooms.RowTemplate.DefaultCellStyle.BackColor = Color.White;
            dgvRooms.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(52, 73, 94);
            dgvRooms.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 215, 0);
            dgvRooms.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 32, 47);
            dgvRooms.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);
            dgvRooms.GridColor = Color.FromArgb(230, 235, 240);

            // Add event handlers for selection
            dgvRooms.SelectionChanged += DgvRooms_SelectionChanged;
            dgvRooms.CellClick += DgvRooms_CellClick;
        }

        private Room _selectedRoomForContextMenu;

        private void Card_RoomClicked(object sender, Room room)
        {
            _selectedRoomForContextMenu = room;
            if(room.TrangThai == "")
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
                    var result = roomBLL.GetRooms(maPhong: maPhong);
                    if (result.Success && result.Data.Count > 0)
                    {
                        _selectedRoomForContextMenu = result.Data[0];
                        // Room is selected and stored in _selectedRoomForContextMenu
                        // This can be used for context menu actions
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
                    var result = roomBLL.GetRooms(maPhong: maPhong);
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

                var result = roomBLL.GetRooms(maPhong: maPhong);
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

                    var result = roomBLL.GetRooms(maPhong: maPhong);
                    if (result.Success && result.Data.Count > 0)
                    {
                        _selectedRoomForContextMenu = result.Data[0];
                        contextMenuRoom.Show(dgvRooms, e.Location);
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

        private void OpenBookingForm(Room room)
        {
            // Kiểm tra nếu form đang được mở trong panel (không phải dialog)
            if (this.Parent != null)
            {
                // Tìm panel chứa form hiện tại
                var parentPanel = this.Parent as Panel;
                if (parentPanel != null)
                {
                    // Mở frmBooking trong panel mới
                    var bookingForm = new frmBooking(room);
                    bookingForm.TopLevel = false;
                    bookingForm.FormBorderStyle = FormBorderStyle.None;
                    bookingForm.Dock = DockStyle.Fill;
                    
                    parentPanel.Controls.Clear();
                    parentPanel.Controls.Add(bookingForm);
                    bookingForm.Show();
                }
            }
            else
            {
                // Mở dạng dialog nếu form độc lập
                using (var bookingForm = new frmBooking(room))
                {
                    if (bookingForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadRooms(); // Refresh danh sách phòng sau khi đặt
                        MessageBox.Show("Đặt phòng thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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
            if (cbFilterResort.SelectedIndex > 0 && cbFilterResort.SelectedItem != null)
            {
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
                    if (cbFilterRoomType.SelectedItem.ToString() == "🏠 Nguyên căn")
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
                    if (cbFilterRoomType.SelectedItem.ToString() == "🏠 Nguyên căn")
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
            lblRoomCount.Text = $"📊 Tìm thấy {count} phòng";
            lblRoomCount.ForeColor = Color.White;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }

        #region Context Menu Handlers

        private void MenuItemCheckIn_Click(object sender, EventArgs e)
        {
            if (_selectedRoomForContextMenu != null)
            {
                if (!TryGetActiveBooking(out var booking, out var detail))
                {
                    MessageBox.Show("Không tìm thấy thông tin đặt phòng để check in.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mở form booking với thông tin đã có để xác nhận và check in
                using (var bookingForm = new frmBooking(_selectedRoomForContextMenu, booking, detail))
                {
                    if (bookingForm.ShowDialog() == DialogResult.OK)
                    {
                        // Sau khi đóng form booking, cập nhật trạng thái thành "Đang sử dụng"
                        var updateResult = bookingDetailBLL.UpdateBookingDetail(
                            detail.MaCTDP,
                            "Đang sử dụng",
                            detail.NgayDen,
                            detail.NgayDi,
                            detail.NguoiLon,
                            detail.TreEm,
                            detail.GiaPhong,
                            detail.ThanhTien,
                            true
                        );

                        if (updateResult.Success)
                        {
                            // Update room status
                            var roomResult = roomBLL.UpdateRoom(
                                _selectedRoomForContextMenu.MaPhong,
                                _selectedRoomForContextMenu.MaCN,
                                _selectedRoomForContextMenu.MaLP,
                                _selectedRoomForContextMenu.SoPhong,
                                _selectedRoomForContextMenu.ViTri,
                                "Đang sử dụng",
                                _selectedRoomForContextMenu.GhiChu,
                                _selectedRoomForContextMenu.IsActive
                            );

                            if (roomResult.Success)
                            {
                                MessageBox.Show("Check In thành công!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadRooms();
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Lỗi: {updateResult.ErrorMessage}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void MenuItemCheckOut_Click(object sender, EventArgs e)
        {
            if (_selectedRoomForContextMenu != null)
            {
                if (!TryGetActiveBooking(out var booking, out var detail))
                {
                    MessageBox.Show("Không tìm thấy thông tin đặt phòng để check out.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mở form thanh toán thay vì checkout trực tiếp
                using (var paymentForm = new frmPayment())
                {
                    // Tự động tìm hóa đơn chưa thanh toán cho booking này
                    var invoiceBLL = new InvoiceBLL();
                    var invoices = invoiceBLL.GetInvoices(maDP: booking.MaDP, trangThai: "Chưa TT");
                    
                    if (invoices.Success && invoices.Data.Count > 0)
                    {
                        // Có hóa đơn chưa thanh toán, mở form thanh toán
                        paymentForm.ShowDialog();
                    }
                    else
                    {
                        // Chưa có hóa đơn, mở checkout form để tạo hóa đơn và thanh toán
                        using (var checkoutForm = new frmCheckout(_selectedRoomForContextMenu, booking, detail))
                        {
                            if (checkoutForm.ShowDialog() == DialogResult.OK)
                            {
                                LoadRooms();
                            }
                        }
                    }
                }
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
                var result = roomBLL.UpdateRoom(
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
                var result = roomBLL.UpdateRoom(
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

        private void MenuItemTraPhong_Click(object sender, EventArgs e)
        {
            if (_selectedRoomForContextMenu != null)
            {
                if (!TryGetActiveBooking(out var booking, out var detail))
                {
                    MessageBox.Show("Không tìm thấy thông tin đặt phòng để trả.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tạo hoặc lấy hóa đơn cho booking này
                var invoiceBLL = new InvoiceBLL();
                var allInvoices = invoiceBLL.GetInvoices(maDP: booking.MaDP);
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
                    var roomBLL = new RoomBLL();
                    var roomResult = roomBLL.GetRooms(maPhong: detail.MaPhong);
                    decimal roomPrice = roomResult.Success && roomResult.Data.Count > 0 
                        ? (roomResult.Data[0].GiaTheoNgay ?? detail.GiaPhong ?? 0) 
                        : (detail.GiaPhong ?? 0);
                    
                    int nights = (int)((detail.NgayDi ?? DateTime.Now) - (detail.NgayDen ?? DateTime.Now)).TotalDays;
                    nights = Math.Max(1, nights);
                    decimal roomTotal = roomPrice * nights;

                    // Lấy dịch vụ
                    var serviceDetailBLL = new ServiceDetailBLL();
                    var services = serviceDetailBLL.GetServiceDetails(maCTDP: detail.MaCTDP, isActive: true);
                    decimal serviceTotal = services.Success ? services.Data.Sum(s => s.ThanhTien ?? 0) : 0;
                    
                    decimal grandTotal = roomTotal + serviceTotal;

                    // Tạo hóa đơn
                    var invoiceResult = invoiceBLL.CreateInvoice(
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
                    invoiceBLL.AddInvoiceDetail(maHD, $"Tiền phòng {_selectedRoomForContextMenu.SoPhong}", nights, roomPrice);
                    
                    if (services.Success)
                    {
                        foreach (var service in services.Data)
                        {
                            invoiceBLL.AddInvoiceDetail(
                                maHD,
                                $"Dịch vụ: {service.MaDV}",
                                service.SoLuong ?? 1,
                                service.Gia ?? 0);
                        }
                    }
                }

                // Mở form thanh toán với hóa đơn đã chọn
                using (var paymentForm = new frmPayment(maHD))
                {
                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        // Sau khi thanh toán thành công, cập nhật trạng thái
                        var bookingDetailBLL = new BookingDetailBLL();
                        bookingDetailBLL.UpdateBookingDetail(
                            detail.MaCTDP,
                            "Hoàn tất",
                            detail.NgayDen,
                            DateTime.Now,
                            detail.NguoiLon ?? 2,
                            detail.TreEm ?? 0,
                            detail.GiaPhong,
                            detail.ThanhTien);

                        var bookingBLL = new BookingBLL();
                        bookingBLL.UpdateBooking(booking.MaDP, "Hoàn tất", booking.GhiChu, true);

                        // Cập nhật trạng thái phòng thành "Đang dọn"
                        var roomBLL2 = new RoomBLL();
                        roomBLL2.UpdateRoom(
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
                }
            }
        }

        private void MenuItemCapNhatThongTin_Click(object sender, EventArgs e)
        {
            if (_selectedRoomForContextMenu != null)
            {
                if (!TryGetActiveBooking(out var booking, out var detail))
                {
                    MessageBox.Show("Phòng hiện chưa có đặt phòng đang xử lý để cập nhật.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var bookingForm = new frmBooking(_selectedRoomForContextMenu, booking, detail))
                {
                    if (bookingForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadRooms();
                    }
                }
            }
        }

        #endregion

        private bool TryGetActiveBooking(out Booking booking, out BookingDetail detail)
        {
            booking = null;
            detail = null;

            if (_selectedRoomForContextMenu == null || string.IsNullOrWhiteSpace(_selectedRoomForContextMenu.MaPhong))
                return false;

            try
            {
                // Bước 1: Tìm trong CTDatPhong theo MaPhong - không filter isActive để lấy cả inactive nếu cần
                var detailResult = bookingDetailBLL.GetBookingDetails(
                    maPhong: _selectedRoomForContextMenu.MaPhong);
                
                if (!detailResult.Success || detailResult.Data == null || detailResult.Data.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine($"TryGetActiveBooking: Không tìm thấy booking detail cho phòng {_selectedRoomForContextMenu.MaPhong}");
                    return false;
                }

                // Tìm booking detail đang hoạt động - kiểm tra nhiều trạng thái và normalize
                var activeStatuses = new[] { "Đặt", "Đang sử dụng", "Đang Sử Dụng", "ĐANG SỬ DỤNG", "Đã đặt", "Đã Đặt" };
                var today = DateTime.Now.Date;

                detail = detailResult.Data
                    .Where(d => 
                    {
                        if (d.TrangThai == null) return false;
                        
                        // Normalize trạng thái
                        string normalizedStatus = d.TrangThai.Trim();
                        
                        // Kiểm tra trạng thái
                        bool isActiveStatus = activeStatuses.Any(s => 
                            normalizedStatus.Equals(s, StringComparison.OrdinalIgnoreCase));
                        
                        // Kiểm tra ngày - booking phải chưa kết thúc hoặc đang trong khoảng thời gian
                        bool isDateValid = true;
                        if (d.NgayDi.HasValue)
                        {
                            // Nếu có ngày đi, phải >= hôm nay hoặc đã qua nhưng chưa check out
                            isDateValid = d.NgayDi.Value.Date >= today || 
                                         normalizedStatus.Equals("Đang sử dụng", StringComparison.OrdinalIgnoreCase);
                        }
                        
                        return isActiveStatus && isDateValid && (d.IsActive == true || normalizedStatus.Equals("Đang sử dụng", StringComparison.OrdinalIgnoreCase));
                    })
                    .OrderByDescending(d => 
                    {
                        // Ưu tiên: Đang sử dụng > Đặt > các trạng thái khác
                        string status = d.TrangThai?.Trim() ?? "";
                        if (status.Equals("Đang sử dụng", StringComparison.OrdinalIgnoreCase)) return 3;
                        if (status.Equals("Đặt", StringComparison.OrdinalIgnoreCase)) return 2;
                        return 1;
                    })
                    .ThenByDescending(d => d.NgayDen ?? DateTime.MinValue)
                    .FirstOrDefault();

                if (detail == null || string.IsNullOrWhiteSpace(detail.MaDP))
                {
                    System.Diagnostics.Debug.WriteLine($"TryGetActiveBooking: Không tìm thấy booking detail hợp lệ cho phòng {_selectedRoomForContextMenu.MaPhong}");
                    return false;
                }

                // Bước 2: Lấy booking từ MaDP
                var bookingResult = bookingBLL.GetBookings(maDP: detail.MaDP);
                if (!bookingResult.Success || bookingResult.Data == null || bookingResult.Data.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine($"TryGetActiveBooking: Không tìm thấy booking với MaDP {detail.MaDP}");
                    return false;
                }

                booking = bookingResult.Data[0];
                
                // Kiểm tra booking có active không
                if (booking.IsActive == false && !detail.TrangThai.Trim().Equals("Đang sử dụng", StringComparison.OrdinalIgnoreCase))
                {
                    System.Diagnostics.Debug.WriteLine($"TryGetActiveBooking: Booking {detail.MaDP} không active");
                    return false;
                }

                System.Diagnostics.Debug.WriteLine($"TryGetActiveBooking: Tìm thấy booking {booking.MaDP}, detail {detail.MaCTDP}, trạng thái: {detail.TrangThai}");

                // Bước 3: Kiểm tra xem đã thanh toán chưa - nếu chưa thanh toán thì mới cho phép check out/sửa
                var invoiceBLL = new InvoiceBLL();
                var allInvoices = invoiceBLL.GetInvoices(maDP: detail.MaDP);
                
                // Nếu chưa có hóa đơn nào hoặc có hóa đơn chưa thanh toán, cho phép check out/sửa
                if (allInvoices.Success)
                {
                    // Nếu chưa có hóa đơn nào -> cho phép (có thể tạo hóa đơn mới)
                    if (allInvoices.Data.Count == 0)
                        return true;
                    
                    // Nếu có hóa đơn chưa thanh toán -> cho phép
                    if (allInvoices.Data.Any(i => i.TrangThai == "Chưa TT"))
                        return true;
                    
                    // Nếu tất cả hóa đơn đã thanh toán -> vẫn cho phép check out để cập nhật trạng thái phòng
                    // Nhưng không cho phép sửa booking đã hoàn tất
                    if (detail.TrangThai == "Hoàn tất")
                        return false; // Không cho sửa booking đã hoàn tất
                    
                    return true; // Cho phép check out để cập nhật trạng thái
                }
                
                // Nếu lỗi khi lấy hóa đơn, vẫn cho phép (để tránh block user)
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"TryGetActiveBooking error: {ex.Message}");
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
