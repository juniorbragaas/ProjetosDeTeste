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
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente<Cliente> _clienteRepository;
       

     
        public ClienteController(ICliente<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: api/Cliente/ListarTodos
        [HttpGet]
        [Route("ListarTodos")]
        public IActionResult GetAllAuthor()
        {
            IEnumerable<Cliente> clientes = _clienteRepository.ListarTodos();
            return Ok(clientes);
        }
        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]Cliente model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId =   _clienteRepository.Cadastrar(model);
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