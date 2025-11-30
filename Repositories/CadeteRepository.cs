using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using ProyectoCadeteria.Models;
using ProyectoCadeteria.Options;

namespace ProyectoCadeteria.Repositories;

public class CadeteRepository : ICadeteRepository
{
    private readonly string? _stringConnection;

    public CadeteRepository(IOptions<DatabaseOptions> dbOptions)
    {
        _stringConnection = dbOptions.Value.StringConnection;
    }

    public SqliteConnection GetOpenConnection()
    {
        SqliteConnection connection = new SqliteConnection(_stringConnection);
        connection.Open();
        return connection;
    }

    public List<Pedido> GetPedidos(int IdCadete)
    {
        List<Pedido> Pedidos = new List<Pedido>();

        using SqliteConnection connection = GetOpenConnection();
        string stringQuery = @"
        SELECT 
            pe.Id AS IdPedido,
            pe.Observacion AS Observacion,
            pe.Estado AS Estado,
            pe.IdCadete AS IdCadete,
            cl.Id AS IdCliente,
            cl.Nombre AS Nombre,
            cl.Direccion AS Direccion,
            cl.Telefono AS Telefono
        FROM Pedidos pe
        INNER JOIN Clientes cl ON pe.Id = cl.IdPedido
        WHERE pe.IdCadete = @IdCadete";
        
        SqliteCommand command = new SqliteCommand(stringQuery, connection);
        command.Parameters.Add(new SqliteParameter("@IdCadete", IdCadete)); 

        using(SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Cliente cliente = new Cliente(Convert.ToInt32(reader["IdCliente"]), reader["Nombre"].ToString(), reader["Direccion"].ToString(), reader["Telefono"].ToString(), Convert.ToInt32(reader["IdPedido"]));

                Enum.TryParse(reader["Estado"].ToString(), out EstadosPosibles estado);

                Pedidos.Add(new Pedido(Convert.ToInt32(reader["IdPedido"]), reader["Observacion"].ToString(), estado, cliente, Convert.ToInt32(reader["IdCadete"])));
            }
        }

        return Pedidos;
    }
}