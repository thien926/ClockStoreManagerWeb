using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NhapHangController : ControllerBase
    {
        private readonly ISanPhamRepository sanPhamRepository;
        private readonly IKieuDayRepository kieuDayRepository;
        private readonly IKieuMayRepository kieuMayRepository;
        private readonly ILoaiSanPhamRepository loaiSanPhamRepository;
        private readonly IThuongHieuRepository thuongHieuRepository;
        public NhapHangController(ISanPhamRepository sanPhamRepository, IKieuDayRepository kieuDayRepository,
        IKieuMayRepository kieuMayRepository, ILoaiSanPhamRepository loaiSanPhamRepository, IThuongHieuRepository thuongHieuRepository) {
            this.sanPhamRepository = sanPhamRepository;
            this.kieuDayRepository = kieuDayRepository;
            this.kieuMayRepository = kieuMayRepository;
            this.loaiSanPhamRepository = loaiSanPhamRepository;
            this.thuongHieuRepository = thuongHieuRepository;
        }

        [HttpGet]
        public IEnumerable<SanPham> GetAll() {
            var kds = kieuDayRepository.KieuDay_GetAll();
            var kms = kieuMayRepository.KieuMay_GetAll();
            var ths = thuongHieuRepository.ThuongHieu_GetAll();
            var lsps = loaiSanPhamRepository.LoaiSanPham_GetAll();
            return this.sanPhamRepository.SanPham_GetAll();;
            // var sps = this.sanPhamRepository.SanPham_GetAll();

            // var res = new List<SanPham>();

            // foreach (var item in sps)
            // {
            //     if(item.brand.name.Contains("KASSAW")) {
            //         res.Add(item);
            //     }
            // }

            // return res;
        }

    }
}