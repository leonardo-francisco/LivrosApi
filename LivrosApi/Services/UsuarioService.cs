using LivrosApi.Models;
using LivrosApi.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrosApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly LivroDbContext _context;
        public UsuarioService(LivroDbContext context)
        {
            _context = context;
        }

        public async Task CreateUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);               
                await _context.SaveChangesAsync();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }          
        }

        public async Task DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.Where(u => u.Id == id).Include(p => p.Perfil).FirstAsync();
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.Include(p => p.Perfil).ToListAsync();
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
