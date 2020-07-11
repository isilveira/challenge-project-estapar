using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Services.Base;

namespace ESTAPAR.Core.Domain.Interfaces.Services
{
    public interface ICarroDomainService : IDomainService<int, Carro>
    {
        int GetTotal();
    }
}
