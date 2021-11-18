using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Repositories
{
    public class KieuMayRepository : IKieuMayRepository
    {
        private readonly ClockStoreDBContext context;
        public KieuMayRepository(ClockStoreDBContext context) {
            this.context = context;
        }
        public KieuMay KieuMay_Add(KieuMay NV)
        {
            context.KieuMays.Add(NV);
            context.SaveChanges();
            return NV;
        }

        public IEnumerable<KieuMay> KieuMay_GetAll()
        {
            return context.KieuMays.ToList();
        }

        public KieuMay KieuMay_GetByUser(string user)
        {
            return context.KieuMays.FirstOrDefault(u => u.user == user);
        }

        public KieuMay KieuMay_Update(KieuMay NV)
        {
            context.KieuMays.Update(NV);
            context.SaveChanges();
            return NV;
        }
    }
}