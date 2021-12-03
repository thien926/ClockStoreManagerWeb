using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApi.DTOs;
using StoreApi.Interfaces;
using StoreApi.Models;
using StoreApi.Services;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ISanPhamRepository sanPhamRepository;
        private readonly IKhachHangRepository KhachHangRepository;
        private readonly JwtKhachHangService jwtKhachHang;
        private readonly IHoaDonRepository hoaDonRepository;
        private readonly IChiTietHDRepository chiTietHDRepository;
        public CartController(ISanPhamRepository sanPhamRepository, IKhachHangRepository khachHangRepository,
        JwtKhachHangService jwtKhachHangService, IHoaDonRepository hoaDonRepository, IChiTietHDRepository chiTietHDRepository)
        {
            this.sanPhamRepository = sanPhamRepository;
            this.KhachHangRepository = khachHangRepository;
            this.jwtKhachHang = jwtKhachHangService;
            this.hoaDonRepository = hoaDonRepository;
            this.chiTietHDRepository = chiTietHDRepository;
        }

        [HttpGet("{donhang}")]
        public ActionResult<ViewCartDto> LoadSPForCart(string donhang)
        {

            try
            {
                if (!Regex.IsMatch(donhang, @"^(\d{1,}-\d{1,}&){1,}$"))
                {
                    return null;
                };

                var sps = sanPhamRepository.SanPham_ListCart(donhang);
                long total = 0;
                int amount = 0;
                foreach (var item in sps)
                {
                    total += item.price * item.amount;
                    amount += item.amount;
                }

                var res = new ViewCartDto();
                res.ListSP = sps;
                res.total = total;
                res.amount = amount;

                return res;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("checkoutcart")]
        public ActionResult<HoaDon> CheckoutCart(CartDto cart)
        {

            try
            {
                // Phần xác thực tài khoản khách hàng để thực hiện thao tác sửa thông tin khách hàng
                var jwt = Request.Cookies["jwt-khachhang"];
                if (jwt == null)
                {
                    return NotFound(new { messgae = "Khách hàng chưa đăng nhập tài khoản!" });
                }
                var token = jwtKhachHang.Verify(jwt);
                var user = token.Issuer;
                var kh = KhachHangRepository.KhachHang_GetByUser(user);

                if (kh == null)
                {
                    return NotFound(new { messgae = "Không tìm thấy tài khoản khách hàng!" });
                }

                if (kh.status == 0)
                {
                    return NotFound(new { messgae = "Tài khoản khách hàng đã bị khóa!" });
                }

                List<int> listProduct_id = new List<int>();
                List<int> listSoluong = new List<int>();

                var list = cart.donhang.Trim('&');
                string[] arrlist = list.Split('&');
                string[] temp;
                int i = 0;
                long total = 0;

                for (i = 0; i < arrlist.Length - 1; ++i)
                {
                    if (!string.IsNullOrEmpty(arrlist[i]))
                    {
                        temp = arrlist[i].Split('-');
                        if (!string.IsNullOrEmpty(temp[0]))
                        {
                            listProduct_id.Add(int.Parse(temp[0]));
                            listSoluong.Add(int.Parse(temp[1]));
                        }
                    }
                }

                if (!string.IsNullOrEmpty(arrlist[i]))
                {
                    temp = arrlist[i].Split('-');
                    if (!string.IsNullOrEmpty(temp[0]))
                    {
                        listProduct_id.Add(int.Parse(temp[0]));
                        listSoluong.Add(int.Parse(temp[1]));
                    }
                }

                var sps = sanPhamRepository.SanPham_LoadByListIdSP(listProduct_id);
                foreach (var q in sps)
                {
                    // Kiểm tra kho còn sản phẩm ko
                    for (i = 0; i < listProduct_id.Count(); ++i)
                    {
                        if(q.Id == listProduct_id[i]) {
                            // Console.WriteLine(listProduct_id[i] + " " + listSoluong[i]);
                            if (q.amount < listSoluong[i])
                            {
                                Console.WriteLine(q.amount + " " + listSoluong[i]);
                                return BadRequest(new {messgae = "Sản phẩm trong kho đã hết!"});
                            }
                            else
                            {
                                q.amount = listSoluong[i];
                                total += q.price * listSoluong[i];
                            }
                        }
                        
                    }
                }

                HoaDon hd = new HoaDon();
                hd.KHuser = kh.user;
                //             hd.NVuser = hddto.NVuser;
                hd.phone = kh.phone;
                hd.address = cart.address;
                //             hd.date_receice = hddto.date_receice;
                hd.date_order = System.DateTime.Now;
                hd.total = total;
                hd.status = 1;

                hd = hoaDonRepository.HoaDon_Add(hd);
                // chiTietHDRepository.ChiTietHD_AddRangeWithListSP(sps, hd.Id);

                List<ChiTietHD> listCTHD = new List<ChiTietHD>();

                foreach (var item in sps)
                {
                    ChiTietHD newChiTietHD = new ChiTietHD();
                    newChiTietHD.billId = hd.Id;
                    newChiTietHD.productId = item.Id;
                    newChiTietHD.name = item.name;
                    newChiTietHD.amount = item.amount;
                    newChiTietHD.price = item.price;
                    newChiTietHD.img = item.img;
                    listCTHD.Add(newChiTietHD);
                }

                chiTietHDRepository.ChiTietHD_AddRange(listCTHD);

                // hd.chitietHDs = (ICollection<ChiTietHD>)chiTietHDRepository.ChiTietHD_AddRange(listCTHD);
                // hd.chitietHDs = (ICollection<ChiTietHD>)chiTietHDRepository.ChiTietHD_GetByBillId(hd.Id);
                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}