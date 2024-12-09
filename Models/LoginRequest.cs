using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_thorin.Models
{
    public class LoginRequest
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
}
}