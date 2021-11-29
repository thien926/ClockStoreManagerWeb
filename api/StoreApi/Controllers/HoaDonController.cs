using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Interfaces;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonRepository hoaDonRepository;
        public HoaDonController(IHoaDonRepository hoaDonRepository) {
            this.hoaDonRepository = hoaDonRepository;
        }

        // public IEnumerable<HoaDon> GetAll() {

        // }
    }
}