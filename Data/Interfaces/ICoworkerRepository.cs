using SiteLeiloes.Models;

namespace SiteLeiloes.Data.Interfaces
{
    public interface ICoworkerRepository
    {
        bool SaveChanges();
        IEnumerable<Coworker> GetAll();
        Coworker GetById(int id);
        bool Create(Coworker coworker);
        public bool Update(Coworker coworker);
        public bool Delete(int id);
    }
}
