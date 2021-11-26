using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_1_SOLID_Ny.Interfaces
{
    public interface IAnimal
    {
        int Id { get; set; }
        string Name { get; set; }
        bool IsAnimalHere { get; set; }
    }
}
