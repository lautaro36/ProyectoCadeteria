namespace ProyectoCadeteria.Models;

public class Cliente
{
    public int? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
    public int? IdPedido { get; set; }
    public Cliente() { }

    public Cliente(int? id, string? nombre, string? direccion, string? telefono, int? idPedido)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        IdPedido = idPedido;
    }
}