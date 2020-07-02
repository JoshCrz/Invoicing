using EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ModelConfiguration
{
    public class CustomerEntityModelConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            // database structure
            builder
                .HasKey(m => m.CustomerID); // set primary key

            builder
                .Property(m => m.CompanyName)
                .HasMaxLength(50);

            // relation betweens entities / tables
            builder
                .HasMany(m => m.Contacts)
                .WithOne(m => m.Customer); // relation between contacts and customer 
                                           // (e.g. one customer can have many contacts, but a contact can only be linked to one customer)
            builder
                .HasMany(m => m.Invoices)
                .WithOne(m => m.Customer); // relation between invocies and customer (as above)
            
          
        }
    }

    public class CustomerAddressEntityModelConfiguration : IEntityTypeConfiguration<CustomersAddresses>
    {
        public void Configure(EntityTypeBuilder<CustomersAddresses> builder)
        {
            builder
                .HasKey(m => new { m.AddressID, m.CustomerID });

            builder
                .HasOne(m => m.Customer)
                .WithMany(m => m.CustomersAddresses);

        }
    }
}



