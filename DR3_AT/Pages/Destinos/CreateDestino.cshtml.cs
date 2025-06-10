using DR3_AT.Data;
using DR3_AT.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DR3_AT.Pages.Destinos;

public class CreateDestino : PageModel
{
    private readonly AgenciaTurismoContext _context;

    [BindProperty]
    public Destino Destino { get; set; }

    public CreateDestino(AgenciaTurismoContext context)
    {
        _context = context;
    }
    public void OnGet()
    {
        
    }
        
    public async Task<IActionResult> OnPostAsync()
    {
        
        if (!ModelState.IsValid) return Page();

        await _context.Destinos.AddAsync(Destino);
        await _context.SaveChangesAsync();
        
        return RedirectToPage($"./DetailsDestino/", new { id = Destino.Id }); 
    }
}