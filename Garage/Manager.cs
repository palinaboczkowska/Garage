using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class Manager
    {
        private IHandler handler;
        public Manager(int capacity)
        {
            handler = new GarageHandler(capacity);
        }

        internal int GetCapacity()
        {
            return handler.GetCapacity();
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

        internal Vehicle? FindVehicle(string? reg)
        {
            if (string.IsNullOrWhiteSpace(reg))
                return null;

            return handler.FindVehicle(reg);
        }

        public IEnumerable<Vehicle> Search(string? color = null, int? wheels = null, Type? type = null)
        {
            return handler.SearchVehicles(color, wheels, type);
        }

        internal IEnumerable<Vehicle> ListVehicles()
        {
            return handler.GetAllVehicles();
        }

        internal IEnumerable<(string Type, int Count)> ListVehicleTypes()
        { 
            var vehicles = handler.GetAllVehicles().ToList();

            //Group vehicles by their type
            var grouped = vehicles
                .GroupBy(v => v.GetType().Name)
                .Select(g => (Type: g.Key, Count: g.Count()));
            return grouped;
        }

    }
}
