using SiteLeiloes.Models;

namespace SiteLeiloes.Data.Interfaces
{
    public interface IUtilizadorRepository
    {
        bool SaveChanges();
        IEnumerable<Utilizador> GetAll();
        Utilizador GetById(int id);
        bool Create(Utilizador utilizador);
        public bool Update(Utilizador utilizador);
        public bool Delete(int id);
    }
}

