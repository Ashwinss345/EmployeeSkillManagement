namespace MyOrg.EmployeeSkillConsoleApp.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public required string Name { get; set; }
    public List<EmployeeSkill> Skills { get; set; } = new();
}
