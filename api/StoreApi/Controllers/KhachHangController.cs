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
        private readonly IKhachHangRepository KhachHangRepository;
        private readonly JwtKhachHangService jwtKhachHang;
        public KhachHangController(IKhachHangRepository KhachHangRepository, JwtKhachHangService jwtKhachHang) {
            this.KhachHangRepository = KhachHangRepository;
            this.jwtKhachHang = jwtKhachHang;
        }

        [HttpPost("login")]
        public ActionResult LoginAdmin(LoginAdminDto dto) {
            var user = KhachHangRepository.KhachHang_GetByUser(dto.user);
            if(user == null) {
                return BadRequest(new { message = "Invalid Credentials"});
            }

            if(!BCrypt.Net.BCrypt.Verify(dto.password, user.password)) {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = jwtKhachHang.Generate(user.user); 

            Response.Cookies.Append("jwt-KhachHang", jwt, new CookieOptions{
                HttpOnly = true
            });

            return Ok(user);
        } 

        [HttpGet("user")]
        public ActionResult UserAdmin() {
            try {
                var jwt = Request.Cookies["jwt-KhachHang"];

                var token = jwtKhachHang.Verify(jwt);

                string userId = token.Issuer;
                var user = KhachHangRepository.KhachHang_GetByUser(userId);
                return Ok(user);
            }
            catch(Exception e) {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public ActionResult LogoutAdmin() {
            Response.Cookies.Delete("jwt-KhachHang");
            return Ok(new {
                message = "success"
            });
        }

        [HttpGet]
        public IEnumerable<KhachHang> GetAll() {
            try {
                var jwt = Request.Cookies["jwt-KhachHang"];
                var token = jwtKhachHang.Verify(jwt);
                string userId = token.Issuer;
                var user = KhachHangRepository.KhachHang_GetByUser(userId);
                
                // quyenRepository.getById(user.quyenId)

                if(user == null) {
                    return null;
                }
                return KhachHangRepository.KhachHang_GetAll();
            }
            catch(Exception e) {
                return null;
            }
        }
    }
}