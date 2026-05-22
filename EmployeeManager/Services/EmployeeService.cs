using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManager.Models;

namespace EmployeeManager.Services;

public class EmployeeService
{
    private readonly List<Employee> _employees = new();
    private int _nextId = 1;

    public int Count => _employees.Count;

    public IReadOnlyList<Employee> GetAll()
    {
        return _employees;
    }

    public Employee Add(string firstName, string lastName, string role, string email)
    {
        var employee = new Employee
        {
            Id = _nextId,
            FirstName = firstName,
            LastName = lastName,
            Role = role,
            Email = email
        };

        _employees.Add(employee);
        _nextId++;

        return employee;
    }

    public Employee? GetById(int id)
    {
        return _employees.FirstOrDefault(employee => employee.Id == id);
    }

    public IReadOnlyList<Employee> SearchByName(string searchTerm)
    {
        return _employees
            .Where(employee =>
                employee.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                employee.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}