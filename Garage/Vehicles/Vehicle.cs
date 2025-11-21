using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    public abstract class Vehicle
    {
        public string RegistrationNumber { get; }
        public string Color { get; }
        public int NumberOfWheels { get; }

        public Vehicle(string regNumber, string color, int wheels)
        {
            RegistrationNumber = regNumber;
            Color = color;
            NumberOfWheels = wheels;
        }

    }

}
