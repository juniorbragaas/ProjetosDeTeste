using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TGCTE.Entities
{
    public class Login
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
    public class Registration : Usuarios { }
}
