using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCoreAPIDemo.Entities;
using MyCoreAPIDemo.Repository.Contract;

namespace MyCoreAPIDemo.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository<Users> _UsersRepository;
       

     
        public UsersController(IUsersRepository<Users> UsersRepository)
        {
            _UsersRepository = UsersRepository;
        }

        // GET: api/Libraries/GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Users> authors = _UsersRepository.GetAll();
            return Ok(authors);
        }
        



    }
}