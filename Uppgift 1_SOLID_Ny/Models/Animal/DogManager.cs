using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Animal.Mockup;
using Uppgift_1_SOLID_Ny.Interfaces.ListHelper;

namespace Uppgift_1_SOLID_Ny.Models.Animal
{
    public class DogManager : IDogManager
    {

        private IDog Dog;
        private Dog.Factory DogFactory;
        private Dogs Dogs;
        private IListHelper ListHelper;
        private IDogMockUp MockUp;

        public DogManager(IDog dog, Dog.Factory dogFactory, Dogs dogs, IListHelper listHelper, IDogMockUp mockUp)
        {
            Dog = dog;
            DogFactory = dogFactory;
            Dogs = dogs;
            ListHelper = listHelper;
            MockUp = mockUp;
        }

        public void AddEntity()
        {
            Console.WriteLine("Whats your dogs name?");
            Dog.Name = Console.ReadLine();
            var id = ListHelper.GetLastId("Dogs");
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
            var _animal = Dogs.Items.FirstOrDefault(x => x.Id == id);
            return _animal;
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
            var dogs = Dogs.Items;
            if (dogs.Count() == 0)
            {
                Console.WriteLine("No dogs detected");
                return false;
            }
            else
            {
                Console.WriteLine("Id\tName\t\t\tCheckedIn");
                foreach (var item in dogs)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t\t\t" + item.CheckedIn);
                }
                Console.WriteLine("\n\n");
                return true;
            }
        }

        public void  ListUpAnimalsReadyToCheckIn()
        {
            var dogs = Dogs.Items.Where(x => x.CheckedIn == false);

            if (dogs.Count() == 0)
            {
                Console.WriteLine("No dogs to be found.");
                Console.WriteLine("\n\nPress any Key to return to the menu.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Id\tName\t\t\tCheckedin");
                foreach (var item in dogs)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t\t\t" + item.CheckedIn);
                }
            }

            Console.WriteLine("\n\n");
        }

        public void PopulateList(List<IDog> dogs)
        {
            if (dogs.Count() == 0)
            {

                var item = new List<IDog>();
                item = MockUp.AddMockUpAnimals(item);
                foreach (var i in item)
                {
                    AddAnimalToList(i);
                }
            }
            else
            {
                foreach (var item in dogs)
                {
                    AddAnimalToList(item);
                }
            }
        }

        public void UpdateAnimalStatus(IDog dog)
        {
            var _dog = Dogs.Items.FirstOrDefault(x => x.Id == dog.Id);
            var index = Dogs.Items.FindIndex(x => x.Name == dog.Name);
            _dog = dog;
            Dogs.Items.RemoveAt(index);
            Dogs.Items.Insert(index, _dog);
        }

 
    }
}
