using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrosApi.Services
{
    public class LivroService : ILivroService
    {
        private readonly LivroDbContext _context;
        public LivroService(LivroDbContext context)
        {
            _context = context;
        }

        public async Task CreateLivro(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if(livro != null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
               
        }

        public async Task<Livro> GetLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            return livro;
        }

        public async Task<IEnumerable<Livro>> GetLivros()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task UpdateLivro(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
