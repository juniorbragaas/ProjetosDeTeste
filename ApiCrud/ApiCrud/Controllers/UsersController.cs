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
    public class UsersController : ControllerBase
    {

        IUsersRepository userRepository;
        public UsersController(IUsersRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await userRepository.GetAll();
                if (users== null)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await userRepository.GetById(Id);

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
        [Route("Add")]
        public async Task<IActionResult> AddPost([FromBody]Users model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await userRepository.Add(model);
                    if (postId > 0)
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
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeletePost(int? Id)
        {
            int result = 0;

            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await userRepository.Delete(Id);
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
        [Route("Update")]
        public async Task<IActionResult> UpdatePost([FromBody]Users model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await userRepository.Update(model);

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
