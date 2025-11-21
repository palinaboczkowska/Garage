using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Vehicles
{
    internal class Airplane : Vehicle
    {
        public int NumberOfEngines { get; }
        public Airplane(string regNumber, string color, int wheels, int engines) 
            : base(regNumber, color, wheels)
        {
            NumberOfEngines = engines;
        }
    }
}
