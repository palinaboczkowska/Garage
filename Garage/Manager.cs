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



    }
}
