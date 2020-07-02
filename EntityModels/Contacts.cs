

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityModels
{
    public class Contacts
    {
        public Contacts()
        {
           
        }

        public int ContactID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }

        public string Email { get; set; }

        // many to one relation between contacts and customer
        public virtual Customers Customer { get; set; }

        // many to many relation between contacts and addresses
        public virtual ICollection<ContactsAddresses> ContactsAddresses { get; set; }
    }

    public class ContactsAddresses
    {
        public int ContactID { get; set; }
        public int AddressID { get; set; }
        public Contacts Contact { get; set; }
        public Addresses Address { get; set; }
    }
}
