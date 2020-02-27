using ApiCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Repository
{
    public interface IUsers
    {
        Task<List<Users>> GetAll();

        Task<Users> GetById(int? id);

        Task<int> Add(Users user);

        Task<int> Delete(int? id);

        Task Update(Users user);
    }
}
