using LAB04_MuñozHerrera.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB04_MuñozHerrera.Repositories;

public class ClienteRepository : IClienteRepository
{
    // Usamos el DbContext que generó Scaffold
    private readonly TiendadbContext _context;

    public ClienteRepository(TiendadbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> GetAll()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente?> GetById(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task Add(Cliente cliente)
    {
        await _context.Clientes.AddAsync(cliente);
    }
    
    public void Update(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
    }

    public async Task Delete(int id)
    {
        var cliente = await GetById(id);
        if (cliente != null)
        {
            _context.Clientes.Remove(cliente);
        }
    }
}