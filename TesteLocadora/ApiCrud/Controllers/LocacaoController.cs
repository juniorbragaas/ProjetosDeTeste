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
    public class LocacaoController : ControllerBase
    {

        ILocacaoRepository LocacaoRepository;
        public LocacaoController(ILocacaoRepository _LocacaoRepository)
        {
            LocacaoRepository = _LocacaoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            try
            {
                var Locacao = await LocacaoRepository.GetAll();
                if (Locacao== null)
                {
                    return NotFound();
                }

                return Ok(Locacao);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ProcurarPorId(int? Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await LocacaoRepository.GetById(Id);

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
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody]Locacao model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var verificarLocacao = await LocacaoRepository.VerificarSeClienteFezLocacao(model.IdCliente);
                    if (verificarLocacao != null)
                    {
                        if (verificarLocacao.DataFimLocacao >= DateTime.Now)
                        {
                            return Ok("Esse Cliente já alugou um filme");
                        }
                    }
                    var verificarTitulo = await LocacaoRepository.VerificarTituloDisponivel(model.IdFilme);
                    if (verificarTitulo != null)
                    {
                        if (verificarTitulo.DataFimLocacao >= DateTime.Now)
                        {
                            return Ok("Esse Titulo ja foi alugado com data prevista de entraga para " + verificarTitulo.DataFimLocacao);
                        }
                    }

                    var postId = await LocacaoRepository.Add(model);
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
        [HttpDelete]
        [Route("Apagar")]
        public async Task<IActionResult> Apagar(int? Id)
        {
            int result = 0;

            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                result = await LocacaoRepository.Delete(Id);
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
        [Route("Atualizar")]
        public async Task<IActionResult> UpdatePost([FromBody]Locacao model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await LocacaoRepository.Update(model);

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
        [HttpGet("VerificarSeClienteFezLocacao/{id}")]
        public async Task<IActionResult> VerificarSeClienteFezLocacao(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await LocacaoRepository.VerificarSeClienteFezLocacao(Id);

                if (post == null)
                {
                    return Ok("Esse Cliente não está com nenhum filme recentemente");
                }
                else
                {
                    if (post.DataFimLocacao >= DateTime.Now)
                    {
                        return Ok("Esse Cliente já alugou um filme");
                    }
                    else
                    {
                        return Ok("Esse Cliente não está com nenhum filme recentemente");
                    }
                }

                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("VerificarTituloDisponivel/{id}")]
        public async Task<IActionResult> VerificarTituloDisponivel(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await LocacaoRepository.VerificarTituloDisponivel(Id);

                if (post == null)
                {
                    return Ok("Esse Filme esta disponivel");
                }
                else
                {
                    if (post.DataFimLocacao >= DateTime.Now)
                    {
                        return Ok("Esse Filme já esta alugado com data de entrega prevista para : " + post.DataFimLocacao);
                    }
                    else
                    {
                        return Ok("Esse Filme esta disponivel"); ;
                    }
                }


            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("AlertarLocacaoAtrasada/{id}")]
        public async Task<IActionResult> AlertarLocacaoAtrasada(DateTime DataEntrega, int idLocacao)
        {
           

            try
            {
                var post = await LocacaoRepository.AlertarLocacaoAtrasada(DataEntrega, idLocacao);

                if (post == null)
                {
                    return null;
                }
                else
                {
                        return Ok("A locacao do cliente " + post.IdCliente + " esta atrasada em : " + DataEntrega.Subtract(post.DataFimLocacao).Days); 
                }


            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
