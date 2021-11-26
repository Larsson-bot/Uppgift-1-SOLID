using Autofac;
using System;
using Uppgift_1_SOLID_Ny.AFConfig;
using Uppgift_1_SOLID_Ny.Interfaces.Application;

namespace Uppgift_1_SOLID_Ny
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = AFConfiguration.Configuration();
            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();

                app.Run();
            }
        }
    }
}
