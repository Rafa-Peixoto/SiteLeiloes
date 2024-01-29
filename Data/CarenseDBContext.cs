using Microsoft.EntityFrameworkCore;
using SiteLeiloes.Models;

namespace SiteLeiloes.Data
{
    public class CarenseDBContext : DbContext
    {
        public CarenseDBContext(DbContextOptions<CarenseDBContext> opt) : base(opt)
        {
        }
        public DbSet<Coworker> Coworker { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Carro> Carro { get; set; }
        public DbSet<Leilao> Leilao { get; set; }
        public DbSet<LeilaoFavorito> LeilaoFavorito { get; set; }
        public DbSet<Utilizador> Utilizador { get; set; }
        public DbSet<Venda> Venda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurando as relações para Leilao
            // Cada Leilao está associado a um Cliente (Utilizador)
            modelBuilder.Entity<Leilao>()
                .HasOne(l => l.Cliente)
                .WithMany() // Sem propriedade de navegação reversa em Utilizador
                .HasForeignKey(l => l.ClienteId)
                .OnDelete(DeleteBehavior.Restrict); // Previne a exclusão em cascata

            // Cada Leilao está associado a um Vendedor (Utilizador)
            modelBuilder.Entity<Leilao>()
                .HasOne(l => l.Vendedor)
                .WithMany() // Sem propriedade de navegação reversa em Utilizador
                .HasForeignKey(l => l.VendedorId)
                .OnDelete(DeleteBehavior.Restrict); // Previne a exclusão em cascata

            // Cada Leilao está associado a um Carro
            modelBuilder.Entity<Leilao>()
                .HasOne(l => l.Carro)
                .WithMany() // Sem propriedade de navegação reversa em Carro
                .HasForeignKey(l => l.CarroId)
                .OnDelete(DeleteBehavior.Restrict); // Previne a exclusão em cascata


            // Configurando as relações para LeilaoFavorito
            modelBuilder.Entity<LeilaoFavorito>()
                .HasOne(lf => lf.Leilao)
                .WithMany() // Sem propriedade de navegação reversa em Leilao
                .HasForeignKey(lf => lf.LeilaoId)
                .OnDelete(DeleteBehavior.Restrict); // Previne a exclusão em cascata

            modelBuilder.Entity<LeilaoFavorito>()
                .HasOne(lf => lf.Utilizador)
                .WithMany() // Sem propriedade de navegação reversa em Utilizador
                .HasForeignKey(lf => lf.UtilizadorId)
                .OnDelete(DeleteBehavior.Restrict); // Previne a exclusão em cascata


            // Configurando as relações para Venda
            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Vendedor)
                .WithMany() // Sem propriedade de navegação reversa em Utilizador
                .HasForeignKey(v => v.VendedorId)
                .OnDelete(DeleteBehavior.Restrict); // Previne a exclusão em cascata

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Cliente)
                .WithMany() // Sem propriedade de navegação reversa em Utilizador
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict); // Previne a exclusão em cascata

            modelBuilder.Entity<Venda>()
                .HasOne(v => v.Carro)
                .WithMany() // Sem propriedade de navegação reversa em Carro
                .HasForeignKey(v => v.CarroId)
                .OnDelete(DeleteBehavior.Restrict); // Previne a exclusão em cascata

            // Configurações adicionais podem ser inseridas aqui
        }

    }
}
