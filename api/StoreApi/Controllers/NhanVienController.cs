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
        private readonly JwtNhanVienService jwtNhanVien;
        public NhanVienController(INhanVienRepository nhanVienRepository, JwtNhanVienService jwtNhanVien) {
            this.nhanVienRepository = nhanVienRepository;
            this.jwtNhanVien = jwtNhanVien;
        }

        [HttpGet]
        public IEnumerable<NhanVien> GetAll() {
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

        [HttpPost("login")]
        public ActionResult LoginAdmin(LoginAdminDto dto) {
            var user = nhanVienRepository.NhanVien_GetByUser(dto.user);
            if(user == null) {
                return BadRequest(new { message = "Invalid Credentials"});
            }

            if(!BCrypt.Net.BCrypt.Verify(dto.password, user.password)) {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = jwtNhanVien.Generate(user.user); 

            Response.Cookies.Append("jwt-nhanvien", jwt, new CookieOptions{
                HttpOnly = true
            });

            return Ok(user);
        } 

        [HttpGet("user")]
        public ActionResult UserAdmin() {
            try {
                var jwt = Request.Cookies["jwt-nhanvien"];

                var token = jwtNhanVien.Verify(jwt);

                string userId = token.Issuer;
                var user = nhanVienRepository.NhanVien_GetByUser(userId);
                return Ok(user);
            }
            catch(Exception e) {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public ActionResult LogoutAdmin() {
            Response.Cookies.Delete("jwt-nhanvien");
            return Ok(new {
                message = "success"
            });
        }

        // Admin Custom Page
        [HttpPut("changeStatus/{user}")]
        public ActionResult<NhanVien> ChangeStatus(string user)
        {
            var nv = nhanVienRepository.NhanVien_GetByUser(user);
            
            if(nv == null) {
                return NotFound(new { message = "Không tìm thấy tài khoản nhân viên!" });
            }

            if(nv.status == 1) {
                nv.status = 0;
            }   
            else {
                nv.status = 1;
            }

            var res = nhanVienRepository.NhanVien_Update(nv);
            return Ok(res);
        }

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