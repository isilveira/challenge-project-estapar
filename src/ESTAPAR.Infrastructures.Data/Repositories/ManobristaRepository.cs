﻿using ESTAPAR.Core.Domain.Entities;
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
        private IEstapardbContext EstaparDbContext { get; set; }
        public ManobristaRepository(IEstapardbContext estaparDbContext)
        {
            EstaparDbContext = estaparDbContext;
        }
        public void Delete(int key)
        {
            var entity = EstaparDbContext.Set<Manobrista>().SingleOrDefault(x => x.IdManobrista == key);

            EstaparDbContext.Set<Manobrista>().Remove(entity);

            EstaparDbContext.SaveChanges();
        }

        public List<Manobrista> GetAll()
        {
            return EstaparDbContext.Set<Manobrista>().ToList();
        }

        public Manobrista GetByKey(int key)
        {
            return EstaparDbContext.Set<Manobrista>().SingleOrDefault(x => x.IdManobrista == key);
        }

        public void Update(Manobrista changedEntity)
        {
            var dbEntity = EstaparDbContext.Set<Manobrista>().SingleOrDefault(x => x.IdManobrista == changedEntity.IdManobrista);

            EstaparDbContext.ApplyChanges(dbEntity, changedEntity);

            EstaparDbContext.SaveChanges();
        }
    }
}
