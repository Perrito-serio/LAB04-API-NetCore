using Microsoft.AspNetCore.Mvc;
using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories;

namespace LAB04_MuñozHerrera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
    {
        return Ok(await _unitOfWork.Productos.GetAll());
    }

    // GET: api/productos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        var producto = await _unitOfWork.Productos.GetById(id);
        if (producto == null)
        {
            return NotFound();
        }
        return producto;
    }

    // POST: api/productos
    [HttpPost]
    public async Task<ActionResult<Producto>> PostProducto(Producto producto)
    {
        await _unitOfWork.Productos.Add(producto);
        await _unitOfWork.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProducto), new { id = producto.Productoid }, producto);
    }

    // PUT: api/productos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int id, Producto producto)
    {
        if (id != producto.Productoid)
        {
            return BadRequest();
        }

        _unitOfWork.Productos.Update(producto);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/productos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        await _unitOfWork.Productos.Delete(id);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }
}