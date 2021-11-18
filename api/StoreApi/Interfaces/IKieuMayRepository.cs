using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Models;

namespace StoreApi.Interfaces
{
    public interface IKieuMayRepository
    {
        KieuMay KieuMay_Add(KieuMay sp); 
        KieuMay KieuMay_GetByUser(string user); 
        IEnumerable<KieuMay> KieuMay_GetAll();
        KieuMay KieuMay_Update(KieuMay NV); 
    }
}