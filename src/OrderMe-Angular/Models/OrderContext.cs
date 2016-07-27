using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace OrderMe_Angular.OMA.Models
{
    public class OrderConext : DbContext
    {
        public OrderConext(DbContextOptions<OrderConext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual OrderLine OrderLine { get; set; }
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public virtual OrderLine OrderLine { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }

        public virtual OrderLine OrderLine { get; set; }
    }

    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int qty { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }

}