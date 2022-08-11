using MyCoreAPIDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.Repository.Contract
{
    public interface IFilme<T>
    {
        IEnumerable<T> ListarTodos();
        Filme Cadastrar(Filme dados);

        // Author PostAuthor(Author author);
        //Author UpdateAuthor(Author author);
        //int DeleteAuthor(Guid authorId);
        //Author GetAuthor(Guid authorId);

    }
}
