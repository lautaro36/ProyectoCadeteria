using Microsoft.Data.Sqlite;
using ProyectoCadeteria.Models;

namespace ProyectoCadeteria.Repositories;

public interface ICadeteriaRepository
{
    public SqliteConnection GetOpenConnection();
    public Cadeteria Get(); 
    public List<Cadete> GetCadetes();
}