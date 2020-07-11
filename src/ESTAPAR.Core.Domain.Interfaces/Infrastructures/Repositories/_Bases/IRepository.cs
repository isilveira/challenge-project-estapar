using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories.Bases
{
    public interface IRepository<TKey, TEntity>
        where TEntity : class
        where TKey : struct
    {
        List<TEntity> GetAll();
        TEntity GetByKey(TKey key);
        void Update(TEntity changedEntity);
        void Delete(TKey key);
    }
}
