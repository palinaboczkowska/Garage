using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class UI
    {
        private Manager manager;

        public UI()
        {
            Console.WriteLine("Welcome to Garage!");
            Console.Write("Enter garage capacity: ");
            int capacity = int.Parse(Console.ReadLine());
            manager = new Manager(capacity);

        }

        internal void Run()
        {
            


        }
    }
}
