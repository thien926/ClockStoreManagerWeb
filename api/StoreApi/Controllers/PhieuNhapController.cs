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
        private readonly JwtNhanVienService jwtNhanVien;
        private readonly IQuyenRepository quyenRepository;
        private readonly INhanVienRepository nhanVienRepository;
        public PhieuNhapController(IPhieuNhapRepository PhieuNhapRepository, JwtNhanVienService jwtNhanVien,
        IQuyenRepository quyenRepository, INhanVienRepository nhanVienRepository) {
            this.PhieuNhapRepository = PhieuNhapRepository;
            this.quyenRepository = quyenRepository;
            this.nhanVienRepository = nhanVienRepository;
            this.jwtNhanVien = jwtNhanVien;
        }

        [HttpGet]
        public IEnumerable<PhieuNhap> GetAll() {
            return this.PhieuNhapRepository.PhieuNhap_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<PhieuNhap> GetById(int id) {
            return this.PhieuNhapRepository.PhieuNhap_GetById(id);
        }

        // [HttpPost]
        // public ActionResult<PhieuNhap> AddPN(PhieuNhapDto pndto) {

        //     // Console.WriteLine("PhieuNhap Add: ");
        //     // Console.WriteLine(pndto.LpnId);
        //     // Console.WriteLine(pndto.brandId);
        //     // Console.WriteLine(pndto.wireId);
        //     // Console.WriteLine(pndto.machineId);
        //     // Console.WriteLine(pndto.nccId);
        //     // Console.WriteLine(pndto.name);
        //     // Console.WriteLine(pndto.amount);
        //     // Console.WriteLine(pndto.price);
        //     // Console.WriteLine(pndto.description);
        //     // Console.WriteLine("img:", pndto.img);

        //     if(ModelState.IsValid){
        //         try {
        //             PhieuNhap pn = new PhieuNhap();

        //             // Mapping
        //             // pn.nccId = pndto.nccId;
        //             pn.NVuser = pndto.NVuser;
        //             pn.phone = pndto.phone;
        //             pn.address = pndto.address;
        //             pn.date_receice = pndto.date_receice;
        //             pn.total = pndto.total;
        //             // pn.status = 0;

        //             var PN = this.PhieuNhapRepository.PhieuNhap_Add(pn);
        //             return Created("success", PN);
        //         }
        //         catch(Exception e) {
        //             return StatusCode(StatusCodes.Status500InternalServerError);
        //         }
        //     }

        //     return StatusCode(StatusCodes.Status500InternalServerError);
        // }

        [HttpPut("{id}")]
        public ActionResult<PhieuNhap> UpdatePN([FromBody] PhieuNhapDto pndto, int id) {
            if(ModelState.IsValid) {
                try {
                    var pn = PhieuNhapRepository.PhieuNhap_GetById(id);

                    if(pn == null || pndto.Id != id) {
                        return NotFound();
                    }

                    // Mapping
                    // pn.nccId = pndto.nccId;
                    pn.status = 0;

                    if(pndto.status > pn.status) {
                        pn.status = pndto.status;
                        if(pn.status == 2) {
                            
                        }
                    }

                    var PN = this.PhieuNhapRepository.PhieuNhap_Update(pn);
                    return Created("success", PN);
                }
                catch(Exception e) {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePN(int id) {
            try{
                // Phần xác thực tài khoản khách hàng để thực hiện thao tác sửa thông tin khách hàng
                var jwt = Request.Cookies["jwt-nhanvien"];
                if (jwt == null)
                {
                    return NotFound(new { message = "Nhân viên chưa đăng nhập tài khoản!" });
                }
                var token = jwtNhanVien.Verify(jwt);
                var user = token.Issuer;
                var nv = nhanVienRepository.NhanVien_GetByUser(user);

                if (nv == null) {
                    return NotFound(new { message = "Không tìm thấy tài khoản nhân viên đang đăng nhập!" });
                }

                if (nv.status == 0) {
                    return NotFound(new { message = "Tài khoản nhân viên đang đăng nhập đã bị khóa!" });
                }

                var quyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "qlPhieuNhap");

                if(!quyen) {
                    return BadRequest(new { message = "Tài khoản không có quyền xóa phiếu nhập!" });
                }

                var PN = PhieuNhapRepository.PhieuNhap_GetById(id);
                if(PN == null) {
                    return NotFound();
                }
                
                if(PN.status != 2) {
                    return BadRequest(new {message = "Phiếu nhập phải ở trạng thái đã bị hủy mới được xóa!"});
                }

                PhieuNhapRepository.PhieuNhap_Delete(PN);
                return Ok(new { messgae = "Ok" });
            }
            catch(Exception e) {
                return BadRequest(e);
            }
        }
        [HttpPost("filter-admin")]
        public ViewPhieuNhapAdminDto FilterAdmin(FilterPhieuNhapDto data) {
            int count;
            var PhieuNhaps = PhieuNhapRepository.PhieuNhap_FilterAdmin(data.search, data.status, data.pageIndex, pageSize, out count);
            var ListPN = new PaginatedList<PhieuNhap>(PhieuNhaps, count, data.pageIndex, pageSize);
            ViewPhieuNhapAdminDto view = new ViewPhieuNhapAdminDto() {
                ListPN = ListPN,
                search = data.search,
                status = data.status,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListPN.TotalPages
            };
            return view;
        }
    }
}