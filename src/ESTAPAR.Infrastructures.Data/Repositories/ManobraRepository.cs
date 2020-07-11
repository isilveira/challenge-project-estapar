﻿using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Contexts;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESTAPAR.Infrastructures.Data.Repositories
{
    public class ManobraRepository : IManobraRepository
    {
        private IEstaparDbContext EstaparDbContext { get; set; }
        public ManobraRepository(IEstaparDbContext estaparDbContext)
        {
            EstaparDbContext = estaparDbContext;
        }
        public void Delete(int key)
        {
            var entity = EstaparDbContext.Set<Manobra>().SingleOrDefault(x => x.IdManobra == key);

            EstaparDbContext.Set<Manobra>().Remove(entity);

            EstaparDbContext.SaveChanges();
        }

        public List<Manobra> GetAll()
        {
            return EstaparDbContext.Set<Manobra>().ToList();
        }

        public Manobra GetByKey(int key)
        {
            return EstaparDbContext.Set<Manobra>().SingleOrDefault(x => x.IdManobra == key);
        }

        public void Update(Manobra changedEntity)
        {
            var dbEntity = EstaparDbContext.Set<Manobra>().SingleOrDefault(x => x.IdManobra == changedEntity.IdManobra);

            EstaparDbContext.ApplyChanges(dbEntity, changedEntity);

            EstaparDbContext.SaveChanges();
        }
    }
}
