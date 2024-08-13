using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data;

namespace Shoe_Store.Models
{
    public class Shoe_Store_DbContext: DbContext
    {
        public Shoe_Store_DbContext(DbContextOptions<Shoe_Store_DbContext> options):base(options)
        { 
        }

        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DanhGia> DanhGias { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<NguoiDung> NguoiDungs { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<AnhChiTiet> AnhChiTiets { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<SanPhamSize> sanPhamSizes { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình bảng SanPham
            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.SanPhamId);
                entity.HasOne(e => e.NhaCungCap)
                    .WithMany(ncc => ncc.SanPhams)
                    .HasForeignKey(e => e.NhaCungCapId);
                entity.HasMany(e => e.DanhGias)
                    .WithOne(dg => dg.SanPham)
                    .HasForeignKey(dg => dg.SanPhamId);
                entity.HasMany(e => e.SanPhamAnhChiTiets)
                    .WithOne(anh => anh.SanPham)
                    .HasForeignKey(anh => anh.SanPhamId);
                entity.HasMany(e => e.sanPhamSizes)
                    .WithOne(ss => ss.SanPham)
                    .HasForeignKey(ss => ss.SanPhamId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Cấu hình bảng DanhGia
            modelBuilder.Entity<DanhGia>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.SanPham)
                    .WithMany(sp => sp.DanhGias)
                    .HasForeignKey(e => e.SanPhamId);
                entity.HasOne(e => e.NguoiDung)
                    .WithMany(nguoiDung => nguoiDung.DanhGias)
                    .HasForeignKey(e => e.NguoiDungId);
            });

            // Cấu hình bảng DonHang
            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.NguoiDung)
                    .WithMany(nguoiDung => nguoiDung.DonHangs)
                    .HasForeignKey(e => e.NguoiDungId);
                entity.HasMany(e => e.ChiTietDonHangs)
                    .WithOne(ctdh => ctdh.DonHang)
                    .HasForeignKey(ctdh => ctdh.DonHangId);
            });

            // Cấu hình bảng SanPhamSize
            modelBuilder.Entity<SanPhamSize>(entity =>
            {
                entity.HasKey(ss => ss.SizeId);

                entity.HasOne(ss => ss.SanPham)
                    .WithMany(sp => sp.sanPhamSizes)
                    .HasForeignKey(ss => ss.SanPhamId)
                    .OnDelete(DeleteBehavior.Cascade);
            });



            // Cấu hình bảng Loai
            modelBuilder.Entity<Loai>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.SanPhams)
                    .WithMany(sp => sp.Loais)
                    .UsingEntity(j => j.ToTable("SanPhamLoai")); 
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.SanPhams)
                    .WithOne(sp => sp.NhaCungCap)
                    .HasForeignKey(sp => sp.NhaCungCapId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);
            });

            modelBuilder.Entity<AnhChiTiet>(entity =>
            {
                entity.HasKey(e => e.ChiTietId);
                entity.HasOne(e => e.SanPham)
                    .WithMany(sp => sp.SanPhamAnhChiTiets)
                    .HasForeignKey(e => e.SanPhamId);
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.DonHang)
                    .WithMany(dh => dh.ChiTietDonHangs)
                    .HasForeignKey(e => e.DonHangId);
                entity.HasOne(e => e.SanPham)
                    .WithMany(sp => sp.ChiTietDonHangs)
                    .HasForeignKey(e => e.SanPhamId);
            });
        }
    }
}

