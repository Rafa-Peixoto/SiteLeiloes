namespace SiteLeiloes.Models
{
    public class Carro
{
        public int Id { get; internal set; }
        public string Marca { get; internal set; } = "";
        public string Modelo { get; internal set; } = "";
        public int Ano { get; internal set; }
        public int Km { get; internal set; } 
        public string Condicao { get; internal set; } = "";
        public string ImagemUrl { get; set; } // Propriedade para o caminho da imagem


        public Carro(int id, string marca, string modelo, int ano, int km, string condicao, string imagemUrl)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Km = km;
            Condicao = condicao;
            ImagemUrl = imagemUrl; // Defina o caminho da imagem ao criar o objeto
        }
    }
}
