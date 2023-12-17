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
    public class SupplyEntityConfiguration : IEntityTypeConfiguration<Supply>
    {
        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder.ToTable(nameof(Supply));

            builder.HasKey(s => s.Id);

            builder.Property(s => s.SupplyDate)
                .IsRequired();

            builder
                .HasOne(s => s.Supplier)
                .WithMany(sp => sp.Supplies)
                .HasForeignKey(s => s.SupplierId)
                .IsRequired();

            builder
                .HasMany(s => s.SupplyItems)
                .WithOne(si => si.Supply)
                .HasForeignKey(si => si.SupplyId)
                .IsRequired();
        }
    }
}
