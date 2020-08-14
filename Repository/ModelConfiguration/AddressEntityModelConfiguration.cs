using EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ModelConfiguration
{

    /// <summary>
    /// Address entity model configuration
    /// </summary>
    public class AddressEntityModelConfiguration : IEntityTypeConfiguration<Addresses>
    {
        public void Configure(EntityTypeBuilder<Addresses> builder)
        {
            builder
                .HasKey(m => m.AddressID);
          
            builder
                .Property(m => m.AddressLine1)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(m => m.AddressLine2)
                .HasMaxLength(50);
            builder
                .Property(m => m.AddressLine3)
                .HasMaxLength(50);

            builder
                .Property(m => m.PostCode)
                .HasMaxLength(10)
                .IsRequired();
            builder
                .Property(m => m.Town)
                .HasMaxLength(60)
                .IsRequired();
            builder
                .Property(m => m.County)
                .HasMaxLength(60);
            builder
               .Property(m => m.Country)
               .HasMaxLength(60)
               .IsRequired();
        }
    }
}
