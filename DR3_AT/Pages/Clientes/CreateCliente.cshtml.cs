using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR3_AT.Pages.Clientes;

public class CreateCliente : PageModel
{
    
    [BindProperty]
    public Cliente Cliente { get; set; } = new();
    
    public void OnGet()
    {
        
    }
    
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page(); 
        }

        // Cria o cliente e adiciona no banco de dados que será integrado na parte 3
        // await _context.Cliente.AddAsync(Cliente);
        
        return RedirectToPage("./Clientes/CreateCliente"); 
    }
}