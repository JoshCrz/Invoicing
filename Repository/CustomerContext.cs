using EntityModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Repository
{
    public class CustomerContext : DbContext
    {

        public DbSet<Customers> Customers { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .HasKey(m=> m.CustomerID);
            modelBuilder.Entity<Contacts>()
                .HasKey(m => m.CustomerID);
            modelBuilder.Entity<Invoices>()
                .HasKey(m => m.CustomerID);

            modelBuilder.Entity<Customers>()
                .HasMany(m => m.Contacts)
                .WithOne(m => m.Customer);

            modelBuilder.Entity<Customers>()
                .HasMany(m => m.Invoices)
                .WithOne(m => m.Customer);

        }


    }
}
