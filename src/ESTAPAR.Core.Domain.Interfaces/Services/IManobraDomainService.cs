﻿using ESTAPAR.Core.Domain.Entities;
using ESTAPAR.Core.Domain.Interfaces.Services.Base;

namespace ESTAPAR.Core.Domain.Interfaces.Services
{
    public interface IManobraDomainService : IDomainService<int, Manobra>
    {
        int GetTotal();
    }
}
