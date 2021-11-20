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
    public class LoaiSanPhamController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly ILoaiSanPhamRepository LoaiSanPhamRepository;
        public LoaiSanPhamController(ILoaiSanPhamRepository LoaiSanPhamRepository) {
            this.LoaiSanPhamRepository = LoaiSanPhamRepository;
        }

        [HttpGet]
        public IEnumerable<LoaiSanPham> GetAll() {
            return this.LoaiSanPhamRepository.LoaiSanPham_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<LoaiSanPham> GetById(int id) {
            return this.LoaiSanPhamRepository.LoaiSanPham_GetById(id);
        }

        [HttpPost]
        public ActionResult<LoaiSanPham> AddLSP(LoaiSanPhamDto lspdto) {

            if(ModelState.IsValid){
                try {
                    LoaiSanPham lsp = new LoaiSanPham();

                    // Mapping
                    // lsp.Id = lspdto.Id;
                    lsp.name = lspdto.name;
                    lsp.description = lspdto.description;

                    var LSP = this.LoaiSanPhamRepository.LoaiSanPham_Add(lsp);
                    return Created("success", LSP);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public ActionResult<LoaiSanPham> UpdateLSP([FromBody] LoaiSanPhamDto lspdto, int id) {
            if(ModelState.IsValid) {
                try {
                    var lsp = LoaiSanPhamRepository.LoaiSanPham_GetById(id);

                    if(lsp == null || lspdto.Id != id) {
                        return NotFound();
                    }

                    // Mapping
                    // lsp.Id = lspdto.Id;
                    lsp.name = lspdto.name;
                    lsp.description = lspdto.description;

                    var LSP = this.LoaiSanPhamRepository.LoaiSanPham_Update(lsp);
                    return Created("success", LSP);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLSP(int id) {
            var LSP = LoaiSanPhamRepository.LoaiSanPham_GetById(id);
            if(LSP == null) {
                return NotFound();
            }
            LoaiSanPhamRepository.LoaiSanPham_Delete(LSP);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewLoaiSanPhamAdminDto FilterAdmin(FilterDataAdminDto data) {
            int count;
            var LoaiSanPhams = LoaiSanPhamRepository.LoaiSanPham_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListLSP = new PaginatedList<LoaiSanPham>(LoaiSanPhams, count, data.pageIndex, pageSize);
            ViewLoaiSanPhamAdminDto view = new ViewLoaiSanPhamAdminDto() {
                ListLSP = ListLSP,
                sort = data.sort,
                search = data.search,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListLSP.TotalPages
            };
            return view;
        }
    }
}