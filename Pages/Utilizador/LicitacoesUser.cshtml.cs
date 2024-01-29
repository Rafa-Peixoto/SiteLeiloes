using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteLeiloes.Data;
using SiteLeiloes.Models;

namespace SiteLeiloes.Pages.Utilizador
{
    public class LicitacoesUserModel : PageModel
    {
        public List<Leilao> Leiloes { get; set; }

        public void OnGet()
        {
            var dataTeste = new DataTeste();

            // Obtendo a lista de leil�es
            List<Leilao> leiloes = dataTeste.Leiloes;

            // Filtrando os leil�es onde o licitador com ID 1 est� presente
            //    Leiloes = leiloes
            //       .Where(leilao => leilao.Licitadores.Any(licitador => licitador.UtilizadorId == 1))
            //       .ToList();
        }
    }
}