using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_1_SOLID_Ny.Interfaces.Menu
{
    public interface IMenuManager
    {
        void CreateMenu(string title);
        void CreateMenuItem(char selector, string title, Action runFunction);
        void DisplayMenu();
        IMenu GetMenu();
        void EndApplication();
    }
}
