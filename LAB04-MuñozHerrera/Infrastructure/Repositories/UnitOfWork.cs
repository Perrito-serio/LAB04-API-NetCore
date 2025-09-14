using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories.Generic; // Importamos la carpeta del Repositorio Genérico

namespace LAB04_MuñozHerrera.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TiendadbContext _context;

    // Propiedades para cada uno de los repositorios
    public IClienteRepository Clientes { get; private set; }
    public IProductoRepository Productos { get; private set; }
    public ICategoriaRepository Categorias { get; private set; }
    public IOrdenRepository Ordenes { get; private set; }
    public IDetallesOrdenRepository DetallesOrden { get; private set; }
    public IPagoRepository Pagos { get; private set; }

    public UnitOfWork(TiendadbContext context)
    {
        _context = context;
        
        Clientes = new ClienteRepository(_context);
        Productos = new ProductoRepository(_context);
        Categorias = new CategoriaRepository(_context);
        Ordenes = new OrdenRepository(_context);
        DetallesOrden = new DetallesOrdenRepository(_context);
        Pagos = new PagoRepository(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}