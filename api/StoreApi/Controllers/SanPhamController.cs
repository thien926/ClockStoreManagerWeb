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
    public class SanPhamController : ControllerBase
    {
        private int pageSize = 9;
        private readonly ISanPhamRepository sanPhamRepository;
        public SanPhamController(ISanPhamRepository sanPhamRepository) {
            this.sanPhamRepository = sanPhamRepository;
        }

        [HttpGet]
        public IEnumerable<SanPham> GetAll() {
            return this.sanPhamRepository.SanPham_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<SanPham> GetById(int id) {
            return this.sanPhamRepository.SanPham_GetById(id);
        }

        [HttpPost]
        public ActionResult<SanPham> AddSP(SanPham sp) {
            try {
                var SP = this.sanPhamRepository.SanPham_Add(sp);
                return Created("success", SP);
            }
            catch(Exception e) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public ActionResult<SanPham> UpdateSP([FromBody] SanPham sp) {
            try {
                var SP = this.sanPhamRepository.SanPham_Update(sp);
                return Created("success", SP);
            }
            catch(Exception e) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSP(int id) {
            var SP = sanPhamRepository.SanPham_GetById(id);
            if(SP == null) {
                return NotFound(new { messgae = "Not" });
            }
            sanPhamRepository.SanPham_Delete(SP);
            return Ok(new { messgae = "Ok" });
        }

        [HttpGet("filter-admin")]
        public PaginatedList<SanPham> FilterAdmin(FilterDataAdminDto data) {
            int count;
            var SanPhams = sanPhamRepository.SanPham_FilterAdmin(data.sort, data.pageIndex, pageSize, out count);
            var ListSP = new PaginatedList<SanPham>(SanPhams, count, data.pageIndex, pageSize);
            return ListSP;
        }
    }
}