using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ProdutoCriarDto
    {
        
        public string Nome { get; set; }
        public int Qtd { get; set; }
        public decimal Preco { get; set; }
        public int Lote { get; set; }

    }
}
