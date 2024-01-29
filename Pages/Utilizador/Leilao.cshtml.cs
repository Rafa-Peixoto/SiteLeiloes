// Em seu arquivo leilao.cshtml.cs
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using SiteLeiloes.Data.Interfaces;
using SiteLeiloes.Models;


namespace SiteLeiloes.Pages.Utilizador
{
    public class LeilaoModel : PageModel
    {
        public LeilaoViewModel Leilao { get; set; }
        private readonly ILeilaoRepository _repository;

        public LeilaoModel(ILeilaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var leilaoEntity = await _repository.GetByIdAsync(id);
            if (leilaoEntity == null)
            {
                return NotFound();
            }
            var carroEntity = await _repository.GetCarroByIdAsync(leilaoEntity.CarroId);
            if (carroEntity == null)
            {
                return NotFound("Carro nгo encontrado.");
            }

            Leilao = new LeilaoViewModel
            {
                Id = leilaoEntity.Id,
                Preco_minimo = leilaoEntity.Preco_minimo,
                Valor = leilaoEntity.Valor,
                VendedorId = leilaoEntity.VendedorId,
                CarroId = leilaoEntity.CarroId,
                Data_de_inicio = leilaoEntity.Data_de_inicio,
                Data_de_fim = leilaoEntity.Data_de_fim,
                ImagemUrl = leilaoEntity.ImagemUrl,
                MarcaCarro = carroEntity.Marca,
                ModeloCarro = carroEntity.Modelo,
                AnoCarro = carroEntity.Ano,
                KmCarro = carroEntity.Km,
                CondicaoCarro = carroEntity.Condicao,
                ImagemCarro = carroEntity.ImagemUrl,
            };

            return Page();
        }
        [BindProperty]
        public float BidValue { get; set; } // Vincule o valor do lance do formulбrio

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var leilaoEntity = await _repository.GetByIdAsync(id);
            if (leilaoEntity == null)
            {
                return NotFound();
            }

            if (BidValue > leilaoEntity.Valor)
            {
                leilaoEntity.Valor = BidValue;
                // Atualize a entidade leilao no banco de dados
                await _repository.UpdateAsync(leilaoEntity);
                await _repository.SaveChangesAsync();
                // Redirecione para a pбgina de sucesso ou atualize a pбgina atual
                return RedirectToPage(new { id = id });
            }
            else
            {
                // Se o valor da licitaзгo for menor ou igual ao valor atual, adicione um erro de validaзгo
                ModelState.AddModelError("BidValue", "A licitaзгo deve ser maior que a licitaзгo atual.");
                return Page(); // Retorne а pбgina atual para mostrar o erro
            }
        }

    }
}

