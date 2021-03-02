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
       
        


    }
}
