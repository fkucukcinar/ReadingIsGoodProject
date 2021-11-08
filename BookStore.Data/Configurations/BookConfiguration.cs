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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Author)
                .IsRequired()
                .HasMaxLength(200);
            builder
                .Property(m => m.Cost)
                .IsRequired();

            builder
                .Property(m => m.ISBN)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.Price)
                .IsRequired();

            builder
                .Property(m => m.Stock)
                .IsRequired();

            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(250); 

            builder
                .ToTable("Book");
        }
    }
}
