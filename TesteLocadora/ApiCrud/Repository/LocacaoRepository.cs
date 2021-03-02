using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Repository
{
    public class LocacaoRepository : ILocacaoRepository
    {
        APIContext db;
        public LocacaoRepository(APIContext _db)
        {
            db = _db;
        }

        public async Task<int> Add(Locacao user)
        {
            if (db != null)
            {
                //user.Id = db.Locacao.Max(x => x.Id) + 1;
                await db.Locacao.AddAsync(user);
                await db.SaveChangesAsync();

                return user.Id;
            }

            return 0;
        }

        public async  Task<Locacao> AlertarLocacaoAtrasada(DateTime DataEntrega, int idLocacao)
        {
            var registro = await db.Locacao.SingleOrDefaultAsync(m => m.Id == idLocacao);
            if (registro != null)
            {
                if(DataEntrega > registro.DataFimLocacao)
                {
                    return registro;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        public async Task<int> Delete(int? Id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var user = await db.Locacao.FirstOrDefaultAsync(x => x.Id == Id);

                if (user != null)
                {
                    //Delete that post
                    db.Locacao.Remove(user);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Locacao>> GetAll()
        {
            if (db != null)
            {
                return await db.Locacao.ToListAsync();
            }

            return null;
        }

        public async  Task<Locacao> GetById(int? Id)
        {
            if (db != null)
            {
                return await db.Locacao.SingleOrDefaultAsync(m => m.Id == Id);
            }

            return null;
        }

        public async Task Update(Locacao user)
        {
            if (db != null)
            {      
                db.Locacao.Update(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Locacao> VerificarSeClienteFezLocacao(int IdCliente)
        {
            if (db != null)
            {
                return await db.Locacao.LastOrDefaultAsync(m => m.IdCliente == IdCliente);
            }
            return null;
        }

        public async Task<Locacao> VerificarTituloDisponivel(int IdFilme)
        {
            if (db != null)
            {
                return await db.Locacao.LastOrDefaultAsync(m => m.IdFilme == IdFilme);
            }
            return null;
        }
    }
}
