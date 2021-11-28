using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.ConsoleHelpers;

namespace Uppgift_1_SOLID_Ny.Models.ConsoleHelpers
{
    public class ConsoleHelper : IConsoleHelper
    {
        public void ReturnToMenuMessage()
        {
            Console.WriteLine($"\n\nPress any Key to return to the menu.");
            Console.ReadKey();
        }

        public void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
