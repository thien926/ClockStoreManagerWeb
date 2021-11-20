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
        public ActionResult<KieuMay> AddKM(KieuMayDto kmdto) {

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
                    KieuMay km = new KieuMay();

                    // Mapping
                    km.Id = kmdto.Id;
                    km.name = kmdto.name;
                    var KM = this.KieuMayRepository.KieuMay_Add(km);
                    return Created("success", KM);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public ActionResult<KieuMay> UpdateKM([FromBody] KieuMayDto kmdto, int id) {
            if(ModelState.IsValid) {
                try {
                    var km = KieuMayRepository.KieuMay_GetById(id);

                    if(km == null || kmdto.Id != id) {
                        return NotFound();
                    }

                    // Mapping
                    km.Id = kmdto.Id;
                    km.name = kmdto.name;

                    var KM = this.KieuMayRepository.KieuMay_Update(km);
                    return Created("success", KM);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteKM(int id) {
            var km = KieuMayRepository.KieuMay_GetById(id);
            if(km == null) {
                return NotFound();
            }
            KieuMayRepository.KieuMay_Delete(km);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewKieuMayAdminDto FilterAdmin(FilterDataAdminDto data) {
            int count;
            var KieuMays = KieuMayRepository.KieuMay_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListSP = new PaginatedList<KieuMay>(KieuMays, count, data.pageIndex, pageSize);
            ViewKieuMayAdminDto view = new ViewKieuMayAdminDto() {
                ListSP = ListSP,
                search = data.search,
                sort = data.sort,
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