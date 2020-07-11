using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ESTAPAR.Core.Application;
using ESTAPAR.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ESTAPAR.Presentations.WebAPP.RazorPages.Pages.Manobras
{
    public class EditarModel : PageModel
    {
        private ManobraApplicationService ManobraApplicationService { get; set; }
        private ManobristaApplicationService ManobristaApplicationService { get; set; }
        private CarroApplicationService CarroApplicationService { get; set; }
        public List<SelectListItem> Manobristas { get; set; }
        public List<SelectListItem> Carros { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public EditarModel(
            ManobraApplicationService manobraApplicationService,
            ManobristaApplicationService manobristaApplicationService,
            CarroApplicationService carroApplicationService)
        {
            ManobraApplicationService = manobraApplicationService;
            ManobristaApplicationService = manobristaApplicationService;
            CarroApplicationService = carroApplicationService;
        }
        public void OnGet(int id)
        {
            var manobra = ManobraApplicationService.GetByKey(id);
            Input = new InputModel
            {
                ManobraID = manobra.ManobraID,
                ManobristaID = manobra.ManobristaID,
                CarroID = manobra.CarroID
            };

            var manobristas = ManobristaApplicationService.GetAll();
            var carros = CarroApplicationService.GetAll();

            Manobristas = manobristas.Select(manobrista => new SelectListItem
            {
                Value = manobrista.ManobristaID.ToString(),
                Text = manobrista.CPF + " / " + manobrista.Nome
            }).ToList();

            Manobristas.Insert(0, new SelectListItem { Value = "0", Text = "-- Manobristas --" });

            Carros = carros.Select(carro => new SelectListItem
            {
                Value = carro.CarroID.ToString(),
                Text = carro.Placa + " / " + carro.Marca + " / " + carro.Modelo
            }).ToList();

            Carros.Insert(0, new SelectListItem { Value = "0", Text = "-- Carros --" });

            Manobristas.Where(x => x.Value == Input.ManobristaID.ToString()).SingleOrDefault().Selected = true;
            Carros.Where(x => x.Value == Input.CarroID.ToString()).SingleOrDefault().Selected = true;
        }

        public ActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var manobra = new Manobra
                    {
                        ManobraID = Input.ManobraID,
                        ManobristaID = Input.ManobristaID,
                        CarroID = Input.CarroID
                    };

                    ManobraApplicationService.Save(manobra);

                    return RedirectToPage("./index");
                }

                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Page();
            }
        }
        public class InputModel
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "{0} é obrigatório!")]
            public int ManobraID { get; set; }
            [Required(AllowEmptyStrings = false, ErrorMessage = "{0} é obrigatório!")]
            [Display(Name = "Manobrista")]
            public int ManobristaID { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "{0} é obrigatório!")]
            [Display(Name = "Carro")]
            public int CarroID { get; set; }
        }
    }
}