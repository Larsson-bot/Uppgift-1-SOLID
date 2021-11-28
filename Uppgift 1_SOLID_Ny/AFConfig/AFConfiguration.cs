using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Animal.Mockup;
using Uppgift_1_SOLID_Ny.Interfaces.Application;
using Uppgift_1_SOLID_Ny.Interfaces.Customer;
using Uppgift_1_SOLID_Ny.Interfaces.FIleManager;
using Uppgift_1_SOLID_Ny.Interfaces.ListHelper;
using Uppgift_1_SOLID_Ny.Interfaces.Menu;
using Uppgift_1_SOLID_Ny.Interfaces.ReportInOut;
using Uppgift_1_SOLID_Ny.Interfaces.UserInput;
using Uppgift_1_SOLID_Ny.Models;
using Uppgift_1_SOLID_Ny.Models.Animal;
using Uppgift_1_SOLID_Ny.Models.Animal.MockUp;
using Uppgift_1_SOLID_Ny.Models.Application;
using Uppgift_1_SOLID_Ny.Models._Customer;
using Uppgift_1_SOLID_Ny.Models.FileManager;
using Uppgift_1_SOLID_Ny.Models.ListHelper;
using Uppgift_1_SOLID_Ny.Models.Menu;
using Uppgift_1_SOLID_Ny.Models.ReportInOut;
using Uppgift_1_SOLID_Ny.Models.UserInput;
using Uppgift_1_SOLID_Ny.Models._Customer.Mockup;
using Uppgift_1_SOLID_Ny.Interfaces.Customer.Mockup;
using Uppgift_1_SOLID_Ny.Models.Services;
using Uppgift_1_SOLID_Ny.Interfaces.Services;
using Uppgift_1_SOLID_Ny.Interfaces.Services.ReceiptServices;
using Uppgift_1_SOLID_Ny.Models.ConsoleHelpers;
using Uppgift_1_SOLID_Ny.Interfaces.ConsoleHelpers;

namespace Uppgift_1_SOLID_Ny.AFConfig
{
    public static class AFConfiguration
    {
        public static IContainer Configuration()
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<MainMenu>().As<IMainMenu>();
            builder.RegisterType<Menu>().As<IMenu>();
            builder.RegisterType<MenuItem>().As<IMenuItem>();
            builder.RegisterType<MenuManager>().As<IMenuManager>();
            builder.RegisterType<UserInput>().As<IUserInput>();
            builder.RegisterType<Dog>().As<IDog>();
            builder.RegisterType<Dog>();
            builder.RegisterType<DogManager>().As<IDogManager>();
            builder.RegisterType<Dogs>().InstancePerLifetimeScope();
            builder.RegisterType<FileManager>().As<IFileManager>();
            builder.RegisterType<ListHelper>().As<IListHelper>();
            builder.RegisterType<ReportManager>().As<IReportManager>();
            builder.RegisterType<DogMockUp>().As<IDogMockUp>();
            builder.RegisterType<Customer>().As<ICustomer>();
            builder.RegisterType<Customer>();
            builder.RegisterType<CustomerManager>().As<ICustomerManager>();
            builder.RegisterType<Customers>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerMockUp>().As<ICustomerMockUp>();
            builder.RegisterType<DogService>().As<IDogService>();
            builder.RegisterType<ReceiptService>().As<IReceiptService>();
            builder.RegisterType<ConsoleHelper>().As<IConsoleHelper>();
            return builder.Build();
        }
    }
}
