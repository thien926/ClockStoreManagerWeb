using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApi.DTOs;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ISanPhamRepository sanPhamRepository;
        public CartController(ISanPhamRepository sanPhamRepository) {
            this.sanPhamRepository = sanPhamRepository;
        }

        [HttpGet("{donhang}")]
        public ActionResult<ViewCartDto> LoadSPForCart(string donhang) {
            
            try {
                var sps = sanPhamRepository.SanPham_ListCart(donhang);
                long total = 0;
                int amount = 0;
                foreach (var item in sps) {
                    total += item.price * item.amount;
                    amount += item.amount;
                }

                var res = new ViewCartDto();
                res.ListSP = sps;
                res.total = total;
                res.amount = amount;

                return res;
            }
            catch(Exception e) {
                return null;
            }
        }
    }
}