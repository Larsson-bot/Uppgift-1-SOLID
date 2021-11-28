using System;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.ConsoleHelpers;
using Uppgift_1_SOLID_Ny.Interfaces.Services.ReceiptServices;

namespace Uppgift_1_SOLID_Ny.Models.Services
{
    public class ReceiptService : IReceiptService
    {
        private IDog Dog;
        private IConsoleHelper ConsoleHelper;

        public ReceiptService(IDog dog, IConsoleHelper consoleHelper)
        {
            Dog = dog;
            ConsoleHelper = consoleHelper;
        }

        public void CalculateReceipt(IDog dog)
        {
            bool loop = true;
            int payment = 1;
            int receipt = 100;
            Console.Clear();
            ConsoleHelper.WriteToConsole("Receipt!");
            ConsoleHelper.WriteToConsole("Standard Fee\t" + 100);
            if (dog.Washed == true)
            {
                receipt = receipt + 25;
                ConsoleHelper.WriteToConsole("Washing\t\t" + 25);
            }
            if (dog.Clawscut == true)
            {
                receipt = receipt + 40;
                ConsoleHelper.WriteToConsole("Claws cut\t" + 40);
            }
            ConsoleHelper.WriteToConsole("Total:\t\t" + receipt + "\n\n");
            ConsoleHelper.WriteToConsole("How would you like to pay?");
            ConsoleHelper.WriteToConsole("1. By Card");
            ConsoleHelper.WriteToConsole("2. By Cash");
            ConsoleHelper.WriteToConsole("3. NOT AT ALL. THIS IS TOO EXPENSIVE");
            while (loop)
            {
                try
                {
                    payment = Convert.ToInt32(Console.ReadLine());
                    loop = false;
                }
                catch
                {
                    ConsoleHelper.WriteToConsole("Only numbers please.");
                }
                
            }

            switch (payment)
            {
                case 1:
                    ConsoleHelper.WriteToConsole("Card Swiped!");
                    ConsoleHelper.WriteToConsole("Have a great day!");
                    ConsoleHelper.ReturnToMenuMessage();
                    break;
                case 2:
                    ConsoleHelper.WriteToConsole("Cash received!");
                    ConsoleHelper.WriteToConsole("Have a great day!");
                    ConsoleHelper.ReturnToMenuMessage();

                    break;
                case 3:
                    ConsoleHelper.WriteToConsole("I´m calling the police.");
                    ConsoleHelper.ReturnToMenuMessage();
                    break;
                default:
                    ConsoleHelper.WriteToConsole("Card Swiped!");
                    ConsoleHelper.WriteToConsole("Have a great day!");
                    ConsoleHelper.ReturnToMenuMessage();
                    break;
            }
        }
    }
}
