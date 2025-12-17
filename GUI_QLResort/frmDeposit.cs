using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_QLResort
{
    public partial class frmDeposit : Form
    {
        public decimal DepositAmount { get; private set; }
        private decimal MinDeposit { get; set; }
        private decimal MaxDeposit { get; set; }

        private Color _defaultLabelColor;

        public frmDeposit(decimal minDeposit, decimal maxDeposit, decimal currentDeposit = 0)
        {
            InitializeComponent();
            _defaultLabelColor = lblDepositAmount.ForeColor; // Capture designer color

            MinDeposit = minDeposit;
            MaxDeposit = maxDeposit;
            DepositAmount = currentDeposit;
            
            SetupControls();
            // BindEvents(); // Removed as requested - Moved to Designer
        }

        private void SetupControls()
        {
            // Setup title
            lblTitle.Text = $"NHẬP TIỀN CỌC (TỪ {MinDeposit:N0} ĐẾN {MaxDeposit:N0} Đ)";
            
            // Setup limits info
            lblMinDeposit.Text = $"Tối thiểu: {MinDeposit:N0} VNĐ";
            lblMaxDeposit.Text = $"Tối đa: {MaxDeposit:N0} VNĐ";
            lblCurrentTotal.Text = $"Tổng tiền: {MaxDeposit:N0} VNĐ"; // MaxDeposit is basically Total Amount

            // Setup NumericUpDown
            nudDeposit.Minimum = 0; // Allow 0 input, but validate on confirm
            nudDeposit.Maximum = MaxDeposit; // Cannot exceed total
            nudDeposit.Value = DepositAmount > 0 ? DepositAmount : 0;
            
            UpdateSummary();
        }

        private void ApplyPercentage(decimal pct)
        {
            decimal amount = MaxDeposit * pct;
            
            // Ensure within range / bounds
            if (amount < MinDeposit) amount = MinDeposit;
            if (amount > MaxDeposit) amount = MaxDeposit;

            nudDeposit.Value = amount; // Will trigger ValueChanged
        }

        // Event Handlers wired in Designer

        private void nudDeposit_ValueChanged(object sender, EventArgs e)
        {
            UpdateSummary();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            decimal amount = nudDeposit.Value;

            if (amount < MinDeposit)
            {
                MessageBox.Show($"Số tiền cọc phải tối thiểu {MinDeposit:N0} VNĐ!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (amount > MaxDeposit)
            {
                MessageBox.Show($"Số tiền cọc không được vượt quá {MaxDeposit:N0} VNĐ!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DepositAmount = amount;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnQuick30_Click(object sender, EventArgs e)
        {
            ApplyPercentage(0.3m);
        }

        private void btnQuick50_Click(object sender, EventArgs e)
        {
            ApplyPercentage(0.5m);
        }

        private void btnQuick70_Click(object sender, EventArgs e)
        {
            ApplyPercentage(0.7m);
        }

        private void btnQuick100_Click(object sender, EventArgs e)
        {
            ApplyPercentage(1.0m);
        }

        private void UpdateSummary()
        {
            decimal current = nudDeposit.Value;
            
            // Calculate percentage
            decimal percent = MaxDeposit > 0 ? (current / MaxDeposit) * 100 : 0;
            lblPercentage.Text = $"{percent:F1}% tổng hóa đơn";

            // Validation Visuals
            if (current < MinDeposit)
            {
                lblDepositAmount.ForeColor = Color.Red;
                lblDepositAmount.Text = $"Số tiền cọc (Thấp hơn tối thiểu {MinDeposit:N0})";
                btnConfirm.Enabled = false;
            }
            else
            {
                lblDepositAmount.ForeColor = _defaultLabelColor;
                lblDepositAmount.Text = "Số tiền cọc (*)";
                btnConfirm.Enabled = true;
            }
        }
    }
}
