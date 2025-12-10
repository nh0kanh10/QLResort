using QLResort.BLL;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmEvent : Form
    {
        private readonly EventBLL eventBLL = new EventBLL();
        private readonly ResortBLL resortBLL = new ResortBLL();
        private string selectedMaSK = null;

        public frmEvent()
        {
            InitializeComponent();
        }

        private void frmEvent_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadEvents();
            LoadComboBoxes();
            ResetForm();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleListView(lvEvents);
            AppTheme.StylePrimaryButton(btnThem);
            AppTheme.StyleSecondaryButton(btnSua);
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
            cbMaCN.Items.Clear();
            var resorts = resortBLL.GetResorts();
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

            cbLoaiSuKien.Items.Clear();
            cbLoaiSuKien.Items.Add("Cưới");
            cbLoaiSuKien.Items.Add("Team building");
            cbLoaiSuKien.Items.Add("Hội nghị");
            cbLoaiSuKien.Items.Add("Khác");
            if (cbLoaiSuKien.Items.Count > 0) cbLoaiSuKien.SelectedIndex = 0;
        }

        private void LoadEvents()
        {
            lvEvents.Items.Clear();
            var result = eventBLL.GetEvents();

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var evt in result.Data)
            {
                ListViewItem item = new ListViewItem(evt.MaSK);
                item.SubItems.Add(evt.TenSK ?? "");
                item.SubItems.Add(evt.LoaiSuKien ?? "");
                item.SubItems.Add(evt.DiaDiem ?? "");
                item.SubItems.Add(evt.TongChiPhi?.ToString("N0") ?? "0");
                item.SubItems.Add(evt.IsActive ? "✓" : "✗");
                item.Tag = evt;
                lvEvents.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            selectedMaSK = null;
            txtMaSK.Clear();
            txtTenSK.Clear();
            txtDiaDiem.Clear();
            txtGhiChu.Clear();
            txtTongChiPhi.Clear();
            cbIsActive.Checked = true;
            if (cbMaCN.Items.Count > 0) cbMaCN.SelectedIndex = 0;
            if (cbLoaiSuKien.Items.Count > 0) cbLoaiSuKien.SelectedIndex = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTenSK.Text))
            {
                errorProvider1.SetError(txtTenSK, "Tên sự kiện không được để trống");
                isValid = false;
            }

            if (cbMaCN.SelectedItem == null)
            {
                errorProvider1.SetError(cbMaCN, "Vui lòng chọn chi nhánh");
                isValid = false;
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (cbMaCN.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selectedCN = cbMaCN.SelectedItem;
            string maCN = selectedCN?.Key?.ToString();

            if (string.IsNullOrEmpty(maCN))
            {
                MessageBox.Show("Vui lòng chọn chi nhánh!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal? tongChiPhi = null;
            if (decimal.TryParse(txtTongChiPhi.Text.Trim(), out decimal chiPhi))
                tongChiPhi = chiPhi;

            var result = eventBLL.AddEvent(
                txtTenSK.Text.Trim(),
                cbLoaiSuKien.SelectedItem?.ToString(),
                maCN,
                txtDiaDiem.Text.Trim(),
                txtGhiChu.Text.Trim(),
                tongChiPhi,
                cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Thêm sự kiện thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEvents();
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
            if (string.IsNullOrEmpty(selectedMaSK))
            {
                MessageBox.Show("Vui lòng chọn sự kiện cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            decimal? tongChiPhi = null;
            if (decimal.TryParse(txtTongChiPhi.Text.Trim(), out decimal chiPhi))
                tongChiPhi = chiPhi;

            var result = eventBLL.UpdateEvent(
                selectedMaSK,
                txtTenSK.Text.Trim(),
                cbLoaiSuKien.SelectedItem?.ToString(),
                txtDiaDiem.Text.Trim(),
                txtGhiChu.Text.Trim(),
                tongChiPhi,
                cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Cập nhật sự kiện thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadEvents();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEvents.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvEvents.SelectedItems[0];
            if (item.Tag is Event evt)
            {
                selectedMaSK = evt.MaSK;
                txtMaSK.Text = evt.MaSK;
                txtTenSK.Text = evt.TenSK ?? "";
                txtDiaDiem.Text = evt.DiaDiem ?? "";
                txtGhiChu.Text = evt.GhiChu ?? "";
                txtTongChiPhi.Text = evt.TongChiPhi?.ToString("N0") ?? "";
                cbIsActive.Checked = evt.IsActive;

                for (int i = 0; i < cbMaCN.Items.Count; i++)
                {
                    dynamic cn = cbMaCN.Items[i];
                    if (cn?.Key != null && cn.Key.ToString() == evt.MaCN)
                    {
                        cbMaCN.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cbLoaiSuKien.Items.Count; i++)
                {
                    if (cbLoaiSuKien.Items[i].ToString() == evt.LoaiSuKien)
                    {
                        cbLoaiSuKien.SelectedIndex = i;
                        break;
                    }
                }

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
            if (string.IsNullOrEmpty(selectedMaSK))
            {
                MessageBox.Show("Vui lòng chọn sự kiện cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sự kiện này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = eventBLL.DeleteEvent(selectedMaSK);
                if (result.Success)
                {
                    MessageBox.Show("Xóa sự kiện thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEvents();
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

