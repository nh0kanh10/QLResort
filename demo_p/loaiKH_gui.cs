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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace demo_p
{
    public partial class loaiKH_gui : Form
    {
        public loaiKH_gui()
        {
            InitializeComponent();
        }
        //ket noi database
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-3OT375B;Initial Catalog=QLR;Integrated Security=True");

        string[] arrTenLKH = new string[4] { "Standard", "Silver", "Gold", "VIP" };
        private void loaiKH_gui_Load(object sender, EventArgs e)
        {
            LayDSLoaiKH();
            
        }
        private void LayDSLoaiKH()
        {
            try
            {
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdLayDSLoaiKH = new SqlCommand();
                cmdLayDSLoaiKH.CommandText = "sp_LayDSLoaiKH";
                cmdLayDSLoaiKH.CommandType = CommandType.StoredProcedure;
                cmdLayDSLoaiKH.Connection = conn;
                //doi tuong
                DataTable dtLayDSLoaiKH = new DataTable();
                SqlDataAdapter daLayDSLoaiKH = new SqlDataAdapter(cmdLayDSLoaiKH);
                daLayDSLoaiKH.Fill(dtLayDSLoaiKH);
                //dua data vao gridview
                dgvTTLKH.DataSource = dtLayDSLoaiKH;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaLKH.Text))
                {
                    MessageBox.Show("Chưa điền thông tin để THÊM", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdThemLoaiKH = new SqlCommand();
                cmdThemLoaiKH.CommandText = "sp_ThemLoaiKH";
                cmdThemLoaiKH.CommandType = CommandType.StoredProcedure;
                cmdThemLoaiKH .Connection = conn;
                //tham so
                SqlParameter paraMaLKH = new SqlParameter("@MaLKH", txtMaLKH.Text);
                cmdThemLoaiKH.Parameters.Add(paraMaLKH);

                SqlParameter paraTenLKH = new SqlParameter("@TenLKH", txtTenLoaiKH.Text);
                cmdThemLoaiKH.Parameters.Add(paraTenLKH);

                SqlParameter paraGiamGia = new SqlParameter("@GiamGiaPercent", txtPercent.Text);
                cmdThemLoaiKH.Parameters.Add(paraGiamGia);

                SqlParameter paraDiem = new SqlParameter("@DiemToiThieu", txtDiem.Text);
                cmdThemLoaiKH.Parameters.Add(paraDiem);

                SqlParameter paraMoTa = new SqlParameter("@MoTa", txtMoTa.Text);
                cmdThemLoaiKH.Parameters.Add(paraMoTa);

                SqlParameter paraIsActive = new SqlParameter("@IsActive", ckbActive.Checked);
                cmdThemLoaiKH.Parameters.Add(paraIsActive);
                //thuc thi
                if(cmdThemLoaiKH.ExecuteNonQuery() > 0)
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
                MessageBox.Show("Lỗi" + ex.Message, "Thông báo");
            }
            finally
            {
                //dong connect
                conn.Close();
            }
            LayDSLoaiKH();
            all_reset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaLKH.Text))
                {
                    MessageBox.Show("Chọn TT để Xóa", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdXoa = new SqlCommand();
                cmdXoa.CommandText = "sp_XoaLoaiKH";
                cmdXoa.CommandType = CommandType.StoredProcedure;
                cmdXoa.Connection = conn;
                //tham so
                SqlParameter paraMaLoaiKH = new SqlParameter("MaLKH", txtMaLKH.Text);
                cmdXoa.Parameters.Add(paraMaLoaiKH);
                //thuc thi
                if (cmdXoa.ExecuteNonQuery() > 0)
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
            LayDSLoaiKH();
            all_reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaLKH.Text))
                {
                    MessageBox.Show("Chọn TT cần sửa", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdSuaLoaiKH = new SqlCommand();
                cmdSuaLoaiKH.CommandText = "sp_SuaLoaiKH";
                cmdSuaLoaiKH.CommandType = CommandType.StoredProcedure;
                cmdSuaLoaiKH.Connection = conn;
                //tham so
                SqlParameter paraMaLKH = new SqlParameter("MaLKH", txtMaLKH.Text);
                cmdSuaLoaiKH.Parameters.Add(paraMaLKH);

                SqlParameter paraTenLKH = new SqlParameter("TenLKH", txtTenLoaiKH.Text);
                cmdSuaLoaiKH.Parameters.Add(paraTenLKH);

                SqlParameter paraPercent = new SqlParameter("GiamGiaPercent", txtPercent.Text);
                cmdSuaLoaiKH.Parameters.Add(paraPercent);

                SqlParameter paraDiem = new SqlParameter("DiemToiThieu", txtDiem.Text);
                cmdSuaLoaiKH.Parameters.Add(paraDiem);

                SqlParameter paraMoTa = new SqlParameter("MoTa", txtMoTa.Text);
                cmdSuaLoaiKH.Parameters.Add(paraMoTa);

                SqlParameter paraIsActive = new SqlParameter("IsActive", ckbActive.Checked);
                cmdSuaLoaiKH.Parameters.Add(paraIsActive);
                //thuc thi
                if(cmdSuaLoaiKH.ExecuteNonQuery() > 0)
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
            LayDSLoaiKH();
            all_reset();
        }

        private void btnDSLKH_Click(object sender, EventArgs e)
        {
            LayDSLoaiKH();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            all_reset();
        }

        private void all_reset()
        {
            txtMaLKH.Clear();
            txtTenLoaiKH.Clear();
            txtPercent.Clear();
            txtDiem.Clear();
            txtMoTa.Clear();
            ckbActive.Checked = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNhap.Text))
                {
                    MessageBox.Show("Nhập TT để tìm", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdTimLoaiKH = new SqlCommand();
                cmdTimLoaiKH.CommandText = "sp_TimTheoTenLoaiKH";
                cmdTimLoaiKH.CommandType = CommandType.StoredProcedure;
                cmdTimLoaiKH.Connection = conn;
                cmdTimLoaiKH.Parameters.AddWithValue("@TenLKH", txtNhap.Text);
                //doi tuong
                DataTable dtTimLoaiKH = new DataTable();
                SqlDataAdapter daTimLoaiKH = new SqlDataAdapter(cmdTimLoaiKH);
                daTimLoaiKH.Fill(dtTimLoaiKH);
                
                //dua data vao gridview
                dgvTTLKH.DataSource = dtTimLoaiKH;

            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi" + ex.Message, "Thông báo");
            }
            finally
            {
                //dong connect
                conn.Close();
            }
            
            all_reset();
        }

        private void dgvTTLKH_Click(object sender, EventArgs e)
        {
            int dong = dgvTTLKH.CurrentCell.RowIndex;
            txtMaLKH.Text = dgvTTLKH.Rows[dong].Cells["MaLKH"].Value.ToString();
            txtTenLoaiKH.Text = dgvTTLKH.Rows[dong].Cells["TenLKH"].Value.ToString();
            txtMoTa.Text = dgvTTLKH.Rows[dong].Cells["MoTa"].Value.ToString();
            txtPercent.Text = dgvTTLKH.Rows[dong].Cells["GiamGiaPercent"].Value.ToString();
            txtDiem.Text = dgvTTLKH.Rows[dong].Cells["DiemToiThieu"].Value.ToString();
            ckbActive.Checked = Convert.ToBoolean(dgvTTLKH.Rows[dong].Cells["IsActive"].Value.ToString());
            
        }

        
    }
}
