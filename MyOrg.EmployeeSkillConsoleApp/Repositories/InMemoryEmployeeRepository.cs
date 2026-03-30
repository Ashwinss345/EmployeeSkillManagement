namespace MyOrg.EmployeeSkillConsoleApp.Repositories;

using MyOrg.EmployeeSkillConsoleApp.Models;

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
        if (existing == null)
            return false;

        existing.Name = updatedEmployee.Name;
        existing.Skills = updatedEmployee.Skills;
        return true;
    }

    public bool DeleteEmployee(int id)
    {
        var employee = GetEmployeeById(id);
        if (employee == null)
            return false;

        _employees.Remove(employee);
        return true;
    }
}
