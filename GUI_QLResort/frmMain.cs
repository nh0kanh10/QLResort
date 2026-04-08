using ET_QLResort;
using System;
using System.ComponentModel;
using System.Windows.Forms;

/// <summary>
/// Form chính của ứng dụng Quản lý Resort
/// Quản lý giao diện chính và điều hướng đến các chức năng khác
/// </summary>

namespace GUI_QLResort
{
    public partial class frmMain : AppBaseForm
    {
       
        public frmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện Load form chính
        /// - Hiển thị thông tin người dùng và chi nhánh hiện tại
        /// - Mở rộng cửa sổ tối đa
        /// - Áp dụng phân quyền cho người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng và chi nhánh
            lblUser.Text = $"Xin chào: {Session_Now.CurrentUser}";
            lblResort.Text = $"Chi nhánh: {Session_Now.CurrentResort}";
            this.WindowState = FormWindowState.Maximized;
            
            // Áp dụng phân quyền dựa trên vai trò người dùng
            ApplyRoleBasedAccess();
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

        /// <summary>
        /// Áp dụng phân quyền dựa trên vai trò người dùng
        /// - Admin: Có quyền truy cập tất cả chức năng
        /// - Quản lý: Chỉ được phép xem báo cáo thống kê
        /// - Nhân viên: Chỉ được phép sử dụng các chức năng cơ bản
        /// </summary>
        private void ApplyRoleBasedAccess()
        {
            bool isAdmin = Session_Now.IsAdmin;
            bool isQuanLy = Session_Now.IsQuanLy;

            // Kích hoạt/vô hiệu hóa các menu dựa trên quyền hạn
            menuChiNhanh.Enabled = isAdmin;
            menuNhanVien.Enabled = isAdmin;
            menuLoaiNhanVien.Enabled = isAdmin;
            menuQuanLyTaiKhoan.Enabled = isAdmin;
            menuThongKe.Enabled = isQuanLy || isAdmin; // Cả admin và quản lý đều xem được thống kê
        }
        
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
            OpenFormInPanel(new khachhang_gui());
        }

        private void menuQuanLyLoaiKhachHang_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new loaiKH_gui());
        }

        private void menuTraCuuKhachHang_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmGuestDetail());
        }

        private void menuQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new nhanvien_gui());
        }

        private void menuQuanLyLoaiNhanVien_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new gui_loaiNV());
        }

        private void menuQuanLyChiNhanh_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new chi_nhanh_gui());
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

        private void menuDatPhong_Click(object sender, EventArgs e)
        {
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
        
        private void menuThongKe_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new frmStatistics());
        }

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

        private void menuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session_Now.Logout();
                Application.Exit();
            }
        }
        
        public void OpenFormInPanel(Form form)
        {
            foreach (Control control in pnlMain.Controls)
            {
                if (control is Form)
                {
                    ((Form)control).Close();
                }
            }
            pnlMain.Controls.Clear();

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
