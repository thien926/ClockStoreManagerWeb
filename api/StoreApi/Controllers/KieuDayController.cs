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
    public class KieuDayController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly IKieuDayRepository KieuDayRepository;
        public KieuDayController(IKieuDayRepository KieuDayRepository) {
            this.KieuDayRepository = KieuDayRepository;
        }

        [HttpGet]
        public IEnumerable<KieuDay> GetAll() {
            return this.KieuDayRepository.KieuDay_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<KieuDay> GetById(int id) {
            return this.KieuDayRepository.KieuDay_GetById(id);
        }

        [HttpPost]
        public ActionResult<KieuDay> AddKD(KieuDayDto kddto) {

            if(ModelState.IsValid){
                try {
                    KieuDay kd = new KieuDay();

                    // Mapping
                    // kd.Id = kddto.Id;
                    kd.name = kddto.name;

                    var KD = this.KieuDayRepository.KieuDay_Add(kd);
                    return Created("success", KD);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public ActionResult<KieuDay> UpdateKD([FromBody] KieuDayDto kddto, int id) {
            if(ModelState.IsValid) {
                try {
                    var kd = KieuDayRepository.KieuDay_GetById(id);

                    if(kd == null || kddto.Id != id) {
                        return NotFound();
                    }

                    // Mapping
                    kd.Id = kddto.Id;
                    kd.name = kddto.name;

                    var KD = this.KieuDayRepository.KieuDay_Update(kd);
                    return Created("success", KD);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteKD(int id) {
            var KD = KieuDayRepository.KieuDay_GetById(id);
            if(KD == null) {
                return NotFound();
            }
            KieuDayRepository.KieuDay_Delete(KD);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewKieuDayAdminDto FilterAdmin(FilterDataAdminDto data) {
            int count;
            var KieuDays = KieuDayRepository.KieuDay_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListKD = new PaginatedList<KieuDay>(KieuDays, count, data.pageIndex, pageSize);
            ViewKieuDayAdminDto view = new ViewKieuDayAdminDto() {
                ListKD = ListKD,
                sort = data.sort,
                search = data.search,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListKD.TotalPages
            };
            return view;
        }
    }
}