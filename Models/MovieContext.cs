using Microsoft.EntityFrameworkCore;

namespace Lab4.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
