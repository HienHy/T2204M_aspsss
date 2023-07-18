using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace T2204M_API.Entities;

public partial class T2204mApiContext : DbContext
{
    public T2204mApiContext()
    {
    }

    public T2204mApiContext(DbContextOptions<T2204mApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =localhost,1433;Database=T2204M_API;User Id=sa;Password=Password123@jkl#;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brands__3214EC07FB035F6B");

            entity.ToTable("brands");

            entity.HasIndex(e => e.Name, "UQ__brands__737584F636A14BAA").IsUnique();

            entity.Property(e => e.Logo).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3214EC079989A128");

            entity.ToTable("categories");

            entity.HasIndex(e => e.Name, "UQ__categori__737584F67E5245EA").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3214EC07D0A46277");

            entity.ToTable("products");

            entity.HasIndex(e => e.Name, "UQ__products__737584F6C14FE990").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("Category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.BrandId).HasColumnName("Brand_id");
            entity.Property(e => e.Thumbnail).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__products__Catego__534D60F1");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__products__Brand__5441852A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
