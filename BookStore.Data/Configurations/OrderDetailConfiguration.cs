using BookStore.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.BookId)
                .IsRequired();

            builder
                .Property(m => m.Amount)
                .IsRequired();
            
            builder
                .Property(m => m.OrderId)
                .IsRequired();

            builder
                .Property(m => m.Price)
                .IsRequired();

            builder
                .HasOne(m => m.Order)
                .WithMany(a => a.OrderDetails)
                .HasForeignKey(m => m.OrderId);

            builder
               .ToTable("OrderDetail");
        }
    }
}
