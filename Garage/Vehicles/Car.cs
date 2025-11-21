using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Car : Vehicle
    {
        public string FuelType { get; }
        public Car(string regNumber, string color, int wheels, string fuelType) 
            : base(regNumber, color, wheels)
        {
            FuelType = fuelType;
        }


        public override string Print()
        {
            return $"Car {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}, Fuel: {FuelType}";
        }
    }
}
