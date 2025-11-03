using QLResort.Core.Model;
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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void test_Load(object sender, EventArgs e)
        {
            List<Room> listRoomsFromDatabase = new List<Room>
            {
                new Room { MaPhong = "101", TrangThai = "Available", GhiChu = "Single" },
                new Room { MaPhong = "102", TrangThai = "Occupied", GhiChu = "Double" },
                new Room { MaPhong = "102", TrangThai = "Occupied", GhiChu = "Double" },
                new Room { MaPhong = "102", TrangThai = "Occupied", GhiChu = "Double" },
                new Room { MaPhong = "102", TrangThai = "Occupied", GhiChu = "Double" },
                new Room { MaPhong = "102", TrangThai = "Occupied", GhiChu = "Double" }


            };


            foreach (var roomData in listRoomsFromDatabase)
            {
                RoomCardControl roomCard = new RoomCardControl();
                roomCard.RoomNumber = roomData.MaPhong;
                roomCard.Status = roomData.TrangThai;
                roomCard.Tag = roomData.GhiChu;
                flp.Controls.Add(roomCard);
            }
        }
    }
}
