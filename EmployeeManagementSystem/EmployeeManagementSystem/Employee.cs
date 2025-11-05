using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Represents a standard Employee, inheriting from Person.
    /// Stores Position, Salary and implements DisplayInfo.
    /// </summary>
    class Employee : Person
    {
        public string Position { get; set; }
        public double Salary { get; set; }

        /// <summary>
        /// Displays information about the employee.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Position: {Position}, Salary: {Salary:C}, Email: {Contact.Email}, Phone: {Contact.Phone}");
        }
    }
}
