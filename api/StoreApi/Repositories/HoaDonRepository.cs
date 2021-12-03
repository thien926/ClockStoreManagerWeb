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

        public HoaDon HoaDon_GetById(int id)
        {
            // context.HoaDons.
            return context.HoaDons.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<HoaDon> HoaDon_GetByUserKH(string user, int pageIndex, int pageSize, out int count)
        {
            var query = context.HoaDons.AsQueryable();
            query = query.Where(m => m.KHuser == user);

            count = query.Count();
            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            
            if(pageIndex < 1){
                pageIndex = 1;
            }
            query = query.OrderBy(m => m.status);
            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        public IEnumerable<HoaDon> HoaDon_GetByUserNV(string user)
        {
            var query = context.HoaDons.AsQueryable();
            query = query.Where(m => m.NVuser == user);
            return query.ToList();
        }

        public IEnumerable<HoaDon> HoaDon_GetAll()
        {
            return context.HoaDons.ToList();
        }

        public HoaDon HoaDon_Update(HoaDon HD)
        {
            context.HoaDons.Update(HD);
            context.SaveChanges();
            return HD;
        }

        public void HoaDon_Delete(HoaDon HD)
        {
            context.HoaDons.Remove(HD);
            context.SaveChanges();
        }

        public IEnumerable<HoaDon> HoaDon_FilterAdmin(string search, int status, int pageIndex, int pageSize, out int count) {
            var query = context.HoaDons.AsQueryable();
            
            if(!string.IsNullOrEmpty(search)) {
                search = search.ToLower();
                query = query.Where(m => (m.NVuser.ToLower().Contains(search)) || 
                    (m.KHuser.ToLower().Contains(search)) || (m.address.ToLower().Contains(search)));
            }
            
            if(status > 0) {
                query = query.Where(m => m.status == status);
            }

            count = query.Count();

            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            // if(pageIndex > TotalPages){
            //     pageIndex = TotalPages;
            // }
            if(pageIndex < 1){
                pageIndex = 1;
            }

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }
    }
}