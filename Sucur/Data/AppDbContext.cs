using Microsoft.EntityFrameworkCore;
using Sucur.Models.Entities;

namespace Sucur.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<User> Usuarios { get; set; }

        // public DbSet<Vehicle> Vehiculo { get; set; }


    }
}
