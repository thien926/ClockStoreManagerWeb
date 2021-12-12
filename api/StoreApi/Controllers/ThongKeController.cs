using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApi.DTOs;
using StoreApi.Interfaces;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThongKeController : ControllerBase
    {
        private readonly IHoaDonRepository hoaDonRepository;
        public ThongKeController(IHoaDonRepository hoaDonRepository) {
            this.hoaDonRepository = hoaDonRepository;
        }
        [HttpPost("doanhthu-year")]
        public Array DoanhThuYear(FilterDoanhThuTheoNamDto dto) {
            if(ModelState.IsValid) {
                var listHD = hoaDonRepository.HoaDon_DoanhThuInYear(dto.begin, dto.end);
                long val = 0;
                int year = 0;
                IDictionary<int, long> res = new Dictionary<int, long>();
                foreach (var item in listHD)
                {
                    year = item.date_order.Year;
                    if(res.TryGetValue(year, out val)) {
                        res[year] = val + item.total;
                    }
                    else {
                        res.Add(year, item.total);
                    }
                }

                return res.ToArray();
            }
            return null;
        }

        [HttpPost("doanhthu-month")]
        public Array DoanhThuMonth(FilterDoanhThuTheoThangDto dto) {
            if(ModelState.IsValid) {
                var listHD = hoaDonRepository.HoaDon_DoanhThuInMonth(dto.year, dto.begin, dto.end);
                long val = 0;
                int month = 0;
                IDictionary<int, long> res = new Dictionary<int, long>();
                foreach (var item in listHD)
                {
                    month = item.date_order.Month;
                    if(res.TryGetValue(month, out val)) {
                        res[month] = val + item.total;
                    }
                    else {
                        res.Add(month, item.total);
                    }
                }

                return res.ToArray();
            }
            return null;
        }
    }
}