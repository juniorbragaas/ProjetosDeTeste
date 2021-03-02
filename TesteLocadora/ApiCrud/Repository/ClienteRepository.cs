using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        APIContext db;
        public ClienteRepository(APIContext _db)
        {
            db = _db;
        }

        public async Task<int> Add(Cliente user)
        {
            if (db != null)
            {
                //user.Id = db.Cliente.Max(x => x.Id) + 1;
                await db.Cliente.AddAsync(user);
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
                var user = await db.Cliente.FirstOrDefaultAsync(x => x.Id == Id);

                if (user != null)
                {
                    //Delete that post
                    db.Cliente.Remove(user);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Cliente>> GetAll()
        {
            if (db != null)
            {
                return await db.Cliente.ToListAsync();
            }

            return null;
        }

        public async  Task<Cliente> GetById(int? Id)
        {
            if (db != null)
            {
                return await db.Cliente.SingleOrDefaultAsync(m => m.Id == Id);
            }

            return null;
        }

        public async Task Update(Cliente user)
        {
            if (db != null)
            {      
                db.Cliente.Update(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
