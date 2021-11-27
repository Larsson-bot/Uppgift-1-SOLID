using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.FIleManager.Helpers;
using Uppgift_1_SOLID_Ny.Interfaces.FIleManager.Readers;
using Uppgift_1_SOLID_Ny.Interfaces.FIleManager.Writers;

namespace Uppgift_1_SOLID_Ny.Interfaces.FIleManager
{
    public interface IFileManager : IFileWriter, IFileReader, IFileHelper
    {
    }
}
