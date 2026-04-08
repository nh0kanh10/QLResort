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
    public partial class gui_loaiNV : Form
    {
        public gui_loaiNV()
        {
            InitializeComponent();
        }
        //ket noi database
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QLR;Integrated Security=True");
        private void gui_loaiNV_Load(object sender, EventArgs e)
        {
            LayDSLoaiNV();
        }

        private void LayDSLoaiNV()
        {
            try
            {
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdLayDSLoaiNv = new SqlCommand();
                cmdLayDSLoaiNv.CommandText = "sp_LayDSLoaiNV";
                cmdLayDSLoaiNv.CommandType = CommandType.StoredProcedure;
                cmdLayDSLoaiNv.Connection = conn;
                //doi tuong
                DataTable dtLayDSLoaiNV = new DataTable();
                SqlDataAdapter daLayDSLoaiNV = new SqlDataAdapter(cmdLayDSLoaiNv);
                daLayDSLoaiNV.Fill(dtLayDSLoaiNV);
                //dua dl vao gridview
                dgvTTLoaiNV.DataSource = dtLayDSLoaiNV;


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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaLNV.Text))
                {
                    MessageBox.Show("Chưa điền thông tin để thêm ", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdThemLoaiNV = new SqlCommand();
                cmdThemLoaiNV.CommandText = "sp_ThemLoaiNV";
                cmdThemLoaiNV.CommandType = CommandType.StoredProcedure;
                cmdThemLoaiNV.Connection = conn;
                //tham so
                SqlParameter paraMaLoaiNV = new SqlParameter("MaLoaiNV", txtMaLNV.Text);
                cmdThemLoaiNV.Parameters.Add(paraMaLoaiNV);

                SqlParameter paraTenLoaiNV = new SqlParameter("TenLoaiNV", txtTenLNV.Text);
                cmdThemLoaiNV.Parameters.Add(paraTenLoaiNV);

                SqlParameter paraMoTa = new SqlParameter("MoTa", txtMoTa.Text);
                cmdThemLoaiNV.Parameters.Add(paraMoTa);

                SqlParameter paraIsActive = new SqlParameter("IsActive", ckbActive.Checked);
                cmdThemLoaiNV.Parameters.Add(paraIsActive);

                //thuc thi
                if (cmdThemLoaiNV.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Thêm KHÔNG thành công", "Thông báo");
                }
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
            LayDSLoaiNV();
            ResetAll();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaLNV.Text))
                {
                    MessageBox.Show("Chọn TT để xóa", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdXoaLoaiNV = new SqlCommand();
                cmdXoaLoaiNV.CommandText = "sp_XoaLoaiNV";
                cmdXoaLoaiNV.CommandType = CommandType.StoredProcedure;
                cmdXoaLoaiNV.Connection = conn;
                //tham so
                SqlParameter paraMaLoaiNV = new SqlParameter("MaLoaiNV", txtMaLNV.Text);
                cmdXoaLoaiNV.Parameters.Add(paraMaLoaiNV);
                //thuc thi
                if (cmdXoaLoaiNV.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Xóa KHÔNG thành công", "Thông báo");
                }
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
            LayDSLoaiNV();
            ResetAll();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaLNV.Text))
                {
                    MessageBox.Show("Chọn TT để sửa", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();

                //command
                SqlCommand cmdSuaLoaiNV = new SqlCommand();
                cmdSuaLoaiNV.CommandText = "sp_SuaLoaiNV";
                cmdSuaLoaiNV.CommandType = CommandType.StoredProcedure;
                cmdSuaLoaiNV.Connection = conn;

                //tham so
                SqlParameter pamaMaLoaiNV = new SqlParameter("MaLoaiNV", txtMaLNV.Text);
                cmdSuaLoaiNV.Parameters.Add(pamaMaLoaiNV);

                SqlParameter pamaTenLoaiNV = new SqlParameter("TenLoaiNV", txtTenLNV.Text);
                cmdSuaLoaiNV.Parameters.Add(pamaTenLoaiNV);

                SqlParameter pamaMoTa = new SqlParameter("MoTa", txtMoTa.Text);
                cmdSuaLoaiNV.Parameters.Add(pamaMoTa);

                SqlParameter pamaIsActive = new SqlParameter("IsActive", ckbActive.Checked);
                cmdSuaLoaiNV.Parameters.Add(pamaIsActive);

                //thuc thi
                if(cmdSuaLoaiNV.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Sửa KHÔNG thành công", "Thông báo");
                }

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
            LayDSLoaiNV();
            ResetAll();
        }

        private void btnDSLNV_Click(object sender, EventArgs e)
        {
            LayDSLoaiNV();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void ResetAll()
        {
            txtMaLNV.Clear();
            txtTenLNV.Clear();
            txtMoTa.Clear();
            ckbActive.Checked = false;
            txtNhap.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNhap.Text))
                {
                    MessageBox.Show("Chưa nhập gì để tìm kiếm", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdTimLoaiNV = new SqlCommand();
                cmdTimLoaiNV.CommandText = "sp_TimTheoTenLoaiNV";
                cmdTimLoaiNV.CommandType = CommandType.StoredProcedure;
                cmdTimLoaiNV.Connection = conn;
                cmdTimLoaiNV.Parameters.AddWithValue("@TenLoaiNV", txtNhap.Text);

                //doi tuong
                DataTable dtTim = new DataTable();
                SqlDataAdapter daTim = new SqlDataAdapter(cmdTimLoaiNV);
                daTim.Fill(dtTim);

                dgvTTLoaiNV.DataSource = dtTim;
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
            
            ResetAll();
        }

        private void dgvTTLoaiNV_Click(object sender, EventArgs e)
        {
            int dong = dgvTTLoaiNV.CurrentCell.RowIndex;
            txtMaLNV.Text = dgvTTLoaiNV.Rows[dong].Cells["MaLoaiNV"].Value.ToString();

            txtTenLNV.Text = dgvTTLoaiNV.Rows[dong].Cells["TenLoaiNV"].Value.ToString();

            txtMoTa.Text = dgvTTLoaiNV.Rows[dong].Cells["Mota"].Value.ToString();

            ckbActive.Checked = Convert.ToBoolean(dgvTTLoaiNV.Rows[dong].Cells["IsActive"].Value);
            
        }

        private void gui_loaiNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        
    }
}
