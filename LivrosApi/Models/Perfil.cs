using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrosApi.Models
{
    [Table("Perfil")]
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public Usuario Usuarios { get; set; }

    }
}
