using QLResort.BLL;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmComplaint : Form
    {
        private readonly ComplaintBLL complaintBLL = new ComplaintBLL();
        private readonly GuestBLL guestBLL = new GuestBLL();
        private readonly EmployeeBLL employeeBLL = new EmployeeBLL();
        private readonly ResortBLL resortBLL = new ResortBLL();
        private string selectedMaKN = null;

        public frmComplaint()
        {
            InitializeComponent();
        }

        private void frmComplaint_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadComplaints();
            LoadComboBoxes();
            ResetForm();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            AppTheme.StyleListView(lvComplaints);
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
            cbMaKH.Items.Clear();
            var guests = guestBLL.GetGuests();
            if (guests.Success)
            {
                foreach (var guest in guests.Data)
                {
                    cbMaKH.Items.Add(new { Key = guest.MaKH, Value = guest.HoTen });
                }
                cbMaKH.DisplayMember = "Value";
                cbMaKH.ValueMember = "Key";
                if (cbMaKH.Items.Count > 0) cbMaKH.SelectedIndex = 0;
            }

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

            cbMaNV.Items.Clear();
            cbMaNV.Items.Add(new { Key = "", Value = "(Chưa phân công)" });
            var employees = employeeBLL.GetEmployeesBLL();
            if (employees.Success)
            {
                foreach (var emp in employees.Data)
                {
                    cbMaNV.Items.Add(new { Key = emp.MaNV, Value = emp.HoTen });
                }
            }
            cbMaNV.DisplayMember = "Value";
            cbMaNV.ValueMember = "Key";
            if (cbMaNV.Items.Count > 0) cbMaNV.SelectedIndex = 0;

            cbMucDo.Items.Clear();
            cbMucDo.Items.Add("Thường");
            cbMucDo.Items.Add("Nghiêm trọng");
            cbMucDo.Items.Add("Rất nghiêm trọng");
            if (cbMucDo.Items.Count > 0) cbMucDo.SelectedIndex = 0;

            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Chưa xử lý");
            cbTrangThai.Items.Add("Đang xử lý");
            cbTrangThai.Items.Add("Đã xong");
            cbTrangThai.Items.Add("Hủy");
            if (cbTrangThai.Items.Count > 0) cbTrangThai.SelectedIndex = 0;
        }

        private void LoadComplaints()
        {
            lvComplaints.Items.Clear();
            var result = complaintBLL.GetComplaints();

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var complaint in result.Data)
            {
                ListViewItem item = new ListViewItem(complaint.MaKN);
                item.SubItems.Add(complaint.NgayGhi.ToString("dd/MM/yyyy"));
                item.SubItems.Add(complaint.MucDo ?? "Thường");
                item.SubItems.Add(complaint.TrangThai ?? "Chưa xử lý");
                item.SubItems.Add(complaint.SoTienBoiThuong.ToString("N0"));
                item.Tag = complaint;
                lvComplaints.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            selectedMaKN = null;
            txtMaKN.Clear();
            txtNoiDung.Clear();
            txtKetQua.Clear();
            txtSoTienBoiThuong.Clear();
            txtGhiChu.Clear();
            dtpNgayGhi.Value = DateTime.Now;
            if (cbMaKH.Items.Count > 0) cbMaKH.SelectedIndex = 0;
            if (cbMaCN.Items.Count > 0) cbMaCN.SelectedIndex = 0;
            if (cbMaNV.Items.Count > 0) cbMaNV.SelectedIndex = 0;
            if (cbMucDo.Items.Count > 0) cbMucDo.SelectedIndex = 0;
            if (cbTrangThai.Items.Count > 0) cbTrangThai.SelectedIndex = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (cbMaKH.SelectedItem == null)
            {
                errorProvider1.SetError(cbMaKH, "Vui lòng chọn khách hàng");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                errorProvider1.SetError(txtNoiDung, "Nội dung khiếu nại không được để trống");
                isValid = false;
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (cbMaKH.SelectedItem == null || cbMaCN.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selectedKH = cbMaKH.SelectedItem;
            dynamic selectedCN = cbMaCN.SelectedItem;

            string maKH = selectedKH?.Key?.ToString();
            string maCN = selectedCN?.Key?.ToString();

            if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(maCN))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = complaintBLL.AddComplaint(
                maKH,
                maCN,
                txtNoiDung.Text.Trim(),
                cbMucDo.SelectedItem?.ToString(),
                txtGhiChu.Text.Trim());

            if (result.Success)
            {
                MessageBox.Show("Thêm khiếu nại thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadComplaints();
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
            if (string.IsNullOrEmpty(selectedMaKN))
            {
                MessageBox.Show("Vui lòng chọn khiếu nại cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = null;
            if (cbMaNV.SelectedItem != null)
            {
                dynamic selectedNV = cbMaNV.SelectedItem;
                maNV = selectedNV?.Key?.ToString();
                if (string.IsNullOrEmpty(maNV) || maNV == "(Chưa phân công)") maNV = null;
            }

            decimal? soTien = null;
            if (decimal.TryParse(txtSoTienBoiThuong.Text.Trim(), out decimal tien))
                soTien = tien;

            var result = complaintBLL.UpdateComplaint(
                selectedMaKN,
                maNV,
                cbTrangThai.SelectedItem?.ToString(),
                txtKetQua.Text.Trim(),
                soTien,
                txtGhiChu.Text.Trim());

            if (result.Success)
            {
                MessageBox.Show("Cập nhật khiếu nại thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadComplaints();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvComplaints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvComplaints.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvComplaints.SelectedItems[0];
            if (item.Tag is Complaint complaint)
            {
                selectedMaKN = complaint.MaKN;
                txtMaKN.Text = complaint.MaKN;
                txtNoiDung.Text = complaint.NoiDung ?? "";
                txtKetQua.Text = complaint.KetQua ?? "";
                txtSoTienBoiThuong.Text = complaint.SoTienBoiThuong.ToString("N0");
                txtGhiChu.Text = complaint.GhiChu ?? "";
                dtpNgayGhi.Value = complaint.NgayGhi;

                for (int i = 0; i < cbMaKH.Items.Count; i++)
                {
                    dynamic kh = cbMaKH.Items[i];
                    if (kh?.Key != null && kh.Key.ToString() == complaint.MaKH)
                    {
                        cbMaKH.SelectedIndex = i;
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(complaint.MaNV))
                {
                    for (int i = 0; i < cbMaNV.Items.Count; i++)
                    {
                        dynamic nv = cbMaNV.Items[i];
                        if (nv.Key != null && nv.Key.ToString() == complaint.MaNV)
                        {
                            cbMaNV.SelectedIndex = i;
                            break;
                        }
                    }
                }

                for (int i = 0; i < cbMucDo.Items.Count; i++)
                {
                    if (cbMucDo.Items[i].ToString() == complaint.MucDo)
                    {
                        cbMucDo.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cbTrangThai.Items.Count; i++)
                {
                    if (cbTrangThai.Items[i].ToString() == complaint.TrangThai)
                    {
                        cbTrangThai.SelectedIndex = i;
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
            if (string.IsNullOrEmpty(selectedMaKN))
            {
                MessageBox.Show("Vui lòng chọn khiếu nại cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khiếu nại này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = complaintBLL.DeleteComplaint(selectedMaKN);
                if (result.Success)
                {
                    MessageBox.Show("Xóa khiếu nại thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadComplaints();
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

