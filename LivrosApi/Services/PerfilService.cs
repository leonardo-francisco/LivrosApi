using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrosApi.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly LivroDbContext _context;
        public PerfilService(LivroDbContext context)
        {
            _context = context;
        }

        public async Task<Perfil> GetPerfil(int id)
        {
            var perfil = await _context.Perfil.FindAsync(id);
            return perfil;
        }

        public async Task<IEnumerable<Perfil>> GetPerfils()
        {
            return await _context.Perfil.ToListAsync();
        }
    }
}
