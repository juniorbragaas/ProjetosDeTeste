using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGCTE.Entities;
using TGCTE.Repository.Contract;

namespace TGCTE.Repository.Implementation
{
    public class HistoricoRepository : IHistoricoRepository
    {
        readonly BaseContext _db;

        public HistoricoRepository(BaseContext context)
        {
            _db = context;
        }

       

        public IEnumerable<Historico> GetAll()
        {
            return _db.Historico.ToList();
        }
        public IEnumerable<Historico> BuscarPorData(string dataInicial, string dataFinal)
        {
            var historico = _db.Historico.Where(e => e.dataTarefa >= Convert.ToDateTime(dataInicial) && e.dataTarefa <= Convert.ToDateTime(dataFinal)).ToList();
            return historico;
        }
        public async Task<int> Add(Historico model)
        {
            if (_db != null)
            {
                //model.UserId = null;
                await _db.Historico.AddAsync(model);
                var t = await _db.SaveChangesAsync();

                return model.codigo;
            }

            return 0;
        }

        //public Cte GetById(int Id)
        //{
        //    try
        //    {
        //        return _db.Users.Where(e => e.Id == Id).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        //log exception
        //        return null;
        //    }
        //}
        //public Author PostAuthor(Author author)
        //{
        //    try
        //    {
        //        if(_db!=null)
        //        {
        //            _db.Add(author);
        //            _db.SaveChanges();
        //            return author;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        //log exception
        //        return null;
        //    }
        //}

        //public Author UpdateAuthor(Author author)
        //{
        //    try
        //    {
        //        if (_db != null)
        //        {
        //            _db.Update(author);
        //            _db.SaveChanges();
        //            return author;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //log exception
        //        return null;
        //    }
        //}

        //public int DeleteAuthor(Guid authorId)
        //{
        //    try
        //    {
        //        if (_db != null)
        //        {
        //            var author = _db.Authors.FirstOrDefault(x => x.AuthorId== authorId);
        //            if(author!=null)
        //            {
        //                _db.Remove(author);
        //                return 1;
        //            }
        //            else
        //            {
        //                return 0;
        //            }
        //        }
        //        else
        //        {
        //            return 0;
        //        }


        //    }
        //    catch(Exception ex)
        //    {
        //        //log exception
        //        return 0;
        //    }
    }
}
