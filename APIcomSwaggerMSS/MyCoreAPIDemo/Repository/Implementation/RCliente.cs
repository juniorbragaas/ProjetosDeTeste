using MyCoreAPIDemo.Entities;
using MyCoreAPIDemo.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreAPIDemo.Repository.Implementation
{
    public class RCliente: ICliente<Cliente>
    {
        readonly ContextoBanco _ContextoBanco;

        public RCliente(ContextoBanco context)
        {
            _ContextoBanco = context;
        }

        public Cliente Cadastrar(Cliente dados)
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

        public IEnumerable<Cliente> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
