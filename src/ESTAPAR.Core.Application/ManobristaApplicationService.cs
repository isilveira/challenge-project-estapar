using ESTAPAR.Core.Application.Bases;
using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Core.Application
{
    public class ManobristaApplicationService : ApplicationService<int, Manobrista>
    {
        private IManobristaDomainService ManobristaDomainService { get; set; }
        public ManobristaApplicationService(IManobristaDomainService manobristaDomainService) : base(manobristaDomainService)
        {
            ManobristaDomainService = manobristaDomainService;
        }

        public int GetTotal()
        {
            return ManobristaDomainService.GetTotal();
        }
    }
}
