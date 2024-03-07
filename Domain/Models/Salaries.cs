namespace Domain.Models;
public class Salaries
{
    public int SalaryId { get; set; }
    public int EmployeeId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Data { get; set; }
}