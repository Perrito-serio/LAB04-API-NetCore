using Microsoft.AspNetCore.Mvc;
using LAB04_MuñozHerrera.Models;
using LAB04_MuñozHerrera.Repositories;

namespace LAB04_MuñozHerrera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public PagosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: api/pagos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pago>>> GetPagos()
    {
        return Ok(await _unitOfWork.Pagos.GetAll());
    }

    // POST: api/pagos
    [HttpPost]
    public async Task<ActionResult<Pago>> PostPago(Pago pago)
    {
        await _unitOfWork.Pagos.Add(pago);
        await _unitOfWork.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPagos), new { id = pago.Pagoid }, pago);
    }
}