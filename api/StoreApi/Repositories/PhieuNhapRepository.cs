using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Repositories
{
    public class PhieuNhapRepository : IPhieuNhapRepository
    {
        private readonly ClockStoreDBContext context;
        public PhieuNhapRepository(ClockStoreDBContext context) {
            this.context = context;
        }
        public PhieuNhap PhieuNhap_Add(PhieuNhap sp)
        {
            context.PhieuNhaps.Add(sp);
            context.SaveChanges();
            return sp;
        }

        public PhieuNhap PhieuNhap_GetById(int id)
        {
            // context.PhieuNhaps.
            return context.PhieuNhaps.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<PhieuNhap> PhieuNhap_GetAll()
        {
            return context.PhieuNhaps.ToList();
        }

        public PhieuNhap PhieuNhap_Update(PhieuNhap SP)
        {
            context.PhieuNhaps.Update(SP);
            context.SaveChanges();
            return SP;
        }

        public void PhieuNhap_Delete(PhieuNhap SP)
        {
            context.PhieuNhaps.Remove(SP);
            context.SaveChanges();
        }
    }
}