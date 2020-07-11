using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Contexts;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESTAPAR.Infrastructures.Data.Repositories
{
    public class ManobristaRepository : IManobristaRepository
    {
        private IEstaparDbContext EstaparDbContext { get; set; }
        public ManobristaRepository(IEstaparDbContext estaparDbContext)
        {
            EstaparDbContext = estaparDbContext;
        }
        public void Delete(int key)
        {
            var entity = EstaparDbContext.Set<Manobrista>().SingleOrDefault(x => x.ManobristaID == key);

            EstaparDbContext.Set<Manobrista>().Remove(entity);

            EstaparDbContext.SaveChanges();
        }

        public List<Manobrista> GetAll()
        {
            return EstaparDbContext.Set<Manobrista>().ToList();
        }

        public Manobrista GetByKey(int key)
        {
            return EstaparDbContext.Set<Manobrista>().SingleOrDefault(x => x.ManobristaID == key);
        }

        public void Update(Manobrista changedEntity)
        {
            var dbEntity = EstaparDbContext.Set<Manobrista>().SingleOrDefault(x => x.ManobristaID == changedEntity.ManobristaID);

            EstaparDbContext.ApplyChanges(dbEntity, changedEntity);

            EstaparDbContext.SaveChanges();
        }

        public void Insert(Manobrista newEntity)
        {
            EstaparDbContext.Set<Manobrista>().Add(newEntity);

            EstaparDbContext.SaveChanges();
        }

        public bool ExisteOutroManobristaComOMesmoCPF(int manobristaID, string cpf)
        {
            return EstaparDbContext.Set<Manobrista>().Any(x => x.ManobristaID != manobristaID && x.CPF == cpf);
        }

        public bool ExistemManobrasParaOManobrista(int key)
        {
            return EstaparDbContext.Set<Manobrista>().Any(x => x.ManobristaID == key && x.Manobras.Any());
        }

        public int GetTotal()
        {
            return EstaparDbContext.Set<Manobrista>().Count();
        }
    }
}
