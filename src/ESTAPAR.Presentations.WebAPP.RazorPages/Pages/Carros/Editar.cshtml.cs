﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ESTAPAR.Core.Application;
using ESTAPAR.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ESTAPAR.Presentations.WebAPP.RazorPages.Pages.Carros
{
    public class EditarModel : PageModel
    {
        private CarroApplicationService CarroApplicationService { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public EditarModel(CarroApplicationService carroApplicationService)
        {
            CarroApplicationService = carroApplicationService;
        }

        public void OnGet([FromRoute] int id)
        {
            var carro = CarroApplicationService.GetByKey(id);

            Input = new InputModel
            {
                CarroID = carro.CarroID,
                Marca = carro.Marca,
                Modelo = carro.Modelo,
                Placa = carro.Placa
            };
        }

        public ActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var carro = new Carro
                    {
                        CarroID = Input.CarroID,
                        Marca = Input.Marca,
                        Modelo = Input.Modelo,
                        Placa = Input.Placa
                    };

                    CarroApplicationService.Save(carro);

                    return RedirectToPage("./Index");
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
            public int CarroID { get; set; }
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