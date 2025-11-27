using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Helpers
{
    public static class Util
    {

        public static int AskForInt(string prompt, IUI ui)
        {
            int value;
            while (true)
            {
                ui.Print(prompt);
                string input = ui.GetInput();

                if (int.TryParse(input, out value) && value >= 0)
                    return value;

                ui.Print($"Invalid input. Please enter a positive number.");
            }
        }


    }
}
