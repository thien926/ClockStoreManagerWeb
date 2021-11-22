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
        public HoaDonController(IHoaDonRepository HoaDonRepository) {
            this.HoaDonRepository = HoaDonRepository;
        }

        [HttpGet]
        public IEnumerable<HoaDon> GetAll() {
            return this.HoaDonRepository.HoaDon_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<HoaDon> GetById(int id) {
            return this.HoaDonRepository.HoaDon_GetById(id);
        }

        [HttpPost]
        public ActionResult<HoaDon> AddSP(HoaDonDto hddto) {

            if(ModelState.IsValid){
                try {
                    HoaDon hd = new HoaDon();

                    // Mapping
                    // hd.LSPId = hddto.LSPId;
                    hd.KHuser = hddto.KHuser;
                    hd.NVuser = hddto.NVuser;
                    hd.phone = hddto.phone;
                    hd.address = hddto.address;
                    hd.date_receice = hddto.date_receice;
                    hd.date_order = hddto.date_order;
                    hd.total = hddto.total;
                    hd.status = 0;

                    var HD = this.HoaDonRepository.HoaDon_Add(hd);
                    return Created("success", HD);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public ActionResult<HoaDon> UpdateSP([FromBody] HoaDonDto hddto, int id) {
            if(ModelState.IsValid) {
                try {
                    var hd = HoaDonRepository.HoaDon_GetById(id);

                    if(hd == null || hddto.Id != id) {
                        return NotFound();
                    }

                    // Mapping
                    hd.LSPId = hddto.LSPId;
                    hd.KHuser = hddto.KHuser;
                    hd.NVuser = hddto.NVuser;
                    hd.phone = hddto.phone;
                    hd.address = hddto.address;
                    hd.date_receice = hddto.date_receice;
                    hd.date_order = hddto.date_order;
                    hd.total = hddto.total;
                    hd.status = 0;

                    var HD = this.HoaDonRepository.HoaDon_Update(hd);
                    return Created("success", HD);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSP(int id) {
            var HD = HoaDonRepository.HoaDon_GetById(id);
            if(HD == null) {
                return NotFound();
            }
            HoaDonRepository.HoaDon_Delete(HD);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewHoaDonAdminDto FilterAdmin(FilterDataAdminDto data) {
            int count;
            var HoaDons = HoaDonRepository.HoaDon_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListHD = new PaginatedList<HoaDon>(HoaDons, count, data.pageIndex, pageSize);
            ViewHoaDonAdminDto view = new ViewHoaDonAdminDto() {
                ListHD = ListHD,
                search = data.search,
                sort = data.sort,
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