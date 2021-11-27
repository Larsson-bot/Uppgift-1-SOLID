using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;

namespace Uppgift_1_SOLID_Ny.Models.Animal
{
    public class DogManager : IDogManager
    {

        private IDog Dog;
        private Dog.Factory DogFactory;
        private Dogs Dogs;

        public DogManager(IDog dog, Dog.Factory dogFactory, Dogs dogs)
        {
            Dog = dog;
            DogFactory = dogFactory;
            Dogs = dogs;
        }

        public void AddEntity()
        {
            Console.WriteLine("Whats your dogs name?");
            Dog.Name = Console.ReadLine();
            var id = 1;
            Dog.Id = id + 1;
            Dog.CheckedIn = false;
            Dog.Clawscut = false;
            Dog.Washed = false;
            Dog.OwnerId = 1;
            AddAnimalToList(Dog);
            foreach (var item in Dogs.Items)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }

        public void AddAnimalToList(IDog dog)
        {
            Dogs.Items.Add(DogFactory(dog.Id, dog.Name, dog.CheckedIn, dog.Clawscut, dog.Washed, dog.OwnerId));
        }

  

        public List<IDog> GetAllAnimalsInKennel()
        {
            var dogs = Dogs.Items.Where(x => x.CheckedIn == true).ToList();
            return dogs;
        }

        public List<IDog> GetAnimals()
        {
            return Dogs.Items;
        }

        public IDog GetSpecficAnimal(int id)
        {
            throw new NotImplementedException();
        }

        public void ListUpAllRegisteredEntities()
        {
            var animals = Dogs.Items;

            if (animals.Count() == 0)
            {
                Console.WriteLine("No animals detected");
            }
            else
            {
                Console.WriteLine("Id\tName\t\t\tCheckedIn");
                foreach (var item in animals)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t\t\t" + item.CheckedIn);
                }
            }
     
            Console.WriteLine("\n\nPress any Key to return to the menu.");
            Console.ReadKey();
        }

        public bool ListUpAnimalsInKennel()
        {
            throw new NotImplementedException();
        }

        public bool ListUpAnimalsReadyToCheckIn()
        {
            throw new NotImplementedException();
        }

        public void PopulateList(List<IDog> dogs)
        {
            if (dogs.Count() == 0)
            {

                //    var item = new List<IAnimal>();
                //    item = Mockup.AddMockUpAnimals(item);
                //    foreach (var i in item)
                //    {
                //        AddAnimalToList(i);
                //    }
            }
            else
            {
                foreach (var item in dogs)
                {
                    AddAnimalToList(item);
                }
            }
        }

        public void UpdateAnimalStatus(IDog animal)
        {
            throw new NotImplementedException();
        }

 
    }
}
