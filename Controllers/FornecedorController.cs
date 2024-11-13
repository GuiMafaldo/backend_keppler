using Microsoft.AspNetCore.Mvc;
using backend_thorin.Context;
using backend_thorin.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend_thorin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly FornecedorContext _context;

        public FornecedorController(FornecedorContext context)
        {
            _context = context;
        }

        // Obter todos os Fornecedores
        [HttpGet("fornecedores")]
        public async Task<ActionResult<IEnumerable<Fornecedores>>> GetFornecedores()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        // Criar Fornecedor
        [HttpPost("criar")]
        public async Task<IActionResult> CreateFornecedor([FromBody] Fornecedores fornecedor)
        {
            if (fornecedor == null)
            {
                return BadRequest();
            }

            await _context.Fornecedores.AddAsync(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFornecedor), new { id = fornecedor.Id }, fornecedor);
        }

        // Obter Fornecedor por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return Ok(fornecedor);
        }
    }
}
