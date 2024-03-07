using Npgsql;

namespace Infrastructure.DataContex;

public class DapperContext 
{
    private readonly string _connectionstring = 
    "Host=localhost;Port=5432;Database=EducationDb;User Id=postgres;Password=2007;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionstring);
    }
}
