using ESTAPAR.Core.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Core.Application.Bases
{
    public abstract class ApplicationService<TKey, TEntity>
        where TKey : struct
        where TEntity : class
    {
        private IDomainService<TKey, TEntity> DomainService { get; set; }
        public ApplicationService(IDomainService<TKey, TEntity> domainService)
        {
            DomainService = domainService;
        }
        public void Delete(TKey key)
        {
            DomainService.Delete(key);
        }

        public List<TEntity> GetAll()
        {
            return DomainService.GetAll();
        }

        public TEntity GetByKey(TKey key)
        {
            return DomainService.GetByKey(key);
        }

        public void Save(TEntity entity)
        {
            DomainService.Save(entity);
        }
    }
}
