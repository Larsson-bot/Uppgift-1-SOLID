using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_1_SOLID_Ny.Interfaces.ConsoleHelpers
{
    public interface IWriterHelper
    {
        void ReturnToMenuMessage();
        void WriteToConsole(string message);

    }
}
