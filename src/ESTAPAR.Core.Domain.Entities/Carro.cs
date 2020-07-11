using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Core.Domain.Entities
{
    public class Carro
    {
        public int IdCarro { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public List<Manobra> Manobras { get; set; }
    }
}
