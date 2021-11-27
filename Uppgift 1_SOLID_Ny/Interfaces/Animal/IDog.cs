using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_1_SOLID_Ny.Interfaces.Animal
{
    public interface IDog : IAnimal
    {
        bool Clawscut { get; set; }
        bool Washed { get; set; }
    }
}
