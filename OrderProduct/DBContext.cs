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
    public DbSet<OPTable> OPTable => Set<OPTable>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OPTable>()
            .HasKey(op => new
            {
                op.OrderId,
                op.ProductId
            });

        modelBuilder.Entity<OPTable>()
            .HasOne(op => op.OrderInst)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        modelBuilder.Entity<OPTable>()
            .HasOne(op => op.ProductInst)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);
    }
}