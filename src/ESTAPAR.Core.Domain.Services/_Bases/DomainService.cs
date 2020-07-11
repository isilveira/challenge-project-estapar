using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories.Bases;
using ESTAPAR.Core.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace ESTAPAR.Core.Domain.Services.Bases
{
    public abstract class DomainService<TKey, TEntity> : IDomainService<TKey, TEntity>
        where TKey : struct
        where TEntity : class
    {
        private IRepository<TKey, TEntity> Repository { get; set; }
        public DomainService(IRepository<TKey, TEntity> repository)
        {
            Repository = repository;
        }
        public virtual void Delete(TKey key)
        {
            Repository.Delete(key);
        }

        public virtual List<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual TEntity GetByKey(TKey key)
        {
            return Repository.GetByKey(key);
        }

        public abstract void Save(TEntity entity);
    }
}
