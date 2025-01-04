using OficinaAPI.connection;
using OficinaAPI.Models;
using OficinaAPI.Repository;

namespace OficinaAPI.InfraEstrutura
{
    public class ClienteRepository : iClienteRepository
    {

        // Implementação dos métodos da interface iClienteRepository

        private readonly OficinaContext _context = new OficinaContext();



        public void add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges(); 
        }
        public List<Cliente> getAll()
        {
            return _context.Clientes.ToList();

        }

        public Cliente getById(int id)
        {
           return _context.Clientes.Find(id);
        }

        public void update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);            
            _context.SaveChanges();
        }

        public void delete(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

    }
}

