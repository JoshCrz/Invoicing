using System;
using System.Collections.Generic;
using System.Linq;
using EntityModels;
using Repository;
using MediatR;
using Service.Queries;
using Service.ViewModels;
using Service.Commands;

namespace Service
{
    public class CustomersService // add generic crud interface ? 
    {

        InvoicingContext db;
        IMediator _mediator;

        public CustomersService(InvoicingContext context, IMediator mediator)
        {
            db = context;
            _mediator = mediator;
        }

        public ServiceResponse<List<CustomerListDTO>> GetAll()
        {
            return _mediator
                    .Send(new GetCustomerListQuery()).Result;
        }

        public ServiceResponse<CustomerDetailsDTO> GetSingle(int customerID)
        {
            return _mediator
                    .Send(new GetCustomerDetailsQuery() { CustomerID = customerID }).Result;
        }


        public ServiceResponse<CustomerDetailsDTO> Add(CreateCustomerCommand command)
        {
            return _mediator
                    .Send(command).Result;
        }

        public ServiceResponse<CustomerDetailsDTO> Update(int customerID, UpdateCustomerCommand command)
        {
            if(customerID != command.CustomerID) {
                throw new Exception("IDs dont match");
            }
            return _mediator
                    .Send(command).Result;
        }

        public ServiceResponse<CustomerDetailsDTO> Delete(int customerID)
        {
            return _mediator
                    .Send(new DeleteCustomerCommand() { CustomerID = customerID }).Result;

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
