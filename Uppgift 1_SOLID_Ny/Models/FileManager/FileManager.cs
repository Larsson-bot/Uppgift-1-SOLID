using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;
using Uppgift_1_SOLID_Ny.Interfaces.FIleManager;
using Uppgift_1_SOLID_Ny.Models._Customer;

namespace Uppgift_1_SOLID_Ny.Models.FileManager
{
    public class FileManager : IFileManager
    {
        private Dog.Factory DogFactory;
        private Customer.Factory CustomerFactory;

        public FileManager(Dog.Factory dogFactory, Customer.Factory customerFactory)
        {
            DogFactory = dogFactory;
            CustomerFactory = customerFactory;
        }

        //Kollar av om filen existar och skickar tillbaka ett true/false värde.
        public bool CheckIfFileExists(string fileName)
        {
            Directory.CreateDirectory(@"C:\Files");
            var fileexists = File.Exists($@"C:\Files\{fileName}.json");
            return fileexists;
        }

        //Läser in kundfilen óch skapar en lista med kundobjekt/ alternativt skapar en tom lista om det inte finns några objekt. 
        public List<ICustomer> ReadCustomerFile()
        {
            var fileexists = CheckIfFileExists("Customers");
            if (fileexists == true)
            {
                var path = File.ReadAllText(@"C:\Files\Customers.json");
                var json = JsonConvert.DeserializeObject<List<Customer>>(path);
                var listOfCustomers = new List<ICustomer>();
                foreach (var item in json)
                {
                    listOfCustomers.Add(CustomerFactory(item.Id, item.Name,item.Email));
                }
                return listOfCustomers;
            }
            else
            {
                List<ICustomer> animals = new List<ICustomer>();
                return animals;
            }
        }
        //Läser in hundfilen óch skapar en lista med hundobjekt/ alternativt skapar en tom lista om det inte finns några objekt. 

        public List<IDog> ReadDogFíle()
        {
            var fileexists = CheckIfFileExists("Dogs");
            if (fileexists == true)
            {
                var path = File.ReadAllText(@"C:\Files\Dogs.json");
                var json = JsonConvert.DeserializeObject<List<Dog>>(path);
                var listOfIDogs = new List<IDog>();
                foreach (var item in json)
                {
                    listOfIDogs.Add(DogFactory(item.Id, item.Name, item.CheckedIn, item.Clawscut, item.Washed, item.OwnerId));
                }
                return listOfIDogs;
            }
            else
            {
                List<IDog> animals = new List<IDog>();
                return animals;
            }
        }
        //Skriver över listan till filen.
        public void WriteToAnimalFile(List<IDog> dogs)
        {
            var json = JsonConvert.SerializeObject(dogs);

            File.WriteAllText(@"C:\Files\Dogs.json", json);
        }
        //Skriver över listan till filen.
        public void WriteToCustomerFile(List<ICustomer> customers)
        {
            var json = JsonConvert.SerializeObject(customers);

            File.WriteAllText(@"C:\Files\Customers.json", json);
        }
    }
}