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
    [Route("api/Libraries")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly ILibraryRepository<Users> _libraryRepository;
       

     
        public LibrariesController(ILibraryRepository<Users> libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        // GET: api/Libraries/GetAllAuthor
        [HttpGet]
        [Route("Users")]
        public IActionResult GetAllAuthor()
        {
            IEnumerable<Users> authors = _libraryRepository.GetAllAuthor();
            return Ok(authors);
        }
        



    }
}