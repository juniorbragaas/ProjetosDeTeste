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
    [Route("api/Filme")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilme<Filme> _filmeRepository;
       

     
        public FilmeController(IFilme<Filme> filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        // GET: api/Filme/ListarTodos
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult ListarTodos()
        {
            IEnumerable<Filme> filmes = _filmeRepository.ListarTodos();
            return Ok(filmes);
        }
        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]Filme model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = _filmeRepository.Cadastrar(model);
                    if (postId != null)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }




    }
}