

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
        public virtual int CustomerID { get; set; }
    }
}
