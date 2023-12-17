using DiyorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Infrastructure.Persistence.Configurations
{
    public class SupplierEntityConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable(nameof(Supplier));

            builder.HasKey(s => s.Id);

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50); 

            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50);  

            builder.Property(s => s.PhoneNumber)
                .HasMaxLength(20); 

            builder.Property(s => s.Company)
                .HasMaxLength(100);  

            builder
                .HasMany(s => s.Supplies)
                .WithOne(sp => sp.Supplier)
                .HasForeignKey(sp => sp.SupplierId)
                .IsRequired();
        }
    }
}
