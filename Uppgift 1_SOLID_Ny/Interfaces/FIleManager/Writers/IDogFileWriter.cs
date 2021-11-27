using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;

namespace Uppgift_1_SOLID_Ny.Interfaces.FIleManager.Writers
{
    public interface IDogFileWriter
    {
        void WriteToAnimalFile(List<IDog> dogs);
    }
}
