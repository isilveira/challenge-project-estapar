using ESTAPAR.Core.Application.Bases;
using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Services;
using ESTAPAR.Core.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Core.Application
{
    public class CarroApplicationService : ApplicationService<int, Carro>
    {
        private ICarroDomainService CarroDomainService { get; set; }
        public CarroApplicationService(ICarroDomainService carroDomainService) : base(carroDomainService)
        {
            CarroDomainService = carroDomainService;
        }

        public int GetTotal()
        {
            return CarroDomainService.GetTotal();
        }
    }
}
