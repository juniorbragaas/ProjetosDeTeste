using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCrud.Repository
{
    public class UsersRepository : IUsers
    {

        APIContext db;
        public UsersRepository(APIContext _db)
        {
            db = _db;
        }

        public async Task<List<Users>> GetAll()
        {
            if (db != null)
            {
                return await db.Users.ToListAsync();
            }

            return null;
        }

        public async Task<Users> GetById(int? id)
        {
            if (db != null)
            {
                //Find the post for specific post id
                var user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user != null)
                {

                    return user;
                }
            }
            return null;
        }

        public async Task<int> Add(Users user)
        {
            if (db != null)
            {
                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();

                return user.Id;
            }

            return 0;
        }

        public async Task<int> Delete(int? id)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var user = await db.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user!= null)
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

        public async Task Update(Users user)
        {
            if (db != null)
            {
                //Delete that post
                db.Users.Update(user);

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }
    }
}
