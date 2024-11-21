using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_thorin.Models;

namespace backend_thorin.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}