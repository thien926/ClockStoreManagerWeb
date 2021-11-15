using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SanPhamController : ControllerBase
    {
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
    }
}