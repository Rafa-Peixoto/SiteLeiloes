using Microsoft.EntityFrameworkCore;
using SiteLeiloes.Data.Interfaces;
using SiteLeiloes.Models;

namespace SiteLeiloes.Data.Components
{
    public class LeilaoRepository : ILeilaoRepository
    {
        private readonly CarenseDBContext _context;

        public LeilaoRepository(CarenseDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Leilao>> GetAllAsync()
        {
            return await _context.Leilao.ToListAsync();
        }

        public async Task<Leilao> GetByIdAsync(int id)
        {
            return await _context.Leilao.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> CreateAsync(Leilao leilao)
        {
            try
            {
                await _context.Leilao.AddAsync(leilao);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // A exceção deve ser logada em um sistema de logs real
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Leilao leilao)
        {
            try
            {
                _context.Entry(leilao).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // A exceção deve ser logada em um sistema de logs real
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var leilao = await _context.Leilao.FindAsync(id);
                if (leilao == null)
                {
                    return false;
                }

                _context.Leilao.Remove(leilao);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // A exceção deve ser logada em um sistema de logs real
                return false;
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Leilao.AnyAsync(c => c.Id == id);
        }
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await _context.SaveChangesAsync()) >= 0;
            }
            catch (Exception)
            {
                // A exceção deve ser logada em um sistema de logs real
                return false;
            }
        }
        public async Task<Carro> GetCarroByIdAsync(int carroId)
        {
            return await _context.Carro.FirstOrDefaultAsync(c => c.Id == carroId);
        }

    }
}

