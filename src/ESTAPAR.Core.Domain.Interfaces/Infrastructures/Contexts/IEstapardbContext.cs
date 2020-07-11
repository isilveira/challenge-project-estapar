using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Core.Domain.Interfaces.Infrastructures.Contexts
{
    public interface IEstaparDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void ApplyChanges<TEntity>(TEntity dbEntity, TEntity changedEntity) where TEntity : class;
        int SaveChanges();
    }
}
