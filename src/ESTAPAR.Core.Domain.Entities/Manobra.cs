using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Core.Domain.Entities
{
    public class Manobra
    {
        public int IdManobra { get; set; }
        public int IdManobrista { get; set; }
        public Manobrista Manobrista { get; set; }
        public int IdCarro { get; set; }
        public Carro Carro { get; set; }
    }
}
