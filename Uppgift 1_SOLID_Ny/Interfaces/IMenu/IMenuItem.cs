﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_1_SOLID_Ny.Interfaces.IMenu
{
    public interface IMenuItem
    {
        char Selector { get; set; }
        string Title { get; set; }
        Action RunFunction { get; set; }
    }
}
