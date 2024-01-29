// No arquivo PagInicialModel.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteLeiloes.Data;
using SiteLeiloes.Models;

public class LeiloesFuturosModel : PageModel
{
    public List<Leilao> Leiloes { get; set; }

    public void OnGet()
    {
        // Instancia a classe DataTeste
        var dataTeste = new DataTeste();

        // Atribui a lista de leilões do DataTeste para a propriedade Leiloes
        Leiloes = dataTeste.Leiloes.
            Where(leilao => DateTime.Now <= leilao.Data_de_inicio)
            .ToList();
    }

}