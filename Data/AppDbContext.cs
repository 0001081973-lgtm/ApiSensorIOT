using ApiSensoresIOT.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiSensoresIOT.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Sensor> Sensores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
