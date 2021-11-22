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
    public class QuyenController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly IQuyenRepository QuyenRepository;
        public QuyenController(IQuyenRepository QuyenRepository) {
            this.QuyenRepository = QuyenRepository;
        }

        [HttpGet]
        public IEnumerable<Quyen> GetAll() {
            return this.QuyenRepository.Quyen_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Quyen> GetById(int id) {
            return this.QuyenRepository.Quyen_GetById(id);
        }

        [HttpPost]
        public ActionResult<Quyen> AddQ(QuyenDto qdto) {
            if(ModelState.IsValid){
                try {
                    Quyen q = new Quyen();

                    // Mapping
                    //q.Id = qdto.Id;
                    q.name = qdto.name;
                    q.details = qdto.details;
                    var Q = this.QuyenRepository.Quyen_Add(q);
                    return Created("success", Q);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public ActionResult<Quyen> UpdateQ([FromBody] QuyenDto qdto, int id) {
            if(ModelState.IsValid) {
                try {
                    var q = QuyenRepository.Quyen_GetById(id);

                    if(q == null || qdto.Id != id) {
                        return NotFound();
                    }

                    // Mapping
                    //q.Id = qdto.Id;
                    q.name = qdto.name;
                    q.details = qdto.details;

                    var Q = this.QuyenRepository.Quyen_Update(q);
                    return Created("success", Q);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteQ(int id) {
            var SP = QuyenRepository.Quyen_GetById(id);
            if(SP == null) {
                return NotFound();
            }
            QuyenRepository.Quyen_Delete(SP);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewQuyenAdminDto FilterAdmin(FilterDataAdminDto data) {
            int count;
            var Quyens = QuyenRepository.Quyen_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListQ = new PaginatedList<Quyen>(Quyens, count, data.pageIndex, pageSize);
            ViewQuyenAdminDto view = new ViewQuyenAdminDto() {
                ListQ = ListQ,
                search = data.search,
                sort = data.sort,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListQ.TotalPages
            };
            return view;
        }
    }
}