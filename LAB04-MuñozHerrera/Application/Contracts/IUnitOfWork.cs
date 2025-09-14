namespace LAB04_MuñozHerrera.Repositories;

public interface IUnitOfWork : IDisposable
{
    IClienteRepository Clientes { get; }
    IProductoRepository Productos { get; }
    ICategoriaRepository Categorias { get; }
    IOrdenRepository Ordenes { get; }
    IDetallesOrdenRepository DetallesOrden { get; }
    IPagoRepository Pagos { get; }
    
    // Dejamos solo la versión asíncrona, que es la buena práctica
    Task<int> SaveChangesAsync();
}