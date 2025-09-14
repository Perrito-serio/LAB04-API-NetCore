using Microsoft.AspNetCore.Mvc;
using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories;

namespace LAB04_MuñozHerrera.Controllers;

[ApiController]
[Route("api/[controller]")] // Esto define la ruta base como -> /api/cliente
public class ClienteController : ControllerBase
{
    // El controlador solo conoce la abstracción IUnitOfWork, no los detalles de la BD.
    private readonly IUnitOfWork _unitOfWork;

    public ClienteController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: /api/cliente
    [HttpGet]
    public async Task<IActionResult> ObtenerClientes()
    {
        var clientes = await _unitOfWork.Clientes.GetAll();
        return Ok(clientes); // Devolvemos los datos en formato JSON
    }

    // POST: /api/cliente
    [HttpPost]
    public async Task<IActionResult> CrearCliente([FromBody] Cliente cliente)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _unitOfWork.Clientes.Add(cliente);
        await _unitOfWork.SaveChangesAsync(); // Guardamos todos los cambios en una transacción

        // Devolvemos una respuesta estándar de "Recurso Creado"
        return CreatedAtAction(nameof(ObtenerClientes), new { id = cliente.Clienteid }, cliente);
    }
}