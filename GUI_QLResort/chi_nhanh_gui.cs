using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLResort
{
    public partial class chi_nhanh_gui : Form
    {
        public chi_nhanh_gui()
        {
            InitializeComponent();
        }
        //ket noi database
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QLR;Integrated Security=True");
        private void chi_nhanh_gui_Load(object sender, EventArgs e)
        {
            LayDSCN();
            LayMaQL();
        }

        private void LayDSCN()
        {
            try
            {
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdLayDSCN = new SqlCommand();
                cmdLayDSCN.CommandText = "sp_LayDSCN";
                cmdLayDSCN.CommandType = CommandType.StoredProcedure;
                cmdLayDSCN.Connection = conn;
                //doi tuong
                DataTable dtDSCN = new DataTable();
                SqlDataAdapter daDSCN = new SqlDataAdapter(cmdLayDSCN);
                daDSCN.Fill(dtDSCN);
                //dua data vao gridview
                dgvDSCN.DataSource = dtDSCN;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo");
            }
            finally
            {
                //dong connect
                conn.Close();
            }
        }

        private void LayMaQL()
        {
            try
            {
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdLayMaQL = new SqlCommand();
                cmdLayMaQL.CommandText = "sp_LayDSMaQL";
                cmdLayMaQL.CommandType = CommandType.StoredProcedure;
                cmdLayMaQL.Connection = conn;
                //doi tong
                DataTable dtLayMQL = new DataTable();
                SqlDataAdapter daLayMQL = new SqlDataAdapter(cmdLayMaQL);
                daLayMQL.Fill(dtLayMQL);


                //dua dl vao cbb
                cbbMaQL.DataSource = dtLayMQL;
                cbbMaQL.DisplayMember = "HoTen";
                cbbMaQL.ValueMember = "MaQuanLy";
                cbbMaQL.SelectedIndex = -1;
            }
            catch
            {

            }
            finally
            {
                //dong connect
                conn.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaCN.Text))
                {
                    MessageBox.Show("Chưa có thông tin để THÊM", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdThemCN = new SqlCommand();
                cmdThemCN.CommandText = "sp_ThemCN";
                cmdThemCN.CommandType = CommandType.StoredProcedure;
                cmdThemCN.Connection = conn;
                //tham so
                SqlParameter paraMaCN = new SqlParameter("MaCN", txtMaCN.Text);
                cmdThemCN.Parameters.Add(paraMaCN);

                SqlParameter paraTenCN = new SqlParameter("TenCN", txtTenCN.Text);
                cmdThemCN.Parameters.Add(paraTenCN);

                SqlParameter paraDiaChi = new SqlParameter("DiaChi", txtDiaChi.Text);
                cmdThemCN.Parameters.Add(paraDiaChi);

                SqlParameter paraMaQL = new SqlParameter("MaQuanLy", cbbMaQL.SelectedValue);
                cmdThemCN.Parameters.Add(paraMaQL);

                SqlParameter paraIsActive = new SqlParameter("IsActive", ckbActive.Checked);
                cmdThemCN.Parameters.Add(paraIsActive);
                //thuc thi
                if (cmdThemCN.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm KHÔNG thành công", "Thông báo");
                }
            }
            catch
            {

            }
            finally
            {
                //dong connect
                conn.Close();
            }
            LayDSCN();
            resetall();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaCN.Text))
                {
                    MessageBox.Show("Chọn cái cần sửa", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdSuaCN = new SqlCommand();
                cmdSuaCN.CommandText = "sp_SuaCN";
                cmdSuaCN.CommandType = CommandType.StoredProcedure;
                cmdSuaCN.Connection = conn;
                //tham so
                SqlParameter paraMaCN = new SqlParameter("MaCN", txtMaCN.Text);
                cmdSuaCN.Parameters.Add(paraMaCN);

                SqlParameter paraTenCN = new SqlParameter("TenCN", txtTenCN.Text);
                cmdSuaCN.Parameters.Add(paraTenCN);

                SqlParameter paraDiaChi = new SqlParameter("DiaChi", txtDiaChi.Text);
                cmdSuaCN.Parameters.Add(paraDiaChi);

                SqlParameter paraMaQL = new SqlParameter("MaQuanLy", cbbMaQL.SelectedValue);
                cmdSuaCN.Parameters.Add(paraMaQL);

                SqlParameter paraIsActive = new SqlParameter("IsActive", ckbActive.Checked);
                cmdSuaCN.Parameters.Add(paraIsActive);

                //thuc thi
                if (cmdSuaCN.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Sửa KHÔNG thành công", "Thông báo");
                }

            }
            catch
            {

            }
            finally
            {
                //dong connect
                conn.Close();
            }
            LayDSCN();
            resetall();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaCN.Text))
                {
                    MessageBox.Show("Chưa chọn để xóa", "Thông báo");
                    return;
                }
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdXoaCN = new SqlCommand();
                cmdXoaCN.CommandText = "sp_XoaCN";
                cmdXoaCN.CommandType = CommandType.StoredProcedure;
                cmdXoaCN.Connection = conn;
                //tham so
                SqlParameter paraMaCN = new SqlParameter("MaCN", txtMaCN.Text);
                cmdXoaCN.Parameters.Add(paraMaCN);
                //thuc thi
                if (cmdXoaCN.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đã xóa thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Đã xóa thành công", "Thông báo");
                }
            }
            catch
            {

            }
            finally
            {
                //dong connect
                conn.Close();
            }
            LayDSCN();
            resetall();
        }

        private void btnDSCN_Click(object sender, EventArgs e)
        {
            LayDSCN();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            resetall();
        }

        private void resetall()
        {
            txtMaCN.Clear();
            txtTenCN.Clear();
            txtDiaChi.Clear();
            cbbMaQL.SelectedValue = "";
            ckbActive.Checked = false;
            txtNhapTT.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNhapTT.Text))
                {
                    MessageBox.Show("Nhập thông tin để tìm kiếm", "Thông báo");
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdTimKiemCN = new SqlCommand();
                cmdTimKiemCN.CommandText = "sp_TimCNtheoTenCN";
                cmdTimKiemCN.CommandType = CommandType.StoredProcedure;
                cmdTimKiemCN.Connection = conn;
                cmdTimKiemCN.Parameters.AddWithValue("TenCN", txtNhapTT.Text);
                //doi tuong
                DataTable dtTimCN = new DataTable();
                SqlDataAdapter daTimCN = new SqlDataAdapter(cmdTimKiemCN);
                daTimCN.Fill(dtTimCN);
                //
                dgvDSCN.DataSource = dtTimCN;
                
            }
            catch
            {

            }
            finally
            {
                //dong connect
                conn.Close();
            }
            resetall();
        }

        private void dgvDSCN_Click(object sender, EventArgs e)
        {
            int dong = dgvDSCN.CurrentCell.RowIndex;
            txtMaCN.Text = dgvDSCN.Rows[dong].Cells["MaCN"].Value.ToString();
            txtTenCN.Text = dgvDSCN.Rows[dong].Cells["TenCN"].Value.ToString();
            txtDiaChi.Text = dgvDSCN.Rows[dong].Cells["DiaChi"].Value.ToString();
            cbbMaQL.SelectedValue = dgvDSCN.Rows[dong].Cells["MaQuanLy"].Value.ToString();
            ckbActive.Checked = Convert.ToBoolean(dgvDSCN.Rows[dong].Cells["IsActive"].Value);
        }
    }
}
