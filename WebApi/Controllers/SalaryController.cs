using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class SalaryController : ControllerBase
{
    private readonly SalariesService _salcontroller;
    public SalaryController()
    {
        _salcontroller = new SalariesService();
    }
    [HttpPost("add - salary")]
    public void AddSalary(Salaries salaries)
    {
        _salcontroller.AddSalaries(salaries);
    }
    [HttpGet("get-salaries")]
    public List<Salaries> GetSalaries()
    {
        return _salcontroller.GetSalaries();
    }
    
    [HttpPut("update-salari")]
    public void UpdateSalary(Salaries salaries)
    {
        _salcontroller.UpdateSalary(salaries);
    }
    [HttpDelete("delete-salari")]
    public void DeleteSalary(int id)
    {
        _salcontroller.DeleteSalary(id);
    }
  
}