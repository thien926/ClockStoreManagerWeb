using System;
using System.Collections.Generic;
using System.Linq;
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
    public class NhapHangController : ControllerBase
    {
        private int pageSize = 9;
        private int range = 9;
        private readonly ISanPhamRepository sanPhamRepository;
        private readonly IKieuDayRepository kieuDayRepository;
        private readonly IKieuMayRepository kieuMayRepository;
        private readonly ILoaiSanPhamRepository loaiSanPhamRepository;
        private readonly IThuongHieuRepository thuongHieuRepository;
        public NhapHangController(ISanPhamRepository sanPhamRepository, IKieuDayRepository kieuDayRepository,
        IKieuMayRepository kieuMayRepository, ILoaiSanPhamRepository loaiSanPhamRepository, IThuongHieuRepository thuongHieuRepository)
        {
            this.sanPhamRepository = sanPhamRepository;
            this.kieuDayRepository = kieuDayRepository;
            this.kieuMayRepository = kieuMayRepository;
            this.loaiSanPhamRepository = loaiSanPhamRepository;
            this.thuongHieuRepository = thuongHieuRepository;
        }

        [HttpGet]
        public IEnumerable<SanPham> GetAll()
        {
            var kds = kieuDayRepository.KieuDay_GetAll();
            var kms = kieuMayRepository.KieuMay_GetAll();
            var ths = thuongHieuRepository.ThuongHieu_GetAll();
            var lsps = loaiSanPhamRepository.LoaiSanPham_GetAll();
            return this.sanPhamRepository.SanPham_GetAll(); ;
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

        

        [HttpPost("filter-admin")]
        public ViewLoadProductNhapHangAdminDto FilterAdmin(FilterLoadSanPhamNhapHangDto data)
        {
            var kds = kieuDayRepository.KieuDay_GetAll();
            var kms = kieuMayRepository.KieuMay_GetAll();
            var ths = thuongHieuRepository.ThuongHieu_GetAll();
            var lsps = loaiSanPhamRepository.LoaiSanPham_GetAll();
            var sps = this.sanPhamRepository.SanPham_GetAll();
            var res = new List<SanPham>();

            data.search = data.search.ToLower();
            int id, count;

            if(!string.IsNullOrEmpty(data.search)) {
                switch (data.typeSearch)
                {
                    case "id":
                        if (Int32.TryParse(data.search, out id))
                        {
                            foreach (var item in sps)
                            {
                                if (item.Id == id)
                                {
                                    res.Add(item);
                                }
                            }
                        }
                        break;
                    case "name":
                        foreach (var item in sps)
                        {
                            if (item.name.ToLower().Contains(data.search))
                            {
                                res.Add(item);
                            }
                        }
                        break;
                    case "lsp":
                        foreach (var item in sps)
                        {
                            if (item.LSP.name.ToLower().Contains(data.search))
                            {
                                res.Add(item);
                            }
                        }
                        break;
                    case "th":
                        foreach (var item in sps)
                        {
                            if (item.brand.name.ToLower().Contains(data.search))
                            {
                                res.Add(item);
                            }
                        }
                        break;
                    case "kd":
                        foreach (var item in sps)
                        {
                            if (item.wire.name.ToLower().Contains(data.search))
                            {
                                res.Add(item);
                            }
                        }
                        break;
                    case "km":
                        foreach (var item in sps)
                        {
                            if (item.machine.name.ToLower().Contains(data.search))
                            {
                                res.Add(item);
                            }
                        }
                        break;
                    default:
                        if (Int32.TryParse(data.search, out id))
                        {
                            foreach (var item in sps)
                            {
                                if (item.Id == id || item.name.ToLower().Contains(data.search) || item.LSP.name.ToLower().Contains(data.search) ||
                                item.brand.name.ToLower().Contains(data.search) || item.wire.name.ToLower().Contains(data.search) || 
                                item.machine.name.ToLower().Contains(data.search))
                                {
                                    res.Add(item);
                                }
                            }
                        }
                        else {
                            foreach (var item in sps)
                            {
                                if (item.name.ToLower().Contains(data.search) || item.LSP.name.ToLower().Contains(data.search) ||
                                item.brand.name.ToLower().Contains(data.search) || item.wire.name.ToLower().Contains(data.search) || 
                                item.machine.name.ToLower().Contains(data.search))
                                {
                                    res.Add(item);
                                }
                            }
                        }
                        
                        break;
                }
            }
            else {
                res = (List<SanPham>)sps;
            }

            count = res.Count();
            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            
            if(data.pageIndex < 1){
                data.pageIndex = 1;
            }

            res = res.Skip((data.pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();

            var ListSP = new PaginatedList<SanPham>(res, count, data.pageIndex, pageSize);
            ViewLoadProductNhapHangAdminDto view = new ViewLoadProductNhapHangAdminDto()
            {
                ListSP = ListSP,
                search = data.search,
                typeSearch = data.typeSearch,
                pageIndex = data.pageIndex,
                pageSize = this.pageSize,
                count = count,
                range = this.range,
                totalPage = ListSP.TotalPages
            };
            return view;
        }
    }
}