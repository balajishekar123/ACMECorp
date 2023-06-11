using System.Collections.Generic;

namespace ACMECorp.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; }
        public List<Order> Orders { get; set; }
    }

    // Contact.cs
    public class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    // Order.cs
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
    }
}



