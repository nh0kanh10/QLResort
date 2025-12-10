using QLResort.BUS;
using QLResort.Core.ClassHoTro;
using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.EmployeeDALQL;
using QLResort.GUI.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLResort.GUI.Employee
{
    public partial class frmEmployee : Form
    {
        private readonly EmployeeBUS EBUS = new EmployeeBUS();
        private Dictionary<string, string> dictLoaiNV;
        public List<string> listChucVu = new List<string>() { "Nhân viên", "Trưởng phòng", "Quản lý", "Giám đốc" };
        private string currentEmployeeImagePath = null;
        private string selectedMaNV = null;
        private string imagesFolder = Path.Combine(Application.StartupPath, "Images", "Employees");

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt) AppTheme.StyleTextBox(txt);
                else if (ctrl is ComboBox cb) AppTheme.StyleComboBox(cb);
                else if (ctrl is DateTimePicker dtp) AppTheme.StyleDateTimePicker(dtp);
                else if (ctrl is Label lbl) AppTheme.StyleLabel(lbl);
                else if (ctrl is Button btn) AppTheme.StylePrimaryButton(btn);
            }
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            frmEmployeeType frmLoaiNV = new frmEmployeeType();
            var result = frmLoaiNV.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadEmployeeTypeBUS();
            }
        }
        public void LoadEmployeeTypeBUS()
        {
            cbLNV.Items.Clear();

            var result = EBUS.GetDataLoaiNVBUS();

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
            if (cbLNV.SelectedItem is ComboBoxItem em) return em.ID;
            return string.Empty;
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            // Tạo thư mục Images nếu chưa có
            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);

            LoadEmployeeTypeBUS();

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

            OperationResult<List<EmployeeM>> list = EBUS.GetEmployeesBUS(maCN: Session_Now.CurrentResort);
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
            selectedMaNV = null;
            currentEmployeeImagePath = null;
            txtCCCD.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            rbNam.Checked = true;
            rbNu.Checked = false;
            if (cbChucVu.Items.Count > 0) cbChucVu.SelectedIndex = 0;
            if (cbLNV.Items.Count > 0) cbLNV.SelectedIndex = 0;
            cbHD.Checked = false;
            // Reset image - assuming there's a PictureBox named pbEmployeeImage
            // pbEmployeeImage.Image = null;
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
            OperationResult<EmployeeM> result = EBUS.AddEmployee(txtCCCD.Text.Trim(), txtHoTen.Text.Trim(),
                gioitinh, chucVu, txtSDT.Text.Trim(), txtEmail.Text.Trim(), maLoaiNV, isActive, currentEmployeeImagePath);

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
            selectedMaNV = item.SubItems[0].Text;
            txtHoTen.Text = item.SubItems[1].Text;
            string chucVu = item.SubItems[2].Text;
            cbChucVu.SelectedItem = chucVu;

            txtCCCD.Text = item.SubItems[3].Text;
            if (item.SubItems[4].Text == "Nam") rbNam.Checked = true;
            else rbNu.Checked = true;
            txtSDT.Text = item.SubItems[5].Text;
            txtEmail.Text = item.SubItems[6].Text;
            txtCN.Text = item.SubItems[7].Text;
            cbHD.Checked = item.SubItems[8].Text == "✓";

            string maLoai = item.SubItems[10].Text;
            SelectLoaiNVById(maLoai);

            // Load ảnh nhân viên
            LoadEmployeeImage(selectedMaNV);
        }

        private void LoadEmployeeImage(string maNV)
        {
            if (string.IsNullOrEmpty(maNV))
            {
                currentEmployeeImagePath = null;
                pbEmployeeImage.Image = null;
                btnDeleteEmployeeImage.Enabled = false;
                return;
            }

            var result = EBUS.GetEmployeesBUS();
            if (result.Success)
            {
                var emp = result.Data.FirstOrDefault(e => e.MaNV == maNV);
                if (emp != null && !string.IsNullOrEmpty(emp.DuongDanAnh) && File.Exists(emp.DuongDanAnh))
                {
                    currentEmployeeImagePath = emp.DuongDanAnh;
                    try
                    {
                        pbEmployeeImage.Image = System.Drawing.Image.FromFile(emp.DuongDanAnh);
                        btnDeleteEmployeeImage.Enabled = true;
                    }
                    catch
                    {
                        pbEmployeeImage.Image = null;
                        btnDeleteEmployeeImage.Enabled = false;
                    }
                }
                else
                {
                    currentEmployeeImagePath = null;
                    pbEmployeeImage.Image = null;
                    btnDeleteEmployeeImage.Enabled = false;
                }
            }
        }

        private void btnUploadEmployeeImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên trước khi thêm ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Chọn ảnh nhân viên";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Copy ảnh vào thư mục Images/Employees
                        string fileName = $"{selectedMaNV}_{DateTime.Now:yyyyMMddHHmmss}{Path.GetExtension(ofd.FileName)}";
                        string destPath = Path.Combine(imagesFolder, fileName);

                        File.Copy(ofd.FileName, destPath, true);

                        // Cập nhật vào database
                        string maCN = txtCN.Text;
                        string cccd = txtCCCD.Text;
                        string hoTen = txtHoTen.Text;
                        string gioiTinh = rbNam.Checked ? "Nam" : "Nữ";
                        string chucVu = cbChucVu.SelectedItem?.ToString() ?? "";
                        string sdt = txtSDT.Text;
                        string email = txtEmail.Text;
                        string maLoaiNV = GetSelectedMaLoaiNV();
                        bool isActive = cbHD.Checked;

                        var result = EBUS.UpdateEmployee(selectedMaNV, maCN, cccd, hoTen, gioiTinh, chucVu, sdt, email, maLoaiNV, isActive, destPath);
                        if (result.Success)
                        {
                            pbEmployeeImage.Image = System.Drawing.Image.FromFile(destPath);
                            currentEmployeeImagePath = destPath;
                            btnDeleteEmployeeImage.Enabled = true;
                            MessageBox.Show("Cập nhật ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormLoadEmployee();
                        }
                        else
                        {
                            MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (File.Exists(destPath))
                                File.Delete(destPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDeleteEmployeeImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa ảnh này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string maCN = txtCN.Text;
                string cccd = txtCCCD.Text;
                string hoTen = txtHoTen.Text;
                string gioiTinh = rbNam.Checked ? "Nam" : "Nữ";
                string chucVu = cbChucVu.SelectedItem?.ToString() ?? "";
                string sdt = txtSDT.Text;
                string email = txtEmail.Text;
                string maLoaiNV = GetSelectedMaLoaiNV();
                bool isActive = cbHD.Checked;

                var result = EBUS.UpdateEmployee(selectedMaNV, maCN, cccd, hoTen, gioiTinh, chucVu, sdt, email, maLoaiNV, isActive, null);
                if (result.Success)
                {
                    if (!string.IsNullOrEmpty(currentEmployeeImagePath) && File.Exists(currentEmployeeImagePath))
                    {
                        try
                        {
                            File.Delete(currentEmployeeImagePath);
                        }
                        catch { }
                    }

                    pbEmployeeImage.Image = null;
                    currentEmployeeImagePath = null;
                    btnDeleteEmployeeImage.Enabled = false;
                    MessageBox.Show("Xóa ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormLoadEmployee();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                    var result = EBUS.DeleteEmployee(item.SubItems[0].Text);
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
                var result = EBUS.UpdateEmployee(maNV, maCN, cccd, hoTen, gioiTinh, chucVu, sdt, email, maLoaiNV, isActive, currentEmployeeImagePath);
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageAccount)
            {
                // Mở form Account trong tab
                frmAccount accountForm = new frmAccount();
                accountForm.TopLevel = false;
                accountForm.FormBorderStyle = FormBorderStyle.None;
                accountForm.Dock = DockStyle.Fill;
                tabPageAccount.Controls.Clear();
                tabPageAccount.Controls.Add(accountForm);
                accountForm.Show();
            }
        }
    }
}
