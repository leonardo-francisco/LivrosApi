using LivrosApi.Models;
using LivrosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosApiController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosApiController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IAsyncEnumerable<Livro>>> GetLivros()
        {
            try
            {
                var livros = await _livroService.GetLivros();
                return Ok(livros);
            }
            catch 
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter livros");
            }
        }

        [HttpGet("{id}", Name ="GetLivro")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            try
            {
                var livros = await _livroService.GetLivro(id);

                if(livros == null)
                    return NotFound($"Livro não encontrado");

                return Ok(livros);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> CreateLivro([FromBody]Livro livro)
        {
            try
            {
                await _livroService.CreateLivro(livro);
                return CreatedAtRoute(nameof(GetLivro), new {id = livro.Id}, livro);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Livro>> EditLivro(int id, [FromBody]Livro livro)
        {
            try
            {
                if (livro.Id == id)
                {
                    await _livroService.UpdateLivro(livro);
                    return Ok($"Livro com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpDelete]
        public async Task<ActionResult<Livro>> DeleteLivro(int id)
        {
            try
            {
                var livro = await _livroService.GetLivro(id);
                if (livro != null)
                {
                    await _livroService.DeleteLivro(livro.Id);
                    return Ok($"Livro com id={id} foi excluído com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

    }
}
