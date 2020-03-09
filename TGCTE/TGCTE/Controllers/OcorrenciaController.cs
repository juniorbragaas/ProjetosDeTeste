using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TGCTE.Entities;
using TGCTE.Repository.Contract;

namespace TGCTE.Controllers
{
    [Route("api/Ocorrencia")]
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        private readonly IOcorrenciaRepository _OcorrenciaRepository;



        public OcorrenciaController(IOcorrenciaRepository OcorrenciaRepository)
        {
            _OcorrenciaRepository = OcorrenciaRepository;
        }

        // GET api/Ocorrencias
        /// <summary>
        /// Lista Ocorrencias cadastrados .
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var Ocorrencias = _OcorrenciaRepository.GetAll();
            return Ok(Ocorrencias);
        }
        // GET: api/Ocorrencias/BuscarIntervaloData?datainicial=04/03/2020&&datafinal=04/03/2020
        /// <summary>
        /// Procura lista Ocorrencias cadastrados entre um intervalo entre datas de envio.
        /// </summary>
        [HttpGet("BuscarIntervaloData")]
        public IActionResult BuscarPorData(string datainicial,string datafinal)
        {
            var Ocorrencias = _OcorrenciaRepository.BuscarPorData(datainicial,datafinal);
            return Ok(Ocorrencias);
        }




    }
}