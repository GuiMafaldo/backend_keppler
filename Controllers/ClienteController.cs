using Microsoft.AspNetCore.Mvc;
using backend_thorin.Context;
using backend_thorin.Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ClienteContext _context;

    public ClienteController(ClienteContext context)
    {
        _context = context;
    }

    // GET: api/clientes
    [HttpGet("clientes")]
    public async Task<ActionResult<IEnumerable<Clientes>>> GetClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    // GET: api/clientes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Clientes>> GetCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return cliente;
    }

    // POST: api/clientes
    [HttpPost("cadastrar")]
    public async Task<ActionResult<Clientes>> PostCliente(Clientes cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
    }

    // PUT: api/clientes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(int id, Clientes cliente)
    {
        if (id != cliente.Id)
        {
            return BadRequest();
        }

        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/clientes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
