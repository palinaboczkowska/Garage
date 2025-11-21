using Garage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class GarageHandler
    {
        private Garage<Vehicle> garage;

        public GarageHandler(int capacity)
        { 
            garage = new Garage<Vehicle>(capacity);
        }

        public bool ParkVehicle(Vehicle vehicle) 
        {



            return true;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return garage;
        }

    }
}
