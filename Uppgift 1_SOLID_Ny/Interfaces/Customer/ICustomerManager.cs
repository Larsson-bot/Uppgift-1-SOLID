using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Managers;

namespace Uppgift_1_SOLID_Ny.Interfaces.Customer
{
    public interface ICustomerManager : IEntityManager
    {
        void AddCustomerToList(ICustomer customer);
        void PopulateList(List<ICustomer> customers);
        List<ICustomer> GetCustomers();
    }
}
