using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.DTOs;
using StoreApi.Interfaces;
using StoreApi.Models;
using StoreApi.Services;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChiTietHDController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly IChiTietHDRepository ChiTietHDRepository;
        private readonly JwtKhachHangService jwtKhachHang;
        private readonly JwtNhanVienService jwtNhanVien;
        private readonly INhanVienRepository nhanVienRepository;
        private readonly IKhachHangRepository KhachHangRepository;
        private readonly IHoaDonRepository HoaDonRepository;
        public ChiTietHDController(IChiTietHDRepository ChiTietHDRepository, IKhachHangRepository KhachHangRepository,
        JwtKhachHangService jwtKhachHang, IHoaDonRepository HoaDonRepository, JwtNhanVienService jwtNhanVien,
        INhanVienRepository nhanVienRepository) {
            this.ChiTietHDRepository = ChiTietHDRepository;
            this.KhachHangRepository = KhachHangRepository;
            this.jwtKhachHang = jwtKhachHang;
            this.HoaDonRepository = HoaDonRepository;
            this.jwtNhanVien = jwtNhanVien;
            this.nhanVienRepository = nhanVienRepository;
        }

        // Client ko gọi api này nên bỏ
        // [HttpGet]
        // public IEnumerable<ChiTietHD> GetAll() {
            
        //     return this.ChiTietHDRepository.ChiTietHD_GetAll();
        // }

        // User Page
        // Xem chi tiết hóa đơn của khách hàng
        [HttpGet("{billId}")]
        public IEnumerable<ChiTietHD> GetByBillId(int billId) {
            // Phần xác thực tài khoản khách hàng để thực hiện thao tác sửa thông tin khách hàng
            var jwt = Request.Cookies["jwt-khachhang"];
            if(jwt == null) {
                return null;
            }
            var token = jwtKhachHang.Verify(jwt);
            var user = token.Issuer;
            var kh = KhachHangRepository.KhachHang_GetByUser(user);

            // Nếu không tìm thấy tài khoản khách hàng hoặc tài khoản bị khóa thì trả về null
            if (kh == null || kh.status == 0)
            {
                return null;
            }

            // Kiểm tra hóa đơn này phải của khách hàng đang đăng nhập ko
            var temp = HoaDonRepository.HoaDon_CheckUserKHAndId(billId, kh.user);
            if(!temp) {
                return null;
            }
            return this.ChiTietHDRepository.ChiTietHD_GetByBillId(billId);
        }

        // HoaDon Page - Admin 
        // Nhân viên không bị khóa tài khoản có quyền xem chi tiết hóa đơn
        [HttpGet("admin/{billId}")]
        public IEnumerable<ChiTietHD> GetByBillIdAdmin(int billId) {
            // Phần xác thực tài khoản khách hàng 
            var jwt = Request.Cookies["jwt-nhanvien"];
            if(jwt == null) {
                return null;
            }
            var token = jwtNhanVien.Verify(jwt);
            var user = token.Issuer;
            var nv = nhanVienRepository.NhanVien_GetByUser(user);

            // Không tìm thấy nhân viên hoặc tài khoản nhân viên bị khóa thì trả về null
            if (nv == null || nv.status == 0) {
                return null;
            }
            
            return this.ChiTietHDRepository.ChiTietHD_GetByBillId(billId);
        }
    }
}