using QLResort.BUS;
using QLResort.Core.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmPaymentType : Form
    {
        private readonly PaymentTypeBUS paymentTypeBUS = new PaymentTypeBUS();
        private string selectedMaLTT = null;

        public frmPaymentType()
        {
            InitializeComponent();
        }

        private void frmPaymentType_Load(object sender, EventArgs e)
        {
            LoadPaymentTypes();
            ResetForm();
        }

        private void LoadPaymentTypes()
        {
            lvPaymentTypes.Items.Clear();
            var result = paymentTypeBUS.GetPaymentTypes(isActive: null);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var pt in result.Data)
            {
                ListViewItem item = new ListViewItem(pt.MaLTT);
                item.SubItems.Add(pt.TenLTT ?? "");
                item.SubItems.Add(pt.IsActive ? "✓" : "✗");
                item.Tag = pt;
                lvPaymentTypes.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            selectedMaLTT = null;
            txtMaLTT.Clear();
            txtTenLTT.Clear();
            cbIsActive.Checked = true;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTenLTT.Text))
            {
                errorProvider1.SetError(txtTenLTT, "Tên loại thanh toán không được để trống");
                isValid = false;
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var result = paymentTypeBUS.AddPaymentType(txtTenLTT.Text.Trim(), cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Thêm loại thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPaymentTypes();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaLTT))
            {
                MessageBox.Show("Vui lòng chọn loại thanh toán cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            var result = paymentTypeBUS.UpdatePaymentType(selectedMaLTT, txtTenLTT.Text.Trim(), cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Cập nhật loại thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPaymentTypes();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaLTT))
            {
                MessageBox.Show("Vui lòng chọn loại thanh toán cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa loại thanh toán này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var result = paymentTypeBUS.DeletePaymentType(selectedMaLTT);
                if (result.Success)
                {
                    MessageBox.Show("Xóa loại thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPaymentTypes();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lvPaymentTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPaymentTypes.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvPaymentTypes.SelectedItems[0];
            if (item.Tag is PaymentType pt)
            {
                selectedMaLTT = pt.MaLTT;
                txtMaLTT.Text = pt.MaLTT;
                txtTenLTT.Text = pt.TenLTT ?? "";
                cbIsActive.Checked = pt.IsActive;

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {

        }
    }
}


