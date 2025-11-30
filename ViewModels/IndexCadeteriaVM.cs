using ProyectoCadeteria.Models;

namespace ProyectoCadeteria.ViewModels;

public class IndexCadeteriaVM
{
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }

    public IndexCadeteriaVM(){}

    public IndexCadeteriaVM(Cadeteria cadeteria)
    {
        Nombre = cadeteria.Nombre;
        Telefono = cadeteria.Telefono;
    }
    
}