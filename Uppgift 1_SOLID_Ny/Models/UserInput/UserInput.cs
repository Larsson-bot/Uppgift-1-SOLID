using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Menu;
using Uppgift_1_SOLID_Ny.Interfaces.UserInput;

namespace Uppgift_1_SOLID_Ny.Models.UserInput
{
    public class UserInput : IUserInput
    {
        public void GetUserInput(IMenu menu)
        {
            var userInput = Console.ReadKey();
            foreach (var item in menu.MenuItems)
            {
                if (item.Selector == userInput.KeyChar)
                {
                    Console.Clear();
                    item.RunFunction();
                }
            }
            Console.Clear();
        }
    }
}
