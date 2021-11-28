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
        private readonly JwtKhachHangService jwtKhachHang;
        public KhachHangController(IKhachHangRepository KhachHangRepository, JwtKhachHangService jwtKhachHang)
        {
            this.KhachHangRepository = KhachHangRepository;
            this.jwtKhachHang = jwtKhachHang;
        }

        [HttpGet]
        public IEnumerable<KhachHang> GetAll()
        {
            return this.KhachHangRepository.KhachHang_GetAll();
        }

        [HttpGet("{user}")]
        public ActionResult<KhachHang> GetByUser(String user)
        {
            return this.KhachHangRepository.KhachHang_GetByUser(user);
        }

        // Update User Page
        [HttpPut("updateInfoKH")]
        public ActionResult<KhachHang> UpdateInfoKH([FromBody] KhachHangInfoDto khdto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Phần xác thực tài khoản khách hàng để thực hiện thao tác sửa thông tin khách hàng
                    var jwt = Request.Cookies["jwt-khachhang"];
                    if(jwt == null) {
                        return NotFound(new { messgae = "Khách hàng chưa đăng nhập tài khoản!"});
                    }
                    var token = jwtKhachHang.Verify(jwt);
                    var user = token.Issuer;
                    var kh = KhachHangRepository.KhachHang_GetByUser(user);

                    if (kh == null || khdto.user != user)
                    {
                        return NotFound(new { messgae = "Không tìm thấy tài khoản khách hàng!"});
                    }

                    // Mapping và sửa thông tin
                    // kh.user = khdto.user;
                    kh.name = khdto.name;
                    kh.phone = khdto.phone;
                    kh.mail = khdto.mail;
                    kh.address = khdto.address;
                    kh.gender = khdto.gender;
                    kh.dateborn = khdto.dateborn;

                    var KH = this.KhachHangRepository.KhachHang_Update(kh);
                    return Created("success", KH);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        // Update User Page
        [HttpPut("updatePasswordKH")]
        public ActionResult<KhachHang> UpdatePasswordKH([FromBody] KhachHangPasswordDto khdto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Phần xác thực tài khoản khách hàng để thực hiện thao tác sửa thông tin khách hàng
                    var jwt = Request.Cookies["jwt-khachhang"];
                    if(jwt == null) {
                        return NotFound(new { messgae = "Khách hàng chưa đăng nhập tài khoản!"});
                    }
                    var token = jwtKhachHang.Verify(jwt);
                    var user = token.Issuer;
                    var kh = KhachHangRepository.KhachHang_GetByUser(user);

                    if (kh == null || khdto.user != user)
                    {
                        return NotFound(new { messgae = "Không tìm thấy tài khoản khách hàng!"});
                    }

                    if (!BCrypt.Net.BCrypt.Verify(khdto.oldPassword, kh.password))
                    {
                        return BadRequest(new { message = "Mật khẩu không đúng!" });
                    }

                    // Mapping và sửa thông tin
                    // kh.user = khdto.user;
                    kh.password = BCrypt.Net.BCrypt.HashPassword(khdto.newPassword);

                    var KH = this.KhachHangRepository.KhachHang_Update(kh);
                    return Created("success", KH);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
            return BadRequest();
        }

        [HttpDelete("{user}")]
        public ActionResult DeleteKH(String user)
        {
            var KH = KhachHangRepository.KhachHang_GetByUser(user);
            if (KH == null)
            {
                return NotFound();
            }
            KhachHangRepository.KhachHang_Delete(KH);
            return Ok(new { messgae = "Ok" });
        }

        // ====================

        // register page
        [HttpPost]
        public ActionResult<KhachHang> AddKH(KhachHangDto khdto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    KhachHang kh = new KhachHang();

                    // Mapping
                    kh.user = khdto.user;
                    kh.password = BCrypt.Net.BCrypt.HashPassword(khdto.password);
                    kh.name = khdto.name;
                    kh.phone = khdto.phone;
                    kh.mail = khdto.mail;
                    kh.address = khdto.address;
                    kh.gender = khdto.gender;
                    kh.dateborn = khdto.dateborn;
                    kh.status = 1;

                    var KH = this.KhachHangRepository.KhachHang_Add(kh);
                    return Created("success", KH);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return BadRequest();
        }

        // login page
        [HttpPost("login")]
        public ActionResult<KhachHang> Login(LoginShopDto khdto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var kh = KhachHangRepository.KhachHang_GetByUser(khdto.user);

                    if (kh == null)
                    {
                        return NotFound(new { message = "Tài khoản không tồn tại!" });
                    }

                    if (!BCrypt.Net.BCrypt.Verify(khdto.password, kh.password))
                    {
                        return BadRequest(new { message = "Mật khẩu không đúng!" });
                    }

                    var jwt = jwtKhachHang.Generate(kh.user);
                    Response.Cookies.Append("jwt-khachhang", jwt, new CookieOptions
                    {
                        HttpOnly = true
                    });

                    return Ok(kh);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return BadRequest();
        }

        // get user shop
        [HttpGet("usercurrent")]
        public ActionResult<KhachHang> UserCurrent()
        {
            try
            {
                var jwt = Request.Cookies["jwt-khachhang"];

                var token = jwtKhachHang.Verify(jwt);

                var userId = token.Issuer;
                var user = KhachHangRepository.KhachHang_GetByUser(userId);
                // Console.WriteLine(user.name);
                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        // logout shop
        [HttpGet("logout")]
        public ActionResult Logout()
        {
            Response.Cookies.Delete("jwt-khachhang");

            return Ok();
        }

        [HttpPost("filter-admin")]
        public ViewKhachHangAdminDto FilterAdmin(FilterDataAdminDto data)
        {
            int count;
            var KhachHangs = KhachHangRepository.KhachHang_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListKH = new PaginatedList<KhachHang>(KhachHangs, count, data.pageIndex, pageSize);
            ViewKhachHangAdminDto view = new ViewKhachHangAdminDto()
            {
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