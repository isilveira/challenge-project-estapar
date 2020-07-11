using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESTAPAR.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ESTAPAR.Presentations.WebAPP.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private CarroApplicationService CarroApplicationService { get; set; }
        private ManobristaApplicationService ManobristaApplicationService { get; set; }
        private ManobraApplicationService ManobraApplicationService { get; set; }
        public int TotalCarros { get; set; }
        public int TotalManobristas { get; set; }
        public int TotalManobras { get; set; }

        public IndexModel(
            CarroApplicationService carroApplicationService,
            ManobristaApplicationService manobristaApplicationService,
            ManobraApplicationService manobraApplicationService
        )
        {
            CarroApplicationService = carroApplicationService;
            ManobristaApplicationService = manobristaApplicationService;
            ManobraApplicationService = manobraApplicationService;
        }

        public void OnGet()
        {
            TotalCarros = CarroApplicationService.GetTotal();
            TotalManobristas = ManobristaApplicationService.GetTotal();
            TotalManobras = ManobraApplicationService.GetTotal();
        }
    }
}
