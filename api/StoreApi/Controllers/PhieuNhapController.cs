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
    public class PhieuNhapController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly IPhieuNhapRepository PhieuNhapRepository;
        private readonly INhanVienRepository NhanVienRepository;
        private readonly JwtNhanVienService jwtNhanVien;
        // chỗ này không chắc
        public PhieuNhapController(IPhieuNhapRepository PhieuNhapRepository, JwtNhanVienService jwtNhanVien,
        INhanVienRepository NhanVienRepository)
        {
            this.PhieuNhapRepository = PhieuNhapRepository;
            this.jwtNhanVien = jwtNhanVien;
            this.NhanVienRepository = NhanVienRepository;
        }

        [HttpGet]
        public IEnumerable<PhieuNhap> GetAll()
        {
            return this.PhieuNhapRepository.PhieuNhap_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<PhieuNhap> GetById(int id)
        {
            return this.PhieuNhapRepository.PhieuNhap_GetById(id);
        }
// Không chắc phần này
        [HttpGet("getByUserNV/{pageIndex}")]
        public ActionResult<ViewBillShopDto> GetByUserNV(int pageIndex)
        {
            // Phần xác thực tài khoản khách hàng để thực hiện thao tác sửa thông tin khách hàng
            var jwt = Request.Cookies["jwt-nhanvien"];
            if (jwt == null) {
                return null;
            }
            var token = jwtNhanVien.Verify(jwt);
            var user = token.Issuer;

            int count;

            var PhieuNhaps = PhieuNhapRepository.PhieuNhap_GetByUserNV(user, pageIndex, pageSize, out count);
            
            var ListPN = new PaginatedList<PhieuNhap>(PhieuNhaps, count, pageIndex, pageSize);
            ViewBillShopDto view = new ViewBillShopDto() {
                ListPN = ListPN,
                pageIndex = pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListPN.TotalPages
            };
            return view;
        }

        // [HttpPost]
        // public ActionResult<PhieuNhap> AddHD(PhieuNhapDto hddto) {

        //     if(ModelState.IsValid){
        //         try {
        //             PhieuNhap hd = new PhieuNhap();

        //             // Mapping
        //             // hd.LSPId = hddto.LSPId;
        //             hd.KHuser = hddto.KHuser;
        //             hd.NVuser = hddto.NVuser;
        //             hd.phone = hddto.phone;
        //             hd.address = hddto.address;
        //             hd.date_receice = hddto.date_receice;
        //             hd.date_order = hddto.date_order;
        //             hd.total = hddto.total;
        //             hd.status = 0;

        //             var HD = this.PhieuNhapRepository.PhieuNhap_Add(hd);
        //             return Created("success", HD);
        //         }
        //         catch(Exception e) {
        //             return StatusCode(StatusCodes.Status500InternalServerError);
        //         }
        //     }

        //     return StatusCode(StatusCodes.Status500InternalServerError);
        // }


        // Chỉ sửa trạng thái của hóa đơn 
        [HttpPut("{id}")]
        public ActionResult<PhieuNhap> UpdatePN([FromBody] PhieuNhapDto pndto, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pn = PhieuNhapRepository.PhieuNhap_GetById(id);

                    if (pn == null || pndto.Id != id)
                    {
                        return NotFound();
                    }
                    // pn.status = pndto.status;
                    // Mapping
                    // Trạng thái gồm có
                    //     -   Đang xử lý : 1
                    //     -   Đang giao hàng: 2
                    //     -   Đã giao hàng : 3
                    //     -   Đã hủy đơn hàng
                    if (pn.status < pndto.status)
                    {
                        pn.status = pndto.status;
                    }
                    else
                    {
                        return BadRequest(new { message = "Cập nhật trạng thái không thành công!" });
                    }

                    var PN = this.PhieuNhapRepository.PhieuNhap_Update(pn);
                    return Ok(PN);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePN(int id)
        {
            var PN = PhieuNhapRepository.PhieuNhap_GetById(id);
            if (PN == null)
            {
                return NotFound();
            }
            PhieuNhapRepository.PhieuNhap_Delete(PN);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewPhieuNhapAdminDto FilterAdmin(FilterPhieuNhapDto data)
        {
            int count;
            var PhieuNhaps = PhieuNhapRepository.PhieuNhap_FilterAdmin(data.search, data.status, data.pageIndex, pageSize, out count);
            var ListPN = new PaginatedList<PhieuNhap>(PhieuNhaps, count, data.pageIndex, pageSize);
            ViewPhieuNhapAdminDto view = new ViewPhieuNhapAdminDto()
            {
                ListPN = ListPN,
                search = data.search,
                status = data.status,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListPN.TotalPages
            };
            return view;
        }
    }
}