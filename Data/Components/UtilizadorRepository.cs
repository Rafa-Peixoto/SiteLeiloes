using Microsoft.EntityFrameworkCore;
using SiteLeiloes.Data.Interfaces;
using SiteLeiloes.Models;
using System.Diagnostics;
using BCrypt.Net;
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
                utilizador.Password = BCrypt.Net.BCrypt.HashPassword(utilizador.Password);
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
            // Encontrar o utilizador com base no nome de utilizador
            var utilizador = _context.Utilizador
                .FirstOrDefault(u => u.Username == username);

            if (utilizador == null)
            {
                // O utilizador não foi encontrado
                return null;
            }

            // Verificar se a palavra-passe coincide
            if (BCrypt.Net.BCrypt.Verify(password, utilizador.Password))
            {
                return utilizador;
            }

            // A palavra-passe está incorreta
            return null;
        }
    }
}
