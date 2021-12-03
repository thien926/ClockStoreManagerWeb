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
    public class HoaDonController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly IHoaDonRepository HoaDonRepository;
        private readonly IKhachHangRepository khachHangRepository;
        private readonly JwtKhachHangService jwtKhachHang;
        public HoaDonController(IHoaDonRepository HoaDonRepository, JwtKhachHangService jwtKhachHang,
        IKhachHangRepository khachHangRepository)
        {
            this.HoaDonRepository = HoaDonRepository;
            this.jwtKhachHang = jwtKhachHang;
            this.khachHangRepository = khachHangRepository;
        }

        [HttpGet]
        public IEnumerable<HoaDon> GetAll()
        {
            return this.HoaDonRepository.HoaDon_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<HoaDon> GetById(int id)
        {
            return this.HoaDonRepository.HoaDon_GetById(id);
        }

        [HttpGet("getByUserKH/{pageIndex}")]
        public ActionResult<ViewBillShopDto> GetByUserKH(int pageIndex)
        {
            // Phần xác thực tài khoản khách hàng để thực hiện thao tác sửa thông tin khách hàng
            var jwt = Request.Cookies["jwt-khachhang"];
            if (jwt == null) {
                return null;
            }
            var token = jwtKhachHang.Verify(jwt);
            var user = token.Issuer;

            int count;

            var HoaDons = HoaDonRepository.HoaDon_GetByUserKH(user, pageIndex, pageSize, out count);
            
            var ListHD = new PaginatedList<HoaDon>(HoaDons, count, pageIndex, pageSize);
            ViewBillShopDto view = new ViewBillShopDto() {
                ListHD = ListHD,
                pageIndex = pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListHD.TotalPages
            };
            return view;
        }

        // [HttpPost]
        // public ActionResult<HoaDon> AddHD(HoaDonDto hddto) {

        //     if(ModelState.IsValid){
        //         try {
        //             HoaDon hd = new HoaDon();

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

        //             var HD = this.HoaDonRepository.HoaDon_Add(hd);
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
        public ActionResult<HoaDon> UpdateHD([FromBody] HoaDonDto hddto, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var hd = HoaDonRepository.HoaDon_GetById(id);

                    if (hd == null || hddto.Id != id)
                    {
                        return NotFound();
                    }
                    // hd.status = hddto.status;
                    // Mapping
                    // Trạng thái gồm có
                    //     -   Đang xử lý : 1
                    //     -   Đang giao hàng: 2
                    //     -   Đã giao hàng : 3
                    //     -   Đã hủy đơn hàng
                    if (hd.status < hddto.status)
                    {
                        hd.status = hddto.status;
                    }
                    else
                    {
                        return BadRequest(new { message = "Cập nhật trạng thái không thành công!" });
                    }

                    var HD = this.HoaDonRepository.HoaDon_Update(hd);
                    return Ok(HD);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteHD(int id)
        {
            var HD = HoaDonRepository.HoaDon_GetById(id);
            if (HD == null)
            {
                return NotFound();
            }
            HoaDonRepository.HoaDon_Delete(HD);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewHoaDonAdminDto FilterAdmin(FilterHoaDonDto data)
        {
            int count;
            var HoaDons = HoaDonRepository.HoaDon_FilterAdmin(data.search, data.status, data.pageIndex, pageSize, out count);
            var ListHD = new PaginatedList<HoaDon>(HoaDons, count, data.pageIndex, pageSize);
            ViewHoaDonAdminDto view = new ViewHoaDonAdminDto()
            {
                ListHD = ListHD,
                search = data.search,
                status = data.status,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListHD.TotalPages
            };
            return view;
        }
    }
}