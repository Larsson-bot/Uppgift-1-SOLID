using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_1_SOLID_Ny.Interfaces.Customer
{
    public interface ICustomer
    {
        int Id { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
        int AnimalId { get; set; }
    }
}
