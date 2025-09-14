using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories.Generic;

namespace LAB04_MuñozHerrera.Repositories;

public class ProductoRepository : Repository<Producto>, IProductoRepository
{
    public ProductoRepository(TiendadbContext context) : base(context)
    {
    }
}