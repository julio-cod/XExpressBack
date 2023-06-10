using Microsoft.EntityFrameworkCore;
using XExpressBack._2.Models.Entities;

namespace XExpressBack._3.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<DireccionModel> Direcciones { get; set; }

    }
}
