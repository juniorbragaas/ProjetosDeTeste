using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Repository
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetAll();

        Task<Cliente> GetById(int? Id);

        Task<int> Add(Cliente user);

        Task<int> Delete(int? Id);

        Task Update(Cliente user);
    }
}
