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

        public void RemoveCPFMask()
        {
            CPF = CPF.Replace(".", "").Replace("-", "").PadLeft(11, '0');
        }
        public void AddCPFMask()
        {
            CPF = string.Format("{0}.{1}.{2}-{3}", CPF.Substring(0, 3), CPF.Substring(3, 3), CPF.Substring(6, 3), CPF.Substring(9, 2));
        }
    }
}
