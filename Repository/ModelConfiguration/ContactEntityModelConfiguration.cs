using EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.ModelConfiguration
{
    public class ContactEntityModelConfiguration : IEntityTypeConfiguration<Contacts>
    {
        public void Configure(EntityTypeBuilder<Contacts> builder)
        {
            builder
                .HasKey(m => m.ContactID); // set primary key
        }
    }

    public class ContactAddressEntityModelConfiguration : IEntityTypeConfiguration<ContactsAddresses>
    {
        public void Configure(EntityTypeBuilder<ContactsAddresses> builder)
        {
            builder
                .HasKey(m => new { m.AddressID, m.ContactID });

            builder
                .HasOne(m => m.Contact)
                .WithMany(m => m.ContactsAddresses);

        }
    }
}
