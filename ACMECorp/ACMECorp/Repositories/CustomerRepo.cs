using ACMECorp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACMECorp.Repositories
{
    

    // CustomerRepository.cs
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> customers = new List<Customer>();
        private int nextId = 1;

        public IEnumerable<Customer> GetAll()
        {
            return customers;
        }

        public Customer GetById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Customer customer)
        {
            customer.Id = nextId++;
            customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            var existingCustomer = GetById(customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Contact = customer.Contact;
                existingCustomer.Orders = customer.Orders;
            }
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                customers.Remove(customer);
            }
        }
    }

}
