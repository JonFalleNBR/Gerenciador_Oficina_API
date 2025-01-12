using Microsoft.EntityFrameworkCore;
using OficinaAPI.connection;
using OficinaAPI.Models;
using OficinaAPI.Repository;

namespace OficinaAPI.InfraEstrutura
{
    public class OrcamentoRepository : iOrcamentoRepository
    {
        private readonly OficinaContext _context;


        public OrcamentoRepository(OficinaContext context)
        {
            _context = context;
        }


        public async Task<Orcamento> GetOrcamentoByIdWithDetailsAsync(int id) // Retorna um orçamento pelo ID - OS
        {
            return await _context.Orcamento.Include(o => o.Veiculo)
                            .ThenInclude(v => v.Cliente)
                            .Include(o => o.Itens)
                            .FirstOrDefaultAsync(o => o.OrcamentoId == id);

        }


        public async Task<List<Orcamento>> GetAllOrcamentosWithDetailsAsync() // Retorna todos os orçamentos
        {
            return await _context.Orcamento.Include(o => o.Veiculo)
                            .ThenInclude(v => v.Cliente)
                            .Include(o => o.Itens)
                            .ToListAsync();
        }

        public Task AddAsync(Orcamento orcamento)
        {
            _context.Orcamento.Add(orcamento);
            return _context.SaveChangesAsync();
        }

        Task<Orcamento> iOrcamentoRepository.GetOrcamentoByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Orcamento>> iOrcamentoRepository.GetAllOrcamentosWithDetailsAsync()
        {
            throw new NotImplementedException();
        }


    }



}

