using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Repositories
{
    public class KhachHangRepository : IKhachHangRepository
    {
        private readonly ClockStoreDBContext context;
        public KhachHangRepository(ClockStoreDBContext context) {
            this.context = context;
        }
        public KhachHang KhachHang_Add(KhachHang sp)
        {
            context.KhachHangs.Add(sp);
            context.SaveChanges();
            return sp;
        }

        public KhachHang KhachHang_GetByUser(string user)
        {
            return context.KhachHangs.FirstOrDefault(u => u.user == user);
        }

        public IEnumerable<KhachHang> KhachHang_GetAll()
        {
            return context.KhachHangs.ToList();
        }

        public KhachHang KhachHang_Update(KhachHang SP)
        {
            context.KhachHangs.Update(SP);
            context.SaveChanges();
            return SP;
        }

        public void KhachHang_Delete(KhachHang SP)
        {
            context.KhachHangs.Remove(SP);
            context.SaveChanges();
        }

        public IEnumerable<KhachHang> KhachHang_FilterAdmin(string search, string sort, int pageIndex, int pageSize, out int count) {
            var query = context.KhachHangs.AsQueryable();
            
            if(!string.IsNullOrEmpty(search)) {
                search = search.ToLower();
                query = query.Where(m => m.name.ToLower().Contains(search));
            }

            count = query.Count();
            if(!string.IsNullOrEmpty(sort)){
                switch(sort){
                    case "name-asc": query = query.OrderBy(m => m.name);
                                    break;
                    case "name-desc": query = query.OrderByDescending(m => m.name);
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