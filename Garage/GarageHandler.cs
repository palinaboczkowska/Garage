using Garage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            // Ensure no duplicate registration number exists
            foreach (Vehicle v in garage)
            {
                if (v.RegistrationNumber.Equals(vehicle.RegistrationNumber, StringComparison.OrdinalIgnoreCase))
                    return false; //already exist
            }
            return garage.AddVehicle(vehicle);
        }

        public bool RemoveVehicle(string regNumber)
        {
            return garage.RemoveVehicle(regNumber);
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return garage;
        }

        internal Vehicle FindVehicle(string regNumber)
        {
            foreach (var v in garage)
            {
                if (v.RegistrationNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                    return v;
            }
            return null;
        }

        public IEnumerable<Vehicle> SearchVehicles(string? color = null, int? wheels = null, Type? type = null)
        {
            return garage.Where(v =>
                (color == null || v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)) &&
                (wheels == null || v.NumberOfWheels == wheels) &&
                (type == null || v.GetType() == type)
            );
        }


    }
}
