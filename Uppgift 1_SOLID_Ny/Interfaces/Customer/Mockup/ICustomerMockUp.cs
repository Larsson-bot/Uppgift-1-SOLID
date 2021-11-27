using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_1_SOLID_Ny.Interfaces.Customer.Mockup
{
    public interface ICustomerMockUp
    {
        List<ICustomer> AddMockUpCustomers(List<ICustomer> customers);
    }
}
