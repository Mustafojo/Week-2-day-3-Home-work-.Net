using Dapper;
using Domain.Models;
using Infrastructure.DataContex;

namespace Infrastructure.Services;

public class EmployeeService
{
    private readonly DapperContext _contex;
    public EmployeeService()
    {
        _contex = new DapperContext();
    }

     public List<Employees> GetEmployees()
    {
        var sql = "select * from Employees";
        var cat = _contex.Connection().Query<Employees>(sql).ToList();
        return cat;
    }
    public void AddEmployees(Employees employees)
    {
        var sql = "insert into Employees (firstname,lastname,departmentid,position,hiredate) values (@firstname,@lastname,@departmentid,@position,@hiredate)";
        _contex.Connection().Execute(sql , employees);
    }

    public void UpdateEmployees(Employees employees)
    {
        var sql = "update Employees set firstname = @firstname,lastname = @lastname,departmentid = @departmentid,position = @position,hiredate = @hiredate where id = @id";
        _contex.Connection().Execute(sql, employees);
    }
    
    public void DeleteEmployees(int id)
    {
        var sql = "delete from Employees where id = @id";
        _contex.Connection().Execute(sql,new { Id = id});
    }
    
    public List<Employees> GetEmployeesByDepartmentId(int id)
    {
        var sql = @"select e.Id,e.FirstName,e.LastName,e.Position,e.HireDate,e.DepartmentId
                    from Employees as e
                    join Departments as d on d.DepartmentId = e.DepartmentId
                    where e.departmentid = @id";
        var result = _contex.Connection().Query<Employees>(sql , new { Id = id }).ToList();
        return result;
    }

    public List<AverageSalary> GetSalaryAverage()
    {
        var sql = @"select d.DepartmentName,e.Id ,e.FirstName,e.LastName,Avg(s.Amount) as Amount
                    from Departments as d
                    join Employees as e on  d.DepartmentId = e.DepartmentId 
                    join Salaries as s on  e.Id = s.EmployeeId
                    group by d.DepartmentName,e.Id,e.FirstName,e.LastName";
        var result = _contex.Connection().Query<AverageSalary>(sql).ToList();
        return result; 
    }

    public List<AverageSalary> GetEmployeesBySalaries(decimal amount)
    {
        var sql = @"select e.Id,e.FirstName,e.LastName,s.Amount
                    from Employees as e
                    join Salaries as s on s.EmployeeId = e.Id
                    where s.Amount > @amount
                    order by s.Amount";
        var result = _contex.Connection().Query<AverageSalary>(sql , new { Amount = amount }).ToList();
        return result;         
    }

    
}
