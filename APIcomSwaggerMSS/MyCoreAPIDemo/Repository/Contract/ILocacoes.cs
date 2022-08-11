using MyCoreAPIDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.Repository.Contract
{
    public interface ILocacoes<T>
    {
        IEnumerable<T> ListarTodos();
        Locacoes Cadastrar(Locacoes dados);
        Locacoes AlertarAtraso(Locacoes dados);
        Locacoes VericarSeExisteLocacao(Locacoes dados);
        // Author PostAuthor(Author author);
        //Author UpdateAuthor(Author author);
        //int DeleteAuthor(Guid authorId);
        //Author GetAuthor(Guid authorId);

    }
}
