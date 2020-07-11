﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ESTAPAR.Core.Application;
using ESTAPAR.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ESTAPAR.Presentations.WebAPP.RazorPages.Pages.Manobristas
{
    public class NovoModel : PageModel
    {
        private ManobristaApplicationService ManobristaApplicationService { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public NovoModel(ManobristaApplicationService manobristaApplicationService)
        {
            ManobristaApplicationService = manobristaApplicationService;
        }

        public void OnGet()
        {

        }
        public ActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var manobrista = new Manobrista
                    {
                        Nome = Input.Nome,
                        CPF = Input.CPF,
                        DataNascimento = Input.DataNascimento
                    };

                    ManobristaApplicationService.Save(manobrista);

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
            [Display(Name = "Nome")]
            public string Nome { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "{0} é obrigatório!")]
            [Display(Name = "CPF")]
            public string CPF { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "{0} é obrigatório!")]
            [Display(Name = "Data de Nascimento")]
            [DataType(DataType.Date)]
            public DateTime DataNascimento { get; set; }
        }
    }
}