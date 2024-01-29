using SiteLeiloes.Models;
// No arquivo PagInicialModel.cs
using SiteLeiloes.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using SiteLeiloes.Data;
using System.Drawing;

public class PagInicialModel : PageModel
{
    public List<Leilao> Leiloes { get; set; }

    public void OnGet(string marca, string ordenacao)
    {

          if (!User.Identity.IsAuthenticated)
            {
                // Se o utilizador não estiver autenticado, você pode redirecioná-lo para a página de login
                Response.Redirect("/Login");
            }

        // Recupere informações da sessão
        var nomeUtilizador = User.Identity.Name;
        // Exemplo: Recupere outras informações armazenadas na sessão usando a serialização JSON
        //var outrasInformacoes = JsonConvert.DeserializeObject<OutrasInformacoesTipo>(HttpContext.Session.GetString("OutrasInformacoes"));

        // Instancia a classe DataTeste ou obtйm os dados de um repositуrio
        var dataTeste = new DataTeste();
        IEnumerable<Leilao> query = dataTeste.Leiloes;

        // Se o filtro de marca foi fornecido, filtre a lista de leilхes pela marca
        if (!string.IsNullOrEmpty(marca))
        {
            query = query.Where(leilao => leilao.Carro.Marca.Contains(marca, StringComparison.OrdinalIgnoreCase));

        }

        // Ordena a lista de leilхes de acordo com a seleзгo do usuбrio
        switch (ordenacao)
        {
            case "dataCrescente":
                query = query.OrderBy(leilao => leilao.Data_de_fim);
                break;
            case "dataDecrescente":
                query = query.OrderByDescending(leilao => leilao.Data_de_fim);
                break;
            case "valorCrescente":
                query = query.OrderBy(leilao => leilao.Valor); // Substitua Valor pelo campo correto
                break;
            case "valorDecrescente":
                query = query.OrderByDescending(leilao => leilao.Valor); // Substitua Valor pelo campo correto
                break;
        }

        // Atribui a lista de leilхes ordenada para a propriedade Leiloes
        Leiloes = query.ToList();
    }
}


