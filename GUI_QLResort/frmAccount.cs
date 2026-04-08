using BUS_QLResort;
using ET_QLResort;
using GUI_QLResort.Styles;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_QLResort
{
    public partial class frmAccount : AppBaseForm
    {
        private readonly AccountBUS accountBUS = new AccountBUS();
        private readonly EmployeeBUS employeeBUS = new EmployeeBUS();
        private string selectedMaTK = null;

        public frmAccount()
        {
            InitializeComponent();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadAccounts();
            ResetForm();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleListView(lvAccounts);
            AppTheme.StylePrimaryButton(btnThem);
            AppTheme.StyleSecondaryButton(btnSua);
            AppTheme.StyleSecondaryButton(btnXoa);
            AppTheme.StyleSecondaryButton(btnThoat);
            AppTheme.StyleSecondaryButton(btnTimKiem);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt) AppTheme.StyleTextBox(txt);
                else if (ctrl is ComboBox cb) AppTheme.StyleComboBox(cb);
                else if (ctrl is Label lbl) AppTheme.StyleLabel(lbl);
            }
        }

        private void LoadEmployees()
        {
            // Không cần load employees nữa - dùng txtMaNV readonly
        }

        private void LoadAccounts(string maNV = null, string tenDangNhap = null)
        {
            lvAccounts.Items.Clear();
            var result = accountBUS.GetAccounts(maNV: maNV, tenDangNhap: tenDangNhap, isActive: true);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var account in result.Data)
            {
                // Lấy thông tin nhân viên
                var empResult = employeeBUS.GetEmployeesBUS(maNV: account.MaNV);
                string tenNV = empResult.Success && empResult.Data.Count > 0 ? empResult.Data[0].HoTen : "";

                ListViewItem item = new ListViewItem(account.MaTK);
                item.SubItems.Add(account.MaNV ?? "");
                item.SubItems.Add(tenNV);
                item.SubItems.Add(account.TenDangNhap ?? "");
                item.SubItems.Add(account.MatKhau ?? ""); // Hiển thị mật khẩu thật
                item.SubItems.Add(account.Role ?? "NhanVien");
                item.SubItems.Add(account.IsActive ? "Hoạt động" : "Ngưng");
                item.Tag = account;
                lvAccounts.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            selectedMaTK = null;
            txtMaTK.Clear();
            txtMaNV.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cbRole.SelectedIndex = 0;
            cbIsActive.Checked = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            // Không cần validate nhân viên vì form này chỉ để xem và sửa

            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                errorProvider1.SetError(txtTenDangNhap, "Tên đăng nhập không được để trống");
                isValid = false;
            }

            if (btnThem.Enabled && string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                errorProvider1.SetError(txtMatKhau, "Mật khẩu không được để trống");
                isValid = false;
            }



            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            string maNV = txtMaNV.Text.Trim();
            string role = cbRole.SelectedItem?.ToString() ?? "NhanVien";

            var result = accountBUS.AddAccount(maNV, txtTenDangNhap.Text.Trim(), txtMatKhau.Text.Trim(), role);

            if (result.Success)
            {
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts();
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
            if (string.IsNullOrEmpty(selectedMaTK))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            string matKhauMoi = string.IsNullOrWhiteSpace(txtMatKhau.Text) || txtMatKhau.Text == "******" ? null : txtMatKhau.Text.Trim();
            string role = cbRole.SelectedItem?.ToString() ?? "NhanVien";
            
            var result = accountBUS.UpdateAccount(selectedMaTK, txtTenDangNhap.Text.Trim(), matKhauMoi, role, cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Cập nhật tài khoản thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAccounts();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaTK))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = accountBUS.DeleteAccount(selectedMaTK);
                if (result.Success)
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccounts();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maNV = txtTimMaNV.Text.Trim();
            string tenDangNhap = txtTimTenDangNhap.Text.Trim();

            if (string.IsNullOrEmpty(maNV)) maNV = null;
            if (string.IsNullOrEmpty(tenDangNhap)) tenDangNhap = null;

            LoadAccounts(maNV, tenDangNhap);
        }

        private void lvAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAccounts.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvAccounts.SelectedItems[0];
            if (item.Tag is Account account)
            {
                selectedMaTK = account.MaTK;
                txtMaTK.Text = account.MaTK;
                txtMaNV.Text = account.MaNV ?? "";
                txtTenDangNhap.Text = account.TenDangNhap ?? "";
                txtMatKhau.Text = account.MatKhau ?? "";
                cbIsActive.Checked = account.IsActive;

                string role = account.Role ?? "NhanVien";
                for (int i = 0; i < cbRole.Items.Count; i++)
                {
                    if (cbRole.Items[i].ToString() == role)
                    {
                        cbRole.SelectedIndex = i;
                        break;
                    }
                }

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAccounts();
        }
    }
}

