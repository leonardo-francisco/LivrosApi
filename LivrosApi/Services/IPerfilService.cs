using LivrosApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrosApi.Services
{
    public interface IPerfilService
    {
        Task<IEnumerable<Perfil>> GetPerfils();
        Task<Perfil> GetPerfil(int id);
    }
}
