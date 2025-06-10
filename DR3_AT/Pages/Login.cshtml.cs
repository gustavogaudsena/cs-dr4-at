using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace DR3_AT.Pages;

public class Login : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
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

        if (Input.Email == "rinaldo@email.com" && Input.Password == "senha123")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Administrador"),
                new Claim(ClaimTypes.Email, Input.Email),
            };

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity), authProperties);

            return RedirectToPage("/Index");
        }

        ModelState.AddModelError(string.Empty, "Login ou senha inválidos.");
        return Page();
    }
}