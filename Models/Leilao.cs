namespace SiteLeiloes.Models
{
    public class Leilao
    {
        public int Id { get; internal set; }
        public float Preco_minimo { get; internal set; }
        public int Cliente { get; internal set; }
        public float Valor { get; internal set; }
        public int Vendedor { get; internal set; }
        public int Carro { get; internal set; }
        public DateTime Data_de_inicio { get; internal set; }
        public DateTime Data_de_fim { get; internal set; }
        public Leilao(int id, float preco_minimo, int cliente, float valor, int vendedor, int carro, DateTime data_de_inicio, DateTime data_de_fim)
        {
            Id = id;
            Preco_minimo = preco_minimo;
            Cliente = cliente;
            Valor = valor;
            Vendedor = vendedor;
            Carro = carro;
            Data_de_inicio = data_de_inicio;
            Data_de_fim = data_de_fim;
        }
    }
}
