using System;
using System.Collections.Generic;
using System.Linq;
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

        // GET: api/Libraries/GetAll
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Cte> ctes = _CteRepository.GetAll();
            return Ok(ctes);
        }




    }
}