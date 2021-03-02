using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Repository
{
    public interface ILocacaoRepository
    {
        Task<List<Locacao>> GetAll();

        Task<Locacao> GetById(int? Id);

        Task<int> Add(Locacao user);

        Task<int> Delete(int? Id);

        Task Update(Locacao user);

        Task<Locacao> VerificarSeClienteFezLocacao(int IdCliente);

        Task<Locacao> VerificarTituloDisponivel(int IdFilme);

        Task<Locacao> AlertarLocacaoAtrasada(DateTime DataEntrega,int idLocacao);
    }
}
