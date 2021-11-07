using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Models;

namespace StoreApi.Repositories
{
    public class SeedData
    {
        public static void Initialize(ClockStoreDBContext context)
        {
            context.Database.EnsureCreated();
            bool temp = false;

            if (!context.Quyens.Any())
            {
                temp = true;
                context.Quyens.AddRange(new List<Quyen>{
                    new Quyen{
                        Id = 1,
                        name = "Admin",
                        details = "qlNhapHang-qlNhanVien-qlSanPham-qlHoaDon-qlKhachHang-qlPhieuNhap-qlNCC-qlTaiKhoan-qlQuyen-qlThongKe-qlLoaiSanPham-qlThuongHieu"
                    },
                    new Quyen{
                        Id = 2,
                        name = "Quản lý",
                        details = "qlNhanVien-xemSanPham-xemHoaDon-qlKhachHang-xemPhieuNhap-xemNCC-qlTaiKhoan-qlThongKe-qlLoaiSanPham-qlThuongHieu"
                    },
                    new Quyen{
                        Id = 3,
                        name = "Nhân viên bán hàng",
                        details = "xemSanPham-qlHoaDon-xemKhachHang-qlThongKe-xemThuongHieu"
                    },
                    new Quyen{
                        Id = 4,
                        name = "Nhân viên nhập hàng",
                        details = "qlNhapHang-qlSanPham-qlPhieuNhap-qlNCC-qlThongKe-qlLoaiSanPham-qlThuongHieu"
                    },
                    new Quyen{
                        Id = 5,
                        name = "Nhân viên nhập hàng",
                        details = ""
                    }
                });
            }

            if (!context.NhanViens.Any())
            {
                temp = true;
                context.NhanViens.AddRange(new List<NhanVien>{
                    new NhanVien{
                        user = "admin",
                        password = "admin",
                        name = "Nguyễn Ngọc Thiện",
                        phone = "0364117408",
                        address = "Bình Định",
                        gender = "Nam",
                        dateborn = DateTime.Parse("2000-5-8"),
                        quyenId = 1,
                        status = 1
                    },
                    new NhanVien{
                        user = "ql01",
                        password = "ql01",
                        name = "Nguyễn Tấn Thông",
                        phone = "0364117408",
                        address = "Hồ Chí Minh",
                        gender = "Nam",
                        dateborn = DateTime.Parse("2000-5-8"),
                        quyenId = 2,
                        status = 1
                    },
                    new NhanVien{
                        user = "bh01",
                        password = "bh01",
                        name = "Cung Xương Hồng Thiên",
                        phone = "0364117408",
                        address = "Hồ Chí Minh",
                        gender = "Nam",
                        dateborn = DateTime.Parse("2000-5-8"),
                        quyenId = 3,
                        status = 1
                    },
                    new NhanVien{
                        user = "nh01",
                        password = "nh01",
                        name = "Võ Minh Hưng",
                        phone = "0364117408",
                        address = "Hồ Chí Minh",
                        gender = "Nam",
                        dateborn = DateTime.Parse("2000-5-8"),
                        quyenId = 2,
                        status = 1
                    }
                });
            }
            if (!context.KieuDays.Any())
            {
                temp = true;
                context.KieuDays.AddRange(new List<KieuDay>{
                    new KieuDay{
                        Id = 1,
                        name = "Không có dây"
                    },
                    new KieuDay{
                        Id = 2,
                        name = "Dây kim loại"
                    },
                    new KieuDay{
                        Id = 3,
                        name = "Dây da"
                    }
                });
            }
            if (!context.KieuMays.Any())
            {
                temp = true;
                context.KieuMays.AddRange(new List<KieuMay>{
                    new KieuMay{
                        Id = 1,
                        name = "Máy điện tử - Pin"
                    },
                    new KieuMay{
                        Id = 2,
                        name = "Máy cơ"
                    }
                });
            }
            if (!context.LoaiSanPhams.Any())
            {
                temp = true;
                context.LoaiSanPhams.AddRange(new List<LoaiSanPham>{
                    new LoaiSanPham{
                        Id = 1,
                        name = "ĐỒNG HỒ NAM",
                        description = "Đồng hồ dành cho nam"
                    },
                    new LoaiSanPham{
                        Id = 2,
                        name = "ĐỒNG HỒ NỮ",
                        description = "Đồng hồ dành cho nữ"
                    },
                    new LoaiSanPham{
                        Id =3,
                        name = "ĐỒNG HỒ ĐÔI",
                        description = "Đồng hồ dành cho cặp đôi"
                    },
                    new LoaiSanPham{
                        Id = 4,
                        name = "ĐỒNG HỒ ĐỂ BÀN",
                        description = "Đồng hồ dành để bàn cho việc học và làm việc"
                    },
                    new LoaiSanPham{
                        Id = 5,
                        name = "ĐỒNG HỒ TREO TƯỜNG",
                        description = "Đồng hồ dành cho việc trang trí nhà cửa"
                    },
                });
            if(!context.ThuongHieus.Any()){
                temp = true;
                context.ThuongHieus.AddRange(new List<ThuongHieu>{
                    new ThuongHieu{
                        Id = 1,
                        name = "ĐỒNG HỒ LOBINI"
                    },
                    new ThuongHieu{
                        Id = 2,
                        name = "ĐỒNG HỒ KASSAW"
                    },
		            new ThuongHieu{
                        Id = 3,
                        name = "ĐỒNG HỒ TEINTOP"
                    },	
		            new ThuongHieu{
                        Id = 4,
                        name = "ĐỒNG HỒ HAZEAL"
                    },
		            new ThuongHieu{
                        Id = 5,
                        name = "ĐỒNG HỒ NAMKIN"
                    },
		            new ThuongHieu{
                        Id = 6,
                        name = "ĐỒNG HỒ PONIGER"
                    },
		            new ThuongHieu{
                        Id = 7,
                        name = "ĐỒNG HỒ LORBERN"
                    },
		            new ThuongHieu{
                        Id = 8,
                        name = "ĐỒNG HỒ MINI FOCUS"
                    },
                });
            }

            if(!context.NCCs.Any()){
                temp = true;
                context.NCCs.AddRange(new List<NCC>{
                    new NCC{
                        Id = 1,
                        name = "Cty Hà Nội",
                        address = "Đống Đa, Hà Nội",
                        phone = "03641174080",
                        fax = "4598-8789-8789-7897"
                    },
                    new NCC{
                        Id = 2,
                        name = "Cty Hồ Chí Minh",
                        address = "HCM",
                        phone = "03641174080",
                        fax = "4598-8789-8789-7897"
                    },
		            new NCC{
                        Id = 3,
                        name = "Cty Đà Nẵng",
                        address = "Đà Nẵng",
                        phone = "03641174080",
                        fax = "4598-8789-8789-7897"
                    },	
		            new NCC{
                        Id = 4,
                        name = "Cty Hội An",
                        address = "Hội An",
                        phone = "03641174080",
                        fax = "4598-8789-8789-7897"
                    },
		            new NCC{
                        Id = 5,
                        name = "Cty Long An",
                        address = "Long An",
                        phone = "03641174080",
                        fax = "4598-8789-8789-7897"
                    },
		            new NCC{
                        Id = 6,
                        name = "Cty Tiền Giang",
                        address = "Tiền Giang",
                        phone = "03641174080",
                        fax = "4598-8789-8789-7897"
                    },
		            new NCC{
                        Id = 7,
                        name = "Cty Bến Tre",
                        address = "Bến Tre",
                        phone = "03641174080",
                        fax = "4598-8789-8789-7897"
                    },
		            new NCC{
                        Id = 8,
                        name = "Cty Đà Lạt",
                        address = "Đà Lạt",
                        phone = "03641174080",
                        fax = "4598-8789-8789-7897"
                    },
                });
            }
                if (!context.SanPhams.Any())
                {
                    temp = true;
                    context.SanPhams.AddRange(new List<SanPham>{
                        new SanPham{
                            Id = 1,
                            LSPId = 1,
                            brandId = 1,
                            wireId = 2,
                            machineId = 2,
                            nccId = 7,
                            name = "Đồng hồ nam chính hãng LOBINNI L17511-1",
                            amount = 30,
                            price = 5480000,
                            description = "ĐƠN GIẢN nhưng TINH TẾ: Thiết kế 3 kim 1 lịch cùng cọc số thanh mảnh nổi hẳn giữa màu mặt xanh thẳm cho thấy sự chỉn chu, sắc sảo trong từng đường nét. SẮC VÀNG HỒNG VƯƠNG GIẢ: Sự uy quyền, sang trọng được tạo nên bởi sắc vàng kim rực rỡ nhờ công nghệ mạ PVD tiên tiến nhất hiện nay.",
                            img = "/image/sp1.jpg"
                        },
                        new SanPham{
                                Id = 2,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 3,
                                machineId = 1,
                                nccId = 8,
                                name = "Đồng hồ nam chính hãng LOBINNI L12032-1",
                                amount = 35,
                                price = 4550000,
                                description = "Lobinni cam kết chất lượng của sản phẩm luôn là tiêu chí hàng đầu. Mỗi sản phẩm được tạo ra đều xuất phát từ cảm xúc của nghệ nhân sáng tác. Với mỗi chiếc đồng hồ tạo ra chúng đánh dấu khoảng khắc quý giá của của các nghệ nhân và là một phần lịch sử thương hiệu trong chặng đường chinh phục trái tim người yêu đồng hồ.",
                                img = "/image/sp2.jpg"
                        },
                        new SanPham{
                                Id = 3,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 3,
                                machineId = 1,
                                nccId = 8,
                                name = "Đồng hồ nam chính hãng LOBINNI L9010-1",
                                amount = 42,
                                price = 5280000,
                                description = "Tuyệt tác đồng hồ LOBINNI L9010 phô diễn những đường nét nghệ thuật đã giúp khơi gợi nên hình ảnh của một quý ông phong trần, lịch lãm. Dưới lớp kính Sapphire cao cấp, toàn bộ tinh hoa, giá trị của đồng hồ Thụy Sỹ toát ra mạnh mẽ.",
                                img = "/image/sp3.jpg"
                        },
                        new SanPham{
                                Id = 4,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 3,
                                machineId = 1,
                                nccId = 8,
                                name = "Đồng hồ nam chính hãng LOBINNI L16050-2",
                                amount = 50,
                                price = 4800000,
                                description = "Lobinni luôn quan niệm chiếc đồng hồ là thứ ghi lại những khoảnh khắc quý giá nhất trong cuộc sống. Để có được những chiếc đồng hồ có chất lượng tốt nhất Lobinni luôn tuyển chọn những người thợ thủ công có tay nghề cao, ít nhất 10 năm kinh nghiệm trong ngành thiết kế và sản xuất đồng hồ.",
                                img = "/image/sp4.jpg"
                        },
                        new SanPham{
                                Id = 5,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 3,
                                machineId = 1,
                                nccId = 1,
                                name = "Đồng hồ nam chính hãng LOBINNI L18016-1",
                                amount = 52,
                                price = 4850000,
                                description = "VẺ ĐẸP CỔ ĐIỂN: Kiểu số cọc nổi xen lẫn số học trò và vân Guilloche' đã tạo nên sức hút mạnh mẽ cho Lobinni. Nét đẹp mang phong cách cổ điển nhưng rất hợp với phong thái của các quý ông thời đại.",
                                img = "/image/sp5.jpg"
                        },
                        new SanPham{
                                Id = 6,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 3,
                                machineId = 1,
                                nccId = 1,
                                name = "Đồng hồ nam chính hãng LOBINNI L9010-3",
                                amount = 36,
                                price = 5280000,
                                description = "Vàng hồng 18K: Là vàng nguyên khối, phủ trọn gần như là toàn bộ mặt số đồng hồ LOBINNI L9010. Trong khi đó, sự sang trọng lại được kết hợp với nền tảng Skeleton độc đáo, giúp các quý ông chìm đắm ở cả mặt trước lẫn mặt sau thiết kế.",
                                img = "/image/sp6.jpg"
                        },
                        new SanPham{
                                Id = 7,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 3,
                                machineId = 1,
                                nccId = 2,
                                name = "Đồng hồ nam chính hãng LOBINNI L1810-1",
                                amount = 38,
                                price = 5350000,
                                description = "ĐỘ CHÍNH XÁC CAO - HOẠT ĐỘNG ỔN ĐỊNH - BỀN BỈ, HIỆN ĐẠI, sở hữu 21 chân kính bảo vệ khớp nối, tần số 21.600 giúp đồng hồ vận hành bền bỉ, mượt mà",
                                img = "/image/sp7.jpg"
                        },
                        new SanPham{
                                Id = 8,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 3,
                                machineId = 1,
                                nccId = 2,
                                name = "Đồng hồ nam chính hãng LOBINNI L3603-4",
                                amount = 25,
                                price = 2680000,
                                description = "TÍNH NĂNG MOONPHASE: Ô cửa sổ với tính năng Moonphase (xem lịch tuần trăng – lịch âm) trên góc 6h có thể coi là điểm nhấn đắt giá của chiếc đồng hồ này. Mặt trăng tròn cùng các vì sao lấp lánh nổi bật trên nền trời đêm xanh thẳm chính là một thiết kế vô cùng bắt mắt.",
                                img = "/image/sp8.jpg"
                        },
                        new SanPham{
                                Id = 9,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 3,
                                machineId = 1,
                                nccId = 2,
                                name = "Đồng hồ nam chính hãng LOBINNI L5018-1",
                                amount = 28,
                                price = 5530000,
                                description = "Thiết kế 3 kim được vót nhọn thanh mảnh vô cùng đơn giản, toàn bộ phần kim và phần số được mạ vàng nổi bật trên nền đen cổ điển huyền bí. Bộ máy bền bỉ in-house chính hãng Lobinni sản xuất – một trong những cỗ máy được đánh giá bền bỉ và chính xác bậc nhất.",
                                img = "/image/sp9.jpg"
                        },
                        new SanPham{
                                Id = 10,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 3,
                                machineId = 1,
                                nccId = 2,
                                name = "Đồng hồ nam chính hãng LOBINNI L18012-2",
                                amount = 25,
                                price = 5880000,
                                description = "Là một trong hai màu sắc cơ bản đầy ấn tượng, màu đen đem đến một sự lôi cuốn đặc biệt đến từ phái mạnh. Nó làm tăng lên sự lịch lãm đầy sang trọng và sự bí ẩn cho các quý ông. Vừa là sự lựa chọn an toàn, vừa chuẩn mực đàn ông, những phụ kiện màu đen luôn là sự lựa chọn số một của mọi quý ông.",
                                img = "/image/sp10.jpg"
                        },
                        new SanPham{
                                Id = 11,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 2,
                                machineId = 2,
                                nccId = 2,
                                name = "Đồng hồ nam chính hãng LOBINNI Ref.1023-7 (Phiên bản đặc biệt Limited)",
                                amount = 18,
                                price = 4450000,
                                description = "Tính năng SUN & MOON độc lạ với biểu tượng Nhật - Nguyệt tương phùng như ôm trọn cả vòng tuần hoàn ngày đêm trên cổ tay. Tính năng SUN & MOON độc lạ với biểu tượng Nhật - Nguyệt tương phùng như ôm trọn cả vòng tuần hoàn ngày đêm trên cổ tay. Trên nền mặt trắng với viền xung quanh vàng hồng sang trọng nổi bật, tinh xảo, đậm chất nghệ thuật tựa như những tia sáng mặt trời tỏa rạng, đẹp mê hồn.",
                                img = "/image/sp11.jpg"
                        },
                        new SanPham{
                                Id = 12,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 2,
                                machineId = 2,
                                nccId = 2,
                                name = "Đồng hồ nam chính hãng LOBINNI Ref.1023-8 (Phiên bản đặc biệt Limited)",
                                amount = 18,
                                price = 4450000,
                                description = "Tính năng SUN & MOON độc lạ với biểu tượng Nhật - Nguyệt tương phùng như ôm trọn cả vòng tuần hoàn ngày đêm trên cổ tay. Tính năng SUN & MOON độc lạ với biểu tượng Nhật - Nguyệt tương phùng như ôm trọn cả vòng tuần hoàn ngày đêm trên cổ tay. Trên nền mặt trắng với viền xung quanh vàng hồng sang trọng nổi bật, tinh xảo, đậm chất nghệ thuật tựa như những tia sáng mặt trời tỏa rạng, đẹp mê hồn.",
                                img = "/image/sp12.jpg"
                        },
                        new SanPham{
                                Id = 13,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 2,
                                machineId = 2,
                                nccId = 2,
                                name = "Đồng hồ nam chính hãng LOBINNI Ref.1023-9 (Phiên bản đặc biệt Limited)",
                                amount = 18,
                                price = 4450000,
                                description = "Tính năng SUN & MOON độc lạ với biểu tượng Nhật - Nguyệt tương phùng như ôm trọn cả vòng tuần hoàn ngày đêm trên cổ tay. Tính năng SUN & MOON độc lạ với biểu tượng Nhật - Nguyệt tương phùng như ôm trọn cả vòng tuần hoàn ngày đêm trên cổ tay. Trên nền mặt trắng với viền xung quanh vàng hồng sang trọng nổi bật, tinh xảo, đậm chất nghệ thuật tựa như những tia sáng mặt trời tỏa rạng, đẹp mê hồn.",
                                img = "/image/sp13.jpg"
                        },
                        new SanPham{
                                Id = 14,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 2,
                                machineId = 2,
                                nccId = 2,
                                name = "Đồng hồ nam chính hãng LOBINNI L9010-6",
                                amount = 23,
                                price = 5380000,
                                description = "Máy Miyota 8215: Cỗ máy Miyota hoạt động vô cùng mạnh mẽ. Citizen nhà sản xuất bộ máy Miyota luôn mang đến cho đồng hồ LOBINNI máy cơ nói riêng, đồng hồ cơ trên toàn thế giới nói chung những giá trị tuyệt diệu về độ bền, độ chính xác, chức năng cũng như giá cả! Đáp ứng mọi tiêu chuẩn khắt khe của người dùng.",
                                img = "/image/sp14.jpg"
                        },
                        new SanPham{
                                Id = 15,
                                LSPId = 1,
                                brandId = 1,
                                wireId = 3,
                                machineId = 2,
                                nccId = 3,
                                name = "Đồng hồ nam chính hãng LOBINNI L12030-1",
                                amount = 33,
                                price = 4650000,
                                description = "Lobinni luôn quan niệm chiếc đồng hồ là thứ ghi lại những khoảnh khắc quý giá nhất trong cuộc sống. Để có được những chiếc đồng hồ có chất lượng tốt nhất Lobinni luôn tuyển chọn những người thợ thủ công có tay nghề cao, ít nhất 10 năm kinh nghiệm trong ngành thiết kế và sản xuất đồng hồ.",
                                img = "/image/sp15.jpg"
                        },
                        new SanPham{
                                Id = 16,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 3,
                                machineId = 2,
                                nccId = 3,
                                name = "Đồng hồ nam chính hãng Teintop T7015-1",
                                amount = 48,
                                price = 1250000,
                                description = "KÍNH SAPPHIRE với độ chống xước hoàn hảo, độ cứng chỉ xếp sau kim cương. Đặc biệt, một số dòng sản phẩm sử dụng loại kính Sapphire cong cớn tạo chiều sâu cho mặt số. Với một mức giá tầm trung, đây có thể xem là ĐIỂM SÁNG đáng ghi nhận của cỗ máy thời gian này!",
                                img = "/image/sp16.jpg"
                        },
                        new SanPham{
                                Id = 17,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 3,
                                machineId = 2,
                                nccId = 3,
                                name = "Đồng hồ nam chính hãng Teintop T7015-2",
                                amount = 50,
                                price = 1250000,
                                description = "BỘ MÁY ĐA DẠNG: Từ những cỗ máy QUARTZ chính xác đến từng giây đếm nhịp tới những cỗ máy CƠ ráp máy Miyota Nhật Bản bền bỉ. Điều đặc biệt, trong tầm giá trên 1 TRIỆU, bạn sẽ khó tìm được một cỗ máy đẳng cấp và chất lượng như TeinTop T7015-4.",
                                img = "/image/sp17.jpg"
                        },
                        new SanPham{
                                Id = 18,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 3,
                                machineId = 2,
                                nccId = 3,
                                name = "Đồng hồ nam chính hãng Teintop T7015-3",
                                amount = 50,
                                price = 1250000,
                                description = "KÍNH SAPPHIRE với độ chống xước hoàn hảo, độ cứng chỉ xếp sau kim cương. Đặc biệt, một số dòng sản phẩm sử dụng loại kính Sapphire cong cớn tạo chiều sâu cho mặt số. Với một mức giá tầm trung, đây có thể xem là ĐIỂM SÁNG đáng ghi nhận của cỗ máy thời gian này!",
                                img = "/image/sp18.jpg"
                        },
                        new SanPham{
                                Id = 19,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 3,
                                machineId = 1,
                                nccId = 3,
                                name = "Đồng hồ nam chính hãng Teintop T7016-10",
                                amount = 50,
                                price = 1550000,
                                description = "BỘ MÁY ĐA DẠNG: Từ những cỗ máy QUARTZ chính xác đến từng giây đếm nhịp tới những cỗ máy CƠ ráp máy Miyota Nhật Bản bền bỉ. Điều đặc biệt, trong tầm giá trên 1 TRIỆU, bạn sẽ khó tìm được một cỗ máy đẳng cấp và chất lượng như TeinTop",
                                img = "/image/sp19.jpg"
                        },
                        new SanPham{
                                Id = 20,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 3,
                                machineId = 1,
                                nccId = 3,
                                name = "Đồng hồ nam chính hãng Teintop T7016-10",
                                amount = 46,
                                price = 1250000,
                                description = "BỘ MÁY ĐA DẠNG: Từ những cỗ máy QUARTZ chính xác đến từng giây đếm nhịp tới những cỗ máy CƠ ráp máy Miyota Nhật Bản bền bỉ. Điều đặc biệt, trong tầm giá trên 1 TRIỆU, bạn sẽ khó tìm được một cỗ máy đẳng cấp và chất lượng như TeinTop.",
                                img = "/image/sp20.jpg"
                        },
                        new SanPham{
                                Id = 21,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 3,
                                machineId = 1,
                                nccId = 3,
                                name = "Đồng hồ nam chính hãng Teintop T7015-5",
                                amount = 42,
                                price = 1250000,
                                description = "Phải nói rằng: Trong tầm giá chỉ hơn 1 triệu đồng, hiếm có thương hiệu nào “CHỊU CHƠI” như TEINTOP khi đầu tư 100% kính SAPPHIRE - loại kính cao cấp nhất hiện nay cho các sản phẩm của mình.",
                                img = "/image/sp21.jpg"
                        },
                        new SanPham{
                                Id = 22,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 3,
                                machineId = 1,
                                nccId = 3,
                                name = "Đồng hồ nam chính hãng Teintop T7015-6",
                                amount = 35,
                                price = 1250000,
                                description = "KÍNH SAPPHIRE với độ chống xước hoàn hảo, độ cứng chỉ xếp sau kim cương. Đặc biệt, một số dòng sản phẩm sử dụng loại kính Sapphire cong cớn tạo chiều sâu cho mặt số. Với một mức giá tầm trung, đây có thể xem là ĐIỂM SÁNG đáng ghi nhận của cỗ máy thời gian này!",
                                img = "/image/sp22.jpg"
                        },
                        new SanPham{
                                Id = 23,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 3,
                                machineId = 1,
                                nccId = 4,
                                name = "Đồng hồ nam chính hãng Teintop T7016-2",
                                amount = 37,
                                price = 1550000,
                                description = "BỘ MÁY ĐA DẠNG: Từ những cỗ máy QUARTZ chính xác đến từng giây đếm nhịp tới những cỗ máy CƠ ráp máy Miyota Nhật Bản bền bỉ. Điều đặc biệt, trong tầm giá trên 1 TRIỆU, bạn sẽ khó tìm được một cỗ máy đẳng cấp và chất lượng như TeinTop.",
                                img = "/image/sp23.jpg"
                        },
                        new SanPham{
                                Id = 24,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 3,
                                machineId = 1,
                                nccId = 4,
                                name = "Đồng hồ nam chính hãng Teintop T7016-1",
                                amount = 38,
                                price = 1550000,
                                description = "BỘ MÁY ĐA DẠNG: Từ những cỗ máy QUARTZ chính xác đến từng giây đếm nhịp tới những cỗ máy CƠ ráp máy Miyota Nhật Bản bền bỉ. Điều đặc biệt, trong tầm giá trên 1 TRIỆU, bạn sẽ khó tìm được một cỗ máy đẳng cấp và chất lượng như TeinTop.",
                                img = "/image/sp24.jpg"
                        },
                        new SanPham{
                                Id = 25,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 3,
                                machineId = 1,
                                nccId = 4,
                                name = "Đồng hồ nam chính hãng Teintop T7016-3",
                                amount = 47,
                                price = 1550000,
                                description = "BỘ MÁY ĐA DẠNG: Từ những cỗ máy QUARTZ chính xác đến từng giây đếm nhịp tới những cỗ máy CƠ ráp máy Miyota Nhật Bản bền bỉ. Điều đặc biệt, trong tầm giá trên 1 TRIỆU, bạn sẽ khó tìm được một cỗ máy đẳng cấp và chất lượng như TeinTop.",
                                img = "/image/sp25.jpg"
                        },
                        new SanPham{
                                Id = 26,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 3,
                                machineId = 1,
                                nccId = 4,
                                name = "Đồng hồ nam chính hãng Teintop T7016-4",
                                amount = 50,
                                price = 1550000,
                                description = "BỘ MÁY ĐA DẠNG: Từ những cỗ máy QUARTZ chính xác đến từng giây đếm nhịp tới những cỗ máy CƠ ráp máy Miyota Nhật Bản bền bỉ. Điều đặc biệt, trong tầm giá trên 1 TRIỆU, bạn sẽ khó tìm được một cỗ máy đẳng cấp và chất lượng như TeinTop.",
                                img = "/image/sp26.jpg"
                        },
                        new SanPham{
                                Id = 27,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 2,
                                machineId = 1,
                                nccId = 6,
                                name = "Đồng hồ nam chính hãng Teintop T7016-5",
                                amount = 32,
                                price = 1550000,
                                description = "KÍNH SAPPHIRE với độ chống xước hoàn hảo, độ cứng chỉ xếp sau kim cương. Đặc biệt, một số dòng sản phẩm sử dụng loại kính Sapphire cong cớn tạo chiều sâu cho mặt số. Với một mức giá tầm trung, đây có thể xem là ĐIỂM SÁNG đáng ghi nhận của cỗ máy thời gian này!",
                                img = "/image/sp27.jpg"
                        },
                        new SanPham{
                                Id = 28,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 2,
                                machineId = 1,
                                nccId = 6,
                                name = "Đồng hồ nam chính hãng Teintop T7016-6",
                                amount = 33,
                                price = 1550000,
                                description = "KÍNH SAPPHIRE với độ chống xước hoàn hảo, độ cứng chỉ xếp sau kim cương. Đặc biệt, một số dòng sản phẩm sử dụng loại kính Sapphire cong cớn tạo chiều sâu cho mặt số. Với một mức giá tầm trung, đây có thể xem là ĐIỂM SÁNG đáng ghi nhận của cỗ máy thời gian này!",
                                img = "/image/sp28.jpg"
                        },
                        new SanPham{
                                Id = 29,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 2,
                                machineId = 1,
                                nccId = 6,
                                name = "Đồng hồ nam chính hãng Teintop T7016-7",
                                amount = 40,
                                price = 1550000,
                                description = "KÍNH SAPPHIRE với độ chống xước hoàn hảo, độ cứng chỉ xếp sau kim cương. Đặc biệt, một số dòng sản phẩm sử dụng loại kính Sapphire cong cớn tạo chiều sâu cho mặt số. Với một mức giá tầm trung, đây có thể xem là ĐIỂM SÁNG đáng ghi nhận của cỗ máy thời gian này!",
                                img = "/image/sp29.jpg"
                        },
                        new SanPham{
                                Id = 30,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 2,
                                machineId = 1,
                                nccId = 6,
                                name = "Đồng hồ nam chính hãng Teintop T7016-8",
                                amount = 40,
                                price = 1550000,
                                description = "KÍNH SAPPHIRE với độ chống xước hoàn hảo, độ cứng chỉ xếp sau kim cương. Đặc biệt, một số dòng sản phẩm sử dụng loại kính Sapphire cong cớn tạo chiều sâu cho mặt số. Với một mức giá tầm trung, đây có thể xem là ĐIỂM SÁNG đáng ghi nhận của cỗ máy thời gian này!",
                                img = "/image/sp30.jpg"
                        },
                        new SanPham{
                                Id = 31,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 2,
                                machineId = 1,
                                nccId = 6,
                                name = "Đồng hồ nam chính hãng Teintop T7016-9",
                                amount = 40,
                                price = 1550000,
                                description = "KÍNH SAPPHIRE với độ chống xước hoàn hảo, độ cứng chỉ xếp sau kim cương. Đặc biệt, một số dòng sản phẩm sử dụng loại kính Sapphire cong cớn tạo chiều sâu cho mặt số. Với một mức giá tầm trung, đây có thể xem là ĐIỂM SÁNG đáng ghi nhận của cỗ máy thời gian này!",
                                img = "/image/sp31.jpg"
                        },
                        new SanPham{
                                Id = 32,
                                LSPId = 1,
                                brandId = 3,
                                wireId = 2,
                                machineId = 1,
                                nccId = 7,
                                name = "Đồng hồ nam chính hãng Teintop T7017-1",
                                amount = 30,
                                price = 1860000,
                                description = "Sở dĩ tôi đánh giá rất cao cỗ máy này bởi: Trong tầm giá trên hơn1 triệu, bạn sẽ khó có thể tìm được một chiếc đồng hồ hội tụ nhiều ĐIỂM SÁNG như TEINTOP T7017-1: độ chống nước tới 30M, sử dụng kỹ nghệ đánh vân Guilloché tinh xảo và đặc biệt là ráp kính SAPPHIRE với độ chống xước gần như tuyệt đối.",
                                img = "/image/sp32.jpg"
                        },
                    });
                }
            }

            if (temp)
            {
                context.SaveChanges();
            }
        }
    }
}