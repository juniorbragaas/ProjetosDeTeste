using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Repository
{
    public class UsersRepository : IUsersRepository
    {
        APIContext db;
        public UsersRepository(APIContext _db)
        {
            db = _db;
        }

        public async Task<int> Add(Users user)
        {
            if (db != null)
            {
                user.Id = db.Users.Max(x => x.Id) + 1;
                await db.Users.AddAsync(user);
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
                var user = await db.Users.FirstOrDefaultAsync(x => x.Id == Id);

                if (user != null)
                {
                    //Delete that post
                    db.Users.Remove(user);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Users>> GetAll()
        {
            if (db != null)
            {
                return await db.Users.ToListAsync();
            }

            return null;
        }

        public async  Task<Users> GetById(int? Id)
        {
            if (db != null)
            {
                return await db.Users.SingleOrDefaultAsync(m => m.Id == Id);
            }

            return null;
        }

        public async Task Update(Users user)
        {
            if (db != null)
            {      
                db.Users.Update(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
