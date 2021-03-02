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
        [HttpGet("{id}")]
        public async Task<IActionResult> ProcurarPorId(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await FilmeRepository.GetById(Id);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
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
        [HttpDelete]
        [Route("Apagar")]
        public async Task<IActionResult> Apagar(int? Id)
        {
            int result = 0;

            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await FilmeRepository.Delete(Id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> UpdatePost([FromBody]Filme model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await FilmeRepository.Update(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }


    }
}
