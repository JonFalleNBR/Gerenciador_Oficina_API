using Microsoft.EntityFrameworkCore;
using OficinaAPI.Models;

namespace OficinaAPI.connection
{
    public class OficinaContext : DbContext
    {

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<DescricaoServico> DescricaoServicos { get; set; }


        public OficinaContext(DbContextOptions<OficinaContext> options) : base(options)
        {



        }
    }
}
