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
            Console.WriteLine("Welcome to the Customer registration! ");
            Console.WriteLine("If you wanna cancel the registeration. Please type in 0");
            Console.WriteLine("Whats your name?");
            try
            {
                bool loop = true;
                while (loop)
                {
                    var name = Console.ReadLine();

                    if (name.Length > 2 && Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                    {
                        Customer.Name = name;
                        Customer.Id = ListHelper.GetLastId("Customers") + 1;
                        AddCustomerToList(Customer);
                        Console.WriteLine("Customer has been created!");
                        Console.WriteLine("\n\nPress any Key to return to the menu.");
                        Console.ReadKey();
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
        }

        public void RegisterCustomerFromOtherClass()
        {
            Console.WriteLine("Welcome to the Customer registration! ");

            Console.WriteLine("Whats your name?");
            try
            {
                bool loop = true;
                while (loop)
                {
                    var name = Console.ReadLine();
                    if (name.Length > 2 && Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                    {
                        Customer.Name = name;
                        Customer.Id = ListHelper.GetLastId("Customers") + 1;
                        AddCustomerToList(Customer);
                        Console.WriteLine("Customer has been created!");
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
                Console.WriteLine("Id\tName");
                foreach (var item in Customers.ListOfCustomers)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name);
                }
            }
            Console.WriteLine("\n\nPress any Key to return to the menu.");
            Console.ReadKey();
        }

        public void AddCustomerToList(ICustomer customer)
        {
            Customers.ListOfCustomers.Add(CustomerFactory(customer.Id, customer.Name));
        }

        public void PopulateList(List<ICustomer> customers)
        {
            if (customers.Count() == 0)
            {
                //var item = new List<ICustomer>();
                //item = CustomerMockUp.AddMockUpCustomers(item);
                //foreach (var i in item)
                //{
                //    AddCustomerToList(i);
                //}
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
            Console.WriteLine("Id\tName");
            foreach (var item in customers)
            {
                Console.WriteLine(item.Id + "\t" + item.Name);
            }
        }
    }
}