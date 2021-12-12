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
    public class HoaDonController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly IHoaDonRepository HoaDonRepository;
        private readonly IKhachHangRepository khachHangRepository;
        private readonly INhanVienRepository nhanVienRepository;
        private readonly JwtKhachHangService jwtKhachHang;
        private readonly JwtNhanVienService jwtNhanVien;
        private readonly IQuyenRepository quyenRepository;
        private readonly IChiTietHDRepository chiTietHDRepository;
        private readonly ISanPhamRepository sanPhamRepository;
        public HoaDonController(IHoaDonRepository HoaDonRepository, JwtKhachHangService jwtKhachHang,
        IKhachHangRepository khachHangRepository, JwtNhanVienService jwtNhanVien, INhanVienRepository nhanVienRepository,
        IQuyenRepository quyenRepository, IChiTietHDRepository chiTietHDRepository, ISanPhamRepository sanPhamRepository)
        {
            this.HoaDonRepository = HoaDonRepository;
            this.jwtKhachHang = jwtKhachHang;
            this.khachHangRepository = khachHangRepository;
            this.jwtNhanVien = jwtNhanVien;
            this.nhanVienRepository = nhanVienRepository;
            this.quyenRepository = quyenRepository;
            this.chiTietHDRepository = chiTietHDRepository;
            this.sanPhamRepository = sanPhamRepository;
        }

        // Client ko gọi api này nên bỏ
        // [HttpGet]
        // public IEnumerable<HoaDon> GetAll()
        // {
        //     return this.HoaDonRepository.HoaDon_GetAll();
        // }
        
        // Client ko gọi api này nên bỏ
        // [HttpGet("{id}")]
        // public ActionResult<HoaDon> GetById(int id)
        // {
        //     return this.HoaDonRepository.HoaDon_GetById(id);
        // }

        // User Page 
        // Hiển thị danh sách hóa đơn của tài khoản khách hàng
        [HttpGet("getByUserKH/{pageIndex}")]
        public ActionResult<ViewBillShopDto> GetByUserKH(int pageIndex)
        {
            // Phần xác thực tài khoản khách hàng 
            var jwt = Request.Cookies["jwt-khachhang"];
            if (jwt == null) {
                return null;
            }
            var token = jwtKhachHang.Verify(jwt);
            var user = token.Issuer;
            var kh = khachHangRepository.KhachHang_GetByUser(user);

            // Không tìm thấy khách hàng hoặc tài khoản bị khóa => return null
            // Tài khoản bị khóa thì không có quyền xem danh sách hóa đơn của tài khoản
            if(kh == null || kh.status == 0) {
                return null;
            }

            int count;

            var HoaDons = HoaDonRepository.HoaDon_GetByUserKH(user, pageIndex, pageSize, out count);
            
            var ListHD = new PaginatedList<HoaDon>(HoaDons, count, pageIndex, pageSize);
            ViewBillShopDto view = new ViewBillShopDto() {
                ListHD = ListHD,
                pageIndex = pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListHD.TotalPages
            };
            return view;
        }

        // Hóa đơn Page - Admin
        // Chỉ có quyền sửa trạng thái của hóa đơn
        [HttpPut("{id}")]
        public ActionResult<HoaDon> UpdateHD([FromBody] HoaDonDto hddto, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Phần xác thực tài khoản nhân viên
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

                    // Kiểm tra nhân viên có quyền sửa hóa đơn không
                    var checkQuyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "qlHoaDon");

                    if(!checkQuyen) {
                        return BadRequest(new { message = "Tài khoản không có quyền sửa hóa đơn!" });
                    }
                    
                    var hd = HoaDonRepository.HoaDon_GetById(id);

                    if (hd == null || hddto.Id != id)
                    {
                        return NotFound(new { message = "Không tìm thấy hóa đơn cần sửa!" });
                    }

                    // Hóa đơn chưa được nhân viên nào xử lý và hóa đơn thuộc quyền xử lý của nhân viên
                    // đó thì nhân viên đó mới được xử lý
                    if(hd.NVuser != null && hd.NVuser != nv.user) {
                        return BadRequest(new { message = "Hóa đơn thuộc quyền sửa đổi của nhân viên khác!" });
                    }

                    // hd.status = hddto.status;
                    // Mapping
                    // Trạng thái gồm có
                    //     -   Đang xử lý : 1
                    //     -   Đang giao hàng: 2
                    //     -   Đã giao hàng : 3
                    //     -   Đã hủy đơn hàng : 4
                    if (hd.status < hddto.status)
                    {
                        if(hd.status == 1) {
                            hd.NVuser = nv.user;
                        }
                        
                        hd.status = hddto.status;

                        // Đã giao hàng thì cập nhật ngày nhận hàng
                        if(hd.status == 3) {
                            hd.date_receice = System.DateTime.Now;
                        }

                        if(hd.status == 4) {
                            var ctdh = chiTietHDRepository.ChiTietHD_GetByBillId(hd.Id);
                            List<int> listProduct_id = new List<int>(); // lưu Id sản phẩm
                            List<int> listSoluong = new List<int>();    // lưu số lượng sản phẩm 

                            foreach (var item in ctdh)
                            {
                                listProduct_id.Add(item.productId);
                                listSoluong.Add(item.amount);
                            }

                            var sps = sanPhamRepository.SanPham_LoadByListIdSP(listProduct_id);
                            
                            // cập nhật số lượng sản phẩm khi đơn hàng bị hủy
                            foreach (var item in sps)
                            {
                                for(int i = 0; i < listProduct_id.Count(); ++i) {
                                    if(item.Id == listProduct_id[i]) {
                                        item.amount = item.amount + listSoluong[i];
                                    }
                                }
                            }
                            // cập nhật sản phẩm trong database
                            sanPhamRepository.SanPham_UpdateRand((List<SanPham>)sps);
                        }
                        
                    }
                    else
                    {
                        return BadRequest(new { message = "Cập nhật trạng thái hóa đơn không thành công!" });
                    }

                    var HD = this.HoaDonRepository.HoaDon_Update(hd);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        // Hóa đơn Page - Admin
        // Xóa hóa đơn
        [HttpDelete("{id}")]
        public ActionResult DeleteHD(int id)
        {
            // Phần xác thực tài khoản nhân viên
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

            var quyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "qlHoaDon");

            // Kiểm tra nhân viên có quyền xóa không
            if(!quyen) {
                return BadRequest(new { message = "Tài khoản không có quyền xóa hóa đơn!" });
            }
            
            var HD = HoaDonRepository.HoaDon_GetById(id);
            if (HD == null)
            {
                return NotFound();
            }

            // Đơn hàng ở trạng thái bị hủy thì mới được xóa
            if(HD.status != 4) {
                return BadRequest(new {message = "Hóa đơn phải ở trạng thái đã bị hủy mới được xóa!"});
            }

            HoaDonRepository.HoaDon_Delete(HD);
            return Ok(new { messgae = "Ok" });
        }

        // Hóa đơn Page - Admin
        // Load danh sách hóa đơn
        [HttpPost("filter-admin")]
        public ViewHoaDonAdminDto FilterAdmin(FilterHoaDonDto data)
        {
            // Phần xác thực tài khoản nhân viên
            var jwt = Request.Cookies["jwt-nhanvien"];
            if (jwt == null)
            {
                return null;
            }
            var token = jwtNhanVien.Verify(jwt);
            var user = token.Issuer;
            var nv = nhanVienRepository.NhanVien_GetByUser(user);

            if (nv == null || nv.status == 0) {
                return null;
            }

            var quyen = quyenRepository.Quyen_CheckQuyenUser(nv.quyenId, "HoaDon");
            if(!quyen) {
                return null;
            }

            int count;
            var HoaDons = HoaDonRepository.HoaDon_FilterAdmin(data.search, data.status, data.pageIndex, pageSize, out count);
            var ListHD = new PaginatedList<HoaDon>(HoaDons, count, data.pageIndex, pageSize);
            ViewHoaDonAdminDto view = new ViewHoaDonAdminDto()
            {
                ListHD = ListHD,
                search = data.search,
                status = data.status,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListHD.TotalPages
            };
            return view;
        }

        // [HttpPost]
        // public ActionResult<HoaDon> AddHD(HoaDonDto hddto) {

        //     if(ModelState.IsValid){
        //         try {
        //             HoaDon hd = new HoaDon();

        //             // Mapping
        //             // hd.LSPId = hddto.LSPId;
        //             hd.KHuser = hddto.KHuser;
        //             hd.NVuser = hddto.NVuser;
        //             hd.phone = hddto.phone;
        //             hd.address = hddto.address;
        //             hd.date_receice = hddto.date_receice;
        //             hd.date_order = hddto.date_order;
        //             hd.total = hddto.total;
        //             hd.status = 0;

        //             var HD = this.HoaDonRepository.HoaDon_Add(hd);
        //             return Created("success", HD);
        //         }
        //         catch(Exception e) {
        //             return StatusCode(StatusCodes.Status500InternalServerError);
        //         }
        //     }

        //     return StatusCode(StatusCodes.Status500InternalServerError);
        // }
    }
}