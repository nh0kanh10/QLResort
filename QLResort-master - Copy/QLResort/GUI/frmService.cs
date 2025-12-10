using QLResort.BLL;
using QLResort.Core.Model;
using QLResort.Core.Validation;
using QLResort.GUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmService : Form
    {
        private readonly ServiceBLL serviceBLL = new ServiceBLL();
        private string selectedMaDV = null;

        public frmService()
        {
            InitializeComponent();
        }

        private void frmService_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadServices();
            LoadLoaiDV();
            ResetForm();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleListView(lvServices);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt) AppTheme.StyleTextBox(txt);
                else if (ctrl is ComboBox cb) AppTheme.StyleComboBox(cb);
                else if (ctrl is DateTimePicker dtp) AppTheme.StyleDateTimePicker(dtp);
                else if (ctrl is Label lbl) AppTheme.StyleLabel(lbl);
                else if (ctrl is Button btn) AppTheme.StylePrimaryButton(btn);
            }
        }

        private void LoadLoaiDV()
        {
            cbLoaiDV.Items.Clear();
            cbLoaiDV.Items.Add("Ăn uống");
            cbLoaiDV.Items.Add("Giải trí");
            cbLoaiDV.Items.Add("Spa & Massage");
            cbLoaiDV.Items.Add("Thể thao");
            cbLoaiDV.Items.Add("Khác");
            if (cbLoaiDV.Items.Count > 0) cbLoaiDV.SelectedIndex = 0;
        }

        private void LoadServices()
        {
            lvServices.Items.Clear();
            var result = serviceBLL.GetServices(isActive: null);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var service in result.Data)
            {
                ListViewItem item = new ListViewItem(service.MaDV);
                item.SubItems.Add(service.TenDV ?? "");
                item.SubItems.Add(service.LoaiDV ?? "");
                item.SubItems.Add(service.Gia?.ToString("N0") ?? "0");
                item.SubItems.Add(service.ChoPhepDoiDiem ? "Có" : "Không");
                item.SubItems.Add(service.GiaTriDoiDiem?.ToString() ?? "0");
                item.SubItems.Add(service.IsActive ? "✓" : "✗");
                item.Tag = service;
                lvServices.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            selectedMaDV = null;
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtMoTa.Clear();
            txtGia.Clear();
            txtGiaTriDoiDiem.Clear();
            cbChoPhepDoiDiem.Checked = false;
            cbIsActive.Checked = true;
            if (cbLoaiDV.Items.Count > 0) cbLoaiDV.SelectedIndex = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTenDV.Text))
            {
                errorProvider1.SetError(txtTenDV, "Tên dịch vụ không được để trống");
                isValid = false;
            }

            if (!string.IsNullOrWhiteSpace(txtGia.Text))
            {
                if (!decimal.TryParse(txtGia.Text, out decimal gia) || gia < 0)
                {
                    errorProvider1.SetError(txtGia, "Giá phải là số lớn hơn hoặc bằng 0");
                    isValid = false;
                }
            }

            if (cbChoPhepDoiDiem.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtGiaTriDoiDiem.Text))
                {
                    errorProvider1.SetError(txtGiaTriDoiDiem, "Nếu cho phép đổi điểm thì giá trị đổi điểm không được để trống");
                    isValid = false;
                }
                else if (!int.TryParse(txtGiaTriDoiDiem.Text, out int diem) || diem <= 0)
                {
                    errorProvider1.SetError(txtGiaTriDoiDiem, "Giá trị đổi điểm phải là số nguyên dương");
                    isValid = false;
                }
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            decimal? gia = null;
            if (decimal.TryParse(txtGia.Text.Trim(), out decimal giaValue))
                gia = giaValue;

            int? giaTriDoiDiem = null;
            if (cbChoPhepDoiDiem.Checked &&
                int.TryParse(txtGiaTriDoiDiem.Text.Trim(), out int diem))
                giaTriDoiDiem = diem;

            var result = serviceBLL.AddService(
                txtTenDV.Text.Trim(),
                cbLoaiDV.SelectedItem?.ToString(),
                txtMoTa.Text.Trim(),
                gia,
                cbChoPhepDoiDiem.Checked,
                giaTriDoiDiem,
                cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadServices();
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
            if (string.IsNullOrEmpty(selectedMaDV))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            decimal? gia = null;
            if (decimal.TryParse(txtGia.Text.Trim(), out decimal giaValue))
                gia = giaValue;

            int? giaTriDoiDiem = null;
            if (cbChoPhepDoiDiem.Checked && int.TryParse(txtGiaTriDoiDiem.Text.Trim(), out int diem))
                giaTriDoiDiem = diem;

            var result = serviceBLL.UpdateService(
                selectedMaDV,
                txtTenDV.Text.Trim(),
                cbLoaiDV.SelectedItem?.ToString(),
                txtMoTa.Text.Trim(),
                gia,
                cbChoPhepDoiDiem.Checked,
                giaTriDoiDiem,
                cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Cập nhật dịch vụ thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadServices();
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
            if (string.IsNullOrEmpty(selectedMaDV))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này không?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var result = serviceBLL.DeleteService(selectedMaDV);
                if (result.Success)
                {
                    MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadServices();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lvServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvServices.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvServices.SelectedItems[0];
            if (item.Tag is Service service)
            {
                selectedMaDV = service.MaDV;
                txtMaDV.Text = service.MaDV;
                txtTenDV.Text = service.TenDV ?? "";
                txtMoTa.Text = service.MoTa ?? "";
                txtGia.Text = service.Gia?.ToString("N0") ?? "";
                cbChoPhepDoiDiem.Checked = service.ChoPhepDoiDiem;
                txtGiaTriDoiDiem.Text = service.GiaTriDoiDiem?.ToString() ?? "";
                cbIsActive.Checked = service.IsActive;

                // Tìm và chọn loại dịch vụ
                for (int i = 0; i < cbLoaiDV.Items.Count; i++)
                {
                    if (cbLoaiDV.Items[i].ToString() == service.LoaiDV)
                    {
                        cbLoaiDV.SelectedIndex = i;
                        break;
                    }
                }

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void cbChoPhepDoiDiem_CheckedChanged(object sender, EventArgs e)
        {
            txtGiaTriDoiDiem.Enabled = cbChoPhepDoiDiem.Checked;
            if (!cbChoPhepDoiDiem.Checked)
                txtGiaTriDoiDiem.Clear();
        }
    }
}







