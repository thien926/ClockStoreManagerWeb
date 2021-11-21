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
    public class PhieuNhapController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly IPhieuNhapRepository PhieuNhapRepository;
        public PhieuNhapController(IPhieuNhapRepository PhieuNhapRepository) {
            this.PhieuNhapRepository = PhieuNhapRepository;
        }

        [HttpGet]
        public IEnumerable<PhieuNhap> GetAll() {
            return this.PhieuNhapRepository.PhieuNhap_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<PhieuNhap> GetById(int id) {
            return this.PhieuNhapRepository.PhieuNhap_GetById(id);
        }

        [HttpPost]
        public ActionResult<PhieuNhap> AddPN(PhieuNhapDto pndto) {

            // Console.WriteLine("PhieuNhap Add: ");
            // Console.WriteLine(pndto.LpnId);
            // Console.WriteLine(pndto.brandId);
            // Console.WriteLine(pndto.wireId);
            // Console.WriteLine(pndto.machineId);
            // Console.WriteLine(pndto.nccId);
            // Console.WriteLine(pndto.name);
            // Console.WriteLine(pndto.amount);
            // Console.WriteLine(pndto.price);
            // Console.WriteLine(pndto.description);
            // Console.WriteLine("img:", pndto.img);

            if(ModelState.IsValid){
                try {
                    PhieuNhap pn = new PhieuNhap();

                    // Mapping
                    pn.nccId = pndto.nccId;
                    pn.NVuser = pndto.NVuser;
                    pn.phone = pndto.phone;
                    pn.address = pndto.address;
                    pn.date_receice = pndto.date_receice;
                    pn.total = pndto.total;
                    pn.status = 0;

                    var PN = this.PhieuNhapRepository.PhieuNhap_Add(pn);
                    return Created("success", PN);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public ActionResult<PhieuNhap> UpdatePN([FromBody] PhieuNhapDto pndto, int id) {
            if(ModelState.IsValid) {
                try {
                    var pn = PhieuNhapRepository.PhieuNhap_GetById(id);

                    if(pn == null || pndto.Id != id) {
                        return NotFound();
                    }

                    // Mapping
                    pn.nccId = pndto.nccId;
                    pn.NVuser = pndto.NVuser;
                    pn.phone = pndto.phone;
                    pn.address = pndto.address;
                    pn.date_receice = pndto.date_receice;
                    pn.total = pndto.total;
                    pn.status = 0;

                    var PN = this.PhieuNhapRepository.PhieuNhap_Update(pn);
                    return Created("success", PN);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePN(int id) {
            var PN = PhieuNhapRepository.PhieuNhap_GetById(id);
            if(PN == null) {
                return NotFound();
            }
            PhieuNhapRepository.PhieuNhap_Delete(PN);
            return Ok(new { messgae = "Ok" });
        }
    }
}