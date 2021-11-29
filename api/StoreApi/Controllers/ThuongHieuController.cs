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
    public class ThuongHieuController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly IThuongHieuRepository ThuongHieuRepository;
        public ThuongHieuController(IThuongHieuRepository ThuongHieuRepository) {
            this.ThuongHieuRepository = ThuongHieuRepository;
        }

        // shop
        [HttpGet]
        public IEnumerable<ThuongHieu> GetAll() {
            return this.ThuongHieuRepository.ThuongHieu_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ThuongHieu> GetById(int id) {
            return this.ThuongHieuRepository.ThuongHieu_GetById(id);
        }

        [HttpPost]
        public ActionResult<ThuongHieu> AddTH(ThuongHieuDto thdto) {

            if(ModelState.IsValid){
                try {
                    ThuongHieu th = new ThuongHieu();

                    // Mapping
                    //th.Id = thdto.Id;
                    th.name = thdto.name;
                    var TH = this.ThuongHieuRepository.ThuongHieu_Add(th);
                    return Created("success", TH);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public ActionResult<ThuongHieu> UpdateTH([FromBody] ThuongHieuDto thdto, int id) {
            if(ModelState.IsValid) {
                try {
                    var th = ThuongHieuRepository.ThuongHieu_GetById(id);

                    if(th == null || thdto.Id != id) {
                        return NotFound();
                    }

                    // Mapping
                    //th.Id = thdto.Id;
                    th.name = thdto.name;

                    var TH = this.ThuongHieuRepository.ThuongHieu_Update(th);
                    return Created("success", TH);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTH(int id) {
            var th = ThuongHieuRepository.ThuongHieu_GetById(id);
            if(th == null) {
                return NotFound();
            }
            ThuongHieuRepository.ThuongHieu_Delete(th);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewThuongHieuAdminDto FilterAdmin(FilterDataAdminDto data) {
            int count;
            var ThuongHieus = ThuongHieuRepository.ThuongHieu_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListTH = new PaginatedList<ThuongHieu>(ThuongHieus, count, data.pageIndex, pageSize);
            ViewThuongHieuAdminDto view = new ViewThuongHieuAdminDto() {
                ListTH = ListTH,
                search = data.search,
                sort = data.sort,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListTH.TotalPages
            };
            return view;
        }
    }
}