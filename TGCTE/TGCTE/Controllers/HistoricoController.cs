using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TGCTE.Entities;
using TGCTE.Repository.Contract;

namespace TGCTE.Controllers
{
    [Route("api/Historico")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        private readonly IHistoricoRepository _HistoricoRepository;



        public HistoricoController(IHistoricoRepository HistoricoRepository)
        {
            _HistoricoRepository = HistoricoRepository;
        }

        // GET: api/Historico
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Historico> historico = _HistoricoRepository.GetAll();
            return Ok(historico);
        }
        // GET: api/Historico/BuscarIntervaloData?datainicial=04/03/2020&&datafinal=04/03/2020
        [HttpGet("BuscarIntervaloData")]
        public IActionResult BuscarPorData(string datainicial,string datafinal)
        {
            IEnumerable<Historico> ctes = _HistoricoRepository.BuscarPorData(datainicial,datafinal);
            return Ok(ctes);
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<object> AddPost([FromBody]Historico model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _HistoricoRepository.Add(model);
                    if (postId > 0)
                    {
                        return new Response { Status = "Success", Message = "SuccessFully Saved." };
                    }
                    else
                    {
                        return new Response { Status = "Error", Message = "Invalid Data." };
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