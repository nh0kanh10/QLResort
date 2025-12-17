using System;
using System.Windows.Forms;
using GUI_QLResort.Styles;

namespace GUI_QLResort
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
