using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;
using Uppgift_1_SOLID_Ny.Interfaces.FIleManager;

namespace Uppgift_1_SOLID_Ny.Models.FileManager
{
    public class FileManager : IFileManager
    {



        private Dog.Factory DogFactory;

        public FileManager(Dog.Factory dogFactory)
        {
            DogFactory = dogFactory;
        }

        public bool CheckIfFileExists(string fileName)
            {
                Directory.CreateDirectory(@"C:\Files");
                var fileexists = File.Exists($@"C:\Files\{fileName}.json");
                return fileexists;
            }
   

        public List<ICustomer> ReadCustomerFile()
        {
            throw new NotImplementedException();
        }

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

        public void WriteToAnimalFile(List<IDog> dogs)
        {
            var json = JsonConvert.SerializeObject(dogs);


            File.WriteAllText(@"C:\Files\Dogs.json", json);
        }

        public void WriteToCustomerFile(ICustomer customer)
        {
            throw new NotImplementedException();
        }
    }
}
