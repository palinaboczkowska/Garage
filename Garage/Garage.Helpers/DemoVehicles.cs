using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Helpers
{
    public static class DemoVehicles
    {
        internal static void SeedData(Manager manager)
        {
            manager.AddVehicle(new Car("ABC123", "Red", 4, "Petrol"));
            manager.AddVehicle(new Car("XYZ789", "Black", 2, "Electric"));
            manager.AddVehicle(new Bus("BUS001", "Blue", 6, 50));
            manager.AddVehicle(new Bus("BUS002", "Yellow", 8, 60));
            manager.AddVehicle(new Boat("BOAT42", "Green", 12.5));
            manager.AddVehicle(new Boat("BOAT99", "White", 8.0));
            manager.AddVehicle(new Motorcycle("MOTO77", "Black", 2, 600));
            manager.AddVehicle(new Motorcycle("MOTO88", "Red", 1, 1000));
            manager.AddVehicle(new Airplane("AIR99", "White", 8, 2));
            manager.AddVehicle(new Airplane("JET007", "Silver", 10, 4));
        }
    }
}
