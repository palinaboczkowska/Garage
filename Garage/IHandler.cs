using Garage.Vehicles;

namespace Garage
{
    internal interface IHandler
    {
        bool ParkVehicle(Vehicle vehicle);
        int GetCapacity();
        bool RemoveVehicle(string regNumber);
        Vehicle FindVehicle(string regNumber);
        IEnumerable<Vehicle> GetAllVehicles();
        IEnumerable<Vehicle> SearchVehicles(string? color = null, int? wheels = null, Type? type = null);

    }
}