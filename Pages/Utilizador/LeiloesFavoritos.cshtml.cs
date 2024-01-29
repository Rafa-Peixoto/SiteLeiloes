// No arquivo PagInicialModel.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteLeiloes.Data;
using SiteLeiloes.Models;

public class LeiloesFavoritosModel : PageModel
{
    public List<Leilao> Leiloes { get; set; }

    public void OnGet()
    {
        var dataTeste = new DataTeste();

        var leiloesFavoritos = dataTeste.LeiloesFav
            .Where(leilaoFav => leilaoFav.UtilizadorId == 1)
            .ToList();
        Leiloes = dataTeste.Leiloes
            .Where(leilao => leiloesFavoritos.Any(leilaoFav => leilaoFav.LeilaoId == leilao.Id))
            .ToList();
    }

}