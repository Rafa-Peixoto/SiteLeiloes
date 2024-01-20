using Microsoft.EntityFrameworkCore;
using SiteLeiloes.Data.Interfaces;
using SiteLeiloes.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiteLeiloes.Data.Components
{
    public class LeilaoFavoritoRepository : ILeilaoFavoritoRepository
    {
        private readonly CarenseDBContext _context;
        private IEnumerable<LeilaoFavorito> _leilaofavorito = new List<LeilaoFavorito>();
        public LeilaoFavoritoRepository(CarenseDBContext context)
        {
            // Inicialize sua lista de leilaofavorito aqui, possivelmente carregando de um banco de dados
            _context = context;
        }

        public IEnumerable<LeilaoFavorito> GetAll()
        {
            return _context.LeilaoFavorito.ToList();
        }


        public LeilaoFavorito GetById(int id)
        {
            return _context.LeilaoFavorito.FirstOrDefault(c => c.Id == id);
        }

        public bool Create(LeilaoFavorito leilaofavorito)
        {
            try
            {
                _context.LeilaoFavorito.Add(leilaofavorito);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool Update(LeilaoFavorito leilaofavorito)
        {
            try
            {
                _context.Entry(leilaofavorito).State = EntityState.Modified;
                return SaveChanges();
            }
            catch (Exception)
            {
                // Log the exception
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var leilaofavorito = _context.LeilaoFavorito.FirstOrDefault(c => c.Id == id);
                if (leilaofavorito == null)
                {
                    return false;
                }

                _context.LeilaoFavorito.Remove(leilaofavorito);
                return SaveChanges();
            }
            catch (Exception)
            {
                // Log the exception
                return false;
            }
        }
    }
}