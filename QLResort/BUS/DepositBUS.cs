using System;
using System.Collections.Generic;
using QLResort.Core.ClassHoTro;
using QLResort.Core.Model;
using QLResort.DAL.DepositDAL;

namespace QLResort.BUS
{
    public class DepositBUS
    {
        private readonly DepositDAL depositDAL;

        public DepositBUS()
        {
            depositDAL = new DepositDAL();
        }

        /// <summary>
        /// Lấy tất cả deposits theo điều kiện
        /// </summary>
        public OperationResult<List<Deposit>> GetAllDeposits(string maDatCoc = null, string maDP = null, 
                                               string maKH = null, string loaiCoc = null, 
                                               string trangThai = null)
        {
            try
            {
                var deposits = depositDAL.GetDeposits(maDatCoc, maDP, maKH, loaiCoc, trangThai);
                return new OperationResult<List<Deposit>>
                {
                    Success = true,
                    Data = deposits,
                    Message = $"Lấy danh sách deposit thành công ({deposits.Count} bản ghi)"
                };
            }
            catch (Exception ex)
            {
                return new OperationResult<List<Deposit>>
                {
                    Success = false,
                    Message = $"Lỗi khi lấy danh sách deposit: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Lấy deposit theo mã
        /// </summary>
        public OperationResult<Deposit> GetDepositById(string maDatCoc)
        {
            try
            {
                var deposit = depositDAL.GetDepositById(maDatCoc);
                if (deposit == null)
                {
                    return new OperationResult<Deposit>
                    {
                        Success = false,
                        Message = $"Không tìm thấy deposit với mã: {maDatCoc}"
                    };
                }

                return new OperationResult<Deposit>
                {
                    Success = true,
                    Data = deposit,
                    Message = "Lấy thông tin deposit thành công"
                };
            }
            catch (Exception ex)
            {
                return new OperationResult<Deposit>
                {
                    Success = false,
                    Message = $"Lỗi khi lấy deposit: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Lấy các deposits của một booking
        /// </summary>
        public OperationResult<List<Deposit>> GetDepositsByBooking(string maDP)
        {
            try
            {
                var deposits = depositDAL.GetDepositsByBooking(maDP);
                return new OperationResult<List<Deposit>>
                {
                    Success = true,
                    Data = deposits,
                    Message = "Lấy danh sách deposit thành công"
                };
            }
            catch (Exception ex)
            {
                return new OperationResult<List<Deposit>>
                {
                    Success = false,
                    Message = $"Lỗi khi lấy deposit của booking: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Thêm deposit mới
        /// </summary>
        public OperationResult<bool> AddDeposit(Deposit deposit)
        {
            try
            {
                // Validate
                if (deposit == null)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Thông tin deposit không được để trống"
                    };
                }

                if (string.IsNullOrEmpty(deposit.MaKH))
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Mã khách hàng không được để trống"
                    };
                }

                if (deposit.SoTien <= 0)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Số tiền cọc phải lớn hơn 0"
                    };
                }

                // Generate mã deposit nếu chưa có
                if (string.IsNullOrEmpty(deposit.MaDatCoc))
                {
                    deposit.MaDatCoc = depositDAL.GenerateDepositCode();
                }

                // Thêm vào database
                var result = depositDAL.AddDeposit(deposit);
                return result;
            }
            catch (Exception ex)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"Lỗi khi thêm deposit: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Cập nhật deposit
        /// </summary>
        public OperationResult<bool> UpdateDeposit(Deposit deposit)
        {
            try
            {
                // Validate
                if (deposit == null || string.IsNullOrEmpty(deposit.MaDatCoc))
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = "Thông tin deposit không hợp lệ"
                    };
                }

                // Kiểm tra deposit có tồn tại không
                var existing = depositDAL.GetDepositById(deposit.MaDatCoc);
                if (existing == null)
                {
                    return new OperationResult<bool>
                    {
                        Success = false,
                        Message = $"Không tìm thấy deposit với mã: {deposit.MaDatCoc}"
                    };
                }

                // Cập nhật
                var result = depositDAL.UpdateDeposit(deposit);
                return result;
            }
            catch (Exception ex)
            {
                return new OperationResult<bool>
                {
                    Success = false,
                    Message = $"Lỗi khi cập nhật deposit: {ex.Message}"
                };
            }
        }

        /// <summary>
        /// Tính tổng tiền cọc của một booking
        /// </summary>
        public decimal GetTotalDepositForBooking(string maDP)
        {
            try
            {
                var deposits = depositDAL.GetDepositsByBooking(maDP);
                decimal total = 0;

                foreach (var deposit in deposits)
                {
                    if (deposit.TrangThai == "ĐÃ NHẬN")
                    {
                        total += deposit.SoTien;
                    }
                }

                return total;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Tạo mã deposit mới
        /// </summary>
        public string GenerateDepositCode()
        {
            return depositDAL.GenerateDepositCode();
        }
    }
}
