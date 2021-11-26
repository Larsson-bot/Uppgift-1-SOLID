using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Application;
using Uppgift_1_SOLID_Ny.Interfaces.IMenu;
using Uppgift_1_SOLID_Ny.Models.Application;
using Uppgift_1_SOLID_Ny.Models.Menu;

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

            return builder.Build();
        }
    }
}
