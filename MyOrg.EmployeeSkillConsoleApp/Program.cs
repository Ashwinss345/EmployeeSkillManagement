using System;
using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Welcome to Employee Skill Console App!");


Skill skillcsharp = new() { SkillId = 100, SkillName = "C#" };
Skill skilljs = new() { SkillId = 100, SkillName = "JavaScript" };

Employee employee = new Employee { EmployeeId = 123, Name = "Ashwin", 
    Skills = new List<EmployeeSkill> {
        new EmployeeSkill {Skill = skillcsharp, ProficiencyLevel = "Master"},
        new EmployeeSkill {Skill = skilljs, ProficiencyLevel = "Advanced"},
    }
};

IEmployeeRepository repo = new InMemoryEmployeeRepository();

repo.AddEmployee(employee);


var storedEmployee = repo.GetEmployeeById(123);
Console.WriteLine($"Employee: {storedEmployee.Name}");


foreach (var es in storedEmployee?.Skills ?? new List<EmployeeSkill>())
{
    Console.WriteLine($" - Skill: {es.Skill.SkillName}, Level: {es.ProficiencyLevel}");
}

// UPDATE
employee.Name = "Nilan Ashwin";
repo.UpdateEmployee(employee);

// READ by ID
var updated = repo.GetEmployeeById(123);
Console.WriteLine($"Updated Employee: {updated?.Name}");

// DELETE
repo.DeleteEmployee(123);
Console.WriteLine($"Remaining Employees: {repo.GetAllEmployees().Count()}");

Console.ReadLine();
public class Employee
{
    public int EmployeeId { get; set; }
    public required string Name { get; set; }

    public List<EmployeeSkill> Skills { get; set; } = new();
}

public class Skill
{
    public int SkillId { get; set; }
    public string? SkillName { get; set; }

    
}

public class EmployeeSkill
{
    public Skill? Skill { get; set; }
    public string ProficiencyLevel { get; set; }

}

//in-memory repository

public interface IEmployeeRepository
{
    void AddEmployee(Employee employee);              // CREATE
    IEnumerable<Employee> GetAllEmployees();          // READ all
    Employee? GetEmployeeById(int id);                // READ by ID
    bool UpdateEmployee(Employee updatedEmployee);    // UPDATE
    bool DeleteEmployee(int id);                      // DELETE
}

public class InMemoryEmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new();

    public void AddEmployee(Employee employee)
    {
        _employees.Add(employee);
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        return _employees;
    }

    public Employee? GetEmployeeById(int id)
    {
        return _employees.FirstOrDefault(e => e.EmployeeId == id);
    }

    public bool UpdateEmployee(Employee updatedEmployee)
    {
        var existing = GetEmployeeById(updatedEmployee.EmployeeId);
        if (existing == null) return false;

        existing.Name = updatedEmployee.Name;
        existing.Skills = updatedEmployee.Skills;
        return true;
    }

    public bool DeleteEmployee(int id)
    {
        var employee = GetEmployeeById(id);
        if (employee == null) return false;

        _employees.Remove(employee);
        return true;
    }
}




