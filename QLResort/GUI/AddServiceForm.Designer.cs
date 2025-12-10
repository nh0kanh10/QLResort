namespace QLResort.GUI
{
    partial class AddServiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Khai báo các Controls (Controls declarations)
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown nudQty;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblPrice;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Thiết lập Form (Form Setup)
            this.SuspendLayout();
            this.Text = "Thêm dịch vụ";
            this.ClientSize = new System.Drawing.Size(320, 160);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddServiceForm";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ResumeLayout(false);


            // Khởi tạo các Controls (Controls initialization, lấy từ BuildSimpleUI)
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.nudQty = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).BeginInit();


            // Cấu hình vị trí và thuộc tính (Positioning and property configuration)

            // lblName
            this.lblName.Left = 10;
            this.lblName.Top = 10;
            this.lblName.Text = "Tên dịch vụ:";

            // txtName
            this.txtName.Left = 110;
            this.txtName.Top = 8;
            this.txtName.Width = 190;

            // lblQty
            this.lblQty.Left = 10;
            this.lblQty.Top = 40;
            this.lblQty.Text = "Số lượng:";

            // nudQty
            this.nudQty.Left = 110;
            this.nudQty.Top = 38;
            this.nudQty.Width = 80;
            this.nudQty.Minimum = 1M; // Sử dụng M cho decimal (numeric up/down)
            this.nudQty.Maximum = 999M;
            this.nudQty.Value = 1M;

            // lblPrice
            this.lblPrice.Left = 10;
            this.lblPrice.Top = 70;
            this.lblPrice.Text = "Đơn giá:";

            // txtPrice
            this.txtPrice.Left = 110;
            this.txtPrice.Top = 68;
            this.txtPrice.Width = 120;
            this.txtPrice.Text = "0";

            // btnOk
            this.btnOk.Left = 110;
            this.btnOk.Top = 100;
            this.btnOk.Text = "OK";
            this.btnOk.Width = 80;
            // Gán sự kiện cho btnOk
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);

            // btnCancel
            this.btnCancel.Left = 200;
            this.btnCancel.Top = 100;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Width = 80;
            // Gán sự kiện cho btnCancel
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);


            // Thêm Controls vào Form (Add Controls to Form)
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblName, this.txtName, this.lblQty, this.nudQty,
                this.lblPrice, this.txtPrice, this.btnOk, this.btnCancel
            });

            ((System.ComponentModel.ISupportInitialize)(this.nudQty)).EndInit();
        }

        #endregion
    }
}
