using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Contexts;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories.Bases;
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
            var entity = EstaparDbContext.Set<Carro>().SingleOrDefault(x => x.CarroID == key);

            EstaparDbContext.Set<Carro>().Remove(entity);

            EstaparDbContext.SaveChanges();
        }

        public List<Carro> GetAll()
        {
            return EstaparDbContext.Set<Carro>().ToList();
        }

        public Carro GetByKey(int key)
        {
            return EstaparDbContext.Set<Carro>().SingleOrDefault(x => x.CarroID == key);
        }

        public void Update(Carro changedEntity)
        {
            var dbEntity = EstaparDbContext.Set<Carro>().SingleOrDefault(x => x.CarroID == changedEntity.CarroID);

            EstaparDbContext.ApplyChanges(dbEntity, changedEntity);

            EstaparDbContext.SaveChanges();
        }

        public void Insert(Carro newEntity)
        {
            EstaparDbContext.Set<Carro>().Add(newEntity);

            EstaparDbContext.SaveChanges();
        }

        public bool ExisteOutroCarroComMesmaPlaca(int carroID, string placa)
        {
            return EstaparDbContext.Set<Carro>().Any(x => x.CarroID != carroID && x.Placa == placa);
        }

        public bool ExistemManobrasParaOCarro(int key)
        {
            return EstaparDbContext.Set<Carro>().Any(x => x.CarroID == key && x.Manobras.Any());
        }

        public int GetTotal()
        {
            return EstaparDbContext.Set<Carro>().Count();
        }
    }
}
