using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories;
using ESTAPAR.Core.Domain.Interfaces.Services;
using ESTAPAR.Core.Domain.Services.Bases;
using System;

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
            if(CarroRepository.ExisteOutroCarroComMesmaPlaca(entity.CarroID, entity.Placa))
            {
                throw new Exception("Já existe um carro cadastrado com essa placa!");
            }

            if (entity.CarroID == 0)
            {
                CarroRepository.Insert(entity);
            }
            else
            {
                CarroRepository.Update(entity);
            }
        }

        public override void Delete(int key)
        {
            if (CarroRepository.ExistemManobrasParaOCarro(key))
            {
                throw new Exception("Existem manobras vinculadas ao carro, não foi possível completar a operação!");
            }

            base.Delete(key);
        }
    }
}
