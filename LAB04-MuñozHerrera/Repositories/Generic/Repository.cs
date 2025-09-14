using LAB04_MuñozHerrera.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB04_MuñozHerrera.Repositories.Generic;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly TiendadbContext _context;

    public Repository(TiendadbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await GetById(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}