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
                .Property(m => m.ReferenceNumber)
                .HasMaxLength(50)
                .IsRequired();


        }
    }
}
