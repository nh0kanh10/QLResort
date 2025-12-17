using BUS_QLResort;
using ET_QLResort;
using DAL_QLResort.PaymentDAL;
using DAL_QLResort.InvoiceDAL;
using DAL_QLResort.Guest_F;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI_QLResort
{
    public partial class frmPayment : AppBaseForm
    {
        private readonly PaymentBUS paymentBUS = new PaymentBUS();
        private readonly PaymentTypeBUS paymentTypeBUS = new PaymentTypeBUS();
        private readonly InvoiceBUS invoiceBUS = new InvoiceBUS();
        private readonly PromotionBUS promotionBUS = new PromotionBUS();
        private readonly GuestDAL guestDAL = new GuestDAL();
        private readonly BookingBUS bookingBUS = new BookingBUS();
        private readonly BookingDetailBUS bookingDetailBUS = new BookingDetailBUS();
        private readonly RoomBUS roomBUS = new RoomBUS();
        private readonly GuestPointBUS guestPointBUS = new GuestPointBUS();
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
                // [FIX] Cập nhật Booking, Phòng, Điểm ngay sau khi thanh toán xong
                UpdateBookingAndRoomStatus(selectedMaHD, tongTienHD);
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
                    
                    // [FIX] Cập nhật Booking, Phòng, Điểm ngay sau khi thanh toán xong (Rule 3.A)
                    UpdateBookingAndRoomStatus(selectedMaHD, tongTienHD);

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

        private void UpdateBookingAndRoomStatus(string maHD, decimal totalAmount)
        {
            try
            {
                // 1. Lấy thông tin Hóa đơn
                var invoiceResult = invoiceBUS.GetInvoices(maHD: maHD);
                if (!invoiceResult.Success || invoiceResult.Data.Count == 0) return;
                var invoice = invoiceResult.Data[0];
                string maDP = invoice.MaDP;
                string maCTSK = invoice.MaCTSK; // Lấy mã chi tiết sự kiện
                string maKH = invoice.MaKH;

                // [LOGIC DAT PHONG]
                if (!string.IsNullOrEmpty(maDP)) 
                {
                    // 2. Cập nhật Booking -> "Hoàn tất"
                    bookingBUS.UpdateBooking(maDP, "Hoàn tất", "Đã thanh toán: " + maHD);

                    // 3. Lấy chi tiết đặt phòng
                    var detailsResult = bookingDetailBUS.GetBookingDetails(maDP: maDP);
                    if (detailsResult.Success)
                    {
                        foreach (var detail in detailsResult.Data)
                        {
                            // 4. Cập nhật từng chi tiết -> "Hoàn tất" & NgayDi = Now (trả sớm)
                            bookingDetailBUS.UpdateBookingDetail(
                                detail.MaCTDP, 
                                "Hoàn tất", 
                                detail.NgayDen, 
                                DateTime.Now, // Set Checkout Time
                                detail.NguoiLon, 
                                detail.TreEm, 
                                detail.GiaPhong, 
                                detail.ThanhTien
                            );

                            // 5. Cập nhật Phòng -> "Đang dọn" (Giải phóng phòng) (Rule 4A)
                            if (!string.IsNullOrEmpty(detail.MaPhong))
                            {
                                roomBUS.UpdateRoomStatus(detail.MaPhong, "Đang dọn");
                            }
                        }
                    }
                }
                
                // [LOGIC SU KIEN]
                if (!string.IsNullOrEmpty(maCTSK))
                {
                    var eventDetailBUS = new EventDetailBUS();
                    // Cập nhật trạng thái chi tiết sự kiện -> "Đã kết thúc" / "Hoàn tất"
                    // Đồng thời update DaThanhToan = TotalAmount (để logic nhất quán)
                    eventDetailBUS.UpdateEventDetail(
                        maCTSK, 
                        "Đã kết thúc", 
                        totalAmount // Update lại số tiền đã thanh toán thực tế
                    );
                }

                // 6. Cộng điểm tích lũy (10% giá trị tạo thành điểm, ví dụ 100k = 1 điểm, hoặc 10k = 1 điểm tùy chính sách)
                // Logic cũ: totalAmount / 10000 -> 10k = 1 điểm
                if (!string.IsNullOrEmpty(maKH))
                {
                    int points = (int)(totalAmount / 10000);
                    if (points > 0)
                    {
                        guestPointBUS.AddPoints(maKH, points, $"Tích điểm từ hóa đơn {maHD}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật trạng thái sau thanh toán: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

