using QLResort.BUS;
using QLResort.Core.Model;
using QLResort.GUI.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLResort.GUI.Guest
{
    public partial class frmGuest : AppBaseForm
    {
        public frmGuest()
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
        public void loadMaLoaiKH()
        {
            GuestTypeBUS guestTypeBUS = new GuestTypeBUS();
            var result = guestTypeBUS.GetGuestTypeForGuest();
            if (result.Success)
            {
                cbLoaiKH.DataSource = result.Data;
                cbLoaiKH.DisplayMember = "TenLKH";
                cbLoaiKH.ValueMember = "MaLKH";
            }
            else
            {
                MessageBox.Show("Lỗi load mã loại khách hàng: " + result.ErrorMessage);
            }

        }

        public void LoadMa()
        {
            cbLoaiMa.Items.Clear();
            cbLoaiMa.Items.Add("CCCD");
            cbLoaiMa.Items.Add("CMND");
            cbLoaiMa.Items.Add("Passport");
            cbLoaiMa.SelectedIndex = 0;
        }
        public void LoadGuest()
        {
            // Load danh sách khách hàng vào ListView lvResult
            // Mỗi mục trong ListView sẽ hiển thị các thông tin của khách hàng
            int max = 0;
            GuestBUS guestBUS = new GuestBUS();
            var result = guestBUS.GetGuests(isActive: null);
            if (result.Success)
            {
                lvResult.Items.Clear();
                foreach (var guest in result.Data)
                {
                    ListViewItem item = new ListViewItem(guest.MaKH);
                    item.SubItems.Add(guest.HoTen);
                    item.SubItems.Add(guest.GioiTinh);
                    item.SubItems.Add(guest.NgaySinh.ToString("dd/MM/yyyy"));
                    item.SubItems.Add(guest.SDT);
                    item.SubItems.Add(guest.Email);
                    item.SubItems.Add(guest.IDType);
                    item.SubItems.Add(guest.IDNumber);
                    item.SubItems.Add(guest.DiaChi);
                    item.SubItems.Add(guest.MaLKH);
                    item.SubItems.Add(guest.CreatedBy);
                    item.SubItems.Add(guest.IsActive ? "✓" : "✗");
                    lvResult.Items.Add(item);
                    int num = int.Parse(guest.MaKH.Substring(2));
                    if (num > max)
                    {
                        max = num;
                    }
                }
                Core.Model.Guest.stt = max + 1;
            }
            else
            {
                MessageBox.Show("Lỗi load khách hàng: " + result.ErrorMessage);
            }
        }
        private void frmGuest_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            loadMaLoaiKH();
            LoadMa();
            LoadGuest();
        }
        //"✓" : "✗"
        private void lvResult_Click(object sender, EventArgs e)
        {
            LoadSelectedGuestToForm();
        }

        private void lvResult_DoubleClick(object sender, EventArgs e)
        {
            if (lvResult.SelectedItems.Count > 0)
            {
                string maKH = lvResult.SelectedItems[0].SubItems[0].Text;
                frmGuestDetail frm = new frmGuestDetail(maKH);
                frm.ShowDialog();
            }
        }

        private void lvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedGuestToForm();
        }

        private void LoadSelectedGuestToForm()
        {
            if (lvResult.SelectedItems.Count == 0)
            {
                Reset();
                return;
            }

            var item = lvResult.SelectedItems[0];
            if (item != null)
            {
                txtTen.Text = item.SubItems[1].Text;
                if (item.SubItems[2].Text == "Nam")
                {
                    rbNam.Checked = true;
                }
                else
                {
                    rbNu.Checked = true;
                }
                dtpNgaySinh.Value = DateTime.ParseExact(item.SubItems[3].Text, "dd/MM/yyyy", null);
                txtSDT.Text = item.SubItems[4].Text;
                txtEmail.Text = item.SubItems[5].Text;
                cbLoaiMa.Text = item.SubItems[6].Text;
                txtMa.Text = item.SubItems[7].Text;
                txtDiaChi.Text = item.SubItems[8].Text;
                cbLoaiKH.SelectedValue = item.SubItems[9].Text;
                cbHD.Checked = item.SubItems[11].Text == "✓" ? true : false;
            }
        }
        private bool Isvalid()
        {
            bool isValid = true;
            List<TextBox> textBoxes = new List<TextBox> { txtTen, txtSDT, txtEmail, txtMa, txtDiaChi };
            foreach (TextBox textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    errorProvider1.SetError(textBox, "Trường này không được để trống.");
                    isValid = false;
                }
            }
            return isValid;
        }
        private void Reset()
        {
            txtTen.Clear();
            rbNam.Checked = true;
            dtpNgaySinh.Value = DateTime.Now;
            txtSDT.Clear();
            txtEmail.Clear();
            cbLoaiMa.SelectedIndex = 0;
            txtMa.Clear();
            txtDiaChi.Clear();
            cbLoaiKH.SelectedIndex = 0;
            cbHD.Checked = false;
            errorProvider1.Clear();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!Isvalid()) { return; }
            GuestBUS guestBUS = new GuestBUS();
            var result = guestBUS.AddGuestBAL(
                tenKH: txtTen.Text.Trim(),
                gioiTinh: rbNam.Checked ? "Nam" : "Nữ",
                ngaySinh: dtpNgaySinh.Value,
                sdt: txtSDT.Text.Trim(),
                email: txtEmail.Text.Trim(),
                idType: cbLoaiMa.Text,
                idNumber: txtMa.Text.Trim(),
                diaChi: txtDiaChi.Text.Trim(),
                maLKH: cbLoaiKH.SelectedValue.ToString(),
                createdBy: Session_Now.CurrentUser,
                isActive: cbHD.Checked
                );
            if (result.Success)
            {
                MessageBox.Show("Thêm khách hàng thành công!");
                LoadGuest();
                Reset();
                Core.Model.Guest.stt++;
            }
            else
            {
                MessageBox.Show("Lỗi thêm khách hàng: " + result.ErrorMessage);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvResult.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa.");
                return;
            }
            if(MessageBox.Show("Bạn có chắc muốn xoá khách hàng đã chọn", "Xác nhận xoá", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            int isDeleted = 0;
            foreach (ListViewItem item in lvResult.SelectedItems)
            {
                GuestBUS guestBUS = new GuestBUS();
                var result = guestBUS.DeleteGuestBAL(item.SubItems[0].Text);
                if (result.Success)
                {
                    isDeleted++;
                }
                else
                {
                    MessageBox.Show($"Lỗi xoá khách hàng {item.SubItems[0].Text}: " + result.ErrorMessage);
                }
            }
            if (isDeleted > 0) { 
            MessageBox.Show($"Xoá thành công {isDeleted} khách hàng!");
            }
            LoadGuest();
            Reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvResult.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa.");
                return;
            }
            var item = lvResult.SelectedItems[0];
            GuestBUS guestBUS = new GuestBUS();
            var result = guestBUS.UpdateGuestBAL(
                maKH: item.SubItems[0].Text,
                tenKH: txtTen.Text.Trim(),
                gioiTinh: rbNam.Checked ? "Nam" : "Nữ",
                ngaySinh: dtpNgaySinh.Value,
                sdt: txtSDT.Text.Trim(),
                email: txtEmail.Text.Trim(),
                idType: cbLoaiMa.Text,
                idNumber: txtMa.Text.Trim(),
                diaChi: txtDiaChi.Text.Trim(),
                maLKH: cbLoaiKH.SelectedValue.ToString(),
                updatedBy: Session_Now.CurrentUser,
                updateAt: DateTime.Now,
                isActive: cbHD.Checked
                );
            if (result.Success)
            {
                MessageBox.Show("Cập nhật khách hàng thành công!");
                LoadGuest();
                Reset();
            }
            else
            {
                MessageBox.Show("Lỗi cập nhật khách hàng: " + result.ErrorMessage);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGuest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
