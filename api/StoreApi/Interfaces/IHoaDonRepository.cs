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
    }
}