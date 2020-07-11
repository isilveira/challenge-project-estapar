using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories;
using ESTAPAR.Core.Domain.Interfaces.Services;
using ESTAPAR.Core.Domain.Interfaces.Services.Base;
using ESTAPAR.Core.Domain.Services.Bases;
using System.Collections.Generic;

namespace ESTAPAR.Core.Domain.Services
{
    public class ManobristaDomainService : DomainService<int, Manobrista>, IManobristaDomainService
    {
        private IManobristaRepository ManobristaRepository { get; set; }
        public ManobristaDomainService(IManobristaRepository manobristaRepository) : base(manobristaRepository)
        {
            ManobristaRepository = manobristaRepository;
        }

        public override void Save(Manobrista entity)
        {
            if (entity.ManobristaID == 0)
            {
                ManobristaRepository.Insert(entity);
            }
            else
            {
                ManobristaRepository.Update(entity);
            }
        }
    }
}
