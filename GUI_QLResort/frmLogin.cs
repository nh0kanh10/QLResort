using BUS_QLResort;
using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using Tool_QLResort.Database;
using Tool_QLResort.Helpers;
using DAL_QLResort;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

/// <summary>
/// Form đăng nhập vào hệ thống Quản lý Resort
/// Xác thực thông tin đăng nhập và phân quyền người dùng
/// </summary>

namespace GUI_QLResort
{
    public partial class frmLogin : AppBaseForm
    {
        private readonly FastQuery fastQuery = new FastQuery();
        private readonly AccountBUS accountBUS = new AccountBUS();
        
        /// <summary>
        /// Khởi tạo form đăng nhập
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Sự kiện Load form đăng nhập
        /// - Thiết lập các thuộc tính giao diện
        /// - Ẩn mật khẩu khi nhập
        /// </summary>
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Text = "Đăng nhập - Hệ thống Quản lý Resort";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            txtPassword.UseSystemPasswordChar = true; // Ẩn mật khẩu
        }

        /// <summary>
        /// Xử lý sự kiện click nút Đăng nhập
        /// - Kiểm tra thông tin đăng nhập
        /// - Xác thực tài khoản với cơ sở dữ liệu
        /// - Đăng nhập thành công sẽ mở form chính
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các trường nhập liệu
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            // Kiểm tra tên đăng nhập không được để trống
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            // Kiểm tra mật khẩu không được để trống
            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                var loginResult = CheckLogin(tenDangNhap, matKhau);
                if (loginResult.Success)
                {
                    var account = loginResult.Data;
                    
                    var empResult = GetEmployeeInfo(account.MaNV);
                    if (empResult.Success)
                    {
                        Session_Now.CurrentUser = account.MaNV;
                        Session_Now.CurrentResort = empResult.Data["MaCN"]?.ToString() ?? "";
                        Session_Now.CurrentRole = account.Role ?? "NhanVien";
                        Session_Now.CurrentAccount = account;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(loginResult.ErrorMessage, "Đăng nhập thất bại", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đăng nhập: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
        
        private OperationResult<Account> CheckLogin(string tenDangNhap, string matKhau)
        {
            try
            {
                var accounts = accountBUS.GetAccounts(tenDangNhap: tenDangNhap, isActive: true);
                if (!accounts.Success || accounts.Data.Count == 0)
                {
                    return OperationResult<Account>.Fail("Tên đăng nhập hoặc mật khẩu không đúng!");
                }

                var account = accounts.Data[0];
                if (account.MatKhau != matKhau)
                {
                    return OperationResult<Account>.Fail("Tên đăng nhập hoặc mật khẩu không đúng!");
                }

                return OperationResult<Account>.Ok(account);
            }
            catch (Exception ex)
            {
                return OperationResult<Account>.Fail($"Lỗi: {ex.Message}");
            }
        }

        private OperationResult<DataRow> GetEmployeeInfo(string maNV)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    SqlParameterHelper.Create("@MaNV", maNV),
                    SqlParameterHelper.Create("@IsActive", true)
                };

                DataTable dt = fastQuery.ExecuteProc(StoredProcedures.Employee.GetNhanVien, parameters);
                if (dt.Rows.Count > 0)
                {
                    return OperationResult<DataRow>.Ok(dt.Rows[0]);
                }
                return OperationResult<DataRow>.Fail("Không tìm thấy nhân viên");
            }
            catch (Exception ex)
            {
                return OperationResult<DataRow>.Fail($"Lỗi: {ex.Message}");
            }
        }
    }
}
