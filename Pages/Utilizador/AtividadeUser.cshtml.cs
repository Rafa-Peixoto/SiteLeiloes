using SiteLeiloes.Models;
// No arquivo PagInicialModel.cs
using SiteLeiloes.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using SiteLeiloes.Data;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace SiteLeiloes.Pages.Utilizador.AtividadeUser
{
    public class AtividadeUserModel : PageModel
    {
        public List<Carro> CarrosVendidos { get; set; }
        public List<Carro> CarrosComprados { get; set; }
        public List<Venda> Vendas { get; set; }
        public List<Venda> Compras { get; set; }

        public void OnGet()
        {
            var dataTeste = new DataTeste();

            Vendas = dataTeste.Vendas
                .Where(vendas => vendas.VendedorId == 1)
                .ToList();
            var vendas = dataTeste.Vendas
                .Where(vendas => vendas.VendedorId == 1)
                .ToList();
            CarrosVendidos = dataTeste.Carros
                .Where(carro => vendas.Any(venda => venda.Carro.Id == carro.Id))
                .ToList();
            Compras = dataTeste.Vendas
               .Where(compras => compras.ClienteId == 1)
               .ToList();
            var compras = dataTeste.Vendas
                .Where(compras => compras.ClienteId == 1)
                .ToList();
            CarrosVendidos = dataTeste.Carros
                .Where(carro => compras.Any(compra => compra.Carro.Id == carro.Id))
                .ToList();
        }
    }
}
