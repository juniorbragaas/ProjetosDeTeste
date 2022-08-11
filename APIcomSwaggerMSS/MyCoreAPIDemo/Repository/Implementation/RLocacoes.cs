using MyCoreAPIDemo.Entities;
using MyCoreAPIDemo.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.Repository.Implementation
{
    public class RLocacoes: ILocacoes<Locacoes>
    {
        readonly ContextoBanco _ContextoBanco;

        public RLocacoes(ContextoBanco context)
        {
            _ContextoBanco = context;
        }

        public Locacoes AlertarAtraso(Locacoes dados)
        {
            throw new NotImplementedException();
        }

        public Locacoes Cadastrar(Locacoes dados)
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

        public IEnumerable<Locacoes> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Locacoes VericarSeExisteLocacao(Locacoes dados)
        {
            throw new NotImplementedException();
        }
    }
}
