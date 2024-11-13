using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_thorin.Models;

namespace backend_thorin.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        
        // endereço
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CEP { get; set; }

    }
}