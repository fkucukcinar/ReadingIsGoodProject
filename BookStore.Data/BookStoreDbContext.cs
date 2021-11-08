using BookStore.Api.IdentityAuth;
using BookStore.Core.Models;
using BookStore.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CustomerConfiguration());

            builder.ApplyConfiguration(new BookConfiguration());

            builder.ApplyConfiguration(new OrderConfiguration());

            builder.ApplyConfiguration(new OrderDetailConfiguration());
        }
    }
}
