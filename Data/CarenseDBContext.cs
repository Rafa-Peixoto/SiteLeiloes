using Microsoft.EntityFrameworkCore;
using SiteLeiloes.Models;

namespace SiteLeiloes.Data
{
    public class CarenseDBContext : DbContext
    {
        public CarenseDBContext(DbContextOptions<CarenseDBContext> opt): base(opt){
        }
        public DbSet<Coworker> Coworker { get; set;}
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Carro> Carro { get; set; }
        public DbSet<Leilao> Leilao { get; set; }
        public DbSet<LeilaoFavorito> LeilaoFavorito { get; set; }
        public DbSet<Utilizador> Utilizador { get; set; }
        public DbSet<Venda> Venda { get; set; }

    }
}
