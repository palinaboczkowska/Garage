using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Boat : Vehicle
    {
        public double Length { get; set; }
        public Boat(string regNumber, string color, int wheels, double length) 
            : base(regNumber, color, wheels)
        {
            Length = length;
        }
    }
}
