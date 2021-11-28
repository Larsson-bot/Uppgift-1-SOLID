using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.ListHelper;
using Uppgift_1_SOLID_Ny.Models.Animal;
using Uppgift_1_SOLID_Ny.Models._Customer;

namespace Uppgift_1_SOLID_Ny.Models.ListHelper
{
    public class ListHelper : IListHelper
    {
        private Dogs Dogs;
        private Customers Customers;

        public ListHelper(Dogs dogs, Customers customers)
        {
            Dogs = dogs;
            Customers = customers;
        }


        //Hämtar ut sista Id.
        public int GetLastId(string typeOfList)
        {
            if (typeOfList == "Dogs")
            {
                return Dogs.Items.Count();
            }
            else
            {
                return Customers.ListOfCustomers.Count();
            }
        }
    }
}
