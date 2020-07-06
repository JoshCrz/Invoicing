using EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ModelConfiguration
{

    /// <summary>
    /// Customer entity model configuration
    /// </summary>
    public class CustomerEntityModelConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {

            // properties configuration
            builder
                .HasKey(m => m.CustomerID);
            builder
                .Property(m => m.CompanyName)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(m => m.NatureOfBusiness)
                .HasMaxLength(250);
            builder
                .Property(m => m.WebsiteUrl)
                .HasMaxLength(50);
            builder
               .Property(m => m.RegistrationNumber)
               .HasMaxLength(10);
            builder
               .Property(m => m.VatNumber)
               .HasMaxLength(20);

            // relation betweens entities / tables ## possible to be moved to a separate class for relations
            builder
                .HasMany(m => m.Contacts)
                .WithOne(m => m.Customer); // relation between contacts and customer 
                                           // (e.g. one customer can have many contacts, but a contact can only be linked to one customer)
            builder
                .HasMany(m => m.Invoices)
                .WithOne(m => m.Customer); // relation between invocies and customer (as above)

            builder
                .HasOne(m => m.CustomerStatus)
                .WithMany(m => m.Customers);

            builder
                .HasOne(m => m.CustomerType)
                .WithMany(m => m.Customers);

        }
    }

    /// <summary>
    /// many-to-many entity model configuration for customer and address bridge table.
    /// </summary>
    public class CustomerAddressEntityModelConfiguration : IEntityTypeConfiguration<CustomersAddresses>
    {
        public void Configure(EntityTypeBuilder<CustomersAddresses> builder)
        {
            // set 2 primary keys for many-to-many
            builder
                .HasKey(m => new { m.CustomerID, m.AddressID });

            // relation between customer and customeraddress bridge table
            builder
                .HasOne(m => m.Customer)
                .WithMany(m => m.CustomersAddresses)
                .HasForeignKey(m => m.CustomerID);

        }
    }
}



