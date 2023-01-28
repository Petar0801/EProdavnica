
using CoreClassLib.Model.Entitis;
using Microsoft.EntityFrameworkCore;

namespace Infrascture.InfrasctureClassLib.Data
{
    public class EProdavnicaDbContext : DbContext
    {
        public EProdavnicaDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Prodcts { get; set; }
    }
}
