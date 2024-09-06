using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UsuarioCriarDto
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public double Salario { get; set; }
        public string CPF { get; set; }
        public bool Situacao { get; set; }
        public string Senha { get; set; }
    }
}
