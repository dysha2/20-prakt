using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assortiment.Model
{
    public partial class AssortimentContext : DbContext
    {
        public AssortimentContext()
        {
        }

        public AssortimentContext(DbContextOptions<AssortimentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<KindOfProduct> KindOfProducts { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductBrand> ProductBrands { get; set; } = null!;
        public virtual DbSet<ProductMaterial> ProductMaterials { get; set; } = null!;
        public virtual DbSet<Provider> Providers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Assortiment;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<KindOfProduct>(entity =>
            {
                entity.ToTable("KindOfProduct");

                entity.Property(e => e.KindOfProductId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.MateriaId);

                entity.ToTable("Material");

                entity.Property(e => e.MateriaId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Comment)
                    .HasMaxLength(50)
                    .HasColumnName("comment");

                entity.Property(e => e.PackagePrice)
                    .HasColumnType("money")
                    .HasColumnName("Package_price");

                entity.Property(e => e.Price1).HasColumnType("money");

                entity.Property(e => e.Price2).HasColumnType("money");

                entity.Property(e => e.Price3).HasColumnType("money");

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.HasOne(d => d.KindOfProduct)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.KindOfProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_KindOfProduct");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Provider");
            });

            modelBuilder.Entity<ProductBrand>(entity =>
            {
                entity.ToTable("ProductBrand");

                entity.Property(e => e.ProductBrandId).ValueGeneratedNever();

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ProductBrands)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductBrand_Brand");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductBrands)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductBrand_Product");
            });

            modelBuilder.Entity<ProductMaterial>(entity =>
            {
                entity.HasKey(e => e.ProductMateriald);

                entity.ToTable("ProductMaterial");

                entity.Property(e => e.ProductMateriald).ValueGeneratedNever();

                entity.HasOne(d => d.MaterialdNavigation)
                    .WithMany(p => p.ProductMaterials)
                    .HasForeignKey(d => d.Materiald)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductMaterial_Material");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductMaterials)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductMaterial_Product");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.Property(e => e.ProviderId).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
