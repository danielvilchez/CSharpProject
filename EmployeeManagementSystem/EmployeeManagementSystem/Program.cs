using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmployeeManagementSystem
{
    internal class Program
    {
        static List<Employee> employees = new List<Employee>();
        static string filePath = "employees.txt";

        static void Main(string[] args)
        {
            LoadFromFile(); // Load existing employees from file

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Employee Management System ---");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display All Employees");
                Console.WriteLine("3. Save and Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee();
                        break;
                    case "2":
                        DisplayEmployees();
                        break;
                    case "3":
                        SaveToFile();
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        /// <summary>
        /// Adds a new Employee or Manager to the system.
        /// Prompts user input and creates the corresponding object.
        /// </summary>
        static void AddEmployee()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            int age;
            while (true)
            {
                Console.Write("Enter age: ");
                if (int.TryParse(Console.ReadLine(), out age)) break;
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            Console.Write("Enter position (Employee/Manager): ");
            string position = Console.ReadLine();

            double salary;
            while (true)
            {
                Console.Write("Enter salary: ");
                if (double.TryParse(Console.ReadLine(), out salary)) break;
                Console.WriteLine("Invalid input. Please enter a valid salary.");
            }

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter phone: ");
            string phone = Console.ReadLine();

            ContactInfo contact = new ContactInfo { Email = email, Phone = phone };

            if (position.ToLower() == "manager")
            {
                int teamSize;
                while (true)
                {
                    Console.Write("Enter team size: ");
                    if (int.TryParse(Console.ReadLine(), out teamSize)) break;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Manager manager = new Manager
                {
                    Name = name,
                    Age = age,
                    Position = position,
                    Salary = salary,
                    Contact = contact,
                    TeamSize = teamSize
                };
                employees.Add(manager);
            }
            else
            {
                Employee employee = new Employee
                {
                    Name = name,
                    Age = age,
                    Position = position,
                    Salary = salary,
                    Contact = contact
                };
                employees.Add(employee);
            }

            Console.WriteLine("Employee added successfully!");
        }

        /// <summary>
        /// Displays all employees and managers in the system.
        /// </summary>
        static void DisplayEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine("\n--- Employee List ---");
            foreach (var emp in employees)
            {
                emp.DisplayInfo();
                Console.WriteLine("----------------------");
            }
        }

        /// <summary>
        /// Saves all employee data to a text file.
        /// Format: Name|Age|Position|Salary|Email|Phone|TeamSize (if manager)
        /// </summary>
        static void SaveToFile()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var emp in employees)
                {
                    writer.WriteLine($"{emp.Name}|{emp.Age}|{emp.Position}|{emp.Salary}|{emp.Contact.Email}|{emp.Contact.Phone}" + (emp is Manager m ? $"|{m.TeamSize}" : ""));
                }
            }
            Console.WriteLine("Employees saved to file!");
        }

        /// <summary>
        /// Loads employee data from a text file into the system.
        /// </summary>
        static void LoadFromFile()
        {
            if (!File.Exists(filePath))
                return;

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length < 6) continue;

                string name = parts[0];
                int age = int.Parse(parts[1]);
                string position = parts[2];
                double salary = double.Parse(parts[3]);
                string email = parts[4];
                string phone = parts[5];

                ContactInfo contact = new ContactInfo { Email = email, Phone = phone };

                if (position.ToLower() == "manager" && parts.Length == 7)
                {
                    int teamSize = int.Parse(parts[6]);
                    Manager manager = new Manager
                    {
                        Name = name,
                        Age = age,
                        Position = position,
                        Salary = salary,
                        Contact = contact,
                        TeamSize = teamSize
                    };
                    employees.Add(manager);
                }
                else
                {
                    Employee employee = new Employee
                    {
                        Name = name,
                        Age = age,
                        Position = position,
                        Salary = salary,
                        Contact = contact
                    };
                    employees.Add(employee);
                }
            }
        }
    }
}
