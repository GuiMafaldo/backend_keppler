using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_thorin.Models;

namespace backend_thorin.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Categoria { get; set; }
    }
}