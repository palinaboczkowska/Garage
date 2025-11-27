using Garage.Vehicles;
using Garage.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    internal class UI: IUI
    {
        private Manager manager;

        public UI()
        {
            Print("Welcome to Garage!");
            while (true) 
            {
                Print("Start with demo vehicles?");
                Print("1. Yes");
                Print("2. No");
                string choice = GetInput();

                if (choice == "1")
                {
                    // Create a garage with 20 spaces so that after loading demo vehicles (10),
                    // there is still room left for adding new ones
                    manager = new Manager(20);
                    SeedData(manager);
                    break;
                }
                else if (choice == "2")
                {
                    int capacity = Util.AskForInt("Enter garage capacity: ");
                    manager = new Manager(capacity);
                    break;
                }
                else
                {
                    Print("You must enter 1 or 2.");
                }
            }
            
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                ShowMainMenu(); 
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Print("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        AddVehicleMenu();
                        break;
                    case '2':
                        RemoveVehicle();
                        break;
                    case '3':
                        ListVehicles();
                        break;
                    case '4':
                        ListVehicleTypes();
                        break;
                    case '5':
                        FindVehicle();
                        break;
                    case '6':
                        SearchVehiclesMenu();
                        break;
                    case '0':
                        running = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Print("Invalid choice, try again.");
                        break;
                }
            }
        }

        private void SearchVehiclesMenu()
        {
            if (!manager.ListVehicles().Any())
            {
                Print("Garage is empty.");
                return;
            }

            Print("\n--- Search Vehicles ---");
            Print("1. By color");
            Print("2. By number of wheels");
            Print("3. By type");
            Print("0. Back to main menu");
            Console.Write("Choose search option: ");
            string choice = GetInput();

            IEnumerable<Vehicle> results = Enumerable.Empty<Vehicle>();

            switch (choice)
            {
                case "1":
                    Print("Enter color: ");
                    string color = GetInput();
                    results = manager.Search(color: color);
                    break;

                case "2":
                    int wheels = Util.AskForInt("Enter number of wheels: ");
                    results = manager.Search(wheels: wheels);
                    break;

                case "3":
                    Type? type = PromptVehicleType();
                    if (type == null)
                    {
                        Print("Invalid type choice.");
                        return;
                    }
                    results = manager.Search(type: type);
                    break;

                case "0":
                    return;

                default:
                    Print("Invalid choice.");
                    return;
            }

            if (!results.Any())
            {
                Print("No vehicles match your search.");
                return;
            }

            Print("\nSearch results:");
            foreach (var v in results)
            {
                Print(v.Print());
            }
        }

        //Help method
        private Type? PromptVehicleType()
        {
            Print("\nChoose vehicle type:");
            Print("1. Car");
            Print("2. Bus");
            Print("3. Motorcycle");
            Print("4. Boat");
            Print("5. Airplane");
            Print("Your choice: ");

            return GetInput() switch
            {
                "1" => typeof(Car),
                "2" => typeof(Bus),
                "3" => typeof(Motorcycle),
                "4" => typeof(Boat),
                "5" => typeof(Airplane),
                _ => null
            };
        }


        private void FindVehicle()
        {
            // Check if garage is empty before asking for input
            if (!manager.ListVehicles().Any())
            {
                Print("Garage is empty.");
                return;
            }

            Print("Enter registration number to find: ");
            string reg = GetInput();
            var vehicle = manager.FindVehicle(reg);
            if (vehicle != null)
                Print(vehicle.Print());
            else
                Print("Vehicle not found.");
        }



        private void ListVehicles()
        {
            var vehicles = manager.ListVehicles();
            if (!vehicles.Any())
            {
                Print("No vehicles are currently parked.");
                return;
            }

            Print("\nParked vehicles:");
            foreach (var v in vehicles)
            {
                Print(v.Print());
            }

            //Show how many vehicles are parked and cpacity
            int count = vehicles.Count();
            int capacity = manager.GetCapacity();
            Print($"\nTotal parked vehicles : {count}/{capacity}");
        }

        private void ListVehicleTypes()
        {
            if (!manager.ListVehicles().Any())
            {
                Print("Garage is empty.");
                return;
            }

            var types = manager.ListVehicleTypes();
            Print("\nVehicle types in garage: ");
            foreach (var type in types)
                Print($"{type.Type}: {type.Count}");
        }

        private void RemoveVehicle()
        {
            // Check if garage is empty before asking for input
            if (!manager.ListVehicles().Any())
            {
                Print("Garage is empty.");
                return;
            }

            Print("Enter registration number to remove: ");
            string reg = Console.ReadLine();
            string result = manager.RemoveVehicle(reg);
            Print(result);
        }

        private void AddVehicleMenu()
        {
            string typeChoice;
            while (true)
            {
                Print("\n--- Add Vehicle ---"
                    + "\n1. Car"
                    + "\n2. Airplane"
                    + "\n3. Motorcycle"
                    + "\n4. Bus"
                    + "\n5. Boat"
                    + "\nChoose type: ");

                typeChoice = GetInput();

                if (typeChoice == "1" || typeChoice == "2" || typeChoice == "3" || typeChoice == "4" || typeChoice == "5")
                    break;

                Print("Invalid type choice. Please try again.");
            }

            Print("Enter registration number: ");
            string reg = GetInput();
            Print("Enter color: ");
            string color = GetInput();

            int wheels = 0;
            if (typeChoice != "5") // not a boat
                wheels = Util.AskForInt("Enter number of wheels: ");

            Vehicle vehicle = null;
            switch (typeChoice)
            {
                case "1":
                    Print("Enter fuel type: ");
                    string fuel = GetInput();
                    vehicle = new Car(reg, color, wheels, fuel);
                    break;
                case "2":
                    int engines = Util.AskForInt("Enter number of engines: ");
                    vehicle = new Airplane(reg, color, wheels, engines);
                    break;
                case "3":
                    int cylinder = Util.AskForInt("Enter cylinder volume: ");
                    vehicle = new Motorcycle(reg, color, wheels, cylinder);
                    break;
                case "4":
                    int seats = Util.AskForInt("Enter number of seats: ");
                    vehicle = new Bus(reg, color, wheels, seats);
                    break;
                case "5":
                    double length;
                    while (true)
                    {
                        Print("Enter length (m): ");
                        string input = GetInput();

                        if (double.TryParse(input, out length) && length > 0)
                            break;

                        Print("Invalid input. Please enter a positive number (e.g., 8.5).");
                    }

                    vehicle = new Boat(reg, color, length);
                    break;
                default:
                    Print("Invalid type.");
                    return;
            }
            string result = manager.AddVehicle(vehicle);
            Print(result);
        }

        private void ShowMainMenu()
        {
            Print("\nPlease navigate through the menu by inputting the number (1,2,3,4,0):"
            + "\n1. Add vehicle"
            + "\n2. Remove vehicle"
            + "\n3. List all vehicles"
            + "\n4. List vehicle types"
            + "\n5. Find vehicle by registration number"
            + "\n6. Search vehicles by properties"
            + "\n0. Exit the application"
            + "\nYour choice: ");
        }

        private void SeedData(Manager manager)
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

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

    }
}
