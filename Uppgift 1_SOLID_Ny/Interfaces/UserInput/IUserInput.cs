using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Menu;

namespace Uppgift_1_SOLID_Ny.Interfaces.UserInput
{
    public interface IUserInput
    {
        void GetUserInput(IMenu menu);
    }
}
