using QLResort.BUS;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmEventPayment : AppBaseForm
    {
        private readonly EventDetailBUS eventDetailBUS = new EventDetailBUS();
        private readonly EventBUS eventBUS = new EventBUS();
        private readonly GuestBUS guestBUS = new GuestBUS();
        private readonly PaymentBUS paymentBUS = new PaymentBUS();
        private readonly PaymentTypeBUS paymentTypeBUS = new PaymentTypeBUS();

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
            LoadEventDetails();
            ResetForm();
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
                // Lấy thông tin sự kiện và khách hàng
                var eventResult = eventBUS.GetEvents(maSK: detail.MaSK);
                var guestResult = guestBUS.GetGuests(maKH: detail.MaKH);

                string tenSK = eventResult.Success && eventResult.Data.Count > 0 ? eventResult.Data[0].TenSK : "";
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
                string newTrangThai = newDaThanhToan >= tongTien ? "Đã thanh toán đủ" : selectedEventDetail.TrangThai;

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

                // Tạo payment record (nếu cần)
                // Note: Payment table có thể cần MaHD, nhưng với sự kiện thì có thể dùng MaCTSK
                // Tạm thời bỏ qua việc tạo payment record vì cấu trúc Payment chỉ có MaHD

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

