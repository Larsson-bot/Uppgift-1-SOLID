using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Application;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;
using Uppgift_1_SOLID_Ny.Interfaces.FIleManager;
using Uppgift_1_SOLID_Ny.Interfaces.Menu;
using Uppgift_1_SOLID_Ny.Interfaces.UserInput;

namespace Uppgift_1_SOLID_Ny.Models.Application
{
    public class Application : IApplication
    {
        private IMainMenu MainMenu;
        private IUserInput UserInput;
        private IDogManager DogManager;
        private IFileManager FileManager;
        private ICustomerManager CustomerManager;

        public Application(IMainMenu mainMenu, IUserInput userInput, IDogManager dogManager, IFileManager fileManager, ICustomerManager customerManager)
        {
            MainMenu = mainMenu;
            UserInput = userInput;
            DogManager = dogManager;
            FileManager = fileManager;
            CustomerManager = customerManager;
        }

        //Funktion som drar igång applikationen. 
        public void Run()
        {
            CustomerManager.PopulateList(FileManager.ReadCustomerFile());
            DogManager.PopulateList(FileManager.ReadDogFíle());
            AppDomain.CurrentDomain.ProcessExit += ProcessExitHandler;
            while (true)
            {
                var menu = MainMenu.Init();
                UserInput.GetUserInput(menu);
            }
        }


        //Funktion som sparar ner all data ifall användaren stänger ner 
        public void ProcessExitHandler(object sender, EventArgs e)
        {
            FileManager.WriteToAnimalFile(DogManager.GetAnimals());
            FileManager.WriteToCustomerFile(CustomerManager.GetCustomers());
        }
    }
}
