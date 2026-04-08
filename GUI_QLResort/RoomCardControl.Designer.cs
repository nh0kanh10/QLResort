using System.Drawing;
using System.Windows.Forms;

namespace GUI_QLResort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomCardControl));
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.lBUSocation = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.lblRoomNumber = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlContainer.BackgroundImage")));
            this.pnlContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContainer.Controls.Add(this.lBUSocation);
            this.pnlContainer.Controls.Add(this.lblStatus);
            this.pnlContainer.Controls.Add(this.lblRoomType);
            this.pnlContainer.Controls.Add(this.lblRoomNumber);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(240, 150);
            this.pnlContainer.TabIndex = 0;
            // 
            // lBUSocation
            // 
            this.lBUSocation.AutoSize = true;
            this.lBUSocation.Location = new System.Drawing.Point(10, 105);
            this.lBUSocation.Name = "lBUSocation";
            this.lBUSocation.Size = new System.Drawing.Size(0, 13);
            this.lBUSocation.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Palatino Linotype", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(10, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 19);
            this.lblStatus.TabIndex = 1;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Location = new System.Drawing.Point(10, 50);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(0, 13);
            this.lblRoomType.TabIndex = 2;
            // 
            // lblRoomNumber
            // 
            this.lblRoomNumber.AutoSize = true;
            this.lblRoomNumber.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold);
            this.lblRoomNumber.Location = new System.Drawing.Point(10, 10);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(0, 29);
            this.lblRoomNumber.TabIndex = 3;
            // 
            // RoomCardControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlContainer);
            this.Name = "RoomCardControl";
            this.Size = new System.Drawing.Size(240, 150);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
