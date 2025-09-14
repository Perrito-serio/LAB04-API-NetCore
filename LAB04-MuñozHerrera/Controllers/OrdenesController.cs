using Microsoft.AspNetCore.Mvc;
using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories;

namespace LAB04_MuñozHerrera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdenesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/ordenes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ordene>>> GetOrdenes()
    {
        return Ok(await _unitOfWork.Ordenes.GetAll());
    }

    // GET: api/ordenes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Ordene>> GetOrden(int id)
    {
        var orden = await _unitOfWork.Ordenes.GetById(id);
        if (orden == null)
        {
            return NotFound();
        }
        return orden;
    }

    // POST: api/ordenes
    [HttpPost]
    public async Task<ActionResult<Ordene>> PostOrden(Ordene orden)
    {
        await _unitOfWork.Ordenes.Add(orden);
        await _unitOfWork.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrden), new { id = orden.Ordenid }, orden);
    }
}