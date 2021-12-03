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
        public PhieuNhap PhieuNhap_Add(PhieuNhap pn)
        {
            context.PhieuNhaps.Add(pn);
            context.SaveChanges();
            return pn;
        }

        public PhieuNhap PhieuNhap_GetById(int id)
        {
            // context.PhieuNhaps.
            return context.PhieuNhaps.FirstOrDefault(o => o.Id == id);
        }
//Không chắc phần này
        public Boolean PhieuNhap_CheckUserNVAndId(int Id, string user)
        {
            var query = context.PhieuNhaps.AsQueryable();
            query = query.Where(m => (m.Id == Id) && (m.NVuser == user));
            int count = query.Count();
            
            return count > 0;
        }
//không chắc phần này
        public IEnumerable<PhieuNhap> PhieuNhap_GetByUserNV(string user, int pageIndex, int pageSize, out int count)
        {
            var query = context.PhieuNhaps.AsQueryable();
            query = query.Where(m => m.NVuser == user);

            count = query.Count();
            int TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            
            if(pageIndex < 1){
                pageIndex = 1;
            }
            query = query.OrderBy(m => m.status);
            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        public IEnumerable<PhieuNhap> PhieuNhap_GetByUserNV(string user)
        {
            var query = context.PhieuNhaps.AsQueryable();
            query = query.Where(m => m.NVuser == user);
            return query.ToList();
        }

        public IEnumerable<PhieuNhap> PhieuNhap_GetAll()
        {
            return context.PhieuNhaps.ToList();
        }

        public PhieuNhap PhieuNhap_Update(PhieuNhap PN)
        {
            context.PhieuNhaps.Update(PN);
            context.SaveChanges();
            return PN;
        }

        public void PhieuNhap_Delete(PhieuNhap PN)
        {
            context.PhieuNhaps.Remove(PN);
            context.SaveChanges();
        }

        public IEnumerable<PhieuNhap> PhieuNhap_FilterAdmin(string search, int status, int pageIndex, int pageSize, out int count) {
            var query = context.PhieuNhaps.AsQueryable();
            
            if(!string.IsNullOrEmpty(search)) {
                search = search.ToLower();
                query = query.Where(m => (m.NVuser.ToLower().Contains(search)) || 
                    (m.NVuser.ToLower().Contains(search)) || (m.address.ToLower().Contains(search)));
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