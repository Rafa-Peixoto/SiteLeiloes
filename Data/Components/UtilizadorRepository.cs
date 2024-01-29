using Microsoft.EntityFrameworkCore;
using SiteLeiloes.Data.Interfaces;
using SiteLeiloes.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiteLeiloes.Data.Components
{
    public class UtilizadorRepository : IUtilizadorRepository
    {
        private readonly CarenseDBContext _context;
        private IEnumerable<Utilizador> _utilizador = new List<Utilizador>();
        public UtilizadorRepository(CarenseDBContext context)
        {
            // Inicialize sua lista de utilizadores aqui, possivelmente carregando de um banco de dados
            _context = context;
        }

        public IEnumerable<Utilizador> GetAll()
        {
            return _context.Utilizador.ToList();
        }


        public Utilizador GetById(int id)
        {
            return _context.Utilizador.FirstOrDefault(c => c.Id == id);
        }

        public bool Create(Utilizador utilizador)
        {
            try
            {
                _context.Utilizador.Add(utilizador);
                _context.SaveChanges();
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

        public bool Update(Utilizador utilizador)
        {
            try
            {
                _context.Entry(utilizador).State = EntityState.Modified;
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
                var utilizador = _context.Utilizador.FirstOrDefault(c => c.Id == id);
                if (utilizador == null)
                {
                    return false;
                }

                _context.Utilizador.Remove(utilizador);
                return SaveChanges();
            }
            catch (Exception)
            {
                // Log the exception
                return false;
            }
        }
        public Utilizador GetByCredentials(string username, string password)
        {
            return _context.Utilizador.FirstOrDefault(c => c.Username == username && c.Password == password);
        }
    }
}
