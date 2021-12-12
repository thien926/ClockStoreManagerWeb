using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApi.Interfaces;
using StoreApi.Models;

namespace StoreApi.Repositories
{
    public class ChiTietHDRepository : IChiTietHDRepository
    {
        private readonly ClockStoreDBContext context;
        public ChiTietHDRepository(ClockStoreDBContext context) {
            this.context = context;
        }
        public ChiTietHD ChiTietHD_Add(ChiTietHD hd)
        {
            context.ChiTietHDs.Add(hd);
            context.SaveChanges();
            return hd;
        }

        public IEnumerable<ChiTietHD> ChiTietHD_AddRange(IEnumerable<ChiTietHD> list)
        {
            context.ChiTietHDs.AddRange(list);
            context.SaveChanges();
            return list;
        }

        // public void ChiTietHD_AddRangeWithListSP(IEnumerable<SanPham> list, int billId)
        // {
        //     foreach (var item in list)
        //     {
        //         ChiTietHD newChiTietHD = new ChiTietHD();
        //         newChiTietHD.billId = billId;
        //         newChiTietHD.productId = item.Id;
        //         newChiTietHD.name = item.name;
        //         newChiTietHD.amount = item.amount;
        //         newChiTietHD.price = item.price;
        //         newChiTietHD.img = item.img;
        //         context.ChiTietHDs.Add(newChiTietHD);
        //     }
        //     context.SaveChanges();
        // }

        // public ChiTietHD ChiTietHD_GetById(int id)
        // {
        //     // context.ChiTietHDs.
        //     return context.ChiTietHDs.FirstOrDefault(o => o.Id == id);
        // }

        public IEnumerable<ChiTietHD> ChiTietHD_GetAll()
        {
            return context.ChiTietHDs.ToList();
        }

        public IEnumerable<ChiTietHD> ChiTietHD_GetByBillId(int billId)
        {
            var query = context.ChiTietHDs.AsQueryable();
            query = query.Where(m => m.billId == billId);
            return query.ToList();
        }

        public ChiTietHD ChiTietHD_Update(ChiTietHD CTHD)
        {
            context.ChiTietHDs.Update(CTHD);
            context.SaveChanges();
            return CTHD;
        }

        public void ChiTietHD_Delete(ChiTietHD CTHD)
        {
            context.ChiTietHDs.Remove(CTHD);
            context.SaveChanges();
        }

        public IEnumerable<ChiTietHD> ChiTietHD_FilterAdmin(string search, string sort, int pageIndex, int pageSize, out int count) {
            var query = context.ChiTietHDs.AsQueryable();
            
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
                    case "price-asc": query = query.OrderBy(m => (long?)m.price);
                                    break;
                    case "price-desc": query = query.OrderByDescending(m => (long?)m.price);
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

        public IEnumerable<ChiTietHD> ChiTietHD_GetByListBill(List<int> list)
        {
            var query = context.ChiTietHDs.AsQueryable();
            query = query.Where(m => list.Contains(m.billId));
            query = query.OrderByDescending(m => m.amount);
            return query.Take(12).ToList();
        }
    }
}