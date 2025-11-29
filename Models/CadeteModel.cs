using ProyectoCadeteria.Models;

namespace ProyectoCadeteria.Controllers;

public class CadeteModel
{
    public int? Id {get; set;}
    public string? Nombre {get;set;}
    public string? Direccion {get;set;}
    public string? Telefono {get;set;}
    public List<PedidoModel> ListadoPedidos {get;set;} = new List<PedidoModel>();

    public CadeteModel(){}

    public CadeteModel(int? id, string? nombre, string? direccion, string? telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }

}