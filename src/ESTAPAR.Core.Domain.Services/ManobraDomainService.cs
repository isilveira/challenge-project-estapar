using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories;
using ESTAPAR.Core.Domain.Interfaces.Services;
using ESTAPAR.Core.Domain.Services.Bases;

namespace ESTAPAR.Core.Domain.Services
{
    public class ManobraDomainService : DomainService<int, Manobra>, IManobraDomainService
    {
        private IManobraRepository ManobraRepository { get; set; }
        public ManobraDomainService(IManobraRepository manobraRepository) : base(manobraRepository)
        {
            ManobraRepository = manobraRepository;
        }

        public override void Save(Manobra entity)
        {
            if (entity.ManobraID == 0)
            {
                ManobraRepository.Insert(entity);
            }
            else
            {
                ManobraRepository.Update(entity);
            }
        }
    }
}
