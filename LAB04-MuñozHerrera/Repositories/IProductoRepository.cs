using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories.Generic;

namespace LAB04_MuñozHerrera.Repositories;

public interface IProductoRepository : IRepository<Producto>
{
    // Por ahora la dejamos vacía. Hereda todo de IRepository<T>.
}