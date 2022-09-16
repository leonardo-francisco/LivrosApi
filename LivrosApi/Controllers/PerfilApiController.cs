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
    public class PerfilApiController : ControllerBase
    {
        private readonly IPerfilService _perfilService;
        public PerfilApiController(IPerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IAsyncEnumerable<Perfil>>> GetPerfils()
        {
            try
            {
                var perfils = await _perfilService.GetPerfils();
                return Ok(perfils);
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter perfils");
            }
        }

        [HttpGet("{id}", Name = "GetPerfil")]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
            try
            {
                var perfil = await _perfilService.GetPerfil(id);

                if (perfil == null)
                    return NotFound($"Perfil não encontrado");

                return Ok(perfil);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }
    }
}
