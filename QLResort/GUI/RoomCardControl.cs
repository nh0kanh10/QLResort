using QLResort.Core.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class RoomCardControl : UserControl
    {
        private Room _room;

        public event EventHandler<Room> RoomClicked;
        public event EventHandler<Room> RoomRightClicked;

        public RoomCardControl()
        {
            InitializeComponent();
            RegisterMouseEvents(this);
        }

        public void SetData(Room room)
        {
            _room = room;
            lblRoomNumber.Text = room.SoPhong;
            lblRoomType.Text = room.TenLoaiPhong;
            lblStatus.Text = room.TrangThai;
            lblLocation.Text = room.ViTri;

            SetStatusColor(room.TrangThai);
        }

        private void SetStatusColor(string st)
        {
            Color c = Color.Gray;
            if (string.IsNullOrEmpty(st)) st = "Khác";

            switch (st.ToLower())
            {
                case "trống": c = Color.LimeGreen; break;
                case "đang sử dụng":
                case "đã đặt": c = Color.Red; break;
                case "bảo trì":
                case "đang dọn": c = Color.Orange; break;
            }

            lblStatus.ForeColor = c;
        }

        private void RegisterMouseEvents(Control control)
        {
            control.Click += OnCardClick;
            control.MouseDown += OnCardMouseDown;
            control.MouseEnter += (s, e) => Cursor = Cursors.Hand;
            control.MouseLeave += (s, e) => Cursor = Cursors.Default;

            foreach (Control c in control.Controls)
                RegisterMouseEvents(c);
        }

        private void OnCardClick(object sender, EventArgs e)
        {
            if (_room != null)
                RoomClicked?.Invoke(this, _room);
        }

        private void OnCardMouseDown(object sender, MouseEventArgs e)
        {
            if (_room == null) return;

            // CHUỘT PHẢI —> mở context menu
            if (e.Button == MouseButtons.Right)
                RoomRightClicked?.Invoke(this, _room);
        }
    }
}
