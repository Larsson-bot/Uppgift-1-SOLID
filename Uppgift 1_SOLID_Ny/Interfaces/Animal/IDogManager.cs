using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.ListHelper;
using Uppgift_1_SOLID_Ny.Interfaces.Managers;

namespace Uppgift_1_SOLID_Ny.Interfaces.Animal
{
    public interface IDogManager : IEntityManager, IAnimalSpecficListUp
    {
        List<IDog> GetAnimals();
        List<IDog> GetAllAnimalsInKennel();

        void AddAnimalToList(IDog animal);
        void PopulateList(List<IDog> animals);

        void UpdateAnimalStatus(IDog animal);
        IDog GetSpecficAnimal(int id);
    }
}
