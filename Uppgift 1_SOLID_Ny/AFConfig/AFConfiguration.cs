using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;
using Uppgift_1_SOLID_Ny.Interfaces.Application;
using Uppgift_1_SOLID_Ny.Interfaces.FIleManager;
using Uppgift_1_SOLID_Ny.Interfaces.Menu;
using Uppgift_1_SOLID_Ny.Interfaces.UserInput;
using Uppgift_1_SOLID_Ny.Models;
using Uppgift_1_SOLID_Ny.Models.Animal;
using Uppgift_1_SOLID_Ny.Models.Application;
using Uppgift_1_SOLID_Ny.Models.FileManager;
using Uppgift_1_SOLID_Ny.Models.Menu;
using Uppgift_1_SOLID_Ny.Models.UserInput;

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
            return builder.Build();
        }
    }
}
