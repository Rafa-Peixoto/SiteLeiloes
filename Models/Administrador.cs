namespace SiteLeiloes.Models
{
    public class Administrador
    {
        public int Id { get; internal set; }
        public string Username { get; internal set; } = "";
        public string Password { get; internal set; } = "";
        public Administrador(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}