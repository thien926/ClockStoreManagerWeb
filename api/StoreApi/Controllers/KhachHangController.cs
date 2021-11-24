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
    public class KhachHangController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly IKhachHangRepository KhachHangRepository;
        public KhachHangController(IKhachHangRepository KhachHangRepository) {
            this.KhachHangRepository = KhachHangRepository;
        }

        [HttpGet]
        public IEnumerable<KhachHang> GetAll() {
            return this.KhachHangRepository.KhachHang_GetAll();
        }

        [HttpGet("{user}")]
        public ActionResult<KhachHang> GetByUser(String user) {
            return this.KhachHangRepository.KhachHang_GetByUser(user);
        }

        [HttpPost]
        public ActionResult<KhachHang> AddKH(KhachHangDto khdto) {

            // Console.WriteLine("KhachHang Add: ");
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
                    KhachHang kh = new KhachHang();

                    // Mapping
                    kh.user = khdto.user;
                    kh.password = khdto.password;
                    kh.name = khdto.name;
                    kh.phone = khdto.phone;
                    kh.mail = khdto.mail;
                    kh.address = khdto.address;
                    kh.gender = khdto.gender;
                    kh.dateborn = khdto.dateborn;
                    kh.status = khdto.status;
                    kh.status = 0;

                    var KH = this.KhachHangRepository.KhachHang_Add(kh);
                    return Created("success", KH);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{user}")]
        public ActionResult<KhachHang> UpdateKH([FromBody] KhachHangDto khdto, String user) {
            if(ModelState.IsValid) {
                try {
                    var kh = KhachHangRepository.KhachHang_GetByUser(user);

                    if(kh == null || khdto.user != user) {
                        return NotFound();
                    }

                    // Mapping
                    kh.user = khdto.user;
                    kh.password = khdto.password;
                    kh.name = khdto.name;
                    kh.phone = khdto.phone;
                    kh.mail = khdto.mail;
                    kh.address = khdto.address;
                    kh.gender = khdto.gender;
                    kh.dateborn = khdto.dateborn;
                    kh.status = khdto.status;

                    var KH = this.KhachHangRepository.KhachHang_Update(kh);
                    return Created("success", KH);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{user}")]
        public ActionResult DeleteKH(String user) {
            var KH = KhachHangRepository.KhachHang_GetByUser(user);
            if(KH == null) {
                return NotFound();
            }
            KhachHangRepository.KhachHang_Delete(KH);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewKhachHangAdminDto FilterAdmin(FilterDataAdminDto data) {
            int count;
            var KhachHangs = KhachHangRepository.KhachHang_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListKH = new PaginatedList<KhachHang>(KhachHangs, count, data.pageIndex, pageSize);
            ViewKhachHangAdminDto view = new ViewKhachHangAdminDto() {
                ListKH = ListKH,
                search = data.search,
                sort = data.sort,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListKH.TotalPages
            };
            return view;
        }
    }
}