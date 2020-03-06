using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TGCTE.Entities;
using TGCTE.Repository.Contract;

namespace TGUsuarios.Controllers
{
    [Route("api/Usuarios")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;



        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        ///POST /api/Usuarios/Autenticar
        /// <summary>
        /// Login(Procura usuário por nome e senha).
        /// </summary>
        [HttpPost]
        [Route("Autenticar")]
        public async Task<object> Autenticar([FromBody]Login model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dadosUsuario = _loginRepository.Autenticar(model);
                    if (dadosUsuario != null)
                    {
                        return dadosUsuario;
                    }
                    else
                    {
                        return new Response { Status = "Error", Message = "Nome de usuário ou senha incorretos." };
                    }
                }
                catch (Exception e)
                {
                    var y = e;
                    return BadRequest();
                }

            }

            return BadRequest();
        }





    }
}