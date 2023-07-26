using Microsoft.EntityFrameworkCore;
using PracticePeli.Entity;

namespace PracticePeli
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Actor> Actores { get; set; }

        public DbSet<Genero> Generos { get; set; }
    }
}
