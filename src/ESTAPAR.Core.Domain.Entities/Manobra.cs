using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Core.Domain.Entities
{
    public class Manobra
    {
        public int ManobraID { get; set; }
        public int ManobristaID { get; set; }
        public Manobrista Manobrista { get; set; }
        public int CarroID { get; set; }
        public Carro Carro { get; set; }
    }
}
