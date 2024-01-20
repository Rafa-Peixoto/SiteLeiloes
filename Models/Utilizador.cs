namespace SiteLeiloes.Models
{
    public class Utilizador
    {
        public int Id { get; internal set; }
        public string Username { get; internal set; } = "";
        public string Password { get; internal set; } = "";
        public string Nome { get; internal set; } = "";
        public int Idade { get; internal set; }
        public string Email { get; internal set; } = "";
        public string Telefone { get; internal set; } = "";
        public string CC { get; internal set; } = "";
        public string Nif { get; internal set; } = "";
        public float Avaliacao_total { get; internal set; }
        public int Nr_avaliacoes { get; internal set; }

        public Utilizador(int id, string username, string password, string nome, int idade, string email, string telefone, string cc, string nif, float avaliacao_total, int nr_avaliacoes)
        {
            Id = id;
            Username = username;
            Password = password;
            Nome = nome;
            Idade = idade;
            Email = email;
            Telefone = telefone;
            CC = cc;
            Nif = nif;
            Avaliacao_total = avaliacao_total;
            Nr_avaliacoes = nr_avaliacoes;
        }

    }
}