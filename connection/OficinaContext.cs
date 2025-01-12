using Microsoft.EntityFrameworkCore;
using OficinaAPI.Models;

namespace OficinaAPI.connection
{
    public class OficinaContext : DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Orcamento> Orcamento { get; set; }

        public DbSet<ItemOrcamento> ItemOrcamento { get; set; }



        public OficinaContext(DbContextOptions<OficinaContext> options) : base(options)
        {



        }
    }
}
