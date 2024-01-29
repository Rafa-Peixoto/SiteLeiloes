
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SiteLeiloes.Data.Interfaces;
using System.ComponentModel.DataAnnotations;
using SiteLeiloes.Models;
using Microsoft.AspNetCore.Authorization;

[AllowAnonymous]
public class RegisterModel : PageModel
{
    private readonly IUtilizadorRepository _utilizadorRepository;
    
    [BindProperty]
    public Utilizador novoUtilizador { get; set; }

    [BindProperty]
    public string ConfirmPassword { get; set; }
    public RegisterModel(IUtilizadorRepository utilizadorRepository)
    {
        _utilizadorRepository = utilizadorRepository;
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

        if (ModelState.IsValid)
        {
            _utilizadorRepository.Create(novoUtilizador);
            _utilizadorRepository.SaveChanges();
            //return RedirectToPage("/PagInicial");
        }

        // Redirecionar para a página de sucesso ou login
       
        return new JsonResult(new { success = true });
    }
}
