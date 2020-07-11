using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESTAPAR.Infrastructures.Data
{
    public class EstaparDbContext : DbContext
    {
        protected EstaparDbContext()
        {
        }
        public EstaparDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
