using OficinaAPI.Models;

namespace OficinaAPI.Repository
{

   
    public interface iClienteRepository
    {

        Task<IEnumerable<Cliente>> GetAllAsync(); // Retorna uma lista de clientes
        Task<Cliente> GetByIdAsync(int id);       // Retorna um cliente pelo ID
        Task AddAsync(Cliente cliente);           // Adiciona um cliente
        Task UpdateAsync(Cliente cliente);        // Atualiza um cliente
        Task DeleteAsync(Cliente cliente);

    }
}
