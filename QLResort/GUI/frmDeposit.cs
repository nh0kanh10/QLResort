using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmDeposit : Form
    {
        public decimal DepositAmount { get; private set; }
        private decimal MinDeposit { get; set; }
        private decimal MaxDeposit { get; set; }

        public frmDeposit(decimal minDeposit, decimal maxDeposit, decimal currentDeposit = 0)
        {
            InitializeComponent();
            MinDeposit = minDeposit;
            MaxDeposit = maxDeposit;
            DepositAmount = currentDeposit;
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Đặt cọc";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Labels
            var lblTitle = new Label()
            {
                Text = $"NHẬP TIỀN CỌC (Từ {MinDeposit:N0} đ đến {MaxDeposit:N0} đ)",
                Location = new Point(20, 20),
                Width = 350,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(41, 128, 185)
            };

            var lblAmount = new Label()
            {
                Text = "Số tiền cọc:",
                Location = new Point(20, 70),
                Width = 100
            };

            var lblNote = new Label()
            {
                Text = $"* Tiền cọc tối thiểu: {MinDeposit:N0} đ ({MinDeposit / MaxDeposit * 100:0}% tổng tiền phòng)",
                Location = new Point(20, 120),
                Width = 350,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 8)
            };

            // Textbox for deposit amount
            var txtDeposit = new TextBox()
            {
                Location = new Point(120, 67),
                Width = 200,
                Text = DepositAmount > 0 ? DepositAmount.ToString("N0") : ""
            };

            // Buttons
            var btnOK = new Button()
            {
                Text = "XÁC NHẬN",
                Location = new Point(120, 160),
                Size = new Size(80, 35),
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button()
            {
                Text = "HỦY",
                Location = new Point(220, 160),
                Size = new Size(80, 35),
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.Cancel
            };

            // Validation
            txtDeposit.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            txtDeposit.TextChanged += (s, e) =>
            {
                if (string.IsNullOrEmpty(txtDeposit.Text))
                {
                    DepositAmount = 0;
                    return;
                }

                if (decimal.TryParse(txtDeposit.Text.Replace(",", ""), out decimal amount))
                {
                    if (amount < MinDeposit)
                    {
                        txtDeposit.ForeColor = Color.Red;
                        btnOK.Enabled = false;
                    }
                    else if (amount > MaxDeposit)
                    {
                        txtDeposit.ForeColor = Color.Red;
                        btnOK.Enabled = false;
                    }
                    else
                    {
                        txtDeposit.ForeColor = Color.Black;
                        btnOK.Enabled = true;
                        DepositAmount = amount;
                    }
                }
            };

            btnOK.Click += (s, e) =>
            {
                if (DepositAmount < MinDeposit || DepositAmount > MaxDeposit)
                {
                    MessageBox.Show($"Số tiền cọc phải từ {MinDeposit:N0} đ đến {MaxDeposit:N0} đ!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                }
            };

            this.Controls.AddRange(new Control[] {
                lblTitle, lblAmount, lblNote, txtDeposit, btnOK, btnCancel
            });

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }
    }
}
