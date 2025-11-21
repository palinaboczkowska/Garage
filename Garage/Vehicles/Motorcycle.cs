using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int CylinderVolume { get; }
        public Motorcycle(string regNumber, string color, int wheels, int cylinderVolume)
            : base(regNumber, color, wheels)
        {
            CylinderVolume = cylinderVolume;
        }


        public override string Print()
        {
            return $"Motorcycle {RegistrationNumber}, Color: {Color}, Wheels: {NumberOfWheels}, Cylinder: {CylinderVolume} cc";
        }
    }
}
