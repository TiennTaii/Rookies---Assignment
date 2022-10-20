using assignment_two.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment_two.Data
{
    public class ProductDataContext : DbContext
    {
        public ProductDataContext(DbContextOptions<ProductDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .ToTable("Category")
            .HasKey(cat => cat.Id);

            modelBuilder.Entity<Category>()
                        .Property(cat => cat.Id)
                        .HasColumnName("CategoryId")
                        .HasColumnType("int")
                        .UseIdentityColumn(1)
                        .IsRequired();

            modelBuilder.Entity<Category>()
                        .Property(cat => cat.Name)
                        .HasColumnName("CategoryName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();

            modelBuilder.Entity<Product>()
                        .ToTable("Product")
            .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                        .HasOne<Category>(cat => cat.Category)
                        .WithMany(cat => cat.Products)
                        .HasForeignKey(cat => cat.CategoryId);

            modelBuilder.Entity<Product>()
                       .Property(cat => cat.Id)
                       .HasColumnName("ProductId")
                       .HasColumnType("int")
                       .UseIdentityColumn(1)
                       .IsRequired();

            modelBuilder.Entity<Product>()
                        .Property(cat => cat.Name)
                        .HasColumnName("ProductName")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Product>()
                        .Property(cat => cat.Manufacture)
                        .HasColumnName("ProductManufacture")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(500)
                        .IsRequired();

            modelBuilder.Entity<Product>()
                        .Property(cat => cat.CategoryId)
                        .HasColumnName("ProductCategoryId")
                        .HasColumnType("int")
                        .IsRequired();
        }
        public DbSet<Category> Categories { get; set; } = null!;
    }
}