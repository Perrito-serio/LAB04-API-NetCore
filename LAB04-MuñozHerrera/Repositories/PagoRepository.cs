using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories.Generic;

namespace LAB04_MuñozHerrera.Repositories;

public class PagoRepository : Repository<Pago>, IPagoRepository
{
    public PagoRepository(TiendadbContext context) : base(context)
    {
    }
}