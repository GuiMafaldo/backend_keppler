using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_thorin.Models
{
    public class Fornecedores
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string RazaoSocial { get; set; }
        public int Telefone { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

    }
}