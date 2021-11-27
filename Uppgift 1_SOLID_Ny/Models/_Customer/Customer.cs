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
        public delegate Customer Factory(int id, string name, string phoneNumber, int animalId);

        public Customer()
        {

        }

        public Customer(int id, string name, string phoneNumber, int animalId)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            AnimalId = animalId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int AnimalId { get; set; }
    }
}
