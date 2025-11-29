using ProyectoCadeteria.Controllers;

namespace ProyectoCadeteria.Models;

public class CadeteriaModel
{
    public string? Nombre {get;set;}
    public string? Telefono {get;set;}
    public List<CadeteModel> ListadoCadetes {get; private set;} = new List<CadeteModel>();

    public CadeteriaModel(string? nombre, string? telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }
}