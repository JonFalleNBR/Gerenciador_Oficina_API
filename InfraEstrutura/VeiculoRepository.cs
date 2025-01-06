using Microsoft.EntityFrameworkCore;
using OficinaAPI.connection;
using OficinaAPI.Models;
using OficinaAPI.Repository;

namespace OficinaAPI.InfraEstrutura
{
    public class VeiculoRepository : iVeiculoRepository
    {

        private readonly OficinaContext _context;

        public VeiculoRepository(OficinaContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Veiculo veiculo)
        {
            _context.Veiculo.Add(veiculo);
            _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(Veiculo veiculo)
        {

            _context.Veiculo.Remove(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Veiculo>> GetAllAsync()
        {
            return await _context.Veiculo.ToListAsync();
        }

        public async Task<Veiculo> GetByIdAsync(int id)
        {
            return await _context.Veiculo.FindAsync(id);

        }

        public async Task UpdateAsync(Veiculo veiculo)
        {

            _context.Veiculo.Update(veiculo);
            await _context.SaveChangesAsync();
        }
    }
}
