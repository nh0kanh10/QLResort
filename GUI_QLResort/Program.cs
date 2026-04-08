using System;
using System.Windows.Forms;

namespace GUI_QLResort
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            using (var loginForm = new frmLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmMain());
                }
            }
        }
    }
}
