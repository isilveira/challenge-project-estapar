using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Contexts;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESTAPAR.Infrastructures.Data.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        public IEstaparDbContext EstaparDbContext { get; set; }
        public CarroRepository(IEstaparDbContext estaparDbContext)
        {
            EstaparDbContext = estaparDbContext;
        }
        public void Delete(int key)
        {
            var entity = EstaparDbContext.Set<Carro>().SingleOrDefault(x => x.IdCarro == key);

            EstaparDbContext.Set<Carro>().Remove(entity);

            EstaparDbContext.SaveChanges();
        }

        public List<Carro> GetAll()
        {
            return EstaparDbContext.Set<Carro>().ToList();
        }

        public Carro GetByKey(int key)
        {
            return EstaparDbContext.Set<Carro>().SingleOrDefault(x => x.IdCarro == key);
        }

        public void Update(Carro changedEntity)
        {
            var dbEntity = EstaparDbContext.Set<Carro>().SingleOrDefault(x => x.IdCarro == changedEntity.IdCarro);

            EstaparDbContext.ApplyChanges(dbEntity, changedEntity);

            EstaparDbContext.SaveChanges();
        }
    }
}
