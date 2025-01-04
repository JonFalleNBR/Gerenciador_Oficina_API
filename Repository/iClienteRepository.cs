using OficinaAPI.Models;

namespace OficinaAPI.Repository
{

   
    public interface iClienteRepository
    {

        void add(Cliente cliente);

        void update(Cliente cliente);

        void delete(Cliente cliente);

        Cliente getById(int id);

        List<Cliente> getAll();

    }
}
