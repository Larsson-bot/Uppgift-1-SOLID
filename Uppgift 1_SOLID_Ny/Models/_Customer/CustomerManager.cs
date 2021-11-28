using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        private ICustomerMockUp CustomerMockUp;

        public CustomerManager(ICustomer customer, Customers customers, Customer.Factory customerFactory, IListHelper listHelper, ICustomerMockUp customerMockUp)
        {
            Customer = customer;
            Customers = customers;
            CustomerFactory = customerFactory;
            ListHelper = listHelper;
            CustomerMockUp = customerMockUp;
        }

        public void AddEntity()
        {
            bool loop = true;
            string name = "";
            Console.WriteLine("Welcome to the Customer registration! ");
            Console.WriteLine("If you wanna cancel the registeration. Please type in 0");
            Console.WriteLine("Whats your name?");
            try
            {
          
                while (loop)
                {
                    name = Console.ReadLine();

                    if (name.Length > 2 && Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                    {
                        Customer.Name = name;
                        Customer.Id = ListHelper.GetLastId("Customers") + 1;
                        

                        loop = false;
                    }
                    else if (Regex.IsMatch(name, "0"))
                    {
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("A name needs atleast two letters.");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Please dont use numbers.");
            }
            try
            {
                if (name != "0")
                {
                    loop = true;
                    Console.WriteLine("Whats your emailadress?");
                    while (loop)
                    {
                        var email = Console.ReadLine();

                        var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");

                        if (email.Length > 4 && regex.IsMatch(email))
                        {
                            Customer.Email = email;


                            AddCustomerToList(Customer);
                            Console.WriteLine("Customer has been created!");
                            Console.WriteLine("\n\nPress any Key to return to the menu.");
                            Console.ReadKey();
                            loop = false;
                        }
                        else if (Regex.IsMatch(email, "0"))
                        {
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("Please write a valid emailformat a@a.com.");
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Format Error.");
            }
        }

        public void RegisterCustomerFromOtherClass()
        {
            bool loop = true;
            Console.WriteLine("Welcome to the Customer registration! ");

            Console.WriteLine("Whats your name?");
            try
            {
            
                while (loop)
                {
                    var name = Console.ReadLine();
                    if (name.Length > 2 && Regex.IsMatch(name, @"^[a-öA-Ö]+$"))
                    {
                        Customer.Name = name;
                        Customer.Id = ListHelper.GetLastId("Customers") + 1;

                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("A name needs atleast two letters.");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Please dont use numbers.");
            }
            loop = true;
            Console.WriteLine("Whats your emailadress?");
            try
            {
                while (loop)
                {
                    var email = Console.ReadLine();
                    var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
                    if (email.Length > 4 && regex.IsMatch(email))
                    {
                        Customer.Email = email;
                        AddCustomerToList(Customer);
                        Console.WriteLine("Customer has been created!");
                        loop = false;
                    }
                    else
                    {
                        Console.WriteLine("Please write a valid emailformat a@a.com.");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Format Error.");
            }
        }

        public void ListUpAllRegisteredEntities()
        {
            if (Customers.ListOfCustomers.Count() == 0)
            {
                Console.WriteLine("No Customers detected");
            }
            else
            {
                Console.WriteLine("Listing up all registered customers!");
                Console.WriteLine("Id\tName\t\tEmail");
                foreach (var item in Customers.ListOfCustomers)
                {
                    if (item.Name.Length >= 8)
                    {
                        Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Email);
                    }
                    else
                        Console.WriteLine(item.Id + "\t" + item.Name + "\t\t" + item.Email);

                }
            }
            Console.WriteLine("\n\nPress any Key to return to the menu.");
            Console.ReadKey();
        }

        public void AddCustomerToList(ICustomer customer)
        {
            Customers.ListOfCustomers.Add(CustomerFactory(customer.Id, customer.Name,customer.Email));
        }

        public void PopulateList(List<ICustomer> customers)
        {
            if (customers.Count() == 0)
            {
                var item = new List<ICustomer>(); //Kod för att mockup ska fungera.
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

        public ICustomer GetSpecficCustomer(int id)
        {
            return Customers.ListOfCustomers.FirstOrDefault(c => c.Id == id);
        }

        public void CreateCustomList(List<ICustomer> customers)
        {
            Console.WriteLine("Id\tName\t\tEmail");
            foreach (var item in customers)
            {
                if (item.Name.Length >= 8)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Email);
                }
                else
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t\t" + item.Email);
            }
        }
    }
}