using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Repositories
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly ClockStoreDBContext context;
        public HoaDonRepository(ClockStoreDBContext context) {
            this.context = context;
        }
        public HoaDon HoaDon_Add(HoaDon hd)
        {
            context.HoaDons.Add(hd);
            context.SaveChanges();
            return hd;
        }

        public void HoaDon_Delete(HoaDon hd)
        {
            context.HoaDons.Remove(hd);
            context.SaveChanges();
        }

        public IEnumerable<HoaDon> HoaDon_GetAll()
        {
            return context.HoaDons.ToList();
        }

        public HoaDon HoaDon_GetById(int id)
        {
            return context.HoaDons.FirstOrDefault(m => m.Id == id);
        }

        public HoaDon HoaDon_Update(HoaDon hd)
        {
            context.HoaDons.Update(hd);
            context.SaveChanges();
            return hd;
        }
    }
}