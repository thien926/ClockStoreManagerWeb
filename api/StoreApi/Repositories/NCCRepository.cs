namespace StoreApi.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using StoreApi.Interfaces;
    using StoreApi.Models;
    public class NCCRepository : INCCRepository
    {
        private readonly ClockStoreDBContext context;
        public NCCRepository(ClockStoreDBContext context) {
            this.context = context;
        }
        public NCC NCC_Add(NCC ncc)
        {
            context.NCCs.Add(ncc);
            context.SaveChanges();
            return ncc;
        }

        public NCC NCC_GetById(int id)
        {
            // context.NCCs.
            return context.NCCs.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<NCC> NCC_GetAll()
        {
            return context.NCCs.ToList();
        }

        public NCC NCC_Update(NCC NCC)
        {
            context.NCCs.Update(NCC);
            context.SaveChanges();
            return NCC;
        }

        public void NCC_Delete(NCC NCC)
        {
            context.NCCs.Remove(NCC);
            context.SaveChanges();
        }

        public IEnumerable<NCC> NCC_FilterAdmin(string search, string sort, int pageIndex, int pageSize, out int count) {
            var query = context.NCCs.AsQueryable();
            
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
                    case "id-asc": query = query.OrderBy(m => m.Id);
                                    break;
                    case "id-desc": query = query.OrderByDescending(m => m.Id);
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