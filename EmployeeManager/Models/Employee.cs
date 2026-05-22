using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";
    }
}
