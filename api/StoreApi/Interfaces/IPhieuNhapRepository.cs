using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Models;
namespace StoreApi.Interfaces
{
    public interface IPhieuNhapRepository
    {
        PhieuNhap PhieuNhap_Add(PhieuNhap hd); 
        PhieuNhap PhieuNhap_GetById(int id); 
        IEnumerable<PhieuNhap> PhieuNhap_GetAll();
        PhieuNhap PhieuNhap_Update(PhieuNhap pn); 
        void PhieuNhap_Delete(PhieuNhap pn); 
        IEnumerable<PhieuNhap> PhieuNhap_FilterAdmin(string search, int status, int pageIndex, int pageSize, out int count);
        IEnumerable<PhieuNhap> PhieuNhap_GetByUserNV(string user, int pageIndex, int pageSize, out int count);
        IEnumerable<PhieuNhap> PhieuNhap_GetByUserNV(string user);
        Boolean PhieuNhap_CheckUserNVAndId(int Id, string user);
    }
}