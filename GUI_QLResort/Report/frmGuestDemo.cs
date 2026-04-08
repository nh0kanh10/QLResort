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
    public partial class khachhang_gui : Form
    {
        public khachhang_gui()
        {
            InitializeComponent();
        }
        //ket noi database
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=QLR;Integrated Security=True");
        string[] arrIDType = new string[2] { "CCCD", "Passport" };
        private void khachhang_gui_Load(object sender, EventArgs e)
        {
            LayDSKH();
            LayDSLoaiKH();
            cbbIDType.DataSource = arrIDType;
            cbbIDType.SelectedIndex = -1;
        }
        //lay danh sach khach hang
        private void LayDSKH()
        {
            try
            {
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdLayDSKH = new SqlCommand();
                cmdLayDSKH.CommandText = "sp_LayDSKH";
                cmdLayDSKH.CommandType = CommandType.StoredProcedure;
                cmdLayDSKH.Connection = conn;
                
                //doi tuong
                DataTable dtDSKH = new DataTable();
                SqlDataAdapter daDSKH = new SqlDataAdapter(cmdLayDSKH);
                daDSKH.Fill(dtDSKH);
                //dua data vào gridview
                dgvDSKH.DataSource = dtDSKH;
                dtpNgaySinh.Format = DateTimePickerFormat.Custom;
                dtpNgaySinh.CustomFormat = " ";
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Thông báo");
            }
            finally
            {
                //dong connect
                conn.Close();
            }
        }

        private void LayDSLoaiKH()
        {
            try
            {
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdLoaiKH = new SqlCommand();
                cmdLoaiKH.CommandText = "sp_LayDSLoaiKH";
                cmdLoaiKH.CommandType = CommandType.StoredProcedure;
                cmdLoaiKH.Connection = conn;
                //doi tuong
                DataTable dtLoaiKH = new DataTable();
                SqlDataAdapter daLoaiKH = new SqlDataAdapter(cmdLoaiKH);
                daLoaiKH.Fill(dtLoaiKH);
                //dua dl vao combobox
                cbbMaLoaiKH.DataSource = dtLoaiKH;
                cbbMaLoaiKH.DisplayMember = "TenLKH";
                cbbMaLoaiKH.ValueMember = "MaLKH";
                cbbMaLoaiKH.SelectedIndex = -1;
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

        private void dgvDSKH_Click(object sender, EventArgs e)
        {
            int dong = dgvDSKH.CurrentCell.RowIndex;

            txtMaKH.Text = dgvDSKH.Rows[dong].Cells["MaKH"].Value.ToString();

            txtHoTenKH.Text = dgvDSKH.Rows[dong].Cells["HoTen"].Value.ToString();

            string gioiTinh = dgvDSKH.Rows[dong].Cells["GioiTinh"].Value.ToString();
            if (gioiTinh == "Nam")
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }

            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Value = DateTime.Parse(dgvDSKH.Rows[dong].Cells["NgaySinh"].Value.ToString());

            txtSDT.Text = dgvDSKH.Rows[dong].Cells["SDT"].Value.ToString();

            txtEmail.Text = dgvDSKH.Rows[dong].Cells["Email"].Value.ToString();

            cbbIDType.SelectedItem = dgvDSKH.Rows[dong].Cells["IDType"].Value.ToString();

            txtIDNumber.Text = dgvDSKH.Rows[dong].Cells["IDNumber"].Value.ToString();

            txtDiaChi.Text = dgvDSKH.Rows[dong].Cells["DiaChi"].Value.ToString();

            cbbMaLoaiKH.SelectedValue = dgvDSKH.Rows[dong].Cells["MaLKH"].Value.ToString();

            ckbActive.Checked = Convert.ToBoolean(dgvDSKH.Rows[dong].Cells["IsActive"].Value);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    MessageBox.Show("Bạn chưa điền thông tin", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdThemKH = new SqlCommand();
                cmdThemKH.CommandText = "sp_ThemKH";
                cmdThemKH.CommandType = CommandType.StoredProcedure;
                cmdThemKH.Connection = conn;
                //tham so
                SqlParameter paraMaKH = new SqlParameter("MaKH", txtMaKH.Text);
                cmdThemKH.Parameters.Add(paraMaKH);

                SqlParameter paraHoTenKH = new SqlParameter("HoTen", txtHoTenKH.Text);
                cmdThemKH.Parameters.Add(paraHoTenKH);

                string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
                SqlParameter paraGioiTinh = new SqlParameter("GioiTinh", gioiTinh);
                cmdThemKH.Parameters.Add(paraGioiTinh);
               
                SqlParameter paraNgaySinh = new SqlParameter("NgaySinh", dtpNgaySinh.Value);
                cmdThemKH.Parameters.Add(paraNgaySinh);

                SqlParameter paraSDT = new SqlParameter("SDT", txtSDT.Text);
                cmdThemKH.Parameters.Add(paraSDT);

                SqlParameter paraEmail = new SqlParameter("Email", txtEmail.Text);
                cmdThemKH.Parameters.Add(paraEmail);

                SqlParameter paraIDType = new SqlParameter("IDType", cbbIDType.SelectedText);
                cmdThemKH.Parameters.Add(paraIDType);

                SqlParameter paraIDNumber = new SqlParameter("IDNumber", txtIDNumber.Text);
                cmdThemKH.Parameters.Add(paraIDNumber);

                SqlParameter paraDiaChi = new SqlParameter("DiaChi", txtDiaChi.Text);
                cmdThemKH.Parameters.Add(paraDiaChi);

                SqlParameter paraMaLKH = new SqlParameter("MaLKH", cbbMaLoaiKH.SelectedValue);
                cmdThemKH.Parameters.Add(paraMaLKH);

                SqlParameter paraIsActive = new SqlParameter("IsActive", ckbActive.Checked);
                cmdThemKH.Parameters.Add(paraIsActive);

                //thuc thi
                if (cmdThemKH.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm KH thành công", "Thông báo");
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
            LayDSKH();
            resetall();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    MessageBox.Show("Bạn chưa chọn gì để xóa", "Thông báo");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return; // người dùng chọn NO → không xóa
                }

                //mo connect
                conn.Open();
                //command
                SqlCommand cmdXoaKH = new SqlCommand();
                cmdXoaKH.CommandText = "sp_XoaKH";
                cmdXoaKH.CommandType = CommandType.StoredProcedure;
                cmdXoaKH.Connection = conn;
                //tham so
                SqlParameter paraMaKH = new SqlParameter("MaKH", txtMaKH.Text);
                cmdXoaKH.Parameters.Add(paraMaKH);
                //thuc thi
                if (cmdXoaKH.ExecuteNonQuery() > 0)
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
            LayDSKH();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaKH.Text))
                {
                    MessageBox.Show("Chọn để SỬA", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdSuaTTKH = new SqlCommand();
                cmdSuaTTKH.CommandText = "sp_SuaKH";
                cmdSuaTTKH.CommandType = CommandType.StoredProcedure;
                cmdSuaTTKH.Connection = conn;
                //tham so
                SqlParameter paraMaKH = new SqlParameter("MaKH", txtMaKH.Text);
                cmdSuaTTKH.Parameters.Add(paraMaKH);

                SqlParameter paraHoTen = new SqlParameter("HoTen", txtHoTenKH.Text);
                cmdSuaTTKH.Parameters.Add(paraHoTen);

                string gioiTinh = radNam.Checked ? "Nam": "Nữ";
                SqlParameter paraGioiTinh = new SqlParameter("GioiTinh", gioiTinh);
                cmdSuaTTKH.Parameters.Add(paraGioiTinh);

                SqlParameter paraNgaySinh = new SqlParameter("NgaySinh", dtpNgaySinh.Value);
                cmdSuaTTKH.Parameters.Add(paraNgaySinh);

                SqlParameter paraSDT = new SqlParameter("SDT", txtSDT.Text);
                cmdSuaTTKH.Parameters.Add(paraSDT);

                SqlParameter paraEmail = new SqlParameter("Email", txtEmail.Text);
                cmdSuaTTKH.Parameters.Add(paraEmail);

                SqlParameter paraIDType = new SqlParameter("IDType", cbbIDType.SelectedText);
                cmdSuaTTKH.Parameters.Add(paraIDType);

                SqlParameter paraIDNumber= new SqlParameter("IDNumber", txtIDNumber.Text);
                cmdSuaTTKH.Parameters.Add(paraIDNumber);
                
                SqlParameter paraDiaChi = new SqlParameter("DiaChi", txtDiaChi.Text);
                cmdSuaTTKH.Parameters.Add(paraDiaChi);

                SqlParameter paraMaLKH = new SqlParameter("MaLKH", cbbMaLoaiKH.SelectedValue);
                cmdSuaTTKH.Parameters.Add(paraMaLKH);

                SqlParameter paraIsActive = new SqlParameter("IsActive", ckbActive.Checked);
                cmdSuaTTKH.Parameters.Add(paraIsActive);

                //thuc thi
                if(cmdSuaTTKH.ExecuteNonQuery() > 0)
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
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            resetall();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void resetall()
        {
            txtMaKH.Clear();
            txtHoTenKH.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = " ";
            txtSDT.Clear();
            txtEmail.Clear();
            cbbMaLoaiKH.SelectedValue = "";
            cbbIDType.SelectedIndex = -1;
            txtIDNumber.Clear();
            txtDiaChi.Clear();
            cbbMaLoaiKH.SelectedValue = "";
            ckbActive.Checked = false;
            txtNhap.Clear();
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNhap.Text))
                {
                    MessageBox.Show("Bạn chưa nhập gì để tìm", "Thông báo");
                    return;
                }
                //mo connect
                conn.Open();
                //command
                SqlCommand cmdTimKiem = new SqlCommand();
                cmdTimKiem.CommandText = "sp_TimTheoIDNumberKH";
                cmdTimKiem.CommandType = CommandType.StoredProcedure;
                cmdTimKiem.Connection = conn;
                cmdTimKiem.Parameters.AddWithValue("@IDNumber", txtNhap.Text);
                //doi tuong
                DataTable dtTK = new DataTable();
                SqlDataAdapter daTK = new SqlDataAdapter(cmdTimKiem);
                daTK.Fill(dtTK);

                dgvDSKH.DataSource = dtTK;

            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
            resetall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LayDSKH();
        }

        private void khachhang_gui_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát", "Xác nhận Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }    
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                GUI_QLResort.RP_TTKH frm = new GUI_QLResort.RP_TTKH();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi in báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
