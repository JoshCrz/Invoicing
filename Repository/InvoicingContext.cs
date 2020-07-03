using EntityModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repository
{
    public class InvoicingContext : DbContext
    {

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Addresses> Addresses { get; set; }
        public DbSet<CustomersAddresses> CustomerAddresses { get; set; }

        
        public InvoicingContext(DbContextOptions<InvoicingContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // apply fluent api config.
            modelBuilder.ApplyConfiguration(new ModelConfiguration.CustomerEntityModelConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration.ContactEntityModelConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration.InvoiceEntityModelConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration.AddressEntityModelConfiguration());

            // many to many config
            modelBuilder.ApplyConfiguration(new ModelConfiguration.CustomerAddressEntityModelConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration.ContactAddressEntityModelConfiguration());


        }


    }
}
