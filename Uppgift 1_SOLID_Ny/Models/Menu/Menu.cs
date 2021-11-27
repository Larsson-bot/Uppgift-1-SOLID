using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces;
using Uppgift_1_SOLID_Ny.Interfaces.Menu;

namespace Uppgift_1_SOLID_Ny.Models.Menu
{
    public class Menu : IMenu
    {
        public string Title { get; set; }
        public List<IMenuItem> MenuItems { get; set; }
    }
}
