namespace SiteLeiloes.Models
{
    public class Venda
    {
        public int Id { get; internal set; }
        public DateTime Data_fim { get; internal set; }
        public int Preco { get; internal set; }
        public int VendedorId { get; internal set; }
        public int ClienteId { get; internal set; }
        public int CarroId { get; internal set; }

        // Propriedades de navegação
        public virtual Utilizador Vendedor { get; set; }
        public virtual Utilizador Cliente { get; set; }
        public virtual Carro Carro { get; set; }

        public Venda(int id, DateTime data_fim, int preco, int vendedorId, int clienteId, int carroId)
        {
            Id = id;
            Data_fim = data_fim;
            Preco = preco;
            VendedorId = vendedorId;
            ClienteId = clienteId;
            CarroId = carroId;
        }
    }
}