using QLResort.BUS;
using QLResort.Core.Model;
using QLResort.DAL.Resort_F;
using QLResort.DAL.RoomTypeDAL;
using QLResort.GUI.Styles;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmRoom : Form
    {
        private readonly RoomBUS roomBUS = new RoomBUS();
        private readonly RoomImageBUS roomImageBUS = new RoomImageBUS();
        private readonly ResortDAL resortDAL = new ResortDAL();
        private readonly RoomTypeDAL roomTypeDAL = new RoomTypeDAL();
        private string selectedMaPhong = null;
        private string currentImagePath = null;
        private string imagesFolder = Path.Combine(Application.StartupPath, "Images", "Rooms");

        public frmRoom()
        {
            InitializeComponent();
        }

        private void frmRoom_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            // Tạo thư mục Images nếu chưa có
            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);

            LoadRooms();
            LoadResorts();
            LoadRoomTypes();
            LoadTrangThai();
            ResetForm();
        }

        private void ApplyTheme()
        {
            AppTheme.ApplyForm(this);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt) AppTheme.StyleTextBox(txt);
                else if (ctrl is ComboBox cb) AppTheme.StyleComboBox(cb);
                else if (ctrl is DateTimePicker dtp) AppTheme.StyleDateTimePicker(dtp);
                else if (ctrl is Label lbl) AppTheme.StyleLabel(lbl);
                else if (ctrl is Button btn) AppTheme.StylePrimaryButton(btn);
            }
        }

        private void LoadResorts()
        {
            cbMaCN.Items.Clear();
            var result = resortDAL.GetResort(isActive: true);
            if (result.Success)
            {
                foreach (System.Data.DataRow row in result.Data.Rows)
                {
                    cbMaCN.Items.Add(new { MaCN = row["MaCN"].ToString(), TenCN = row["TenCN"].ToString() });
                }
                cbMaCN.DisplayMember = "TenCN";
                cbMaCN.ValueMember = "MaCN";
            }
        }

        private void LoadRoomTypes()
        {
            cbMaLoaiPhong.Items.Clear();
            var result = roomTypeDAL.GetRoomTypes(isActive: true);
            if (result.Success)
            {
                foreach (System.Data.DataRow row in result.Data.Rows)
                {
                    cbMaLoaiPhong.Items.Add(new { MaLP = row["MaLP"].ToString(), TenLP = row["TenLP"].ToString() });
                }
                cbMaLoaiPhong.DisplayMember = "TenLP";
                cbMaLoaiPhong.ValueMember = "MaLP";
            }
        }

        private void LoadTrangThai()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Trống");
            cbTrangThai.Items.Add("Đã đặt");
            cbTrangThai.Items.Add("Bảo trì");
            cbTrangThai.Items.Add("Ngưng hoạt động");
            cbTrangThai.SelectedIndex = 0;
        }

        private void LoadRooms()
        {
            lvRooms.Items.Clear();
            var result = roomBUS.GetRooms(isActive: null);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var room in result.Data)
            {
                ListViewItem item = new ListViewItem(room.MaPhong);
                item.SubItems.Add(room.SoPhong ?? "");
                item.SubItems.Add(room.MaCN ?? "");
                item.SubItems.Add(room.MaLP ?? "");
                item.SubItems.Add(room.ViTri ?? "");
                item.SubItems.Add(room.TrangThai ?? "Trống");
                item.SubItems.Add(room.IsActive ? "✓" : "✗");
                item.Tag = room;
                lvRooms.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            selectedMaPhong = null;
            currentImagePath = null;
            txtMaPhong.Clear();
            txtSoPhong.Clear();
            txtViTri.Clear();
            txtGhiChu.Clear();
            cbIsActive.Checked = true;
            if (cbMaCN.Items.Count > 0) cbMaCN.SelectedIndex = 0;
            if (cbMaLoaiPhong.Items.Count > 0) cbMaLoaiPhong.SelectedIndex = 0;
            if (cbTrangThai.Items.Count > 0) cbTrangThai.SelectedIndex = 0;
            pbRoomImage.Image = null;
            btnDeleteImage.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (cbMaCN.SelectedItem == null)
            {
                errorProvider1.SetError(cbMaCN, "Vui lòng chọn chi nhánh");
                isValid = false;
            }

            if (cbMaLoaiPhong.SelectedItem == null)
            {
                errorProvider1.SetError(cbMaLoaiPhong, "Vui lòng chọn loại phòng");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                errorProvider1.SetError(txtSoPhong, "Số phòng không được để trống");
                isValid = false;
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            dynamic selectedCN = cbMaCN.SelectedItem;
            dynamic selectedLP = cbMaLoaiPhong.SelectedItem;

            var result = roomBUS.AddRoom(
                selectedCN.MaCN,
                selectedLP.MaLP,
                txtSoPhong.Text.Trim(),
                txtViTri.Text.Trim(),
                cbTrangThai.SelectedItem?.ToString(),
                txtGhiChu.Text.Trim(),
                cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRooms();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            dynamic selectedCN = cbMaCN.SelectedItem;
            dynamic selectedLP = cbMaLoaiPhong.SelectedItem;

            var result = roomBUS.UpdateRoom(
                selectedMaPhong,
                selectedCN.MaCN,
                selectedLP.MaLP,
                txtSoPhong.Text.Trim(),
                txtViTri.Text.Trim(),
                cbTrangThai.SelectedItem?.ToString(),
                txtGhiChu.Text.Trim(),
                cbIsActive.Checked);

            if (result.Success)
            {
                MessageBox.Show("Cập nhật phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRooms();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa phòng này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var result = roomBUS.DeleteRoom(selectedMaPhong);
                if (result.Success)
                {
                    MessageBox.Show("Xóa phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lvRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRooms.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvRooms.SelectedItems[0];
            if (item.Tag is Room room)
            {
                selectedMaPhong = room.MaPhong;
                txtMaPhong.Text = room.MaPhong;
                txtSoPhong.Text = room.SoPhong ?? "";
                txtViTri.Text = room.ViTri ?? "";
                txtGhiChu.Text = room.GhiChu ?? "";
                cbIsActive.Checked = room.IsActive;

                // Chọn chi nhánh
                for (int i = 0; i < cbMaCN.Items.Count; i++)
                {
                    dynamic cn = cbMaCN.Items[i];
                    if (cn.MaCN == room.MaCN)
                    {
                        cbMaCN.SelectedIndex = i;
                        break;
                    }
                }

                // Chọn loại phòng
                for (int i = 0; i < cbMaLoaiPhong.Items.Count; i++)
                {
                    dynamic lp = cbMaLoaiPhong.Items[i];
                    if (lp.MaLP == room.MaLP)
                    {
                        cbMaLoaiPhong.SelectedIndex = i;
                        break;
                    }
                }

                // Chọn trạng thái
                for (int i = 0; i < cbTrangThai.Items.Count; i++)
                {
                    if (cbTrangThai.Items[i].ToString() == room.TrangThai)
                    {
                        cbTrangThai.SelectedIndex = i;
                        break;
                    }
                }

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                // Load ảnh phòng
                LoadRoomImage(room.MaPhong);
            }
        }

        private void LoadRoomImage(string maPhong)
        {
            if (string.IsNullOrEmpty(maPhong))
            {
                pbRoomImage.Image = null;
                btnDeleteImage.Enabled = false;
                return;
            }

            var result = roomImageBUS.GetRoomImages(maPhong: maPhong, isActive: true);
            if (result.Success && result.Data.Count > 0)
            {
                string imagePath = result.Data[0].DuongDan;
                if (File.Exists(imagePath))
                {
                    try
                    {
                        pbRoomImage.Image = System.Drawing.Image.FromFile(imagePath);
                        currentImagePath = imagePath;
                        btnDeleteImage.Enabled = true;
                    }
                    catch
                    {
                        pbRoomImage.Image = null;
                        btnDeleteImage.Enabled = false;
                    }
                }
                else
                {
                    pbRoomImage.Image = null;
                    btnDeleteImage.Enabled = false;
                }
            }
            else
            {
                pbRoomImage.Image = null;
                btnDeleteImage.Enabled = false;
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng trước khi thêm ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                ofd.Title = "Chọn ảnh phòng";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Copy ảnh vào thư mục Images/Rooms
                        string fileName = $"{selectedMaPhong}_{DateTime.Now:yyyyMMddHHmmss}{Path.GetExtension(ofd.FileName)}";
                        string destPath = Path.Combine(imagesFolder, fileName);

                        File.Copy(ofd.FileName, destPath, true);

                        // Lưu vào database
                        var result = roomImageBUS.AddRoomImage(selectedMaPhong, destPath);
                        if (result.Success)
                        {
                            pbRoomImage.Image = System.Drawing.Image.FromFile(destPath);
                            currentImagePath = destPath;
                            btnDeleteImage.Enabled = true;
                            MessageBox.Show("Thêm ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (File.Exists(destPath))
                                File.Delete(destPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi thêm ảnh: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa ảnh này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var images = roomImageBUS.GetRoomImages(maPhong: selectedMaPhong);
                if (images.Success && images.Data.Count > 0)
                {
                    foreach (var img in images.Data)
                    {
                        var result = roomImageBUS.DeleteRoomImage(img.MaAnh);
                        if (result.Success && File.Exists(img.DuongDan))
                        {
                            try
                            {
                                File.Delete(img.DuongDan);
                            }
                            catch { }
                        }
                    }
                }

                pbRoomImage.Image = null;
                currentImagePath = null;
                btnDeleteImage.Enabled = false;
                MessageBox.Show("Xóa ảnh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}

