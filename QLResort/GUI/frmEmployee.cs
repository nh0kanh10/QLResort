using QLResort.BLL;
using QLResort.Core.ClassHoTro;
using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.EmployeeDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLResort.GUI.Employee
{
    public partial class frmEmployee : Form
    {
        private readonly EmployeeBLL EBLL = new EmployeeBLL();
        private Dictionary<string, string> dictLoaiNV;
        public List<string> listChucVu = new List<string>() { "Nhân viên", "Trưởng phòng", "Quản lý", "Giám đốc" };

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            frmEmployeeType frmLoaiNV = new frmEmployeeType();
            var result = frmLoaiNV.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadEmployeeTypeBLL();
            }
        }
        public void LoadEmployeeTypeBLL()
        {
            cbLNV.Items.Clear();

            var result = EBLL.GetDataLoaiNVBLL();

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dictLoaiNV = result.Data;

            foreach (var kv in dictLoaiNV)
            {
                cbLNV.Items.Add(new ComboBoxItem(kv.Key, kv.Value));
            }

            cbLNV.DisplayMember = "Text";
            cbLNV.ValueMember = "ID";

            if (cbLNV.Items.Count > 0) cbLNV.SelectedIndex = 0;
        }


        private string GetSelectedMaLoaiNV()
        {
            if (cbLNV.SelectedItem is ComboBoxItem em)
                return em.ID;
            return string.Empty;
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployeeTypeBLL();

            rbNam.Checked = true;
            txtCN.Text = Session_Now.CurrentResort;

            foreach (string itemCV in listChucVu)
            {
                cbChucVu.Items.Add(itemCV);
            }

            if (cbChucVu.Items.Count > 0) cbChucVu.SelectedIndex = 0;

            lvResult.Items.Clear();

            FormLoadEmployee();
        }
        public void FormLoadEmployee()
        {
            lvResult.Items.Clear();

            OperationResult<List<EmployeeM>> list = EBLL.GetEmployeesBLL(maCN: Session_Now.CurrentResort);
            if (!list.Success)
            {
                MessageBox.Show(list.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (EmployeeM item in list.Data)
            {
                ListViewItem emp = new ListViewItem(item.MaNV);
                emp.SubItems.Add(item.HoTen);
                emp.SubItems.Add(item.ChucVu);
                emp.SubItems.Add(item.CCCD);
                emp.SubItems.Add(item.GioiTinh);
                emp.SubItems.Add(item.SDT);
                emp.SubItems.Add(item.Email);
                emp.SubItems.Add(item.TenCN);
                emp.SubItems.Add(item.IsActive ? "✓" : "✗");
                emp.SubItems.Add(item.CreatedBy);
                emp.SubItems.Add(item.TenLoaiNV);
                lvResult.Items.Add(emp);
            }
        }

        public bool ValidateEmployee()
        {
            bool isValid = true;
            errorProvider1.Clear();

            if (!Validator.IsRequired(txtCN.Text))
            {
                errorProvider1.SetError(txtCN, "Mã chi nhánh không được để trống.");
                isValid = false;
            }

            if (!Validator.IsRequired(txtCCCD.Text) || !Validator.MaxLength(txtCCCD.Text, 12))
            {
                errorProvider1.SetError(txtCCCD, "CCCD phải đủ 12 ký tự.");
                isValid = false;
            }

            if (!Validator.IsRequired(txtSDT.Text) || !Validator.IsPhoneNumber(txtSDT.Text))
            {
                errorProvider1.SetError(txtSDT, "SĐT không hợp lệ (9-11 chữ số).");
                isValid = false;
            }

            if (!Validator.IsRequired(txtEmail.Text) || !Validator.IsEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Email không hợp lệ.");
                isValid = false;
            }

            return isValid;
        }
        private void ResetForm()
        {
            txtCCCD.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            rbNam.Checked = true;
            rbNu.Checked = false;
            if (cbChucVu.Items.Count > 0) cbChucVu.SelectedIndex = 0;
            if (cbLNV.Items.Count > 0) cbLNV.SelectedIndex = 0;
            cbHD.Checked = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployee()) return;

            if (string.IsNullOrEmpty(Session_Now.CurrentResort) || string.IsNullOrEmpty(Session_Now.CurrentUser))
            {
                MessageBox.Show("Vui lòng chọn resort và đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gioitinh = rbNam.Checked ? "Nam" : "Nữ";
            string chucVu = cbChucVu.SelectedItem?.ToString() ?? "";
            string maLoaiNV = GetSelectedMaLoaiNV();
            bool isActive = cbHD.Checked;

            EmployeeM.stt++;
            OperationResult<EmployeeM> result = EBLL.AddEmployee(txtCCCD.Text.Trim(), txtHoTen.Text.Trim(),
                gioitinh, chucVu, txtSDT.Text.Trim(), txtEmail.Text.Trim(), maLoaiNV, isActive);

            if (result.Success)
            {
                MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormLoadEmployee();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmployeeM.stt--;
            }
        }

        private void lvResult_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvResult.SelectedItems.Count == 0) return;

            ListViewItem item = lvResult.SelectedItems[0];
            txtHoTen.Text = item.SubItems[1].Text;
            string chucVu = item.SubItems[2].Text;
            cbChucVu.SelectedItem = chucVu;

            txtCCCD.Text = item.SubItems[3].Text;
            if (rbNam.Text == item.SubItems[4].Text) rbNam.Checked = true;
            else rbNu.Checked = true;
            txtSDT.Text = item.SubItems[5].Text;
            txtEmail.Text = item.SubItems[6].Text;
            txtCN.Text = item.SubItems[7].Text;
            cbHD.Checked = item.SubItems[8].Text == "✓";

            string maLoai = item.SubItems[10].Text;
            SelectLoaiNVById(maLoai);
        }

        private void SelectLoaiNVById(string maLoai)
        {
            if (string.IsNullOrEmpty(maLoai)) return;
            foreach (var item in cbLNV.Items)
            {
                if (item is ComboBoxItem cbItem && cbItem.Text.Trim() == maLoai.Trim())
                {
                    cbLNV.SelectedItem = cbItem;
                    return;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvResult.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa!", "Thông báo");
                return;
            }

            string message = lvResult.SelectedItems.Count == 1
                ? "Bạn có chắc muốn xóa dòng vừa chọn không?"
                : $"Bạn có chắc muốn xóa {lvResult.SelectedItems.Count} dòng đã chọn không?";

            if (MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                List<ListViewItem> itemsToRemove = new List<ListViewItem>();
                int successCount = 0;
                int failCount = 0;

                foreach (ListViewItem item in lvResult.SelectedItems)
                {
                    var result = EBLL.DeleteEmployee(item.SubItems[0].Text);
                    if (result.Success)
                    {
                        itemsToRemove.Add(item);
                        successCount++;
                    }
                    else
                    {
                        failCount++;
                        MessageBox.Show(result.ErrorMessage, "Lỗi khi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                foreach (var item in itemsToRemove) lvResult.Items.Remove(item);

                if (successCount > 0)
                {
                    string successMsg = lvResult.SelectedItems.Count == 1 ? "Xóa thành công!" : $"Đã xóa thành công {successCount} dòng.";
                    MessageBox.Show(successMsg, "Thông báo");
                }
                if (failCount > 0)
                    MessageBox.Show($"Có {failCount} dòng không thể xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (lvResult.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = lvResult.SelectedItems[0];
            string maNV = item.SubItems[0].Text;
            string hoTen = txtHoTen.Text.Trim();
            string gioiTinh = rbNam.Checked ? "Nam" : "Nữ";
            string chucVu = cbChucVu.SelectedItem?.ToString() ?? "";
            string cccd = txtCCCD.Text.Trim();
            string sdt = txtSDT.Text.Trim();
            string email = txtEmail.Text.Trim();
            string maLoaiNV = GetSelectedMaLoaiNV();
            bool isActive = cbHD.Checked;
            string maCN = "CN01";

            if (MessageBox.Show("Bạn có chắc muốn cập nhật thông tin này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = EBLL.UpdateEmployee(maNV, maCN, cccd, hoTen, gioiTinh, chucVu, sdt, email, maLoaiNV, isActive);
                if (result.Success)
                {
                    item.SubItems[1].Text = hoTen;
                    item.SubItems[2].Text = chucVu;
                    item.SubItems[3].Text = cccd;
                    item.SubItems[4].Text = gioiTinh;
                    item.SubItems[5].Text = sdt;
                    item.SubItems[6].Text = email;
                    item.SubItems[10].Text = dictLoaiNV.ContainsKey(maLoaiNV) ? dictLoaiNV[maLoaiNV] : "";
                    item.SubItems[8].Text = isActive ? "✓" : "✗";
                    MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void frmEmployee_Shown(object sender, EventArgs e)
        {
            if (lvResult.Items.Count > 0)
            {
                int maxStt = 0;

                foreach (ListViewItem item in lvResult.Items)
                {
                    if (int.TryParse(item.Text.Substring(2), out int stt))
                    {
                        if (stt > maxStt)
                            maxStt = stt;
                    }
                }
                EmployeeM.stt = maxStt;
            }
        }
    }
}
