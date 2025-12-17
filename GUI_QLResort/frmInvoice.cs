using BUS_QLResort;
using ET_QLResort;
using DAL_QLResort.Guest_F;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_QLResort
{
    public partial class frmInvoice : AppBaseForm
    {
        private readonly InvoiceBUS invoiceBUS = new InvoiceBUS();
        private readonly GuestDAL guestDAL = new GuestDAL();
        private string selectedMaHD = null;

        public frmInvoice()
        {
            InitializeComponent();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {

            LoadInvoices();
            LoadTrangThai();
            ResetForm();
        }



        private void LoadTrangThai()
        {
            cbTrangThai.Items.Clear();
            cbTrangThai.Items.Add("Tất cả");
            cbTrangThai.Items.Add("Chưa TT");
            cbTrangThai.Items.Add("Đã TT");
            cbTrangThai.Items.Add("Hủy");
            cbTrangThai.SelectedIndex = 0;

            cbTrangThaiFil.Items.Clear();
            cbTrangThaiFil.Items.Add("Tất cả");
            cbTrangThaiFil.Items.Add("Chưa TT");
            cbTrangThaiFil.Items.Add("Đã TT");
            cbTrangThaiFil.Items.Add("Hủy");
            cbTrangThaiFil.SelectedIndex = 0;
        }

        private void LoadInvoices()
        {
            lvInvoices.Items.Clear();
            string trangThai = cbTrangThaiFil.SelectedItem?.ToString();
            var result = invoiceBUS.GetInvoices(maCN: Session_Now.CurrentResort, trangThai: trangThai == "Tất cả" ? null : trangThai);

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var inv in result.Data)
            {
                // Xác định loại hóa đơn và mã liên kết
                string loaiHoaDon = inv.LoaiHoaDon == "SuKien" ? "Sự kiện" : "Đặt phòng";
                string maLienKet = inv.LoaiHoaDon == "SuKien" ? (inv.MaCTSK ?? "") : (inv.MaDP ?? "");

                ListViewItem item = new ListViewItem(inv.MaHD);
                item.SubItems.Add(loaiHoaDon); // Cột Loại
                item.SubItems.Add(maLienKet); // Cột Mã liên kết (MaDP hoặc MaCTSK)
                item.SubItems.Add(inv.MaKH ?? "");
                item.SubItems.Add(inv.NgayLap?.ToString("dd/MM/yyyy HH:mm") ?? "");
                item.SubItems.Add(inv.TongTruocKM?.ToString("N0") ?? "0");
                item.SubItems.Add(inv.TongTien?.ToString("N0") ?? "0");
                item.SubItems.Add(inv.TrangThai ?? "");
                item.SubItems.Add(inv.MaKM ?? "");
                item.Tag = inv;
                lvInvoices.Items.Add(item);
            }
        }

        private void LoadInvoiceDetails(string maHD)
        {
            lvDetails.Items.Clear();
            var result = invoiceBUS.GetInvoiceDetails(maHD);
            if (result.Success)
            {
                foreach (var detail in result.Data)
                {
                    ListViewItem item = new ListViewItem(detail.MaCTHD);
                    item.SubItems.Add(detail.MoTa ?? "");
                    item.SubItems.Add(detail.SoLuong?.ToString() ?? "0");
                    item.SubItems.Add(detail.DonGia?.ToString("N0") ?? "0");
                    item.SubItems.Add(detail.ThanhTien?.ToString("N0") ?? "0");
                    item.Tag = detail;
                    lvDetails.Items.Add(item);
                }
            }
        }

        private void ResetForm()
        {
            selectedMaHD = null;
            txtMaHD.Clear();
            txtMaDP.Clear();
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtMaKM.Clear();
            txtTongTruocKM.Clear();
            txtTongTien.Clear();
            if (cbTrangThaiFil.Items.Count > 0) cbTrangThaiFil.SelectedIndex = 0;
            lvDetails.Items.Clear();
            btnSua.Enabled = false;
        }

        private void lvInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvInvoices.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem item = lvInvoices.SelectedItems[0];
            if (item.Tag is Invoice inv)
            {
                selectedMaHD = inv.MaHD;
                txtMaHD.Text = inv.MaHD;
                txtMaDP.Text = inv.MaDP ?? "";
                txtMaKH.Text = inv.MaKH ?? "";
                txtMaKM.Text = inv.MaKM ?? "";
                txtTongTruocKM.Text = inv.TongTruocKM?.ToString("N0") ?? "0";
                txtTongTien.Text = inv.TongTien?.ToString("N0") ?? "0";

                // Load thông tin khách hàng
                var guestResult = guestDAL.GetGuest(maKH: inv.MaKH);
                if (guestResult.Success && guestResult.Data.Rows.Count > 0)
                {
                    var row = guestResult.Data.Rows[0];
                    txtTenKH.Text = row["HoTen"]?.ToString() ?? "";
                }

                // Select trạng thái
                cbTrangThai.SelectedItem = inv.TrangThai;           
                LoadInvoiceDetails(inv.MaHD);
                btnSua.Enabled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaHD))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var invoices = invoiceBUS.GetInvoices(maHD: selectedMaHD);
            if (!invoices.Success || invoices.Data.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var invoice = invoices.Data[0];
            invoice.TrangThai = cbTrangThaiFil.SelectedItem?.ToString();

            var result = invoiceBUS.UpdateInvoice(invoice);
            if (result.Success)
            {
                MessageBox.Show("Cập nhật hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoices();
                ResetForm();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}


