using LivrosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosApi
{
    public class LivroDbContext :DbContext
    {
        public LivroDbContext(DbContextOptions<LivroDbContext> options) : base(options)
        {
            
        }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfil { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfil>()
            .HasOne<Usuario>(s => s.Usuarios)
            .WithOne(ad => ad.Perfil)
            .HasForeignKey<Usuario>(ad => ad.PerfilId);
        }
    }
}
