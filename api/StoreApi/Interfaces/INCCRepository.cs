using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Models;
namespace StoreApi.Interfaces
{
   public interface INCCRepository
    {
        NCC NCC_Add(NCC ncc); 
        NCC NCC_GetById(int id); 
        IEnumerable<NCC> NCC_GetAll();
        NCC NCC_Update(NCC ncc); 
        void NCC_Delete(NCC ncc); 
        IEnumerable<NCC> NCC_FilterAdmin(string search, string sort, int pageIndex, int pageSize, out int count);
    }
}