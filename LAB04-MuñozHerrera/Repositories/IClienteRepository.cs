using LAB04_MuñozHerrera.Models;

namespace LAB04_MuñozHerrera.Repositories;

public interface IClienteRepository
{
    // Obtener un cliente por su ID
    Task<Cliente?> GetById(int id);
    
    // Obtener todos los clientes
    Task<IEnumerable<Cliente>> GetAll();
    
    // Agregar un nuevo cliente
    Task Add(Cliente cliente);
    
    // Actualizar un cliente existente
    void Update(Cliente cliente);
    
    // Eliminar un cliente por su ID
    Task Delete(int id);
}