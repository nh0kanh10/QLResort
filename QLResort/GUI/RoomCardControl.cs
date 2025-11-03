using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class RoomCardControl : UserControl
    {
        public string RoomNumber;
        public string Status;
        public string sTag;
        public RoomCardControl()
        {
            InitializeComponent();
        }

        private void RoomCardControl_Load(object sender, EventArgs e)
        {

        }
    }
}
