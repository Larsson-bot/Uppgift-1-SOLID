using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;
using Uppgift_1_SOLID_Ny.Interfaces.Customer.Mockup;
using Uppgift_1_SOLID_Ny.Interfaces.ListHelper;


namespace Uppgift_1_SOLID_Ny.Models._Customer
{
    public class CustomerManager : ICustomerManager
    {

        private ICustomer Customer;
        private Customers Customers;
        private Customer.Factory CustomerFactory;
        private IListHelper ListHelper;
        private IDogManager DogManager;
        private IDog Dog;
        private ICustomerMockUp CustomerMockUp;

        public CustomerManager(ICustomer customer, Customers customers, Customer.Factory customerFactory, IListHelper listHelper, IDogManager dogManager, IDog dog, ICustomerMockUp customerMockUp)
        {
            Customer = customer;
            Customers = customers;
            CustomerFactory = customerFactory;
            ListHelper = listHelper;
            DogManager = dogManager;
            Dog = dog;
            CustomerMockUp = customerMockUp;
        }

        public void AddEntity()
        {
            bool loop = true;


            Console.WriteLine("Whats your name?");
            Customer.Name = Console.ReadLine();
            Customer.Id = ListHelper.GetLastId("Customers");

            while (loop)
            {
                Console.WriteLine("Whats your phonenumber?");
                try
                {
                    Customer.PhoneNumber = Console.ReadLine();
                    loop = false;
                }
                catch
                {
                    Console.WriteLine("Please use numbers.");
                }

            }
            Console.WriteLine("Do you have a animal registered? y/n ");
            if (Console.ReadKey().KeyChar == 'y')
            {
                DogManager.ListUpAllRegisteredEntities();
                Console.WriteLine("Please write the Id of your Animal");
                Console.WriteLine("Wanna register a animal instead? Press 0!");
                loop = true;
                while (loop)
                {
                    try
                    {
                        var id = Convert.ToInt32(Console.ReadLine());
                        if (id == 0)
                        {
                            DogManager.AddEntity();
                            loop = false;
                        }
                        var animals = DogManager.GetAnimals();

                        foreach (var item in animals)
                        {
                            if (item.Id == id)
                            {
                                Customer.AnimalId = item.Id;
                                loop = false;
                            }
                        }
                        if (Customer.AnimalId == 0)
                        {
                            Console.WriteLine("The id you entered does not exist. Please try a new one.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please use numbers.");
                    }
                }

            }
            else
            {
                DogManager.AddEntity();
            }
            AddCustomerToList(Customer);
        }

        public void ListUpAllRegisteredEntities()
        {
          
            if (Customers.ListOfCustomers.Count() == 0)
            {
                Console.WriteLine("No Customers detected");
            }
            else
            {
                Console.WriteLine("Id:\tName:\t\tPhoneNumber:\t\tAnimal");
                foreach (var item in Customers.ListOfCustomers)
                {

                    var animal = DogManager.GetSpecficAnimal(item.Id);
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t\t" + item.PhoneNumber + "\t\t" + animal.Name);
                }
            }
            Console.WriteLine("\n\nPress any Key to return to the menu.");
            Console.ReadKey();
        }

        public void AddCustomerToList(ICustomer customer)
        {
            Customers.ListOfCustomers.Add(CustomerFactory(customer.Id, customer.Name, customer.PhoneNumber, customer.AnimalId));
        }

        public void PopulateList(List<ICustomer> customers)
        {
            if (customers.Count() == 0)
            {

                var item = new List<ICustomer>();
                item = CustomerMockUp.AddMockUpCustomers(item);
                foreach (var i in item)
                {
                    AddCustomerToList(i);
                }
            }
            else
            {
                foreach (var item in customers)
                {
                    AddCustomerToList(item);
                }
            }
        }
        public List<ICustomer> GetCustomers()
        {
            return Customers.ListOfCustomers;
        }
    }
}
