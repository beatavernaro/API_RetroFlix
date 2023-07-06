using Locadora02.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora02.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts) : base (opts)
        {

        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
    }
}
