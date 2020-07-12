using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Infrastructures.Data
{
    public class EstaparDbContext : DbContext, IEstaparDbContext
    {
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Manobra> Manobras { get; set; }
        public DbSet<Manobrista> Manobristas { get; set; }
        public EstaparDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public void ApplyChanges<TEntity>(TEntity dbEntity, TEntity changedEntity) where TEntity : class
        {
            this.Entry<TEntity>(dbEntity).CurrentValues.SetValues(changedEntity);
        }
    }
}
