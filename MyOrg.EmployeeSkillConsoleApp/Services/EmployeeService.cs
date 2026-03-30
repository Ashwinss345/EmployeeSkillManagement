namespace MyOrg.EmployeeSkillConsoleApp.Services;

using MyOrg.EmployeeSkillConsoleApp.Models;
using MyOrg.EmployeeSkillConsoleApp.Repositories;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public void CreateEmployee(Employee employee)
    {
        _employeeRepository.AddEmployee(employee);
    }

    public Employee? GetEmployee(int employeeId)
    {
        return _employeeRepository.GetEmployeeById(employeeId);
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        return _employeeRepository.GetAllEmployees();
    }

    public bool UpdateEmployee(Employee employee)
    {
        return _employeeRepository.UpdateEmployee(employee);
    }

    public bool DeleteEmployee(int employeeId)
    {
        return _employeeRepository.DeleteEmployee(employeeId);
    }
}
