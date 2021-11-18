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
    public class KieuMayController : ControllerBase
    {
        private readonly IKieuMayRepository KieuMayRepository;
        private readonly JwtKieuMayService jwtKieuMay;
        public KieuMayController(IKieuMayRepository KieuMayRepository, JwtKieuMayService jwtKieuMay) {
            this.KieuMayRepository = KieuMayRepository;
            this.jwtKieuMay = jwtKieuMay;
        }

        [HttpGet]
        public IEnumerable<KieuMay> GetAll() {
            try {
                var jwt = Request.Cookies["jwt-KieuMay"];
                var token = jwtKieuMay.Verify(jwt);
                string userId = token.Issuer;
                var user = KieuMayRepository.KieuMay_GetByUser(userId);
                

                if(user == null) {
                    return null;
                }
                return KieuMayRepository.KieuMay_GetAll();
            }
            catch(Exception e) {
                return null;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<KieuMay> GetByUser(string user) {
            return this.KieuMayRepository.KieuMay_GetByUser(User);
        }

        [HttpDelete("{id}")]
        public ActionResult Deletekm(int id) {
            var km = KieuMayRepository.KieuMay_GetById(id);
            if(km == null) {
                return NotFound();
            }
            KieuMayRepository.KieuMay_Delete(km);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost]
        public ActionResult<KieuMay> Addkm(KieuMayDto kmdto) {
            if(ModelState.IsValid){
                try {
                    KieuMay km = new KieuMay();

                    km.Id = kmdto.Id;
                    km.name = kmdto.name;

                    var km = this.KieuMayRepository.KieuMay_Add(km);
                    return Created("success", SP);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public ActionResult<KieuMay> Updatekm([FromBody] KieuMayDto kmdto, int id) {
            if(ModelState.IsValid) {
                try {
                    var km = KieuMayRepository.KieuMay_GetById(id);

                    if(km == null || spdto.Id != id) {
                        return NotFound();
                    }

                    km.Id = kmdto.Id;
                    km.nameID = kmdto.nameID;

                    var km = this.KieuMayRepository.KieuMay_Update(km);
                    return Created("success", km);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDto dto) {
            var user = KieuMayRepository.KieuMay_GetByUser(dto.user);
            if(user == null) {
                return BadRequest(new { message = "Invalid Credentials"});
            }

            if(!BCrypt.Net.BCrypt.Verify(dto.password, user.password)) {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = jwtKieuMay.Generate(user.user); 

            Response.Cookies.Append("jwt-KieuMay", jwt, new CookieOptions{
                HttpOnly = true
            });

            return Ok(user);
        } 

        [HttpGet("user")]
        public ActionResult User() {
            try {
                var jwt = Request.Cookies["jwt-KieuMay"];

                var token = jwtKieuMay.Verify(jwt);

                string userId = token.Issuer;
                var user = KieuMayRepository.KieuMay_GetByUser(userId);
                return Ok(user);
            }
            catch(Exception e) {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public ActionResult Logout() {
            Response.Cookies.Delete("jwt-KieuMay");
            return Ok(new {
                message = "success"
            });
        }
    }
}