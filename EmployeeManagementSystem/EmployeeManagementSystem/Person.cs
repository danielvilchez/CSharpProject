using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    /// <summary>
    /// Abstract base class for all people in the system.
    /// Defines Name, Age, Contact and abstract DisplayInfo method.
    /// </summary>
    abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ContactInfo Contact { get; set; }

        /// <summary>
        /// Abstract method to display information about the person.
        /// Must be implemented by derived classes.
        /// </summary>
        public abstract void DisplayInfo();
    }
}