using SiteLeiloes.Models;

namespace SiteLeiloes.Data.Interfaces
{
    public interface ILeilaoRepository
    {
        bool SaveChanges();
        IEnumerable<Leilao> GetAll();
        Leilao GetById(int id);
        bool Create(Leilao leilao);
        public bool Update(Leilao leilao);
        public bool Delete(int id);
    }
}