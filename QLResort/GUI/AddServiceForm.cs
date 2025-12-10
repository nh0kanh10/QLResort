using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLResort.GUI
{
    // Form này kế thừa từ Form và sử dụng các Controls đã khai báo trong AddServiceForm.Designer.cs
    public partial class AddServiceForm : Form
    {
        public ServiceItem Result { get; private set; }

        public AddServiceForm()
        {
            // InitializeComponent() gọi code trong AddServiceForm.Designer.cs
            InitializeComponent();
            // Không cần BuildSimpleUI() nữa vì đã chuyển code vào InitializeComponent
        }

        /// <summary>
        /// Event Handler for the OK button click.
        /// Hàm xử lý sự kiện khi nhấn nút OK.
        /// </summary>
        private void BtnOk_Click(object sender, EventArgs e)
        {
            // Validation Logic (Logic kiểm tra hợp lệ)
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nhập tên dịch vụ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price < 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Collect Data and Set Result (Thu thập dữ liệu và đặt kết quả)
            Result = new ServiceItem
            {
                Name = txtName.Text.Trim(),
                Qty = (int)nudQty.Value,
                Price = price
            };

            // Set DialogResult (Thiết lập kết quả dialog)
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Event Handler for the Cancel button click (moved from inline lambda).
        /// Hàm xử lý sự kiện khi nhấn nút Hủy (được chuyển từ lambda function).
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
