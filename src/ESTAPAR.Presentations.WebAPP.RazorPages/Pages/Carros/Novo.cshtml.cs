using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ESTAPAR.Core.Application;
using ESTAPAR.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ESTAPAR.Presentations.WebAPP.RazorPages.Pages.Carros
{
    public class NovoModel : PageModel
    {
        private CarroApplicationService CarroApplicationService { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public NovoModel(CarroApplicationService carroApplicationService)
        {
            CarroApplicationService = carroApplicationService;
        }
        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var carro = new Carro
                {
                    Marca = Input.Marca,
                    Modelo = Input.Modelo,
                    Placa = Input.Placa
                };

                CarroApplicationService.Save(carro);

                return RedirectToPage("./Index");
            }

            return Page();
        }

        public class InputModel
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "{0} é obrigatório!")]
            [Display(Name = "Marca")]
            public string Marca { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "{0} é obrigatório!")]
            [Display(Name = "Modelo")]
            public string Modelo { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "{0} é obrigatório!")]
            [Display(Name = "Placa")]
            public string Placa { get; set; }
        }
    }
}