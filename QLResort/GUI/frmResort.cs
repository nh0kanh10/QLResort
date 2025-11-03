using QLResort.BLL;
using QLResort.Core;
using QLResort.Core.ClassHoTro;
using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using QLResort.GUI.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLResort.GUI.Resort
{
    public partial class frmResort : Form
    {
        public frmResort()
        {
            InitializeComponent();
        }
        ResortBLL rBLL = new ResortBLL();
        public OperationResult<Dictionary<string,string>> listNQL ;

        private void LoadManagers()
        {
            cbbNguoiQL.Items.Clear();
            listNQL = rBLL.GetDataEmployee();
            if (!listNQL.Success)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + listNQL.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var emp in listNQL.Data)
            {
                var item = new ComboBoxItem(emp.Key, emp.Value);
                cbbNguoiQL.Items.Add(item);
            }

            cbbNguoiQL.DisplayMember = "Text";
            cbbNguoiQL.ValueMember = "ID";

            if (cbbNguoiQL.Items.Count > 0) cbbNguoiQL.SelectedIndex = 0;
        }
        private void LoadResorts()
        {
            
            lvResult.Items.Clear();

            var res = rBLL.GetResorts(); 
            if (!res.Success)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chi nhánh: " + res.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var r in res.Data)
            {
                var lvi = new ListViewItem(r.MaCN);
                lvi.SubItems.Add(r.TenCN);
                lvi.SubItems.Add(r.DiaChi);
                string maql = r.MaNQL ?? "";
                bool find = false;
                foreach (var emp in listNQL.Data)
                {
                    if (emp.Key == maql)
                    {
                        lvi.SubItems.Add(emp.Value);
                        find = true;
                        break;
                    }
                    
                }
                if(!find) lvi.SubItems.Add("");
                lvi.SubItems.Add(r.CreatedBy ?? "");
                lvi.SubItems.Add(r.IsActive ? "✓" : "✗"); 
                lvi.Tag = r.MaCN;
                lvResult.Items.Add(lvi);
            }

        }

        private void frmResort_Load(object sender, EventArgs e)
        {           
            LoadManagers();
            cbHD.Checked = true;
            LoadResorts();    
            ResetForm();      
        }
       
        private void ResetForm()
        {
            txtTen.Clear();
            txtDiaChi.Clear();
            if (cbbNguoiQL.Items.Count > 0) cbbNguoiQL.SelectedIndex = 0;
            cbHD.Checked = true;
            txtTen.Focus();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            frmEmployee frm = new frmEmployee();

            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadManagers();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool hasError = false;

            if (!Validator.IsRequired(txtTen.Text,200))
            {
                errorProvider1.SetError(txtTen, "Tên chi nhánh không hợp lệ hoặc quá 200 ký tự");
                hasError = true;
            }

            if (!Validator.IsRequired(txtTen.Text, 300))
            {
                errorProvider1.SetError(txtDiaChi, "Địa chỉ chi nhánh không hợp lệ hoặc quá 300 ký tự");
                hasError = true;
            }

            if (hasError)
            {
                MessageBox.Show("Vui lòng sửa các lỗi trước khi lưu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return;
            }


            string ten = txtTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            bool isActive = cbHD.Checked;
            string tenNQL = "";
            if (cbbNguoiQL.SelectedItem is ComboBoxItem nql)
            {
                tenNQL = nql.ID;
            }
            ResortM.stt++;
            var result = rBLL.AddResort(ten, diaChi, isActive, tenNQL);
            if (!result.Success)
            {
                ResortM.stt--;
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Thêm chi nhánh thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            LoadResorts();
            ResetForm();
        }
        

        private void SelectManagerByText(string tenNQL)
        {
            if (string.IsNullOrEmpty(tenNQL)) return;
            for (int i = 0; i < cbbNguoiQL.Items.Count; i++)
            {
                if (cbbNguoiQL.Items[i] is ComboBoxItem it && it.Text == tenNQL)
                {
                    cbbNguoiQL.SelectedIndex = i;
                    return;
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvResult.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một chi nhánh để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa các chi nhánh đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Lấy danh sách MaCN cần xóa
            List<string> toDelete = new List<string>();
            foreach (ListViewItem sel in lvResult.SelectedItems)
            {
                toDelete.Add(sel.SubItems[0].Text);
            }

            bool anyFail = false;
            List<string> failMessages = new List<string>();
            foreach (var ma in toDelete)
            {
                var res = rBLL.DeleteResort(ma);
                if (!res.Success)
                {
                    anyFail = true;
                    failMessages.Add($"[{ma}] {res.ErrorMessage}");
                }
            }

            if (anyFail)
            {
                MessageBox.Show("Có lỗi khi xóa:\n" + string.Join("\n", failMessages), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadResorts();
            ResetForm();
        }

        private void lvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvResult.SelectedItems.Count == 0) return;
             var item = lvResult.SelectedItems[0];
            txtTen.Text = item.SubItems[1].Text;
            txtDiaChi.Text = item.SubItems[2].Text;
            cbHD.Checked = item.SubItems[5].Text == "✓";
            SelectManagerByText(item.SubItems[3].Text);


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvResult.SelectedItems.Count == 0) return;
            string maCN = lvResult.SelectedItems[0].SubItems[0].Text;
            string ten  = lvResult.SelectedItems[0].SubItems[1].Text;
            string diaChi = lvResult.SelectedItems[0].SubItems[2].Text;
            string tenNQL = cbbNguoiQL.SelectedItem.ToString();

            string MaNQL = "";
            foreach (var emp in listNQL.Data)
            {
                if (emp.Value == tenNQL)
                {
                    MaNQL = emp.Key;
                    break;
                }
            }
            
            bool hd = cbHD.Checked;
            var result = rBLL.UpdateResort(maCN, ten, diaChi, hd, MaNQL);
            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Cập nhật chi nhánh thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadResorts();
            ResetForm();
        }

        private void frmResort_Shown(object sender, EventArgs e)
        {
            if (lvResult.Items.Count > 0)
            {
                int maxStt = 0;

                foreach (ListViewItem item in lvResult.Items)
                {
                    if (int.TryParse(item.Text.Substring(2), out int stt))
                    {
                        if (stt > maxStt)
                            maxStt = stt;
                    }
                }

                ResortM.stt = maxStt;
            }
        }
    }
}
