using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManager.Models;

namespace EmployeeManager.Services;

public class EmployeeService
{
    private readonly List<Employee> _employees = [];
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
}