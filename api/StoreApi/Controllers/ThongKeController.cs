using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApi.DTOs;
using StoreApi.Interfaces;
using StoreApi.Services;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongKeController : ControllerBase
    {
        private readonly IHoaDonRepository hoaDonRepository;
        private readonly IChiTietHDRepository chiTietHDRepository;
        private readonly INhanVienRepository nhanVienRepository;
        private readonly JwtNhanVienService jwtNhanVien;
        private readonly IQuyenRepository quyenRepository;
        public ThongKeController(IHoaDonRepository hoaDonRepository, IChiTietHDRepository chiTietHDRepository, INhanVienRepository nhanVienRepository,
        JwtNhanVienService jwtNhanVien, IQuyenRepository quyenRepository)
        {
            this.hoaDonRepository = hoaDonRepository;
            this.chiTietHDRepository = chiTietHDRepository;
            this.nhanVienRepository = nhanVienRepository;
            this.jwtNhanVien = jwtNhanVien;
            this.quyenRepository = quyenRepository;
        }

        [HttpPost("doanhthu-year")]
        public Array DoanhThuYear(FilterBeginEndTheoNamDto dto)
        {
            if (ModelState.IsValid)
            {
                // Phần xác thực tài khoản nhân viên
                var jwt = Request.Cookies["jwt-nhanvien"];
                if (jwt == null)
                {
                    return null;
                }
                var token = jwtNhanVien.Verify(jwt);
                var user = token.Issuer;
                var nv = nhanVienRepository.NhanVien_GetByUser(user);

                if (nv == null || nv.status == 0)
                {
                    return null;
                }

                var quyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "ThongKe");

                // Kiểm tra nhân viên có quyền thống kê ko
                if (!quyen)
                {
                    return null;
                }

                var listHD = hoaDonRepository.HoaDon_FilterBeginEndInYear(dto.begin, dto.end);
                long val = 0;
                int year = 0;
                IDictionary<int, long> res = new Dictionary<int, long>();
                foreach (var item in listHD)
                {
                    year = item.date_order.Year;
                    if (res.TryGetValue(year, out val))
                    {
                        res[year] = val + item.total;
                    }
                    else
                    {
                        res.Add(year, item.total);
                    }
                }

                return res.ToArray();
            }
            return null;
        }

        [HttpPost("doanhthu-month")]
        public Array DoanhThuMonth(FilterBeginEndTheoThangDto dto)
        {
            if (ModelState.IsValid)
            {
                // Phần xác thực tài khoản nhân viên
                var jwt = Request.Cookies["jwt-nhanvien"];
                if (jwt == null)
                {
                    return null;
                }
                var token = jwtNhanVien.Verify(jwt);
                var user = token.Issuer;
                var nv = nhanVienRepository.NhanVien_GetByUser(user);

                if (nv == null || nv.status == 0)
                {
                    return null;
                }

                var quyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "ThongKe");

                // Kiểm tra nhân viên có quyền thống kê ko
                if (!quyen)
                {
                    return null;
                }

                var listHD = hoaDonRepository.HoaDon_FilterBeginEndInMonth(dto.year, dto.begin, dto.end);
                long val = 0;
                int month = 0;
                IDictionary<int, long> res = new Dictionary<int, long>();
                foreach (var item in listHD)
                {
                    month = item.date_order.Month;
                    if (res.TryGetValue(month, out val))
                    {
                        res[month] = val + item.total;
                    }
                    else
                    {
                        res.Add(month, item.total);
                    }
                }

                return res.ToArray();
            }
            return null;
        }

        [HttpPost("bill-year")]
        public Array DonHangYear(FilterBeginEndTheoNamDto dto)
        {
            if (ModelState.IsValid)
            {
                // Phần xác thực tài khoản nhân viên
                var jwt = Request.Cookies["jwt-nhanvien"];
                if (jwt == null)
                {
                    return null;
                }
                var token = jwtNhanVien.Verify(jwt);
                var user = token.Issuer;
                var nv = nhanVienRepository.NhanVien_GetByUser(user);

                if (nv == null || nv.status == 0)
                {
                    return null;
                }

                var quyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "ThongKe");

                // Kiểm tra nhân viên có quyền thống kê ko
                if (!quyen)
                {
                    return null;
                }

                var listHD = hoaDonRepository.HoaDon_FilterBeginEndInYear(dto.begin, dto.end);
                int val = 0;
                int year = 0;
                IDictionary<int, int> res = new Dictionary<int, int>();
                foreach (var item in listHD)
                {
                    year = item.date_order.Year;
                    if (res.TryGetValue(year, out val))
                    {
                        res[year] = val + 1;
                    }
                    else
                    {
                        res.Add(year, 1);
                    }
                }

                return res.ToArray();
            }
            return null;
        }

        [HttpPost("bill-month")]
        public Array DonHangMonth(FilterBeginEndTheoThangDto dto)
        {
            if (ModelState.IsValid)
            {
                // Phần xác thực tài khoản nhân viên
                var jwt = Request.Cookies["jwt-nhanvien"];
                if (jwt == null)
                {
                    return null;
                }
                var token = jwtNhanVien.Verify(jwt);
                var user = token.Issuer;
                var nv = nhanVienRepository.NhanVien_GetByUser(user);

                if (nv == null || nv.status == 0)
                {
                    return null;
                }

                var quyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "ThongKe");

                // Kiểm tra nhân viên có quyền thống kê ko
                if (!quyen)
                {
                    return null;
                }

                var listHD = hoaDonRepository.HoaDon_FilterBeginEndInMonth(dto.year, dto.begin, dto.end);
                int val = 0;
                int month = 0;
                IDictionary<int, int> res = new Dictionary<int, int>();
                foreach (var item in listHD)
                {
                    month = item.date_order.Month;
                    if (res.TryGetValue(month, out val))
                    {
                        res[month] = val + 1;
                    }
                    else
                    {
                        res.Add(month, 1);
                    }
                }

                return res.ToArray();
            }
            return null;
        }

        [HttpPost("product-year")]
        public Array ProductYear(FilterBeginEndTheoNamDto dto)
        {
            if (ModelState.IsValid)
            {
                // Phần xác thực tài khoản nhân viên
                var jwt = Request.Cookies["jwt-nhanvien"];
                if (jwt == null)
                {
                    return null;
                }
                var token = jwtNhanVien.Verify(jwt);
                var user = token.Issuer;
                var nv = nhanVienRepository.NhanVien_GetByUser(user);

                if (nv == null || nv.status == 0)
                {
                    return null;
                }

                var quyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "ThongKe");

                // Kiểm tra nhân viên có quyền thống kê ko
                if (!quyen)
                {
                    return null;
                }

                var listHD = hoaDonRepository.HoaDon_FilterBeginEndInYear(dto.begin, dto.end);

                List<int> listBillId = new List<int>();
                foreach (var item in listHD)
                {
                    listBillId.Add(item.Id);
                }

                var listCTHD = chiTietHDRepository.ChiTietHD_GetByListBill(listBillId);

                IDictionary<string, int> res = new Dictionary<string, int>();
                int val = 0;
                string key = "";
                foreach (var item in listCTHD)
                {
                    key = item.productId + "-" + item.name;
                    if (res.TryGetValue(key, out val))
                    {
                        res[key] = val + item.amount;
                    }
                    else
                    {
                        res.Add(key, item.amount);
                    }
                }

                return res.ToArray();
            }
            return null;
        }

        [HttpPost("product-month")]
        public Array ProductMonth(FilterBeginEndTheoThangDto dto)
        {
            if (ModelState.IsValid)
            {
                // Phần xác thực tài khoản nhân viên
                var jwt = Request.Cookies["jwt-nhanvien"];
                if (jwt == null)
                {
                    return null;
                }
                var token = jwtNhanVien.Verify(jwt);
                var user = token.Issuer;
                var nv = nhanVienRepository.NhanVien_GetByUser(user);

                if (nv == null || nv.status == 0)
                {
                    return null;
                }

                var quyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "ThongKe");

                // Kiểm tra nhân viên có quyền thống kê ko
                if (!quyen)
                {
                    return null;
                }
                
                var listHD = hoaDonRepository.HoaDon_FilterBeginEndInMonth(dto.year, dto.begin, dto.end);

                List<int> listBillId = new List<int>();
                foreach (var item in listHD)
                {
                    listBillId.Add(item.Id);
                }

                var listCTHD = chiTietHDRepository.ChiTietHD_GetByListBill(listBillId);

                IDictionary<string, int> res = new Dictionary<string, int>();
                int val = 0;
                string key = "";
                foreach (var item in listCTHD)
                {
                    key = item.productId + "-" + item.name;
                    if (res.TryGetValue(key, out val))
                    {
                        res[key] = val + item.amount;
                    }
                    else
                    {
                        res.Add(key, item.amount);
                    }
                }

                return res.ToArray();
            }
            return null;
        }
    }
}