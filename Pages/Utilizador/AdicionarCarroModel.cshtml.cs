using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteLeiloes.Data;
using SiteLeiloes.Models;
using SiteLeiloes.Data.Interfaces;
using System.Security.Claims;

public class AdicionarCarroModel : PageModel
{
    [BindProperty]
    public Carro NovoCarro { get; set; }

    private readonly ICarroRepository _carroRepository; 

    public AdicionarCarroModel(ICarroRepository carroRepository)
    {
        _carroRepository = carroRepository;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        NovoCarro.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        
        var sucesso = _carroRepository.Create(NovoCarro);

        if (!sucesso)
        {
            return Page();
        }

        return RedirectToPage("/PaginaGaragem");
    }
}
