using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories.Generic;

namespace LAB04_MuñozHerrera.Repositories;

public interface ICategoriaRepository : IRepository<Categoria>
{
    // Hereda todo de IRepository<T>.
}