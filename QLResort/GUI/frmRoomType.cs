using QLResort.BUS;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmRoomType : AppBaseForm
    {
        private readonly RoomTypeBUS roomTypeBUS = new RoomTypeBUS();
        private string selectedMaLP = null;

        public frmRoomType()
        {
            InitializeComponent();
        }

        private void frmRoomType_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadRoomTypes();
            ResetForm();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleListView(lvRoomTypes);
            AppTheme.StylePrimaryButton(btnThem);
            AppTheme.StyleSecondaryButton(btnSua);
            AppTheme.StyleDangerButton(btnXoa);
            AppTheme.StyleSecondaryButton(btnReset);
            
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt) AppTheme.StyleTextBox(txt);
                else if (ctrl is ComboBox cb) AppTheme.StyleComboBox(cb);
                else if (ctrl is DateTimePicker dtp) AppTheme.StyleDateTimePicker(dtp);
                else if (ctrl is Label lbl) AppTheme.StyleLabel(lbl);
                else if (ctrl is NumericUpDown num) AppTheme.StyleNumericUpDown(num);
            }
        }

        private void LoadRoomTypes()
        {
            lvRoomTypes.Items.Clear();
            var result = roomTypeBUS.GetRoomTypes(isActive: null);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var rt in result.Data)
            {
                ListViewItem item = new ListViewItem(rt.MaLP);
                item.SubItems.Add(rt.TenLP ?? "");
                item.SubItems.Add(rt.IsNhaNguyenCan ? "Nhà nguyên căn" : "Phòng thường");
                item.SubItems.Add(rt.SoPhongTrongNha.ToString());
                item.SubItems.Add(rt.GiaTheoNgay?.ToString("N0") ?? "0");
                item.SubItems.Add(rt.SucChuaToiDa?.ToString() ?? "0");
                item.SubItems.Add(rt.IsActive ? "✓" : "✗");
                item.Tag = rt;
                lvRoomTypes.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            selectedMaLP = null;
            txtMaLP.Clear();
            txtTenLP.Clear();
            txtMoTa.Clear();
            cbIsNhaNguyenCan.Checked = false;
            numSoPhongTrongNha.Value = 1;
            txtGiaTheoGio.Clear();
            txtGiaTheoNgay.Clear();
            txtGiaTheoThang.Clear();
            numSucChuaToiDa.Value = 1;
            cbIsActive.Checked = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            UpdateNhaNguyenCanControls();
        }

        private void UpdateNhaNguyenCanControls()
        {
            numSoPhongTrongNha.Enabled = cbIsNhaNguyenCan.Checked;
            if (!cbIsNhaNguyenCan.Checked)
                numSoPhongTrongNha.Value = 1;
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTenLP.Text))
            {
                errorProvider1.SetError(txtTenLP, "Tên loại phòng không được để trống");
                isValid = false;
            }

            if (cbIsNhaNguyenCan.Checked && numSoPhongTrongNha.Value <= 0)
            {
                errorProvider1.SetError(numSoPhongTrongNha, "Số phòng trong nhà phải lớn hơn 0");
                isValid = false;
            }

            if (!string.IsNullOrWhiteSpace(txtGiaTheoNgay.Text))
            {
                if (!decimal.TryParse(txtGiaTheoNgay.Text, out decimal gia) || gia < 0)
                {
                    errorProvider1.SetError(txtGiaTheoNgay, "Giá theo ngày phải là số lớn hơn hoặc bằng 0");
                    isValid = false;
                }
            }

            if (numSucChuaToiDa.Value <= 0)
            {
                errorProvider1.SetError(numSucChuaToiDa, "Sức chứa tối đa phải lớn hơn 0");
                isValid = false;
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            decimal? giaTheoGio = null;
            decimal? giaTheoNgay = null;
            decimal? giaTheoThang = null;

            if (decimal.TryParse(txtGiaTheoGio.Text.Trim(), out decimal gio))
                giaTheoGio = gio;

            if (decimal.TryParse(txtGiaTheoNgay.Text.Trim(), out decimal ngay))
                giaTheoNgay = ngay;

            if (decimal.TryParse(txtGiaTheoThang.Text.Trim(), out decimal thang))
                giaTheoThang = thang;

            var result = roomTypeBUS.AddRoomType(
                txtTenLP.Text.Trim(),
                txtMoTa.Text.Trim(),
                cbIsNhaNguyenCan.Checked,
                (int)numSoPhongTrongNha.Value,
                giaTheoGio,
                giaTheoNgay,
                giaTheoThang,
                (int)numSucChuaToiDa.Value,
                cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Thêm loại phòng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRoomTypes();
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
            if (string.IsNullOrEmpty(selectedMaLP))
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            decimal? giaTheoGio = null;
            decimal? giaTheoNgay = null;
            decimal? giaTheoThang = null;

            if (decimal.TryParse(txtGiaTheoGio.Text.Trim(), out decimal gio))
                giaTheoGio = gio;

            if (decimal.TryParse(txtGiaTheoNgay.Text.Trim(), out decimal ngay))
                giaTheoNgay = ngay;

            if (decimal.TryParse(txtGiaTheoThang.Text.Trim(), out decimal thang))
                giaTheoThang = thang;

            var result = roomTypeBUS.UpdateRoomType(
                selectedMaLP,
                txtTenLP.Text.Trim(),
                txtMoTa.Text.Trim(),
                cbIsNhaNguyenCan.Checked,
                (int)numSoPhongTrongNha.Value,
                giaTheoGio,
                giaTheoNgay,
                giaTheoThang,
                (int)numSucChuaToiDa.Value,
                cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Cập nhật loại phòng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRoomTypes();
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
            if (string.IsNullOrEmpty(selectedMaLP))
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa loại phòng này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var result = roomTypeBUS.DeleteRoomType(selectedMaLP);
                if (result.Success)
                {
                    MessageBox.Show("Xóa loại phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRoomTypes();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lvRoomTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRoomTypes.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvRoomTypes.SelectedItems[0];
            if (item.Tag is RoomType rt)
            {
                selectedMaLP = rt.MaLP;
                txtMaLP.Text = rt.MaLP;
                txtTenLP.Text = rt.TenLP ?? "";
                txtMoTa.Text = rt.MoTa ?? "";
                cbIsNhaNguyenCan.Checked = rt.IsNhaNguyenCan;
                numSoPhongTrongNha.Value = rt.SoPhongTrongNha;
                txtGiaTheoGio.Text = rt.GiaTheoGio?.ToString("N0") ?? "";
                txtGiaTheoNgay.Text = rt.GiaTheoNgay?.ToString("N0") ?? "";
                txtGiaTheoThang.Text = rt.GiaTheoThang?.ToString("N0") ?? "";
                numSucChuaToiDa.Value = rt.SucChuaToiDa ?? 1;
                cbIsActive.Checked = rt.IsActive;

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                UpdateNhaNguyenCanControls();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void cbIsNhaNguyenCan_CheckedChanged(object sender, EventArgs e)
        {
            UpdateNhaNguyenCanControls();
        }
    }
}







