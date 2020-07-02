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

            //if(db.Customers.Count() < 1)
            //{
            //    db.Customers.Add(new Customers()
            //    {
            //        CompanyName = "Eagle Freelance",
            //        Address = "Blank address",
            //        Town = "Telford",
            //        PostCode = "TF3 3TF"
            //    });

            //    db.Customers.Add(new Customers()
            //    {
            //        CompanyName = "Panda Design",
            //        Address = "Blank address",
            //        Town = "Fkknows",
            //        PostCode = "FK3 3NS"
            //    });

            //    db.Customers.Add(new Customers()
            //    {
            //        CompanyName = "JC & PS",
            //        Address = "The internet",
            //        Town = "Virtual",
            //        PostCode = "IP1 3PI"
            //    });


            //}
            //db.SaveChanges();
        }

    }
}
