using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;
using Uppgift_1_SOLID_Ny.Interfaces.FIleManager;
using Uppgift_1_SOLID_Ny.Interfaces.Menu;

namespace Uppgift_1_SOLID_Ny.Models.Menu
{
    public class MenuManager : IMenuManager
    {

        private IMenu Menu;
        private Func<char, string, Action, IMenuItem> MenuItemFactory;
        private IFileManager FileManager;
        private IDogManager DogManager;
        private ICustomerManager CustomerManager;

        public MenuManager(IMenu menu, Func<char, string, Action, IMenuItem> menuItemFactory, IFileManager fileManager, IDogManager dogManager, ICustomerManager customerManager)
        {
            Menu = menu;
            MenuItemFactory = menuItemFactory;
            FileManager = fileManager;
            DogManager = dogManager;
            CustomerManager = customerManager;
        }

        public void CreateMenu(string title)
        {
            Menu.Title = title;
            Menu.MenuItems = new List<IMenuItem>();
        }

        public void CreateMenuItem(char selector, string title, Action runFunction)
        {
            Menu.MenuItems.Add(MenuItemFactory(selector, title, runFunction));
        }

        public void DisplayMenu()
        {
            Console.WriteLine(Menu.Title);
            foreach (var menuItem in Menu.MenuItems)
            {
                Console.WriteLine(menuItem.Selector + ": " + menuItem.Title);
            }
        }

        public IMenu GetMenu()
        {
            return Menu;
        }

        public void EndApplication()
        {
            //Skriver listorna till filer när applikationen avslutas.
            Console.WriteLine("Application is closing...");
            var dogs = DogManager.GetAnimals();
            FileManager.WriteToAnimalFile(DogManager.GetAnimals());
            FileManager.WriteToCustomerFile(CustomerManager.GetCustomers());
       

            Environment.Exit(0);
        }
    }
}
