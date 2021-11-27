using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Application;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;
using Uppgift_1_SOLID_Ny.Interfaces.Menu;
using Uppgift_1_SOLID_Ny.Interfaces.ReportInOut;

namespace Uppgift_1_SOLID_Ny.Models.Menu
{
    public class MainMenu : IMainMenu
    {
        private IMenuManager MenuManager;
        private IDogManager DogManager;
        private IReportManager ReportManager;
        private ICustomerManager CustomerManager;

        public MainMenu(IMenuManager menuManager, IDogManager dogManager, IReportManager reportManager, ICustomerManager customerManager)
        {
            MenuManager = menuManager;
            DogManager = dogManager;
            ReportManager = reportManager;
            CustomerManager = customerManager;
        }

        public IMenu Init()
        {
            MenuManager.CreateMenu("Welcome to the kennelApplication!");
            MenuManager.CreateMenuItem('1', "Add a customer", CustomerManager.AddEntity);
            MenuManager.CreateMenuItem('2', "Add a animal", DogManager.AddEntity);
            MenuManager.CreateMenuItem('3', "List up all registered customers", CustomerManager.ListUpAllRegisteredEntities);
            MenuManager.CreateMenuItem('4', "List up all registered animals", DogManager.ListUpAllRegisteredEntities);
            MenuManager.CreateMenuItem('6', "Check in a dog", ReportManager.ReportIn);
            MenuManager.CreateMenuItem('7', "Check out a dog", ReportManager.ReportOut);
            MenuManager.CreateMenuItem('x', "Exit Application", MenuManager.EndApplication);
            MenuManager.DisplayMenu();
            return MenuManager.GetMenu();
        }
    }
}
