using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;
using Uppgift_1_SOLID_Ny.Interfaces.Customer.Mockup;

namespace Uppgift_1_SOLID_Ny.Models._Customer.Mockup
{
    public class CustomerMockUp : ICustomerMockUp
    {
        public List<ICustomer> AddMockUpCustomers(List<ICustomer> customers)
        {
                int length = 5;
                for (int i = 1; i < length; i++)
                {
                    customers.Add(new Customer() { Id = i, Name = Faker.Name.First(), Email = Faker.Internet.Email()});
                }
                return customers; 
        }
    }
}
