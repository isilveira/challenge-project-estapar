using System;
using System.Collections.Generic;

namespace ESTAPAR.Core.Domain.Entities
{
    public class Manobrista
    {
        public int ManobristaID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Manobra> Manobras { get; set; }
    }
}
