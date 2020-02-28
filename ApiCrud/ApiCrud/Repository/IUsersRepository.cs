using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Repository
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAll();

        Task<Users> GetById(int? Id);

        Task<int> Add(Users user);

        Task<int> Delete(int? Id);

        Task Update(Users user);
    }
}
