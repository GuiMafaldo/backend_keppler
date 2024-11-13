using Microsoft.AspNetCore.Mvc;
using backend_thorin.Context;
using backend_thorin.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_thorin.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class AdminController : ControllerBase
        {
            private readonly AdminContext _context;

            public AdminController(AdminContext context)
            {
                _context = context;
            }
            [HttpPost("login")]
                public IActionResult Login([FromBody] LoginRequest request)
                {
                    if (request == null || string.IsNullOrEmpty(request.Nome) || string.IsNullOrEmpty(request.Senha))
                    {
                        return BadRequest("Dados de login inválidos.");
                    }

                    var usuario = _context.Administracao
                        .FirstOrDefault(u => u.Nome == request.Nome && u.Senha == request.Senha);

                    if (usuario == null)
                    {
                        return Unauthorized("Credenciais inválidas.");
                    }

                    // Retorne um objeto que indique sucesso
                    return Ok(new { success = true });
                }
           

        // GET: admin/admin/{id}
        [HttpGet("{id}")]
        public IActionResult ObterUsuarioPorId(int id)
        {
            var usuario = _context.Administracao.Find(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado");
            return Ok(usuario);
        }

        // GET: admin/admin/ObterTodosUsuarios
        [HttpGet("ObterTodosUsuarios")]
        public IActionResult ObterTodosUsuarios()
        {
            var usuarios = _context.Administracao.ToList();
            if (usuarios == null || usuarios.Count == 0)
                return NotFound("Nenhum usuário encontrado");
            return Ok(usuarios);
        }

        // POST: admin/admin/CriarUsuario
        [HttpPost("CriarUsuario")]
        public IActionResult CriarUsuario(Administracao usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrEmpty(usuario.Senha))
                return BadRequest(new { Erro = "Nome e email são obrigatórios" });

            _context.Administracao.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ObterUsuarioPorId), new { id = usuario.Id }, usuario);
        }

        // PUT: admin/admin/AtualizarUsuario/{id}
        [HttpPut("AtualizarUsuario/{id}")]
        public IActionResult AtualizarUsuario(int id, Administracao usuario)
        {
            var usuarioBanco = _context.Administracao.Find(id);
            if (usuarioBanco == null)
                return NotFound("Usuário não encontrado");

            usuarioBanco.Nome = usuario.Nome;
            usuarioBanco.Senha = usuario.Senha;
            usuarioBanco.Role = usuario.Role;

            _context.SaveChanges();
            return Ok();
        }

        // DELETE: admin/admin/DeletarUsuario/{id}
        [HttpDelete("DeletarUsuario/{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            var usuarioBanco = _context.Administracao.Find(id);
            if (usuarioBanco == null)
                return NotFound("Usuário não encontrado");

            _context.Administracao.Remove(usuarioBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
