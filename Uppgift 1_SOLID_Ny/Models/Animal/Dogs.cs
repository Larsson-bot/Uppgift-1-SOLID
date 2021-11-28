using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;

namespace Uppgift_1_SOLID_Ny.Models.Animal
{
    public class Dogs
    {
        private List<IDog> items = new List<IDog>(); //Instansierar en ny lista när projeketet skapas. 
        public List<IDog> Items
        {
            get { return items; }
        }
       
    }
}
