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
    public class ChiTietPNController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly IChiTietPNRepository ChiTietPNRepository;
        private readonly JwtKhachHangService jwtKhachHang;
        private readonly JwtNhanVienService jwtNhanVien;
        private readonly INhanVienRepository nhanVienRepository;
        private readonly IKhachHangRepository KhachHangRepository;
        private readonly IHoaDonRepository HoaDonRepository;
        public ChiTietPNController(IChiTietPNRepository ChiTietPNRepository, IKhachHangRepository KhachHangRepository,
        JwtKhachHangService jwtKhachHang, IHoaDonRepository HoaDonRepository, JwtNhanVienService jwtNhanVien,
        INhanVienRepository nhanVienRepository) {
            this.ChiTietPNRepository = ChiTietPNRepository;
            this.KhachHangRepository = KhachHangRepository;
            this.jwtKhachHang = jwtKhachHang;
            this.HoaDonRepository = HoaDonRepository;
            this.jwtNhanVien = jwtNhanVien;
            this.nhanVienRepository = nhanVienRepository;
        }

        [HttpGet]
        public IEnumerable<ChiTietPN> GetAll() {
            
            return this.ChiTietPNRepository.ChiTietPN_GetAll();
        }

        [HttpGet("{couponId}")]
        public IEnumerable<ChiTietPN> GetBycouponId(int couponId) {
            // Phần xác thực tài khoản khách hàng để thực hiện thao tác sửa thông tin khách hàng
            var jwt = Request.Cookies["jwt-khachhang"];
            if(jwt == null) {
                return null;
            }
            var token = jwtKhachHang.Verify(jwt);
            var user = token.Issuer;
            var kh = KhachHangRepository.KhachHang_GetByUser(user);

            if (kh == null)
            {
                return null;
            }
            var temp = HoaDonRepository.HoaDon_CheckUserKHAndId(couponId, kh.user);
            if(!temp) {
                return null;
            }
            return this.ChiTietPNRepository.ChiTietPN_GetBycouponId(couponId);
        }

        [HttpGet("admin/{couponId}")]
        public IEnumerable<ChiTietPN> GetBycouponIdAdmin(int couponId) {
            // Phần xác thực tài khoản khách hàng để thực hiện thao tác sửa thông tin khách hàng
            var jwt = Request.Cookies["jwt-nhanvien"];
            if(jwt == null) {
                return null;
            }
            var token = jwtNhanVien.Verify(jwt);
            var user = token.Issuer;
            var nv = nhanVienRepository.NhanVien_GetByUser(user);

            if (nv == null) {
                return null;
            }
            
            return this.ChiTietPNRepository.ChiTietPN_GetBycouponId(couponId);
        }

        // [HttpGet("{id}")]
        // public ActionResult<ChiTietPN> GetById(int id) {
        //     return this.ChiTietPNRepository.ChiTietPN_GetById(id);
        // }

        // [HttpPost]
        // public ActionResult<ChiTietPN> AddCTPN(ChiTietPNDto ctPNdto) {

        //     if(ModelState.IsValid){
        //         try {
        //             ChiTietPN ctPN = new ChiTietPN();

        //             // Mapping
        //             // ctPN.LSPId = PNdto.LSPId;
        //             ctPN.couponId = PNdto.couponId;
        //             ctPN.productId = PNdto.productId;
        //             ctPN.name  = PNdto.name ;
        //             ctPN.ammount = PNdto.ammount;
        //             ctPN.price = PNdto.price;
        //             ctPN.img = PNdto.img;

        //             var CTPN = this.ChiTietPNRepository.ChiTietPN_Add(ctPN);
        //             return Created("success", CTPN);
        //         }
        //         catch(Exception e) {
        //             return StatusCode(StatusCodes.Status500InternalServerError);
        //         }
        //     }

        //     return StatusCode(StatusCodes.Status500InternalServerError);
        // }

        // [HttpPut("{id}")]
        // public ActionResult<ChiTietPN> UpdateCTPN([FromBody] ChiTietPNDto PNdto, int id) {
        //     if(ModelState.IsValid) {
        //         try {
        //             var PN = ChiTietPNRepository.ChiTietPN_GetById(id);

        //             if(PN == null || PNdto.Id != id) {
        //                 return NotFound();
        //             }

        //             // Mapping
        //             PN.LSPId = PNdto.LSPId;
        //             PN.KHuser = PNdto.KHuser;
        //             PN.NVuser = PNdto.NVuser;
        //             PN.phone = PNdto.phone;
        //             PN.address = PNdto.address;
        //             PN.date_receice = PNdto.date_receice;
        //             PN.date_order = PNdto.date_order;
        //             PN.total = PNdto.total;
        //             PN.status = 0;

        //             var PN = this.ChiTietPNRepository.ChiTietPN_Update(PN);
        //             return Created("success", PN);
        //         }
        //         catch(Exception e) {
        //             return StatusCode(StatusCodes.Status500InternalServerError);
        //         }
        //     }
        //     return StatusCode(StatusCodes.Status500InternalServerError);
        // }

        // [HttpDelete("{id}")]
        // public ActionResult DeleteSP(int id) {
        //     var PN = ChiTietPNRepository.ChiTietPN_GetById(id);
        //     if(PN == null) {
        //         return NotFound();
        //     }
        //     ChiTietPNRepository.ChiTietPN_Delete(PN);
        //     return Ok(new { messgae = "Ok" });
        // }

        // [HttpPost("filter-admin")]
        // public ViewChiTietPNAdminDto FilterAdmin(FilterDataAdminDto data) {
        //     int count;
        //     var ChiTietPNs = ChiTietPNRepository.ChiTietPN_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
        //     var ListCTPN = new PaginatedList<ChiTietPN>(ChiTietPNs, count, data.pageIndex, pageSize);
        //     ViewChiTietPNAdminDto view = new ViewChiTietPNAdminDto() {
        //         ListCTPN = ListCTPN,
        //         search = data.search,
        //         sort = data.sort,
        //         pageIndex = data.pageIndex,
        //         pageSize = this.pageSize,
        //         count = count,
        //         range = this.range,
        //         totalPage = ListCTPN.TotalPages
        //     };
        //     return view;
        // }
    }
}