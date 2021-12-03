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
        private readonly JwtNhanVienService jwtNhanVien;
        private readonly INhanVienRepository NhanVienRepository;
        private readonly IPhieuNhapRepository PhieuNhapRepository;
        //không chắc phần này
        public ChiTietPNController(IChiTietPNRepository ChiTietPNRepository, INhanVienRepository NhanVienRepository,
        JwtNhanVienService jwtNhanVien, IPhieuNhapRepository PhieuNhapRepository) {
            this.ChiTietPNRepository = ChiTietPNRepository;
            this.NhanVienRepository = NhanVienRepository;
            this.jwtNhanVien = jwtNhanVien;
            this.PhieuNhapRepository = PhieuNhapRepository;
        }

        [HttpGet]
        public IEnumerable<ChiTietPN> GetAll() {
            
            return this.ChiTietPNRepository.ChiTietPN_GetAll();
        }

//không chắc phần này
        [HttpGet("{couponId}")]
        public IEnumerable<ChiTietPN> GetByCouponId(int couponId) {
            // Phần xác thực tài khoản khách hàng để thực hiện thao tác sửa thông tin khách hàng
            var jwt = Request.Cookies["jwt-nhanvien"];
            if(jwt == null) {
                return null;
            }
            var token = jwtNhanVien.Verify(jwt);
            var user = token.Issuer;
            var nv = NhanVienRepository.NhanVien_GetByUser(user);

            if (nv == null)
            {
                return null;
            }
            var temp = PhieuNhapRepository.PhieuNhap_CheckUserNVAndId(couponId, nv.user);
            if(!temp) {
                return null;
            }
            return this.ChiTietPNRepository.ChiTietPN_GetByCouponId(couponId);
        }

        // [HttpGet("{id}")]
        // public ActionResult<ChiTietPN> GetById(int id) {
        //     return this.ChiTietPNRepository.ChiTietPN_GetById(id);
        // }

        // [HttpPost]
        // public ActionResult<ChiTietPN> AddCTHD(ChiTietPNDto cthddto) {

        //     if(ModelState.IsValid){
        //         try {
        //             ChiTietPN cthd = new ChiTietPN();

        //             // Mapping
        //             // cthd.LSPId = hddto.LSPId;
        //             cthd.couponId = hddto.couponId;
        //             cthd.productId = hddto.productId;
        //             cthd.name  = hddto.name ;
        //             cthd.ammount = hddto.ammount;
        //             cthd.price = hddto.price;
        //             cthd.img = hddto.img;

        //             var CTHD = this.ChiTietPNRepository.ChiTietPN_Add(cthd);
        //             return Created("success", CTHD);
        //         }
        //         catch(Exception e) {
        //             return StatusCode(StatusCodes.Status500InternalServerError);
        //         }
        //     }

        //     return StatusCode(StatusCodes.Status500InternalServerError);
        // }

        // [HttpPut("{id}")]
        // public ActionResult<ChiTietPN> UpdateCTHD([FromBody] ChiTietPNDto hddto, int id) {
        //     if(ModelState.IsValid) {
        //         try {
        //             var hd = ChiTietPNRepository.ChiTietPN_GetById(id);

        //             if(hd == null || hddto.Id != id) {
        //                 return NotFound();
        //             }

        //             // Mapping
        //             hd.LSPId = hddto.LSPId;
        //             hd.KHuser = hddto.KHuser;
        //             hd.NVuser = hddto.NVuser;
        //             hd.phone = hddto.phone;
        //             hd.address = hddto.address;
        //             hd.date_receice = hddto.date_receice;
        //             hd.date_order = hddto.date_order;
        //             hd.total = hddto.total;
        //             hd.status = 0;

        //             var HD = this.ChiTietPNRepository.ChiTietPN_Update(hd);
        //             return Created("success", HD);
        //         }
        //         catch(Exception e) {
        //             return StatusCode(StatusCodes.Status500InternalServerError);
        //         }
        //     }
        //     return StatusCode(StatusCodes.Status500InternalServerError);
        // }

        // [HttpDelete("{id}")]
        // public ActionResult DeleteSP(int id) {
        //     var HD = ChiTietPNRepository.ChiTietPN_GetById(id);
        //     if(HD == null) {
        //         return NotFound();
        //     }
        //     ChiTietPNRepository.ChiTietPN_Delete(HD);
        //     return Ok(new { messgae = "Ok" });
        // }

        // [HttpPost("filter-admin")]
        // public ViewChiTietPNAdminDto FilterAdmin(FilterDataAdminDto data) {
        //     int count;
        //     var ChiTietPNs = ChiTietPNRepository.ChiTietPN_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
        //     var ListCTHD = new PaginatedList<ChiTietPN>(ChiTietPNs, count, data.pageIndex, pageSize);
        //     ViewChiTietPNAdminDto view = new ViewChiTietPNAdminDto() {
        //         ListCTHD = ListCTHD,
        //         search = data.search,
        //         sort = data.sort,
        //         pageIndex = data.pageIndex,
        //         pageSize = this.pageSize,
        //         count = count,
        //         range = this.range,
        //         totalPage = ListCTHD.TotalPages
        //     };
        //     return view;
        // }
    }
}