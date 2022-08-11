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
    [Route("api/Locacoes")]
    [ApiController]
    public class LocacoesController : ControllerBase
    {
        private readonly ILocacoes<Locacoes> _locacoesRepository;
       

     
        public LocacoesController(ILocacoes<Locacoes> locacoesRepository)
        {
            _locacoesRepository = locacoesRepository;
        }

        // GET: api/Libraries/GetAllAuthor
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult GetAllAuthor()
        {
            IEnumerable<Locacoes> locacoes = _locacoesRepository.ListarTodos();
            return Ok(locacoes);
        }
        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]Locacoes model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = _locacoesRepository.Cadastrar(model);
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