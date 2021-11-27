using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;

namespace Uppgift_1_SOLID_Ny.Models._Customer
{
    public class Customers
    {
        private List<ICustomer> customers = new List<ICustomer>();
        public List<ICustomer> ListOfCustomers
        {
            get { return customers; }

        }
    }
}
