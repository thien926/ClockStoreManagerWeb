using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Models;
using StoreApi.Services;

namespace StoreApi.DTOs
{
    public class ViewProductsShopDto
    {
        public PaginatedList<SanPham> ListSP { get; set; }
        public LoaiSanPham LSP { get; set; }
        public ThuongHieu TH { get; set; }
        public KieuMay KM { get; set; }
        public KieuDay KD { get; set; }
        public int priceFrom { get; set; }
        public int priceTo { get; set; }
        public string search { get; set;}
        public string sort { get; set;}
        public int pageIndex{ get; set; }

        // Kích thước của 1 trang có bao nhiêu sản phẩm
        public int pageSize { get; set; }
        // Số lượng sản phẩm trong database
        public int count { get; set; }
        // Số phân trang cần hiện
        public int range { get; set; }
        // Tổng database có bao nhiêu trang
        public int totalPage { get; set; }
    }
}