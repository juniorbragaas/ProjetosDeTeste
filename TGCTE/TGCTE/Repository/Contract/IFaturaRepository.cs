﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGCTE.Entities;

namespace TGCTE.Repository.Contract
{
    public interface IOcorrenciaRepository
    {
        List<Ocorrencia> GetAll();
        List<Ocorrencia> BuscarPorData(string dataInicial,string dataFinal);
        //Cte GetById(int Id);
        // Author PostAuthor(Author author);
        //Author UpdateAuthor(Author author);
        //int DeleteAuthor(Guid authorId);
    }
}
