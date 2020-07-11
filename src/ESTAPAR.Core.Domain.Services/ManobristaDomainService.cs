using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories;
using ESTAPAR.Core.Domain.Interfaces.Services;
using ESTAPAR.Core.Domain.Interfaces.Services.Base;
using ESTAPAR.Core.Domain.Services.Bases;
using System;
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
            if(ManobristaRepository.ExisteOutroManobristaComOMesmoCPF(entity.ManobristaID, entity.CPF))
            {
                throw new Exception("Já existe um manobrista cadastrado com esse CPF!");
            }

            if (entity.ManobristaID == 0)
            {
                ManobristaRepository.Insert(entity);
            }
            else
            {
                ManobristaRepository.Update(entity);
            }
        }

        public override void Delete(int key)
        {
            if (ManobristaRepository.ExistemManobrasParaOManobrista(key))
            {
                throw new Exception("Existem manobras vinculadas ao manobrista, não foi possível completar a operação!");
            }

            base.Delete(key);
        }

        public int GetTotal()
        {
            return ManobristaRepository.GetTotal();
        }
    }
}
