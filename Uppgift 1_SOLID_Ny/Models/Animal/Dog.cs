using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift_1_SOLID_Ny.Interfaces.Animal;

namespace Uppgift_1_SOLID_Ny.Models
{
    public class Dog : IDog
    {
        public delegate Dog Factory(int id, string name, bool checkedIn, bool clawscut, bool washed, int ownerId);
        public Dog(int id, string name, bool checkedIn, bool clawscut, bool washed, int ownerId)
        {
            Id = id;
            Name = name;
            CheckedIn = checkedIn;
            Clawscut = clawscut;
            Washed = washed;
            OwnerId = ownerId;
        }

        public Dog()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CheckedIn { get; set; }
        public bool Clawscut { get ; set; }
        public bool Washed { get; set; }
        public int OwnerId { get; set; }
    }
}
