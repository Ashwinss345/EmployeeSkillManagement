namespace MyOrg.EmployeeSkillConsoleApp.Services;

using MyOrg.EmployeeSkillConsoleApp.Models;

public interface IEmployeeService
{
    void CreateEmployee(Employee employee);
    Employee? GetEmployee(int employeeId);
    IEnumerable<Employee> GetAllEmployees();
    bool UpdateEmployee(Employee employee);
    bool DeleteEmployee(int employeeId);
}
