using QLResort.Core;
using QLResort.GUI;
using QLResort.GUI.Employee;
using QLResort.GUI.Guest;
using QLResort.GUI.Resort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLResort
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Hiển thị form đăng nhập
            using (var loginForm = new QLResort.GUI.frmLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Đăng nhập thành công, mở form chính
                    Application.Run(new QLResort.GUI.frmMain());
                }
                else
                {
                    // Người dùng hủy đăng nhập
                    Application.Exit();
                }
            }
        }
    }
}
