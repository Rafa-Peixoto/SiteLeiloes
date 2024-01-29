using SiteLeiloes.Models;
// No arquivo PagInicialModel.cs
using SiteLeiloes.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using SiteLeiloes.Data;
using System.Drawing;

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