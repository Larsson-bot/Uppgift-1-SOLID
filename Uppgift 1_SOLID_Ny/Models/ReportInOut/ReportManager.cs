using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.ReportInOut;
using Uppgift_1_SOLID_Ny.Interfaces.Services.ReceiptServices;

namespace Uppgift_1_SOLID_Ny.Models.ReportInOut
{
    public class ReportManager : IReportManager
    {
        private IDog Dog;
        private IReceiptService ReceiptService;
        private IDogManager DogManager;

        public ReportManager(IDog dog, IReceiptService receiptService, IDogManager dogManager)
        {
            Dog = dog;
            ReceiptService = receiptService;
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
                var loop = true;
                DogManager.ListUpAnimalsReadyToCheckIn();
       
           
                Console.WriteLine("Please type in your animals Id that you want to report in.");
                Console.WriteLine("Type 0 if you want to return to the menu.");
                while (loop)
                {
                  
                    try
                    {
               
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
                                    Console.WriteLine("Dog is already checked in.");
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
                var loop = true;
                DogManager.CreateCustomListUp(dogs);
     
                //Console.WriteLine("\n\n");

                Console.WriteLine("Please type in your animals Id that you want to report out.");
                Console.WriteLine("Type 0 if you want to return to the menu.");
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

                                    ReceiptService.CalculateReceipt(Dog);
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
            }
        }
    }
}