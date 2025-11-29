namespace ProyectoCadeteria.Models;

public class ClienteModel
{
    public int? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }

    public ClienteModel(){}

    public ClienteModel(int? id, string? nombre, string? direccion, string? telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }
}