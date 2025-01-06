using OficinaAPI.Models;

namespace OficinaAPI.Repository
{
    public interface iVeiculoRepository
    {
        public Task<IEnumerable<Veiculo>> GetAllAsync();

        public Task <Cliente> GetClienteByIdAsync(int id);

        public Task<Veiculo> GetByIdAsync(int id);

        public Task AddAsync(Veiculo veiculo);

        public Task UpdateAsync(Veiculo veiculo);

        public Task DeleteAsync(Veiculo veiculo);




    }
}
