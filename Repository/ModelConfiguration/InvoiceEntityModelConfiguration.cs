using EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ModelConfiguration
{
    /// <summary>
    /// Invoice entity model configuration
    /// </summary>
    public class InvoiceEntityModelConfiguration : IEntityTypeConfiguration<Invoices>
    {
        public void Configure(EntityTypeBuilder<Invoices> builder)
        {
            builder
                .HasKey(m => m.InvoiceID);
            builder
                .HasIndex(m => m.ReferenceNumber)
                .IsUnique();
            builder
                .Property(m => m.ReferenceNumber)
                .HasMaxLength(50)
                .IsRequired();
            
            // relation mappings
            builder
                .HasMany(m => m.InvoiceItems)
                .WithOne(m => m.Invoice)
                .HasForeignKey(m => m.InvoiceID);
        }
    }

    public class InvoiceItemEntityModelConfiguration : IEntityTypeConfiguration<InvoiceItems>
    {
        public void Configure(EntityTypeBuilder<InvoiceItems> builder)
        {
            builder
                .HasKey(m => m.InvoiceItemID);

            builder
                .Property(m => m.ItemTitle)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(m => m.ItemDescription)
                .HasMaxLength(2000);

            builder
                .HasOne(m => m.Invoice)
                .WithMany(m => m.InvoiceItems)
                .HasForeignKey(m => m.InvoiceID);
        }
    }
}
