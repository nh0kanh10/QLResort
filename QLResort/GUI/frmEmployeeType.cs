using QLResort.BLL;
using QLResort.Core;
using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.DAL.EmployeeDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace QLResort.GUI.Employee
{
    public partial class frmEmployeeType : Form
    {
        public frmEmployeeType()
        {
            InitializeComponent();
        }
        EmployeeTypeBLL ETBLL = new EmployeeTypeBLL();

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool hasError = false;

            if (string.IsNullOrWhiteSpace(txtTen.Text) || txtTen.Text.Length > 200)
            {
                errorProvider1.SetError(txtTen, "Tên loại nhân viên không hợp lệ");
                hasError = true;
            }

            if (txtMoTa.Text.Length > 500)
            {
                errorProvider1.SetError(txtMoTa, "Mô tả không được quá 500 ký tự!");
                hasError = true;
            }

            if (hasError)
            {
                MessageBox.Show("Vui lòng sửa các lỗi trước khi lưu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OperationResult<EmployeeType> result = ETBLL.Add(txtTen.Text.Trim(), txtMoTa.Text.Trim(), rbMo.Checked);
            if (result.Success)
            {
                EmployeeType.stt++;
                errorProvider1.SetError(txtTen, "");
                addToListView(result.Data);
            }
            else
            {
                errorProvider1.SetError(txtTen, result.ErrorMessage);
            }
        }
        /// <summary>
        /// Hàm ánh xạ EmployeeType lên list view
        /// </summary>
        /// <param name="itemE"></param>
        public void addToListView(EmployeeType itemE)
        {
            ListViewItem item = new ListViewItem(itemE.MaLoaiNV);

            item.SubItems.Add(itemE.TenLoaiNV);
            item.SubItems.Add(itemE.MoTa ?? "");
            item.SubItems.Add(itemE.CreatedBy ?? "");
            item.SubItems.Add(itemE.CreatedAt.ToString("dd/MM/yyyy HH:mm"));
            item.SubItems.Add(itemE.IsActive ? "✓" : "✗");

            lvLNV.Items.Add(item);
        }

        private void frmEmployeeType_Load(object sender, EventArgs e)
        {
            OperationResult<List<EmployeeType>> list = ETBLL.GetAllInBLL();
            if (!list.Success)
            {
                MessageBox.Show(list.ErrorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            rbMo.Checked = true;
            lvLNV.Items.Clear();

            foreach (var itemE in list.Data)
            {
                addToListView(itemE);
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvLNV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa!", "Thông báo");
                return;
            }

            //Hỗ trợ việc thông báo xoá nhiều hay xoá một dòng 
            string message = lvLNV.SelectedItems.Count == 1
                ? "Bạn có chắc muốn xóa dòng vừa chọn không?"
                : $"Bạn có chắc muốn xóa {lvLNV.SelectedItems.Count} dòng đã chọn không?";

            if (MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                List<ListViewItem> itemsToRemove = new List<ListViewItem>();
                int successCount = 0;
                int failCount = 0;

                foreach (ListViewItem item in lvLNV.SelectedItems)
                {
                    var result = ETBLL.Delete(item.SubItems[0].Text); // Hàm xoa bên bll trả về operationResult
                    if (result.Success)                              // gồm isSucces ,data nếu isSucces và error mess nếu !isSucces
                    {
                        itemsToRemove.Add(item);
                        successCount++;
                    }
                    else
                    {
                        failCount++;
                        MessageBox.Show(result.ErrorMessage, "Lỗi khi xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                foreach (var item in itemsToRemove)
                    lvLNV.Items.Remove(item);

                if (successCount > 0)
                {
                    string successMsg = lvLNV.SelectedItems.Count == 1
                        ? "Xóa thành công!"
                        : $"Đã xóa thành công {successCount} dòng.";
                    MessageBox.Show(successMsg, "Thông báo");
                }

                if (failCount > 0)
                    MessageBox.Show($"Có {failCount} dòng không thể xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvLNV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một loại nhân viên để sửa!");
                return;
            }

            ListViewItem item = lvLNV.SelectedItems[0];
            string maLoaiNV = item.SubItems[0].Text;
            string tenLoaiNV = txtTen.Text.Trim();
            string moTa = txtMoTa.Text.Trim();
            bool isActive = rbMo.Checked;

            if (MessageBox.Show("Bạn có chắc muốn cập nhật thông tin này không?",
                                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OperationResult<EmployeeType> result = ETBLL.Update(maLoaiNV, tenLoaiNV, moTa, isActive);
                if (result.Success)
                {
                    item.SubItems[1].Text = tenLoaiNV;
                    item.SubItems[2].Text = moTa;
                    item.SubItems[5].Text = isActive ? "✓" : "✗";
                    MessageBox.Show("Cập nhật thành công!");
                    txtTen.Text = "";
                    txtTen.Focus();
                    txtMoTa.Text = "";
                    rbMo.Checked = true;
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Thông báo");
                }
            }
        }


        private void lvLNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLNV.SelectedItems.Count == 0)
            {
                return;
            }
            ListViewItem item = lvLNV.SelectedItems[0];
            txtTen.Text = item.SubItems[1].Text;
            txtMoTa.Text = item.SubItems[2].Text;
            if (item.SubItems[5].Text == "✓") rbMo.Checked = true;
            else rbDong.Checked = true;
        }

        private void frmEmployeeType_Shown(object sender, EventArgs e)
        {
            if (lvLNV.Items.Count > 0)
            {
                int maxStt = 0;

                foreach (ListViewItem item in lvLNV.Items)
                {
                    if (int.TryParse(item.Text.Substring(3), out int stt))
                    {
                        if (stt > maxStt)
                            maxStt = stt;
                    }
                }

                EmployeeType.stt = maxStt + 1; /// cập nhật lại mã loại khách hàng mỗi lần khởi động lại app

            }
            txtTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEmployeeType_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
