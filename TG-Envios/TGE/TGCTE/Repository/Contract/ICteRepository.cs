using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGCTE.Entities;

namespace TGCTE.Repository.Contract
{
    public interface ICteRepository
    {
        List<Cte> GetAll();
        List<Cte> BuscarPorData(string dataInicial,string dataFinal);
        //Cte GetById(int Id);
        // Author PostAuthor(Author author);
        //Author UpdateAuthor(Author author);
        //int DeleteAuthor(Guid authorId);
    }
}
