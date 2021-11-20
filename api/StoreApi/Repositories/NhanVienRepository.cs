using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Repositories
{
    public class NhanVienRepository : INhanVienRepository
    {
        private readonly ClockStoreDBContext context;
        public NhanVienRepository(ClockStoreDBContext context) {
            this.context = context;
        }
        public NhanVien NhanVien_Add(NhanVien NV)
        {
            context.NhanViens.Add(NV);
            context.SaveChanges();
            return NV;
        }

        public IEnumerable<NhanVien> NhanVien_GetAll()
        {
            return context.NhanViens.ToList();
        }

        public NhanVien NhanVien_GetByUser(string user)
        {
            return context.NhanViens.FirstOrDefault(u => u.user == user);
        }

        public NhanVien NhanVien_Update(NhanVien NV)
        {
            context.NhanViens.Update(NV);
            context.SaveChanges();
            return NV;
        }
    }
}