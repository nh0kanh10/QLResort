using BUS_QLResort;
using ET_QLResort;
using GUI_QLResort.Styles;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_QLResort
{
    public partial class frmEventPayment : AppBaseForm
    {
        private readonly EventDetailBUS eventDetailBUS = new EventDetailBUS();
        private readonly EventBUS eventBUS = new EventBUS();
        private readonly GuestBUS guestBUS = new GuestBUS();
        private readonly PaymentBUS paymentBUS = new PaymentBUS();
        private readonly PaymentTypeBUS paymentTypeBUS = new PaymentTypeBUS();
        private readonly InvoiceBUS invoiceBUS = new InvoiceBUS();

        private EventDetail selectedEventDetail = null;
        private decimal tongTien = 0;
        private decimal daThanhToan = 0;
        private decimal conLai = 0;

        public frmEventPayment()
        {
            InitializeComponent();
        }

        private void frmEventPayment_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadPaymentTypes();
            SetupListView(); //  Add columns explicitly
            LoadEventDetails();
            ResetForm();
        }

        private void SetupListView()
        {
            lvEventDetails.Columns.Clear();
            lvEventDetails.Columns.Add("Mã CTSK", 100);
            lvEventDetails.Columns.Add("Tên SK", 200);
            lvEventDetails.Columns.Add("Khách Hàng", 150);
            lvEventDetails.Columns.Add("Ngày BD", 100);
            lvEventDetails.Columns.Add("Ngày KT", 100);
            lvEventDetails.Columns.Add("Tổng Tiền", 100);
            lvEventDetails.Columns.Add("Đã TT", 100);
            lvEventDetails.Columns.Add("Còn Lại", 100);
            lvEventDetails.Columns.Add("Trạng Thái", 120);
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleListView(lvEventDetails);
            AppTheme.StylePrimaryButton(btnThanhToan);
            AppTheme.StyleSecondaryButton(btnTimKiem);
            AppTheme.StyleSecondaryButton(btnHuy);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt) AppTheme.StyleTextBox(txt);
                else if (ctrl is ComboBox cb) AppTheme.StyleComboBox(cb);
                else if (ctrl is DateTimePicker dtp) AppTheme.StyleDateTimePicker(dtp);
                else if (ctrl is Label lbl) AppTheme.StyleLabel(lbl);
            }
        }

        private void LoadPaymentTypes()
        {
            cbPhuongThucThanhToan.Items.Clear();
            var paymentTypes = paymentTypeBUS.GetPaymentTypes(isActive: true);
            if (paymentTypes.Success)
            {
                foreach (var pt in paymentTypes.Data)
                {
                    cbPhuongThucThanhToan.Items.Add(new { Key = pt.MaLTT, Value = pt.TenLTT });
                }
                cbPhuongThucThanhToan.DisplayMember = "Value";
                cbPhuongThucThanhToan.ValueMember = "Key";
                if (cbPhuongThucThanhToan.Items.Count > 0) cbPhuongThucThanhToan.SelectedIndex = 0;
            }
        }

        private void LoadEventDetails(string maKH = null, string maSK = null, string trangThai = null)
        {
            lvEventDetails.Items.Clear();
            var result = eventDetailBUS.GetEventDetails(maKH: maKH, maSK: maSK, trangThai: trangThai, isActive: true);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var detail in result.Data)
            {
                // Lấy thông tin sự kiện
                var eventResult = eventBUS.GetEvents(maSK: detail.MaSK);
                var currentEvent = eventResult.Success && eventResult.Data.Count > 0 ? eventResult.Data[0] : null;
                
                // [ROLE CHECK] Nếu là Nhân viên, chỉ hiện sự kiện thuộc chi nhánh của mình
                if (!Session_Now.IsQuanLy && !Session_Now.IsAdmin)
                {
                     if (currentEvent != null && currentEvent.MaCN != Session_Now.CurrentResort)
                     {
                         continue; // Bỏ qua sự kiện khác chi nhánh
                     }
                }

                var guestResult = guestBUS.GetGuests(maKH: detail.MaKH);
                string tenSK = currentEvent != null ? currentEvent.TenSK : "";
                string tenKH = guestResult.Success && guestResult.Data.Count > 0 ? guestResult.Data[0].HoTen : "";

                ListViewItem item = new ListViewItem(detail.MaCTSK);
                item.SubItems.Add(tenSK);
                item.SubItems.Add(tenKH);
                item.SubItems.Add(detail.NgayBD.ToString("dd/MM/yyyy"));
                item.SubItems.Add(detail.NgayKT.ToString("dd/MM/yyyy"));
                item.SubItems.Add(detail.ThanhTien.ToString("N0"));
                item.SubItems.Add(detail.DaThanhToan.ToString("N0"));
                item.SubItems.Add((detail.ThanhTien - detail.DaThanhToan).ToString("N0"));
                item.SubItems.Add(detail.TrangThai ?? "Lên kế hoạch");
                item.Tag = detail;
                lvEventDetails.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            selectedEventDetail = null;
            txtMaCTSK.Clear();
            txtTenSK.Clear();
            txtTenKH.Clear();
            txtNgayBD.Clear();
            txtNgayKT.Clear();
            txtTongTien.Clear();
            txtDaThanhToan.Clear();
            txtConLai.Clear();
            txtSoTienThanhToan.Clear();
            txtGhiChu.Clear();
            btnThanhToan.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maKH = txtTimMaKH.Text.Trim();
            string maSK = txtTimMaSK.Text.Trim();
            string trangThai = cbTimTrangThai.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(maKH)) maKH = null;
            if (string.IsNullOrEmpty(maSK)) maSK = null;
            if (trangThai == "Tất cả") trangThai = null;

            LoadEventDetails(maKH, maSK, trangThai);
        }

        private void lvEventDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEventDetails.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvEventDetails.SelectedItems[0];
            if (item.Tag is EventDetail detail)
            {
                selectedEventDetail = detail;
                txtMaCTSK.Text = detail.MaCTSK;

                // Load thông tin sự kiện
                var eventResult = eventBUS.GetEvents(maSK: detail.MaSK);
                if (eventResult.Success && eventResult.Data.Count > 0)
                {
                    txtTenSK.Text = eventResult.Data[0].TenSK ?? "";
                }

                // Load thông tin khách hàng
                var guestResult = guestBUS.GetGuests(maKH: detail.MaKH);
                if (guestResult.Success && guestResult.Data.Count > 0)
                {
                    txtTenKH.Text = guestResult.Data[0].HoTen ?? "";
                }

                txtNgayBD.Text = detail.NgayBD.ToString("dd/MM/yyyy");
                txtNgayKT.Text = detail.NgayKT.ToString("dd/MM/yyyy");
                txtTongTien.Text = detail.ThanhTien.ToString("N0");
                txtDaThanhToan.Text = detail.DaThanhToan.ToString("N0");
                txtConLai.Text = (detail.ThanhTien - detail.DaThanhToan).ToString("N0");

                tongTien = detail.ThanhTien;
                daThanhToan = detail.DaThanhToan;
                conLai = tongTien - daThanhToan;

                txtSoTienThanhToan.Text = conLai > 0 ? conLai.ToString("N0") : "0";
                txtSoTienThanhToan.Enabled = conLai > 0;
                btnThanhToan.Enabled = conLai > 0;
            }
        }

        private void txtSoTienThanhToan_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtSoTienThanhToan.Text.Replace(",", ""), out decimal soTien))
            {
                if (soTien > conLai)
                {
                    MessageBox.Show($"Số tiền thanh toán không được vượt quá số tiền còn lại ({conLai:N0})", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTienThanhToan.Text = conLai.ToString("N0");
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (selectedEventDetail == null)
            {
                MessageBox.Show("Vui lòng chọn sự kiện cần thanh toán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSoTienThanhToan.Text.Replace(",", ""), out decimal soTien) || soTien <= 0)
            {
                MessageBox.Show("Số tiền thanh toán không hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (soTien > conLai)
            {
                MessageBox.Show($"Số tiền thanh toán không được vượt quá số tiền còn lại!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbPhuongThucThanhToan.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Cập nhật số tiền đã thanh toán
                decimal newDaThanhToan = daThanhToan + soTien;
                string newTrangThai = newDaThanhToan >= tongTien ? "Đã kết thúc" : selectedEventDetail.TrangThai;

                var updateResult = eventDetailBUS.UpdateEventDetail(
                    selectedEventDetail.MaCTSK,
                    newTrangThai,
                    newDaThanhToan,
                    txtGhiChu.Text.Trim(),
                    null,
                    null
                );

                if (!updateResult.Success)
                {
                    MessageBox.Show($"Lỗi khi cập nhật thanh toán: {updateResult.ErrorMessage}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //  Cập nhật Payment và Invoice
                // 1. Tìm hoặc tạo hóa đơn
                var invoices = invoiceBUS.GetInvoices(maCTSK: selectedEventDetail.MaCTSK);
                string maHD = null;

                if (invoices.Success && invoices.Data.Count > 0)
                {
                    maHD = invoices.Data[0].MaHD;
                }
                else
                {
                    // Fallback: Tạo hóa đơn mới nếu chưa có (ví dụ do lỗi lúc booking)
                    var eventInfo = eventBUS.GetEvents(maSK: selectedEventDetail.MaSK).Data.FirstOrDefault();
                    string maCN = eventInfo?.MaCN; 
                    
                    // CHECK: Nếu maCN null (do tạo lỗi), fallback về CurrentResort
                    if (string.IsNullOrEmpty(maCN)) maCN = Session_Now.CurrentResort;

                    var invoiceResult = invoiceBUS.CreateInvoice(
                        null, 
                        selectedEventDetail.MaKH, 
                        Session_Now.CurrentUser,
                        maCN, // MaCN chắc chắn có giá trị
                        tongTien, 
                        null, null, null, null, 
                        selectedEventDetail.MaCTSK, 
                        "SuKien");

                    if (invoiceResult.Success) 
                    {
                        maHD = invoiceResult.Data.MaHD;
                    }
                }

                if (!string.IsNullOrEmpty(maHD))
                {
                    // 2. Tạo record thanh toán
                    dynamic selectedPaymentMethod = cbPhuongThucThanhToan.SelectedItem;
                    string maLTT = selectedPaymentMethod.Key;
                    
                    paymentBUS.AddPayment(maHD, soTien, maLTT, DateTime.Now);

                    // 3. Cập nhật trạng thái hóa đơn nếu đã thanh toán hết
                    if (newDaThanhToan >= tongTien)
                    {
                        invoiceBUS.UpdateInvoiceStatus(maHD, "Đã TT"); // Đã thanh toán
                    }
                }

                MessageBox.Show("Thanh toán thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadEventDetails();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

