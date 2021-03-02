using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Repository
{
    public interface IFilmeRepository
    {
        Task<List<Filme>> GetAll();

        Task<Filme> GetById(int? Id);

        Task<int> Add(Filme user);

        Task<int> Delete(int? Id);

        Task Update(Filme user);
    }
}
