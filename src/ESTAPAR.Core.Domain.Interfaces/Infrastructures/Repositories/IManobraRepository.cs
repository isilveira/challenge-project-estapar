using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories.Bases;

namespace ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories
{
    public interface IManobraRepository : IRepository<int, Manobra>
    {
        int GetTotal();
    }
}
