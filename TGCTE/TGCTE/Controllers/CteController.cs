using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TGCTE.Entities;
using TGCTE.Repository.Contract;

namespace TGCTE.Controllers
{
    [Route("api/Ctes")]
    [ApiController]
    public class CteController : ControllerBase
    {
        private readonly ICteRepository _CteRepository;



        public CteController(ICteRepository CteRepository)
        {
            _CteRepository = CteRepository;
        }

        // GET: api/Ctes
        [HttpGet]
        public IActionResult GetAll()
        {
            var ctes = _CteRepository.GetAll();
            return Ok(ctes);
        }
        // GET: api/Ctes/BuscarIntervaloData?datainicial=04/03/2020&&datafinal=04/03/2020
        [HttpGet("BuscarIntervaloData")]
        public IActionResult BuscarPorData(string datainicial,string datafinal)
        {
            var ctes = _CteRepository.BuscarPorData(datainicial,datafinal);
            return Ok(ctes);
        }




    }
}