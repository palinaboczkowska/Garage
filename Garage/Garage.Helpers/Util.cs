using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Helpers
{
    public static class Util
    {

        public static int AskForInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out value) && value >= 0)
                    return value;

                Console.WriteLine($"Invalid input. Please enter a positive number.");
            }
        }


    }
}
