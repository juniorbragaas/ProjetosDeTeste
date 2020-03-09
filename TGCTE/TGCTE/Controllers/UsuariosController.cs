using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TGCTE.Entities;
using TGCTE.Models;
using TGCTE.Repository.Contract;

namespace TGUsuarios.Controllers
{

    [Route("api/Usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _UsuariosRepository;



        public UsuariosController(IUsuariosRepository UsuariosRepository)
        {
            _UsuariosRepository = UsuariosRepository;
        }

        // GET: api/Usuarios
        /// <summary>
        /// Lista usuários Cadastrados.
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var Usuarios = _UsuariosRepository.GetAll();
            return Ok(Usuarios);
        }

        /// POST: /api/Usuarios/Adicionar
        /// <summary>
        /// Adiciona um novo usuário.
        /// </summary>
        [HttpPost]
        [Route("Adicionar")]
        public async Task<object> AddPost([FromBody]Usuarios model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await _UsuariosRepository.Add(model);
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

        /// POST: /api/Usuarios/{id}
        /// <summary>
        /// Procura usuario pelo seu Id.
        /// </summary>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var post =  _UsuariosRepository.GetById(Id);

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

        /// DELETE: /api/Usuarios/Delete/{(id)}
        /// <summary>
        /// Apaga um usuario com a Id escolhida.
        /// </summary>
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int? Id)
        {
            int result = 0;

            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                result = _UsuariosRepository.Delete(Id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(Id);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        /// PUT: /api/Usuarios/Update
        /// <summary>
        /// Atualiza dados de um usuário.
        /// </summary>
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdatePost([FromBody]Usuarios model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _UsuariosRepository.Update(model);

                    return Ok(model);
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