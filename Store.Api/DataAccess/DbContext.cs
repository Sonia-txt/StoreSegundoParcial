using System.Data.Common;
using MySqlConnector;
using Store.Api.DataAccess.Interfaces;
namespace Store.Api.DataAccess;


public class DbContext : IDbContext
{
    private readonly string _connectionString=
        "server=localhost;user=root;password=1234;database=;port=3306";
    private MySqlConnection _connection;

    public DbConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new MySqlConnection(_connectionString);

            }

            return _connection;
        }
    }
}