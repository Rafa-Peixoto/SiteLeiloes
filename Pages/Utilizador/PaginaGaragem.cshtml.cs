// No arquivo PagInicialModel.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteLeiloes.Data;
using SiteLeiloes.Models;

public class PaginaGaragemModel : PageModel
{
    public List<Carro> Carros { get; set; }
    public List<Leilao> Leiloes { get; set; }

    public void OnGet()
    {
        var dataTeste = new DataTeste();

        // Atribui a lista de leilões e carros do DataTeste 
        Leiloes = (List<Leilao>)dataTeste.Leiloes.
            Where(leilao => leilao.VendedorId == 1)
            .ToList();

        Carros = dataTeste.Carros
            .Where(carro =>
                carro.UserId == 1 &&
                !dataTeste.Leiloes.Any(leilao => leilao.CarroId == carro.Id))
            .ToList();

    }
}