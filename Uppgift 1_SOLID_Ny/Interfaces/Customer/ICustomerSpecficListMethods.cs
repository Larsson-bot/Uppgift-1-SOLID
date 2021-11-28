using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_1_SOLID_Ny.Interfaces.Customer
{
    public interface ICustomerSpecficListMethods
    {
        void AddCustomerToList(ICustomer customer);
        void PopulateList(List<ICustomer> customers);
        void CreateCustomList(List<ICustomer> customers);
    }
}
