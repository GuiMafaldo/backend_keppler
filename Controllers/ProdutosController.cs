using Microsoft.AspNetCore.Mvc;
using backend_thorin.Context;
using backend_thorin.Models;
using Microsoft.EntityFrameworkCore;



[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutosContext _context;

    public ProdutosController(ProdutosContext context)
    {
        _context = context;
    }

    // GET: api/Produtos
    [HttpGet("produto")]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        return await _context.Produto.ToListAsync();
    }

    // GET: api/Produtos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(int id)
    {
        var produto = await _context.Produto.FindAsync(id);

        if (produto == null)
        {
            return NotFound();
        }

        return produto;
    }

    // POST: api/Produtos
    [HttpPost("cadastrar")]
    public async Task<ActionResult<Produto>> PostProduto(Produto produto)
    {
        _context.Produto.Add(produto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
    }

    // PUT: api/Produtos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduto(int id, Produto produto)
    {
        if (id != produto.Id)
        {
            return BadRequest();
        }

        _context.Entry(produto).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Produtos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        var produto = await _context.Produto.FindAsync(id);

        if (produto == null)
        {
            return NotFound();
        }

        _context.Produto.Remove(produto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

