using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories.Generic;

namespace LAB04_MuñozHerrera.Repositories;

public class OrdenRepository : Repository<Ordene>, IOrdenRepository
{
    public OrdenRepository(TiendadbContext context) : base(context)
    {
    }
}