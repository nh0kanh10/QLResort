using QLResort.Core.Model;
using QLResort.GUI.Employee;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"Xin chào: {Session_Now.CurrentUser}";
            lblResort.Text = $"Chi nhánh: {Session_Now.CurrentResort}";
            this.WindowState = FormWindowState.Maximized;
            
            // Áp dụng role-based access control
            ApplyRoleBasedAccess();
        }

        private void ApplyRoleBasedAccess()
        {
            string role = Session_Now.CurrentRole;
            bool isAdmin = Session_Now.IsAdmin;
            bool isQuanLy = Session_Now.IsQuanLy;
            bool isNhanVien = Session_Now.IsNhanVien;

            // Quyền theo Role:
            // NhanVien: Tất cả trừ frmChiNhanh, frmNhanVien, frmThongKe, frmAccount
            // QuanLy: Tất cả trừ frmChiNhanh
            // Admin: Tất cả

            // Menu Quản lý Chi nhánh - Chỉ Admin
            menuChiNhanh.Enabled = isAdmin;

            // Menu Quản lý Nhân viên - Chỉ Admin
            menuNhanVien.Enabled = isAdmin;
            menuLoaiNhanVien.Enabled = isAdmin;

            // Menu Quản lý Tài khoản - Chỉ Admin
            menuQuanLyTaiKhoan.Enabled = isAdmin;

            // Menu Thống kê - Chỉ Admin và QuanLy
            menuThongKe.Enabled = isQuanLy;

            // Các menu khác - Tất cả đều có thể truy cập (trừ những cái đã disable ở trên)
            // NhanVien có thể truy cập: Phòng, Dịch vụ, Khách hàng, Đặt phòng, Hóa đơn, Thanh toán, v.v.
        }

        // ===========================================
        // MENU QUẢN LÝ
        // ===========================================
        private void menuQuanLyPhong_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmRoom());
        }

        private void menuQuanLyLoaiPhong_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmRoomType());
        }

        private void menuQuanLyDichVu_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmService());
        }

        private void menuQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new QLResort.GUI.Guest.frmGuest());
        }

        private void menuQuanLyLoaiKhachHang_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new QLResort.GUI.frmGuestType());
        }

        private void menuQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new QLResort.GUI.Employee.frmEmployee());
        }

        private void menuQuanLyLoaiNhanVien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmEmployeeType());
        }

        private void menuQuanLyChiNhanh_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new QLResort.GUI.Resort.frmResort());
        }

        private void menuQuanLyDoThatLac_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmLostFound());
        }


        private void menuQuanLyKhieuNai_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmComplaint());
        }

        private void menuQuanLyVoucher_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmVoucher());
        }

        private void menuQuanLyGoiSuKien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmEventPackage());
        }

        private void menuQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmAccount());
        }

        private void menuDatSuKien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmEventBooking());
        }

        private void menuThanhToanSuKien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmEventPayment());
        }

        // ===========================================
        // MENU ĐẶT PHÒNG & HÓA ĐƠN
        // ===========================================
        private void menuDatPhong_Click(object sender, EventArgs e)
        {
            // Mở form xem danh sách phòng để chọn phòng trước khi đặt
            OpenFormInPanel(new frmRoomView());
        }

        private void menuHoaDon_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmInvoice());
        }

        private void menuQuanLyKhuyenMai_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmPromotion());
        }

        private void menuQuanLyLoaiThanhToan_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmPaymentType());
        }

        private void menuThanhToan_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmPayment());
        }

        // ===========================================
        // MENU THỐNG KÊ
        // ===========================================
        private void menuThongKe_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmStatistics());
        }

        // ===========================================
        // MENU HỆ THỐNG
        // ===========================================
        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session_Now.Logout();
                this.Hide();
                
                // Hiển thị lại form đăng nhập
                using (var loginForm = new frmLogin())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Đăng nhập lại thành công
                        this.Show();
                        ApplyRoleBasedAccess();
                        lblUser.Text = $"Xin chào: {Session_Now.CurrentUser}";
                        lblResort.Text = $"Chi nhánh: {Session_Now.CurrentResort}";
                    }
                    else
                    {
                        // Thoát ứng dụng
                        Application.Exit();
                    }
                }
            }
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session_Now.Logout();
                Application.Exit();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            Session_Now.Logout();
            base.OnFormClosing(e);
        }

        private void menuThoat_Click_OLD(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // ===========================================
        // HELPER METHODS
        // ===========================================
        private void OpenFormInPanel(Form form)
        {
            // Đóng form hiện tại trong panel nếu có
            foreach (Control control in pnlMain.Controls)
            {
                if (control is Form)
                {
                    ((Form)control).Close();
                }
            }
            pnlMain.Controls.Clear();

            // Mở form mới
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(form);
            form.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

