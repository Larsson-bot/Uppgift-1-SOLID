using System;
using System.Linq;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Services;
using Uppgift_1_SOLID_Ny.Models.Animal;

namespace Uppgift_1_SOLID_Ny.Models.Services
{
    public class DogService : IDogService
    {
        private IDogManager DogManager;
        private Dogs Dogs;
        private IDog Dog;

        public DogService(IDogManager dogManager, Dogs dogs, IDog dog)
        {
            DogManager = dogManager;
            Dogs = dogs;
            Dog = dog;
        }

        public void CutClaws()
        {
            bool loop = true;
            var dogsInKennel = DogManager.GetAllAnimalsInKennel(); //Kollar av om det finns några incheckade djur.
            if (dogsInKennel.Count() != 0)
            {
                var dogs = Dogs.Items.Where(x => x.CheckedIn == true && x.Clawscut == false).ToList(); //Kollar om det finns incheckade djur som inte har fått sina klor klippta

                if (dogs.Count() != 0)
                {
                    DogManager.CreateCustomListUp(dogs);

                    Console.WriteLine("Type in the id of the animal you want to cut the claws on.");
                    while (loop)
                    {
                        try
                        {
                            var id = Convert.ToInt32(Console.ReadLine());

                            foreach (var item in dogs)
                            {
                                if (item.Id == id)
                                {
                                    Dog = item;
                                    loop = false;
                                }
                            }
                            if (loop == true)
                            {
                                Console.WriteLine("Dog with ID:" + id + " has not checked in.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("No strings allowed!");
                        }
                    }
                    Console.WriteLine("Cutting commencing!");
                    Console.WriteLine("Press any Key to return to the menu!");
                    Console.ReadKey();
                    Dog.Clawscut = true;
                    DogManager.UpdateAnimalStatus(Dog);
                }
                else
                {
                    Console.WriteLine("All checked in animals has had their claws cut.");
                    Console.WriteLine("Press any Key to return to the menu!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No dogs are checked in at the moment.");
                Console.WriteLine("Press any Key to return to the menu!");
                Console.ReadKey();
            }
        }

        public void WashAnimal()
        {
            bool loop = true;
            var dogsInKennel = DogManager.GetAllAnimalsInKennel();
            if (dogsInKennel.Count() != 0)
            {
                var dogs = Dogs.Items.Where(x => x.CheckedIn == true && x.Washed == false).ToList();

                if (dogs.Count() != 0)
                {
                    DogManager.CreateCustomListUp(dogs);

                    Console.WriteLine("Type in the id of the animal you want to wash.");
                    while (loop)
                    {
                        try
                        {
                            var id = Convert.ToInt32(Console.ReadLine());

                            foreach (var item in dogs)
                            {
                                if (item.Id == id)
                                {
                                    Dog = item;
                                    loop = false;
                                }
                            }
                            if (loop == true)
                            {
                                Console.WriteLine("Dog with ID:" + id + " has not checked in.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("No strings allowed!");
                        }
                    }
                    Console.WriteLine("Washing commencing!");
                    Console.WriteLine("Press any Key to return to the menu.");
                    Console.ReadKey();
                    Dog.Washed = true;
                    DogManager.UpdateAnimalStatus(Dog);
                }
                else
                {
                    Console.WriteLine("All checked in dogs has been washed.");
                    Console.WriteLine("Press any Key to return to the menu!");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("No dogs are checked in at the moment.");
                Console.WriteLine("Press any Key to return to the menu!");
                Console.ReadKey();
            }
        }
    }
}