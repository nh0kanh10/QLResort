namespace QLResort.GUI
{
    partial class frmDeposit
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblCurrentTotal;
        private System.Windows.Forms.Label lblMinDeposit;
        private System.Windows.Forms.Label lblMaxDeposit;
        private System.Windows.Forms.NumericUpDown nudDeposit;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Panel pnlQuickButtons;
        private System.Windows.Forms.Button btnQuick30;
        private System.Windows.Forms.Button btnQuick50;
        private System.Windows.Forms.Button btnQuick70;
        private System.Windows.Forms.Button btnQuick100;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDepositAmount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblDepositAmount = new System.Windows.Forms.Label();
            this.nudDeposit = new System.Windows.Forms.NumericUpDown();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblCurrentTotal = new System.Windows.Forms.Label();
            this.lblMinDeposit = new System.Windows.Forms.Label();
            this.lblMaxDeposit = new System.Windows.Forms.Label();
            this.pnlQuickButtons = new System.Windows.Forms.Panel();
            this.btnQuick30 = new System.Windows.Forms.Button();
            this.btnQuick50 = new System.Windows.Forms.Button();
            this.btnQuick70 = new System.Windows.Forms.Button();
            this.btnQuick100 = new System.Windows.Forms.Button();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeposit)).BeginInit();
            this.pnlQuickButtons.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(543, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(199, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "NHẬP TIỀN CỌC";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.lblDepositAmount);
            this.pnlMain.Controls.Add(this.nudDeposit);
            this.pnlMain.Controls.Add(this.lblPercentage);
            this.pnlMain.Controls.Add(this.lblCurrentTotal);
            this.pnlMain.Controls.Add(this.lblMinDeposit);
            this.pnlMain.Controls.Add(this.lblMaxDeposit);
            this.pnlMain.Controls.Add(this.pnlQuickButtons);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(30);
            this.pnlMain.Size = new System.Drawing.Size(543, 340);
            this.pnlMain.TabIndex = 1;
            // 
            // lblDepositAmount
            // 
            this.lblDepositAmount.AutoSize = true;
            this.lblDepositAmount.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.lblDepositAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDepositAmount.Location = new System.Drawing.Point(26, 30);
            this.lblDepositAmount.Name = "lblDepositAmount";
            this.lblDepositAmount.Size = new System.Drawing.Size(122, 23);
            this.lblDepositAmount.TabIndex = 6;
            this.lblDepositAmount.Text = "Số tiền cọc (*)";
            // 
            // nudDeposit
            // 
            this.nudDeposit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudDeposit.Font = new System.Drawing.Font("Cambria", 12F);
            this.nudDeposit.Location = new System.Drawing.Point(30, 56);
            this.nudDeposit.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudDeposit.Name = "nudDeposit";
            this.nudDeposit.Size = new System.Drawing.Size(440, 34);
            this.nudDeposit.TabIndex = 5;
            this.nudDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudDeposit.ThousandsSeparator = true;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Italic);
            this.lblPercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblPercentage.Location = new System.Drawing.Point(27, 93);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(129, 20);
            this.lblPercentage.TabIndex = 4;
            this.lblPercentage.Text = "0.0% tổng hóa đơn";
            // 
            // lblCurrentTotal
            // 
            this.lblCurrentTotal.AutoSize = true;
            this.lblCurrentTotal.Font = new System.Drawing.Font("Cambria", 9F);
            this.lblCurrentTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblCurrentTotal.Location = new System.Drawing.Point(27, 120);
            this.lblCurrentTotal.Name = "lblCurrentTotal";
            this.lblCurrentTotal.Size = new System.Drawing.Size(152, 20);
            this.lblCurrentTotal.TabIndex = 3;
            this.lblCurrentTotal.Text = "Tổng hóa đơn: 0 VND";
            // 
            // lblMinDeposit
            // 
            this.lblMinDeposit.AutoSize = true;
            this.lblMinDeposit.Font = new System.Drawing.Font("Cambria", 9F);
            this.lblMinDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblMinDeposit.Location = new System.Drawing.Point(27, 145);
            this.lblMinDeposit.Name = "lblMinDeposit";
            this.lblMinDeposit.Size = new System.Drawing.Size(117, 20);
            this.lblMinDeposit.TabIndex = 2;
            this.lblMinDeposit.Text = "Tối thiểu: 0 VND";
            // 
            // lblMaxDeposit
            // 
            this.lblMaxDeposit.AutoSize = true;
            this.lblMaxDeposit.Font = new System.Drawing.Font("Cambria", 9F);
            this.lblMaxDeposit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblMaxDeposit.Location = new System.Drawing.Point(27, 170);
            this.lblMaxDeposit.Name = "lblMaxDeposit";
            this.lblMaxDeposit.Size = new System.Drawing.Size(101, 20);
            this.lblMaxDeposit.TabIndex = 1;
            this.lblMaxDeposit.Text = "Tối đa: 0 VND";
            // 
            // pnlQuickButtons
            // 
            this.pnlQuickButtons.Controls.Add(this.btnQuick30);
            this.pnlQuickButtons.Controls.Add(this.btnQuick50);
            this.pnlQuickButtons.Controls.Add(this.btnQuick70);
            this.pnlQuickButtons.Controls.Add(this.btnQuick100);
            this.pnlQuickButtons.Location = new System.Drawing.Point(30, 210);
            this.pnlQuickButtons.Name = "pnlQuickButtons";
            this.pnlQuickButtons.Size = new System.Drawing.Size(440, 56);
            this.pnlQuickButtons.TabIndex = 0;
            // 
            // btnQuick30
            // 
            this.btnQuick30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnQuick30.FlatAppearance.BorderSize = 0;
            this.btnQuick30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuick30.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuick30.ForeColor = System.Drawing.Color.White;
            this.btnQuick30.Location = new System.Drawing.Point(0, 10);
            this.btnQuick30.Name = "btnQuick30";
            this.btnQuick30.Size = new System.Drawing.Size(100, 35);
            this.btnQuick30.TabIndex = 0;
            this.btnQuick30.Text = "30%";
            this.btnQuick30.UseVisualStyleBackColor = false;
            // 
            // btnQuick50
            // 
            this.btnQuick50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnQuick50.FlatAppearance.BorderSize = 0;
            this.btnQuick50.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuick50.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuick50.ForeColor = System.Drawing.Color.White;
            this.btnQuick50.Location = new System.Drawing.Point(115, 10);
            this.btnQuick50.Name = "btnQuick50";
            this.btnQuick50.Size = new System.Drawing.Size(100, 35);
            this.btnQuick50.TabIndex = 1;
            this.btnQuick50.Text = "50%";
            this.btnQuick50.UseVisualStyleBackColor = false;
            // 
            // btnQuick70
            // 
            this.btnQuick70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnQuick70.FlatAppearance.BorderSize = 0;
            this.btnQuick70.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuick70.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuick70.ForeColor = System.Drawing.Color.White;
            this.btnQuick70.Location = new System.Drawing.Point(230, 10);
            this.btnQuick70.Name = "btnQuick70";
            this.btnQuick70.Size = new System.Drawing.Size(100, 35);
            this.btnQuick70.TabIndex = 2;
            this.btnQuick70.Text = "70%";
            this.btnQuick70.UseVisualStyleBackColor = false;
            // 
            // btnQuick100
            // 
            this.btnQuick100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnQuick100.FlatAppearance.BorderSize = 0;
            this.btnQuick100.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuick100.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold);
            this.btnQuick100.ForeColor = System.Drawing.Color.White;
            this.btnQuick100.Location = new System.Drawing.Point(340, 10);
            this.btnQuick100.Name = "btnQuick100";
            this.btnQuick100.Size = new System.Drawing.Size(100, 35);
            this.btnQuick100.TabIndex = 3;
            this.btnQuick100.Text = "100%";
            this.btnQuick100.UseVisualStyleBackColor = false;
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlActions.Controls.Add(this.btnCancel);
            this.pnlActions.Controls.Add(this.btnConfirm);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Location = new System.Drawing.Point(0, 400);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Padding = new System.Windows.Forms.Padding(20);
            this.pnlActions.Size = new System.Drawing.Size(543, 100);
            this.pnlActions.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(260, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(390, 20);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(120, 45);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "XÁC NHẬN";
            this.btnConfirm.UseVisualStyleBackColor = false;
            // 
            // frmDeposit
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(543, 500);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlActions);
            this.Font = new System.Drawing.Font("Cambria", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeposit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập Tiền Cọc - Luxury Resort";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeposit)).EndInit();
            this.pnlQuickButtons.ResumeLayout(false);
            this.pnlActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
    }
}
