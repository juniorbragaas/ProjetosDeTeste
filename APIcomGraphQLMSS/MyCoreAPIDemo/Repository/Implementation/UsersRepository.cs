using MyCoreAPIDemo.Entities;
using MyCoreAPIDemo.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.Repository.Implementation
{
    public class UsersRepository: IUsersRepository<Users>
    {
        readonly LibraryContext _libraryContext;

        public UsersRepository(LibraryContext context)
        {
            _libraryContext = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return _libraryContext.Users.ToList();
        }

        public Users GetById(int Id)
        {
            try
            {
                return _libraryContext.Users.Where(e => e.Id == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //log exception
                return null;
            }
        }
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
        //}
    }
}
