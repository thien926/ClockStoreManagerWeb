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
    public class KieuMayController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly IKieuMayRepository KieuMayRepository;
        public KieuMayController(IKieuMayRepository KieuMayRepository) {
            this.KieuMayRepository = KieuMayRepository;
        }

        [HttpGet]
        public IEnumerable<KieuMay> GetAll() {
            return this.KieuMayRepository.KieuMay_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<KieuMay> GetById(int id) {
            return this.KieuMayRepository.KieuMay_GetById(id);
        }

        [HttpPost]
        public ActionResult<KieuMay> AddSP(KieuMayDto spdto) {

            // Console.WriteLine("KieuMay Add: ");
            // Console.WriteLine(spdto.LSPId);
            // Console.WriteLine(spdto.brandId);
            // Console.WriteLine(spdto.wireId);
            // Console.WriteLine(spdto.machineId);
            // Console.WriteLine(spdto.nccId);
            // Console.WriteLine(spdto.name);
            // Console.WriteLine(spdto.amount);
            // Console.WriteLine(spdto.price);
            // Console.WriteLine(spdto.description);
            // Console.WriteLine("img:", spdto.img);

            if(ModelState.IsValid){
                try {
                    KieuMay sp = new KieuMay();

                    // Mapping
                    sp.Id = spdto.Id;
                    sp.name = spdto.name;
                    var SP = this.KieuMayRepository.KieuMay_Add(sp);
                    return Created("success", SP);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public ActionResult<KieuMay> UpdateSP([FromBody] KieuMayDto spdto, int id) {
            if(ModelState.IsValid) {
                try {
                    var sp = KieuMayRepository.KieuMay_GetById(id);

                    if(sp == null || spdto.Id != id) {
                        return NotFound();
                    }

                    // Mapping
                    sp.Id = spdto.Id;
                    sp.name = spdto.name;

                    var SP = this.KieuMayRepository.KieuMay_Update(sp);
                    return Created("success", SP);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSP(int id) {
            var SP = KieuMayRepository.KieuMay_GetById(id);
            if(SP == null) {
                return NotFound();
            }
            KieuMayRepository.KieuMay_Delete(SP);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewProductAdminDto FilterAdmin(FilterDataAdminDto data) {
            int count;
            var KieuMays = KieuMayRepository.KieuMay_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListSP = new PaginatedList<KieuMay>(KieuMays, count, data.pageIndex, pageSize);
            ViewProductAdminDto view = new ViewProductAdminDto() {
                // sort = data.sort,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListSP.TotalPages
            };
            return view;
        }
    }
}