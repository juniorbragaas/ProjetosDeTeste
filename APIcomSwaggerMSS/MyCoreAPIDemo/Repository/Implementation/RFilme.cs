using MyCoreAPIDemo.Entities;
using MyCoreAPIDemo.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.Repository.Implementation
{
    public class RFilme: IFilme<Filme>
    {
        readonly ContextoBanco _ContextoBanco;

        public RFilme(ContextoBanco context)
        {
            _ContextoBanco = context;
        }

        public Filme Cadastrar(Filme dados)
        {

                try
                {
                    if (_ContextoBanco != null)
                    {
                        _ContextoBanco.Add(dados);
                        _ContextoBanco.SaveChanges();
                        return dados;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    //log exception
                    return null;
                }
            
        }

        public IEnumerable<Users> GetAllAuthor()
        {
            return _ContextoBanco.Users.ToList();
        }

        public IEnumerable<Filme> ListarTodos()
        {
            throw new NotImplementedException();
        }

       
    }
}
