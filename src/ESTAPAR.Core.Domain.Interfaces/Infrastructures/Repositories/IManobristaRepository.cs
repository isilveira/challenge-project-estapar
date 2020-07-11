using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories.Bases;

namespace ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories
{
    public interface IManobristaRepository : IRepository<int, Manobrista>
    {
        bool ExisteOutroManobristaComOMesmoCPF(int manobristaID, string cPF);
        bool ExistemManobrasParaOManobrista(int key);
    }
}
