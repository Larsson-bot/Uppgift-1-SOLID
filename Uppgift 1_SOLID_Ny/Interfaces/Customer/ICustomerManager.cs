using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Managers;

namespace Uppgift_1_SOLID_Ny.Interfaces.Customer
{
    public interface ICustomerManager : IEntityManager, ICustomerSpecficListMethods
    {
        void RegisterCustomerFromOtherClass();
        List<ICustomer> GetCustomers();
  
        ICustomer GetSpecficCustomer(int id);

    }
}
