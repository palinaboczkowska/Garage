using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Bus : Vehicle
    {
        public int NumberOfSeats { get; }
        public Bus(string regNumber, string color, int wheels, int numberOfSeats) 
            : base(regNumber, color, wheels)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}
