using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGCTE.Entities;
using TGCTE.Models;
using TGCTE.Repository.Contract;


namespace TGUsuarios.Repository.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        readonly BaseContext db;

        public LoginRepository(BaseContext _db)
        {
            db = _db;
        }

        public Usuarios Autenticar(Login model)
        {
            if (db != null)
            {
                return db.Usuarios.FirstOrDefault(m => m.UserName == model.UserName && m.Password == model.Password);
            }

            return null;
        }
    }
}
