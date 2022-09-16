using LivrosApi.Models;
using LivrosApi.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrosApi.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task CreateUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(int id);
    }
}
