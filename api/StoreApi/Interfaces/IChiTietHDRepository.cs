using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Models;
namespace StoreApi.Interfaces
{
    public interface IChiTietHDRepository
    {
        ChiTietHD ChiTietHD_Add(ChiTietHD hd); 
        // ChiTietHD ChiTietHD_GetById(int id); 
        IEnumerable<ChiTietHD> ChiTietHD_GetAll();
        IEnumerable<ChiTietHD> ChiTietHD_GetByBillId(int billId);
        ChiTietHD ChiTietHD_Update(ChiTietHD hd); 
        void ChiTietHD_Delete(ChiTietHD hd); 
        IEnumerable<ChiTietHD> ChiTietHD_FilterAdmin(string search, string sort, int pageIndex, int pageSize, out int count);
        IEnumerable<ChiTietHD> ChiTietHD_AddRange(IEnumerable<ChiTietHD> list);
        // void ChiTietHD_AddRangeWithListSP(IEnumerable<SanPham> list, int billId);
    }
}