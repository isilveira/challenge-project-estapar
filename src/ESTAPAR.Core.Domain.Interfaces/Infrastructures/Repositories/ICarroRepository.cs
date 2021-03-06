﻿using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories.Bases;

namespace ESTAPAR.Core.Domain.Interfaces.Infrastructures.Repositories
{
    public interface ICarroRepository : IRepository<int, Carro>
    {
        bool ExisteOutroCarroComMesmaPlaca(int carroID, string placa);
        bool ExistemManobrasParaOCarro(int key);
        int GetTotal();
    }
}
