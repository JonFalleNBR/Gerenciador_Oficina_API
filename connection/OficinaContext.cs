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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orcamento>()
                .HasMany(o => o.Itens)
                .WithOne(i => i.Orcamento)
                .HasForeignKey(i => i.OrcamentoId);

            modelBuilder.Entity<ItemOrcamento>()
                .HasOne(i => i.Orcamento)
                .WithMany(o => o.Itens)
                .HasForeignKey(i => i.OrcamentoId);
        }

    }
}
