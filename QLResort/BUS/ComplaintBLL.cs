using QLResort.Core.Extensions;
using QLResort.Core.Model;
using QLResort.Core.ClassHoTro;
using QLResort.DAL.ComplaintDAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace QLResort.BLL
{
    public class ComplaintBLL
    {
        private readonly ComplaintDAL complaintDAL = new ComplaintDAL();

        public OperationResult<List<Complaint>> GetComplaints(string maKN = null, string maKH = null,
            string maNV = null, string maCN = null, string trangThai = null, string mucDo = null)
        {
            var dalResult = complaintDAL.GetComplaints(maKN, maKH, maNV, maCN, trangThai, mucDo);

            if (!dalResult.Success)
                return OperationResult<List<Complaint>>.Fail(dalResult.ErrorMessage);

            try
            {
                List<Complaint> list = new List<Complaint>();
                foreach (DataRow row in dalResult.Data.Rows)
                {
                    list.Add(MapComplaint(row));
                }
                return OperationResult<List<Complaint>>.Ok(list);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Complaint>>.Fail($"Lỗi khi xử lý dữ liệu khiếu nại: {ex.Message}");
            }
        }

        public OperationResult<bool> AddComplaint(
            string maKH,
            string maCN,
            string noiDung,
            string mucDo = "Thường",
            string ghiChu = null)
        {
            if (string.IsNullOrWhiteSpace(maKH))
                return OperationResult<bool>.Fail("Mã khách hàng không được để trống");

            if (string.IsNullOrWhiteSpace(maCN))
                return OperationResult<bool>.Fail("Mã chi nhánh không được để trống");

            if (string.IsNullOrWhiteSpace(noiDung))
                return OperationResult<bool>.Fail("Nội dung khiếu nại không được để trống");

            string maKN = GenerateMaKN();

            Complaint complaint = new Complaint
            {
                MaKN = maKN,
                MaKH = maKH,
                MaCN = maCN,
                NgayGhi = DateTime.Now,
                NoiDung = noiDung,
                MucDo = mucDo,
                TrangThai = "Chưa xử lý",
                SoTienBoiThuong = 0,
                GhiChu = ghiChu,
                CreatedAt = DateTime.Now
            };

            var dalResult = complaintDAL.Insert(complaint);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> UpdateComplaint(
            string maKN,
            string maNV = null,
            string trangThai = null,
            string ketQua = null,
            decimal? soTienBoiThuong = null,
            string ghiChu = null)
        {
            if (string.IsNullOrWhiteSpace(maKN))
                return OperationResult<bool>.Fail("Mã khiếu nại không hợp lệ");

            if (!complaintDAL.Exists(maKN))
                return OperationResult<bool>.Fail("Khiếu nại không tồn tại");

            Complaint complaint = new Complaint
            {
                MaKN = maKN,
                MaNV = maNV,
                TrangThai = trangThai,
                KetQua = ketQua,
                SoTienBoiThuong = soTienBoiThuong ?? 0,
                GhiChu = ghiChu,
                UpdatedAt = DateTime.Now
            };

            var dalResult = complaintDAL.Update(complaint);
            if (!dalResult.Success)
                return OperationResult<bool>.Fail(dalResult.ErrorMessage);

            return OperationResult<bool>.Ok(true);
        }

        public OperationResult<bool> DeleteComplaint(string maKN)
        {
            if (string.IsNullOrWhiteSpace(maKN))
                return OperationResult<bool>.Fail("Mã khiếu nại không hợp lệ");

            if (!complaintDAL.Exists(maKN))
                return OperationResult<bool>.Fail("Khiếu nại không tồn tại");

            // Soft delete - update status to "Hủy"
            var result = UpdateComplaint(maKN, null, "Hủy", "Đã xóa", null, "Đã xóa");
            return result;
        }

        private string GenerateMaKN()
        {
            var complaints = GetComplaints();
            int maxNumber = 0;

            if (complaints.Success && complaints.Data.Count > 0)
            {
                foreach (var complaint in complaints.Data)
                {
                    if (complaint.MaKN.StartsWith("KN") && complaint.MaKN.Length > 2)
                    {
                        if (int.TryParse(complaint.MaKN.Substring(2), out int number))
                        {
                            if (number > maxNumber)
                                maxNumber = number;
                        }
                    }
                }
            }

            return $"KN{(maxNumber + 1):D3}";
        }

        private Complaint MapComplaint(DataRow row)
        {
            return new Complaint
            {
                MaKN = row.GetString("MaKN", ""),
                MaKH = row.GetString("MaKH", ""),
                MaNV = row.GetString("MaNV"),
                MaCN = row.GetString("MaCN", ""),
                NgayGhi = row.GetNullableDateTime("NgayGhi") ?? DateTime.Now,
                NoiDung = row.GetString("NoiDung", ""),
                MucDo = row.GetString("MucDo", "Thường"),
                TrangThai = row.GetString("TrangThai", "Chưa xử lý"),
                KetQua = row.GetString("KetQua"),
                SoTienBoiThuong = row.GetNullableDecimal("SoTienBoiThuong") ?? 0,
                GhiChu = row.GetString("GhiChu"),
                CreatedAt = row.GetNullableDateTime("CreatedAt") ?? DateTime.Now,
                UpdatedAt = row.GetNullableDateTime("UpdatedAt")
            };
        }
    }
}

