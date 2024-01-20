namespace SiteLeiloes.Models
{
    public class Venda
    {
        public int Id { get; internal set; }
        public DateTime Data_fim { get; internal set; }
        public int Preco { get; internal set; }
        public int Vendedor { get; internal set; }
        public int Cliente { get; internal set; }
        public int Carro { get; internal set; }

        public Venda(int id, DateTime data_fim, int preco, int vendedor, int cliente, int carro)
        {
            Id = id;
            Data_fim = data_fim;
            Preco = preco;
            Vendedor = vendedor;
            Cliente = cliente;
            Carro = carro;
        }

    }
}