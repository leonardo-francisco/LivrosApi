using LivrosApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LivrosApi.Services
{
    public interface ILivroService
    {
        Task<IEnumerable<Livro>> GetLivros();
        Task<Livro> GetLivro(int id);
        Task CreateLivro(Livro livro);
        Task UpdateLivro(Livro livro);  
        Task DeleteLivro(int id);
    }
}
