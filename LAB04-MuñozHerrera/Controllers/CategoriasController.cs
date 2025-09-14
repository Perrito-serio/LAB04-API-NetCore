using Microsoft.AspNetCore.Mvc;
using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories;

namespace LAB04_MuñozHerrera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoriasController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/categorias
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
    {
        return Ok(await _unitOfWork.Categorias.GetAll());
    }

    // POST: api/categorias
    [HttpPost]
    public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
    {
        await _unitOfWork.Categorias.Add(categoria);
        await _unitOfWork.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCategorias), new { id = categoria.Categoriaid }, categoria);
    }
}