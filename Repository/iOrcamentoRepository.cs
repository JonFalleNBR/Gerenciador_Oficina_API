using OficinaAPI.Models;

namespace OficinaAPI.Repository
{
    public interface iOrcamentoRepository
    {


        Task<Orcamento> GetOrcamentoByIdWithDetailsAsync(int id);

        Task<List<Orcamento>> GetAllOrcamentosWithDetailsAsync();

        Task AddAsync(Orcamento orcamento);

    }
}
