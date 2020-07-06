using System;
using System.Collections.Generic;
using System.Linq;
using EntityModels;
using Repository;

namespace Service
{
    public class CustomerService
    {

        InvoicingContext db;

        public CustomerService(InvoicingContext context)
        {
            db = context;
        }

        public List<Customers> GetAll()
        {
            return db.Customers.ToList();
        }

        public Customers GetSingle(int customerID)
        {
            return db.Customers.FirstOrDefault(x => x.CustomerID == customerID);
        }


        public Customers Add(Customers model)
        {
            db.Customers.Add(model);
            db.SaveChanges();

            return model;
        }

        public Customers Update(int customerID, Customers model)
        {
            db.Customers.Update(model);
            db.SaveChanges();

            return model;
        }

        public Customers Delete(int customerID)
        {
            var model = db.Customers.FirstOrDefault(x => x.CustomerID == customerID);
            db.Customers.Remove(model);

            return model;
        }

        public void DeleteAndCreateDatabase()
        {

            // delete db
            var res = db.Database.EnsureDeleted();

            // create db
            var res2 = db.Database.EnsureCreated();


        }

        public void SeedTestData()
        {

            db.Addresses.AddRange(
                new Addresses()
                {
                    AddressLine1 = "Barley Bank Meadow",
                    AddressLine2 = "Leegomery",
                    AddressLine3 = "",
                    Town = "Telford",
                    PostCode = "TF11FT",
                    Country = "UK"
                },
                new Addresses()
                {
                    AddressLine1 = " 4 Century Road",
                    AddressLine2 = "High Carr Business Park",
                    AddressLine3 = "",
                    Town = "Newcastle-under-Lyme",
                    PostCode = "ST5 7UG",
                    County = "Staffordshire",
                    Country = "UK"
                },
                new Addresses()
                {
                    AddressLine1 = "23a High Street",
                    AddressLine2 = "",
                    AddressLine3 = "",
                    Town = "Newport",
                    PostCode = "TF10 7AT",
                    County = "Shropshire",
                    Country = "UK"
                }
            );
            db.SaveChanges();

            db.Contacts.AddRange(
                new Contacts()
                {
                    FirstName = "Tom",
                    LastName = "Mot",
                    Tel = "01743665599",
                    Mobile = "07907995566",
                    Email = "tom@gmail.com"
                },
                new Contacts()
                {
                    FirstName = "Teresa",
                    LastName = "Mother",
                    Tel = "01743666666",
                    Mobile = "07907666666",
                    Email = "motherT@yahoo.com"
                },
                new Contacts()
                {
                    FirstName = "Vincent",
                    LastName = "Vangoth",
                    Tel = "01743321123",
                    Mobile = "07907987890",
                    Email = "ear@yahoo.com"
                }
            );
            db.SaveChanges();

            db.Customers.AddRange(
                new Customers()
                {
                    CompanyName = "Eagle Freelnace",
                    NatureOfBusiness = "Freelance Website Design and Development",
                    WebsiteUrl = "http://www.eaglefreelance.co.uk",
                    VatNumber = "",
                    RegistrationNumber = ""
                },
                new Customers()
                {
                    CompanyName = "UK Test Instruments",
                    NatureOfBusiness = "Electrical instruments calibration and sale",
                    WebsiteUrl = "https://www.acutest.net",
                    VatNumber = "GB 927 2027 36",
                    RegistrationNumber = "2529960"
                },
                new Customers()
                {
                    CompanyName = "Elf Software",
                    NatureOfBusiness = "Software applications",
                    WebsiteUrl = "http://www.elfsoftware.co.uk/",
                    VatNumber = "GB 834 0489 27",
                    RegistrationNumber = "05020121"
                }
            );
            db.SaveChanges();

            db.CustomerAddresses.AddRange(
                new CustomersAddresses()
                {
                    Customer = db.Customers.FirstOrDefault(x => x.CustomerID == 1),
                    Address = db.Addresses.FirstOrDefault(x => x.AddressID == 1)
                },
                new CustomersAddresses()
                {
                    Customer = db.Customers.FirstOrDefault(x => x.CustomerID == 1),
                    Address = db.Addresses.FirstOrDefault(x => x.AddressID == 2)
                },
                new CustomersAddresses()
                {
                    Customer = db.Customers.FirstOrDefault(x => x.CustomerID == 2),
                    Address = db.Addresses.FirstOrDefault(x => x.AddressID == 2)
                },
                new CustomersAddresses()
                {
                    Customer = db.Customers.FirstOrDefault(x => x.CustomerID == 3),
                    Address = db.Addresses.FirstOrDefault(x => x.AddressID == 3)
                }
            );
            db.SaveChanges();

            db.CustomerStatuses.AddRange(
                new CustomerStatuses() { CustomerStatus = "Active" },
                new CustomerStatuses() { CustomerStatus = "InActive" },
                new CustomerStatuses() { CustomerStatus = "Susspended" }
            );
            db.CustomerTypes.AddRange(
                new CustomerTypes() { CustomerType = "Business" },
                new CustomerTypes() { CustomerType = "Contractor" },
                new CustomerTypes() { CustomerType = "Freelancer" }
            );
            db.SaveChanges();

            db.Customers.FirstOrDefault(x => x.CustomerID == 1).Contacts.Add(db.Contacts.FirstOrDefault(x => x.ContactID == 1));
            db.Customers.FirstOrDefault(x => x.CustomerID == 2).Contacts.Add(db.Contacts.FirstOrDefault(x => x.ContactID == 2));
            db.Customers.FirstOrDefault(x => x.CustomerID == 3).Contacts.Add(db.Contacts.FirstOrDefault(x => x.ContactID == 3));

            db.Customers.FirstOrDefault(x => x.CustomerID == 1).CustomerStatusID = 1;
            db.Customers.FirstOrDefault(x => x.CustomerID == 1).CustomerTypeID = 1;
            db.Customers.FirstOrDefault(x => x.CustomerID == 2).CustomerStatusID = 2;
            db.Customers.FirstOrDefault(x => x.CustomerID == 2).CustomerTypeID = 2;
            db.Customers.FirstOrDefault(x => x.CustomerID == 3).CustomerStatusID = 3;
            db.Customers.FirstOrDefault(x => x.CustomerID == 3).CustomerTypeID = 3;
            db.SaveChanges();
        }

    }
}
