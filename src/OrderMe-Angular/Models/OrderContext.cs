using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderMe_Angular.OMA.Models
{
    public class OrderConext : DbContext
    {
        public OrderConext(DbContextOptions<OrderConext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderLine>()
                .HasKey(t => new { t.OrderLineId, t.OrderId, t.ProductId });

            modelBuilder.Entity<OrderLine>()
                .HasOne(pt => pt.Order)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(pt => pt.OrderId);

            modelBuilder.Entity<OrderLine>()
                .HasOne(pt => pt.Product)
                .WithMany(t => t.OrderLines)
                .HasForeignKey(pt => pt.ProductId);
        }

    }

    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }
        
        public int Price { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }

        public List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine
    {
        public int OrderLineId { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

}