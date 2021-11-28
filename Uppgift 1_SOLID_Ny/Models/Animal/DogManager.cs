using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Animal.Mockup;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;
using Uppgift_1_SOLID_Ny.Interfaces.ListHelper;
using Uppgift_1_SOLID_Ny.Models._Customer;

namespace Uppgift_1_SOLID_Ny.Models.Animal
{
    public class DogManager : IDogManager
    {
        private IDog Dog;
        private Dog.Factory DogFactory;
        private Dogs Dogs;
        private IListHelper ListHelper;
        private IDogMockUp MockUp;
        private Customers Customers;
        private ICustomerManager CustomerManager;

        public DogManager(IDog dog, Dog.Factory dogFactory, Dogs dogs, IListHelper listHelper, IDogMockUp mockUp, Customers customers, ICustomerManager customerManager)
        {
            Dog = dog;
            DogFactory = dogFactory;
            Dogs = dogs;
            ListHelper = listHelper;
            MockUp = mockUp;
            Customers = customers;
            CustomerManager = customerManager;
        }

        public void AddEntity()
        {
            var loop = true;
            Console.WriteLine("Welcome to the Dog registration!");
            Console.WriteLine("If you wanna cancel the registeration. Please type in 0");
            Console.WriteLine("Whats your dogs name?");
            var name = Console.ReadLine();
            if (name != "0")
            {
                Dog.Name = name;
                var id = ListHelper.GetLastId("Dogs");
                Dog.Id = id + 1;
                Dog.CheckedIn = false;
                Dog.Clawscut = false;
                Dog.Washed = false;
                Dog.OwnerId = 0;
                if (Customers.ListOfCustomers.Count != 0)
                {
                    Console.Clear();
                    CustomerManager.CreateCustomList(Customers.ListOfCustomers);
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Please enter the CustomerId this dog belongs to.");
                    Console.WriteLine("If you wanna register a new customer. Type (C/c)");
                    Console.WriteLine("If you wanna cancel the registeration. Please type in 0");
                    while (loop)
                    {
                        try
                        {
                            var stringId = Console.ReadLine();
                            Regex regex = new Regex("^[0-9]*$");
                            if (regex.IsMatch(stringId)) //Kollar av om inputen bara innehåller siffror.
                            {
                                var _id = Convert.ToInt32(stringId); 

                                if (_id != 0)
                                {
                                    foreach (var item in CustomerManager.GetCustomers())
                                    {
                                        if (item.Id == _id)
                                        {
                                            Dog.OwnerId = _id;
                                            loop = false;
                                        }
                                    }

                                    if (Dog.OwnerId == 0)
                                    {
                                        Console.WriteLine("OwnerId does not exist!");
                                    }
                                    else
                                    {
                                        AddAnimalToList(Dog);
                                        Console.WriteLine("The animal has been registered.");
                                        Console.WriteLine("\n\nPress any Key to return to the menu.");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    loop = false;
                                }
                            }
                            else
                            {
                                if (stringId == "C" || stringId == "c")
                                {
                                    CustomerManager.RegisterCustomerFromOtherClass();
                                    Dog.OwnerId = Customers.ListOfCustomers.Last().Id;
                                    AddAnimalToList(Dog);
                                    Console.WriteLine("The animal has been registered.");
                                    Console.WriteLine("\n\nPress any Key to return to the menu.");
                                    Console.ReadKey();
                                    loop = false;
                                }
                                else
                                {
                                    Console.WriteLine("Stringinput was not correct. Please type C or c in order to create a new customer.");
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Unexpected error. Please contact support.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine("There are no registered customers!");
                    Console.WriteLine("Redirecting to CustomerRegistration");
                    CustomerManager.RegisterCustomerFromOtherClass();
                    Dog.OwnerId = Customers.ListOfCustomers.Last().Id;
                    AddAnimalToList(Dog);
                    Console.WriteLine("The animal has been registered.");
                    Console.WriteLine("\n\nPress any Key to return to the menu.");
                    Console.ReadKey();
                }
            }
        }

        public void AddAnimalToList(IDog dog)
        {
            Dogs.Items.Add(DogFactory(dog.Id, dog.Name, dog.CheckedIn, dog.Clawscut, dog.Washed, dog.OwnerId));
        }

        public List<IDog> GetAllAnimalsInKennel()
        {
            var dogs = Dogs.Items.Where(x => x.CheckedIn == true).ToList();
            return dogs;
        }

        public List<IDog> GetAnimals()
        {
            return Dogs.Items;
        }

        public IDog GetSpecficAnimal(int id)
        {
            var _animal = Dogs.Items.FirstOrDefault(x => x.Id == id);
            return _animal;
        }

        public void ListUpAllRegisteredEntities()
        {
            var animals = Dogs.Items;

            if (animals.Count() == 0)
            {
                Console.WriteLine("No animals detected");
            }
            else
            {
                Console.WriteLine("Listing up all registered dogs!");
                Console.WriteLine("Id\tName\t\t\tCheckedIn\t\tOwner");
                foreach (var item in animals)
                {
                    if (item.OwnerId != 0)
                    {
                        var customer = Customers.ListOfCustomers.FirstOrDefault(x => x.Id == item.OwnerId);
                        if (item.Name.Length >= 8)
                        {
                            Console.WriteLine(item.Id + "\t" + item.Name + "\t\t" + item.CheckedIn + "\t\t\t" + customer.Name);
                        }
                        else
                            Console.WriteLine(item.Id + "\t" + item.Name + "\t\t\t" + item.CheckedIn + "\t\t\t" + customer.Name);
                    }
                    else
                    {
                        if (item.Name.Length >= 8)
                        {
                            Console.WriteLine(item.Id + "\t" + item.Name + "\t\t" + item.CheckedIn + "\t\t\t" + item.OwnerId);
                        }
                        else
                            Console.WriteLine(item.Id + "\t" + item.Name + "\t\t\t" + item.CheckedIn + "\t\t\t" + item.OwnerId);
                    }
                }
            }

            Console.WriteLine("\n\nPress any Key to return to the menu.");
            Console.ReadKey();
        }

        public void ListUpAnimalsInKennel()
        {
            var dogs = GetAllAnimalsInKennel();
            if (dogs.Count() == 0)
            {
                Console.WriteLine("No dogs are checked in right now.");
                Console.WriteLine("\n\nPress any Key to return to the menu.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Id\tName\t\t\tCheckedIn\tOwner");
                foreach (var item in dogs)
                {
                    var customer = CustomerManager.GetSpecficCustomer(item.OwnerId);
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t\t\t" + item.CheckedIn + "\t\t" + customer.Name);
                }
                Console.WriteLine("\n\nPress any Key to return to the menu.");
                Console.ReadKey();
            }
        }

        public void ListUpAnimalsReadyToCheckIn()
        {
            var dogs = Dogs.Items.Where(x => x.CheckedIn == false);

            if (dogs.Count() == 0)
            {
                Console.WriteLine("No dogs to be found.");
                Console.WriteLine("\n\nPress any Key to return to the menu.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Id\tName\t\t\tCheckedin");
                foreach (var item in dogs)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t\t\t" + item.CheckedIn);
                }
            }

            Console.WriteLine("\n\n");
        }

        public void PopulateList(List<IDog> dogs)
        {
            if (dogs.Count() == 0)
            {
                var item = new List<IDog>(); //Kod för att lägga in DogMockUp
                item = MockUp.AddMockUpAnimals(item);
                foreach (var i in item)
                {
                    AddAnimalToList(i);
                }
            }
            else
            {
                foreach (var item in dogs)
                {
                    AddAnimalToList(item);
                }
            }
        }

        public void UpdateAnimalStatus(IDog dog)
        {
            var _dog = Dogs.Items.FirstOrDefault(x => x.Id == dog.Id);
            var index = Dogs.Items.FindIndex(x => x.Name == dog.Name);
            _dog = dog;
            Dogs.Items.RemoveAt(index);
            Dogs.Items.Insert(index, _dog);
        }

        public void CreateCustomListUp(List<IDog> dogs)
        {
            Console.WriteLine("Id\tName\t\t\tCheckedIn\tOwner");
            foreach (var item in dogs)
            {
                var customer = CustomerManager.GetSpecficCustomer(item.OwnerId);
                if (item.Name.Length >= 8)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t\t" + item.CheckedIn + "\t\t\t" + customer.Name);
                }
                else
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t\t\t" + item.CheckedIn + "\t\t\t" + customer.Name);
            }
        }
    }
}