using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Models;

namespace StoreApi.Interfaces
{
    public interface IKhachHangRepository
    {
        KhachHang KhachHang_Add(KhachHang sp); 
        KhachHang KhachHang_GetByUser(string user); 
        IEnumerable<KhachHang> KhachHang_GetAll();
        KhachHang KhachHang_Update(KhachHang KH); 
    }
}