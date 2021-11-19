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
        public ClockStoreDBContext(DbContextOptions<ClockStoreDBContext> options) : base(options) { }

        public DbSet<KieuDay> KieuDays { get; set; }
        public DbSet<KieuMay> KieuMays { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<NCC> NCCs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<Quyen> Quyens { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHD> ChiTietHDs { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<ChiTietPN> ChiTietPNs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<NhanVien>(entity => {
            //     entity.HasOne(field => field.quyenId)
            //     .WithMany(fk => fk.)
            // });

            modelBuilder.Entity<ChiTietHD>()
               .HasKey(c => new { c.billId, c.productId });
        }
    }
}