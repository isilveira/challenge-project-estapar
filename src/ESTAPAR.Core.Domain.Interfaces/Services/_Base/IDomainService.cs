using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Core.Domain.Interfaces.Services.Base
{
    public interface IDomainService<TKey, TEntity>
        where TKey : struct
        where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity GetByKey(TKey key);
        void Save(TEntity changedEntity);
        void Delete(TKey key);
    }
}
