using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Models;

namespace StoreApi.Interfaces
{
    public interface ISanPhamRepository
    {
        SanPham SanPham_Add(SanPham sp); 
        SanPham SanPham_GetById(int id); 
        IEnumerable<SanPham> SanPham_GetAll();
        SanPham SanPham_Update(SanPham NV); 
        void SanPham_Delete(SanPham NV); 
        IEnumerable<SanPham> SanPham_FilterAdmin(string search, string sort, int pageIndex, int pageSize, out int count);
        IEnumerable<SanPham> SanPham_FilterProductShop(int lspId, int branchId, int machineId, int wireId, int priceFrom, int priceTo, string search, string sort, int pageIndex, int pageSize, out int count);

    }
}   