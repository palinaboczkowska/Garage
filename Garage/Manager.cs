using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Manager
    {
        private GarageHandler handler;
        public Manager(int capacity)
        {
            handler = new GarageHandler(capacity);
        }

        internal string AddVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        internal Vehicle FindVehicle(string? reg)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<Vehicle> ListVehicles()
        {
            throw new NotImplementedException();
        }

        internal string RemoveVehicle(string? reg)
        {
            throw new NotImplementedException();
        }
    }
}
