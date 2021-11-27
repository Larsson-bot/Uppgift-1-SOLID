using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Menu;

namespace Uppgift_1_SOLID_Ny.Models.Menu
{
    public class MenuItem : IMenuItem
    {
        public MenuItem(char selector, string title, Action runFunction)
        {
            Selector = selector;
            Title = title;
            RunFunction = runFunction;
        }

        public char Selector { get; set ; }
        public string Title { get ; set ; }
        public Action RunFunction { get; set; }
    }
}
