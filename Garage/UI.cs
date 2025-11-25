using Garage.Vehicles;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            Console.WriteLine("Start with demo vehicles?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // Create a garage with 20 spaces so that after loading demo vehicles (10),
                // there is still room left for adding new ones
                manager = new Manager(20); 
                SeedData(manager);
            }
            else {
                int capacity = AskForInt("Enter garage capacity: ");
                manager = new Manager(capacity);
            }
        }

        internal void Run()
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
                    Console.WriteLine("Please enter some input!");
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
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
            }
        }

        private void SearchVehiclesMenu()
        {
            if (!manager.ListVehicles().Any())
            {
                Console.WriteLine("Garage is empty.");
                return;
            }

            Console.WriteLine("\n--- Search Vehicles ---");
            Console.WriteLine("1. By color");
            Console.WriteLine("2. By number of wheels");
            Console.WriteLine("3. By type");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Choose search option: ");
            string choice = Console.ReadLine();

            IEnumerable<Vehicle> results = Enumerable.Empty<Vehicle>();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter color: ");
                    string color = Console.ReadLine();
                    results = manager.Search(color: color);
                    break;

                case "2":
                    int wheels = AskForInt("Enter number of wheels: ");
                    results = manager.Search(wheels: wheels);
                    break;

                case "3":
                    Type? type = PromptVehicleType();
                    if (type == null)
                    {
                        Console.WriteLine("Invalid type choice.");
                        return;
                    }
                    results = manager.Search(type: type);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            if (!results.Any())
            {
                Console.WriteLine("No vehicles match your search.");
                return;
            }

            Console.WriteLine("\nSearch results:");
            foreach (var v in results)
            {
                Console.WriteLine(v.Print());
            }
        }

        //Help method
        private Type? PromptVehicleType()
        {
            Console.WriteLine("\nChoose vehicle type:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Bus");
            Console.WriteLine("3. Motorcycle");
            Console.WriteLine("4. Boat");
            Console.WriteLine("5. Airplane");
            Console.Write("Your choice: ");

            return Console.ReadLine() switch
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
                Console.WriteLine("Garage is empty.");
                return;
            }

            Console.Write("Enter registration number to find: ");
            string reg = Console.ReadLine();
            var vehicle = manager.FindVehicle(reg);
            if (vehicle != null)
                Console.WriteLine(vehicle.Print());
            else
                Console.WriteLine("Vehicle not found.");
        }



        private void ListVehicles()
        {
            var vehicles = manager.ListVehicles();
            if (!vehicles.Any())
            {
                Console.WriteLine("No vehicles are currently parked.");
                return;
            }

            Console.WriteLine("\nParked vehicles:");
            foreach (var v in vehicles)
            {
                Console.WriteLine(v.Print());
            }
        }

        private void ListVehicleTypes()
        {
            if (!manager.ListVehicles().Any())
            {
                Console.WriteLine("Garage is empty.");
                return;
            }

            var types = manager.ListVehicleTypes();
            Console.WriteLine("\nVehicle types in garage: ");
            foreach (var type in types)
                Console.WriteLine($"{type.Type}: {type.Count}");
        }

        private void RemoveVehicle()
        {
            // Check if garage is empty before asking for input
            if (!manager.ListVehicles().Any())
            {
                Console.WriteLine("Garage is empty.");
                return;
            }

            Console.Write("Enter registration number to remove: ");
            string reg = Console.ReadLine();
            string result = manager.RemoveVehicle(reg);
            Console.WriteLine(result);
        }

        private void AddVehicleMenu()
        {
            string typeChoice;
            while (true)
            {
                Console.WriteLine("\n--- Add Vehicle ---"
                    + "\n1. Car"
                    + "\n2. Airplane"
                    + "\n3. Motorcycle"
                    + "\n4. Bus"
                    + "\n5. Boat"
                    + "\nChoose type: ");

                typeChoice = Console.ReadLine();

                if (typeChoice == "1" || typeChoice == "2" || typeChoice == "3" || typeChoice == "4" || typeChoice == "5")
                    break;

                Console.WriteLine("Invalid type choice. Please try again.");
            }

            Console.Write("Enter registration number: ");
            string reg = Console.ReadLine();
            Console.Write("Enter color: ");
            string color = Console.ReadLine();

            int wheels = 0;
            if (typeChoice != "5") // not a boat
                wheels = AskForInt("Enter number of wheels: ");

            Vehicle vehicle = null;
            switch (typeChoice)
            {
                case "1":
                    Console.Write("Enter fuel type: ");
                    string fuel = Console.ReadLine();
                    vehicle = new Car(reg, color, wheels, fuel);
                    break;
                case "2":
                    int engines = AskForInt("Enter number of engines: ");
                    vehicle = new Airplane(reg, color, wheels, engines);
                    break;
                case "3":
                    int cylinder = AskForInt("Enter cylinder volume: ");
                    vehicle = new Motorcycle(reg, color, wheels, cylinder);
                    break;
                case "4":
                    int seats = AskForInt("Enter number of seats: ");
                    vehicle = new Bus(reg, color, wheels, seats);
                    break;
                case "5":
                    double length;
                    while (true)
                    {
                        Console.Write("Enter length (m): ");
                        string input = Console.ReadLine();

                        if (double.TryParse(input, out length) && length > 0)
                            break;

                        Console.WriteLine("Invalid input. Please enter a positive number (e.g., 8.5).");
                    }

                    vehicle = new Boat(reg, color, length);
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    return;
            }
            string result = manager.AddVehicle(vehicle);
            Console.WriteLine(result);
        }

        private void ShowMainMenu()
        {
            Console.WriteLine("\nPlease navigate through the menu by inputting the number (1,2,3,4,0):"
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

        private int AskForInt(string prompt)
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
