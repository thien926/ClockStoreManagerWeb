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
        public KhachHang KhachHang_Add(KhachHang KH)
        {
            context.KhachHangs.Add(KH);
            context.SaveChanges();
            return KH;
        }

        public IEnumerable<KhachHang> KhachHang_GetAll()
        {
            return context.KhachHangs.ToList();
        }

        public KhachHang KhachHang_GetByUser(string user)
        {
            return context.KhachHangs.FirstOrDefault(u => u.user == user);
        }

        public KhachHang KhachHang_Update(KhachHang KH)
        {
            context.KhachHangs.Update(KH);
            context.SaveChanges();
            return KH;
        }
    }
}