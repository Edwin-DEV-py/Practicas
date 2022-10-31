using Microsoft.EntityFrameworkCore;

namespace prueba.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public virtual DbSet<Usuario> Usuarios { get; set; } = default!;
    }
}
