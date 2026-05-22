using EmployeeManager.Models;
using EmployeeManager.Services;

EmployeeService employeeService = new();
bool isRunning = true;

while (isRunning)
{
    Console.Clear();

    PrintHeader(employeeService.Count);
    PrintMenu();

    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();

    Console.WriteLine();

    switch (choice)
    {
        case "1":
            ListEmployees();
            break;

        case "2":
            AddEmployee();
            break;

        case "3":
            SearchEmployee();
            break;

        case "4":
            ShowComingSoon("Update employee");
            break;

        case "5":
            ShowComingSoon("Delete employee");
            break;

        case "0":
            isRunning = false;
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid option. Choose a number from the menu.");
            Pause();
            break;
    }
}

void PrintHeader(int employeeCount)
{
    Console.WriteLine("EmployeeManager");
    Console.WriteLine("----------------");
    Console.WriteLine($"Saved employees: {employeeCount}");
    Console.WriteLine();
}

void PrintMenu()
{
    Console.WriteLine("1. List employees");
    Console.WriteLine("2. Add employee");
    Console.WriteLine("3. Search employee");
    Console.WriteLine("4. Update employee");
    Console.WriteLine("5. Delete employee");
    Console.WriteLine("0. Exit");
    Console.WriteLine();
}

void AddEmployee()
{
    Console.WriteLine("Add employee");
    Console.WriteLine("------------");

    Console.Write("First name: ");
    string firstName = ReadRequiredInput();

    Console.Write("Last name: ");
    string lastName = ReadRequiredInput();

    Console.Write("Role: ");
    string role = ReadRequiredInput();

    Console.Write("Email: ");
    string email = ReadRequiredInput();

    Employee employee = employeeService.Add(firstName, lastName, role, email);

    Console.WriteLine();
    Console.WriteLine($"Employee created: {employee.Id} - {employee.FullName}");
    Pause();
}

void ListEmployees()
{
    Console.WriteLine("Employees");
    Console.WriteLine("---------");

    IReadOnlyList<Employee> employees = employeeService.GetAll();

    if (employees.Count == 0)
    {
        Console.WriteLine("No employees have been added yet.");
        Pause();
        return;
    }

    foreach (Employee employee in employees)
    {
        PrintEmployee(employee);
    }

    Pause();
}

void SearchEmployee()
{
    Console.WriteLine("Search employee");
    Console.WriteLine("---------------");
    Console.WriteLine("1. Search by id");
    Console.WriteLine("2. Search by name");
    Console.WriteLine();

    Console.Write("Choose search type: ");
    string? choice = Console.ReadLine();

    Console.WriteLine();

    switch (choice)
    {
        case "1":
            SearchEmployeeById();
            break;

        case "2":
            SearchEmployeeByName();
            break;

        default:
            Console.WriteLine("Invalid search option.");
            Pause();
            break;
    }
}

void SearchEmployeeById()
{
    Console.Write("Employee id: ");
    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int id))
    {
        Console.WriteLine("Invalid id. Please enter a number.");
        Pause();
        return;
    }

    Employee? employee = employeeService.GetById(id);

    if (employee is null)
    {
        Console.WriteLine("No employee was found with that id.");
        Pause();
        return;
    }

    PrintEmployee(employee);
    Pause();
}

void SearchEmployeeByName()
{
    Console.Write("Name: ");
    string searchTerm = ReadRequiredInput();

    IReadOnlyList<Employee> employees = employeeService.SearchByName(searchTerm);

    if (employees.Count == 0)
    {
        Console.WriteLine("No employees matched the search.");
        Pause();
        return;
    }

    foreach (Employee employee in employees)
    {
        PrintEmployee(employee);
    }

    Pause();
}

void PrintEmployee(Employee employee)
{
    Console.WriteLine($"{employee.Id}. {employee.FullName} - {employee.Role} - {employee.Email}");
}

string ReadRequiredInput()
{
    while (true)
    {
        string? input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            return input.Trim();
        }

        Console.Write("Value cannot be empty. Try again: ");
    }
}

void ShowComingSoon(string featureName)
{
    Console.WriteLine($"{featureName} will be implemented in a later issue.");
    Pause();
}

void Pause()
{
    Console.WriteLine();
    Console.WriteLine("Press Enter to continue...");
    Console.ReadLine();
}