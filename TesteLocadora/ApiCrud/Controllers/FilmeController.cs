using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCrud.Models;
using ApiCrud.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ApiCrud.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        IFilmeRepository FilmeRepository;
        public FilmeController(IFilmeRepository _FilmeRepository)
        {
            FilmeRepository = _FilmeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var Filme = await FilmeRepository.GetAll();
                if (Filme== null)
                {
                    return NotFound();
                }

                return Ok(Filme);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]Filme model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await FilmeRepository.Add(model);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return BadRequest();
                }

            }

            return BadRequest();
        }
       
        


    }
}
