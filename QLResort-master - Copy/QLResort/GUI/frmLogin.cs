using QLResort.BLL;
using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.DatabaseToolF;
using QLResort.Core.Helpers;
using QLResort.DAL.Constants;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmLogin : Form
    {
        private readonly FastQuery fastQuery = new FastQuery();
        private readonly AccountBLL accountBLL = new AccountBLL();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Text = "Đăng nhập - Hệ thống Quản lý Resort";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtUsername.Text.Trim();
            string matKhau = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                // Kiểm tra đăng nhập
                var loginResult = CheckLogin(tenDangNhap, matKhau);
                if (loginResult.Success)
                {
                    var account = loginResult.Data;
                    
                    // Lấy thông tin nhân viên và chi nhánh
                    var empResult = GetEmployeeInfo(account.MaNV);
                    if (empResult.Success)
                    {
                        Session_Now.CurrentUser = account.MaNV;
                        Session_Now.CurrentResort = empResult.Data["MaCN"]?.ToString() ?? "";
                        // Lấy Role từ Account thay vì từ ChucVu
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

        private OperationResult<Account> CheckLogin(string tenDangNhap, string matKhau)
        {
            try
            {
                var accounts = accountBLL.GetAccounts(tenDangNhap: tenDangNhap, isActive: true);
                if (!accounts.Success || accounts.Data.Count == 0)
                {
                    return OperationResult<Account>.Fail("Tên đăng nhập hoặc mật khẩu không đúng!");
                }

                var account = accounts.Data[0];
                if (account.MatKhau != matKhau) // Trong thực tế nên hash password
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
    }
}

