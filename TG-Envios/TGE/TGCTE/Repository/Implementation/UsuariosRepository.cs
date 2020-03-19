using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGCTE.Entities;
using TGCTE.Repository.Contract;


namespace TGUsuarios.Repository.Implementation
{
    public class UsuariosRepository : IUsuariosRepository
    {
        readonly BaseContext db;

        public UsuariosRepository(BaseContext _db)
        {
            db = _db;
        }

       

        public  List<Usuarios> GetAll()
        {
            if (db != null)
            {
                return  db.Usuarios.ToList();
            }

            return null;
        }


        public async Task<int> Add(Usuarios model)
        {
            if (db != null)
            {
                //model.UserId = null;
                await db.Usuarios.AddAsync(model);
                var t = await db.SaveChangesAsync();

                return model.UserId;
            }

            return 0;
        }

        public Usuarios GetById(int Id)
        {
            if (db != null)
            {
                return  db.Usuarios.SingleOrDefault(m => m.UserId == Id);
            }

            return null;
        }

        public Usuarios Update(Usuarios model)
        {
            if (db != null)
            {
                db.Usuarios.Update(model);
                db.SaveChanges();
                return model;
            }
            return null;
        }

        public  int Delete(int? Id)
        {
          

            if (db != null)
            {
                //Find the post for specific post id
                Usuarios user = db.Usuarios.FirstOrDefault(x => x.UserId == Id);

                if (user != null)
                {
                    //Delete that post
                    db.Usuarios.Remove(user);
                    db.SaveChangesAsync();
                    //Commit the transaction
                    return 1;
                }
            }
            return 0;
        }
    }
}
