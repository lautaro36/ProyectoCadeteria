using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using ProyectoCadeteria.Models;

namespace ProyectoCadeteria.Repositories;

public class CadeteRepository : ICadeteRepository
{
    private readonly string? _stringConnection;

    public CadeteRepository(IOptions<DataBaseOptions> dbOptions)
    {
        _stringConnection = dbOptions.Value.stringConnection;
    }

    public SqliteConnection GetOpenConnection()
    {
        SqliteConnection connection = new SqliteConnection(_stringConnection);
        connection.Open();
        return connection;
    }

    public List<Pedido> GetPedidos()
    {
        List<Pedido> Pedidos = new List<Pedido>();

        using SqliteConnection connection = GetOpenConnection();
        string stringQuery = "SELECT pe.Id AS IdPedido, pe.Observacion AS Observacion, pe.Estado AS Estado, cl.Id AS IdCliente, cl.Nombre AS Nombre, cl.Direccion AS Direccion, cl.Telefono AS Telefono FROM Pedidos pe JOIN Clientes ON pe.IdCliente = cl.Id";
        SqliteCommand command = new SqliteCommand(stringQuery, connection);

        using(SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Cliente cliente = new Cliente(Convert.ToInt32(reader["IdCliente"]), reader["Nombre"].ToString(), reader["Direccion"].ToString(), reader["Telefono"].ToString());
                Enum.TryParse(reader["Estado"].ToString(), out EstadosPosibles estado);
                Pedidos.Add(new Pedido(Convert.ToInt32(reader["IdPedido"]), reader["Observacion"].ToString(), estado, cliente));
            }
        }

        connection.Close();
        return Pedidos;
    }
}