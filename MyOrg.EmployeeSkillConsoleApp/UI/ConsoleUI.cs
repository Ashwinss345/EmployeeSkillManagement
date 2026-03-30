namespace MyOrg.EmployeeSkillConsoleApp.UI;

using MyOrg.EmployeeSkillConsoleApp.Models;
using MyOrg.EmployeeSkillConsoleApp.Services;

public class ConsoleUI
{
    private readonly IEmployeeService _employeeService;

    public ConsoleUI(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public void Run()
    {
        Console.WriteLine("Hello, Welcome to Employee Skill Console App!\n");

        // Initialize skills
        var csharpSkill = new Skill { SkillId = 100, SkillName = "C#" };
        var javascriptSkill = new Skill { SkillId = 101, SkillName = "JavaScript" };

        // Create employee with skills
        var employee = new Employee
        {
            EmployeeId = 123,
            Name = "Ashwin",
            Skills = new List<EmployeeSkill>
            {
                new EmployeeSkill { Skill = csharpSkill, ProficiencyLevel = "Master" },
                new EmployeeSkill { Skill = javascriptSkill, ProficiencyLevel = "Advanced" },
            }
        };

        // CREATE: Add employee
        _employeeService.CreateEmployee(employee);

        // READ: Display initial employee
        var storedEmployee = _employeeService.GetEmployee(123);
        DisplayEmployee(storedEmployee);

        // UPDATE: Modify and update employee
        employee.Name = "Nilan Ashwin";
        _employeeService.UpdateEmployee(employee);

        // READ: Display updated employee
        var updatedEmployee = _employeeService.GetEmployee(123);
        Console.WriteLine("\nAfter Update:");
        DisplayEmployee(updatedEmployee);

        // DELETE: Remove employee
        _employeeService.DeleteEmployee(123);
        Console.WriteLine($"\nRemaining Employees: {_employeeService.GetAllEmployees().Count()}");

        Console.ReadLine();
    }

    private static void DisplayEmployee(Employee? employee)
    {
        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        Console.WriteLine($"Employee: {employee.Name}");
        foreach (var employeeSkill in employee.Skills)
        {
            Console.WriteLine($" - Skill: {employeeSkill.Skill?.SkillName}, Level: {employeeSkill.ProficiencyLevel}");
        }
    }
}
