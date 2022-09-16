using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LivrosApi.Models
{
    [Table("Usuarios")]
    public class Usuario
    {

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PerfilId { get; set; }

        public Perfil Perfil { get; set; }
    }
}
