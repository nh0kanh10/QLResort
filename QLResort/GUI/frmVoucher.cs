using QLResort.BLL;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmVoucher : Form
    {
        private readonly VoucherBLL voucherBLL = new VoucherBLL();
        private readonly GuestTypeBLL guestTypeBLL = new GuestTypeBLL();
        private readonly ResortBLL resortBLL = new ResortBLL();
        private string selectedMaVoucher = null;

        public frmVoucher()
        {
            InitializeComponent();
        }

        private void frmVoucher_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadVouchers();
            LoadComboBoxes();
            ResetForm();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleListView(lvVouchers);
            AppTheme.StylePrimaryButton(btnThem);
            AppTheme.StyleSecondaryButton(btnSua);
            AppTheme.StyleSecondaryButton(btnXoa);
            AppTheme.StyleSecondaryButton(btnReset);
            
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt) AppTheme.StyleTextBox(txt);
                else if (ctrl is ComboBox cb) AppTheme.StyleComboBox(cb);
                else if (ctrl is DateTimePicker dtp) AppTheme.StyleDateTimePicker(dtp);
                else if (ctrl is Label lbl) AppTheme.StyleLabel(lbl);
            }
        }

        private void LoadComboBoxes()
        {
            cbMaLKH.Items.Clear();
            cbMaLKH.Items.Add(new { Key = "", Value = "(Tất cả)" });
            var guestTypes = guestTypeBLL.GetGuestTypes();
            if (guestTypes.Success)
            {
                foreach (var gt in guestTypes.Data)
                {
                    cbMaLKH.Items.Add(new { Key = gt.MaLKH, Value = gt.TenLKH });
                }
            }
            cbMaLKH.DisplayMember = "Value";
            cbMaLKH.ValueMember = "Key";
            if (cbMaLKH.Items.Count > 0) cbMaLKH.SelectedIndex = 0;

            cbMaCN.Items.Clear();
            cbMaCN.Items.Add(new { Key = "", Value = "(Tất cả)" });
            var resorts = resortBLL.GetResorts();
            if (resorts.Success)
            {
                foreach (var resort in resorts.Data)
                {
                    cbMaCN.Items.Add(new { Key = resort.MaCN, Value = resort.TenCN });
                }
            }
            cbMaCN.DisplayMember = "Value";
            cbMaCN.ValueMember = "Key";
            if (cbMaCN.Items.Count > 0) cbMaCN.SelectedIndex = 0;

            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Active");
            cbTrangThai.Items.Add("Inactive");
            cbTrangThai.Items.Add("Expired");
            if (cbTrangThai.Items.Count > 0) cbTrangThai.SelectedIndex = 0;
        }

        private void LoadVouchers()
        {
            lvVouchers.Items.Clear();
            var result = voucherBLL.GetVouchers();

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var voucher in result.Data)
            {
                ListViewItem item = new ListViewItem(voucher.MaVoucher);
                item.SubItems.Add(voucher.TenVoucher ?? "");
                item.SubItems.Add(voucher.CouponCode ?? "");
                item.SubItems.Add(voucher.IsPhanTram ? "%" : "VNĐ");
                item.SubItems.Add(voucher.GiaTri?.ToString("N0") ?? "0");
                item.SubItems.Add(voucher.SoLuong?.ToString() ?? "∞");
                item.SubItems.Add(voucher.SoLuongDaDung.ToString());
                item.SubItems.Add(voucher.TrangThai ?? "Active");
                item.Tag = voucher;
                lvVouchers.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            selectedMaVoucher = null;
            txtMaVoucher.Clear();
            txtTenVoucher.Clear();
            txtCouponCode.Clear();
            cbIsPhanTram.Checked = true;
            txtGiaTri.Clear();
            txtSoLuong.Clear();
            txtDieuKien.Clear();
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now.AddMonths(1);
            cbTrangThai.SelectedIndex = 0;
            cbIsActive.Checked = true;
            if (cbMaLKH.Items.Count > 0) cbMaLKH.SelectedIndex = 0;
            if (cbMaCN.Items.Count > 0) cbMaCN.SelectedIndex = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTenVoucher.Text))
            {
                errorProvider1.SetError(txtTenVoucher, "Tên voucher không được để trống");
                isValid = false;
            }

            if (dtpNgayKT.Value < dtpNgayBD.Value)
            {
                errorProvider1.SetError(dtpNgayKT, "Ngày kết thúc phải sau ngày bắt đầu");
                isValid = false;
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            decimal? giaTri = null;
            if (decimal.TryParse(txtGiaTri.Text.Trim(), out decimal gt))
                giaTri = gt;

            int? soLuong = null;
            if (int.TryParse(txtSoLuong.Text.Trim(), out int sl))
                soLuong = sl;

            string maLKH = null;
            string maCN = null;

            if (cbMaLKH.SelectedItem != null)
            {
                dynamic selectedLKH = cbMaLKH.SelectedItem;
                maLKH = selectedLKH?.Key?.ToString();
                if (string.IsNullOrEmpty(maLKH) || maLKH == "(Tất cả)") maLKH = null;
            }

            if (cbMaCN.SelectedItem != null)
            {
                dynamic selectedCN = cbMaCN.SelectedItem;
                maCN = selectedCN?.Key?.ToString();
                if (string.IsNullOrEmpty(maCN) || maCN == "(Tất cả)") maCN = null;
            }

            var result = voucherBLL.AddVoucher(
                txtTenVoucher.Text.Trim(),
                cbIsPhanTram.Checked,
                giaTri,
                txtCouponCode.Text.Trim(),
                soLuong,
                maLKH,
                maCN,
                null,
                null,
                dtpNgayBD.Value,
                dtpNgayKT.Value,
                txtDieuKien.Text.Trim(),
                cbTrangThai.SelectedItem?.ToString(),
                cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Thêm voucher thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVouchers();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaVoucher))
            {
                MessageBox.Show("Vui lòng chọn voucher cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            decimal? giaTri = null;
            if (decimal.TryParse(txtGiaTri.Text.Trim(), out decimal gt))
                giaTri = gt;

            int? soLuong = null;
            if (int.TryParse(txtSoLuong.Text.Trim(), out int sl))
                soLuong = sl;

            var result = voucherBLL.UpdateVoucher(
                selectedMaVoucher,
                txtTenVoucher.Text.Trim(),
                cbIsPhanTram.Checked,
                giaTri,
                soLuong,
                dtpNgayBD.Value,
                dtpNgayKT.Value,
                txtDieuKien.Text.Trim(),
                cbTrangThai.SelectedItem?.ToString(),
                cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Cập nhật voucher thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVouchers();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvVouchers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvVouchers.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvVouchers.SelectedItems[0];
            if (item.Tag is Voucher voucher)
            {
                selectedMaVoucher = voucher.MaVoucher;
                txtMaVoucher.Text = voucher.MaVoucher;
                txtTenVoucher.Text = voucher.TenVoucher ?? "";
                txtCouponCode.Text = voucher.CouponCode ?? "";
                cbIsPhanTram.Checked = voucher.IsPhanTram;
                txtGiaTri.Text = voucher.GiaTri?.ToString("N0") ?? "";
                txtSoLuong.Text = voucher.SoLuong?.ToString() ?? "";
                txtDieuKien.Text = voucher.DieuKien ?? "";
                if (voucher.NgayBD.HasValue) dtpNgayBD.Value = voucher.NgayBD.Value;
                if (voucher.NgayKT.HasValue) dtpNgayKT.Value = voucher.NgayKT.Value;
                
                // Set ComboBox values
                for (int i = 0; i < cbTrangThai.Items.Count; i++)
                {
                    if (cbTrangThai.Items[i].ToString() == (voucher.TrangThai ?? "Active"))
                    {
                        cbTrangThai.SelectedIndex = i;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(voucher.MaLKH))
                {
                    for (int i = 0; i < cbMaLKH.Items.Count; i++)
                    {
                        dynamic lkh = cbMaLKH.Items[i];
                        if (lkh?.Key != null && lkh.Key.ToString() == voucher.MaLKH)
                        {
                            cbMaLKH.SelectedIndex = i;
                            break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(voucher.MaCN))
                {
                    for (int i = 0; i < cbMaCN.Items.Count; i++)
                    {
                        dynamic cn = cbMaCN.Items[i];
                        if (cn?.Key != null && cn.Key.ToString() == voucher.MaCN)
                        {
                            cbMaCN.SelectedIndex = i;
                            break;
                        }
                    }
                }

                cbIsActive.Checked = voucher.IsActive;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaVoucher))
            {
                MessageBox.Show("Vui lòng chọn voucher cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa voucher này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = voucherBLL.DeleteVoucher(selectedMaVoucher);
                if (result.Success)
                {
                    MessageBox.Show("Xóa voucher thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVouchers();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

