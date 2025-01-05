using Microsoft.EntityFrameworkCore;
using OficinaAPI.connection;
using OficinaAPI.Models;
using OficinaAPI.Repository;

namespace OficinaAPI.InfraEstrutura
{
    public class ClienteRepository : iClienteRepository
    {

        // Implementação dos métodos da interface iClienteRepository

        private readonly OficinaContext _context;

        public ClienteRepository(OficinaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
           return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cliente cliente)
        {

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }
    }
}

