namespace MyOrg.EmployeeSkillConsoleApp.Repositories;

using MyOrg.EmployeeSkillConsoleApp.Models;

public interface IEmployeeRepository
{
    void AddEmployee(Employee employee);
    IEnumerable<Employee> GetAllEmployees();
    Employee? GetEmployeeById(int id);
    bool UpdateEmployee(Employee updatedEmployee);
    bool DeleteEmployee(int id);
}
