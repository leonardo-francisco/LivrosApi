using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrosApi.Models
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Classificacao { get; set; }
        public int Ano { get; set; }
        public string Editora { get; set; }
    }
}
