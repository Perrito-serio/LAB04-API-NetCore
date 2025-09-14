using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories.Generic;

namespace LAB04_MuñozHerrera.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(TiendadbContext context) : base(context)
    {
    }
}