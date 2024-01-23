using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using SiteLeiloes.Models;
using System.Collections.Generic;
using SiteLeiloes.Data;
using System.Drawing;

namespace SiteLeiloes.Pages.Utilizador
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public InputModel RegisterInput { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Nome de usuario")]
            public string? Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string? Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string? Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme a senha")]
            [Compare("Password", ErrorMessage = "As senhas nгo correspondem.")]
            public string? ConfirmPassword { get; set; }
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Aqui vocк adicionaria a lуgica para registrar o usuбrio
            // Por exemplo, adicionar ao seu banco de dados

            // Depois de registrar com sucesso, redirecionar para a pбgina de login ou confirmaзгo
            return RedirectToPage("/PagInicial/");
        }

    }
    public class RegisterInputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        // ... Outras propriedades ...
    }
}
