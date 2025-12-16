using System;
using System.Windows.Forms;
using QLResort.GUI.Styles;

namespace QLResort.GUI
{
    public partial class AppBaseForm : Form
    {
        public AppBaseForm()
        {
        }
        protected override void OnLoad(EventArgs e)
        {
            if (!DesignMode)
            {
                AppTheme.ApplyForm(this);
            }
            base.OnLoad(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AppBaseForm
            // 
            this.ClientSize = new System.Drawing.Size(786, 404);
            this.Name = "AppBaseForm";
            this.ResumeLayout(false);

        }
    }
}
