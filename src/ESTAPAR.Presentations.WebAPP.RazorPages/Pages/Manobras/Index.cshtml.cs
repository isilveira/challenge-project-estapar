using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESTAPAR.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ESTAPAR.Presentations.WebAPP.RazorPages.Pages.Manobras
{
    public class IndexModel : PageModel
    {
        private ManobraApplicationService ManobraApplicationService { get; set; }
        public List<ManobraViewModel> Manobras { get; set; }
        public IndexModel(ManobraApplicationService manobraApplicationService)
        {
            ManobraApplicationService = manobraApplicationService;
        }
        public void OnGet()
        {
            var manobras = ManobraApplicationService.GetAll();

            Manobras = manobras.Select(manobra => new ManobraViewModel
            {
                ManobraID = manobra.ManobraID,
                DescricaoManobrista = manobra.Manobrista.CPF + " / " + manobra.Manobrista.Nome,
                DescricaoCarro = manobra.Carro.Placa + " / " + manobra.Carro.Marca + " / " + manobra.Carro.Modelo
            }).ToList();
        }

        public class ManobraViewModel
        {
            public int ManobraID { get; set; }
            public string DescricaoManobrista { get; set; }
            public string DescricaoCarro { get; set; }
        }
    }
}