namespace ProyectoCadeteria.Models;

public class PedidoModel
{
    public int? Id {get; set;}
    public string? Observacion {get; set;}
    public EstadosPosibles Estado {get; set;}
    // private readonly IClienteRepo _cliente;
    public int? ClienteId {get;set;}

    public PedidoModel(int? id, string? obs, EstadosPosibles estado, int? clienteId)
    {
        Id = id;
        Observacion = obs;
        Estado = estado;
        ClienteId = clienteId;
    }
}

public enum EstadosPosibles
{
    Pendiente = 1,
    Entregado = 2,
    Cancelado = 3
}