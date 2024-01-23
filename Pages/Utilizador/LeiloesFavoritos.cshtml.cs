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
        Leiloes = new List<Leilao>
        {
            new Leilao(1, 500.00f,10, 600.00f,1,4, DateTime.Now.AddMinutes(30), DateTime.Now.AddHours(2), "/images/lamboUrus.png"),
            new Leilao(2, 800.00f,11, 900.00f,3,7, DateTime.Now.AddHours(2), DateTime.Now.AddDays(1), "/images/BMW-E36-M3.jpg"),
            new Leilao(3, 700.00f,31, 750.00f,4,7, DateTime.Now.AddDays(1), DateTime.Now.AddDays(3), "/images/ferrari.png")
    };
    }

}