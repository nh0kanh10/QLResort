using BUS_QLResort;
using ET_QLResort;
using DAL_QLResort.Resort_F;
using DAL_QLResort.RoomTypeDAL;
using DAL_QLResort.RoomDAL;
using DAL_QLResort.Guest_F;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_QLResort
{
    public partial class frmPromotion : AppBaseForm
    {
        private readonly PromotionBUS promotionBUS = new PromotionBUS();
        private readonly ResortDAL resortDAL = new ResortDAL();
        private readonly RoomTypeDAL roomTypeDAL = new RoomTypeDAL();
        private readonly RoomDAL roomDAL = new RoomDAL();
        private readonly GuestTypeDAL guestTypeDAL = new GuestTypeDAL();
        private string selectedMaKM = null;

        public frmPromotion()
        {
            InitializeComponent();
        }

        private void frmPromotion_Load(object sender, EventArgs e)
        {
            LoadPromotions();
            LoadResorts();
            LoadRoomTypes();
            LoadRooms();
            LoadGuestTypes();
            ResetForm();
        }

        private void LoadResorts()
        {
            cbMaCN.Items.Clear();
            var result = resortDAL.GetResort(isActive: true);
            if (result.Success)
            {
                cbMaCN.Items.Add(new { MaCN = "", TenCN = "-- Tất cả --" });
                foreach (System.Data.DataRow row in result.Data.Rows)
                {
                    cbMaCN.Items.Add(new { MaCN = row["MaCN"].ToString(), TenCN = row["TenCN"].ToString() });
                }
                cbMaCN.DisplayMember = "TenCN";
                cbMaCN.ValueMember = "MaCN";
                cbMaCN.SelectedIndex = 0;
            }
        }

        private void LoadRoomTypes()
        {
            cbMaLP.Items.Clear();
            var result = roomTypeDAL.GetRoomTypes(isActive: true);
            if (result.Success)
            {
                cbMaLP.Items.Add(new { MaLP = "", TenLP = "-- Tất cả --" });
                foreach (System.Data.DataRow row in result.Data.Rows)
                {
                    cbMaLP.Items.Add(new { MaLP = row["MaLP"].ToString(), TenLP = row["TenLP"].ToString() });
                }
                cbMaLP.DisplayMember = "TenLP";
                cbMaLP.ValueMember = "MaLP";
                cbMaLP.SelectedIndex = 0;
            }
        }

        private void LoadRooms()
        {
            cbMaPhong.Items.Clear();
            var result = roomDAL.GetRooms(isActive: true);
            if (result.Success)
            {
                cbMaPhong.Items.Add(new { MaPhong = "", SoPhong = "-- Tất cả --" });
                foreach (System.Data.DataRow row in result.Data.Rows)
                {
                    cbMaPhong.Items.Add(new { MaPhong = row["MaPhong"].ToString(), SoPhong = row["SoPhong"].ToString() });
                }
                cbMaPhong.DisplayMember = "SoPhong";
                cbMaPhong.ValueMember = "MaPhong";
                cbMaPhong.SelectedIndex = 0;
            }
        }

        private void LoadGuestTypes()
        {
            cbMaLKH.Items.Clear();
            var result = guestTypeDAL.GetGuestTypes(isActive: true);
            if (result.Success)
            {
                cbMaLKH.Items.Add(new { MaLKH = "", TenLKH = "-- Tất cả --" });
                foreach (System.Data.DataRow row in result.Data.Rows)
                {
                    cbMaLKH.Items.Add(new { MaLKH = row["MaLKH"].ToString(), TenLKH = row["TenLKH"].ToString() });
                }
                cbMaLKH.DisplayMember = "TenLKH";
                cbMaLKH.ValueMember = "MaLKH";
                cbMaLKH.SelectedIndex = 0;
            }
        }

        private void LoadPromotions()
        {
            lvPromotions.Items.Clear();
            var result = promotionBUS.GetPromotions(isActive: null);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var prom in result.Data)
            {
                ListViewItem item = new ListViewItem(prom.MaKM);
                item.SubItems.Add(prom.TenKM ?? "");
                item.SubItems.Add(prom.IsPhanTram ? "%" : "VNĐ");
                item.SubItems.Add(prom.GiaTri?.ToString("N0") ?? "0");
                item.SubItems.Add(prom.CouponCode ?? "");
                item.SubItems.Add(prom.NgayBD?.ToString("dd/MM/yyyy") ?? "");
                item.SubItems.Add(prom.NgayKT?.ToString("dd/MM/yyyy") ?? "");
                item.SubItems.Add(prom.IsActive ? "✓" : "✗");
                item.Tag = prom;
                lvPromotions.Items.Add(item);
            }
        }

        private void ResetForm()
        {
            selectedMaKM = null;
            txtMaKM.Clear();
            txtTenKM.Clear();
            rbPhanTram.Checked = true;
            txtGiaTri.Clear();
            txtCouponCode.Clear();
            dtpNgayBD.Value = DateTime.Now;
            dtpNgayKT.Value = DateTime.Now.AddDays(30);
            txtDieuKien.Clear();
            cbIsActive.Checked = true;
            if (cbMaCN.Items.Count > 0) cbMaCN.SelectedIndex = 0;
            if (cbMaLP.Items.Count > 0) cbMaLP.SelectedIndex = 0;
            if (cbMaPhong.Items.Count > 0) cbMaPhong.SelectedIndex = 0;
            if (cbMaLKH.Items.Count > 0) cbMaLKH.SelectedIndex = 0;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTenKM.Text))
            {
                errorProvider1.SetError(txtTenKM, "Tên khuyến mãi không được để trống");
                isValid = false;
            }

            if (!decimal.TryParse(txtGiaTri.Text, out decimal giaTri) || giaTri <= 0)
            {
                errorProvider1.SetError(txtGiaTri, "Giá trị khuyến mãi phải là số lớn hơn 0");
                isValid = false;
            }

            if (dtpNgayKT.Value < dtpNgayBD.Value)
            {
                errorProvider1.SetError(dtpNgayKT, "Ngày kết thúc phải sau ngày bắt đầu");
                isValid = false;
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            dynamic selectedCN = cbMaCN.SelectedItem;
            dynamic selectedLP = cbMaLP.SelectedItem;
            dynamic selectedPhong = cbMaPhong.SelectedItem;
            dynamic selectedLKH = cbMaLKH.SelectedItem;

            // Lấy giá trị an toàn từ anonymous type
            string maCN = selectedCN != null ? (selectedCN.MaCN == "" ? null : selectedCN.MaCN) : null;
            string maLP = selectedLP != null ? (selectedLP.MaLP == "" ? null : selectedLP.MaLP) : null;
            string maPhong = selectedPhong != null ? (selectedPhong.MaPhong == "" ? null : selectedPhong.MaPhong) : null;
            string maLKH = selectedLKH != null ? (selectedLKH.MaLKH == "" ? null : selectedLKH.MaLKH) : null;

            Promotion promotion = new Promotion
            {
                TenKM = txtTenKM.Text.Trim(),
                IsPhanTram = rbPhanTram.Checked,
                GiaTri = decimal.Parse(txtGiaTri.Text),
                CouponCode = string.IsNullOrWhiteSpace(txtCouponCode.Text) ? null : txtCouponCode.Text.Trim(),
                NgayBD = dtpNgayBD.Value,
                NgayKT = dtpNgayKT.Value,
                DieuKien = txtDieuKien.Text.Trim(),
                MaCN = maCN,
                MaLP = maLP,
                MaPhong = maPhong,
                MaLKH = maLKH,
                IsActive = cbIsActive.Checked
            };

            var result = promotionBUS.AddPromotion(promotion);

            if (result.Success)
            {
                MessageBox.Show("Thêm khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPromotions();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaKM))
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            dynamic selectedCN = cbMaCN.SelectedItem;
            dynamic selectedLP = cbMaLP.SelectedItem;
            dynamic selectedPhong = cbMaPhong.SelectedItem;
            dynamic selectedLKH = cbMaLKH.SelectedItem;

            // Lấy giá trị an toàn từ anonymous type
            string maCN = selectedCN != null ? (selectedCN.MaCN == "" ? null : selectedCN.MaCN) : null;
            string maLP = selectedLP != null ? (selectedLP.MaLP == "" ? null : selectedLP.MaLP) : null;
            string maPhong = selectedPhong != null ? (selectedPhong.MaPhong == "" ? null : selectedPhong.MaPhong) : null;
            string maLKH = selectedLKH != null ? (selectedLKH.MaLKH == "" ? null : selectedLKH.MaLKH) : null;

            Promotion promotion = new Promotion
            {
                MaKM = selectedMaKM,
                TenKM = txtTenKM.Text.Trim(),
                IsPhanTram = rbPhanTram.Checked,
                GiaTri = decimal.Parse(txtGiaTri.Text),
                CouponCode = string.IsNullOrWhiteSpace(txtCouponCode.Text) ? null : txtCouponCode.Text.Trim(),
                NgayBD = dtpNgayBD.Value,
                NgayKT = dtpNgayKT.Value,
                DieuKien = txtDieuKien.Text.Trim(),
                MaCN = maCN,
                MaLP = maLP,
                MaPhong = maPhong,
                MaLKH = maLKH,
                IsActive = cbIsActive.Checked
            };

            var result = promotionBUS.UpdatePromotion(promotion);

            if (result.Success)
            {
                MessageBox.Show("Cập nhật khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPromotions();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaKM))
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khuyến mãi này không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var result = promotionBUS.DeletePromotion(selectedMaKM);
                if (result.Success)
                {
                    MessageBox.Show("Xóa khuyến mãi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPromotions();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lvPromotions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPromotions.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvPromotions.SelectedItems[0];
            if (item.Tag is Promotion prom)
            {
                selectedMaKM = prom.MaKM;
                txtMaKM.Text = prom.MaKM;
                txtTenKM.Text = prom.TenKM ?? "";
                rbPhanTram.Checked = prom.IsPhanTram;
                rbTienMat.Checked = !prom.IsPhanTram;
                txtGiaTri.Text = prom.GiaTri?.ToString() ?? "";
                txtCouponCode.Text = prom.CouponCode ?? "";
                if (prom.NgayBD.HasValue) dtpNgayBD.Value = prom.NgayBD.Value;
                if (prom.NgayKT.HasValue) dtpNgayKT.Value = prom.NgayKT.Value;
                txtDieuKien.Text = prom.DieuKien ?? "";
                cbIsActive.Checked = prom.IsActive;

                // Select comboboxes
                SelectComboBox(cbMaCN, "MaCN", prom.MaCN);
                SelectComboBox(cbMaLP, "MaLP", prom.MaLP);
                SelectComboBox(cbMaPhong, "MaPhong", prom.MaPhong);
                SelectComboBox(cbMaLKH, "MaLKH", prom.MaLKH);

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void SelectComboBox(ComboBox cb, string propertyName, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                cb.SelectedIndex = 0;
                return;
            }

            for (int i = 0; i < cb.Items.Count; i++)
            {
                object item = cb.Items[i];
                var prop = item.GetType().GetProperty(propertyName);
                if (prop != null)
                {
                    var propValue = prop.GetValue(item)?.ToString();
                    if (propValue == value)
                    {
                        cb.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}


