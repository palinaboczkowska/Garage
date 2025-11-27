using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Helpers
{
    internal class MenuHelpers
    {
        public static void ShowMainMenu(IUI ui)
        {
            ui.Print("\nPlease navigate through the menu by inputting the number (1,2,3,4,0):"
            + "\n1. Add vehicle"
            + "\n2. Remove vehicle"
            + "\n3. List all vehicles"
            + "\n4. List vehicle types"
            + "\n5. Find vehicle by registration number"
            + "\n6. Search vehicles by properties"
            + "\n0. Exit the application"
            + "\nYour choice: ");
        }

        public static void ShowSearchMenu(IUI ui)
        {
            ui.Print("\n--- Search Vehicles ---");
            ui.Print("1. By color");
            ui.Print("2. By number of wheels");
            ui.Print("3. By type");
            ui.Print("0. Back to main menu");
            ui.Print("Choose search option: ");
        }

        //Help method
        public static Type? PromptVehicleType(IUI ui)
        {
            ui.Print("\nChoose vehicle type:");
            ui.Print("1. Car");
            ui.Print("2. Bus");
            ui.Print("3. Motorcycle");
            ui.Print("4. Boat");
            ui.Print("5. Airplane");
            ui.Print("Your choice: ");

            return ui.GetInput() switch
            {
                "1" => typeof(Car),
                "2" => typeof(Bus),
                "3" => typeof(Motorcycle),
                "4" => typeof(Boat),
                "5" => typeof(Airplane),
                _ => null
            };
        }

        public static void ShowAddVehicleMenu(IUI ui)
        {
            ui.Print("\n--- Add Vehicle ---"
                    + "\n1. Car"
                    + "\n2. Airplane"
                    + "\n3. Motorcycle"
                    + "\n4. Bus"
                    + "\n5. Boat"
                    + "\nChoose type: ");
        }
    }
}
