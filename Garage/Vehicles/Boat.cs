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
        public Boat(string regNumber, string color, double length) 
            : base(regNumber, color, 0) //boats have no wheels
        {
            Length = length;
        }


        public override string Print()
        {
            return $"Boat {RegistrationNumber}, Color: {Color}, Length: {Length} m";
        }
    }
}
