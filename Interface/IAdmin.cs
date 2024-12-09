using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_thorin.Interface
{
    public interface IAdmin
    {
        string Nome { get; set; }
        string Senha { get; set; }
    }

    public interface IUsuario
    {
        string Username { get; set; }
        string Password { get; set; }     
    }
}