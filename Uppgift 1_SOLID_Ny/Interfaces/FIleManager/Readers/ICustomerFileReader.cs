using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;

namespace Uppgift_1_SOLID_Ny.Interfaces.FIleManager.Readers
{
    public interface ICustomerFileReader
    {
        List<ICustomer> ReadCustomerFile();
    }
}
