using Microsoft.AspNetCore.Mvc;
using backend_thorin.Models;
using backend_thorin.Context;
using Microsoft.EntityFrameworkCore;


namespace backend_thorin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly ColaboradorContext _context;

        public ColaboradorController(ColaboradorContext context)
        {
            _context = context;
        }
        // GET: lista todos os colaboradores
        [HttpGet("colaborador")]
        public async Task<ActionResult<IEnumerable<Colaborador>>> GetColaborador()
        {
            return await _context.Colaborador.ToListAsync();
        }
        
        // GET: pelo id do usuario
        [HttpGet("colaborador/{id}")]
        public async Task<ActionResult<Colaborador>> GetColaborador(int id)
        {
            var colaborador = await _context.Colaborador.FindAsync(id);

            if( colaborador == null)
            {
                return NotFound();
            }
            return colaborador;
        }

        // POST: adiciona um colaborador  AO BANCO DE DADOS
        [HttpPost("colaborador")]
        public async Task<ActionResult<Colaborador>> PostColaborador(Colaborador colaborador)
        {
            _context.Colaborador.Add(colaborador);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetColaborador), new { id = colaborador.Id}, colaborador);
        }

        // PUT: atualiza um colaborador  AO BANCO DE DADOS
        [HttpPut("colaborador/{id}")]
        public async Task<ActionResult> PutColaborador(int id, Colaborador colaborador)
        {
            if(id != colaborador.Id)
            {
                return BadRequest();
            }
            _context.Entry(colaborador).State = EntityState.Modified;
            await 
            _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: apaga um colaborador  AO BANCO DE DADOS
        [HttpDelete("colaborardor{id}")]
        public async Task<ActionResult> DeleteColaborador(int id)
        {
            var colaborador = await _context.Colaborador.FindAsync(id);

            if(colaborador == null)
            {
                return NotFound();
            }

            _context.Colaborador.Remove(colaborador);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}