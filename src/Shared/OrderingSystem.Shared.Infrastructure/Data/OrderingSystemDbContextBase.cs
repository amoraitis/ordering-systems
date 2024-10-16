using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Shared.Common;
using OrderingSystem.Shared.Domain.Entities;

namespace OrderingSystem.Shared.Infrastructure.Data
{
    public class OrderingSystemDbContextBase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<PaymentProvider> PaymentProviders { get; set; }
        public DbSet<ProductSource> ProductSources { get; set; }

        public OrderingSystemDbContextBase(DbContextOptions<OrderingSystemDbContextBase> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define relationships, constraints, etc.
        }
    }
}
