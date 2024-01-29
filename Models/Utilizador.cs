namespace SiteLeiloes.Models
{
    public class Utilizador
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get;  set; } = "";
        //public string Nome { get; set; } = "";
        //public int Idade { get; set; }
        //public string Telefone { get; set; } = "";
        //public string CC { get; set; } = "";
        //public string Nif { get; set; } = "";
        //public float Avaliacao_total { get; set; }
        //public int Nr_avaliacoes { get; set; }
        //public List<Licitacao>? Licitacoes { get; set; } = new List<Licitacao>();

        public Utilizador()
        {
            Username = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            //Nome = string.Empty;
            //Idade = 0;
            //Telefone = string.Empty;
            //CC = string.Empty;
            //Nif = string.Empty;
            //Avaliacao_total = 0.0f;
            //Nr_avaliacoes = 0;
        }
        //public float AvaliacaoMedia => Nr_avaliacoes > 0 ? Avaliacao_total / Nr_avaliacoes : 0;
    }
}