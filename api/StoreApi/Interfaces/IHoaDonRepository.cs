using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Models;
namespace StoreApi.Interfaces
{
    public interface IHoaDonRepository
    {
        HoaDon HoaDon_Add(HoaDon hd); 
        HoaDon HoaDon_GetById(int id); 
        IEnumerable<HoaDon> HoaDon_GetAll();
        HoaDon HoaDon_Update(HoaDon hd); 
        void HoaDon_Delete(HoaDon hd); 
        IEnumerable<HoaDon> HoaDon_FilterAdmin(string search, int status, int pageIndex, int pageSize, out int count);
        IEnumerable<HoaDon> HoaDon_GetByUserKH(string user, int pageIndex, int pageSize, out int count);
        IEnumerable<HoaDon> HoaDon_GetByUserNV(string user);
        Boolean HoaDon_CheckUserKHAndId(int Id, string user);
        IEnumerable<HoaDon> HoaDon_FilterBeginEndInYear(int begin, int end);
        IEnumerable<HoaDon> HoaDon_FilterBeginEndInMonth(int year, int begin, int end);
    }
}