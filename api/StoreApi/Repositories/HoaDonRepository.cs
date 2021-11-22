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

        public IEnumerable<HoaDon> HoaDon_FilterAdmin(string search, string sort, int pageIndex, int pageSize, out int count) {
            var query = context.HoaDons.AsQueryable();
            
            if(!string.IsNullOrEmpty(search)) {
                search = search.ToLower();
                query = query.Where(m => m.name.ToLower().Contains(search));
            }

            count = query.Count();
            if(!string.IsNullOrEmpty(sort)){
                switch(sort){
                    
                    case "KHuser-asc": query = query.OrderBy(m => m.KHuser);
                                    break;
                    case "KHuser-desc": query = query.OrderByDescending(m => m.KHuser);
                                    break;
                    case "NVuser-asc": query = query.OrderBy(m => m.NVuser);
                                    break;
                    case "NVuser-desc": query = query.OrderByDescending(m => m.NVuser);
                                    break;                
                    case "total-asc": query = query.OrderBy(m => (long?)m.total);
                                    break;
                    case "total-desc": query = query.OrderByDescending(m => (long?)m.total);
                                    break;
                    case "status-asc": query = query.OrderBy(m => (int?)m.status);
                                    break;
                    case "status-desc": query = query.OrderByDescending(m => (int?)m.status);
                                    break;                
                    default: break;
                }
            }

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