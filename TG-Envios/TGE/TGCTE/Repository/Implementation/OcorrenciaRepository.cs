using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TGCTE.Entities;
using TGCTE.Repository.Contract;

namespace TGTCE.Repository.Implementation
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        readonly BaseContext db;

        public OcorrenciaRepository(BaseContext _db)
        {
            db = _db;
        }

        public  List<Ocorrencia> GetAll()
        {
            if (db != null)
            {
                return  db.Ocorrencia.ToList(); ;
            }

            return null;
        }
        public List<Ocorrencia> BuscarPorData(string dataInicial, string dataFinal)
        {
            if (db != null)
            {
                return db.Ocorrencia.Where(e => e.dataEnvio >= Convert.ToDateTime(dataInicial) && e.dataEnvio <= Convert.ToDateTime(dataFinal)).ToList(); 
            }

            return null;
        }

        //public async Task<int> Delete(int? Id)
        //{
        //    int result = 0;

        //    if (db != null)
        //    {
        //        //Find the post for specific post id
        //        var user = await db.Users.FirstOrDefaultAsync(x => x.Id == Id);

        //        if (user != null)
        //        {
        //            //Delete that post
        //            db.Users.Remove(user);

        //            //Commit the transaction
        //            result = await db.SaveChangesAsync();
        //        }
        //        return result;
        //    }

        //    return result;
        //}

        //public async Task<Users> GetById(int? Id)
        //{
        //    if (db != null)
        //    {
        //        return await db.Users.SingleOrDefaultAsync(m => m.Id == Id);
        //    }

        //    return null;
        //}

        //public async Task Update(Users user)
        //{
        //    if (db != null)
        //    {
        //        db.Users.Update(user);
        //        await db.SaveChangesAsync();
        //    }
        //}
    }
}
