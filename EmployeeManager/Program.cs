using EmployeeManager.Models;

List<Employee> employees = new();
bool isRunning = true;

while (isRunning)
{
    Console.Clear();

    PrintHeader(employees.Count);
    PrintMenu();

    Console.Write("Choose an option: ");
    string? choice = Console.ReadLine();

    Console.WriteLine();

    switch (choice)
    {
        case "1":
            ShowComingSoon("List employees");
            break;

        case "2":
            ShowComingSoon("Add employee");
            break;

        case "3":
            ShowComingSoon("Search employee");
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