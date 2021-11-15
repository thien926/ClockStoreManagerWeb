using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Repositories
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly ClockStoreDBContext context;
        public SanPhamRepository(ClockStoreDBContext context) {
            this.context = context;
        }
        public SanPham SanPham_Add(SanPham sp)
        {
            context.SanPhams.Add(sp);
            context.SaveChanges();
            return sp;
        }

        public SanPham SanPham_GetById(int id)
        {
            return context.SanPhams.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<SanPham> SanPham_GetAll()
        {
            return context.SanPhams.ToList();
        }

        public SanPham SanPham_Update(SanPham NV)
        {
            context.SanPhams.Update(NV);
            context.SaveChanges();
            return NV;
        }

        public void SanPham_Delete(SanPham NV)
        {
            context.SanPhams.Remove(NV);
            context.SaveChanges();
        }
    }
}