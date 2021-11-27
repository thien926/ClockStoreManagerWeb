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
    public class SanPhamController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly ISanPhamRepository sanPhamRepository;
        private readonly ILoaiSanPhamRepository loaiSanPhamRepository;
        private readonly IThuongHieuRepository thuongHieuRepository;
        private readonly IKieuMayRepository kieuMayRepository;
        private readonly IKieuDayRepository kieuDayRepository;
        public SanPhamController(ISanPhamRepository sanPhamRepository, ILoaiSanPhamRepository loaiSanPhamRepository,
        IThuongHieuRepository thuongHieuRepository, IKieuMayRepository kieuMayRepository,IKieuDayRepository kieuDayRepository ) {
            this.sanPhamRepository = sanPhamRepository;
            this.loaiSanPhamRepository = loaiSanPhamRepository;
            this.thuongHieuRepository = thuongHieuRepository;
            this.kieuMayRepository = kieuMayRepository;
            this.kieuDayRepository = kieuDayRepository;
        }

        [HttpGet]
        public IEnumerable<SanPham> GetAll() {
            return this.sanPhamRepository.SanPham_GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<SanPham> GetById(int id) {
            return this.sanPhamRepository.SanPham_GetById(id);
        }

        [HttpPost]
        public ActionResult<SanPham> AddSP(SanPhamDto spdto) {
            if(ModelState.IsValid){
                try {
                    SanPham sp = new SanPham();

                    // Mapping
                    sp.LSPId = spdto.LSPId;
                    sp.brandId = spdto.brandId;
                    sp.wireId = spdto.wireId;
                    sp.machineId = spdto.machineId;
                    sp.nccId = spdto.nccId;
                    sp.name = spdto.name;
                    sp.amount = spdto.amount;
                    sp.price = spdto.price;
                    sp.description = spdto.description;
                    sp.img = spdto.img;
                    sp.status = 0;

                    var SP = this.sanPhamRepository.SanPham_Add(sp);
                    return Created("success", SP);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        public ActionResult<SanPham> UpdateSP([FromBody] SanPhamDto spdto, int id) {
            if(ModelState.IsValid) {
                try {
                    var sp = sanPhamRepository.SanPham_GetById(id);

                    if(sp == null || spdto.Id != id) {
                        return NotFound();
                    }

                    // Mapping
                    sp.LSPId = spdto.LSPId;
                    sp.brandId = spdto.brandId;
                    sp.wireId = spdto.wireId;
                    sp.machineId = spdto.machineId;
                    sp.nccId = spdto.nccId;
                    sp.name = spdto.name;
                    sp.amount = spdto.amount;
                    sp.price = spdto.price;
                    sp.description = spdto.description;
                    sp.img = spdto.img;
                    sp.status = spdto.status;

                    var SP = this.sanPhamRepository.SanPham_Update(sp);
                    return Created("success", SP);
                }
                catch(Exception e) {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSP(int id) {
            var SP = sanPhamRepository.SanPham_GetById(id);
            if(SP == null) {
                return NotFound();
            }
            sanPhamRepository.SanPham_Delete(SP);
            return Ok(new { messgae = "Ok" });
        }

        [HttpPost("filter-admin")]
        public ViewProductAdminDto FilterAdmin(FilterDataAdminDto data) {
            int count;
            var SanPhams = sanPhamRepository.SanPham_FilterAdmin(data.search, data.sort, data.pageIndex, pageSize, out count);
            var ListSP = new PaginatedList<SanPham>(SanPhams, count, data.pageIndex, pageSize);
            ViewProductAdminDto view = new ViewProductAdminDto() {
                ListSP = ListSP,
                search = data.search,
                sort = data.sort,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListSP.TotalPages
            };
            return view;
        }

        // shop page
        [HttpPost("filter-shop")]
        public ViewProductsShopDto FilterShop(FilterProductsShopDto data) {
            int count;
            var SanPhams = sanPhamRepository.SanPham_FilterProductShop(data.lspId, data.branchId, data.machineId, data.wireId, data.priceFrom, data.priceTo, data.search, data.sort, data.pageIndex, pageSize, out count);
            var LSP = loaiSanPhamRepository.LoaiSanPham_GetById(data.lspId);
            var TH = thuongHieuRepository.ThuongHieu_GetById(data.branchId);
            var KM = kieuMayRepository.KieuMay_GetById(data.machineId);
            var KD = kieuDayRepository.KieuDay_GetById(data.wireId);
            var ListSP = new PaginatedList<SanPham>(SanPhams, count, data.pageIndex, pageSize);
            ViewProductsShopDto view = new ViewProductsShopDto() {
                ListSP = ListSP,
                LSP = LSP,
                TH = TH,
                KM = KM,
                KD = KD,
                priceFrom = data.priceFrom,
                priceTo = data.priceTo,
                search = data.search,
                sort = data.sort,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListSP.TotalPages
            };
            return view;
        }


        // home page
        [HttpGet("home-page")]
        public List<ListSPHomePage> FilterHomePage() {
            var LSP = loaiSanPhamRepository.LoaiSanPham_GetAll();
            var viewHomePage = new List<ListSPHomePage>();
            foreach (var item in LSP)
            {
                var newListHomePage = new ListSPHomePage();
                newListHomePage.LSP = item;
                newListHomePage.listSP = sanPhamRepository.SanPham_GetByLSPId(item.Id);
                viewHomePage.Add(newListHomePage);
            }
            return viewHomePage;
        }

        // product page
        [HttpGet("product/{id}")]
        public ActionResult<SanPham> GetProductDetail(int id) {
            var sanpham = this.sanPhamRepository.SanPham_GetById(id);
            var LSP = loaiSanPhamRepository.LoaiSanPham_GetById(sanpham.LSPId);
            var TH = thuongHieuRepository.ThuongHieu_GetById(sanpham.brandId);
            var KM = kieuMayRepository.KieuMay_GetById(sanpham.machineId);
            var KD = kieuDayRepository.KieuDay_GetById(sanpham.wireId);

            return sanpham;
        }
    }
}