using System;
using System.Data.SqlClient;
using BUS_QLResort;
using ET_QLResort;
using Tool_QLResort.ClassHoTro;
using Tool_QLResort.Database;

namespace TestBUS
{
    /// <summary>
    /// Console app test trực tiếp BUS layer để kiểm tra logic nghiệp vụ
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          TEST BUS LAYER - RESORT MANAGEMENT                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.WriteLine();

            // Giả lập session - cần có user đăng nhập
            Session_Now.CurrentUser = "NV01";

            try
            {
                // Test 1: Luồng Đặt Phòng qua BUS
                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                Console.WriteLine("[TEST 1] LUỒNG ĐẶT PHÒNG QUA BUS LAYER");
                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                TestBookingFlowViaBUS();

                Console.WriteLine();

                // Test 2: Luồng Sự Kiện qua BUS
                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                Console.WriteLine("[TEST 2] LUỒNG SỰ KIỆN QUA BUS LAYER");
                Console.WriteLine("═══════════════════════════════════════════════════════════════");
                TestEventFlowViaBUS();

                Console.WriteLine();
                Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                  BUS TEST HOÀN TẤT!                          ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("❌ LỖI: " + ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine();
            Console.WriteLine("Nhấn Enter để thoát...");
            Console.ReadLine();
        }

        static void TestBookingFlowViaBUS()
        {
            var bookingBUS = new BookingBUS();
            var bookingDetailBUS = new BookingDetailBUS();
            var roomBUS = new RoomBUS();
            var invoiceBUS = new InvoiceBUS();
            var paymentBUS = new PaymentBUS();
            var guestPointBUS = new GuestPointBUS();

            string testPhong = "P005"; // Phòng trống
            string testKH = "KH001";
            string testNV = "NV03";
            string testMaCN = "CN01";

            string createdMaDP = null;
            string createdMaCTDP = null;
            string createdMaHD = null;

            try
            {
                // BƯỚC 1: Tạo Booking qua BUS
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 1] BookingBUS.AddBooking()...");
                var booking = new Booking
                {
                    MaKH = testKH,
                    MaNV = testNV,
                    TrangThai = "Đặt",
                    GhiChu = "Test từ Console BUS"
                };
                var bookingResult = bookingBUS.AddBooking(booking);
                if (!bookingResult.Success)
                {
                    Console.WriteLine("   ❌ Lỗi: " + bookingResult.ErrorMessage);
                    return;
                }
                createdMaDP = bookingResult.Data.MaDP;
                Console.WriteLine("   ✅ Tạo Booking: " + createdMaDP);

                // BƯỚC 2: Tạo BookingDetail qua BUS
                // Signature: AddBookingDetail(maDP, maPhong, ngayDen, ngayDi, nguoiLon, treEm, giaPhong, thanhTien, trangThai, loaiThue)
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 2] BookingDetailBUS.AddBookingDetail()...");
                var detailResult = bookingDetailBUS.AddBookingDetail(
                    createdMaDP,
                    testPhong,
                    DateTime.Now,
                    DateTime.Now.AddDays(2),
                    2, // NguoiLon
                    0, // TreEm
                    1800000m, // GiaPhong
                    3600000m, // ThanhTien
                    "Đặt",
                    "Ngày"
                );
                if (!detailResult.Success)
                {
                    Console.WriteLine("   ❌ Lỗi: " + detailResult.ErrorMessage);
                    return;
                }
                createdMaCTDP = detailResult.Data; // AddBookingDetail returns OperationResult<string>
                Console.WriteLine("   ✅ Tạo BookingDetail: " + createdMaCTDP);

                // BƯỚC 3: Cập nhật trạng thái phòng
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 3] RoomBUS.UpdateRoomStatus()...");
                var roomResult = roomBUS.UpdateRoomStatus(testPhong, "Đã đặt");
                Console.WriteLine("   " + (roomResult.Success ? "✅" : "❌") + " Phòng " + testPhong + " → 'Đã đặt'");

                // BƯỚC 4: CHECK-IN - Cập nhật trạng thái
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 4] CHECK-IN via BookingBUS.UpdateBooking()...");
                var updateBooking = bookingBUS.UpdateBooking(createdMaDP, "Đang sử dụng", "Đã check-in");
                Console.WriteLine("   " + (updateBooking.Success ? "✅" : "❌") + " Booking → 'Đang sử dụng'");

                var updateDetail = bookingDetailBUS.UpdateBookingDetail(
                    createdMaCTDP,
                    "Đang sử dụng",
                    DateTime.Now,
                    DateTime.Now.AddDays(2),
                    2, 0, 1800000m, 3600000m
                );
                Console.WriteLine("   " + (updateDetail.Success ? "✅" : "❌") + " BookingDetail → 'Đang sử dụng'");

                roomBUS.UpdateRoomStatus(testPhong, "Đang Sử Dụng");
                Console.WriteLine("   ✅ Phòng → 'Đang Sử Dụng'");

                // BƯỚC 5: Tạo Hóa đơn
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 5] InvoiceBUS.CreateInvoice()...");
                // Signature: CreateInvoice(maDP, maKH, maNV, maCN, tongTruocKM, couponCode, maLKH, maLP, maPhong, maCTSK, loaiHoaDon)
                var invoiceResult = invoiceBUS.CreateInvoice(
                    createdMaDP,
                    testKH,
                    testNV,
                    testMaCN,
                    3600000m,
                    null, null, null, null, // couponCode, maLKH, maLP, maPhong
                    null,                    // maCTSK = null cho đặt phòng
                    "DatPhong"
                );
                if (!invoiceResult.Success)
                {
                    Console.WriteLine("   ❌ Lỗi: " + invoiceResult.ErrorMessage);
                    return;
                }
                createdMaHD = invoiceResult.Data.MaHD;
                Console.WriteLine("   ✅ Tạo HoaDon: " + createdMaHD);

                // BƯỚC 6: Thanh toán
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 6] PaymentBUS.AddPayment()...");
                var paymentResult = paymentBUS.AddPayment(createdMaHD, 3600000m, "LTT01", DateTime.Now);
                Console.WriteLine("   " + (paymentResult.Success ? "✅" : "❌") + " Tạo ThanhToan: 3,600,000 VNĐ");

                // BƯỚC 7: Cập nhật trạng thái sau thanh toán
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 7] Cập nhật trạng thái sau thanh toán...");

                // HoaDon → Đã TT
                var updateInvoice = invoiceBUS.UpdateInvoiceStatus(createdMaHD, "Đã TT");
                Console.WriteLine("   " + (updateInvoice.Success ? "✅" : "❌") + " HoaDon → 'Đã TT'");

                // Booking → Hoàn tất
                var finalBooking = bookingBUS.UpdateBooking(createdMaDP, "Hoàn tất", "Đã thanh toán");
                Console.WriteLine("   " + (finalBooking.Success ? "✅" : "❌") + " Booking → 'Hoàn tất'");

                // BookingDetail → Hoàn tất
                var finalDetail = bookingDetailBUS.UpdateBookingDetail(
                    createdMaCTDP, "Hoàn tất",
                    DateTime.Now.AddDays(-1), DateTime.Now,
                    2, 0, 1800000m, 3600000m
                );
                Console.WriteLine("   " + (finalDetail.Success ? "✅" : "❌") + " BookingDetail → 'Hoàn tất'");

                // Phòng → Đang dọn
                var roomDon = roomBUS.UpdateRoomStatus(testPhong, "Đang Dọn");
                Console.WriteLine("   " + (roomDon.Success ? "✅" : "❌") + " Phòng → 'Đang Dọn'");

                // Cộng điểm KH
                int points = (int)(3600000m / 10000);
                var pointResult = guestPointBUS.AddPoints(testKH, points, "Test tích điểm");
                Console.WriteLine("   " + (pointResult.Success ? "✅" : "❌") + " Cộng " + points + " điểm cho KH");

                // BƯỚC 8: Kiểm tra kết quả
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 8] KIỂM TRA KẾT QUẢ...");
                VerifyBookingViaBUS(bookingBUS, bookingDetailBUS, invoiceBUS, roomBUS,
                    createdMaDP, createdMaCTDP, createdMaHD, testPhong);

                Console.WriteLine();
                Console.WriteLine("✅✅✅ LUỒNG ĐẶT PHÒNG QUA BUS THÀNH CÔNG! ✅✅✅");
            }
            finally
            {
                // Cleanup - soft delete
                Console.WriteLine();
                Console.WriteLine("▶ [Cleanup] Soft delete dữ liệu test...");
                CleanupTestData(createdMaDP, createdMaCTDP, createdMaHD, testPhong);
            }
        }

        static void VerifyBookingViaBUS(BookingBUS bookingBUS, BookingDetailBUS bookingDetailBUS,
            InvoiceBUS invoiceBUS, RoomBUS roomBUS,
            string maDP, string maCTDP, string maHD, string maPhong)
        {
            // Check Booking
            var bookings = bookingBUS.GetBookings(maDP: maDP);
            if (bookings.Success && bookings.Data.Count > 0)
            {
                var b = bookings.Data[0];
                Console.WriteLine("   - Booking.TrangThai = " + b.TrangThai + (b.TrangThai == "Hoàn tất" ? " ✅" : " ❌"));
            }

            // Check BookingDetail
            var details = bookingDetailBUS.GetBookingDetails(maCTDP: maCTDP);
            if (details.Success && details.Data.Count > 0)
            {
                var d = details.Data[0];
                Console.WriteLine("   - BookingDetail.TrangThai = " + d.TrangThai + (d.TrangThai == "Hoàn tất" ? " ✅" : " ❌"));
            }

            // Check Invoice
            var invoices = invoiceBUS.GetInvoices(maHD: maHD);
            if (invoices.Success && invoices.Data.Count > 0)
            {
                var inv = invoices.Data[0];
                Console.WriteLine("   - Invoice.TrangThai = " + inv.TrangThai + (inv.TrangThai == "Đã TT" ? " ✅" : " ❌"));
            }

            // Check Room
            var rooms = roomBUS.GetRooms(maPhong: maPhong);
            if (rooms.Success && rooms.Data.Count > 0)
            {
                var r = rooms.Data[0];
                Console.WriteLine("   - Room.TrangThai = " + r.TrangThai + (r.TrangThai == "Đang Dọn" ? " ✅" : " ❌"));
            }
        }

        static void CleanupTestData(string maDP, string maCTDP, string maHD, string maPhong)
        {
            var dal = new FastQuery();

            if (!string.IsNullOrEmpty(maHD))
            {
                dal.ExecuteNonQuery("UPDATE ThanhToan SET IsActive = 0 WHERE MaHD = @MaHD",
                    new SqlParameter("@MaHD", maHD));
                dal.ExecuteNonQuery("UPDATE HoaDon SET IsActive = 0 WHERE MaHD = @MaHD",
                    new SqlParameter("@MaHD", maHD));
            }
            if (!string.IsNullOrEmpty(maCTDP))
            {
                dal.ExecuteNonQuery("UPDATE CTDatPhong SET IsActive = 0 WHERE MaCTDP = @MaCTDP",
                    new SqlParameter("@MaCTDP", maCTDP));
            }
            if (!string.IsNullOrEmpty(maDP))
            {
                dal.ExecuteNonQuery("UPDATE DatPhong SET IsActive = 0 WHERE MaDP = @MaDP",
                    new SqlParameter("@MaDP", maDP));
            }
            if (!string.IsNullOrEmpty(maPhong))
            {
                dal.ExecuteNonQuery("UPDATE Phong SET TrangThai = N'Trống' WHERE MaPhong = @MaPhong",
                    new SqlParameter("@MaPhong", maPhong));
            }
            Console.WriteLine("   ✅ Đã cleanup");
        }

        static void TestEventFlowViaBUS()
        {
            var eventDetailBUS = new EventDetailBUS();
            var invoiceBUS = new InvoiceBUS();
            var paymentBUS = new PaymentBUS();

            string testMaSK = "SK001";
            string testKH = "KH002";
            string testNV = "NV01";
            string testMaCN = "CN01";
            decimal tongTien = 50000000m;
            decimal datCoc = 15000000m;

            string createdMaCTSK = null;
            string createdMaHD = null;

            try
            {
                // BƯỚC 1: Tạo EventDetail
                // Signature: AddEventDetail(maSK, maKH, donGia, ngayBD, ngayKT, soLuong=1, tongKhach=null, daThanhToan=0, ghiChu=null, trangThai="Lên kế hoạch")
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 1] EventDetailBUS.AddEventDetail()...");
                var detailResult = eventDetailBUS.AddEventDetail(
                    testMaSK,
                    testKH,
                    tongTien,       // donGia
                    DateTime.Now.AddDays(30), // ngayBD
                    DateTime.Now.AddDays(30), // ngayKT
                    1,              // soLuong
                    150,            // tongKhach
                    datCoc,         // daThanhToan
                    "Test sự kiện từ Console BUS",
                    "Lên kế hoạch"
                );
                if (!detailResult.Success)
                {
                    Console.WriteLine("   ❌ Lỗi: " + detailResult.ErrorMessage);
                    return;
                }
                Console.WriteLine("   ✅ Tạo EventDetail thành công");

                // Lấy MaCTSK vừa tạo
                var eventDetails = eventDetailBUS.GetEventDetails(maSK: testMaSK, maKH: testKH);
                if (eventDetails.Success && eventDetails.Data.Count > 0)
                {
                    // Lấy chi tiết mới nhất
                    createdMaCTSK = eventDetails.Data[eventDetails.Data.Count - 1].MaCTSK;
                    Console.WriteLine("   ✅ MaCTSK: " + createdMaCTSK);
                }
                else
                {
                    Console.WriteLine("   ❌ Không tìm thấy EventDetail vừa tạo");
                    return;
                }

                // BƯỚC 2: Tạo Invoice cho sự kiện
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 2] InvoiceBUS.CreateInvoice() cho sự kiện...");
                // Signature: CreateInvoice(maDP, maKH, maNV, maCN, tongTruocKM, couponCode, maLKH, maLP, maPhong, maCTSK, loaiHoaDon)
                var invoiceResult = invoiceBUS.CreateInvoice(
                    null,           // MaDP null cho sự kiện
                    testKH,
                    testNV,
                    testMaCN,
                    tongTien,
                    null, null, null, null, // couponCode, maLKH, maLP, maPhong
                    createdMaCTSK,  // maCTSK
                    "SuKien"
                );
                if (!invoiceResult.Success)
                {
                    Console.WriteLine("   ❌ Lỗi: " + invoiceResult.ErrorMessage);
                    return;
                }
                createdMaHD = invoiceResult.Data.MaHD;
                Console.WriteLine("   ✅ Tạo HoaDon: " + createdMaHD);

                // BƯỚC 3: Thanh toán đặt cọc
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 3] PaymentBUS.AddPayment() - Đặt cọc 30%...");
                var payment1 = paymentBUS.AddPayment(createdMaHD, datCoc, "LTT04", DateTime.Now);
                Console.WriteLine("   " + (payment1.Success ? "✅" : "❌") + " Đặt cọc: " + string.Format("{0:N0}", datCoc));

                // BƯỚC 4: Thanh toán phần còn lại
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 4] PaymentBUS.AddPayment() - Còn lại...");
                decimal conLai = tongTien - datCoc;
                var payment2 = paymentBUS.AddPayment(createdMaHD, conLai, "LTT02", DateTime.Now);
                Console.WriteLine("   " + (payment2.Success ? "✅" : "❌") + " Thanh toán còn lại: " + string.Format("{0:N0}", conLai));

                // BƯỚC 5: Cập nhật trạng thái
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 5] Cập nhật trạng thái...");

                var updateInvoice = invoiceBUS.UpdateInvoiceStatus(createdMaHD, "Đã TT");
                Console.WriteLine("   " + (updateInvoice.Success ? "✅" : "❌") + " HoaDon → 'Đã TT'");

                var updateEvent = eventDetailBUS.UpdateEventDetail(createdMaCTSK, "Đã kết thúc", tongTien);
                Console.WriteLine("   " + (updateEvent.Success ? "✅" : "❌") + " EventDetail → 'Đã kết thúc'");

                // BƯỚC 6: Kiểm tra
                Console.WriteLine();
                Console.WriteLine("▶ [Bước 6] KIỂM TRA KẾT QUẢ...");
                VerifyEventViaBUS(eventDetailBUS, invoiceBUS, createdMaCTSK, createdMaHD, tongTien);

                Console.WriteLine();
                Console.WriteLine("✅✅✅ LUỒNG SỰ KIỆN QUA BUS THÀNH CÔNG! ✅✅✅");
            }
            finally
            {
                Console.WriteLine();
                Console.WriteLine("▶ [Cleanup] Soft delete dữ liệu test...");
                CleanupEventData(createdMaCTSK, createdMaHD);
            }
        }

        static void VerifyEventViaBUS(EventDetailBUS eventDetailBUS, InvoiceBUS invoiceBUS,
            string maCTSK, string maHD, decimal tongTien)
        {
            // Check EventDetail
            var details = eventDetailBUS.GetEventDetails(maCTSK: maCTSK);
            if (details.Success && details.Data.Count > 0)
            {
                var d = details.Data[0];
                Console.WriteLine("   - EventDetail.TrangThai = " + d.TrangThai + (d.TrangThai == "Đã kết thúc" ? " ✅" : " ❌"));
                Console.WriteLine("   - EventDetail.DaThanhToan = " + string.Format("{0:N0}", d.DaThanhToan) + (d.DaThanhToan == tongTien ? " ✅" : " ❌"));
            }

            // Check Invoice
            var invoices = invoiceBUS.GetInvoices(maHD: maHD);
            if (invoices.Success && invoices.Data.Count > 0)
            {
                var inv = invoices.Data[0];
                Console.WriteLine("   - Invoice.TrangThai = " + inv.TrangThai + (inv.TrangThai == "Đã TT" ? " ✅" : " ❌"));
            }
        }

        static void CleanupEventData(string maCTSK, string maHD)
        {
            var dal = new FastQuery();

            if (!string.IsNullOrEmpty(maHD))
            {
                dal.ExecuteNonQuery("UPDATE ThanhToan SET IsActive = 0 WHERE MaHD = @MaHD",
                    new SqlParameter("@MaHD", maHD));
                dal.ExecuteNonQuery("UPDATE HoaDon SET IsActive = 0 WHERE MaHD = @MaHD",
                    new SqlParameter("@MaHD", maHD));
            }
            if (!string.IsNullOrEmpty(maCTSK))
            {
                dal.ExecuteNonQuery("UPDATE CTSuKien SET IsActive = 0 WHERE MaCTSK = @MaCTSK",
                    new SqlParameter("@MaCTSK", maCTSK));
            }
            Console.WriteLine("   ✅ Đã cleanup");
        }
    }
}
