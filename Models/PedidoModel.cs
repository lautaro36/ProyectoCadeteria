namespace ProyectoCadeteria.Models;

public class Pedido
{//suele no ponerse Model en los models, por convencion
    public int? Id { get; set; }
    public string? Observacion { get; set; }
    public EstadosPosibles Estado { get; set; }
    public Cliente? Cliente { get; set; }
    public int? IdCadete { get; set; }
    public Pedido() { }

    public Pedido(int? id, string? obs, EstadosPosibles estado, Cliente cliente, int? idCadete)
    {
        Id = id;
        Observacion = obs;
        Estado = estado;
        Cliente = cliente;
        IdCadete = idCadete;
    }
}

public enum EstadosPosibles
{
    Pendiente = 1,
    Entregado = 2,
    Cancelado = 3
}