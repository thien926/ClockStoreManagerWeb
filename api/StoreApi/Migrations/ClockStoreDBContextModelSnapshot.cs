﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoreApi.Repositories;

namespace StoreApi.Migrations
{
    [DbContext(typeof(ClockStoreDBContext))]
    partial class ClockStoreDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreApi.Models.ChiTietHD", b =>
                {
                    b.Property<int>("billId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("price")
                        .HasColumnType("bigint");

                    b.HasKey("billId", "productId");

                    b.HasIndex("productId");

                    b.ToTable("ChiTietHDs");
                });

            modelBuilder.Entity("StoreApi.Models.HoaDon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KHuser")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("NVuser")
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date_order")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("date_receice")
                        .HasColumnType("datetime2");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<long>("total")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("KHuser");

                    b.HasIndex("NVuser");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("StoreApi.Models.KhachHang", b =>
                {
                    b.Property<string>("user")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateborn")
                        .HasColumnType("datetime2");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("user");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("StoreApi.Models.KieuDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("KieuDays");
                });

            modelBuilder.Entity("StoreApi.Models.KieuMay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("KieuMays");
                });

            modelBuilder.Entity("StoreApi.Models.LoaiSanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("LoaiSanPhams");
                });

            modelBuilder.Entity("StoreApi.Models.NCC", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("NCCs");
                });

            modelBuilder.Entity("StoreApi.Models.NhanVien", b =>
                {
                    b.Property<string>("user")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateborn")
                        .HasColumnType("datetime2");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("quyenId")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("user");

                    b.HasIndex("quyenId");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("StoreApi.Models.Quyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Quyens");
                });

            modelBuilder.Entity("StoreApi.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LSPId")
                        .HasColumnType("int");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<int>("brandId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("machineId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("nccId")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<int>("wireId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LSPId");

                    b.HasIndex("brandId");

                    b.HasIndex("machineId");

                    b.HasIndex("nccId");

                    b.HasIndex("wireId");

                    b.ToTable("SanPhams");
                });

            modelBuilder.Entity("StoreApi.Models.ThuongHieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("ThuongHieus");
                });

            modelBuilder.Entity("StoreApi.Models.ChiTietHD", b =>
                {
                    b.HasOne("StoreApi.Models.HoaDon", "bill")
                        .WithMany("chitietHDs")
                        .HasForeignKey("billId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreApi.Models.SanPham", "product")
                        .WithMany("chitietHDs")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bill");

                    b.Navigation("product");
                });

            modelBuilder.Entity("StoreApi.Models.HoaDon", b =>
                {
                    b.HasOne("StoreApi.Models.KhachHang", "KH")
                        .WithMany("hoadons")
                        .HasForeignKey("KHuser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreApi.Models.NhanVien", "NV")
                        .WithMany("hoaDons")
                        .HasForeignKey("NVuser");

                    b.Navigation("KH");

                    b.Navigation("NV");
                });

            modelBuilder.Entity("StoreApi.Models.NhanVien", b =>
                {
                    b.HasOne("StoreApi.Models.Quyen", "quyen")
                        .WithMany("NhanViens")
                        .HasForeignKey("quyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("quyen");
                });

            modelBuilder.Entity("StoreApi.Models.SanPham", b =>
                {
                    b.HasOne("StoreApi.Models.LoaiSanPham", "LSP")
                        .WithMany("SanPhams")
                        .HasForeignKey("LSPId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreApi.Models.ThuongHieu", "brand")
                        .WithMany("SanPhams")
                        .HasForeignKey("brandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreApi.Models.KieuMay", "machine")
                        .WithMany("SanPhams")
                        .HasForeignKey("machineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreApi.Models.NCC", "ncc")
                        .WithMany("SanPhams")
                        .HasForeignKey("nccId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreApi.Models.KieuDay", "wire")
                        .WithMany("SanPhams")
                        .HasForeignKey("wireId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("brand");

                    b.Navigation("LSP");

                    b.Navigation("machine");

                    b.Navigation("ncc");

                    b.Navigation("wire");
                });

            modelBuilder.Entity("StoreApi.Models.HoaDon", b =>
                {
                    b.Navigation("chitietHDs");
                });

            modelBuilder.Entity("StoreApi.Models.KhachHang", b =>
                {
                    b.Navigation("hoadons");
                });

            modelBuilder.Entity("StoreApi.Models.KieuDay", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("StoreApi.Models.KieuMay", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("StoreApi.Models.LoaiSanPham", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("StoreApi.Models.NCC", b =>
                {
                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("StoreApi.Models.NhanVien", b =>
                {
                    b.Navigation("hoaDons");
                });

            modelBuilder.Entity("StoreApi.Models.Quyen", b =>
                {
                    b.Navigation("NhanViens");
                });

            modelBuilder.Entity("StoreApi.Models.SanPham", b =>
                {
                    b.Navigation("chitietHDs");
                });

            modelBuilder.Entity("StoreApi.Models.ThuongHieu", b =>
                {
                    b.Navigation("SanPhams");
                });
#pragma warning restore 612, 618
        }
    }
}
