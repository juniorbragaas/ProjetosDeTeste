using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGCTE.Entities;
using TGCTE.Repository.Contract;

namespace TGCTE.Repository.Implementation
{
    public class CteRepository : ICteRepository
    {
        readonly BaseContext _libraryContext;

        public CteRepository(BaseContext context)
        {
            _libraryContext = context;
        }

        public IEnumerable<Cte> GetAll()
        {
            return _libraryContext.Cte.ToList();
        }

        //public Cte GetById(int Id)
        //{
        //    try
        //    {
        //        return _libraryContext.Users.Where(e => e.Id == Id).FirstOrDefault();
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
        //        if(_libraryContext!=null)
        //        {
        //            _libraryContext.Add(author);
        //            _libraryContext.SaveChanges();
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
        //        if (_libraryContext != null)
        //        {
        //            _libraryContext.Update(author);
        //            _libraryContext.SaveChanges();
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
        //        if (_libraryContext != null)
        //        {
        //            var author = _libraryContext.Authors.FirstOrDefault(x => x.AuthorId== authorId);
        //            if(author!=null)
        //            {
        //                _libraryContext.Remove(author);
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
