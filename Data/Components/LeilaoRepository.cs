using Microsoft.EntityFrameworkCore;
using SiteLeiloes.Data.Interfaces;
using SiteLeiloes.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiteLeiloes.Data.Components
{
    public class LeilaoRepository : ILeilaoRepository
    {
        private readonly CarenseDBContext _context;
        private IEnumerable<Leilao> _leilao = new List<Leilao>();
        public LeilaoRepository(CarenseDBContext context)
        {
            // Inicialize sua lista de leiloes aqui, possivelmente carregando de um banco de dados
            _context = context;
        }

        public IEnumerable<Leilao> GetAll()
        {
            return _context.Leilao.ToList();
        }


        public Leilao GetById(int id)
        {
            return _context.Leilao.FirstOrDefault(c => c.Id == id);
        }

        public bool Create(Leilao leilao)
        {
            try
            {
                _context.Leilao.Add(leilao);
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

        public bool Update(Leilao leilao)
        {
            try
            {
                _context.Entry(leilao).State = EntityState.Modified;
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
                var leilao = _context.Leilao.FirstOrDefault(c => c.Id == id);
                if (leilao == null)
                {
                    return false;
                }

                _context.Leilao.Remove(leilao);
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

