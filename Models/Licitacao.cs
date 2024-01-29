namespace SiteLeiloes.Models
{
    public class Licitacao
    {
        public int LeilaoId { get; set; }
        public Leilao Leilao { get; set; }

        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}
