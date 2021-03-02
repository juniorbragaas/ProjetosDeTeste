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
    public class ClienteController : ControllerBase
    {

        IClienteRepository clienteRepository;
        public ClienteController(IClienteRepository _clienteRepository)
        {
            clienteRepository = _clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var Cliente = await clienteRepository.GetAll();
                if (Cliente== null)
                {
                    return NotFound();
                }

                return Ok(Cliente);
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
                var post = await clienteRepository.GetById(Id);

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
        public async Task<IActionResult> Adicionar([FromBody]Cliente model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await clienteRepository.Add(model);
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
                result = await clienteRepository.Delete(Id);
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
        public async Task<IActionResult> UpdatePost([FromBody]Cliente model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await clienteRepository.Update(model);

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
