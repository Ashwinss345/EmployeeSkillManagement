using Microsoft.Extensions.DependencyInjection;
using MyOrg.EmployeeSkillConsoleApp.Repositories;
using MyOrg.EmployeeSkillConsoleApp.Services;
using MyOrg.EmployeeSkillConsoleApp.UI;

// Setup dependency injection
var services = new ServiceCollection();
services.AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();
services.AddSingleton<IEmployeeService, EmployeeService>();
services.AddSingleton<ConsoleUI>();

// Build service provider
var provider = services.BuildServiceProvider();

// Get UI and run application
var ui = provider.GetRequiredService<ConsoleUI>();
ui.Run();
