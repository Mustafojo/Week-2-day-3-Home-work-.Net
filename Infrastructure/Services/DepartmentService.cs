using Domain.Models;
using Dapper;
using Npgsql;
using Infrastructure.DataContex;
using System.Security.Cryptography.X509Certificates;
namespace Infrastructure.Services;

public class DepartmentService
{
     private readonly DapperContext _contex;
    public DepartmentService()
    {
        _contex = new DapperContext();
    }

     public List<Departments> GetDepartments()
    {
        var sql = "select * from Departments";
        var cat = _contex.Connection().Query<Departments>(sql).ToList();
        return cat;
    }
    public void AddDepartments(Departments departments)
    {
        var sql = "insert into Departments (departmentname) values (@departmentname)";
        _contex.Connection().Execute(sql , departments);
    }

    public void UpdateDepartments (Departments departments)
    {
        var sql = "update Departments set departmentname = @departmentname where departmentid = @departmentid";
        _contex.Connection().Execute(sql , departments);
    }
    
    public void DeleteDepartments(int id)
    {
        var sql = "delete from Departments where departmentid = @departmentid";
        _contex.Connection().Execute(sql, new {Id = id});
    }
}
