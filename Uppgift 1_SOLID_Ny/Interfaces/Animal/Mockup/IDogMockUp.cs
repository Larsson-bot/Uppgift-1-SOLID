using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_1_SOLID_Ny.Interfaces.Animal.Mockup
{
    public interface IDogMockUp
    {
        List<IDog> AddMockUpAnimals(List<IDog> dogs);
    }
}
