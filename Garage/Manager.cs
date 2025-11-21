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
            bool success = handler.ParkVehicle(vehicle);
            return success
                ? $"Vehicle {vehicle.RegistrationNumber} parked successfully."
                : $"Failed to park vehicle {vehicle.RegistrationNumber}. It may already exist or garage is full.";
        }

        internal string RemoveVehicle(string? reg)
        {
            if (string.IsNullOrWhiteSpace(reg))
                return "Invalid registration number.";

            bool success = handler.RemoveVehicle(reg);
            return success
                ? $"Vehicle {reg} removed successfully."
                : $"Vehicle {reg} not found.";
        }

        internal Vehicle FindVehicle(string? reg)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<Vehicle> ListVehicles()
        {
            return handler.GetAllVehicles();
        }
    }
}
