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
                manager = new Manager(10);
                SeedData(manager);
            }
            else {
                Console.Write("Enter garage capacity: ");
            int capacity = int.Parse(Console.ReadLine());
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
            Console.WriteLine("\n--- Add Vehicle ---"
            + "\n1. Car"
            + "\n2. Airplane"
            + "\n3. Motorcycle"
            + "\n4. Bus"
            + "\n5. Boat"
            + "\nChoose type: ");

            string typeChoice = Console.ReadLine();

            Console.Write("Enter registration number: ");
            string reg = Console.ReadLine();
            Console.Write("Enter color: ");
            string color = Console.ReadLine();

            int wheels = 0;
            if (typeChoice != "5") //not a boat
            { 
                Console.Write("Enter number of wheels: ");
                wheels = int.Parse(Console.ReadLine());
            }

            Vehicle vehicle = null;
            switch (typeChoice)
            {
                case "1":
                    Console.Write("Enter fuel type: ");
                    string fuel = Console.ReadLine();
                    vehicle = new Car(reg, color, wheels, fuel);
                    break;
                case "2":
                    Console.Write("Enter number of engines: ");
                    int engines = int.Parse(Console.ReadLine());
                    vehicle = new Airplane(reg, color, wheels, engines);
                    break;
                case "3":
                    Console.Write("Enter cylinder volume: ");
                    int cylinder = int.Parse(Console.ReadLine());
                    vehicle = new Motorcycle(reg, color, wheels, cylinder);
                    break;
                case "4":
                    Console.Write("Enter number of seats: ");
                    int seats = int.Parse(Console.ReadLine());
                    vehicle = new Bus(reg, color, wheels, seats);
                    break;
                case "5":
                    Console.Write("Enter length (m): ");
                    double length = double.Parse(Console.ReadLine());
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

    }
}
