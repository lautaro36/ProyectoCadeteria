namespace ProyectoCadeteria.Models;

public class Cadeteria
{
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public List<Cadete> ListadoCadetes { get; private set; } = new List<Cadete>();

    public Cadeteria() { }
    public Cadeteria(string? nombre, string? telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }

    public void GetPedidos(List<Cadete> listadoCadetes)
    {
        ListadoCadetes = listadoCadetes;
    }
}