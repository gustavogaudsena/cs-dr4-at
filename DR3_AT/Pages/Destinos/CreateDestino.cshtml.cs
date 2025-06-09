using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DR3_AT.Pages.Destinos;

public class CreateDestino : PageModel
{
    
    [BindProperty]
    public Destino Destino { get; set; }
    
    public void OnGet()
    {
        
    }
    
        
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page(); 
        }

        // Cria o destino e adiciona no banco de dados que será integrado na parte 3
        // await _context.Destino.AddAsync(Destino);
        
        return RedirectToPage("./Destinos/Createdestino"); 
    }
}