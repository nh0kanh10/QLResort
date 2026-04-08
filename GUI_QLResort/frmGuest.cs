using BUS_QLResort;
using ET_QLResort;
using GUI_QLResort.Styles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Form quản lý thông tin khách hàng trong hệ thống
/// Cho phép thêm, sửa, xóa và tìm kiếm thông tin khách hàng
/// Quản lý thông tin cá nhân và phân loại khách hàng
/// </summary>

namespace GUI_QLResort
{
    public partial class frmGuest : AppBaseForm
    {
        private readonly GuestBUS _guestBUS = new GuestBUS();
        private string _selectedMaKH = null;
        
        /// <summary>
        /// Khởi tạo form quản lý khách hàng
        /// </summary>
        public frmGuest()
        {
            InitializeComponent();
        }

        
        private void ApplyTheme()
        {
            // Áp dụng theme cho toàn bộ form
            AppTheme.ApplyForm(this);
            
            // Duyệt qua tất cả các control để áp dụng style phù hợp
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt) 
                    AppTheme.StyleTextBox(txt);
                else if (ctrl is ComboBox cb) 
                    AppTheme.StyleComboBox(cb);
                else if (ctrl is DateTimePicker dtp) 
                    AppTheme.StyleDateTimePicker(dtp);
                else if (ctrl is Label lbl) 
                    AppTheme.StyleLabel(lbl);
                else if (ctrl is Button btn) 
                    AppTheme.StylePrimaryButton(btn);
            }
        }
        /// <summary>
        /// Load ma loại
        /// </summary>
        public void loadMaLoaiKH()
        {
            try
            {
                GuestTypeBUS guestTypeBUS = new GuestTypeBUS();
                var result = guestTypeBUS.GetGuestTypeForGuest();
                
                if (result.Success)
                {
                    // Gán dữ liệu vào ComboBox
                    cbLoaiKH.DataSource = result.Data;
                    cbLoaiKH.DisplayMember = "TenLKH";  // Hiển thị tên loại khách hàng
                    cbLoaiKH.ValueMember = "MaLKH";     // Giá trị thực sự là mã loại khách hàng
                }
                else
                {
                    MessageBox.Show("Lỗi khi tải danh sách loại khách hàng: " + result.ErrorMessage, 
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải loại khách hàng: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải danh sách các loại giấy tờ tùy thân vào ComboBox
        /// </summary>
        public void LoadMa()
        {
            try
            {
                cbLoaiMa.Items.Clear();
                cbLoaiMa.Items.Add("CCCD");
                cbLoaiMa.Items.Add("CMND");
                cbLoaiMa.Items.Add("Passport");
                cbLoaiMa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách loại giấy tờ: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Tải danh sách khách hàng
        /// </summary>
        public void LoadGuest()
        {
            try
            {
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
                    
                    GuestM.stt = max + 1;
                }
                else
                {
                    MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + result.ErrorMessage,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách khách hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Load form khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGuest_Load(object sender, EventArgs e)
        {
            try
            {
                // Áp dụng giao diện
                ApplyTheme();               
                loadMaLoaiKH();  
                LoadMa();
                LoadGuest();   
               
                // Đặt lại form
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải form: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// - Tải thông tin khách hàng được chọn lên form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvResult_Click(object sender, EventArgs e)
        {
            LoadSelectedGuestToForm();
        }

        private void lvResult_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (lvResult.SelectedItems.Count > 0)
                {
                    // Lấy mã khách hàng từ dòng được chọn
                    string maKH = lvResult.SelectedItems[0].SubItems[0].Text;
                    
                    // Mở form chi tiết khách hàng
                    frmGuestDetail frm = new frmGuestDetail(maKH);
                    frm.ShowDialog();
                    
                    // Làm mới danh sách sau khi đóng form chi tiết
                    LoadGuest();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở chi tiết khách hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedGuestToForm();
        }

        private void LoadSelectedGuestToForm()
        {
            try
            {
                // Nếu không có mục nào được chọn, đặt lại form
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
                    
                    if (cbLoaiKH.Items.Count > 0)
                    {
                        cbLoaiKH.SelectedValue = item.SubItems[9].Text;
                    }                   
                    cbHD.Checked = item.SubItems[11].Text == "✓";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin khách hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Kiểm tra tính hợp lệ của dữ liệu nhập vào
        /// - Kiểm tra các trường bắt buộc không được để trống
        /// - Hiển thị thông báo lỗi nếu có
        /// </summary>
        /// <returns>True nếu dữ liệu hợp lệ, ngược lại trả về False</returns>
        private bool Isvalid()
        {
            bool isValid = true;
            
            // Danh sách các TextBox bắt buộc nhập
            List<TextBox> requiredFields = new List<TextBox> 
            { 
                txtTen,    // Họ tên
                txtSDT,    // Số điện thoại
                txtEmail,  // Email
                txtMa,     // Số giấy tờ
                txtDiaChi  // Địa chỉ
            };
            
            // Kiểm tra từng trường bắt buộc
            foreach (TextBox field in requiredFields)
            {
                if (string.IsNullOrWhiteSpace(field.Text))
                {
                    // Hiển thị thông báo lỗi cho trường bị bỏ trống
                    errorProvider1.SetError(field, "Trường này không được để trống.");
                    isValid = false;
                }
                else
                {
                    // Xóa thông báo lỗi nếu trường đã được điền
                    errorProvider1.SetError(field, string.Empty);
                }
            }
            
            // Có thể thêm các kiểm tra khác ở đây (định dạng email, số điện thoại, v.v.)
            
            return isValid;
        }
        /// <summary>
        /// Đặt lại các control trên form về trạng thái mặc định
        /// - Xóa nội dung các trường nhập liệu
        /// - Đặt giá trị mặc định cho các control
        /// - Xóa các thông báo lỗi
        /// </summary>
        private void Reset()
        {
            try
            {
                // Xóa nội dung các trường nhập liệu
                txtTen.Clear();             // Xóa họ tên
                txtSDT.Clear();             // Xóa số điện thoại
                txtEmail.Clear();           // Xóa email
                txtMa.Clear();              // Xóa số giấy tờ
                txtDiaChi.Clear();          // Xóa địa chỉ
                
                // Đặt giá trị mặc định
                rbNam.Checked = true;       // Mặc định chọn giới tính Nam
                dtpNgaySinh.Value = DateTime.Now;  // Ngày hiện tại
                
                // Đặt lại ComboBox loại giấy tờ
                if (cbLoaiMa.Items.Count > 0)
                {
                    cbLoaiMa.SelectedIndex = 0;  // Chọn mục đầu tiên
                }
                
                // Đặt lại ComboBox loại khách hàng
                if (cbLoaiKH.Items.Count > 0)
                {
                    cbLoaiKH.SelectedIndex = 0;  // Chọn mục đầu tiên
                }
                
                // Đặt lại trạng thái hoạt động
                cbHD.Checked = false;
                
                // Xóa các thông báo lỗi
                errorProvider1.Clear();
                
                // Xóa khách hàng đang chọn
                _selectedMaKH = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đặt lại form: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                GuestM.stt++;
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
