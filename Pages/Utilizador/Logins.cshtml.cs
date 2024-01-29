using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SiteLeiloes.Data.Interfaces;
using System.Diagnostics;
using System.Security.Claims;

namespace SiteLeiloes.Pages.Utilizador
{
    [AllowAnonymous]
    public class LoginsModel : PageModel
    {

        private readonly IUtilizadorRepository _utilizadorRepository;
        private readonly ILogger<LoginsModel> _logger;

        [BindProperty]
        public LoginInputModel Input { get; set; }

        public LoginsModel(IUtilizadorRepository utilizadorRepository, ILogger<LoginsModel> logger)
        {
            _utilizadorRepository = utilizadorRepository;
            _logger = logger;
        }
        public class LoginInputModel
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        public void OnGet()
        {
            // Página de carregamento
        }

        public object Get_logger()
        {
            return _logger;
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("Entrou no método OnPost");
            Debugger.Break();
            // Verifique se o utilizador existe
            var utilizador = _utilizadorRepository.GetByCredentials(Input.Username, Input.Password);

            if(!ModelState.IsValid)
            {
                return Page();
            }
            if (utilizador == null)
            {
                _logger.LogError($"Login falhou para o utilizador {Input.Username}. Utilizador não encontrado.");
                // Utilizador não encontrado
                ModelState.AddModelError(string.Empty, "Credenciais inválidas");
                return Page();
            }

            // Autenticação bem-sucedida
            HttpContext.Session.SetString("NomeUtilizador", utilizador.Username);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, utilizador.Username),
                new Claim(ClaimTypes.Email, utilizador.Email),
                // Adicione mais claims conforme necessário
            };

            var identity = new ClaimsIdentity(claims, "AuthenticationCookies");
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync("AuthenticationCookies", principal);

            // Adicione mais informações do utilizador à sessão conforme necessário
            return RedirectToPage("/PagInicial/"); // Substitua "/Index" pelo caminho da sua página principal


        }
    }
}

