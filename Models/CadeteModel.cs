
namespace ProyectoCadeteria.Models;

public class Cadete
{
    public int? Id {get; set;}
    public string? Nombre {get;set;}
    public string? Direccion {get;set;}
    public string? Telefono {get;set;}
    public List<Pedido> ListadoPedidos {get;set;} = new List<Pedido>();

    public Cadete(){}

    public Cadete(int? id, string? nombre, string? direccion, string? telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }

    public void GetPedidos(List<Pedido> pedidos)
    {
        ListadoPedidos = pedidos;
    }

}