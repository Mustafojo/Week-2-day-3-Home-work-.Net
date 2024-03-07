using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeControllers : ControllerBase
{
    private readonly EmployeeService _empcontroller;
    public EmployeeControllers()
    {
        _empcontroller = new EmployeeService();
    }

    [HttpPost("Add Employee")]
    public void AddEmployees(Employees employees)
    {
        _empcontroller.AddEmployees(employees);
    }

    [HttpGet("Get Employees")]
    public List<Employees> GetEmployees()
    {
        return _empcontroller.GetEmployees();
    }

    [HttpPut("Update Employee")]
    public void UpdateEmployees(Employees employees)
    {
        _empcontroller.UpdateEmployees(employees);
    }

    [HttpDelete("Delete Employee")]
    public void DeleteEmployees(int id)
    {
        _empcontroller.DeleteEmployees(id);
    }

    [HttpGet("Get Employees By DepertmentId")]
    public List<Employees> GetEmployeesByDepartmentId(int id)
    {
        return _empcontroller.GetEmployeesByDepartmentId(id);
    }

    [HttpGet("Get Employee By Salaries ")]
    public List<AverageSalary> GetEmployeeBySalaries(decimal amount)
    {
        return _empcontroller.GetEmployeesBySalaries(amount);
    }

    [HttpGet("Get Average of Salaries ")]
    public List<AverageSalary> GetSalaryAverage()
    {
        return _empcontroller.GetSalaryAverage();
    }



}