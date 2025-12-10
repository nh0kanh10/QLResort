using QLResort.BLL;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmEventPackage : Form
    {
        private readonly EventPackageBLL eventPackageBLL = new EventPackageBLL();
        private readonly ResortBLL resortBLL = new ResortBLL();
        private string selectedMaGoiSK = null;

        public frmEventPackage()
        {
            InitializeComponent();
        }

        private void frmEventPackage_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadEventPackages();
            LoadComboBoxes();
            ResetForm();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleListView(lvPackages);
            AppTheme.StylePrimaryButton(btnThem);
            AppTheme.StyleSecondaryButton(btnSua);
            AppTheme.StyleSecondaryButton(btnXoa);
            AppTheme.StyleSecondaryButton(btnReset);

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt) AppTheme.StyleTextBox(txt);
                else if (ctrl is ComboBox cb) AppTheme.StyleComboBox(cb);
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
            cbMaCN.Items.Add(new { Key = "", Value = "(Tất cả chi nhánh)" });
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
            cbMaCN.SelectedIndex = 0;
        }

        private void LoadEventPackages(string loaiSuKien = null)
        {
            lvPackages.Items.Clear();
            var result = eventPackageBLL.GetEventPackages(loaiSuKien: loaiSuKien, isActive: true);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var package in result.Data)
            {
                ListViewItem item = new ListViewItem(package.MaGoiSK);
                item.SubItems.Add(package.TenGoiSK ?? "");
                item.SubItems.Add(package.LoaiSuKien ?? "");
                item.SubItems.Add(package.GiaCoBan.ToString("N0"));
                item.SubItems.Add(package.SoKhachToiThieu.ToString());
                item.SubItems.Add(package.SoKhachToiDa?.ToString() ?? "Không giới hạn");
                item.SubItems.Add(package.IsGoiMacDinh ? "Mặc định" : "Custom");
                item.Tag = package;
                lvPackages.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            selectedMaGoiSK = null;
            txtMaGoiSK.Clear();
            txtTenGoiSK.Clear();
            txtMoTa.Clear();
            txtDichVuKemTheo.Clear();
            nudGiaCoBan.Value = 0;
            nudSoKhachToiThieu.Value = 10;
            nudSoKhachToiDa.Value = 100;
            nudThoiGianToiThieu.Value = 2;
            nudThoiGianToiDa.Value = 8;
            cbIsGoiMacDinh.Checked = false;
            if (cbLoaiSuKien.Items.Count > 0) cbLoaiSuKien.SelectedIndex = 0;
            if (cbMaCN.Items.Count > 0) cbMaCN.SelectedIndex = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTenGoiSK.Text))
            {
                errorProvider1.SetError(txtTenGoiSK, "Tên gói sự kiện không được để trống");
                isValid = false;
            }

            if (cbLoaiSuKien.SelectedItem == null)
            {
                errorProvider1.SetError(cbLoaiSuKien, "Vui lòng chọn loại sự kiện");
                isValid = false;
            }

            if (nudGiaCoBan.Value <= 0)
            {
                errorProvider1.SetError(nudGiaCoBan, "Giá cơ bản phải lớn hơn 0");
                isValid = false;
            }

            if (nudSoKhachToiThieu.Value > nudSoKhachToiDa.Value)
            {
                errorProvider1.SetError(nudSoKhachToiDa, "Số khách tối đa phải lớn hơn số khách tối thiểu");
                isValid = false;
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            dynamic selectedCN = cbMaCN.SelectedItem;
            string maCN = selectedCN != null && selectedCN.Key != null && !string.IsNullOrEmpty(selectedCN.Key.ToString()) 
                ? selectedCN.Key.ToString() : null;

            var result = eventPackageBLL.AddEventPackage(
                txtTenGoiSK.Text.Trim(),
                cbLoaiSuKien.SelectedItem?.ToString(),
                nudGiaCoBan.Value,
                (int)nudSoKhachToiThieu.Value,
                (int)nudSoKhachToiDa.Value,
                (int)nudThoiGianToiThieu.Value,
                (int)nudThoiGianToiDa.Value,
                txtMoTa.Text.Trim(),
                txtDichVuKemTheo.Text.Trim(),
                maCN,
                cbIsGoiMacDinh.Checked,
                true);

            if (result.Success)
            {
                MessageBox.Show("Thêm gói sự kiện thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEventPackages();
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
            if (string.IsNullOrEmpty(selectedMaGoiSK))
            {
                MessageBox.Show("Vui lòng chọn gói sự kiện cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            dynamic selectedCN = cbMaCN.SelectedItem;
            string maCN = selectedCN != null && selectedCN.Key != null && !string.IsNullOrEmpty(selectedCN.Key.ToString())
                ? selectedCN.Key.ToString() : null;

            var result = eventPackageBLL.UpdateEventPackage(
                selectedMaGoiSK,
                txtTenGoiSK.Text.Trim(),
                txtMoTa.Text.Trim(),
                nudGiaCoBan.Value,
                (int)nudSoKhachToiThieu.Value,
                (int)nudSoKhachToiDa.Value,
                (int)nudThoiGianToiThieu.Value,
                (int)nudThoiGianToiDa.Value,
                txtDichVuKemTheo.Text.Trim(),
                maCN,
                true);

            if (result.Success)
            {
                MessageBox.Show("Cập nhật gói sự kiện thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEventPackages();
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
            if (string.IsNullOrEmpty(selectedMaGoiSK))
            {
                MessageBox.Show("Vui lòng chọn gói sự kiện cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa gói sự kiện này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = eventPackageBLL.UpdateEventPackage(selectedMaGoiSK, null, null, null, null, null, null, null, null, null, false);
                if (result.Success)
                {
                    MessageBox.Show("Xóa gói sự kiện thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEventPackages();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lvPackages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPackages.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvPackages.SelectedItems[0];
            if (item.Tag is EventPackage package)
            {
                selectedMaGoiSK = package.MaGoiSK;
                txtMaGoiSK.Text = package.MaGoiSK;
                txtTenGoiSK.Text = package.TenGoiSK ?? "";
                txtMoTa.Text = package.MoTa ?? "";
                txtDichVuKemTheo.Text = package.DichVuKemTheo ?? "";
                nudGiaCoBan.Value = package.GiaCoBan;
                nudSoKhachToiThieu.Value = package.SoKhachToiThieu;
                nudSoKhachToiDa.Value = package.SoKhachToiDa ?? 1000;
                nudThoiGianToiThieu.Value = package.ThoiGianToiThieu ?? 2;
                nudThoiGianToiDa.Value = package.ThoiGianToiDa ?? 12;
                cbIsGoiMacDinh.Checked = package.IsGoiMacDinh;

                for (int i = 0; i < cbLoaiSuKien.Items.Count; i++)
                {
                    if (cbLoaiSuKien.Items[i].ToString() == package.LoaiSuKien)
                    {
                        cbLoaiSuKien.SelectedIndex = i;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(package.MaCN))
                {
                    for (int i = 0; i < cbMaCN.Items.Count; i++)
                    {
                        dynamic cn = cbMaCN.Items[i];
                        if (cn?.Key != null && cn.Key.ToString() == package.MaCN)
                        {
                            cbMaCN.SelectedIndex = i;
                            break;
                        }
                    }
                }
                else
                {
                    cbMaCN.SelectedIndex = 0;
                }

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = !package.IsGoiMacDinh; // Không cho xóa gói mặc định
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void cbLoaiSuKien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiSuKien.SelectedItem != null)
            {
                LoadEventPackages(cbLoaiSuKien.SelectedItem.ToString());
            }
        }
    }
}

