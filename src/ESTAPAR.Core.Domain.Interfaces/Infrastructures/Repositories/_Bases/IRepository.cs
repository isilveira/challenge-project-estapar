﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories.Bases
{
    public interface IRepository<TKey, TEntity>
        where TKey : struct
        where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetByKey(TKey key);
        void Insert(TEntity newEntity);
        void Update(TEntity changedEntity);
        void Delete(TKey key);
    }
}
