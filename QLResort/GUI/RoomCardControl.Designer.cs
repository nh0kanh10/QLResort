using System.Drawing;
using System.Windows.Forms;

namespace QLResort.GUI
{
    partial class RoomCardControl
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlContainer;
        private Label lblRoomNumber;
        private Label lblRoomType;
        private Label lblStatus;
        private Label lBUSocation;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlContainer = new Panel();
            this.lBUSocation = new Label();
            this.lblStatus = new Label();
            this.lblRoomType = new Label();
            this.lblRoomNumber = new Label();

            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();

            // pnlContainer
            this.pnlContainer.BorderStyle = BorderStyle.FixedSingle;
            this.pnlContainer.Dock = DockStyle.Fill;
            this.pnlContainer.Controls.Add(this.lBUSocation);
            this.pnlContainer.Controls.Add(this.lblStatus);
            this.pnlContainer.Controls.Add(this.lblRoomType);
            this.pnlContainer.Controls.Add(this.lblRoomNumber);

            // lblRoomNumber
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblRoomNumber.Location = new Point(10, 10);

            // lblRoomType
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Location = new Point(10, 50);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblStatus.Location = new Point(10, 75);

            // lBUSocation
            this.lBUSocation.AutoSize = true;
            this.lBUSocation.Location = new Point(10, 105);

            // RoomCardControl
            this.Controls.Add(this.pnlContainer);
            this.BackColor = Color.White;
            this.Size = new Size(240, 150);

            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
