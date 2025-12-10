using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.InvoiceDAL;
using QLResort.DAL.PromotionDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QLResort.BUS
{
    public class InvoiceBUS
    {
        private readonly InvoiceDAL invoiceDAL = new InvoiceDAL();
        private readonly PromotionDAL promotionDAL = new PromotionDAL();
        private readonly PromotionBUS promotionBUS = new PromotionBUS();

        public OperationResult<List<Invoice>> GetInvoices(string maHD = null, string maDP = null, string maCTSK = null, string loaiHoaDon = null, string maKH = null, string maCN = null, string trangThai = null, bool? isActive = null)
        {
            var dalResult = invoiceDAL.GetInvoices(maHD, maDP, maCTSK, loaiHoaDon, maKH, maCN, trangThai, isActive);

            if (!dalResult.Success)
                return OperationResult<List<Invoice>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<Invoice> list = new List<Invoice>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapInvoice(row));
                }
                return OperationResult<List<Invoice>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Invoice>>.Fail($"Lỗi khi xử lý dữ liệu hóa đơn: {ex.Message}");
            }
        }

        public OperationResult<Invoice> CreateInvoice(string maDP, string maKH, string maNV, string maCN, 
            decimal tongTruocKM, string couponCode = null, string maLKH = null, string maLP = null, string maPhong = null)
        {
            if (string.IsNullOrWhiteSpace(maDP))
                return OperationResult<Invoice>.Fail("Mã đặt phòng không được để trống");

            if (tongTruocKM <= 0)
                return OperationResult<Invoice>.Fail("Tổng tiền phải lớn hơn 0");

            string maHD = GenerateMaHD();
            string maKM = null;
            decimal giamGia = 0;
            decimal tongTien = tongTruocKM;

            // Áp dụng khuyến mãi nếu có
            if (!string.IsNullOrWhiteSpace(couponCode))
            {
                var promResult = promotionBUS.GetPromotionByCode(couponCode, maCN, maLKH);
                if (promResult.Success)
                {
                    var promotion = promResult.Data;
                    maKM = promotion.MaKM;
                    giamGia = promotionBUS.CalculateDiscount(promotion, tongTruocKM, maCN, maLKH, maLP, maPhong);
                    tongTien = tongTruocKM - giamGia;
                    if (tongTien < 0) tongTien = 0;
                }
            }

            Invoice invoice = new Invoice
            {
                MaHD = maHD,
                MaDP = maDP,
                MaKH = maKH,
                MaNV = maNV,
                MaKM = maKM,
                MaCN = maCN,
                TrangThai = "Chưa TT",
                NgayLap = DateTime.Now,
                TongTruocKM = tongTruocKM,
                TongTien = tongTien,
                IsActive = true,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now
            };

            var dalResult = invoiceDAL.Insert(invoice);
            if (!dalResult.Success)
                return OperationResult<Invoice>.Fail(dalResult.ErrorMessage);

            return OperationResult<Invoice>.Ok(invoice);
        }

        public OperationResult<bool> UpdateInvoice(Invoice invoice)
        {
            if (string.IsNullOrWhiteSpace(invoice.MaHD))
                return OperationResult<bool>.Fail("Mã hóa đơn không hợp lệ");

            invoice.UpdatedBy = Session_Now.CurrentUser;
            invoice.UpdatedAt = DateTime.Now;

            var dalResult = invoiceDAL.Update(invoice);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateInvoiceStatus(string maHD, string trangThai)
        {
            if (string.IsNullOrWhiteSpace(maHD))
                return OperationResult<bool>.Fail("Mã hóa đơn không hợp lệ");

            var invoices = GetInvoices(maHD: maHD);
            if (!invoices.Success || invoices.Data.Count == 0)
                return OperationResult<bool>.Fail("Hóa đơn không tồn tại");

            var invoice = invoices.Data[0];
            invoice.TrangThai = trangThai;
            return UpdateInvoice(invoice);
        }

        public OperationResult<List<InvoiceDetail>> GetInvoiceDetails(string maHD)
        {
            var dalResult = invoiceDAL.GetInvoiceDetails(maHD: maHD);

            if (!dalResult.Success)
                return OperationResult<List<InvoiceDetail>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<InvoiceDetail> list = new List<InvoiceDetail>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapInvoiceDetail(row));
                }
                return OperationResult<List<InvoiceDetail>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<InvoiceDetail>>.Fail($"Lỗi khi xử lý chi tiết hóa đơn: {ex.Message}");
            }
        }

        public OperationResult<bool> AddInvoiceDetail(string maHD, string moTa, int soLuong, decimal donGia)
        {
            if (string.IsNullOrWhiteSpace(maHD))
                return OperationResult<bool>.Fail("Mã hóa đơn không được để trống");

            decimal thanhTien = soLuong * donGia;
            string maCTHD = GenerateMaCTHD();

            InvoiceDetail detail = new InvoiceDetail
            {
                MaCTHD = maCTHD,
                MaHD = maHD,
                MoTa = moTa,
                SoLuong = soLuong,
                DonGia = donGia,
                ThanhTien = thanhTien,
                IsActive = true,
                CreatedBy = Session_Now.CurrentUser,
                CreatedAt = DateTime.Now
            };

            var dalResult = invoiceDAL.InsertInvoiceDetail(detail);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        private string GenerateMaHD()
        {
            var invoices = GetInvoices();
            int maxNumber = 0;
            
            if (invoices.Success && invoices.Data.Count > 0)
            {
                foreach (var inv in invoices.Data)
                {
                    if (inv.MaHD.StartsWith("HD") && inv.MaHD.Length > 2)
                    {
                        if (int.TryParse(inv.MaHD.Substring(2), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }
            
            return $"HD{(maxNumber + 1):D3}";
        }

        private string GenerateMaCTHD()
        {
            // Simple generation - can be improved
            return $"CTHD{DateTime.Now:yyyyMMddHHmmss}";
        }

        private Invoice MapInvoice(DataRow row)
        {
            return new Invoice
            {
                MaHD = row["MaHD"]?.ToString() ?? "",
                MaDP = row["MaDP"]?.ToString(),
                MaCTSK = row.Table.Columns.Contains("MaCTSK") ? row["MaCTSK"]?.ToString() : null,
                LoaiHoaDon = row.Table.Columns.Contains("LoaiHoaDon") ? row["LoaiHoaDon"]?.ToString() : "DatPhong",
                MaKH = row["MaKH"]?.ToString(),
                MaNV = row["MaNV"]?.ToString(),
                MaKM = row["MaKM"]?.ToString(),
                MaCN = row["MaCN"]?.ToString(),
                TrangThai = row["TrangThai"]?.ToString(),
                NgayLap = row["NgayLap"] != DBNull.Value ? Convert.ToDateTime(row["NgayLap"]) : (DateTime?)null,
                TongTruocKM = row["TongTruocKM"] != DBNull.Value ? Convert.ToDecimal(row["TongTruocKM"]) : (decimal?)null,
                TongTien = row["TongTien"] != DBNull.Value ? Convert.ToDecimal(row["TongTien"]) : (decimal?)null,
                IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]),
                CreatedBy = row["CreatedBy"]?.ToString(),
                CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now,
                UpdatedBy = row["UpdatedBy"]?.ToString(),
                UpdatedAt = row["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null
            };
        }

        private InvoiceDetail MapInvoiceDetail(DataRow row)
        {
            return new InvoiceDetail
            {
                MaCTHD = row["MaCTHD"]?.ToString() ?? "",
                MaHD = row["MaHD"]?.ToString(),
                MoTa = row["MoTa"]?.ToString(),
                SoLuong = row["SoLuong"] != DBNull.Value ? Convert.ToInt32(row["SoLuong"]) : (int?)null,
                DonGia = row["DonGia"] != DBNull.Value ? Convert.ToDecimal(row["DonGia"]) : (decimal?)null,
                ThanhTien = row["ThanhTien"] != DBNull.Value ? Convert.ToDecimal(row["ThanhTien"]) : (decimal?)null,
                IsActive = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]),
                CreatedBy = row["CreatedBy"]?.ToString(),
                CreatedAt = row["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.Now,
                UpdatedBy = row["UpdatedBy"]?.ToString(),
                UpdatedAt = row["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null
            };
        }
    }
}

