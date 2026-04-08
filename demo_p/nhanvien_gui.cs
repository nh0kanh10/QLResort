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

namespace demo_p
{
    public partial class nhanvien_gui : Form
    {
        public nhanvien_gui()
        {
            InitializeComponent();
        }
        //ket noi database
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-3OT375B;Initial Catalog=QLR;Integrated Security=True");
        private void nhanvien_gui_Load(object sender, EventArgs e)
        {
            LayDSNV();
            LayDSTenCN();
            LayDSLoaiNV();
            txtMaNV.Focus();
        }
        //lay danh sach nhan vien
        private void LayDSNV()
        {
            try
            {
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdDSNV = new SqlCommand();
                cmdDSNV.CommandText = "sp_LayDSNV";
                cmdDSNV.CommandType = CommandType.StoredProcedure;
                cmdDSNV.Connection = conn;
                //doi tuong
                DataTable dtDSNV = new DataTable();
                SqlDataAdapter daDSNV = new SqlDataAdapter(cmdDSNV);
                daDSNV.Fill(dtDSNV);
                //dua data gridview
                dgvDSNV.DataSource = dtDSNV;
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
            txtMaNV.Focus();
        }

        private void dgvDSNV_Click(object sender, EventArgs e)
        {
            int dong = dgvDSNV.CurrentCell.RowIndex;
            txtMaNV.Text = dgvDSNV.Rows[dong].Cells["MaNV"].Value.ToString();
            cbbMaCN.SelectedValue = dgvDSNV.Rows[dong].Cells["MaCN"].Value.ToString();
            txtCCCD.Text = dgvDSNV.Rows[dong].Cells["CCCD"].Value.ToString();
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            gioiTinh = dgvDSNV.Rows[dong].Cells["GioiTinh"].Value.ToString();
            if(gioiTinh == "Nam")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
            txtHoTen.Text = dgvDSNV.Rows[dong].Cells["HoTen"].Value.ToString();
            txtChucVu.Text = dgvDSNV.Rows[dong].Cells["ChucVu"].Value.ToString();
            txtSDT.Text = dgvDSNV.Rows[dong].Cells["SDT"].Value.ToString();
            txtEmail.Text = dgvDSNV.Rows[dong].Cells["Email"].Value.ToString();
            cbbMaLoaiNV.SelectedValue = dgvDSNV.Rows[dong].Cells["MaLoaiNV"].Value.ToString();
            ckbActive.Checked = Convert.ToBoolean(dgvDSNV.Rows[dong].Cells["IsActive"].Value);
        }

        private void LayDSTenCN()
        {
            try
            {
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdTenCN = new SqlCommand();
                cmdTenCN.CommandText = "sp_LayMaLoaiCN";
                cmdTenCN.CommandType = CommandType.StoredProcedure;
                cmdTenCN.Connection = conn;
                //doi tuong
                DataTable dtDSNV = new DataTable();
                SqlDataAdapter daDSNV = new SqlDataAdapter(cmdTenCN);
                daDSNV.Fill(dtDSNV);
                //dua data vao combobox
                cbbMaCN.DataSource = dtDSNV;
                cbbMaCN.DisplayMember = "TenCN";
                cbbMaCN.ValueMember = "MaCN";
                cbbMaCN.SelectedIndex = -1;
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

        private void LayDSLoaiNV()
        {
            try
            {
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdLoaiNV = new SqlCommand();
                cmdLoaiNV.CommandText = "sp_LayMaLoaiNV";
                cmdLoaiNV.CommandType = CommandType.StoredProcedure;
                cmdLoaiNV.Connection = conn;
                //doi tuong
                DataTable dtDSNV = new DataTable();
                SqlDataAdapter daDSNV = new SqlDataAdapter(cmdLoaiNV);
                daDSNV.Fill(dtDSNV);
                //dua data vao combobox
                cbbMaLoaiNV.DataSource = dtDSNV;
                cbbMaLoaiNV.DisplayMember = "TenLoaiNV";
                cbbMaLoaiNV.ValueMember = "MaLoaiNV";
                cbbMaLoaiNV.SelectedIndex = -1;
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
                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    MessageBox.Show("Bạn chưa điền thông tin", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdThemNV = new SqlCommand();
                cmdThemNV.CommandText = "sp_ThemNV";
                cmdThemNV.CommandType = CommandType.StoredProcedure;
                cmdThemNV.Connection = conn;
                //tham so
                SqlParameter paraMaNV = new SqlParameter("MaNV", txtMaNV.Text);
                cmdThemNV.Parameters.Add(paraMaNV);

                SqlParameter paraMaCN = new SqlParameter("MaCN", cbbMaCN.SelectedValue);
                cmdThemNV.Parameters.Add(paraMaCN);

                SqlParameter paraCCCD = new SqlParameter("CCCD", txtCCCD.Text);
                cmdThemNV.Parameters.Add(paraCCCD);

                string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
                SqlParameter paraGioiTinh = new SqlParameter("GioiTinh", gioiTinh);
                cmdThemNV.Parameters.Add(paraGioiTinh);

                SqlParameter paraHoTen = new SqlParameter("HoTen", txtHoTen.Text);
                cmdThemNV.Parameters.Add(paraHoTen);

                SqlParameter paraChucVu = new SqlParameter("ChucVu", txtChucVu.Text);
                cmdThemNV.Parameters.Add(paraChucVu);

                SqlParameter paraSDT = new SqlParameter("SDT", txtSDT.Text);
                cmdThemNV.Parameters.Add(paraSDT);

                SqlParameter paraEmail = new SqlParameter("Email", txtEmail.Text);
                cmdThemNV.Parameters.Add(paraEmail);

                SqlParameter paraMaLoaiNV = new SqlParameter("MaLoaiNV", cbbMaLoaiNV.SelectedValue);
                cmdThemNV.Parameters.Add(paraMaLoaiNV);

                SqlParameter paraIsActive = new SqlParameter("IsActive", ckbActive.Checked);
                cmdThemNV.Parameters.Add(paraIsActive);

                //thuc thi
                if (cmdThemNV.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm Nhân viên thành công", "Thông báo");
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
            LayDSNV();
            ResetTT();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    MessageBox.Show("Chọn Nhân viên cần XÓA", "Thông báo");
                    return;
                }
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn Xóa", "Xác nhận Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.No)
                {
                    return;
                }
                // mo connect
                conn.Open();
                //command
                SqlCommand cmdXoaNV = new SqlCommand();
                cmdXoaNV.CommandText = "sp_XoaNV";
                cmdXoaNV.CommandType = CommandType.StoredProcedure;
                cmdXoaNV.Connection = conn;
                //tham so
                SqlParameter paraMaNV = new SqlParameter("@MaNV", txtMaNV.Text);
                cmdXoaNV.Parameters.Add(paraMaNV);
                //thuc thi
                if (cmdXoaNV.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa Nhân viên thành công", "Thông báo");
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
            LayDSNV();
            ResetTT();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    MessageBox.Show("Chọn Nhân viên cần SỬA", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdSuaTTNV = new SqlCommand();
                cmdSuaTTNV.CommandText = "sp_SuaNV";
                cmdSuaTTNV.CommandType = CommandType.StoredProcedure;
                cmdSuaTTNV.Connection = conn;
                //tham so
                SqlParameter paraMaNV = new SqlParameter("MaNV", txtMaNV.Text);
                cmdSuaTTNV.Parameters.Add(paraMaNV);

                SqlParameter paraMaCN = new SqlParameter("MaCN", cbbMaCN.SelectedValue);
                cmdSuaTTNV.Parameters.Add(paraMaCN);

                SqlParameter paraCCCD = new SqlParameter("CCCD", txtCCCD.Text);
                cmdSuaTTNV.Parameters.Add(paraCCCD);

                string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
                SqlParameter paraGioiTinh = new SqlParameter("GioiTinh", gioiTinh);
                cmdSuaTTNV.Parameters.Add(paraGioiTinh);

                SqlParameter paraHoTen = new SqlParameter("HoTen", txtHoTen.Text);
                cmdSuaTTNV.Parameters.Add(paraHoTen);

                SqlParameter paraChucVu = new SqlParameter("ChucVu", txtChucVu.Text);
                cmdSuaTTNV.Parameters.Add(paraChucVu);

                SqlParameter paraSDT = new SqlParameter("SDT", txtSDT.Text);
                cmdSuaTTNV.Parameters.Add(paraSDT);

                SqlParameter paraEmail = new SqlParameter("Email", txtEmail.Text);
                cmdSuaTTNV.Parameters.Add(paraEmail);

                SqlParameter paraMaLoaiNV = new SqlParameter("MaLoaiNV", cbbMaLoaiNV.SelectedValue);
                cmdSuaTTNV.Parameters.Add(paraMaLoaiNV);

                SqlParameter paraIsActive = new SqlParameter("IsActive", ckbActive.Checked);
                cmdSuaTTNV.Parameters.Add(paraIsActive);

                //thuc thi
                if (cmdSuaTTNV.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa Nhân viên thành công", "Thông báo");
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
            LayDSNV();
            ResetTT();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTT();
        }

        private void ResetTT()
        {
            txtMaNV.Clear();
            cbbMaCN.SelectedValue = "";
            txtCCCD.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            txtHoTen.Clear();
            txtChucVu.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            cbbMaLoaiNV.SelectedValue = "";
            ckbActive.Checked = false;
            txtMaNV.Focus();
        }

        //private void btnTimKiem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(txtCCCD.Text))
        //        {
        //            MessageBox.Show("Nhập thông tin cần tìm kiếm", "Thông báo");
        //            return;
        //        }
                
        //        //mo connect
        //        conn.Open();
        //        //command
        //        SqlCommand cmdTimKiemNV = new SqlCommand();
        //        cmdTimKiemNV.CommandText = "sp_TimTheoCCCD_NV";
        //        cmdTimKiemNV.CommandType = CommandType.StoredProcedure;
        //        cmdTimKiemNV.Connection = conn;
        //        cmdTimKiemNV.Parameters.AddWithValue("@CCCD", txtCCCD.Text);
        //        //doi tuong
        //        DataTable dtTimNV = new DataTable();
        //        SqlDataAdapter daTimNV = new SqlDataAdapter(cmdTimKiemNV);
        //        daTimNV.Fill(dtTimNV);
        //        //thuc thi
        //        dgvDSNV.DataSource = dtTimNV;
        //    }
        //    catch
        //    {
                
        //    }
        //    finally
        //    {
        //        //dong connect
        //        conn.Close();
        //    }
        //}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nhanvien_gui_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false; //dong
            }
            else
            {
                e.Cancel = true; //k dong
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNhap.Text))
                {
                    MessageBox.Show("Nhập thông tin cần tìm kiếm", "Thông báo");
                    return;
                }

                //mo connect
                conn.Open();
                //command
                SqlCommand cmdTimKiemNV = new SqlCommand();
                cmdTimKiemNV.CommandText = "sp_TimTheoTenNV";
                cmdTimKiemNV.CommandType = CommandType.StoredProcedure;
                cmdTimKiemNV.Connection = conn;
                cmdTimKiemNV.Parameters.AddWithValue("@HoTen", txtNhap.Text);
                //doi tuong
                DataTable dtTimNV = new DataTable();
                SqlDataAdapter daTimNV = new SqlDataAdapter(cmdTimKiemNV);
                daTimNV.Fill(dtTimNV);
                //thuc thi
                dgvDSNV.DataSource = dtTimNV;
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
            ResetTT();
        }

        private void pictboxAnhDaiDien_Click(object sender, EventArgs e)
        {

        }

        private void btnDSNV_Click(object sender, EventArgs e)
        {
            LayDSNV();
        }

       
    }
}
