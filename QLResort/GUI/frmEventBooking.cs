using QLResort.BUS;
using QLResort.Core.Model;
using QLResort.GUI.Guest;
using QLResort.GUI.Styles;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmEventBooking : AppBaseForm
    {
        private readonly EventBUS eventBUS = new EventBUS();
        private readonly EventPackageBUS eventPackageBUS = new EventPackageBUS();
        private readonly EventDetailBUS eventDetailBUS = new EventDetailBUS();
        private readonly GuestBUS guestBUS = new GuestBUS();
        private readonly ResortBUS resortBUS = new ResortBUS();
        private readonly PaymentBUS paymentBUS = new PaymentBUS();
        private readonly PaymentTypeBUS paymentTypeBUS = new PaymentTypeBUS();

        private EventPackage selectedPackage = null;
        private QLResort.Core.Model.Guest selectedGuest = null;
        private Event selectedEvent = null;
        private decimal tongTien = 0;
        private decimal datCoc = 0;
        private decimal conLai = 0;

        public frmEventBooking()
        {
            InitializeComponent();
        }

        private void frmEventBooking_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadComboBoxes();
            ResetForm();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StylePrimaryButton(btnXacNhan);
            AppTheme.StyleSecondaryButton(btnTaoGoiCustom);
            AppTheme.StyleSecondaryButton(btnChonKhachHang);
            AppTheme.StyleSecondaryButton(btnHuy);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt) AppTheme.StyleTextBox(txt);
                else if (ctrl is ComboBox cb) AppTheme.StyleComboBox(cb);
                else if (ctrl is DateTimePicker dtp) AppTheme.StyleDateTimePicker(dtp);
                else if (ctrl is NumericUpDown nud) AppTheme.StyleNumericUpDown(nud);
                else if (ctrl is Label lbl) AppTheme.StyleLabel(lbl);
            }
        }

        private void LoadComboBoxes()
        {
            // Load loại sự kiện
            cbLoaiSuKien.Items.Clear();
            cbLoaiSuKien.Items.Add("Cưới");
            cbLoaiSuKien.Items.Add("Hội nghị");
            cbLoaiSuKien.Items.Add("Team building");
            cbLoaiSuKien.Items.Add("Khác");

            // Load chi nhánh
            cbMaCN.Items.Clear();
            var resorts = resortBUS.GetResorts();
            if (resorts.Success)
            {
                foreach (var resort in resorts.Data)
                {
                    cbMaCN.Items.Add(new { Key = resort.MaCN, Value = resort.TenCN });
                }
                cbMaCN.DisplayMember = "Value";
                cbMaCN.ValueMember = "Key";
                if (cbMaCN.Items.Count > 0) cbMaCN.SelectedIndex = 0;
            }

            // Load phương thức thanh toán
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

            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now.AddDays(1);
        }

        private void ResetForm()
        {
            selectedPackage = null;
            selectedGuest = null;
            selectedEvent = null;
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            txtMaGoiSK.Clear();
            txtTenGoiSK.Clear();
            txtGiaCoBan.Clear();
            txtDichVuKemTheo.Clear();
            txtTongTien.Clear();
            txtDatCoc.Clear();
            txtConLai.Clear();
            txtTongKhach.Value = 10;
            txtGhiChu.Clear();
            cbLoaiSuKien.SelectedIndex = -1;
            lvGoiSuKien.Items.Clear();
            tongTien = 0;
            datCoc = 0;
            conLai = 0;
        }

        private void cbLoaiSuKien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiSuKien.SelectedItem == null) return;

            string loaiSuKien = cbLoaiSuKien.SelectedItem.ToString();
            LoadEventPackages(loaiSuKien);
        }

        private void LoadEventPackages(string loaiSuKien)
        {
            lvGoiSuKien.Items.Clear();
            var result = eventPackageBUS.GetEventPackages(loaiSuKien: loaiSuKien, isActive: true);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var package in result.Data)
            {
                ListViewItem item = new ListViewItem(package.MaGoiSK);
                item.SubItems.Add(package.TenGoiSK ?? "");
                item.SubItems.Add(package.GiaCoBan.ToString("N0"));
                item.SubItems.Add(package.SoKhachToiThieu.ToString());
                item.SubItems.Add(package.SoKhachToiDa?.ToString() ?? "Không giới hạn");
                item.SubItems.Add(package.IsGoiMacDinh ? "Mặc định" : "Custom");
                item.Tag = package;
                lvGoiSuKien.Items.Add(item);
            }
        }

        private void lvGoiSuKien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGoiSuKien.SelectedItems.Count == 0)
            {
                selectedPackage = null;
                ClearPackageInfo();
                return;
            }

            ListViewItem item = lvGoiSuKien.SelectedItems[0];
            if (item.Tag is EventPackage package)
            {
                selectedPackage = package;
                txtMaGoiSK.Text = package.MaGoiSK;
                txtTenGoiSK.Text = package.TenGoiSK ?? "";
                txtGiaCoBan.Text = package.GiaCoBan.ToString("N0");
                txtDichVuKemTheo.Text = package.DichVuKemTheo ?? "";
                
                // Tính tổng tiền dựa trên số khách và thời gian
                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            if (selectedPackage == null) return;

            int soKhach = (int)txtTongKhach.Value;
            int soGio = (int)(dtpNgayKT.Value - dtpNgayBD.Value).TotalHours;
            if (soGio < 1) soGio = 1;

            // Tính giá dựa trên số khách và thời gian
            tongTien = selectedPackage.GiaCoBan;
            
            // Nếu số khách vượt quá số khách tối thiểu, tính thêm
            if (soKhach > selectedPackage.SoKhachToiThieu)
            {
                int vuotQua = soKhach - selectedPackage.SoKhachToiThieu;
                tongTien += vuotQua * (selectedPackage.GiaCoBan * 0.1m); // Thêm 10% cho mỗi khách vượt quá
            }

            // Tính theo thời gian
            if (selectedPackage.ThoiGianToiThieu.HasValue && soGio > selectedPackage.ThoiGianToiThieu.Value)
            {
                int vuotQuaGio = soGio - selectedPackage.ThoiGianToiThieu.Value;
                tongTien += vuotQuaGio * (selectedPackage.GiaCoBan * 0.05m); // Thêm 5% cho mỗi giờ vượt quá
            }

            // Đặt cọc bắt buộc 30%
            datCoc = tongTien * 0.3m;
            conLai = tongTien - datCoc;

            txtTongTien.Text = tongTien.ToString("N0");
            txtDatCoc.Text = datCoc.ToString("N0");
            txtConLai.Text = conLai.ToString("N0");
        }

        private void ClearPackageInfo()
        {
            txtMaGoiSK.Clear();
            txtTenGoiSK.Clear();
            txtGiaCoBan.Clear();
            txtDichVuKemTheo.Clear();
            txtTongTien.Clear();
            txtDatCoc.Clear();
            txtConLai.Clear();
        }

        private void txtTongKhach_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void dtpNgayBD_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgayKT.Value < dtpNgayBD.Value)
                dtpNgayKT.Value = dtpNgayBD.Value.AddDays(1);
            CalculateTotal();
        }

        private void dtpNgayKT_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNgayKT.Value < dtpNgayBD.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayKT.Value = dtpNgayBD.Value.AddDays(1);
            }
            CalculateTotal();
        }

        private void btnChonKhachHang_Click(object sender, EventArgs e)
        {
            // Mở form chọn khách hàng hoặc tìm bằng mã
            using (var selectGuestForm = new frmSelectCustomer())
            {
                if (selectGuestForm.ShowDialog() == DialogResult.OK)
                {
                    selectedGuest = selectGuestForm.SelectedGuest;
                    if (selectedGuest != null)
                    {
                        txtMaKH.Text = selectedGuest.MaKH;
                        txtTenKH.Text = selectedGuest.HoTen ?? "";
                        txtSDT.Text = selectedGuest.SDT ?? "";
                        txtEmail.Text = selectedGuest.Email ?? "";
                    }
                }
            }
        }

        private void btnTaoGoiCustom_Click(object sender, EventArgs e)
        {
            using (var packageForm = new frmEventPackage())
            {
                if (packageForm.ShowDialog() == DialogResult.OK)
                {
                    // Reload packages
                    if (cbLoaiSuKien.SelectedItem != null)
                    {
                        LoadEventPackages(cbLoaiSuKien.SelectedItem.ToString());
                    }
                }
            }
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (selectedGuest == null)
            {
                errorProvider1.SetError(btnChonKhachHang, "Vui lòng chọn khách hàng");
                isValid = false;
            }

            if (cbLoaiSuKien.SelectedItem == null)
            {
                errorProvider1.SetError(cbLoaiSuKien, "Vui lòng chọn loại sự kiện");
                isValid = false;
            }

            if (selectedPackage == null)
            {
                errorProvider1.SetError(lvGoiSuKien, "Vui lòng chọn gói sự kiện");
                isValid = false;
            }

            if (cbMaCN.SelectedItem == null)
            {
                errorProvider1.SetError(cbMaCN, "Vui lòng chọn chi nhánh");
                isValid = false;
            }

            if (txtTongKhach.Value < selectedPackage?.SoKhachToiThieu)
            {
                errorProvider1.SetError(txtTongKhach, $"Số khách tối thiểu là {selectedPackage.SoKhachToiThieu}");
                isValid = false;
            }

            if (selectedPackage?.SoKhachToiDa.HasValue == true && txtTongKhach.Value > selectedPackage.SoKhachToiDa.Value)
            {
                errorProvider1.SetError(txtTongKhach, $"Số khách tối đa là {selectedPackage.SoKhachToiDa.Value}");
                isValid = false;
            }

            return isValid;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                // Tạo hoặc lấy sự kiện
                dynamic selectedCN = cbMaCN.SelectedItem;
                string maCN = selectedCN?.Key?.ToString();

                var eventResult = eventBUS.GetEvents(maCN: maCN, loaiSuKien: cbLoaiSuKien.SelectedItem?.ToString());
                if (!eventResult.Success || eventResult.Data.Count == 0)
                {
                    // Tạo sự kiện mới
                    var addEventResult = eventBUS.AddEvent(
                        $"Sự kiện {cbLoaiSuKien.SelectedItem}",
                        cbLoaiSuKien.SelectedItem?.ToString(),
                        maCN,
                        null,
                        null,
                        null,
                        true);
                    
                    if (!addEventResult.Success)
                    {
                        MessageBox.Show($"Lỗi khi tạo sự kiện: {addEventResult.ErrorMessage}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Lấy lại danh sách để lấy mã sự kiện
                    eventResult = eventBUS.GetEvents(maCN: maCN, loaiSuKien: cbLoaiSuKien.SelectedItem?.ToString());
                }

                selectedEvent = eventResult.Data[0];

                // Tạo chi tiết sự kiện
                var detailResult = eventDetailBUS.AddEventDetail(
                    selectedEvent.MaSK,
                    selectedGuest.MaKH,
                    tongTien,
                    dtpNgayBD.Value,
                    dtpNgayKT.Value,
                    1,
                    (int)txtTongKhach.Value,
                    datCoc,
                    txtGhiChu.Text.Trim(),
                    "Lên kế hoạch"
                );

                if (!detailResult.Success)
                {
                    MessageBox.Show($"Lỗi khi đặt sự kiện: {detailResult.ErrorMessage}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy mã chi tiết sự kiện vừa tạo để cập nhật đặt cọc
                var eventDetails = eventDetailBUS.GetEventDetails(maSK: selectedEvent.MaSK, maKH: selectedGuest.MaKH);
                if (eventDetails.Success && eventDetails.Data.Count > 0)
                {
                    var latestDetail = eventDetails.Data.OrderByDescending(d => d.CreatedAt).First();
                    
                    // Cập nhật đặt cọc vào EventDetail
                    var updateResult = eventDetailBUS.UpdateEventDetail(
                        latestDetail.MaCTSK,
                        null,
                        datCoc, // Đã thanh toán = đặt cọc
                        null,
                        null,
                        null
                    );

                    if (!updateResult.Success)
                    {
                        MessageBox.Show($"Đã đặt sự kiện nhưng không thể cập nhật đặt cọc: {updateResult.ErrorMessage}", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                MessageBox.Show("Đặt sự kiện thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

