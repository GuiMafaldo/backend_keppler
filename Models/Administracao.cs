using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_thorin.Models;

namespace backend_thorin.Models
{
    public class Administracao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public EnumUsuariosAdm TipoUsuario { get; set; }
    
    }
}