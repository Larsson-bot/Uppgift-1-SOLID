using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;

namespace Uppgift_1_SOLID_Ny.Models._Customer
{
    public class Customer : ICustomer
    {
        public delegate Customer Factory(int id, string name,string email);

        public Customer()
        {

        }

        public Customer(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
