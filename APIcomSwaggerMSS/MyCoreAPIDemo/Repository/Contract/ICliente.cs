using MyCoreAPIDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.Repository.Contract
{
    public interface ICliente<T>
    {
        IEnumerable<T> ListarTodos();
        Cliente Cadastrar(Cliente dados);
        // Author PostAuthor(Author author);
        //Author UpdateAuthor(Author author);
        //int DeleteAuthor(Guid authorId);
        //Author GetAuthor(Guid authorId);

    }
}
