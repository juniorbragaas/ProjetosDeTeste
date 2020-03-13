﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGCTE.Entities;

namespace TGCTE.Repository.Contract
{
    public interface IHistoricoRepository
    {
        IEnumerable<Historico> GetAll();
        IEnumerable<Historico> BuscarPorData(string dataInicial,string dataFinal);
        Task<int> Add(Historico model);
        // Author PostAuthor(Author author);
        //Author UpdateAuthor(Author author);
        //int DeleteAuthor(Guid authorId);
    }
}
