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
    public class NCCController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly INCCRepository NCCRepository;
        public NCCController(INCCRepository NCCRepository) {
            this.NCCRepository = NCCRepository;
        }

        [HttpGet]
        public IEnumerable<NCC> GetAll() {
            return this.NCCRepository.NCC_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<NCC> GetById(int id) {
            return this.NCCRepository.NCC_GetById(id);
        }

        [HttpPost]
        public ActionResult<NCC> AddLSP(NCCDto nccdto) {

            if(ModelState.IsValid){
                try {
                    NCC ncc = new NCC();

                    // Mapping
                    // ncc.Id = nccdto.Id;
                    ncc.name = nccdto.name;
                    ncc.address = nccdto.address;
                    ncc.phone = nccdto.phone;
                    ncc.fax = nccdto.fax;
                    var NCC = this.NCCRepository.NCC_Add(ncc);
                    return Created("success", NCC);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public ActionResult<NCC> UpdateLSP([FromBody] NCCDto nccdto, int id) {
            if(ModelState.IsValid) {
                try {
                    var ncc = NCCRepository.NCC_GetById(id);

                    if(ncc == null || nccdto.Id != id) {
                        return NotFound();
                    }

                    // Mapping
                    ncc.Id = nccdto.Id;
                    ncc.name = nccdto.name;
                    ncc.address = nccdto.address;
                    ncc.phone = nccdto.phone;
                    ncc.fax = nccdto.fax;

                    var nCC = this.NCCRepository.NCC_Update(ncc);
                    return Created("success", nCC);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLSP(int id) {
            var NCC = NCCRepository.NCC_GetById(id);
            if(NCC == null) {
                return NotFound();
            }
            NCCRepository.NCC_Delete(NCC);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewNCCAdminDto FilterAdmin(FilterDataAdminDto data) {
            int count;
            var NCCs = NCCRepository.NCC_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListNCC = new PaginatedList<NCC>(NCCs, count, data.pageIndex, pageSize);
            ViewNCCAdminDto view = new ViewNCCAdminDto() {
                ListNCC = ListNCC,
                sort = data.sort,
                search = data.search,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListNCC.TotalPages
            };
            return view;
        }
    }
}