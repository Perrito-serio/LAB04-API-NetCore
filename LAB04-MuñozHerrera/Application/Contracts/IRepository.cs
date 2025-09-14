namespace LAB04_MuñozHerrera.Repositories.Generic;

// La T representa un tipo genérico (puede ser Cliente, Producto, etc.)
// "where T : class" es una restricción que asegura que T siempre sea una clase.
public interface IRepository<T> where T : class
{
    // Obtiene una entidad por su ID
    Task<T?> GetById(int id);
    
    // Obtiene todas las entidades
    Task<IEnumerable<T>> GetAll();
    
    // Agrega una nueva entidad
    Task Add(T entity);
    
    // Actualiza una entidad existente
    void Update(T entity);
    
    // Elimina una entidad por su ID
    Task Delete(int id);
}