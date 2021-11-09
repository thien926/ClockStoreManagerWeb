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
        private readonly INhanVienRepository nhanVienRepository;
        private readonly JwtNhanVienService jwtNhanVien;
        public NhanVienController(INhanVienRepository nhanVienRepository, JwtNhanVienService jwtNhanVien) {
            this.nhanVienRepository = nhanVienRepository;
            this.jwtNhanVien = jwtNhanVien;
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

        [HttpGet]
        public IEnumerable<NhanVien> GetAll() {
            try {
                var jwt = Request.Cookies["jwt-nhanvien"];
                var token = jwtNhanVien.Verify(jwt);
                string userId = token.Issuer;
                var user = nhanVienRepository.NhanVien_GetByUser(userId);
                if(user == null) {
                    return null;
                }
                return nhanVienRepository.NhanVien_GetAll();
            }
            catch(Exception e) {
                return null;
            }
        }
    }
}