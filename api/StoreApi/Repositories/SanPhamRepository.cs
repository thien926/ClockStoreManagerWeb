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
            // context.SanPhams.
            return context.SanPhams.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<SanPham> SanPham_GetAll()
        {
            return context.SanPhams.ToList();
        }

        public SanPham SanPham_Update(SanPham SP)
        {
            context.SanPhams.Update(SP);
            context.SaveChanges();
            return SP;
        }

        public void SanPham_Delete(SanPham SP)
        {
            context.SanPhams.Remove(SP);
            context.SaveChanges();
        }

        public IEnumerable<SanPham> SanPham_FilterAdmin(string sort, int pageIndex, int pageSize, out int count) {
            var query = context.SanPhams.AsQueryable();
            count = query.Count();
            if(!string.IsNullOrEmpty(sort)){
                switch(sort){
                    case "name-asc": query = query.OrderBy(m => m.name);
                                    break;
                    case "name-desc": query = query.OrderByDescending(m => m.name);
                                    break;
                    case "price-asc": query = query.OrderBy(m => (int?)m.price);
                                    break;
                    case "price-desc": query = query.OrderByDescending(m => (int?)m.price);
                                    break;
                    default: break;
                }
            }

            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            if(pageIndex > TotalPages){
                pageIndex = TotalPages;
            }
            if(pageIndex < 1){
                pageIndex = 1;
            }

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }
    }
}