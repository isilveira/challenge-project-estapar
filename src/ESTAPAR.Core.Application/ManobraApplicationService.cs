using ESTAPAR.Core.Application.Bases;
using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Core.Application
{
    public class ManobraApplicationService : ApplicationService<int, Manobra>
    {
        private IManobraDomainService ManobraDomainService { get; set; }
        public ManobraApplicationService(IManobraDomainService manobraDomainService) : base(manobraDomainService)
        {
            ManobraDomainService = manobraDomainService;
        }

        public int GetTotal()
        {
            return ManobraDomainService.GetTotal();
        }
    }
}
