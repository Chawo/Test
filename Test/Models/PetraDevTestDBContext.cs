using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Test.Models
{
    public partial class PetraDevTestDBContext : DbContext
    {
        private readonly IConfiguration configuration;

        public PetraDevTestDBContext()
        {
        }

        public PetraDevTestDBContext(DbContextOptions<PetraDevTestDBContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("PetraDevTestDb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ArticleNo);

                entity.Property(e => e.ArticleNo)
                    .HasColumnName("articleNo")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArticleName)
                    .HasColumnName("articleName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");
            });
        }
    }
}
