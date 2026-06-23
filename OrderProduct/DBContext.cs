using OrderProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderProduct.Data;

public class OrderProductDbContext : DbContext
{
    public OrderProductDbContext(DbContextOptions<OrderProductDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Table> Table => Set<Table>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table>()
            .HasKey(op => new
            {
                op.OrderId,
                op.ProductId
            });

        modelBuilder.Entity<Table>()
            .HasOne(op => op.OrderInst)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<Table>()
            .HasOne(op => op.ProductInst)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);
    }
}