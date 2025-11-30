using ProyectoCadeteria.Models;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;

namespace ProyectoCadeteria.Repositories;

public class CadeteriaRepository : ICadeteriaRepository
{
    private readonly string _stringConnection;
    public CadeteriaRepository(IOptions<DataBaseOptions> options)
    {
        _stringConnection = options.Value.stringConnection;
    }
    public SqliteConnection GetOpenConnection()
    {
        SqliteConnection connection = new SqliteConnection(_stringConnection);
        connection.Open();
        return connection;
    }
    public Cadeteria Get()
    {
        Cadeteria cadeteria = new Cadeteria();
        using var connection = GetOpenConnection();

        string stringQuery = "SELECT * FROM Cadeteria";
        SqliteCommand command = new SqliteCommand(stringQuery, connection);

        using(SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Cadeteria cadeteriaTemp= new Cadeteria(reader["Nombre"].ToString(), reader["Telefono"].ToString());
                cadeteria = cadeteriaTemp;
            }
        }
        connection.Close();
        return cadeteria;
    }

    public List<Cadete> GetCadetes()
    {
        List<Cadete> cadetes = new List<Cadete>();
        using SqliteConnection connection = GetOpenConnection();
        string stringQuery = "SELECT * FROM Cadetes";

        SqliteCommand command = new SqliteCommand(stringQuery, connection);

        using(SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                cadetes.Add(new Cadete(Convert.ToInt32(reader["Id"]), reader["Nombre"].ToString(), reader["Direccion"].ToString(), reader["Telefono"].ToString()));
            }
        }

        connection.Close();
        return cadetes;
    }
}