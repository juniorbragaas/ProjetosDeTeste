using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly APIContext _context;
        public UsersController(APIContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Users> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public async Task<Users> GetById(int? id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            return user;
        }
    }
}
