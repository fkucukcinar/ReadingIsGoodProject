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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(m => m.BirthDate)
                .IsRequired();

            builder
                .Property(m => m.Address)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(m => m.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(m => m.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Password)
                .IsRequired()
                .HasMaxLength(50);


            builder
                .ToTable("Customer");
        }

    }
}
