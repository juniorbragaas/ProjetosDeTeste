using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TGCTE.Entities;
using TGCTE.Repository.Contract;

namespace TGCTE.Controllers
{
    [Route("api/Fatura")]
    [ApiController]
    public class FaturaController : ControllerBase
    {
        private readonly IFaturaRepository _FaturaRepository;



        public FaturaController(IFaturaRepository FaturaRepository)
        {
            _FaturaRepository = FaturaRepository;
        }

        // GET api/Faturas
        /// <summary>
        /// Lista Faturas cadastrados .
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var Faturas = _FaturaRepository.GetAll();
            return Ok(Faturas);
        }
        // GET: api/Faturas/BuscarIntervaloData?datainicial=04/03/2020&&datafinal=04/03/2020
        /// <summary>
        /// Procura lista Faturas cadastrados entre um intervalo entre datas de envio.
        /// </summary>
        [HttpGet("BuscarIntervaloData")]
        public IActionResult BuscarPorData(string datainicial,string datafinal)
        {
            var Faturas = _FaturaRepository.BuscarPorData(datainicial,datafinal);
            return Ok(Faturas);
        }




    }
}