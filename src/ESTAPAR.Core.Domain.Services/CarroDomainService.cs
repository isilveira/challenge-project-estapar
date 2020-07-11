using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories;
using ESTAPAR.Core.Domain.Interfaces.Services;
using ESTAPAR.Core.Domain.Services.Bases;

namespace ESTAPAR.Core.Domain.Services
{
    public class CarroDomainService : DomainService<int, Carro>, ICarroDomainService
    {
        private ICarroRepository CarroRepository { get; set; }
        public CarroDomainService(ICarroRepository carroRepository) : base(carroRepository)
        {
            CarroRepository = carroRepository;
        }

        public override void Save(Carro entity)
        {
            if (entity.CarroID == 0)
            {
                CarroRepository.Insert(entity);
            }
            else
            {
                CarroRepository.Update(entity);
            }
        }
    }
}
