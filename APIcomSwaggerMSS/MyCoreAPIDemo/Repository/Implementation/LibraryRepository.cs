using MyCoreAPIDemo.Entities;
using MyCoreAPIDemo.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.Repository.Implementation
{
    public class ClienteRepository : ILibraryRepository<Users>
    {
        readonly ContextoBanco _ContextoBanco;

        public ClienteRepository(ContextoBanco context)
        {
            _ContextoBanco = context;
        }

       

        public IEnumerable<Users> GetAllAuthor()
        {
            return _ContextoBanco.Users.ToList();
        }

        //public Author GetAuthor(Guid authorId)
        //{
        //    try
        //    {
        //        return _ContextoBanco.Authors.Where(e => e.AuthorId == authorId).FirstOrDefault();
        //    }
        //    catch(Exception ex)
        //    {
        //        //log exception
        //        return null;
        //    }
        //}
        //public Author PostAuthor(Author author)
        //{
        //    try
        //    {
        //        if(_ContextoBanco!=null)
        //        {
        //            _ContextoBanco.Add(author);
        //            _ContextoBanco.SaveChanges();
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
        //        if (_ContextoBanco != null)
        //        {
        //            _ContextoBanco.Update(author);
        //            _ContextoBanco.SaveChanges();
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
        //        if (_ContextoBanco != null)
        //        {
        //            var author = _ContextoBanco.Authors.FirstOrDefault(x => x.AuthorId== authorId);
        //            if(author!=null)
        //            {
        //                _ContextoBanco.Remove(author);
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
        //}
    }
}
