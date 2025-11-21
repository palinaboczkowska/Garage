using Garage.Vehicles;
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

        private void RemoveVehicle()
        {
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
            + "\n4. Find vehicle by registration number"
            + "\n0. Exit the application"
            + "\nYour choice: ");
        }

    }
}
