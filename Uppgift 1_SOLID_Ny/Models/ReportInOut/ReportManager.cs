using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.ReportInOut;

namespace Uppgift_1_SOLID_Ny.Models.ReportInOut
{
    public class ReportManager : IReportManager
    {
        private IDog Dog;

        private IDogManager DogManager;

        public ReportManager(IDog dog, IDogManager dogManager)
        {
            Dog = dog;
            DogManager = dogManager;
        }



        //private IReceiptService ReceiptService;


        public void ReportIn()
        {
            var dogs = DogManager.GetAnimals();
            var _dogs = dogs.Where(x => x.CheckedIn == false);
            if (_dogs.Count() == 0)
            {
                if(dogs.Count() == 0)
                {
                    Console.WriteLine("There are no animals registered!");
                    Console.WriteLine("Press any Key to return to the menu");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("All registered animals are checked in already!");
                    Console.WriteLine("Press any Key to return to the menu");
                    Console.ReadKey();
                }
            
            }
            else
            {
              DogManager.ListUpAnimalsReadyToCheckIn();
                var loop = true;

                while (loop)
                {

                    try
                    {
                        Console.WriteLine("Please type in your animals Id.");
                        Console.WriteLine("Press 0 if you want to return to the menu.");
                        var id = Console.ReadLine();
                        if(Convert.ToInt32(id) != 0)
                        {
                            Dog = DogManager.GetSpecficAnimal(Convert.ToInt32(id));
                            if (Dog == null)
                            {
                                Console.WriteLine("Invaild Id. Please write another one.");
                            }
                            else
                            {
                                if (Dog.CheckedIn == true)
                                {
                                    Console.WriteLine("Animal is already checked in.");
                                }
                                else
                                {
                                    Dog.CheckedIn = true;
                                    DogManager.UpdateAnimalStatus(Dog);
                                    loop = false;
                                }

                            }
                        }
                        else
                        {
                            loop = false;
                        }
                       

                    }
                    catch
                    {
                        Console.WriteLine("Error! Only numbers please!");
                    }

                }



            }


            //AnimalManager.ListUpAllAnimals();

            //Console.WriteLine("Please type in your animals Id.");
            //var id = Console.ReadLine();
            //var animal = AnimalManager.GetSpecficAnimal(Convert.ToInt32(id));
            //animal.IsAnimalHere = true;
            //AnimalManager.UpdateAnimalStatus(animal);
        }

        public void ReportOut()
        {

            var dogs = DogManager.GetAllAnimalsInKennel();
            if (dogs.Count() == 0)
            {
                Console.WriteLine("There are no animals reported in!");
                Console.WriteLine("Press any Key to return to the menu");
                Console.ReadKey();

            }
            else
            {

                DogManager.ListUpAnimalsInKennel();
                var loop = true;
                Console.WriteLine("Please type in your animals Id.");
                Console.WriteLine("Press 0 if you want to return to the menu.");
                while (loop)
                {

                    try
                    {
                        var id = Convert.ToInt32(Console.ReadLine());
                        if(id != 0)
                        {
                            Dog = DogManager.GetSpecficAnimal(id);
                            if (Dog == null)
                            {
                                Console.WriteLine("Invaild Id. Please write another one.");
                            }
                            else
                            {
                                if (Dog.CheckedIn == true)
                                {
                                    loop = false;
                                    Dog.CheckedIn = false;
                                    Dog.Clawscut = false;
                                    Dog.Washed = false;
                                    DogManager.UpdateAnimalStatus(Dog);
                                }
                                else
                                {
                                    Console.WriteLine("This dog has not checked in.");
                                }
                            }
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Try Again");
                    }


                }

                //ReceiptService.CalculateReceipt(Animal);


            }
        }
    }
}