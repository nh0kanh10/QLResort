using QLResort.BUS;
using QLResort.Core.Model;
using QLResort.DAL.PaymentDAL;
using QLResort.DAL.InvoiceDAL;
using QLResort.DAL.Guest_F;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QLResort.GUI
{
    public partial class frmPayment : AppBaseForm
    {
        private readonly PaymentBUS paymentBUS = new PaymentBUS();
        private readonly PaymentTypeBUS paymentTypeBUS = new PaymentTypeBUS();
        private readonly InvoiceBUS invoiceBUS = new InvoiceBUS();
        private readonly PromotionBUS promotionBUS = new PromotionBUS();
        private readonly GuestDAL guestDAL = new GuestDAL();
        private string selectedMaHD = null;
        private decimal tongTienHD = 0;
        private decimal daThanhToan = 0;
        private string _preselectedMaHD = null; // Để truyền từ bên ngoài

        public frmPayment()
        {
            InitializeComponent();
        }

        public frmPayment(string maHD) : this()
        {
            _preselectedMaHD = maHD;
        }

        private void frmPayment_Load(object sender, EventArgs e)
        {
            SetupListViews(); // ADDED: Setup columns
            LoadInvoices();
            LoadPaymentTypes();
            ResetForm();
            ApplyPaymentTheme();
            
            // Nếu có maHD được truyền vào, tự động chọn
            if (!string.IsNullOrEmpty(_preselectedMaHD))
            {
                foreach (ListViewItem item in lvInvoices.Items)
                {
                    if (item.Text == _preselectedMaHD)
                    {
                        item.Selected = true;
                        lvInvoices_SelectedIndexChanged(null, null);
                        break;
                    }
                }
            }
        }


        private void LoadInvoices()
        {
            lvInvoices.Items.Clear();
            var result = invoiceBUS.GetInvoices(maCN: Session_Now.CurrentResort, trangThai: "Chưa TT");

            if (!result.Success)
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (var inv in result.Data)
            {
                ListViewItem item = new ListViewItem(inv.MaHD);
                item.SubItems.Add(inv.MaKH ?? "");
                item.SubItems.Add(inv.NgayLap?.ToString("dd/MM/yyyy") ?? "");
                item.SubItems.Add(inv.TongTruocKM?.ToString("N0") ?? "0");
                item.SubItems.Add(inv.TongTien?.ToString("N0") ?? "0");
                item.SubItems.Add(inv.TrangThai ?? "");
                item.Tag = inv;
                lvInvoices.Items.Add(item);
            }
        }

        private void LoadPaymentTypes()
        {
            cbLoaiTT.Items.Clear();
            var result = paymentTypeBUS.GetPaymentTypes(isActive: true);
            if (result.Success)
            {
                foreach (var pt in result.Data)
                {
                    cbLoaiTT.Items.Add(new { MaLTT = pt.MaLTT, TenLTT = pt.TenLTT });
                }
                cbLoaiTT.DisplayMember = "TenLTT";
                cbLoaiTT.ValueMember = "MaLTT";
                if (cbLoaiTT.Items.Count > 0) cbLoaiTT.SelectedIndex = 0;
            }
        }

        private void LoadPaymentsForInvoice(string maHD)
        {
            lvPayments.Items.Clear();
            var result = paymentBUS.GetPayments(maHD: maHD, isActive: true);
            if (result.Success)
            {
                daThanhToan = 0;
                foreach (var payment in result.Data)
                {
                    ListViewItem item = new ListViewItem(payment.MaTT);
                    item.SubItems.Add(payment.NgayTT?.ToString("dd/MM/yyyy HH:mm") ?? "");
                    item.SubItems.Add(payment.SoTien?.ToString("N0") ?? "0");
                    item.SubItems.Add(payment.MaLTT ?? "");
                    item.Tag = payment;
                    lvPayments.Items.Add(item);
                    daThanhToan += payment.SoTien ?? 0;
                }
                UpdatePaymentSummary();
            }
        }

        private void UpdatePaymentSummary()
        {
            decimal conLai = tongTienHD - daThanhToan;
            if (lblTongTienSummary != null)
                lblTongTienSummary.Text = $"Tổng tiền: {tongTienHD:N0} VNĐ";
            if (lblDaThanhToan != null)
                lblDaThanhToan.Text = $"Đã thanh toán: {daThanhToan:N0} VNĐ";
            if (lblConLai != null)
            {
                lblConLai.Text = $"Còn lại: {conLai:N0} VNĐ";
                if (conLai <= 0)
                {
                    btnThanhToan.Enabled = true;
                    btnThanhToan.Text = "Hoàn tất";
                    lblConLai.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    btnThanhToan.Enabled = true;
                    btnThanhToan.Text = "Thanh toán"; // Reset text
                    lblConLai.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void SetupListViews()
        {
            // Setup lvInvoices
            lvInvoices.Columns.Clear();
            lvInvoices.Columns.Add("Mã HĐ", 100);
            lvInvoices.Columns.Add("Mã KH", 100);
            lvInvoices.Columns.Add("Ngày Lập", 100);
            lvInvoices.Columns.Add("Tổng Trước KM", 120);
            lvInvoices.Columns.Add("Tổng Tiền", 120);
            lvInvoices.Columns.Add("Trạng Thái", 100);

            // Setup lvPayments
            lvPayments.Columns.Clear();
            lvPayments.Columns.Add("Mã TT", 80);
            lvPayments.Columns.Add("Ngày TT", 120);
            lvPayments.Columns.Add("Số Tiền", 100);
            lvPayments.Columns.Add("Loại TT", 100);
        }

        private void ResetForm()
        {
            selectedMaHD = null;
            tongTienHD = 0;
            daThanhToan = 0;
            txtMaHD.Clear();
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtCouponCode.Clear();
            txtGiamGia.Clear();
            txtTongTruocKM.Clear();
            txtTongTien.Clear();
            txtSoTien.Text = "0";
            dtpNgayTT.Value = DateTime.Now;
            lvPayments.Items.Clear();
            if (cbLoaiTT.Items.Count > 0) cbLoaiTT.SelectedIndex = 0;
            if (lblTongTienSummary != null) lblTongTienSummary.Text = "Tổng tiền: 0 VNĐ";
            if (lblDaThanhToan != null) lblDaThanhToan.Text = "Đã thanh toán: 0 VNĐ";
            if (lblConLai != null) lblConLai.Text = "Còn lại: 0 VNĐ";
            btnThanhToan.Enabled = false;
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
                txtMaKH.Text = inv.MaKH ?? "";

                // Load thông tin khách hàng
                var guestResult = guestDAL.GetGuest(maKH: inv.MaKH);
                if (guestResult.Success && guestResult.Data.Rows.Count > 0)
                {
                    var row = guestResult.Data.Rows[0];
                    txtTenKH.Text = row["HoTen"]?.ToString() ?? "";
                }

                tongTienHD = inv.TongTien ?? 0;
                txtTongTruocKM.Text = inv.TongTruocKM?.ToString("N0") ?? "0";
                txtTongTien.Text = tongTienHD.ToString("N0");

                if (inv.MaKM != null)
                {
                    var promResult = promotionBUS.GetPromotions(maKM: inv.MaKM);
                    if (promResult.Success && promResult.Data.Count > 0)
                    {
                        var prom = promResult.Data[0];
                        txtCouponCode.Text = prom.CouponCode ?? "";
                        decimal giamGia = (inv.TongTruocKM ?? 0) - (inv.TongTien ?? 0);
                        txtGiamGia.Text = giamGia.ToString("N0");
                    }
                }

                LoadPaymentsForInvoice(inv.MaHD);
                decimal conLai = tongTienHD - daThanhToan;

                // Gán giá trị còn lại vào TextBox (nếu còn nợ)
                txtSoTien.Text = conLai > 0 ? conLai.ToString("N0") : "0";
            }
        }

        private void btnApDungKM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaHD))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCouponCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã coupon!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin hóa đơn và khách hàng
            var invoices = invoiceBUS.GetInvoices(maHD: selectedMaHD);
            if (!invoices.Success || invoices.Data.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var invoice = invoices.Data[0];
            var guestResult = guestDAL.GetGuest(maKH: invoice.MaKH);
            string maLKH = null;
            if (guestResult.Success && guestResult.Data.Rows.Count > 0)
            {
                maLKH = guestResult.Data.Rows[0]["MaLKH"]?.ToString();
            }

            // Kiểm tra khuyến mãi
            var promResult = promotionBUS.GetPromotionByCode(txtCouponCode.Text.Trim(), Session_Now.CurrentResort, maLKH);
            if (!promResult.Success)
            {
                MessageBox.Show(promResult.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var promotion = promResult.Data;
            decimal giamGia = promotionBUS.CalculateDiscount(promotion, invoice.TongTruocKM ?? 0, 
                Session_Now.CurrentResort, maLKH, null, null);
            
            if (giamGia > 0)
            {
                decimal tongTienMoi = (invoice.TongTruocKM ?? 0) - giamGia;
                if (tongTienMoi < 0) tongTienMoi = 0;

                // Cập nhật hóa đơn
                invoice.MaKM = promotion.MaKM;
                invoice.TongTien = tongTienMoi;

                var updateResult = invoiceBUS.UpdateInvoice(invoice);
                if (updateResult.Success)
                {
                    txtGiamGia.Text = giamGia.ToString("N0");
                    tongTienHD = tongTienMoi;
                    txtTongTien.Text = tongTienHD.ToString("N0");
                    LoadPaymentsForInvoice(selectedMaHD);
                    MessageBox.Show($"Áp dụng khuyến mãi thành công! Giảm: {giamGia:N0} VNĐ", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(updateResult.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Khuyến mãi không áp dụng được cho hóa đơn này!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Trong frmPayment.cs

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedMaHD))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal conLai = tongTienHD - daThanhToan;

            // FIX: Cho phép đóng form nếu đã thanh toán đủ
            if (conLai <= 0)
            {
                // Ensure status is updated even if no new payment is made
                if (daThanhToan >= tongTienHD - 1000)
                {
                    invoiceBUS.UpdateInvoiceStatus(selectedMaHD, "Đã TT");
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // Validations
            if (!decimal.TryParse(txtSoTien.Text.Replace(",", "").Replace(".", ""), out decimal soTien) || soTien <= 0)
            {
                MessageBox.Show("Số tiền thanh toán không hợp lệ hoặc phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Focus();
                return;
            }

            if (cbLoaiTT.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check overflow
            if (soTien > conLai + 1000) // Cho phép sai số nhỏ 1000đ
            {
                 MessageBox.Show($"Số tiền thanh toán không được vượt quá số tiền còn lại ({conLai:N0} VNĐ)!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic selectedLTT = cbLoaiTT.SelectedItem;

            // Thực hiện thanh toán
            var result = paymentBUS.AddPayment(selectedMaHD, soTien, selectedLTT.MaLTT, dtpNgayTT.Value);
            if (result.Success)
            {
                daThanhToan += soTien;
                LoadPaymentsForInvoice(selectedMaHD);

                // Cập nhật trạng thái hóa đơn nếu đã thanh toán hết
                if (daThanhToan >= tongTienHD - 1000) // Sai số nhỏ
                {
                    invoiceBUS.UpdateInvoiceStatus(selectedMaHD, "Đã TT");
                    LoadInvoices(); // Refresh list
                    
                    MessageBox.Show("Thanh toán hoàn tất! Hóa đơn đã được cập nhật trạng thái 'Đã TT'.", 
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset input
                    txtSoTien.Text = "0";
                    UpdatePaymentSummary();
                }
            }
            else
            {
                MessageBox.Show(result.ErrorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm hàm này vào frmPayment.cs
        private void TxtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số, Backspace, và dấu phân cách thập phân/hàng nghìn
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Chỉ cho phép một dấu phân cách
            if ((e.KeyChar == '.' || e.KeyChar == ',') && ((sender as TextBox).Text.Contains(".") || (sender as TextBox).Text.Contains(",")))
            {
                e.Handled = true;
            }
        }

        // Bổ sung vào frmPayment() hoặc InitializeComponent()
        // txtSoTien.KeyPress += TxtSoTien_KeyPress;

        private void lblDaThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void cbLoaiTT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayTT_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblTongTienSummary_Click(object sender, EventArgs e)
        {

        }

        private void lblConLai_Click(object sender, EventArgs e)
        {

        }
    }
}

