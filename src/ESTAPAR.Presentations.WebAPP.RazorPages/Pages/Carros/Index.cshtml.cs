using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESTAPAR.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ESTAPAR.Presentations.WebAPP.RazorPages.Pages.Carros
{
    public class IndexModel : PageModel
    {
        private CarroApplicationService CarroApplicationService { get; set; }
        public IndexModel(CarroApplicationService carroApplicationService)
        {
            CarroApplicationService = carroApplicationService;
        }

        public List<CarroViewModel> Carros { get; set; }

        public void OnGet()
        {
            Carros = CarroApplicationService.GetAll()
                .Select(carro=> 
                    new CarroViewModel { 
                        IdCarro = carro.CarroID,
                        Marca = carro.Marca,
                        Modelo = carro.Modelo,
                        Placa = carro.Placa
                    })
                .ToList();
        }

        public class CarroViewModel
        {
            public int IdCarro { get; set; }
            public string Marca { get; set; }
            public string Modelo { get; set; }
            public string Placa { get; set; }
        }
    }
}