using Infrastructure.DataContex;
using Dapper;
using Domain.Models;
using Npgsql;
namespace Infrastructure.Services;

public class SalariesService
{
     private readonly DapperContext _contex;
    public SalariesService()
    {
        _contex = new DapperContext();
    }

     public List<Salaries> GetSalaries()
    {
        var sql = "select * from Salaries";
        var cat = _contex.Connection().Query<Salaries>(sql).ToList();
        return cat;
    }
    public void AddSalaries(Salaries salaries)
    {
        var sql = "insert into Salaries (employeeid,amount,data) values (@employeeid,@amount,@data)";
        _contex.Connection().Execute(sql , salaries);
    }

    public void UpdateSalary(Salaries salaries)
    {
        var sql = "update Salaries set employeeid = @employeeid,amount = @amount,data = @data where salaryid = @salaryid";
        _contex.Connection().Execute(sql, salaries);
    }
    
    public void DeleteSalary(int id)
    {
        var sql = "delete from Salaries where salaryid = @salaryid";
        _contex.Connection().Execute(sql, new {Id = id});
    }

    // public List<Salaries> (int id)
    // {
    //     var sql = @"select g.SalaryId,g.GroupName,s.Id
    //                 from StudentGroup as sg
    //                 join Students as s on s.Id = sg.StudentId
    //                 join Salaries as g on g.GroupId = sg.GroupId where s.Id = @id";
    //     var cat = _contex.Connection().Query<Salaries>(sql ,new { Id = id }).ToList();
    //     return cat;   
    // }

    

}
