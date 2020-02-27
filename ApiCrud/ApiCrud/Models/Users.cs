using System;
using System.Collections.Generic;

namespace ApiCrud.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
