using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Application;
using Uppgift_1_SOLID_Ny.Interfaces.Menu;

namespace Uppgift_1_SOLID_Ny.Models.Menu
{
    public class MainMenu : IMainMenu
    {
        private IMenuManager MenuManager;
        private IDogManager DogManager;


        public MainMenu(IMenuManager menuManager, IDogManager dogManager)
        {
            MenuManager = menuManager;
            DogManager = dogManager;
     
        }

        public IMenu Init()
        {
            MenuManager.CreateMenu("Welcome to the kennelApplication!");
            MenuManager.CreateMenuItem('1', "Add a animal", DogManager.AddEntity);
            MenuManager.CreateMenuItem('4', "List up all registered animals", DogManager.ListUpAllRegisteredEntities);
            MenuManager.CreateMenuItem('x', "Exit Application", MenuManager.EndApplication);
            MenuManager.DisplayMenu();
            return MenuManager.GetMenu();
        }
    }
}
