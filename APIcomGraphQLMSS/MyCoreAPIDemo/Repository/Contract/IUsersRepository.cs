using MyCoreAPIDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.Repository.Contract
{
    public interface IUsersRepository<T>
    {
        IEnumerable<T> GetAll();
        Users GetById(int Id);
        // Author PostAuthor(Author author);
        //Author UpdateAuthor(Author author);
        //int DeleteAuthor(Guid authorId);


    }
}
