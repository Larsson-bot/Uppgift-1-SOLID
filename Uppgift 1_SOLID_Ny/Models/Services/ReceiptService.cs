using System;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Services.ReceiptServices;

namespace Uppgift_1_SOLID_Ny.Models.Services
{
    public class ReceiptService : IReceiptService
    {
        private IDog Dog;

        public ReceiptService(IDog dog)
        {
            Dog = dog;
        }

        public void CalculateReceipt(IDog dog)
        {
            bool loop = true;
            int payment = 1;
            int receipt = 100;
            Console.Clear();
            Console.WriteLine("Receipt!");
            Console.WriteLine("Standard Fee\t" + 100);
            if (dog.Washed == true)
            {
                receipt = receipt + 25;
                Console.WriteLine("Washing\t\t" + 25);
            }
            if (dog.Clawscut == true)
            {
                receipt = receipt + 40;
                Console.WriteLine("Claws cut\t" + 40);
            }
            Console.WriteLine("Total:\t\t" + receipt);
            Console.WriteLine("How would you like to pay?");
            Console.WriteLine("1. By Card");
            Console.WriteLine("2. By Cash");
            Console.WriteLine("3. NOT AT ALL. THIS IS TOO EXPENSIVE");
            while (loop)
            {
                try
                {
                    payment = Convert.ToInt32(Console.ReadLine());
                    loop = false;
                }
                catch
                {
                    Console.WriteLine("Only numbers please.");
                }
                
            }

            switch (payment)
            {
                case 1:
                    Console.WriteLine("Card Swiped!");
                    Console.WriteLine("Have a great day!");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Cash received!");
                    Console.WriteLine("Have a great day!");
                    Console.ReadKey();

                    break;
                case 3:
                    Console.WriteLine("I´m calling the police.");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Card Swiped!");
                    Console.WriteLine("Have a great day!");
                    break;
            }
        }
    }
}
