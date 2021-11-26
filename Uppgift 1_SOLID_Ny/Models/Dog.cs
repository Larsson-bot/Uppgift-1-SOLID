using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces;

namespace Uppgift_1_SOLID_Ny.Models
{
    public class Dog : IDog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAnimalHere { get; set; }
        public string Breed { get; set; }
        public bool Clawscut { get ; set; }
        public bool Washed { get; set; }

    }
}
