using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGCTE.Entities;

namespace TGCTE.Repository.Contract
{
    public interface ILoginRepository
    {
        Usuarios Autenticar(Login model);
    }
}
