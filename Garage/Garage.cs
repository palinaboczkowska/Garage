using Garage.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class Garage<T>: IEnumerable<T> where T : Vehicle
    {
        private T[] vehicles;
        private int capacity;
        private int count; // How many vehicles are currently parked


        public Garage(int capacity) 
        {
            this.capacity = capacity;
            vehicles = new T[capacity];
        }

        public bool AddVehicle(T vehicle)
        {
            if (count >= capacity)
                return false; //garage is full
            vehicles[count++] = vehicle;
            return true;
        }

        public bool RemoveVehicle(string regNumber)
        {
            for (int i = 0; i < count; i++) 
            {
                if (vehicles[i].RegistrationNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase))
                {
                    // Replace removed vehicle with the last one in the array
                    vehicles[i] = vehicles[i - 1];
                    vehicles[count - 1] = null;
                    count--;
                    return true;
                }
            }
            return false;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return vehicles[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
