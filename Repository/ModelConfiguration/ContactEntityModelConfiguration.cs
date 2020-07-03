using EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ModelConfiguration
{

    /// <summary>
    /// Contact entity model configuration
    /// </summary>
    public class ContactEntityModelConfiguration : IEntityTypeConfiguration<Contacts>
    {
        public void Configure(EntityTypeBuilder<Contacts> builder)
        {

            // properties configuration
            builder
                .HasKey(m => m.ContactID);
            builder
                .Property(m => m.FirstName)
                .HasMaxLength(20)
                .IsRequired();
            builder
                .Property(m => m.LastName)
                .HasMaxLength(20)
                .IsRequired();
            builder
                .Property(m => m.Tel)
                .HasMaxLength(20)
                .IsRequired();
            builder
                .Property(m => m.Mobile)
                .HasMaxLength(20)
                .IsRequired();
            builder
                .Property(m => m.Email)
                .HasMaxLength(200)
                .IsRequired();
        }
    }

    /// <summary>
    /// many-to-many entity model configuration for contact and address bridge table.
    /// </summary>
    public class ContactAddressEntityModelConfiguration : IEntityTypeConfiguration<ContactsAddresses>
    {
        public void Configure(EntityTypeBuilder<ContactsAddresses> builder)
        {
            // set 2 primary keys
            builder
                .HasKey(m => new { m.ContactID, m.AddressID });

            // relation between contact and contactaddress bridge table
            builder
                .HasOne(m => m.Contact)
                .WithMany(m => m.ContactsAddresses)
                .HasForeignKey(m => m.ContactID);

        }
    }
}
