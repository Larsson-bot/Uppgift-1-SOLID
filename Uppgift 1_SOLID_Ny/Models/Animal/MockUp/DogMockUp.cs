using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Animal.Mockup;

namespace Uppgift_1_SOLID_Ny.Models.Animal.MockUp
{
    public class DogMockUp : IDogMockUp
    {
        public List<IDog> AddMockUpAnimals(List<IDog> dogs)
        {
            int length = 5;
            for (int i = 1; i < length; i++)
            {
                dogs.Add(new Dog() { Id = i, Name = Faker.Name.First(), CheckedIn = false, Clawscut = false, Washed = false, OwnerId = i });
            }
            return dogs;
        }  
    }
}
