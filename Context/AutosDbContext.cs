using Api2Postgresql.Models;
using Microsoft.EntityFrameworkCore;

namespace Api2Postgresql.Context
{
    public class AutosDbContext : DbContext
    {
        public AutosDbContext(DbContextOptions<AutosDbContext> options)
        : base(options)
        {

        }
        public DbSet<Autos> MarcaAutos { get; set; }

    }
}
