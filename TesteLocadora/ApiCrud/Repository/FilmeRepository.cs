using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        APIContext db;
        public FilmeRepository(APIContext _db)
        {
            db = _db;
        }

        public async Task<int> Add(Filme user)
        {
            if (db != null)
            {
                //user.Id = db.Filme.Max(x => x.Id) + 1;
                await db.Filme.AddAsync(user);
                await db.SaveChangesAsync();

                return user.Id;
            }

            return 0;
        }

        public async Task<int> Delete(int? Id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var user = await db.Filme.FirstOrDefaultAsync(x => x.Id == Id);

                if (user != null)
                {
                    //Delete that post
                    db.Filme.Remove(user);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Filme>> GetAll()
        {
            if (db != null)
            {
                return await db.Filme.ToListAsync();
            }

            return null;
        }

        public async  Task<Filme> GetById(int? Id)
        {
            if (db != null)
            {
                return await db.Filme.SingleOrDefaultAsync(m => m.Id == Id);
            }

            return null;
        }

        public async Task Update(Filme user)
        {
            if (db != null)
            {      
                db.Filme.Update(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
