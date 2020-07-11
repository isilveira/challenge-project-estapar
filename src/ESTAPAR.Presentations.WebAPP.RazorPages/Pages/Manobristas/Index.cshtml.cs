using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESTAPAR.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ESTAPAR.Presentations.WebAPP.RazorPages.Pages.Manobristas
{
    public class IndexModel : PageModel
    {
        private ManobristaApplicationService ManobristaApplicationService { get; set; }
        public IndexModel(ManobristaApplicationService manobristaApplicationService)
        {
            ManobristaApplicationService = manobristaApplicationService;
        }

        public List<ManobristaViewModel> Manobristas { get; set; }

        public void OnGet()
        {
            Manobristas = ManobristaApplicationService.GetAll()
                .Select(manobrista =>
                    new ManobristaViewModel
                    {
                        ManobristaID = manobrista.ManobristaID,
                        Nome = manobrista.Nome,
                        CPF = manobrista.CPF,
                        DataNascimento = manobrista.DataNascimento
                    })
                .ToList();
        }

        public class ManobristaViewModel
        {
            public int ManobristaID { get; set; }
            public string Nome { get; set; }
            public string CPF { get; set; }
            public DateTime DataNascimento { get; set; }
        }
    }
}