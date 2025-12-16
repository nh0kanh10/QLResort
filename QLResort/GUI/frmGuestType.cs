using QLResort.BUS;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmGuestType : AppBaseForm
    {
        private readonly GuestTypeBUS guestTypeBUS = new GuestTypeBUS();
        private string selectedMaLKH = null;

        public frmGuestType()
        {
            InitializeComponent();
        }

        private void frmGuestType_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadGuestTypes();
            ResetForm();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleListView(lvGuestTypes);
            AppTheme.StylePrimaryButton(btnThem);
            AppTheme.StyleSecondaryButton(btnSua);
            AppTheme.StyleDangerButton(btnXoa); // Assuming there's a danger style
            AppTheme.StyleSecondaryButton(btnReset);
            
            foreach (Control ctrl in grpThongTin.Controls)
            {
                if (ctrl is TextBox txt) AppTheme.StyleTextBox(txt);
                else if (ctrl is Label lbl) AppTheme.StyleLabel(lbl);
            }
        }

        private void LoadGuestTypes()
        {
            lvGuestTypes.Items.Clear();
            var result = guestTypeBUS.GetGuestTypes();

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var item in result.Data)
            {
                ListViewItem lvi = new ListViewItem(item.MaLKH);
                lvi.SubItems.Add(item.TenLKH);
                lvi.SubItems.Add(item.GiamGiaPercent.ToString("N2"));
                lvi.SubItems.Add(item.DiemToiThieu.ToString("N0"));
                lvi.SubItems.Add(item.IsActive ? "Active" : "Inactive");
                lvi.Tag = item;
                lvGuestTypes.Items.Add(lvi);
            }
        }

        private void ResetForm()
        {
            selectedMaLKH = null;
            txtMaLKH.Clear();
            txtTenLKH.Clear();
            txtGiamGia.Clear();
            txtDiemToiThieu.Clear();
            txtMoTa.Clear();
            cbIsActive.Checked = true;
            
            txtMaLKH.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtMaLKH.Text))
            {
                errorProvider.SetError(txtMaLKH, "Mã loại khách hàng không được để trống");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtTenLKH.Text))
            {
                errorProvider.SetError(txtTenLKH, "Tên loại khách hàng không được để trống");
                isValid = false;
            }

            if (!decimal.TryParse(txtGiamGia.Text, out decimal discount) || discount < 0 || discount > 100)
            {
                errorProvider.SetError(txtGiamGia, "Giảm giá phải là số từ 0 đến 100");
                isValid = false;
            }

            if (!int.TryParse(txtDiemToiThieu.Text, out int points) || points < 0)
            {
                errorProvider.SetError(txtDiemToiThieu, "Điểm tối thiểu phải là số nguyên không âm");
                isValid = false;
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var result = guestTypeBUS.AddGuestType(
                txtMaLKH.Text.Trim(),
                txtTenLKH.Text.Trim(),
                decimal.Parse(txtGiamGia.Text),
                int.Parse(txtDiemToiThieu.Text),
                txtMoTa.Text.Trim(),
                cbIsActive.Checked
            );

            if (result.Success)
            {
                MessageBox.Show("Thêm loại khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGuestTypes();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaLKH)) return;
            if (!ValidateForm()) return;

            var result = guestTypeBUS.UpdateGuestType(
                txtMaLKH.Text.Trim(), // Primary key usually shouldn't change, but depends on logic
                txtTenLKH.Text.Trim(),
                decimal.Parse(txtGiamGia.Text),
                int.Parse(txtDiemToiThieu.Text),
                txtMoTa.Text.Trim(),
                cbIsActive.Checked
            );

            if (result.Success)
            {
                MessageBox.Show("Cập nhật loại khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGuestTypes();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaLKH)) return;

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa loại khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var result = guestTypeBUS.DeleteGuestType(selectedMaLKH);

                if (result.Success)
                {
                    MessageBox.Show("Xóa loại khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGuestTypes();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void lvGuestTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGuestTypes.SelectedItems.Count == 0) return;

            ListViewItem item = lvGuestTypes.SelectedItems[0];
            GuestType guestType = item.Tag as GuestType;

            if (guestType != null)
            {
                selectedMaLKH = guestType.MaLKH;
                txtMaLKH.Text = guestType.MaLKH;
                txtMaLKH.Enabled = false; // Disable editing PK
                txtTenLKH.Text = guestType.TenLKH;
                txtGiamGia.Text = guestType.GiamGiaPercent.ToString("N2"); // Format for display might need parsing back
                // Or just use 
                txtGiamGia.Text = guestType.GiamGiaPercent.ToString();

                txtDiemToiThieu.Text = guestType.DiemToiThieu.ToString();
                txtMoTa.Text = guestType.MoTa;
                cbIsActive.Checked = guestType.IsActive;

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
