using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Represents a Manager, inheriting from Employee.
    /// Adds a TeamSize property.
    /// </summary>
    class Manager : Employee
    {
        public int TeamSize { get; set; }

        /// <summary>
        /// Displays information about the manager, including team size.
        /// </summary>
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Manages a team of {TeamSize} employees.");
        }
    }
}
