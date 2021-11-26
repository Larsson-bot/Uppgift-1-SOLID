using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Application;

namespace Uppgift_1_SOLID_Ny.Models.Application
{
    public class Application : IApplication
    {
        public void End()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine("Hello World");
            Console.ReadKey();
        }
    }
}
