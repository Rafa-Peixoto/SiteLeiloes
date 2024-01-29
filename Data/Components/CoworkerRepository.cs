using Microsoft.EntityFrameworkCore;
using SiteLeiloes.Data.Interfaces;
using SiteLeiloes.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiteLeiloes.Data.Components
{
    public class CoworkerRepository : ICoworkerRepository
    {
        private readonly CarenseDBContext _context;
        private IEnumerable<Coworker> _coworker = new List<Coworker>();
        public CoworkerRepository(CarenseDBContext context)
        {
            // Inicialize sua lista de coworkers aqui, possivelmente carregando de um banco de dados
            _context = context;
        }

        public IEnumerable<Coworker> GetAll()
        {
            return _context.Coworker.ToList();
        }


        public Coworker? GetById(int id)
        {
            return _context.Coworker.FirstOrDefault(c => c.Id == id);
        }

        public bool Create(Coworker coworker)
        {
            try
            {
                _context.Coworker.Add(coworker);
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

        public bool Update(Coworker coworker)
        {
            try
            {
                _context.Entry(coworker).State = EntityState.Modified;
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
                var coworker = _context.Coworker.FirstOrDefault(c => c.Id == id);
                if (coworker == null)
                {
                    return false;
                }

                _context.Coworker.Remove(coworker);
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


