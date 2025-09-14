using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories.Generic;

namespace LAB04_MuñozHerrera.Repositories;

public class DetallesOrdenRepository : Repository<Detallesorden>, IDetallesOrdenRepository
{
    public DetallesOrdenRepository(TiendadbContext context) : base(context)
    {
    }
}