using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.IMenu;

namespace Uppgift_1_SOLID_Ny.Models.Menu
{
    public class MenuItem : IMenuItem
    {
        public char Selector { get; set ; }
        public string Title { get ; set ; }
        public Action RunFunction { get; set; }
    }
}
