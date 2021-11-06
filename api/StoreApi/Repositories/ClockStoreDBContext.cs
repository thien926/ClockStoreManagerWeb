using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApi.Models;

namespace StoreApi.Repositories
{
    public class ClockStoreDBContext : DbContext
    {
        public ClockStoreDBContext(DbContextOptions<ClockStoreDBContext> options) : base(options) {}

        public DbSet<KieuDay> KieuDays { get; set; }
        public DbSet<KieuMay> KieuMays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

        }
    }
}