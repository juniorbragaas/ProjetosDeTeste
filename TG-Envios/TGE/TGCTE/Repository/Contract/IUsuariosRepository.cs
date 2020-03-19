using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGCTE.Entities;

namespace TGCTE.Repository.Contract
{
    public interface IUsuariosRepository
    {
        List<Usuarios> GetAll();
        Task<int>  Add(Usuarios author);
        Usuarios GetById(int Id);
        
        Usuarios Update(Usuarios model);
        int Delete(int? Id);
    }
}
