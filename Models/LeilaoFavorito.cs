namespace SiteLeiloes.Models
{
    public class LeilaoFavorito
    {
        public int Id { get; internal set; }
        public int LeilaoId { get; internal set; }
        public int UtilizadorId { get; internal set; }

        public LeilaoFavorito(int leilaoId, int utilizadorId)
        {
            LeilaoId = leilaoId;
            UtilizadorId = utilizadorId;
        }
    }
}
    

