using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public interface IGarage<T> : IEnumerable<T> where T : Vehicle
    {
        int Capacity { get; }
        int Count { get; }

        bool AddVehicle(T vehicle);
        bool RemoveVehicle(string regNumber);
    }

}
