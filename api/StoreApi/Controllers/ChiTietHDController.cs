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
        public ChiTietHDController(IChiTietHDRepository ChiTietHDRepository) {
            this.ChiTietHDRepository = ChiTietHDRepository;
        }

        [HttpGet]
        public IEnumerable<ChiTietHD> GetAll() {
            return this.ChiTietHDRepository.ChiTietHD_GetAll();
        }

        // [HttpGet("{id}")]
        // public ActionResult<ChiTietHD> GetById(int id) {
        //     return this.ChiTietHDRepository.ChiTietHD_GetById(id);
        // }

        [HttpPost]
        public ActionResult<ChiTietHD> AddCTHD(ChiTietHDDto cthddto) {

            if(ModelState.IsValid){
                try {
                    ChiTietHD cthd = new ChiTietHD();

                    // Mapping
                    // cthd.LSPId = hddto.LSPId;
                    cthd.billId = hddto.billId;
                    cthd.productId = hddto.productId;
                    cthd.name  = hddto.name ;
                    cthd.ammount = hddto.ammount;
                    cthd.price = hddto.price;
                    cthd.img = hddto.img;

                    var CTHD = this.ChiTietHDRepository.ChiTietHD_Add(cthd);
                    return Created("success", CTHD);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        // [HttpPut("{id}")]
        // public ActionResult<ChiTietHD> UpdateCTHD([FromBody] ChiTietHDDto hddto, int id) {
        //     if(ModelState.IsValid) {
        //         try {
        //             var hd = ChiTietHDRepository.ChiTietHD_GetById(id);

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

        //             var HD = this.ChiTietHDRepository.ChiTietHD_Update(hd);
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
        //     var HD = ChiTietHDRepository.ChiTietHD_GetById(id);
        //     if(HD == null) {
        //         return NotFound();
        //     }
        //     ChiTietHDRepository.ChiTietHD_Delete(HD);
        //     return Ok(new { messgae = "Ok" });
        // }

        [HttpPost("filter-admin")]
        public ViewChiTietHDAdminDto FilterAdmin(FilterDataAdminDto data) {
            int count;
            var ChiTietHDs = ChiTietHDRepository.ChiTietHD_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListCTHD = new PaginatedList<ChiTietHD>(ChiTietHDs, count, data.pageIndex, pageSize);
            ViewChiTietHDAdminDto view = new ViewChiTietHDAdminDto() {
                ListCTHD = ListCTHD,
                search = data.search,
                sort = data.sort,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListCTHD.TotalPages
            };
            return view;
        }
    }
}