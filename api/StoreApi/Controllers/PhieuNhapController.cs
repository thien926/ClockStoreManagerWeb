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
        private readonly IChiTietPNRepository chiTietPNRepository;
        private readonly ISanPhamRepository sanPhamRepository;
        public PhieuNhapController(IPhieuNhapRepository PhieuNhapRepository, JwtNhanVienService jwtNhanVien,
        IQuyenRepository quyenRepository, INhanVienRepository nhanVienRepository, IChiTietPNRepository chiTietPNRepository,
        ISanPhamRepository sanPhamRepository) {
            this.PhieuNhapRepository = PhieuNhapRepository;
            this.quyenRepository = quyenRepository;
            this.nhanVienRepository = nhanVienRepository;
            this.jwtNhanVien = jwtNhanVien;
            this.chiTietPNRepository = chiTietPNRepository;
            this.sanPhamRepository = sanPhamRepository;
        }

        // [HttpGet]
        // public IEnumerable<PhieuNhap> GetAll() {
        //     return this.PhieuNhapRepository.PhieuNhap_GetAll();
        // }

        // [HttpGet("{id}")]
        // public ActionResult<PhieuNhap> GetById(int id) {
        //     return this.PhieuNhapRepository.PhieuNhap_GetById(id);
        // }

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

        // Phieu Nhap Page - Admin
        // [HttpPut("{id}")]
        // public ActionResult<PhieuNhap> UpdatePN([FromBody] PhieuNhapDto pndto, int id) {
        //     if(ModelState.IsValid) {
        //         try {
        //             // Ph???n x??c th???c t??i kho???n kh??ch h??ng ????? th???c hi???n thao t??c s???a th??ng tin kh??ch h??ng
        //             var jwt = Request.Cookies["jwt-nhanvien"];
        //             if (jwt == null)
        //             {
        //                 return NotFound(new { message = "Nh??n vi??n ch??a ????ng nh???p t??i kho???n!" });
        //             }
        //             var token = jwtNhanVien.Verify(jwt);
        //             var user = token.Issuer;
        //             var nv = nhanVienRepository.NhanVien_GetByUser(user);

        //             if (nv == null) {
        //                 return NotFound(new { message = "Kh??ng t??m th???y t??i kho???n nh??n vi??n ??ang ????ng nh???p!" });
        //             }

        //             if (nv.status == 0) {
        //                 return NotFound(new { message = "T??i kho???n nh??n vi??n ??ang ????ng nh???p ???? b??? kh??a!" });
        //             }

        //             var checkQuyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "qlPhieuNhap");

        //             if(!checkQuyen) {
        //                 return BadRequest(new { message = "T??i kho???n kh??ng c?? quy???n s???a phi???u nh???p!" });
        //             }

        //             var pn = PhieuNhapRepository.PhieuNhap_GetById(id);

        //             if(pn == null || pndto.Id != id) {
        //                 return NotFound(new { message = "Kh??ng t??m th???y phi???u nh???p c???n s???a!" });
        //             }

        //             // if(pn.NVuser != null && pn.NVuser != nv.user) {
        //             //     return BadRequest(new { message = "Phi???u nh???p thu???c quy???n s???a ?????i c???a nh??n vi??n kh??c!" });
        //             // }

        //             // Mapping

        //             if(pndto.status > pn.status) {
        //                 pn.status = pndto.status;
        //                 if(pn.status == 2) {
        //                     var ctpn = chiTietPNRepository.ChiTietPN_GetByCouponId(pn.Id);
        //                     List<int> listProduct_id = new List<int>(); // l??u Id s???n ph???m
        //                     List<int> listSoluong = new List<int>();    // l??u s??? l?????ng s???n ph???m 

        //                     foreach (var item in ctpn)
        //                     {
        //                         listProduct_id.Add(item.productId);
        //                         listSoluong.Add(item.amount);
        //                     }

        //                     var sps = sanPhamRepository.SanPham_LoadByListIdSP(listProduct_id);
        //                     foreach (var item in sps)
        //                     {
        //                         for(int i = 0; i < listProduct_id.Count(); ++i) {
        //                             if(item.Id == listProduct_id[i]) {
        //                                 item.amount = item.amount - listSoluong[i];
        //                                 break;
        //                             }
        //                         }
        //                     }
        //                     sanPhamRepository.SanPham_UpdateRand((List<SanPham>)sps);
        //                 }
        //             }
        //             else {
        //                 return BadRequest(new { message = "C???p nh???t tr???ng th??i phi???u nh???p kh??ng th??nh c??ng!" });
        //             }

        //             var PN = this.PhieuNhapRepository.PhieuNhap_Update(pn);
        //             return Ok();
        //         }
        //         catch(Exception e) {
        //             return BadRequest(e);
        //         }
        //     }
        //     return BadRequest();
        // }
        
        // Phieu Nhap Page -  Admin
        // [HttpDelete("{id}")]
        // public ActionResult DeletePN(int id) {
        //     try{
        //         // Ph???n x??c th???c t??i kho???n kh??ch h??ng ????? th???c hi???n thao t??c s???a th??ng tin kh??ch h??ng
        //         var jwt = Request.Cookies["jwt-nhanvien"];
        //         if (jwt == null)
        //         {
        //             return NotFound(new { message = "Nh??n vi??n ch??a ????ng nh???p t??i kho???n!" });
        //         }
        //         var token = jwtNhanVien.Verify(jwt);
        //         var user = token.Issuer;
        //         var nv = nhanVienRepository.NhanVien_GetByUser(user);

        //         if (nv == null) {
        //             return NotFound(new { message = "Kh??ng t??m th???y t??i kho???n nh??n vi??n ??ang ????ng nh???p!" });
        //         }

        //         if (nv.status == 0) {
        //             return NotFound(new { message = "T??i kho???n nh??n vi??n ??ang ????ng nh???p ???? b??? kh??a!" });
        //         }

        //         var quyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "qlPhieuNhap");

        //         if(!quyen) {
        //             return BadRequest(new { message = "T??i kho???n kh??ng c?? quy???n x??a phi???u nh???p!" });
        //         }

        //         var PN = PhieuNhapRepository.PhieuNhap_GetById(id);
        //         if(PN == null) {
        //             return NotFound();
        //         }
                
        //         // if(PN.status != 2) {
        //         //     return BadRequest(new {message = "Phi???u nh???p ph???i ??? tr???ng th??i ???? b??? h???y m???i ???????c x??a!"});
        //         // }

        //         PhieuNhapRepository.PhieuNhap_Delete(PN);
        //         return Ok(new { messgae = "Ok" });
        //     }
        //     catch(Exception e) {
        //         return BadRequest(e);
        //     }
        // }

        // PhieuNhap - Admin
        [HttpPost("filter-admin")]
        public ViewPhieuNhapAdminDto FilterAdmin(FilterDataAdminDto data) {
            // Ph???n x??c th???c t??i kho???n nh??n vi??n
            var jwt = Request.Cookies["jwt-nhanvien"];
            if (jwt == null)
            {
                return null;
            }
            var token = jwtNhanVien.Verify(jwt);
            var user = token.Issuer;
            var nv = nhanVienRepository.NhanVien_GetByUser(user);

            if (nv == null || nv.status == 0)
            {
                return null;
            }

            var quyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "PhieuNhap");

            // Ki???m tra nh??n vi??n c?? quy???n xem ki???u d??y kh??ng
            if (!quyen)
            {
                return null;
            }

            int count;
            var PhieuNhaps = PhieuNhapRepository.PhieuNhap_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListPN = new PaginatedList<PhieuNhap>(PhieuNhaps, count, data.pageIndex, pageSize);
            ViewPhieuNhapAdminDto view = new ViewPhieuNhapAdminDto() {
                ListPN = ListPN,
                search = data.search,
                sort = data.sort,
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