using AutoMapper;
using LivrosApi.Models;
using LivrosApi.Models.Dto;
using LivrosApi.Models.ViewModels;
using LivrosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosApiController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosApiController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IAsyncEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuarios();
                var model = usuarios.Select(u => new UsuarioViewModel
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email,
                    UserName = u.UserName,
                    Password = u.Password,
                    PerfilNome = u.Perfil.Nome
                });

                return Ok(model);
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter usuarios");
            }
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuario(id);

                if (usuario == null)
                    return NotFound($"Usuario não encontrado");

                var model = new UsuarioViewModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    UserName = usuario.UserName,
                    Password = usuario.Password,
                    PerfilNome = usuario.Perfil.Nome
                };

                return Ok(model);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario([FromBody] Usuario usuario)
        {
            try
            {
                await _usuarioService.CreateUsuario(usuario);
                var model = _mapper.Map<Usuario, UsuarioDto>(usuario);
                return CreatedAtRoute(nameof(GetUsuario), new { id = model.Id }, model);
            }
            catch
            {

                return BadRequest("Request inválido");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> EditUsuario(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (usuario.Id == id)
                {
                    await _usuarioService.UpdateUsuario(usuario);
                    return Ok($"Usuário com id={id} foi atualizado com sucesso");
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
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuario(id);
                if (usuario != null)
                {
                    await _usuarioService.DeleteUsuario(usuario.Id);
                    return Ok($"Usuário com id={id} foi excluído com sucesso");
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
