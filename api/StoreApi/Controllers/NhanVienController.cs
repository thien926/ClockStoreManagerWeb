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
    public class NhanVienController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly INhanVienRepository nhanVienRepository;
        private readonly IQuyenRepository quyenRepository;
        private readonly JwtNhanVienService jwtNhanVien;
        public NhanVienController(INhanVienRepository nhanVienRepository, JwtNhanVienService jwtNhanVien, IQuyenRepository quyenRepository)
        {
            this.nhanVienRepository = nhanVienRepository;
            this.jwtNhanVien = jwtNhanVien;
            this.quyenRepository = quyenRepository;
        }

        [HttpGet]
        public IEnumerable<NhanVien> GetAll()
        {
            // try {
            //     var jwt = Request.Cookies["jwt-nhanvien"];
            //     var token = jwtNhanVien.Verify(jwt);
            //     string userId = token.Issuer;
            //     var user = nhanVienRepository.NhanVien_GetByUser(userId);

            //     // quyenRepository.getById(user.quyenId)

            //     if(user == null) {
            //         return null;
            //     }
            //     return nhanVienRepository.NhanVien_GetAll();
            // }
            // catch(Exception e) {
            //     return null;
            // }
            return nhanVienRepository.NhanVien_GetAll();
        }

        // NhanVien Page Admin
        [HttpPost]
        public ActionResult<NhanVien> AddNV(NhanVienDto nvdto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    NhanVien nv = new NhanVien();

                    // Mapping
                    nv.user = nvdto.user;
                    nv.password = BCrypt.Net.BCrypt.HashPassword(nvdto.password);
                    nv.name = nvdto.name;
                    nv.phone = nvdto.phone;
                    nv.quyenId = nvdto.quyenId;
                    nv.address = nvdto.address;
                    nv.gender = nvdto.gender;
                    nv.dateborn = nvdto.dateborn;
                    nv.status = 1;

                    var NV = this.nhanVienRepository.NhanVien_Add(nv);
                    return Created("success", NV);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return BadRequest();
        }

        // Update staff Page
        [HttpPut("updatePasswordNV")]
        public ActionResult<NhanVien> UpdatePasswordNV([FromBody] NhanVienPasswordDto nvdto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var nv = nhanVienRepository.NhanVien_GetByUser(nvdto.user);
                    // Mapping và sửa thông tin
                    // nv.user = nvdto.user;
                    nv.password = BCrypt.Net.BCrypt.HashPassword(nvdto.password);

                    var NV = this.nhanVienRepository.NhanVien_Update(nv);
                    return Created("success", NV);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        // Update staff Page
        [HttpPut("updatePermissionNV")]
        public ActionResult<NhanVien> UpdatePermissionNV([FromBody] NhanVienPermissionDto nvdto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var nv = nhanVienRepository.NhanVien_GetByUser(nvdto.user);
                    // Mapping và sửa thông tin
                    // nv.user = nvdto.user;
                    nv.quyenId = nvdto.quyenId;

                    var NV = this.nhanVienRepository.NhanVien_Update(nv);
                    return Created("success", NV);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public ActionResult LoginAdmin(LoginAdminDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = nhanVienRepository.NhanVien_GetByUser(dto.user);
                    if (user == null)
                    {
                        return BadRequest(new { message = "Tài khoản không tồn tại!" });
                    }

                    if (!BCrypt.Net.BCrypt.Verify(dto.password, user.password))
                    {
                        return BadRequest(new { message = "Mật khẩu không đúng!" });
                    }

                    if (user.status != 1)
                    {
                        return BadRequest(new { message = "Tài khoản đã bị khóa!" });
                    }

                    var jwt = jwtNhanVien.Generate(user.user);

                    Response.Cookies.Append("jwt-nhanvien", jwt, new CookieOptions
                    {
                        HttpOnly = true
                    });

                    return Ok(user);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return BadRequest();
        }

        // Get current user admin
        [HttpGet("user")]
        public ActionResult UserAdmin()
        {
            try
            {
                var jwt = Request.Cookies["jwt-nhanvien"];

                var token = jwtNhanVien.Verify(jwt);

                string userId = token.Issuer;
                var user = nhanVienRepository.NhanVien_GetByUser(userId);

                if (user.status != 1)
                {
                    return BadRequest(new { message = "Tài khoản đã bị khóa!" });
                }

                var quyen = quyenRepository.Quyen_GetById(user.quyenId);

                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized(e);
            }
        }

        // Update user admin Page
        [HttpPut("updateInfoUserNV")]
        public ActionResult<NhanVien> UpdateInfoUserNV([FromBody] UserInfoAdminDto nvdto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var jwt = Request.Cookies["jwt-nhanvien"];

                    if(jwt == null) {
                        return NotFound(new { messgae = "Nhân viên chưa đăng nhập tài khoản!"});
                    }

                    var token = jwtNhanVien.Verify(jwt);
                    string userId = token.Issuer;

                    var user = nhanVienRepository.NhanVien_GetByUser(userId);

                    if (user == null) {
                        return NotFound(new { messgae = "Không tìm thấy tài khoản nhân viên!"});
                    }

                    if(user.user != nvdto.user) {
                        return BadRequest(
                            new { message = "Tên tài khoản đăng nhập không khớp với tên tài khoản cần sửa!" }
                        );
                    }

                    // Mapping và sửa thông tin
                    // nv.user = nvdto.user;
                    user.name = nvdto.name;
                    user.phone = nvdto.phone;
                    user.address = nvdto.address;
                    user.gender = nvdto.gender;
                    user.dateborn = nvdto.dateborn;

                    var NV = this.nhanVienRepository.NhanVien_Update(user);
                    return Created("success", NV);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        [HttpPut("updatePasswordUserNV")]
        public ActionResult<KhachHang> UpdatePasswordUserNV([FromBody] UserPasswordDto nvdto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Phần xác thực tài khoản khách hàng để thực hiện thao tác sửa thông tin khách hàng
                    var jwt = Request.Cookies["jwt-nhanvien"];
                    if(jwt == null) {
                        return NotFound(new { messgae = "Nhân viên chưa đăng nhập tài khoản!"});
                    }
                    
                    var token = jwtNhanVien.Verify(jwt);
                    var userId = token.Issuer;
                    var user = nhanVienRepository.NhanVien_GetByUser(userId);

                    if (user == null) {
                        return NotFound(new { messgae = "Không tìm thấy tài khoản nhân viên!"});
                    }

                    if(user.user != nvdto.user) {
                        return BadRequest(
                            new { message = "Tên tài khoản đăng nhập không khớp với tên tài khoản cần sửa!" }
                        );
                    }

                    if (!BCrypt.Net.BCrypt.Verify(nvdto.oldPassword, user.password))
                    {
                        return BadRequest(new { message = "Mật khẩu không đúng!" });
                    }

                    // Mapping và sửa thông tin
                    user.password = BCrypt.Net.BCrypt.HashPassword(nvdto.newPassword);

                    var NV = this.nhanVienRepository.NhanVien_Update(user);
                    return Created("success", NV);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        [HttpPost("logout")]
        public ActionResult LogoutAdmin()
        {
            Response.Cookies.Delete("jwt-nhanvien");
            return Ok(new
            {
                message = "Đăng xuất thành công!"
            });
        }

        // Admin staff Page
        [HttpPut("changeStatus/{user}")]
        public ActionResult<NhanVien> ChangeStatus(string user)
        {
            var nv = nhanVienRepository.NhanVien_GetByUser(user);

            if (nv == null)
            {
                return NotFound(new { message = "Không tìm thấy tài khoản nhân viên!" });
            }

            if (nv.status == 1)
            {
                nv.status = 0;
            }
            else
            {
                nv.status = 1;
            }

            var res = nhanVienRepository.NhanVien_Update(nv);
            return Ok(res);
        }

        // Staff Page Admin
        [HttpPost("filter-admin")]
        public ViewNhanVienAdminDto FilterAdmin(FilterDataAdminDto data)
        {
            int count;
            var nhanViens = nhanVienRepository.NhanVien_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListNV = new PaginatedList<NhanVien>(nhanViens, count, data.pageIndex, pageSize);
            ViewNhanVienAdminDto view = new ViewNhanVienAdminDto()
            {
                ListNV = ListNV,
                search = data.search,
                sort = data.sort,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListNV.TotalPages
            };
            return view;
        }
    }
}