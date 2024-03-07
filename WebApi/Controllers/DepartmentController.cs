using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly DepartmentService _depcontroller;
    public DepartmentController()
    {
        _depcontroller = new DepartmentService();
    }
    [HttpPost("add - department")]
    public void AddDepartments(Departments departments)
    {
        _depcontroller.AddDepartments(departments);
    }
    [HttpGet("get-departments")]
    public List<Departments> GetDepartments()
    {
        return _depcontroller.GetDepartments();
    }
    [HttpPut("update-departments")]
    public void UpdateDepartments(Departments departments)
    {
        _depcontroller.UpdateDepartments(departments);
    }
    [HttpDelete("delete-department")]
    public void DeleteDepartments(int id)
    {
        _depcontroller.DeleteDepartments(id);
    }
  
}