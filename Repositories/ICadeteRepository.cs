using Microsoft.Data.Sqlite;
using ProyectoCadeteria.Models;

namespace ProyectoCadeteria.Repositories;

public interface ICadeteRepository
{
    public SqliteConnection GetOpenConnection();
    public List<Pedido> GetPedidos(int IdCadete);
}