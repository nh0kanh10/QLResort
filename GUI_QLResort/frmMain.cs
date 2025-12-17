/*
 * =================================================================
 * frmMain.cs - Form chính của ứng dụng (MDI Container)
 * =================================================================
 * Chức năng:
 *   - Hiển thị menu điều hướng toàn bộ hệ thống
 *   - Phân quyền truy cập menu dựa trên Role
 *   - Mở các form con trong panel chính (pnlMain)
 * 
 * Phân quyền:
 *   - NhanVien: Phòng, Dịch vụ, Khách hàng, Đặt phòng, Hóa đơn
 *   - QuanLy: Tất cả + Thống kê
 *   - Admin: Tất cả + Chi nhánh, Nhân viên, Tài khoản
 * =================================================================
 */

using ET_QLResort;

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GUI_QLResort
{
    public partial class frmMain : AppBaseForm
    {
        // Constructor
        public frmMain()
        {
            InitializeComponent();
        }
        
        // Form Events
        /// <summary>
        /// Khởi tạo form chính: hiển thị thông tin user, áp dụng phân quyền
        /// </summary>
        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUser.Text = $"Xin chào: {Session_Now.CurrentUser}";
            lblResort.Text = $"Chi nhánh: {Session_Now.CurrentResort}";
            this.WindowState = FormWindowState.Maximized;
            
            ApplyRoleBasedAccess();
            
        }

        /// <summary>
        /// Xác nhận trước khi đóng ứng dụng
        /// </summary>
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
        
        // Role-Based Access Control
        /// <summary>
        /// Áp dụng phân quyền dựa trên Role:
        /// - NhanVien: Không truy cập Chi nhánh, Nhân viên, Thống kê, Tài khoản
        /// - QuanLy: Không truy cập Chi nhánh
        /// - Admin: Truy cập tất cả
        /// </summary>
        private void ApplyRoleBasedAccess()
        {
            bool isAdmin = Session_Now.IsAdmin;
            bool isQuanLy = Session_Now.IsQuanLy;

            // Menu Quản lý Chi nhánh - Chỉ Admin
            menuChiNhanh.Enabled = isAdmin;

            // Menu Quản lý Nhân viên - Chỉ Admin
            menuNhanVien.Enabled = isAdmin;
            menuLoaiNhanVien.Enabled = isAdmin;

            // Menu Quản lý Tài khoản - Chỉ Admin
            menuQuanLyTaiKhoan.Enabled = isAdmin;

            // Menu Thống kê - Chỉ Admin và QuanLy
            menuThongKe.Enabled = isQuanLy;
        }
        
        // Menu Click Handlers - Quản lý
        /// <summary>Mở form quản lý phòng</summary>
        private void menuQuanLyPhong_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmRoom());
        }

        /// <summary>Mở form quản lý loại phòng</summary>
        private void menuQuanLyLoaiPhong_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmRoomType());
        }

        /// <summary>Mở form quản lý dịch vụ</summary>
        private void menuQuanLyDichVu_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmService());
        }

        /// <summary>Mở form quản lý khách hàng</summary>
        private void menuQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmGuest());
        }

        /// <summary>Mở form quản lý loại khách hàng</summary>
        private void menuQuanLyLoaiKhachHang_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new GUI_QLResort.frmGuestType());
        }

        /// <summary>Mở form quản lý nhân viên</summary>
        private void menuTraCuuKhachHang_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmGuestDetail());
        }

        private void menuQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmEmployee());
        }

        /// <summary>Mở form quản lý loại nhân viên</summary>
        private void menuQuanLyLoaiNhanVien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmEmployeeType());
        }

        /// <summary>Mở form quản lý chi nhánh</summary>
        private void menuQuanLyChiNhanh_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmResort());
        }

        /// <summary>Mở form quản lý đồ thất lạc</summary>
        private void menuQuanLyDoThatLac_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmLostFound());
        }

        /// <summary>Mở form quản lý khiếu nại</summary>
        private void menuQuanLyKhieuNai_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmComplaint());
        }

        /// <summary>Mở form quản lý voucher</summary>
        private void menuQuanLyVoucher_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmVoucher());
        }

        /// <summary>Mở form quản lý gói sự kiện</summary>
        private void menuQuanLyGoiSuKien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmEventPackage());
        }

        /// <summary>Mở form quản lý tài khoản</summary>
        private void menuQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmAccount());
        }
        
        // Menu Click Handlers - Đặt phòng & Sự kiện
        /// <summary>Mở form đặt sự kiện</summary>
        private void menuDatSuKien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmEventBooking());
        }

        /// <summary>Mở form thanh toán sự kiện</summary>
        private void menuThanhToanSuKien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmEventPayment());
        }

        /// <summary>Mở form xem phòng để đặt</summary>
        private void menuDatPhong_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmRoomView());
        }

        /// <summary>Mở form hóa đơn</summary>
        private void menuHoaDon_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmInvoice());
        }

        /// <summary>Mở form quản lý khuyến mãi</summary>
        private void menuQuanLyKhuyenMai_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmPromotion());
        }

        /// <summary>Mở form quản lý loại thanh toán</summary>
        private void menuQuanLyLoaiThanhToan_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmPaymentType());
        }

        /// <summary>Mở form thanh toán</summary>
        private void menuThanhToan_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmPayment());
        }
        
        // Menu Click Handlers - Thống kê & Hệ thống
        /// <summary>Mở form thống kê</summary>
        private void menuThongKe_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmStatistics());
        }

        /// <summary>Đăng xuất và hiển thị lại form đăng nhập</summary>
        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session_Now.Logout();
                this.Hide();
                
                using (var loginForm = new frmLogin())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        this.Show();
                        ApplyRoleBasedAccess();
                        lblUser.Text = $"Xin chào: {Session_Now.CurrentUser}";
                        lblResort.Text = $"Chi nhánh: {Session_Now.CurrentResort}";
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }

        /// <summary>Thoát ứng dụng</summary>
        private void menuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session_Now.Logout();
                Application.Exit();
            }
        }
        
        // Helper Methods
        /// <summary>
        /// Mở một form bên trong panel chính
        /// - Đóng form cũ nếu có
        /// - Thiết lập form mới để hiển thị embedded
        /// </summary>
        /// <param name="form">Form cần mở</param>
        public void OpenFormInPanel(Form form)
        {
            // Đóng form hiện tại trong panel
            foreach (Control control in pnlMain.Controls)
            {
                if (control is Form)
                {
                    ((Form)control).Close();
                }
            }
            pnlMain.Controls.Clear();

            // Mở form mới embedded
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(form);
            form.Show();
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
