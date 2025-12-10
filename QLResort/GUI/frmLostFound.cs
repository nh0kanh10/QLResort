using QLResort.BLL;
using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.GUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmLostFound : Form
    {
        private readonly LostFoundBLL lostFoundBLL = new LostFoundBLL();
        private readonly EmployeeBLL employeeBLL = new EmployeeBLL();
        private readonly GuestBLL guestBLL = new GuestBLL();
        private readonly ResortBLL resortBLL = new ResortBLL();
        private string selectedMaLF = null;

        public frmLostFound()
        {
            InitializeComponent();
        }

        private void frmLostFound_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadLostFoundItems();
            LoadComboBoxes();
            ResetForm();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleListView(lvLostFound);
            AppTheme.StylePrimaryButton(btnThem);
            AppTheme.StyleSecondaryButton(btnSua);
            AppTheme.StyleSecondaryButton(btnTraDo);
            AppTheme.StyleSecondaryButton(btnReset);
            AppTheme.StyleSecondaryButton(btnXoa);
            
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
            // Load chi nhánh
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

            // Load nhân viên
            cbMaNV.Items.Clear();
            var employees = employeeBLL.GetEmployeesBLL();
            if (employees.Success)
            {
                foreach (var emp in employees.Data)
                {
                    cbMaNV.Items.Add(new { Key = emp.MaNV, Value = emp.HoTen });
                }
                cbMaNV.DisplayMember = "Value";
                cbMaNV.ValueMember = "Key";
                if (cbMaNV.Items.Count > 0) cbMaNV.SelectedIndex = 0;
            }

            // Load khách hàng (optional)
            cbMaKH.Items.Clear();
            cbMaKH.Items.Add(new { Key = "", Value = "(Không có)" });
            var guests = guestBLL.GetGuests();
            if (guests.Success)
            {
                foreach (var guest in guests.Data)
                {
                    cbMaKH.Items.Add(new { Key = guest.MaKH, Value = guest.HoTen });
                }
            }
            cbMaKH.DisplayMember = "Value";
            cbMaKH.ValueMember = "Key";
            if (cbMaKH.Items.Count > 0) cbMaKH.SelectedIndex = 0;

            // Load trạng thái
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Chưa trả");
            cbTrangThai.Items.Add("Đã trả");
            cbTrangThai.Items.Add("Hủy");
            cbTrangThai.SelectedIndex = 0;
        }

        private void LoadLostFoundItems(string trangThaiFilter = null)
        {
            lvLostFound.Items.Clear();
            var result = lostFoundBLL.GetLostFoundItems(trangThai: trangThaiFilter);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var item in result.Data)
            {
                ListViewItem lvItem = new ListViewItem(item.MaLF);
                lvItem.SubItems.Add(item.TenDo ?? "");
                lvItem.SubItems.Add(item.NgayTimThay.ToString("dd/MM/yyyy"));
                lvItem.SubItems.Add(item.DiaDiemTim ?? "");
                lvItem.SubItems.Add(item.TrangThai ?? "Chưa trả");
                lvItem.SubItems.Add(item.NgayTra?.ToString("dd/MM/yyyy") ?? "");
                lvItem.SubItems.Add(item.NguoiNhan ?? "");
                lvItem.Tag = item;
                lvLostFound.Items.Add(lvItem);
            }
        }

        private void ResetForm()
        {
            selectedMaLF = null;
            txtMaLF.Clear();
            txtTenDo.Clear();
            dtpNgayTimThay.Value = DateTime.Now;
            txtDiaDiemTim.Clear();
            txtGhiChu.Clear();
            txtNguoiNhan.Clear();
            dtpNgayTra.Value = DateTime.Now;
            dtpNgayTra.Enabled = false;
            txtNguoiNhan.Enabled = false;
            if (cbMaCN.Items.Count > 0) cbMaCN.SelectedIndex = 0;
            if (cbMaNV.Items.Count > 0) cbMaNV.SelectedIndex = 0;
            if (cbMaKH.Items.Count > 0) cbMaKH.SelectedIndex = 0;
            if (cbTrangThai.Items.Count > 0) cbTrangThai.SelectedIndex = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnTraDo.Enabled = false;
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTenDo.Text))
            {
                errorProvider1.SetError(txtTenDo, "Tên đồ không được để trống");
                isValid = false;
            }

            if (cbMaCN.SelectedItem == null)
            {
                errorProvider1.SetError(cbMaCN, "Vui lòng chọn chi nhánh");
                isValid = false;
            }

            if (cbMaNV.SelectedItem == null)
            {
                errorProvider1.SetError(cbMaNV, "Vui lòng chọn nhân viên");
                isValid = false;
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (cbMaCN.SelectedItem == null || cbMaNV.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selectedCN = cbMaCN.SelectedItem;
            dynamic selectedNV = cbMaNV.SelectedItem;
            dynamic selectedKH = cbMaKH.SelectedItem;

            string maCN = selectedCN?.Key?.ToString();
            string maNV = selectedNV?.Key?.ToString();
            string maKH = selectedKH != null && selectedKH.Key != null ? selectedKH.Key.ToString() : null;

            if (string.IsNullOrEmpty(maCN) || string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = lostFoundBLL.AddLostFoundItem(
                txtTenDo.Text.Trim(),
                maNV,
                maCN,
                dtpNgayTimThay.Value,
                txtDiaDiemTim.Text.Trim(),
                maKH,
                txtGhiChu.Text.Trim());

            if (result.Success)
            {
                MessageBox.Show("Thêm đồ thất lạc thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLostFoundItems();
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
            if (string.IsNullOrEmpty(selectedMaLF))
            {
                MessageBox.Show("Vui lòng chọn đồ thất lạc cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selectedKH = cbMaKH.SelectedItem;
            string maKH = selectedKH != null && selectedKH.Key != null ? selectedKH.Key.ToString() : null;

            var result = lostFoundBLL.UpdateLostFoundItem(
                selectedMaLF,
                maKH,
                cbTrangThai.SelectedItem?.ToString(),
                dtpNgayTra.Enabled ? (DateTime?)dtpNgayTra.Value : null,
                txtNguoiNhan.Text.Trim(),
                txtGhiChu.Text.Trim());

            if (result.Success)
            {
                MessageBox.Show("Cập nhật đồ thất lạc thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLostFoundItems();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTraDo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaLF))
            {
                MessageBox.Show("Vui lòng chọn đồ thất lạc cần trả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNguoiNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người nhận!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = lostFoundBLL.UpdateLostFoundItem(
                selectedMaLF,
                null,
                "Đã trả",
                DateTime.Now,
                txtNguoiNhan.Text.Trim(),
                txtGhiChu.Text.Trim());

            if (result.Success)
            {
                MessageBox.Show("Trả đồ thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLostFoundItems();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvLostFound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLostFound.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvLostFound.SelectedItems[0];
            if (item.Tag is LostFoundItem lostFound)
            {
                selectedMaLF = lostFound.MaLF;
                txtMaLF.Text = lostFound.MaLF;
                txtTenDo.Text = lostFound.TenDo ?? "";
                dtpNgayTimThay.Value = lostFound.NgayTimThay;
                txtDiaDiemTim.Text = lostFound.DiaDiemTim ?? "";
                txtGhiChu.Text = lostFound.GhiChu ?? "";
                txtNguoiNhan.Text = lostFound.NguoiNhan ?? "";
                if (lostFound.NgayTra.HasValue)
                {
                    dtpNgayTra.Value = lostFound.NgayTra.Value;
                    dtpNgayTra.Enabled = true;
                }
                else
                {
                    dtpNgayTra.Enabled = false;
                }

                // Set comboboxes
                for (int i = 0; i < cbMaCN.Items.Count; i++)
                {
                    dynamic cn = cbMaCN.Items[i];
                    if (cn?.Key != null && cn.Key.ToString() == lostFound.MaCN)
                    {
                        cbMaCN.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cbMaNV.Items.Count; i++)
                {
                    dynamic nv = cbMaNV.Items[i];
                    if (nv?.Key != null && nv.Key.ToString() == lostFound.MaNV)
                    {
                        cbMaNV.SelectedIndex = i;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(lostFound.MaKH))
                {
                    for (int i = 0; i < cbMaKH.Items.Count; i++)
                    {
                        dynamic kh = cbMaKH.Items[i];
                        if (kh.Key != null && kh.Key.ToString() == lostFound.MaKH)
                        {
                            cbMaKH.SelectedIndex = i;
                            break;
                        }
                    }
                }

                for (int i = 0; i < cbTrangThai.Items.Count; i++)
                {
                    if (cbTrangThai.Items[i].ToString() == lostFound.TrangThai)
                    {
                        cbTrangThai.SelectedIndex = i;
                        break;
                    }
                }

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnTraDo.Enabled = lostFound.TrangThai == "Chưa trả";
                txtNguoiNhan.Enabled = lostFound.TrangThai == "Chưa trả";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaLF))
            {
                MessageBox.Show("Vui lòng chọn đồ thất lạc cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa đồ thất lạc này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = lostFoundBLL.DeleteLostFoundItem(selectedMaLF);
                if (result.Success)
                {
                    MessageBox.Show("Xóa đồ thất lạc thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLostFoundItems();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTrangThai.SelectedItem?.ToString() == "Đã trả")
            {
                dtpNgayTra.Enabled = true;
                txtNguoiNhan.Enabled = true;
            }
            else
            {
                dtpNgayTra.Enabled = false;
                txtNguoiNhan.Enabled = false;
            }
        }
    }
}

