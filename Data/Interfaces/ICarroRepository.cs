using SiteLeiloes.Models;

namespace SiteLeiloes.Data.Interfaces
{
    public interface ICarroRepository
    {
        bool SaveChanges();
        IEnumerable<Carro> GetAll();
        Carro GetById(int id);
        bool Create(Carro carro);
        public bool Update(Carro carro);
        public bool Delete(int id);
    }
}
